using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Audubon.Lang {
    /*
    public abstract class Function : IAst {
        [SerializeField]
        protected IAst[] args;
        protected string FunctionName;

        protected int _argNum = 0; 


        protected bool isCorrectArg() {
            return _argNum == args.Length;
        }

        public virtual int getArgNum() {
            return _argNum;
        }

        public AudubonValue eval(Env env) {
            if (!isCorrectArg()) {
                Debug.LogError("引数の数が正しくありません");
                return null;
            }
            var vals = args.Select(exp => exp.eval(env)).ToArray();
            return run(vals);
        }

        public void UpdateArgs(IEnumerable<IAst> args) {
            this.args = args.ToArray();
        }

        protected virtual AudubonValue run(AudubonValue[] values) {
            Debug.LogError("メソッドの中身が定義されていません");
            return null;
        }
        public string information() {
            return FunctionName;
        }

    }
    */
    // 試しにinterfaceにしてみる
    /// <summary>
    /// Functionを表すinterface
    /// </summary>
    public interface IFunction: IAst{
        int GetArgNum();
        void AddArg(IAst ast, string argID);
		string[] GetIDs ();
    }
}
