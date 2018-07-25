using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour {

	public static void LogMessage(string message) {
        Debug.Log(message);
    }

    public static void LogError(string error) {
        Debug.LogError(error);
    }

    public static void LogWarning(string warning) {
        Debug.LogWarning(warning);
    }
}
