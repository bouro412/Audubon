using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolNode : ConstNode {
    public bool InitValue;

	// Use this for initialization
	void Start () {
        SetLangValue(new AudubonBool(InitValue));
	}
	
}
