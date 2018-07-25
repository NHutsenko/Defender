using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//basic character stat class
[System.Serializable]
public class Stat {
    [SerializeField]
    private int basicValue;
    public int Value {
        get { return basicValue; }
    }

    public void AddStat(int value) {
        basicValue += value;
    }
}
