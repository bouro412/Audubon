using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移動
/// </summary>
public class VIVEController : MonoBehaviour {

    public GameObject CameraRig;
    public GameObject CameraEye;
    [SerializeField]
    SteamVR_TrackedObject Controller;
	// Use this for initialization
	void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
        var device = SteamVR_Controller.Input((int)Controller.index);
        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
            var axis = device.GetAxis();
            var moveForward = Vector3.zero;
            var moveSide = Vector3.zero;
            var move = Vector3.zero;
            var shikiichi = 0.1;
            var speed = 0.05f;
            if(Mathf.Abs(axis.x) > shikiichi) {
                moveSide =  CameraEye.transform.right * speed * axis.x;
            }
            if (Mathf.Abs(axis.y) > shikiichi) {
                moveForward =  CameraEye.transform.forward * speed * axis.y;
            }
            CameraRig.transform.Translate(moveForward + moveSide);
        }

    }
}
