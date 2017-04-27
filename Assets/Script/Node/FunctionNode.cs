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
    public class FunctionNode : MonoBehaviour, ICatchable
    {
        public ArgPipe Pipe;
        private IFunction Function;
        private int _argNum;
        private int current_arg = 0;

        private void Start()
        {
            if (Function == null)
            {
                Function = new Plus();
            }
            _argNum = Function.GetArgNum();
        }

        /// <summary>
        /// pipeから引数を受け取る
        /// </summary>
        private void Update()
        {
            if (Pipe.HasArg())
            {

                var arg = Pipe.GetArg();
                Function.AddArg(arg, Function.GetIDs()[current_arg++]);
                // 引数が十分に渡ったらpipeを消す
                if(current_arg == _argNum)
                {
                    DestroyImmediate(Pipe.gameObject);     
                }
            }
        }
    }
}
