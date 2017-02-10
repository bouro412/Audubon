using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移動
/// </summary>
public class VIVEController : MonoBehaviour{

    public GameObject CameraRig;
    public GameObject CameraEye;
    public GameObject MenuPrehab;
    GameObject Menu;
    [SerializeField]
    SteamVR_TrackedObject Controller;
    SteamVR_Controller.Device device;


    // Use this for initialization
    void Start() {
        device = SteamVR_Controller.Input((int)Controller.index);
    }

    // Update is called once per frame
    void Update() {
        if (Menu != null) {
            var m = Menu.GetComponent<IMenu>();
            m.Update(Controller);
            if (m.isMenuClose()) {
                DestroyImmediate(Menu);
                Menu = null;
            }
            return;
        }
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
            var axis = device.GetAxis();
            var moveForward = Vector3.zero;
            var moveSide = Vector3.zero;
            var move = Vector3.zero;
            var shikiichi = 0.1;
            var speed = 0.05f;
            if (Mathf.Abs(axis.x) > shikiichi) {
                moveSide = CameraEye.transform.right * speed * axis.x;
            }
            if (Mathf.Abs(axis.y) > shikiichi) {
                moveForward = CameraEye.transform.forward * speed * axis.y;
            }
            CameraRig.transform.Translate(moveForward + moveSide);
        }

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
            Menu = Instantiate(MenuPrehab, transform, false);
        }
    }
}
