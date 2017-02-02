using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace Audubon {
    public class If : IAst {
        public IAst Cond;
        public IAst Then;
        public IAst Else;

        public void UpdateArgs(IEnumerable<IAst> args) {
            try {
                var a = args.ToArray();
                Cond = a[0];
                Then = a[1];
                Else = a[2];
            } catch (System.IndexOutOfRangeException) {
                return;
            }
        }

        public Value eval(Env env) {
            if (Cond == null || Then == null) {
                Debug.LogError("引数が足りません");
                return null;
            }
            var test = Cond.eval(env);
            if (test == null) {
                Debug.LogError("Cond式の評価に失敗");
                return null;
            }
            if (!test.getBool().HasValue) {
                Debug.LogError("ifの条件文にbool以外が入っています");
                return null;
            }
            if (test.getBool().Value == true) {
                return Then.eval(env);
            } else if (Else != null) {
                return Else.eval(env);
            }
            return new Nil();

        }

        public string information() {
            return "if";
        }
    }
}
