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
    /// function�����m�[�h
    /// �����̈����n�����ł���
    /// </summary>
    public class FunctionNode : Node, ICatchable, IAstNode
    {
        public ArgPipe Pipe;
        private IFunction Function;
        private int _argNum;
        private int current_arg = 0;
        
        /// <summary>
        /// ���J���̂��߂Ɉ�����ێ�����
        /// �����I�ɂ̓f�U�C���ŉ���������
        /// </summary>
        private List<IAst> argCache;

        private void Start()
        {
            if (Function == null)
            {
                Function = new Plus();
            }
            _argNum = Function.GetArgNum();
            argCache = new List<IAst>();
        }

        /// <summary>
        /// pipe����������󂯎��
        /// </summary>
        private void Update()
        {
            base.Update();
            if (Pipe.HasArg())
            {

                var arg = Pipe.GetArg();
                Function.AddArg(arg, Function.GetIDs()[current_arg++]);
                argCache.Add(arg);
                // �������\���ɓn������pipe������
                if(current_arg == _argNum)
                {
                    DestroyImmediate(Pipe.gameObject);     
                }
            }
        }

        /// <summary>
        /// �������Ɉ����̗l�q�������
        /// �����I�ɂ̓f�U�C���Ō�������
        /// </summary>
        /// <returns></returns>
        protected override string Information()
        {
            var ret = "(" + Function.information() + " ";
            for(int i = 0;i < _argNum; i++)
            {
                if(i < current_arg)
                {
                    ret += argCache[i].information() + " ";
                }
                else
                {
                    ret += "null ";
                }
            }
            if(_argNum > 0)
                ret = ret.Substring(0, ret.Length - 1);
            ret += ")";
            return ret;
        }

        IAst IAstNode.GetAst()
        {
            return Function;
        }
    }
}
