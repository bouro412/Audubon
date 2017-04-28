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
        public Text NumberText;

        private string _prefabPath = "prefab/ValueNode";
        private bool currentValue = true;
        private bool isClose = false;

        void IMenu.Update(SteamVR_TrackedObject controller)
        {
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
                var prefab = (GameObject)Resources.Load(_prefabPath);
                var node = Instantiate(prefab, transform.position, Quaternion.Euler(0, 180, 0));
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
