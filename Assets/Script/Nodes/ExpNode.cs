using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExpNode : MonoBehaviour
{
    public AST expression;
    AudubonValue LangValue { get; set; }
    TextMesh info;
    public AST[] args;
    AST[] argsCache;

    // Use this for initialization
    void Start()
    {
        argsCache = args;
    }

    // Update is called once per frame
    protected void Update()
    {
        displayInformation();
        if (hasValue())
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        if (isEdited())
        {
            expression.updateArgs(args);
        }
    }

    bool isEdited()
    {
        var ret = args.SequenceEqual(argsCache);
        if (!ret)
        {
            argsCache = args;
            return true;
        }
        return false;
    }

    public virtual bool hasValue()
    {
        return LangValue != null;
    }

    public virtual AudubonValue GetLangValue()
    {
        return LangValue;
    }

    protected virtual void SetLangValue(AudubonValue value)
    {
        LangValue = value;
    }

    void run()
    {

    }

    protected virtual string information()
    {
        return expression.information();
    }
    void displayInformation()
    {
        if (info == null)
        {
            info = this.GetComponentInChildren<TextMesh>();
        }
        info.text = this.information();
    }
    public virtual AudubonValue eval(AudubonEnv env)
    {
        return expression.eval(env);
    }
}