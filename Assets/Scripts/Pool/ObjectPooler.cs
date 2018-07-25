using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {


    #region initialize static acess to pooler
    // creating static object and setup it for acess to Pool of objects
    private static ObjectPooler instantce;
    public static ObjectPooler Instance {
        get {
            return instantce;
        }
    }


    private void Awake() {
        instantce = this;
        CreatePools();
    }
    #endregion

    // pooled objects container
    [SerializeField]
    private Dictionary<int, Queue<GameObject>> poolDictionary;

    // type of pools
    [SerializeField]
    private List<Pool> pools;

    private void CreatePools() {
        poolDictionary = new Dictionary<int, Queue<GameObject>>();

        foreach (Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            // creating objects from current pool and add it to dictionary
            for (int i = 0; i < pool.Size; i++) {
                GameObject obj = Instantiate(pool.PoolObject);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            // add pool to dictionary
            poolDictionary.Add(pool.Tag, objectPool);
        }
    }

    public GameObject SpawnObject(int tag, Vector2 position, Quaternion rotation) {
        if (!poolDictionary.ContainsKey(tag)) {
            Logger.LogError("Pool dictionary with tag " + tag + " doesen't exists");
            return null;
        }
        GameObject obj = poolDictionary[tag].Dequeue();

        obj.SetActive(true);

        obj.transform.position = position;
        obj.transform.rotation = rotation;

        List<IPooledObject> pooledObject = new List<IPooledObject>();
        pooledObject.AddRange(obj.GetComponents<IPooledObject>());

        foreach (IPooledObject pObj in pooledObject) {
            if (pObj != null) {
                pObj.OnObjectSpawn();
            }
        }
        poolDictionary[tag].Enqueue(obj);

        return obj;
    }
}
