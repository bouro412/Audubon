using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audubon.Lang {
    public class Env {
        private Dictionary<string, Value> _table;
        public Env() {
            _table = new Dictionary<string, Value>();
        }

        private Env(Dictionary<string, Value> oldTable) {
            _table = new Dictionary<string, Value>(oldTable);
        }

        public Value Apply(string varname) {
            Value val;
            try
            {
                _table.TryGetValue(varname, out val);
                return val;
            }
            catch (ArgumentNullException e){
                Debug.LogError("Variable " + varname + " is not found.");
                throw e;
            }
        }

        private void _extend(string varname, Value value) {
            _table[varname] = value;
        }

        public Env Extend(string varname, Value value) {
            var newtable = new Env(_table);
            newtable._extend(varname, value);
            return newtable;
        }
    }
}
