using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Interface;
using Audubon.Lang;
using Audubon.Lang.Function;
using System;

namespace Audubon.Node
{
    /// <summary>
    /// functionを持つノード
    /// 引数の引き渡しができる
    /// </summary>
    public class FunctionNode : Node, ICatchable, IAstNode
    {
        public ArgPipe Pipe;
        private IFunction Function;
        private int _argNum;
        private int current_arg = 0;
        
        /// <summary>
        /// 情報開示のために引数を保持する
        /// 将来的にはデザインで解決したい
        /// </summary>
        private List<IAst> argCache;

        private void Start()
        {
            if (Function == null)
            {
                Function = new Plus();
            }
            _argNum = Function.GetArgNum();
            argCache = new List<IAst>();
        }

        /// <summary>
        /// pipeから引数を受け取る
        /// </summary>
        private void Update()
        {
            base.Update();
            if (Pipe.HasArg())
            {

                var arg = Pipe.GetArg();
                Function.AddArg(arg, Function.GetIDs()[current_arg++]);
                argCache.Add(arg);
                // 引数が十分に渡ったらpipeを消す
                if(current_arg == _argNum)
                {
                    DestroyImmediate(Pipe.gameObject);     
                }
            }
        }

        /// <summary>
        /// 文字情報に引数の様子も入れる
        /// 将来的にはデザインで見せたい
        /// </summary>
        /// <returns></returns>
        protected override string Information()
        {
            var ret = "(" + Function.information() + " ";
            for(int i = 0;i < _argNum; i++)
            {
                if(i < current_arg)
                {
                    ret += argCache[i].information() + " ";
                }
                else
                {
                    ret += "null ";
                }
            }
            if(_argNum > 0)
                ret = ret.Substring(0, ret.Length - 1);
            ret += ")";
            return ret;
        }

        IAst IAstNode.GetAst()
        {
            return Function;
        }
    }
}
