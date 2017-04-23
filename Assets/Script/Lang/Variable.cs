using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audubon.Lang {
    public class Variable : IAst {
        public string VarName;

        public string information() {
            return VarName;
        }

        public Value eval(Env env) {
            return env.apply(VarName);
        }

        public void UpdateArgs(IEnumerable<IAst> args) {
            throw new NotImplementedException();
        }

        public Variable(string name) {
            VarName = name;
        }

    }
}
