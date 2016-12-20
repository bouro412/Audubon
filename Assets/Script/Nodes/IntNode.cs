using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntNode : ConstNode {
    public int InitValue;

	// Use this for initialization
	void Start () {
        SetLangValue(new AudubonInt(InitValue));
	}
	
}
