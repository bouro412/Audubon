using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Lang;

namespace Audubon.Node
{
    /// <summary>
    /// �֐�Node�Ɉ�����n���p�C�v��MonoBehavior
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class ArgPipe : MonoBehaviour
    {
        /// <summary>
        /// �󂯎����������AST
        /// </summary>
        private IAst _ast { get; set; }
        // �ϐ����Ƃ�pipe��p�ӂ��Ȃ����Ƃɂ����̂ŕs�v
        //public string ArgID { get; set; }

        /// <summary>
        /// �����̐F
        /// </summary>
        private Color _defaultColor { get; set; }

        /// <summary>
        /// �������擾���Ă��邩�ǂ���
        /// </summary>
        /// <returns></returns>
        public bool HasArg()
        {
            return _ast != null;
        }

        /// <summary>
        /// �������擾���Ă����ꍇ�A�����Ԃ�
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
