using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Lang;
using Audubon.Interface;
using System;

namespace Audubon.Node
{
    public class VariableSourceNode : Node, IHasClickEvent
    {
        public string VarName;

        [ContextMenu("CreateVariableNode")]
        public GameObject CreateVariableNode()
        {

            var prefab = PrefabManager.Instance.GetPrefab("VariableNode");
            GameObject instance = Instantiate(prefab, transform.position + new Vector3(0, -0.5f, 0),
                                              transform.rotation) as GameObject;
            instance.GetComponent<VariableNode>().Initialize(VarName);
            return instance;
        }
        protected override string Information()
        {
            return VarName;
        }

        void IHasClickEvent.ClickEvent()
        {
            CreateVariableNode();
        }
    }
}
