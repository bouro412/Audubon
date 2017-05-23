using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Audubon.Node
{
    internal class NodeMaker
    {
        public static GameObject CreateNode(GameObject nodePrefab, Vector3 position, Quaternion quaternion)
        {
            return UnityEngine.Object.Instantiate(nodePrefab, position, quaternion, FieldManager.Instance.CurrentRoom.transform);
        }
        public static GameObject CreateNode(string nodeName, Vector3 position, Quaternion quaternion)
        {
            return CreateNode(PrefabManager.Instance.GetPrefab(nodeName), position, quaternion);
        }
    }
}