using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntMenu : MonoBehaviour, IMenu {
    public GameObject NodePrehab;
    int currentValue = 0;
    public Text NumberText;
    bool menuClose = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void IMenu.Update(SteamVR_TrackedObject controller) {
        Debug.Log("Int Menu Update");
        var device = SteamVR_Controller.Input((int)controller.index);
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)) {
            // 左をクリック
            if (device.GetAxis().x < -0.5) {
                currentValue--;
            }
            // 右をクリック 
            else if (device.GetAxis().x > 0.5) {
                currentValue++;
            }
            NumberText.text = currentValue.ToString();
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
            var node = Instantiate(NodePrehab, transform.position, Quaternion.identity);
            node.GetComponent<Audubon.ExpNode>().expression = new Audubon.Const((int)currentValue);
            menuClose = true;
        }
    }
    bool IMenu.isMenuClose() {
        return menuClose;
    }
}
