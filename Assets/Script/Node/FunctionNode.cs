using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Interface;
using Audubon.Lang;
using Audubon.Lang.Function;
using System;

namespace Audubon.Node
{
    /// <summary>
    /// function‚ğ‚Âƒm[ƒh
    /// ˆø”‚Ìˆø‚«“n‚µ‚ª‚Å‚«‚é
    /// </summary>
    public class FunctionNode : MonoBehaviour, ICatchable
    {
        public ArgPipe Pipe;
        private IFunction Function;
        private int _argNum;
        private int current_arg = 0;

        private void Start()
        {
            if (Function == null)
            {
                Function = new Plus();
            }
            _argNum = Function.GetArgNum();
        }

        /// <summary>
        /// pipe‚©‚çˆø”‚ğó‚¯æ‚é
        /// </summary>
        private void Update()
        {
            if (Pipe.HasArg())
            {

                var arg = Pipe.GetArg();
                Function.AddArg(arg, Function.GetIDs()[current_arg++]);
                // ˆø”‚ª\•ª‚É“n‚Á‚½‚çpipe‚ğÁ‚·
                if(current_arg == _argNum)
                {
                    DestroyImmediate(Pipe.gameObject);     
                }
            }
        }
    }
}
