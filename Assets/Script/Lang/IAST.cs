using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Audubon {
    public interface IAst {
        string information();
        Value eval(Env env);
        void UpdateArgs(IEnumerable<IAst> ast);
    }
}