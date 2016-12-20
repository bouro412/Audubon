using UnityEngine;
using System.Collections;

public class ConstNode : ASTNode {

    protected override string information()
    {
        return GetLangValue().ToString();
    }

    public override bool hasValue()
    {
        return true;
    }
}
