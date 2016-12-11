using UnityEngine;
using System.Collections;

public class ObjectNode<T> : Node<T> {
    T value;
    protected override string information()
    {
        return value.ToString();
    }

    public override bool hasValue()
    {
        return true;
    }

    public override T getValue()
    {
        return value;
    }
}
