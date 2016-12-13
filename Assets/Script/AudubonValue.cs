using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudubonValue{
    public enum AudubonType
    {
        Int,
        Float,
        Bool
    }
    public AudubonType Type { get; protected set; }
    public object Value { get; protected set; }
    public AudubonValue(AudubonType type, object value)
    {
        Type = type;
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
}

public class AudubonInt: AudubonValue
{
    public AudubonInt(int v)
    {
        Value = v;
        Type = AudubonType.Int;
    }
    public override int? getInt() {
        return (int)Value;
    }
}

public class AudubonFloat : AudubonValue
{
    public AudubonFloat(float v)
    {
        Value = v;
        Type = AudubonType.Float;
    }
    public override float? getFloat() {
        return (float)Value;
    }
}

public class AudubonBool : AudubonValue
{
    public AudubonBool(bool v)
    {
        Value = v;
        Type = AudubonType.Bool;
    }
    public override bool? getBool() {
        return (bool)Value;
    }

}