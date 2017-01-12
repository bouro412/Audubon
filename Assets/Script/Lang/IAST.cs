using UnityEngine;
using System.Collections;

public interface IAst
{
    string information();
    AudubonValue eval(AudubonEnv env);
    void updateArgs(IAst[] args);
}