using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class FunctionNode : OperatorNode {

    /// <summary>
    /// 主に初期化
    /// </summary>
    void Start()
    {
        OperatorName = "Function";
    }

    public override AudubonValue execute()
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
            return OperatorName;
        }
    }

}
