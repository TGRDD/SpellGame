using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneHelper
{
    public static void LoadScene(string SceneName, Type type)
    {
        Debug.Log($"The {type} caused a scene change");
        SceneManager.LoadScene(SceneName);
    }
}
