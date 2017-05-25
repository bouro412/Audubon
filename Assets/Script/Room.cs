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
        /// このRoomの返り値となるAstNode
        /// </summary>
        public IAstNode ReturnNode { get; private set; }

        /// <summary>
        /// 返り値を入れるエリア
        /// </summary>
        private ReturnArea _returnArea { get; set; }

        /// <summary>
        /// roomidに合わせて変数の生成
        /// </summary>
        /// <param name="roomid"></param>
        /// <param name="argNum"></param>
        public void Initialize(string[] argNames)
        {
            var argarea = transform.FindChild("ArgArea");
            var prefab = PrefabManager.Instance.GetPrefab("VariableSourceNode");
            var space = 0.3f;
            var len = space * (argNames.Length - 1);
            for (int i = 0;i < argNames.Length; i++)
            {
                var instance = Instantiate(prefab, argarea.transform, false);
                instance.GetComponent<VariableSourceNode>().VarName = argNames[i];
                instance.transform.position += new Vector3(- len / 2 + i * space, 0, 0);
            }
            _returnArea = GetComponentInChildren<ReturnArea>();
        }

        /// <summary>
        /// 部屋終了時に必要な処理
        /// </summary>
        /// <returns></returns>
        public void OnClose()
        {
            ReturnNode = _returnArea.Node;
        }

    }
}
