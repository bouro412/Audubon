using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudubonValue{
    public object Value { get; protected set; }
    public AudubonValue(object value)
    {
        Value = value;
    }
    public AudubonValue()
    {

    }
    public virtual int? getInt() {
        return null;
    }
    public virtual float? getFloat() {
        return null;
    }
    public virtual bool? getBool() {
        return null;
    }
    public virtual void AddDefaultNode(GameObject obj)
    {
    }
    public virtual string information()
    {
        return Value.ToString();
    }
}

public class AudubonInt: AudubonValue
{
    public AudubonInt(int v)
    {
        Value = v;
    }
    public override int? getInt() {
        return (int)Value;
    }
    public override void AddDefaultNode(GameObject obj)
    {
    }
}

public class AudubonFloat : AudubonValue
{
    public AudubonFloat(float v)
    {
        Value = v;
    }
    public override float? getFloat() {
        return (float)Value;
    }
    public override void AddDefaultNode(GameObject obj)
    {
    }
}

public class AudubonBool : AudubonValue
{
    public AudubonBool(bool v)
    {
        Value = v;
    }
    public override bool? getBool() {
        return (bool)Value;
    }
    public override void AddDefaultNode(GameObject obj)
    {
    }

}

public class AudubonNil : AudubonValue
{
    public AudubonNil()
    {

    }
    public override string information()
    {
        return "nil";
    }
}