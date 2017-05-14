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
        private IAst BodyAst { get; set; }
        public int ArgNum { get; private set; }
        void IHasClickEvent.ClickEvent(SteamVR_Controller.Device controller)
        {
            if (controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                if(controller.GetAxis().x < -0.3)
                {
                    ArgNum = Mathf.Min(ArgNum - 1, 0);
                }else if(controller.GetAxis().x > 0.3)
                {
                    ArgNum += 1;
                }
            }
        }

        IAst IAstNode.GetAst()
        {
        }

        protected override string Information()
        {
            return "Lambda: " + ArgNum;
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