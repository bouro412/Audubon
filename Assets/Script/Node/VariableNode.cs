using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Audubon.Interface;
using Audubon.Lang;

namespace Audubon.Node
{
    internal class VariableNode : Node, ICatchable, IAstNode
    {
        private string _varName { get; set; }
        private bool _isInit = false;

        public void Initialize(string varname)
        {
            if (_isInit) return;
            _varName = varname;
            _isInit = true;
        }

        protected override string Information()
        {
            if (_isInit)
            {
                return _varName;
            }
            else
            {
                return "Not Initialized";
            }
        }

        IAst IAstNode.GetAst()
        {
            return new Variable(_varName);
        }
    }
}
