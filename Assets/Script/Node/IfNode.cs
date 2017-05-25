using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Audubon.Lang;
using Audubon.Interface;
using UnityEngine;

namespace Audubon.Node
{
    internal class IfNode : MonoBehaviour, IAstNode, ICatchable
    {
        [SerializeField]
        private ArgPipe _testPipe;
        [SerializeField]
        private ArgPipe _thenPipe;
        [SerializeField]
        private ArgPipe _elsePipe;

        private IAst _test { get; set; }
        private IAst _then { get; set; }
        private IAst _else { get; set; }

        private If _ifAst { get; set; }

        private void Update()
        {
            if (_testPipe.HasArg())
            {
                _test = _testPipe.GetArg();
                _testPipe.gameObject.SetActive(false);
            }
            if (_thenPipe.HasArg())
            {
                _then = _thenPipe.GetArg();
                _thenPipe.gameObject.SetActive(false);
            }
            if (_elsePipe.HasArg())
            {
                _else = _elsePipe.GetArg();
                _elsePipe.gameObject.SetActive(false);
            }
        }

        IAst IAstNode.GetAst()
        {
            if(_ifAst == null)
            {
                _ifAst = new If();
            }
            _ifAst.Cond = _test;
            _ifAst.Then = _then;
            _ifAst.Else = _else;
            return _ifAst;
        }
    }
}
