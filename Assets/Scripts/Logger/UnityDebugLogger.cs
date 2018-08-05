﻿using UnityEngine;
using Logger = UnityEngine.Logger;

public class UnityDebugLogger : ILogger {

    public void Info(string msg) {
        Debug.Log(msg);
    }

    public void Error(string msg) {
        Debug.LogError(msg);
    }

    public void Warning(string msg) {
        Debug.Log(msg);
    }
}
