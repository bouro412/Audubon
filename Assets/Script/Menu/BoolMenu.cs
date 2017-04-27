using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Audubon.Lang;
using Audubon.Node;

namespace Audubon.Menu 
{
    public class BoolMenu : MonoBehaviour, IMenu
    {
        public GameObject NodePrehab;
        bool currentValue = true;
        public Text NumberText;
        bool isClose = false;

        void IMenu.Update(SteamVR_TrackedObject controller)
        {
            Debug.Log("Int Menu Update");
            var device = SteamVR_Controller.Input((int)controller.index);
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
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
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                var node = Instantiate(NodePrehab, transform.position, Quaternion.Euler(0, 180, 0));
                node.GetComponent<ValueNode>().valueExp = new Const((bool)currentValue);
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
