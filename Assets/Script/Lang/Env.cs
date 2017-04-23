using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audubon.Lang {
    public class Env {
        Dictionary<string, Value> table;
        public Env() {
            table = new Dictionary<string, Value>();
        }

        Env(Dictionary<string, Value> oldTable) {
            table = new Dictionary<string, Value>(oldTable);
        }

        public Value apply(string varname) {
            Value val;
            table.TryGetValue(varname, out val);
            return val;
        }

        void _extend(string varname, Value value) {
            table[varname] = value;
        }

        public Env extend(string varname, Value value) {
            var newtable = new Env(table);
            newtable._extend(varname, value);
            return newtable;
        }
    }
}
