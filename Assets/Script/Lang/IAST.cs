using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;   

public interface IAst
{
    string information();
    AudubonValue eval(AudubonEnv env);
    void UpdateArgs(IEnumerable<IAst> args);
}