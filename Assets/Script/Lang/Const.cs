using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Audubon.Lang {
    public class Const : IAst {
        Value audubonValue { get; set; }

        public string information() {
            return audubonValue.information();
        }

        public Value eval(Env env) {
            return audubonValue;
        }

        public void UpdateArgs(IEnumerable<IAst> args) {
            throw new NotImplementedException();
        }

        public Const() {
            audubonValue = new Nil();
        }
        public Const(Value val) {
            audubonValue = val;
        }
        public Const(bool value) {
            audubonValue = new Bool(value);
        }
        public Const(int value) {
            audubonValue = new Int(value);
        }
        public Const(float value) {
            audubonValue = new Float(value);
        }
    }
}
