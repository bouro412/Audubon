using UnityEngine;
using System.Collections;

public class ConstNode : ASTNode {

    protected override string information()
    {
        return Value.ToString();
    }

    public override bool hasValue()
    {
        return true;
    }
    public ConstNode(AudubonValue v)
    {
        Value = v;
    }
}
