using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AudubonValue
{
    public object value { get; protected set; }
    public AudubonValue()
    {

    }
    public AudubonValue(object v)
    {
        value = v;
    }
}

public class AInt : AudubonValue
{
    public int value { get; protected set; }
    public AInt (int v)
    {
        value = v;
    }
}

public class AFloat : AudubonValue
{
    public float value { get; protected set; }
    public AFloat (float v)
    {
        value = v;
    }
}

public class ABool : AudubonValue
{
    public bool value { get; protected set; }
    public ABool (bool b)
    {
        value = b;
    }
}