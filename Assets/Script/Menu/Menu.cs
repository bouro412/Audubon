using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Audubon.Menu {
public class Menu : MonoBehaviour, IMenu{
    public GameObject TopMenu;
    public GameObject NodePrehab;
    [SerializeField, TooltipAttribute("各typeの生成MenuPrehabを入れてください")]
    public GameObject[] MenuPrehabs;
    [SerializeField, TooltipAttribute("各typeの名前を入れてください")]
    public string[] types;
    int index = 0;
    GameObject menuObject;
    IMenu nextMenu;
    bool isClose = false;

    enum state {
        Top = 0,
        
    }

    void IMenu.Update(SteamVR_TrackedObject controller) {
        if (nextMenu != null) {
            gameObject.GetComponent<Canvas>().enabled = false;
            nextMenu.Update(controller);
            if (nextMenu.isMenuClose()) {
                nextMenu = null;
                DestroyImmediate(menuObject);
            }
            return;
        }else {
            gameObject.GetComponent<Canvas>().enabled = true;
        }
        var device = SteamVR_Controller.Input((int)controller.index);
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)) {
            if (device.GetAxis().x < -0.5) {
                index = (index + 1) % types.Length;

            } else if (device.GetAxis().x > 0.5) {
                index = (index - 1) % types.Length; Debug.Log(index);
            }
            if (index < 0) index += types.Length;
            GetComponentInChildren<Text>().text = types[index];
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
            menuObject = Instantiate(MenuPrehabs[index], transform.parent, false);
            nextMenu = menuObject.GetComponent<IMenu>();
            Debug.Log(types[index] + " menu created");
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
            isClose = true;
        }
    }
    bool IMenu.isMenuClose() {
        return isClose;
    }   
}
}
