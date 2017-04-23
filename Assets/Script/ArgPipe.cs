using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Lang;
using Audubon.Node;

namespace Audubon
{
    [RequireComponent(typeof(Collider))]
    public class ArgPipe : MonoBehaviour
    {
        GameObject LastCollideObject;
        ExpNode node;
        public string argID;
        GameObject ParentFunction;
        IFunction Function;
        Color defaultColor;

        void Start()
        {
            defaultColor = gameObject.GetComponentInChildren<MeshRenderer>().material.color;
            ParentFunction = transform.parent.gameObject;
            Function = ParentFunction.GetComponent<FunctionNode>().function;
        }

        void Update()
        {

        }

        void VomitNode()
        {

        }

        #region Trigger
        void OnTriggerStay(Collider collider)
        {
            if (node == null
                && collider.gameObject != ParentFunction
                && collider.gameObject.GetComponent<ExpNode>() != null
                && collider.gameObject.GetComponent<Joint>() == null

                )
            {
                node = collider.gameObject.GetComponent<ExpNode>();
                gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
                DestroyImmediate(collider.gameObject);
            }
        }
        void OnTriggerExit(Collider collider)
        {
            if (LastCollideObject == collider.gameObject)
            {
                LastCollideObject = null;
            }
        }
        #endregion
    }
}
