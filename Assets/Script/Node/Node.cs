using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Audubon.Node
{

    /// <summary>
    /// Node共通の処理
    /// </summary>
    public class Node : MonoBehaviour
    {
        /// <summary>
        /// Node情報を載せるテキスト
        /// </summary>
        protected TextMesh _info { get; set; }

        /// <summary>
        /// 毎フレームノードの情報を更新、表示する
        /// </summary>
        protected void Update()
        {
            if (_info == null)
            {
                _info = this.GetComponentInChildren<TextMesh>();
            }
            else
            {
                _info.text = Information();
            }
        }

        /// <summary>
        /// Nodeの情報
        /// </summary>
        /// <returns></returns>
        protected virtual string Information()
        {
            return "Node";
        }
    }
}
