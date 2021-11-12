using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    //public float timeRemaining = 10;
    public Text displayText;
    bool timerOn = true;
    private static GameObject Instance;

    void Awake() {
        if (Instance == null){
             Instance = transform.gameObject;
             DontDestroyOnLoad(transform.gameObject);
        } else {
           Destroy(transform.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn){
            if(PublicVars.timeRemaining > 0){
                PublicVars.timeRemaining -= Time.deltaTime;

                float minutes = Mathf.FloorToInt(PublicVars.timeRemaining / 60); 
                float seconds = Mathf.FloorToInt(PublicVars.timeRemaining % 60);

                displayText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }else{
                PublicVars.timeRemaining = 0;
                timerOn  = false;
                SceneManager.LoadScene("EndBad");
            }
            
        }
    }
}
