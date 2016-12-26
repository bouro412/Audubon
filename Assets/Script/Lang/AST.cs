using UnityEngine;
using System.Collections;

public class AST
{
    public virtual string information()
    {
        return "AST";
    }
    public virtual AudubonValue eval(AudubonEnv env)
    {
        return null;
    }

    public virtual void updateArgs(AST[] args)
    {
        Debug.LogError("このASTには引数を渡せません");
    }
}