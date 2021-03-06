﻿using UnityEngine;
using System.Collections;

public class If : AST
{
    public AST Cond;
    public AST Then;
    public AST Else;

    public override void updateArgs(AST[] args)
    {
        try
        {
            Cond = args[0];
            Then = args[1];
            Else = args[2];
        }
        catch (System.IndexOutOfRangeException)
        {
            return;
        }
    }

    public override AudubonValue eval(AudubonEnv env)
    {
        if(Cond == null || Then == null)
        {
            Debug.LogError("引数が足りません");
            return null;
        }
        var test = Cond.eval(env);
        if (test == null)
        {
            Debug.LogError("Cond式の評価に失敗");
            return null;
        }
        if (!test.getBool().HasValue)
        {
            Debug.LogError("ifの条件文にbool以外が入っています");
            return null;
        }
        if (test.getBool().Value == true)
        {
            return Then.eval(env);
        }else if (Else != null)
        {
            return Else.eval(env);
        }
        return new AudubonNil();

    }

    public override string information()
    {
        return "if";
    }
}
