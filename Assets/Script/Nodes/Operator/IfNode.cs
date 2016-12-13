using UnityEngine;
using System.Collections;

public class IfNode : OperatorNode
{
    AudubonValue _testValue = null;

    void Start()
    {
        _argNum = 3;
        OperatorName = "if";
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        execute();
        Debug.Log("test : " + _testValue);
    }

    public override AudubonValue execute()
    {
        if (hasValue())
        {
            return getValue();
        }
        if (!isCorrectArg())
        {
            return null;
        }
        var Test = args[0];
        var Then = args[1];
        var Else = args[2];
        if (_testValue == null)
        {
            Test.execute();
            if (Test.hasValue())
            {
                _testValue = Test.Value;
            }
        }
        if (_testValue.Type == AudubonValue.AudubonType.Bool && 
            (bool)_testValue.Value == true)
        {
            Then.execute();
            if (Then.hasValue())
            {
                Value = Then.getValue();
            }
        }
        else if (_testValue.Type == AudubonValue.AudubonType.Bool &&
                (bool)_testValue.Value == false)
        {
            Else.execute();
            if (Else.hasValue())
            {
                Value = Else.getValue();
            }
        }
        else
        {
            Debug.LogError("ifの条件式にはBoolを入れてください");
        }
        return null;
    }

    protected override string information()
    {
        if (hasValue())
        {
            return Value.Value.ToString();
        }
        else
        {
            return OperatorName;
        }
    }
}
