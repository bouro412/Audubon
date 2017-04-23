using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audubon.Lang {
    public class For : IAst {
        IAst start;
        IAst end;
        IAst varName;
        Variable variableNode;
    
        public Variable variableNodePrehab;

        public string information() {
            throw new NotImplementedException();
        }

        public Value eval(Env env) {
            throw new NotImplementedException();
        }

        public void UpdateArgs(IEnumerable<IAst> args) {
            throw new NotImplementedException();
        }
    }
}
