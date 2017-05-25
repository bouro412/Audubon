using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Interface;
using System;
using Audubon.Lang;
using Audubon;
using System.Linq;

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
        /// 引数の名前リスト
        /// </summary>
        public string[] ArgNames { get {
                return _argTableList.Select(pair => pair.Key).ToArray();
            } }

        /// <summary>
        /// 引数テーブル, 順序が必要なためリストにしてある
        /// </summary>
        private List<KeyValuePair<string, IAst>> _argTableList { get; set; }

        /// <summary>
        /// 次に値を入れるべき引数インデックス
        /// </summary>
        private int _currentArgIndex = 0;

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
            if(_argTableList.Count < ArgNum) 
            {
                for(var i = 0; i < ArgNum - _argTableList.Count; i++)
                {
                    ExtendTable();
                }
            }else if(_argTableList.Count > ArgNum)
            {
                for (var i = 0; i < _argTableList.Count - ArgNum; i++)
                {
                    DeleteArg();
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
                _lambdaAst = new Lambda(GetArgTable(), BodyAst);
            }
            else
            {
                _lambdaAst.UpdateTable(GetArgTable());
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
            _argTableList = new List<KeyValuePair<string, IAst>>();
        }

        // Update is called once per frame
        new void Update()
        {
            // 引数が足りていないときにはパイプを表示
            _pipe.gameObject.SetActive(!IsTableFull());
            base.Update();
            if (_pipe.HasArg())
            {

                var arg = _pipe.GetArg();
                PushValueToTable(arg);
            }
        }

        private Dictionary<string, IAst> GetArgTable()
        {
            var table = new Dictionary<string, IAst>();
            foreach (var pair in _argTableList)
            {
                table.Add(pair.Key, pair.Value);
            }
            return table;
        }

        private void ExtendTable()
        {
            _argTableList.Add(new KeyValuePair<string, IAst>(VariableMaker.NewVariable(), null));
        }

        private void PushValueToTable(IAst value)
        {
            var key = _argTableList[_currentArgIndex].Key;
            _argTableList[_currentArgIndex++] = new KeyValuePair<string, IAst>(key, value);
        }
        private void ClearTopValueFromTable()
        {
            var key = _argTableList[_currentArgIndex].Key;
            _argTableList[_currentArgIndex--] = new KeyValuePair<string, IAst>(key, null);
        }
        private void DeleteArg()
        {
            if(_currentArgIndex == _argTableList.Count)
            {
                _currentArgIndex--;
            }
            _argTableList.RemoveAt(_argTableList.Count - 1);
        }
        private bool IsTableFull()
        {
            return _currentArgIndex == _argTableList.Count;
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