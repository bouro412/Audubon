using UnityEngine;
using System.Collections;

public class ObjectNode : Node {

    protected override string information()
    {
        return Value.ToString();
    }

    public override bool hasValue()
    {
        return true;
    }
    public ObjectNode(AudubonValue v)
    {
        Value = v;
    }
}
