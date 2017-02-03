using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Audubon {
    public class ExpNode : MonoBehaviour, ICatchable {
        public IAst expression;
        Value LangValue { get; set; }
        TextMesh info;
        public GameObject[] argObjects;
        List<IAst> args;
        List<IAst> argsCache;
        GameObject CatchingHand;

        // Use this for initialization
        void Start() {
            if (argObjects == null) {
                args = new List<IAst>();
            } else {
                args = argObjects.Select(a => a.GetComponent<IAst>()).ToList();
            }
            argsCache = new List<IAst>(args);
            if(expression == null )expression = new Const();
        }

        // Update is called once per frame
        protected void Update() {
            displayInformation();
            if (hasValue()) {
                GetComponent<MeshRenderer>().material.color = Color.blue;
            }
            if (isEdited()) {
                expression.UpdateArgs(args);
            }
        }

        bool isEdited() {
            var ret = args.SequenceEqual(argsCache);
            if (!ret) {
                argsCache = args;
                return true;
            }
            return false;
        }

        public virtual bool hasValue() {
            return LangValue != null;
        }


        void run() {

        }

        void displayInformation() {
            if (info == null) {
                info = this.GetComponentInChildren<TextMesh>();
            }
            info.text = expression.information();
        }
        public virtual Value eval(Env env) {
            return expression.eval(env);
        }

    }
}