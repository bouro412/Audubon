using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Audubon.Node;

namespace Audubon
{
    /// <summary>
    /// プログラムの実行を行う黒板
    /// これにオブジェクトを叩きつけると、現在の値が評価され、それが表示される
    /// </summary>
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    internal class Blackboard : MonoBehaviour
    {
        /// <summary>
        /// 黒板に書かれるテキスト
        /// </summary>
        private TextMesh _text { get; set; }

        private void Start()
        {
            _text = GetComponentInChildren<TextMesh>();
        }

        /// <summary>
        /// 接触したオブジェクトを評価、表示する
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<IAstNode>() != null)
            {
                var node = other.GetComponent<IAstNode>();
                try
                {
                    // Envの提供手段が整ってないため、とりあえずnewして渡す
                    _text.text = node.GetAst().eval(new Audubon.Lang.Env()).information();
                }
                catch (Exception e)
                {
                    _text.text = e.Message;
                    throw e;
                }
            }
        }
    }
}
