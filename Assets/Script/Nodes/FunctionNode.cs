using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class FunctionNode : ASTNode {
    [SerializeField]
    protected List<ASTNode> args;
    protected string name;

    protected int _argNum = 0;

    protected void evalNode(int i) {
        if (i < 0 || i >= args.Count) {
            Debug.LogError(name + ": " + i + "番目の引数が存在しません");
            return;
        }
        args[i].eval();
    }
    protected void evalAllNode() {
        foreach (var n in args) {
            n.eval();
        }
    }

    protected bool isCorrectArg() {
        return _argNum == args.Count;
    }

    /// <summary>
    /// 主に初期化
    /// </summary>
    void Start()
    {
        name = "Function";
    }

    public override AudubonValue eval()
    {
        if (hasValue())
        {
            return getValue();
        }
        if (!isCorrectArg())
        {
            return null;
        }else if(!args.All(n => n.hasValue()))
        {
            evalAllNode();
            return null;
        }
        else
        {
            var val = run(args.Select(n => n.getValue()).ToArray());
            Value = val;
            return val;
        }
    }
    protected virtual AudubonValue run(AudubonValue[] values)
    {
        return null;
    }
    protected override string information()
    {
        if (hasValue())
        {
            return Value.Value.ToString();
        }
        else
        {
            return name;
        }
    }

}
