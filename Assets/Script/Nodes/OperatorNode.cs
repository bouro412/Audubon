using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class OperatorNode : Node
{
    [SerializeField]
    protected List<Node> args;
    protected string OperatorName = "Operator";

    protected int _argNum = 0;

    protected override string information()
    {
        return OperatorName;
    }

    protected void evalNode(int i)
    {
        if(i < 0 || i >= args.Count)
        {
            Debug.LogError(OperatorName + ": " + i + "番目の引数が存在しません");
            return;
        }
        args[i].execute();
    }
    protected void evalAllNode()
    {
        foreach(var n in args)
        {
            n.execute();
        }
    }

    protected bool isCorrectArg()
    {
        return _argNum == args.Count;
    }
}