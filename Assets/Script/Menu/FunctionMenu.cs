using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Audubon.Menu
{
    public class FunctionMenu : MonoBehaviour, IMenu
    {
        public Text NumberText;

        private string _functionPrehabPath = "prefab/FunctionNode";
        private int currentIndex = 0;
        private string[] _funcNames = new string[] {"Plus"};
        private bool isClose = false;

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
                var prefab = (GameObject)Resources.Load(_functionPrehabPath);
                var node = Instantiate(prefab, transform.position, Quaternion.Euler(0, 180, 0));
                node.GetComponent<Lang.Function.Plus>();
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