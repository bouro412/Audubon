using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour, IMenu{
    public GameObject TopMenu;
    public GameObject NodePrehab;
    string[] types = { "int", "float", "bool" };
    Audubon.Const[] vals = { new Audubon.Const((int)0), new Audubon.Const((float)0), new Audubon.Const(true) };
    int index = 0;

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
        var device = SteamVR_Controller.Input((int)controller.index);
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)) {
            if(device.GetAxis().x < -0.5) {
                Debug.Log(index);
                index = (index + 1) % types.Length;
                Debug.Log(index);

            } else if(device.GetAxis().x > 0.5) {
                Debug.Log(index);

                index = (index - 1) % types.Length; Debug.Log(index);

            }
            if (index < 0) index += types.Length;
            GetComponentInChildren<Text>().text = types[index];
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
            var node = Instantiate(NodePrehab, transform.position, Quaternion.identity);
            node.GetComponent<Audubon.ExpNode>().expression = vals[index];
            Debug.Log(vals[index].information());
        }
    }
}
