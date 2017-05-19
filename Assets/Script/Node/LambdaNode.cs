using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Interface;
using System;
using Audubon.Lang;
using Audubon;

namespace Audubon.Node
{
    public class LambdaNode : Node, IAstNode, ICatchable, IHasEventOnCatched
    {
        /// <summary>
        /// 関数本体を表すAST
        /// </summary>
        public IAst BodyAst { get; set; }

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
        public List<string> ArgNames { get; private set; }

        /// <summary>
        /// 引数を受け取るPipe
        /// </summary>
        private ArgPipe _pipe { get; set; }

        /// <summary>
        /// プレイヤーの頭に触れているどうか
        /// </summary>
        private bool _isTouchHead = false;

        /// <summary>
        /// 引数の個数の変更、それに合わせて引数の名前リストの生成
        /// </summary>
        /// <param name="controller"></param>
        void IHasEventOnCatched.ClickEvent(SteamVR_Controller.Device controller)
        {
            // 引数の増減
            if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                if(controller.GetAxis().x < -0.3)
                {
                    ArgNum = Mathf.Max(ArgNum - 1, 0);
                }else if(controller.GetAxis().x > 0.3)
                {
                    ArgNum += 1;
                }
            }
            // 新しい引数に合わせて調整
            if(ArgNames.Count < ArgNum) 
            {
                for(var i = 0; i < ArgNum - ArgNames.Count; i++)
                {
                    ArgNames.Add(VariableMaker.NewVariable());
                }
            }else if(ArgNames.Count > ArgNum)
            {
                for (var i = 0; i < ArgNames.Count - ArgNum; i++)
                {
                    ArgNames.RemoveAt(ArgNames.Count - 1);
                }
            }
            // 顔に近づけたら編集
            if (_isTouchHead)
            {
                _isTouchHead = false;
                FieldManager.Instance.Open(this);
            }

        }

        IAst IAstNode.GetAst()
        {
            if(_lambdaAst == null)
            {
                _lambdaAst = new Lambda(ArgNames.ToArray(), BodyAst);
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
            ArgNames = new List<string>();
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
        #region Trigger
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Head"))
            {
                _isTouchHead = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Head"))
            {
                _isTouchHead = false;
            }
        }
        #endregion  

    }

}