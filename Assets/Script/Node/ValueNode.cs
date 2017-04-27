using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Audubon.Lang;
using Audubon.Interface;
using System;

namespace Audubon.Node {
    internal class ValueNode : Node, ICatchable, IAstNode {
        public Const valueExp;

        // Use this for initialization
        void Start() {
			if (valueExp == null) {
				valueExp = new Const ();
			}
		}
        IAst IAstNode.GetAst()
        {
            return valueExp;
        }
        protected override string Information()
        {
            return valueExp.information();
        }
    }
}
