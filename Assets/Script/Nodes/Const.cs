using UnityEngine;
using System.Collections;

public class Const : AST
{
    AudubonValue audubonValue { get; set; }

    public override string information()
    {
        return audubonValue.information();
    }

    public override AudubonValue eval(AudubonEnv env)
    {
        return audubonValue;
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
