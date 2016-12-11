using UnityEngine;
using System.Collections;

public class IfNode : ObjectNode
{
    [SerializeField]
    ObjectNode Test;
    [SerializeField]
    ObjectNode Then;
    [SerializeField]
    ObjectNode Else;

    object _notTested = new object();
    object _testValue;

    object value;
    bool executed = false;

    void Start()
    {
        _testValue = _notTested;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        execute();
        Debug.Log("test : " + _testValue);
    }

    public override object execute()
    {
        if (hasValue())
        {
            return getValue();
        }
        if (_testValue == _notTested)
        {
            Test.execute();
            if (Test.hasValue())
            {
                _testValue = Test.getValue();
            }
        }
        if (_testValue.GetType() == typeof(bool) && (bool)_testValue == true)
        {
            Then.execute();
            if (Then.hasValue())
            {
                value = Then.getValue();
                executed = true;
            }
        }
        else if (_testValue.GetType() == typeof(bool) && (bool)_testValue == false)
        {
            Else.execute();
            if (Else.hasValue())
            {
                value = Else.getValue();
                executed = true;
            }
        }
        else
        {
            Debug.LogError("ifの条件式にはBoolを入れてください");
        }
        return getValue();
    }

    public override bool hasValue()
    {
        return executed;
    }
    protected override string information()
    {
        if (hasValue())
        {
            return value.ToString();
        }
        else
        {
            return "if";
        }
    }
}
