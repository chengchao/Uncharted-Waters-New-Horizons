using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private string _currentSceneName;

    public void Start()
    {
        Load(_currentSceneName);
    }

    private void Load(string sceneName)
    {
        Debug.Log($"Load {sceneName}");
        _currentSceneName = sceneName;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    private void UnloadUnloadSceneAsync()
    {
        SceneManager.UnloadSceneAsync(_currentSceneName).completed += OnSceneUnload;
    }

    private void OnSceneUnload(AsyncOperation obj)
    {
        Debug.Log("unload current scene.");
    }
}
