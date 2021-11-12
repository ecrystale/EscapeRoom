using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour{

    TransitionManager transitionManager;

    void Start(){
        transitionManager = FindObjectOfType<TransitionManager>();
    }

    public void PlayGame(){

        transitionManager.LoadScene("Basement");
    }
}
