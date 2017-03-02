using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon;

[RequireComponent(typeof(Collider))]
public class ArgPipe : MonoBehaviour {
    GameObject LastCollideObject;
    ExpNode node;
    public string argID;
    public IFunction Function;

	void Start () {
	}
	
	void Update () {
	        	
	}

    #region Trigger
    void OnTriggerStay(Collider collider) {
        if (node == null &&
            collider.gameObject.GetComponent<ExpNode>() != null && 
            collider.gameObject.GetComponent<Joint>() == null) {
            node = collider.gameObject.GetComponent<ExpNode>();
            
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if(LastCollideObject == collider.gameObject)
        {
            LastCollideObject = null;
        }
    }
    #endregion
}
