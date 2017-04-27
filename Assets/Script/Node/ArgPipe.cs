using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Lang;

namespace Audubon.Node
{
    /// <summary>
    /// 関数Nodeに引数を渡すパイプのMonoBehavior
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class ArgPipe : MonoBehaviour
    {
        /// <summary>
        /// 受け取った引数のAST
        /// </summary>
        private IAst _ast { get; set; }
        // 変数ごとにpipeを用意しないことにしたので不要
        //public string ArgID { get; set; }

        /// <summary>
        /// 初期の色
        /// </summary>
        private Color _defaultColor { get; set; }

        /// <summary>
        /// 引数を取得しているかどうか
        /// </summary>
        /// <returns></returns>
        public bool HasArg()
        {
            return _ast != null;
        }

        /// <summary>
        /// 引数を取得していた場合、それを返す
        /// </summary>
        /// <returns></returns>
        public IAst GetArg()
        {
            var tmp = _ast;
            _ast = null;
            return tmp;
        }

        private void Start()
        {
            _defaultColor = gameObject.GetComponentInChildren<MeshRenderer>().material.color;
        }

        #region Trigger
        private void OnTriggerStay(Collider collider)
        {
            if (_ast == null
                && collider.gameObject.GetComponent<IAstNode>() != null
                && collider.gameObject.GetComponent<Joint>() == null

                )
            {
                var node = collider.gameObject.GetComponent<IAstNode>();
                _ast = node.GetAst();
                // gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
                Destroy(collider.gameObject, 0.0f);
            }
        }
        #endregion
    }
}
