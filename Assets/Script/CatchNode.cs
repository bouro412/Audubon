//======= Copyright (c) Valve Corporation, All rights reserved. ===============
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class CatchNode : MonoBehaviour
{
	GameObject Target;
	Rigidbody attachPoint;

	public SteamVR_TrackedObject trackedObj;
	FixedJoint joint;

	void Awake()
	{
        attachPoint = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		var device = SteamVR_Controller.Input((int)trackedObj.index);
		if (joint == null && Target != null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
		{
			Target.transform.position = attachPoint.transform.position;
            Target.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

			joint = Target.AddComponent<FixedJoint>();
			joint.connectedBody = attachPoint;
		}
		else if (joint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
		{
			var go = joint.gameObject;
			var rigidbody = go.GetComponent<Rigidbody>();
			Object.DestroyImmediate(joint);
			joint = null;
			// Object.Destroy(go, 15.0f);

			// We should probably apply the offset between trackedObj.transform.position
			// and device.transform.pos to insert into the physics sim at the correct
			// location, however, we would then want to predict ahead the visual representation
			// by the same amount we are predicting our render poses.

			var origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
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
		}
	}

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.GetComponent<ICatchable>() != null) {
            Target = collider.gameObject;
        }
    }
    void OnTriggerExit(Collider collider) {
        if (collider.gameObject == Target) {
            Target = null;
        }
    }

}
