using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Audubon.Lang {
    /// <summary>
    /// Functionを表すinterface
    /// </summary>
    public interface IFunction: IAst{
        int GetArgNum();
        void AddArg(IAst ast, string argID);
		string[] GetIDs ();
    }
}
