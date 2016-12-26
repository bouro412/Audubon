using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable : AST
{
    public string VarName;

    public override string information()
    {
        return VarName;
    }

    public virtual AudubonValue eval(AudubonEnv env)
    {
        return env.apply(VarName);
    }
    public Variable(string name)
    {
        VarName = name;
    }

}
