using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Audubon.Lang;
using Audubon.Node;

namespace Audubon.Menu
{
    public class IntMenu : MonoBehaviour, IMenu
    {
        public Text NumberText;

        int currentValue = 0;
        bool isClose = false;

        void IMenu.Update(SteamVR_TrackedObject controller)
        {
            var device = SteamVR_Controller.Input((int)controller.index);
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                // 左をクリック
                if (device.GetAxis().x < -0.5)
                {
                    currentValue--;
                }
                // 右をクリック 
                else if (device.GetAxis().x > 0.5)
                {
                    currentValue++;
                }
                NumberText.text = currentValue.ToString();
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                var node = NodeMaker.CreateNode("ValueNode", transform.position, Quaternion.Euler(0, 180, 0));
                node.GetComponent<ValueNode>().valueExp = new Const((int)currentValue);
                isClose = true;
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                isClose = true;
            }
        }
        bool IMenu.isMenuClose()
        {
            return isClose;
        }
    }
}
