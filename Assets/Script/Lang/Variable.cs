using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audubon.Lang {
    /// <summary>
    /// �ϐ��f�[�^��\��
    /// </summary>
    public class Variable : IAst {
        public string VarName;

        string IAst.information() {
            return VarName;
        }

        Value IAst.eval(Env env) {
            return env.apply(VarName);
        }

        public Variable(string name) {
            VarName = name;
        }

    }
}
