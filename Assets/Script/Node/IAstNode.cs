using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Lang;

namespace Audubon.Node
{
    /// <summary>
    /// プログラムの式を構成するNodeのinterface
    /// </summary>
    public interface IAstNode
    {
        /// <summary>
        /// ノードが持つ式を返す
        /// </summary>
        /// <returns></returns>
        IAst GetAst();
    }
}