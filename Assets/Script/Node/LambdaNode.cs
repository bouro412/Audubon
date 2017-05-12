using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Interface;
using System;
using Audubon.Lang;

namespace Audubon.Node
{
    public class LambdaNode : Node, IAstNode, ICatchable, IHasClickEvent
    {

        void IHasClickEvent.ClickEvent(SteamVR_Controller.Device controller)
        {

        }

        IAst IAstNode.GetAst()
        {
            throw new NotImplementedException();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}