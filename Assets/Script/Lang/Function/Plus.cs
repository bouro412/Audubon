using UnityEngine;
using System.Collections;
using System.Linq;

namespace Audubon {
    public class Plus : Function {

        void Start() {
            FunctionName = "+";
            _argNum = 2;
        }
        protected override Value run(Value[] values) {
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
    }
}
