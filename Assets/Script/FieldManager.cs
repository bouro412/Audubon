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

        /// <summary>
        /// Playerカメラの位置
        /// </summary>
        [SerializeField]
        private GameObject Player;

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
                _currentRoom = room.gameObject;
            }
            else
            {
                // 初めての場合は作成、初期化、キャッシュ
                var roomObject = Instantiate(PrefabManager.Instance.GetPrefab("Room"),
                                        transform, false);
                roomObject.GetComponent<Room>().Initialize(originalNode.ArgNames);
                NodeRoomDict[originalNode] = roomObject.GetComponent<Room>();
                _currentRoom = roomObject;
            }
        }

        /// <summary>
        /// Roomを閉じる処理
        /// </summary>
        /// <param name="room"></param>
        public void Close() 
        {
            // 現在のRoomを無効化
            var room = _currentRoom.GetComponent<Room>() ;
            room.OnClose();
            room.gameObject.SetActive(false);
            // 返り値があればセットする
            if (room.ReturnNode != null)
            {
                var node = NodeRoomDict.First(x => x.Value == room).Key;
                node.BodyAst = room.ReturnNode.GetAst();
            }
            // 新しい部屋を有効化
            var newroom = _roomStack.Pop();
            _currentRoom = newroom;
            newroom.SetActive(true);
        }
    }
}