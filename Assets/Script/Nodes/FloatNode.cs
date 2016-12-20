using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatNode : ConstNode {
    public float InitValue;

	// Use this for initialization
	void Start () {
        SetLangValue(new AudubonFloat(InitValue));
	}
	
}
