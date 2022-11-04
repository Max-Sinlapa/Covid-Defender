using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

    public class SceneManager_Script : MonoBehaviour
    {
        public TextMeshProUGUI ScoreText;
        public string previusScene;

        private void Start()
        {
            previusScene = SceneManager.GetActiveScene().name;
        }

        private void Update()
        {

        }

        public static void LoadSingleScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        public void UnLoadSingleScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
        
        //-----------------------------------------------------------------------------------
        
        public static void Load_PopUP_Scene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            
        }
        public static void UNLoad_PopUP_Scene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
        
        //-------------------------------------------------------------------------------------

        public static void Load_LoseScene(string sceneName, int Score)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);

        }
        public void UnLoad_LoseScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
            SceneManager.LoadScene(previusScene, LoadSceneMode.Single);
            
        }
        
        //--------------------------------------------------------------------------------------
        
        public void ExitGame()
        {
            Application.Quit();
        }
        
        //---------------------------------------------------------------------------------------
        
        #region Scene Load and Unload Events Handler
        private void OnEnable()
        {
            SceneManager.sceneUnloaded += SceneUnloadEventHandler;
            SceneManager.sceneLoaded += SceneLoadedEventHandler;
        }

        private void OnDisable()
        {
            SceneManager.sceneUnloaded -= SceneUnloadEventHandler;
            SceneManager.sceneLoaded -= SceneLoadedEventHandler;
        }
        
        private void SceneUnloadEventHandler(Scene scene)
        {
        }

        private void SceneLoadedEventHandler(Scene scene, LoadSceneMode mode)
        {
        }
        #endregion
    }
