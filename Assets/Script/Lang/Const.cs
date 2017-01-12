using UnityEngine;
using System.Collections;
using System;

public class Const : IAst
{
    AudubonValue audubonValue { get; set; }

    public string information()
    {
        return audubonValue.information();
    }

    public AudubonValue eval(AudubonEnv env)
    {
        return audubonValue;
    }

    public void updateArgs(IAst[] args)
    {
        throw new NotImplementedException();
    }

    public Const()
    {

    }
    public Const(bool value)
    {
        audubonValue = new AudubonBool(value);
    }
    public Const(int value)
    {
        audubonValue = new AudubonInt(value);
    }
    public Const(float value)
    {
        audubonValue = new AudubonFloat(value);
    }
}
