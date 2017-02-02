using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audubon {
    public class Value {
        public object value { get; protected set; }
        public Value(object value) {
            this.value = value;
        }
        public Value() {

        }
        public virtual int? getInt() {
            return null;
        }
        public virtual float? getFloat() {
            return null;
        }
        public virtual bool? getBool() {
            return null;
        }
        public virtual void AddDefaultNode(GameObject obj) {
        }
        public virtual string information() {
            return value.ToString();
        }
    }

    public class Int : Value {
        public Int(int v) {
            value = v;
        }
        public override int? getInt() {
            return (int)value;
        }
        public override void AddDefaultNode(GameObject obj) {
        }
    }

    public class Float : Value {
        public Float(float v) {
            value = v;
        }
        public override float? getFloat() {
            return (float)value;
        }
        public override void AddDefaultNode(GameObject obj) {
        }
    }

    public class Bool : Value {
        public Bool(bool v) {
            value = v;
        }
        public override bool? getBool() {
            return (bool)value;
        }
        public override void AddDefaultNode(GameObject obj) {
        }

    }

    public class Nil : Value {
        public Nil() {

        }
        public override string information() {
            return "nil";
        }
    }
}