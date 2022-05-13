using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystem
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadAsyncScene(SceneID indexScene)
        {
            StartCoroutine(Loading((int)indexScene));
        }

        private IEnumerator Loading(int indexScene)
        {
            yield return SceneManager.LoadSceneAsync(indexScene, LoadSceneMode.Single);
        }
    }
}