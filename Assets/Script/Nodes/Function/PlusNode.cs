using UnityEngine;
using System.Collections;
using System.Linq;

public class PlusNode : FunctionNode {

    void Start()
    {
        name = "+";
        _argNum = 2;
    }
    protected override AudubonValue run(AudubonValue[] values)
    {
        AudubonValue a = values[0];
        AudubonValue b = values[1];
        if(a.Type == AudubonValue.AudubonType.Int)
        {
            if(b.Type == AudubonValue.AudubonType.Int)
            {
                return new AudubonInt((int)a.Value + (int)b.Value);
            }else if(b.Type == AudubonValue.AudubonType.Float)
            {
                return new AudubonFloat((int) a.Value + (float)b.Value);
            }
        }
        else if(a.Type == AudubonValue.AudubonType.Float)
        {
            if(isNumber(b))
            {
                return new AudubonFloat((float)a.Value + (float)b.Value);
            }
        }
        Debug.LogError("TypeError");
        return null;
    }
    bool isNumber(AudubonValue v)
    {
        return v.Type == AudubonValue.AudubonType.Float || 
               v.Type == AudubonValue.AudubonType.Int;
    }
    int? getInt(AudubonValue v)
    {
        if(v.Type == AudubonValue.AudubonType.Int)
        {
            return (int)v.Value;
        }
        else
        {
            return null;
        }
    }
    float? getFloat(AudubonValue v)
    {
        if (v.Type == AudubonValue.AudubonType.Float)
        {
            return (float)v.Value;
        }
        else
        {
            return null;
        }
    }

}
