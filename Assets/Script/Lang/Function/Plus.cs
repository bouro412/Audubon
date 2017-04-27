using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Audubon.Lang.Function {
    public class Plus : IFunction {
        /// <summary>
        /// à¯êîÉeÅ[ÉuÉã
        /// </summary>
        private Dictionary<string, IAst> Args { get; set; }

        public Plus() {
            Args = new Dictionary<string, IAst>();
            Args.Add("x", null);
            Args.Add("y", null);
        }
        
        int IFunction.GetArgNum() {
            return 2;
        }

        string IAst.information() {
            return "+";
        }

        Value IAst.eval(Env env) {
            var values = Args.Select(a => a.Value.eval(env)).ToArray();
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
            if (Args.Keys.Contains(argID))
            {
                Args[argID] = ast;
            }
            else
            {
                Debug.LogError("Argument " + argID + "is not " + "'+' function argument");
            }
        }
		string[] IFunction.GetIDs(){
			return new string[] {"x", "y"};
		}
    }
}
