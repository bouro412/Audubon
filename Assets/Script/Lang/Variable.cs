using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable : IAst
{
    public string VarName;

    public string information()
    {
        return VarName;
    }

    public AudubonValue eval(AudubonEnv env)
    {
        return env.apply(VarName);
    }

    public void updateArgs(IAst[] args)
    {
        throw new NotImplementedException();
    }

    public Variable(string name)
    {
        VarName = name;
    }

}
