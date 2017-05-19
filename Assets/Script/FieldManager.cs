using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audubon.Node;
using System.Linq;

namespace Audubon
{
    /// <summary>
    /// 編集環境スタックの管理をする
    /// </summary>
    internal class FieldManager : MonoBehaviour
    {
        /// <summary>
        /// シングルトン
        /// </summary>
        public static FieldManager Instance { get; private set; }

        /// <summary>
        /// ルームのプレハブ
        /// </summary>
        private GameObject _roomPrefab { get; set; }

        /// <summary>
        /// ルームスタック。上位の無効化したルームを入れる
        /// </summary>
        private Stack<GameObject> _roomStack = new Stack<GameObject>();

        /// <summary>
        /// 現在有効なルーム
        /// </summary>
        private GameObject _currentRoom = null;

        public GameObject CurrentRoom { get { return _currentRoom; } } 
        /// <summary>
        /// Roomとそれに対応するLambdaNodeのマップ表
        /// </summary>
        private Dictionary<LambdaNode, Room> NodeRoomDict = new Dictionary<LambdaNode, Room>();

        private void Awake()
        {
            Instance = this;
            _roomPrefab = PrefabManager.Instance.GetPrefab("Room");
            _currentRoom = GetComponentInChildren<Room>().gameObject;
        }

        /// <summary>
        /// あるLambdaのRoomを開く
        /// </summary>
        /// <param name="originalNode"></param>
        public void Open(LambdaNode originalNode)
        {
            // 現在のRoomを隠蔽
            if (_currentRoom != null)
            {
                _roomStack.Push(_currentRoom);
                _currentRoom.SetActive(false);
            }
            // 過去に作成したことがあればそれを開く
            Room room;
            if (NodeRoomDict.TryGetValue(originalNode, out room))
            {
                room.gameObject.SetActive(true);
            }
            else {
                // 初めての場合は作成、初期化、キャッシュ
                var roomObject = Instantiate(PrefabManager.Instance.GetPrefab("Room"),
                                        transform, false);
                roomObject.GetComponent<Room>().Initialize(originalNode.ArgNames.ToArray());
                NodeRoomDict[originalNode] = roomObject.GetComponent<Room>();
            }
        }

        public void Close(Room room) 
        {
            room.OnClose();
            var node = NodeRoomDict.First(x => x.Value == room).Key;
            node.BodyAst = room.ReturnNode.GetAst();
            room.gameObject.SetActive(false);
            _roomStack.Pop().SetActive(true);
        }
    }
}