using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//basic character stat class
[System.Serializable]
public class Stat {
    [SerializeField]
    private int _basicValue;
    public int Value {
        get { return _basicValue; }
    }

    public void AddStat(int value) {
        _basicValue += value;
    }

    public void UpdateStat(int value) {
        _basicValue = value;
    }
}
