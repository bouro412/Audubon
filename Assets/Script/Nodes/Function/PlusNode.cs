using UnityEngine;
using System.Collections;
using System.Linq;

public class PlusNode : FunctionNode {

    string fname = "+";
    bool executed = false;
    int? resultInt = null;
    float? resultFloat = null;
	// Use this for initialization
	void Start () {
	
	}

	public override object execute () {
        if (hasValue())
        {
            return getValue();
        }
        var argnodes = args.Select(obj => obj.GetComponent<ObjectNode>()).ToArray();
        base.Update();
        if (args.Count >= 2 && argnodes.All(node =>
                node != null && node.hasValue()))  
        
        {
            run();
            return getValue();
        }
        else
        {
            foreach(var n in argnodes)
            {
                n.execute();
            }
            return null;
        }
	}


    public override bool hasValue()
    {
        return executed;
    }

    public override object getValue()
    {
        return resultInt ?? resultFloat;
    }

    void Update()
    {
        base.Update();
    }

    void run()
    {
        var vals = args.Select(obj => obj.GetComponent<ObjectNode>().getValue()).ToArray();
        float result = 0;
        bool isFloat = false;
        foreach(var v in vals)
        {
            if (v.GetType() == typeof(int))
            {
                result += (int)v;
            }
            else if (v.GetType() == typeof(float))
            {
                result += (float)v;
                isFloat = true;
            }
            else return;
        }
        if (isFloat)
        {
            resultFloat = result;
        }
        else
        {
            resultInt = (int)result;
        }
        executed = true;
    }

    protected override string information()
    {
        if (hasValue())
        {
            return getValue().ToString();
        }
        else
        {
            return fname;
        }
    }
}
