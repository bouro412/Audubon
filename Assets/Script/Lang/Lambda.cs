using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Audubon.Lang
{
    internal class Lambda : IAst, IFunction
    {
        private Dictionary<string, IAst> Args;
        private IAst BodyAst { get; set; }

        void IFunction.AddArg(IAst ast, string argID)
        {
            if (Args.Keys.Contains(argID))
            {
                Args[argID] = ast;
            }
            else
            {
                Debug.LogError("Argument " + argID + "is not " + "'+' function argument");
            }
        }

        Value IAst.eval(Env env)
        {
            Env newenv = env;
            foreach(var pair in Args)
            {
                if(pair.Value == null)
                {
                    throw new Exception("Argumentが空のままです");
                }
                newenv = newenv.Extend(pair.Key, pair.Value.eval(env));
            }
            return BodyAst.eval(newenv);
        }

        int IFunction.GetArgNum()
        {
            return Args.Count;
        }

        string[] IFunction.GetIDs()
        {
            return Args.Keys.ToArray();
        }

        string IAst.information()
        {
            return "Lambda:" + ((IFunction)this).GetArgNum();
        }



        public Lambda(string[] args, IAst body)
        {
            Args = new Dictionary<string, IAst>();
            foreach(var arg in args)
            {
                Args.Add(arg, null);
            }
            BodyAst = body;
        }
    }
}
