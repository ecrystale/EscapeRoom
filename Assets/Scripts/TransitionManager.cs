using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour{

    private float fadeSpeed = 0.2f;
    public Image fadeImage;

    void Awake(){
        if(FindObjectsOfType<TransitionManager>().Length > 1){
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        StopAllCoroutines();
        StartCoroutine(fadeOut());
    }
    
    IEnumerator fadeOut(){
        yield return new WaitForSeconds(0.2f);
        fadeImage.CrossFadeAlpha(0, 1, true);
        yield return new WaitForSeconds(1);
        fadeImage.gameObject.SetActive(false);
    }

    public void LoadScene(string sceneName){
        StartCoroutine(fadeAndLoad(sceneName));
    }

    IEnumerator fadeAndLoad(string sceneName){
        fadeImage.gameObject.SetActive(true);
        fadeImage.CrossFadeAlpha(1, 1, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

    void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded; 
    }

    void OnDisable(){
        SceneManager.sceneLoaded += OnSceneLoaded; 
    }
}
