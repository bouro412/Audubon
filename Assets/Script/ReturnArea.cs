using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Node;

namespace Audubon
{
    /// <summary>
    /// 返り値を入れるエリア
    /// </summary>
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class ReturnArea : MonoBehaviour
    {
        /// <summary>
        /// 返り値を表すノード
        /// </summary>
        public IAstNode Node { get; private set; }

        #region Trigger
        private void OnTriggerEnter(Collider collider)
        {
            Node = collider.GetComponent<IAstNode>();
        }
        #endregion
    }
}