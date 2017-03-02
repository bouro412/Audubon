using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon;

public class FunctionNode : ExpNode , ICatchable{
	public GameObject[] argPipe;
	public IFunction function;
	int argNum;
	public GameObject[] PipePrehabs;

	// Use this for initialization
	void Start (){
		if (function == null) {
			function = new Plus ();
		}
		argNum = function.GetArgNum();
		if (argNum - 1 < PipePrehabs.Length) {
			var pipes = Instantiate (PipePrehabs [argNum - 1], gameObject.transform);
			argPipe = new GameObject[argNum];
			for(int i = 0;i < pipes.transform.childCount;i++) {
				var pipe = pipes.transform.GetChild (i).gameObject;
				argPipe [i] = pipe;
				pipe.GetComponent<ArgPipe> ().argID = function.GetIDs() [i];
			}
		} else {
			Debug.LogError ("Too Many Argument.");
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
