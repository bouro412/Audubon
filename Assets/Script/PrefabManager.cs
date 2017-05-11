using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audubon
{
    /// <summary>
    /// 全てのスクリプトからPrefabを参照できるようにする
    /// シングルトン
    /// </summary>
    public class PrefabManager : MonoBehaviour
    {
        /// <summary>
        /// シングルトン
        /// </summary>
        public static PrefabManager Instance { get; private set; }

        [System.Serializable]
        private class Pair
        {
            public string Name;
            public GameObject Prehab;
        }

        /// <summary>
        /// インスペクタ表示用テーブル
        /// </summary>
        [SerializeField]
        private Pair[] PrefabTable = null;

        /// <summary>
        /// Prefab名とPrefabのテーブル
        /// </summary>
        private Dictionary<string, GameObject> _table { get; set; }

        /// <summary>
        /// nameで指定したPrefabを取得する
        /// もしなかったらエラーメッセージを投げてnullを返す
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GameObject GetPrefab(string name)
        {
            GameObject gameObject;
            var exist = _table.TryGetValue(name, out gameObject);
            if (exist)
            {
                return gameObject;
            }
            else
            {
                Debug.LogError("Prefab " + name + " is not found");
                return null;
            }
        }

        /// <summary>
        /// テーブルの初期化
        /// </summary>
        void Awake()
        {
            Instance = this;
            if(PrefabTable == null)
            {
                Debug.LogError("PrefabManagerにPrefabをセットしてください");
                return;
            }
            _table = new Dictionary<string, GameObject>();
            foreach(var pair in PrefabTable)
            {
                _table.Add(pair.Name, pair.Prehab);
            }
        }

    }
}