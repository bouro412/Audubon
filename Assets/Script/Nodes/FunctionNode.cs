using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class FunctionNode<T> : ObjectNode<T> {
    string fname;
    [SerializeField]
    protected List<GameObject> args;
    int argnum = 0;
    bool executed = false;
    

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    protected override string information()
    {
        return fname;
    }

    void setArg(GameObject arg)
    {
        args.Add(arg);
    }

    public override T execute()
    {
        if (hasValue())
        {
            return getValue();
        }
        var argnodes = args.Select(obj => obj.GetComponent<Node<>>()).ToArray();
        base.Update();
        if (args.Count >= argnum && argnodes.All(node =>
                node != null && node.hasValue()))

        {
            run();
            return getValue();
        }
        else
        {
            foreach (var n in argnodes)
            {
                n.execute();
            }
            return null;
        }
    }

}
