using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystem
{
    public class SceneLoader : MonoBehaviour
    {
        public event Action DownloadStarted;
        public event Action<float> DownloadProcess;
        public event Action DownloadEnded;
        
        public void LoadAsyncScene(string scene)
        {
            StartCoroutine(Loading(scene));
        }

        private IEnumerator Loading(string name)
        {
            AsyncOperation sceneLoader = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
            
            DownloadStarted?.Invoke();

            while (!sceneLoader.isDone)
            {
                DownloadProcess?.Invoke(sceneLoader.progress);
                yield return null;
            }
            
            DownloadEnded?.Invoke();
        }
    }
}