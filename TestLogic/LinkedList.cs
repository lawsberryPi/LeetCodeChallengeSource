using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpPlayground
{
    public class LinkedListLRU
    {
        public class LRUCache
        {
            private readonly int _capacity;
            private LRUNode _head;
            private LRUNode _tail;
            private Dictionary<int, int> _lruDictionary;
            public LRUCache(int capacity)
            {
                _capacity = capacity;
                _lruDictionary = new Dictionary<int, int>();
            }


            public int Get(int key)
            {
                var hasValue = _lruDictionary.TryGetValue(key, out int value);

                if (hasValue)
                {
                    MoveCurrentNodeToHead(key);
                }
                return hasValue ? value : - 1;
            }

            public void Put(int key, int value)
            {
                if (_lruDictionary.Count() == 0)
                {
                    _lruDictionary.Add(key, value);
                    _head = _tail = new LRUNode(key);
                }
                else
                {
                    if (_lruDictionary.ContainsKey(key))
                    {
                        _lruDictionary[key] = value;
                        MoveCurrentNodeToHead(key);
                    }
                    else
                    {
                        var newHead = new LRUNode(key);
                        newHead.NextNode = _head;
                        _head.PrevNode = newHead;
                        _head = newHead;

                        _lruDictionary.Add(key, value);
                        if(_lruDictionary.Count() > _capacity)
                        {
                            _lruDictionary.Remove(_tail.Key);
                            var tempTail = _tail;
                            tempTail.NextNode = null;
                            _tail = tempTail.PrevNode;
                        }
                    }
                }
            }

            private void MoveCurrentNodeToHead(int key)
            {
                var currentNode = _head;
                while (currentNode.Key != key)
                {
                    currentNode = currentNode.NextNode;
                }
                if (currentNode.PrevNode != null && currentNode.NextNode != null)
                {
                    currentNode.PrevNode.NextNode = currentNode.NextNode;
                    currentNode.NextNode.PrevNode = currentNode.PrevNode;
                    currentNode.PrevNode = null;
                    currentNode.NextNode = _head;
                    _head = currentNode;
                }
                else if (currentNode.NextNode == null)
                {
                    // if it is tail
                    if (currentNode.PrevNode != null)
                    {
                        currentNode.PrevNode.NextNode = null;
                        _tail = currentNode.PrevNode;
                    }
                    currentNode.PrevNode = null;
                    currentNode.NextNode = _head;
                    _head.PrevNode = currentNode;
                    _head = currentNode;
                }
            }
        }

        public class LRUNode
        {
            public LRUNode(int key)
            {
                Key = key;
            }
            public int Key { set; get; }
            public LRUNode? NextNode { set; get; }
            public LRUNode? PrevNode { set; get; }
        }
    }
}
