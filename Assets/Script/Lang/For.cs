using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class For : IAst {
    IAst start;
    IAst end;
    IAst varName;
    Variable variableNode;

    public Variable variableNodePrehab;

    public string information()
    {
        throw new NotImplementedException();
    }

    public AudubonValue eval(AudubonEnv env)
    {
        throw new NotImplementedException();
    }

    public void UpdateArgs(IEnumerable<IAst> args)
    {
        throw new NotImplementedException();
    }
}
