using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool {

    [SerializeField]
    private int tag;
    public int Tag {
        get {
            return tag;
        }
    }
    [SerializeField]
    private GameObject poolObj;
    public GameObject PoolObject {
        get {
            return poolObj;
        }
    }
    [SerializeField]
    private int size;
    public int Size {
        get {
            return size;
        }
    }
}
