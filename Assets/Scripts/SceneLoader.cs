using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public LevelEvent levelEvent;
    
    private void Awake() {
        levelEvent.OnLevelClear += LevelClear;
    }


    public void LoadNextScene(){
        int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int indexModule = (currenSceneIndex+1)%SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(indexModule);
    }


    public void QuitGame() {
        Application.Quit();
    }


    private void LevelClear() {
        LoadNextScene();
    }

}
