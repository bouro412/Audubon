using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ArgPipe : MonoBehaviour {
    Collider collider;
    GameObject LastCollideObject;
	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider collider) {
        if (LastCollideObject != null) {

        }
    }
}
