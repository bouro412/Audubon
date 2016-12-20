﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableNode : ASTNode {
    public string VarName;
    public VariableSourceNode Source;

    protected override string information() {
        return VarName + " : " + GetLangValue().Value;
    }

    public override AudubonValue GetLangValue()
    {
        return Source.Value;
    }
    public override bool hasValue()
    {
        return true;
    }
    void Update()
    {
        base.Update();
        this.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

}
