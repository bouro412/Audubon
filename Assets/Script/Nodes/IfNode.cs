using UnityEngine;
using System.Collections;

public class IfNode : ASTNode
{
    public ASTNode Cond;
    public ASTNode Then;
    public ASTNode Else;


    AudubonValue _testValue = null;


    // Update is called once per frame
    new void Update()
    {
        base.Update();
        eval();
        Debug.Log("test : " + _testValue.Value);
    }

    public override AudubonValue eval()
    {
        if (hasValue())
        {
            return GetLangValue();
        }
        if (_testValue == null)
        {
            Cond.eval();
            if (Cond.hasValue())
            {
                _testValue = Cond.GetLangValue();
            }
        }
        var test = _testValue.getBool();
        if (test == true)
        {
            Then.eval();
            if (Then.hasValue())
            {
                SetLangValue(Then.GetLangValue());
            }
        }
        else if (test == false)
        {
            Else.eval();
            if (Else.hasValue())
            {
                SetLangValue(Else.GetLangValue());
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
            return GetLangValue().Value.ToString();
        }
        else
        {
            return "if";
        }
    }
}
