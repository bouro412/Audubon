using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Audubon.Node;
using Audubon.Lang;

namespace Audubon.Menu 
{
    public class FloatMenu : MonoBehaviour, IMenu
    {
        public Text NumberText;

        private float _currentValue = 0.0f;
        private bool _isClose = false;

        void IMenu.Update(SteamVR_TrackedObject controller)
        {
            Debug.Log("Float Menu Update");
            var device = SteamVR_Controller.Input((int)controller.index);
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                // 左をクリック
                if (device.GetAxis().x < -0.5)
                {
                    _currentValue -= 0.1f;
                }
                // 右をクリック 
                else if (device.GetAxis().x > 0.5)
                {
                    _currentValue += 0.1f;
                }
                NumberText.text = _currentValue.ToString();
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                var node = NodeMaker.CreateNode("ValueNode",
                                       transform.position, Quaternion.Euler(0, 180, 0));
                node.GetComponent<ValueNode>().valueExp = new Const((float)_currentValue);
                _isClose = true;
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                _isClose = true;
            }
        }
        bool IMenu.isMenuClose()
        {
            return _isClose;
        }
    }

}
