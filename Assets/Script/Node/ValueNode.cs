using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Audubon.Lang;
using Audubon.Interface;
using System;

namespace Audubon.Node {
    public class ValueNode : MonoBehaviour, ICatchable, IAstNode {
        public Const valueExp;
        TextMesh info;

        // Use this for initialization
        void Start() {
			if (valueExp == null) {
				valueExp = new Const (123);
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
				Debug.Log (valueExp == null);
				info.text = valueExp.information ();
			}
		}

        IAst IAstNode.GetAst()
        {
            return valueExp;
        }
    }
}
