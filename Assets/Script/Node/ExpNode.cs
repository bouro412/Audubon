using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Audubon.Interface;
using Audubon.Lang;

namespace Audubon.Node
{
    internal class ExpNode : Node, ICatchable, IAstNode 
    {
        private IFunction _function;

        IAst IAstNode.GetAst()
        {
            return _function;
        }


    }
}
