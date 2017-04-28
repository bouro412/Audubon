using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Interface;
using Audubon.Menu;

namespace Audubon
{
    /// <summary>
    /// 移動, メニュー, ノードのキャッチ
    /// </summary>
    public class VIVEController : MonoBehaviour
    {

        public GameObject CameraRig;
        public GameObject CameraEye;
        private GameObject Menu;
        private string MenuPath = "Prefab/Menu/HandMenu";
        SteamVR_TrackedObject Controller;
    SteamVR_Controller.Device device;

        // Drag Node
        GameObject Target; // 掴む対象
        Rigidbody attachPoint; // コントローラーのRigidBody
        HingeJoint joint; // コントローラーとオブジェクトを結合するJoint

        enum State
        {
            Normal,
            Menu,
            Drag
        }
        State state = State.Normal;

        // Use this for initialization
        void Start()
        {
            Controller = GetComponent<SteamVR_TrackedObject>();
            device = SteamVR_Controller.Input((int)Controller.index);
            attachPoint = GetComponent<Rigidbody>();
        }

        void Update()
        {
            // stateの値に応じてupdateを呼ぶ
            switch (state)
            {
                case State.Normal:
                    NormalUpdate();
                    break;
                case State.Drag:
                    DragUpdate();
                    break;
                case State.Menu:
                    MenuUpdate();
                    break;
                default:
                    throw new Exception("Unknown Controller State.");
            }
        }
        #region 各StateのUpdate
        void NormalUpdate()
        {
            if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                var axis = device.GetAxis();
                var moveForward = Vector3.zero;
                var moveSide = Vector3.zero;
                var move = Vector3.zero;
                var shikiichi = 0.1;
                var speed = 0.05f;
                if (Mathf.Abs(axis.x) > shikiichi)
                {
                    moveSide = CameraEye.transform.right * speed * axis.x;
                }
                if (Mathf.Abs(axis.y) > shikiichi)
                {
                    moveForward = CameraEye.transform.forward * speed * axis.y;
                }
                CameraRig.transform.Translate(moveForward + moveSide);
            }
            if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && Target != null)
            {
                Target.transform.position = attachPoint.transform.position;
                Target.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

                joint = Target.AddComponent<HingeJoint>();
                joint.connectedBody = attachPoint;
                state = State.Drag;
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                var prefab = (GameObject)Resources.Load(MenuPath);
                Menu = Instantiate(prefab, transform, false);

                state = State.Menu;
            }
        }

        void MenuUpdate()
        {
            var m = Menu.GetComponent<IMenu>();
            m.Update(Controller);
            if (m.isMenuClose())
            {
                DestroyImmediate(Menu);
                Menu = null;
                state = State.Normal;
            }
        }
        void DragUpdate()
        {
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                joint = null;
                DestroyImmediate(Target);
                state = State.Normal;
            }
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                var go = joint.gameObject;
                var rigidbody = go.GetComponent<Rigidbody>();
                DestroyImmediate(joint);
                joint = null;
                // Object.Destroy(go, 15.0f);

                // We should probably apply the offset between trackedObj.transform.position
                // and device.transform.pos to insert into the physics sim at the correct
                // location, however, we would then want to predict ahead the visual representation
                // by the same amount we are predicting our render poses.

                var origin = Controller.origin ? Controller.origin : Controller.transform.parent;
                if (origin != null)
                {
                    rigidbody.velocity = origin.TransformVector(device.velocity);
                    rigidbody.angularVelocity = origin.TransformVector(device.angularVelocity);
                }
                else
                {
                    rigidbody.velocity = device.velocity;
                    rigidbody.angularVelocity = device.angularVelocity;
                }

                rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
                state = State.Normal;
            }
        }
        #endregion

        #region Trigger
        void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.GetComponent<ICatchable>() != null)
            {
                Target = collider.gameObject;
            }
        }
        void OnTriggerExit(Collider collider)
        {
            if (collider.gameObject == Target)
            {
                Target = null;
            }
        }
        #endregion
    }
}
