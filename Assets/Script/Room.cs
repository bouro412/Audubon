using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Audubon.Node;

namespace Audubon
{
    /// <summary>
    /// 今いる環境を表す
    /// VariableSourceを保持する
    /// </summary>
    internal class Room : MonoBehaviour
    {
        /// <summary>
        /// Roomの名前を使って変数名を決める.
        /// </summary>
        private string _roomId { get; set; }

        /// <summary>
        /// 今使われている変数の数
        /// </summary>
        private int _argId { get; set; }

        /// <summary>
        /// このROomの返り値となるAstNode
        /// </summary>
        public IAstNode ReturnNode { get; private set; }

        /// <summary>
        /// 返り値を入れるエリア
        /// </summary>
        private ReturnArea _returnArea { get; set; }

        /// <summary>
        /// この部屋のGameObject
        /// </summary>
        public GameObject RoomObject { get; private set; }

        /// <summary>
        /// roomidに合わせて変数の生成
        /// </summary>
        /// <param name="roomid"></param>
        /// <param name="argNum"></param>
        public void Initialize(string roomid, int argNum)
        {
            if (_roomId != null) return;
            _roomId = roomid;
            var argarea = transform.FindChild("ArgArea");
            for(int i = 0;i < argNum; i++)
            {
                var name = roomid + "_" + i;
                var prefab = PrefabManager.Instance.GetPrefab("VariableSourceNode");
                var instance = Instantiate(prefab, argarea.transform, false);
                instance.GetComponent<VariableSourceNode>().VarName = name;
            }
            _argId = argNum;
            _returnArea = GetComponentInChildren<ReturnArea>();
            RoomObject = this.gameObject;
        }

        /// <summary>
        /// 部屋の終了、無効してこのクラスを返す
        /// </summary>
        /// <returns></returns>
        private Room CloseRoom()
        {
            ReturnNode = _returnArea.Node;
            gameObject.SetActive(false);
            return this;
        }

        /// <summary>
        /// for test
        /// </summary>
        private void Start()
        {
            Initialize("root", 1);
        }
    }
}
