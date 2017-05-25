using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Lang;
using Audubon.Interface;
using System;

namespace Audubon.Node
{
    public class VariableSourceNode : Node, IClickEvent
    {
        public string VarName;
        private GameObject _prevNode;
        private Vector3 _initPosition;

        [ContextMenu("CreateVariableNode")]
        public GameObject CreateVariableNode()
        {
            var instance = NodeMaker.CreateNode("VariableNode", transform.position + new Vector3(0, -0.1f, 0),
                                    transform.rotation);
            instance.GetComponent<VariableNode>().Initialize(VarName);
            return instance;
        }
        protected override string Information()
        {
            return VarName;
        }

        void IClickEvent.ClickEvent(SteamVR_Controller.Device controller)
        {
            if (_prevNode != null && _prevNode.transform.position == _initPosition)
                return;
            _prevNode = CreateVariableNode();
            _initPosition = _prevNode.transform.position;
        }
    }
}
