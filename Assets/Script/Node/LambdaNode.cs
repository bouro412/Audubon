using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Interface;
using System;
using Audubon.Lang;
using Audubon;

namespace Audubon.Node
{
    public class LambdaNode : Node, IAstNode, ICatchable, IHasClickEvent
    {
        /// <summary>
        /// 関数本体を表すAST
        /// </summary>
        private IAst _bodyAst { get; set; }

        /// <summary>
        /// このNodeが表すLambdaのAST
        /// </summary>
        private Lambda _lambdaAst { get; set; }

        /// <summary>
        /// 引数の数
        /// </summary>
        public int ArgNum { get; private set; }

        /// <summary>
        /// 引数リスト
        /// </summary>
        private List<IAst> _argList { get; set; }

        /// <summary>
        /// 引数の名前リスト
        /// </summary>
        private List<string> _argNames { get; set; }

        /// <summary>
        /// 引数を受け取るPipe
        /// </summary>
        private ArgPipe _pipe { get; set; }

        /// <summary>
        /// 引数の個数の変更、それに合わせて引数の名前リストの生成
        /// </summary>
        /// <param name="controller"></param>
        void IHasClickEvent.ClickEvent(SteamVR_Controller.Device controller)
        {
            if (controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                if(controller.GetAxis().x < -0.3)
                {
                    ArgNum = Mathf.Min(ArgNum - 1, 0);
                }else if(controller.GetAxis().x > 0.3)
                {
                    ArgNum += 1;
                }
            }
            if(_argNames.Count < ArgNum)
            {
                for(var i = 0; i < ArgNum - _argNames.Count; i++)
                {
                    _argNames.Add(VariableMaker.NewVariable());
                }
            }else if(_argNames.Count > ArgNum)
            {
                for (var i = 0; i < _argNames.Count - ArgNum; i++)
                {
                    _argNames.RemoveAt(_argNames.Count - 1);
                }
            }
        }

        IAst IAstNode.GetAst()
        {
            if(_lambdaAst == null)
            {
                _lambdaAst = new Lambda(_argNames.ToArray(), _bodyAst);
            }

            return _lambdaAst;
        }

        protected override string Information()
        {
            return "Lambda: " + ArgNum;
        }

        // Use this for initialization
        void Start()
        {
            _pipe = GetComponentInChildren<ArgPipe>();
        }

        // Update is called once per frame
        void Update()
        {
            base.Update();
            if (_pipe.HasArg())
            {

                var arg = _pipe.GetArg();
                _argList.Add(arg);
                // 引数が十分に渡ったらpipeを消す
                // TODO: 渡し切ったあとに引数の数を変更した場合
                if (_argList.Count == ArgNum)
                {
                    DestroyImmediate(_pipe.gameObject);
                }
            }
        }
    }

}