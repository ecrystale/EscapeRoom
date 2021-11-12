using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
  TransitionManager transitionManager;

  void Start(){
    transitionManager = FindObjectOfType<TransitionManager>();
  }

  public void Load(string sceneName)
  {
    transitionManager.LoadScene(sceneName);
  }
}
