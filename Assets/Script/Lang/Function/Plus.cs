using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Audubon {
    public class Plus : IFunction {
        Dictionary<string, IAst> args;
        void Start() {
            args = new Dictionary<string, IAst>();
            args.Add("x", null);
            args.Add("y", null);
        }
        
        int IFunction.getArgNum() {
            return 2;
        }

        string IAst.information() {
            return "+";
        }

        Value IAst.eval(Env env) {
            var values = args.Select(a => a.Value.eval(env)).ToArray();
            int? ai = values[0].getInt();
            int? bi = values[1].getInt();
            float? af = values[0].getFloat();
            float? bf = values[1].getFloat();
            if (ai != null && bi != null) {
                return new Int(ai.Value + bi.Value);
            } else {
                return new Float((float)((ai ?? af) + (bi ?? bf)));
            }
        }

        void IFunction.AddArg(IAst ast, string argID)
        {
            if (args.Keys.Contains(argID))
            {
                args[argID] = ast;
            }
            else
            {
                Debug.LogError("Argument " + argID + "is not " + "'+' function argument");
            }
        }
    }
}
