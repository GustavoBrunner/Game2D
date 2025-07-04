using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        private readonly HashSet<string> m_loadedScenes = new();
        public HashSet<string> LoadedScenes { get => m_loadedScenes; }
        protected override void Awake()
        {
            base.Awake();
        }
        public void LoadSceneAdditive(string sceneName)
        {
            if(string.IsNullOrEmpty( sceneName))
            {
                Debug.LogError("Scene name cannot be null or empty.");
                return;
            }
            if(SceneManager.GetSceneByName(sceneName).isLoaded)
            {
                Debug.LogWarning($"Scene '{sceneName}' is already loaded.");
                return;
            }
            LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }
        public void LoadSceneSync(string sceneName)
        {
            if(string.IsNullOrEmpty(sceneName))
            {
                Debug.LogError("Scene name cannot be null or empty.");
                return;
            }
            if(SceneManager.GetSceneByName(sceneName).isLoaded)
            {
                Debug.LogWarning($"Scene '{sceneName}' is already loaded.");
                return;
            }
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

        private string LoadSceneAsync(string sceneName, LoadSceneMode additive)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, additive);
            if (asyncOperation != null)
            {
                asyncOperation.completed += (operation) =>
                {
                    if (operation.isDone)
                    {
                        m_loadedScenes.Add(sceneName);
                        Debug.Log($"Scene '{sceneName}' loaded successfully.");
                    }
                    else
                    {
                        Debug.LogError($"Failed to load scene '{sceneName}'.");
                    }
                };
                return sceneName;
            }
            else
            {
                Debug.LogError($"Failed to start loading scene '{sceneName}'.");
                return null;
            }
        }
    }
}
