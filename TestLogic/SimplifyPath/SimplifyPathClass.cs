using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestLogic.SimplifyPath
{
    public static class SimplifyPathClass
    {
        public static string SimplifyPath(string path)
        {
            var simplifiedPath = "";
            var afterSplit = path.Split('/');
            var stackPath = new Stack<string>();
            foreach (var eachSplit in afterSplit)
            {
                if(eachSplit != "")
                {

                    if (eachSplit == ".." && stackPath.Count > 0)
                    {
                        stackPath.Pop();
                    }
                    else if(eachSplit != "." && eachSplit != "..")
                    {
                        stackPath.Push(eachSplit);
                    }
                }
            }
            while(stackPath.Count > 0)
            {
                simplifiedPath = '/' + stackPath.Pop() + simplifiedPath;
            }

            return simplifiedPath == "" ? "/" : simplifiedPath;
        }
    }
}
