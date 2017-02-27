using UnityEngine;
using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Audubon {
    public class Plus : IFunction {
        IAst[] args;
        void Start() {
            args = new IAst[2];
        }
        
        int IFunction.getArgNum() {
            return 2;
        }

        string IAst.information() {
            return "+";
        }

        Value IAst.eval(Env env) {
            var values = args.Select(a => a.eval(env)).ToArray();
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

        void IAst.UpdateArgs(IEnumerable<IAst> args) {
            this.args = args.ToArray();
        }

        IEnumerable<IAst> IFunction.getArgs() {
            return args;
        }
    }
}
