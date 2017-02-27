﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Audubon {
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

        public Value eval(Env env) {
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

        protected virtual Value run(Value[] values) {
            Debug.LogError("メソッドの中身が定義されていません");
            return null;
        }
        public string information() {
            return FunctionName;
        }

    }
    */
    // 試しにinterfaceにしてみる
    public interface IFunction: IAst{
         int getArgNum();
         IEnumerable<IAst> getArgs();

    }
}