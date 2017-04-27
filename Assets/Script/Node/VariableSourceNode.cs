using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Lang;

namespace Audubon.Node
{
    public class VariableSourceNode : MonoBehaviour
    {
        public string VarName;
        private TextMesh _info;

        public GameObject PlaneNode;

        private void Start()
        {
            this.GetComponent<MeshRenderer>().material.color = Color.green;
        }

        private void Update()
        {
            displayInformation();
        }

        /*
        [ContextMenu("CreateVariableNode")]
        public GameObject CreateVariableNode()
        {

            GameObject instance = Instantiate(PlaneNode.gameObject, transform.position + new Vector3(1, 1, 1),
                                              transform.rotation) as GameObject;
            instance.AddComponent<ValueNode>();
            var variable = instance.GetComponent<ValueNode>();
            variable.valueExp = new Variable(VarName);

            return instance;
        }
    */

        void displayInformation()
        {
            if (_info == null)
            {
                _info = GetComponentInChildren<TextMesh>();
            }
            _info.text = VarName;
        }
    }
}
