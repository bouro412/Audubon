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
        public IAstNode Node { get
            { if (_returnObject == null)
                {
                    return null;
                }
                else
                {
                    return _returnObject.GetComponent<IAstNode>();
                }
                }
        }
        private MeshRenderer _renderer { get; set; }

        private GameObject _returnObject { get; set; }

        private void Start()
        {
            _renderer = this.GetComponent<MeshRenderer>();
        }
        private void Update()
        {
            if (_returnObject != null)
            {
                _renderer.material.color = Color.blue;
            }
            else
            {
                _renderer.material.color = Color.red;
            }
        }

        #region Trigger
        private void OnTriggerEnter(Collider collider)
        {
            var node = collider.GetComponent<IAstNode>();
            if (node != null)
            {
                _returnObject = collider.gameObject;
            }
            if (collider.CompareTag("Head"))
            {
                FieldManager.Instance.Close(GetComponentInParent<Room>());
            }
        }
        #endregion
    }
}