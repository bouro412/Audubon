using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Lang;

namespace Audubon.Node
{
    public class VariableSource : MonoBehaviour
    {
        public string VarName;
        TextMesh info;

        public GameObject PlaneNode;

        void Start()
        {
            this.GetComponent<MeshRenderer>().material.color = Color.green;
        }

        void Update()
        {
            displayInformation();
        }


        [ContextMenu("CreateVariableNode")]
        public GameObject CreateVariableNode()
        {

            GameObject instance = Instantiate(PlaneNode.gameObject, transform.position + new Vector3(1, 1, 1),
                                              transform.rotation) as GameObject;
            instance.AddComponent<ExpNode>();
            var variable = instance.GetComponent<ExpNode>();
            variable.expression = new Variable(VarName);

            return instance;
        }


        void displayInformation()
        {
            if (info == null)
            {
                info = GetComponentInChildren<TextMesh>();
            }
            info.text = VarName;
        }
    }
}
