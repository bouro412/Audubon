using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudubonEnv {
    Dictionary<string, AudubonValue> table;
    public AudubonEnv()
    {
        table = new Dictionary<string, AudubonValue>();
    }

    AudubonEnv(Dictionary<string, AudubonValue> oldTable)
    {
        table = new Dictionary<string, AudubonValue>(oldTable);
    }

    public AudubonValue apply(string varname)
    {
        AudubonValue val;
        table.TryGetValue(varname, out val);
        return val;
    }

    void _extend(string varname, AudubonValue value)
    {
        table[varname] = value;
    }

    public AudubonEnv extend(string varname, AudubonValue value)
    {
        var newtable = new AudubonEnv(table);
        newtable._extend(varname, value);
        return newtable;
    }
}
