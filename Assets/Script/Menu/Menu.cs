using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour, IMenu{
    public GameObject TopMenu;
    public GameObject NodePrehab;
    [SerializeField, TooltipAttribute("各typeの生成MenuPrehabを入れてください")]
    public GameObject[] MenuPrehabs;
    [SerializeField, TooltipAttribute("各typeの名前を入れてください")]
    public string[] types;
    Audubon.Const[] vals = { new Audubon.Const((int)0), new Audubon.Const((float)0), new Audubon.Const(true) };
    int index = 0;
    GameObject menuObject;
    IMenu nextMenu;
    bool isClose = false;

    enum state {
        Top = 0,
        
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void IMenu.Update(SteamVR_TrackedObject controller) {
        Debug.Log("null? : " + (nextMenu == null) + ", not null? : " + (nextMenu != null));
        if (nextMenu != null) {
            nextMenu.Update(controller);
            if (nextMenu.isMenuClose()) {
                nextMenu = null;
                DestroyImmediate(menuObject);
            }
            return;
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
            /*
            var node = Instantiate(NodePrehab, transform.position, Quaternion.identity);
            node.GetComponent<Audubon.ExpNode>().expression = vals[index];
            Debug.Log(vals[index].information());
            */
            menuObject = Instantiate(MenuPrehabs[index], transform.parent, false);
            nextMenu = menuObject.GetComponent<IMenu>();
            Debug.Log(types[index] + " menu created");
        }
    }
    bool IMenu.isMenuClose() {
        return isClose;
    }   
}
