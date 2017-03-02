using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Audubon {
    public class ExpNode : MonoBehaviour, ICatchable {
        public IAst expression;
        TextMesh info;

        // Use this for initialization
        void Start() {
			if (expression == null) {
				expression = new Const (123);
			}
		}

        // Update is called once per frame
        protected void Update() {
            displayInformation();
			Rigidbody rigid = GetComponent<Rigidbody> ();
			Debug.Log (rigid.velocity);
        }

        protected void displayInformation() {
			if (info == null) {
				info = this.GetComponentInChildren<TextMesh> ();
			} else {
				Debug.Log (expression == null);
				info.text = expression.information ();
			}
		}
        public virtual Value eval(Env env) {
            return expression.eval(env);
        }

    }
}