using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AValue
{
    public object value { get; protected set; }
    public AValue()
    {

    }
    public AValue(object v)
    {
        value = v;
    }
}

public class AInt : AValue
{
    public int value { get; protected set; }
    public AInt (int v)
    {
        value = v;
    }
}

public class AFloat : AValue
{
    public float value { get; protected set; }
    public AFloat (float v)
    {
        value = v;
    }
}

public class ABool : AValue
{
    public bool value { get; protected set; }
    public ABool (bool b)
    {
        value = b;
    }
}