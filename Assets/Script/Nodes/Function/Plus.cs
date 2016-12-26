using UnityEngine;
using System.Collections;
using System.Linq;

public class Plus : Function {

    void Start()
    {
        FunctionName = "+";
        _argNum = 2;
    }
    protected override AudubonValue run(AudubonValue[] values)
    {
        int? ai = values[0].getInt();
        int? bi = values[1].getInt();
        float? af = values[0].getFloat();
        float? bf = values[1].getFloat();
        if(ai != null && bi != null) {
            return new AudubonInt(ai.Value + bi.Value);
        }else {
            return new AudubonFloat((float)((ai ?? af) + (bi ?? bf)));
        }
    }
}
