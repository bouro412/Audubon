using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Audubon.Node;

namespace Audubon.Menu
{
    class OperatorMenu : MonoBehaviour, IMenu
    {
        public Text ChoicesText;

        private int currentIndex = 0;
        private string[] _Operators = new string[] { "Lambda" };
        private bool isClose = false;

        bool IMenu.isMenuClose()
        {
            return isClose;
        }

        void IMenu.Update(SteamVR_TrackedObject controller)
        {
            var device = SteamVR_Controller.Input((int)controller.index);
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                //めんどいから今度頑張る
                /*
                // 左をクリック
                if (device.GetAxis().x < -0.5)
                {
                    currentValue = !currentValue;
                }
                // 右をクリック 
                else if (device.GetAxis().x > 0.5)
                {
                    currentValue = !currentValue;
                }
                NumberText.text = currentValue.ToString();
                */
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                var node = NodeMaker.CreateNode("LambdaNode", transform.position, Quaternion.Euler(0, 180, 0));
                node.GetComponent<Node.FunctionNode>();
                isClose = true;
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                isClose = true;
            }
        }
    }
}
