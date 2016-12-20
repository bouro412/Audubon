using UnityEngine;
using System.Collections;

public class ConstNode : ASTNode {

    protected override string information()
    {
        return GetLangValue().Value.ToString();
    }

    public override bool hasValue()
    {
        return true;
    }
}
