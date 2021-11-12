using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorEntry : MonoBehaviour
{
    public int[] doorkeys;
    public string nxtlvl;
    public bool locked = true;
    public bool isSceneDoor = false;
    public int keyNum = 0;

    public AudioClip door_open;
    AudioSource _audiosrc;
    public Text doorText;
    // Start is called before the first frame update
    TransitionManager transitionManager;

    void Start()
    {
      _audiosrc = GetComponent<AudioSource>();
      transitionManager = FindObjectOfType<TransitionManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other){
      print("Collision detected");
      int open = 0;
      int startingKeys = PublicVars.keys[keyNum];
      if(other.gameObject.CompareTag("Player")){
        if(!locked){
          StartCoroutine(playaudio());
          if(isSceneDoor){
            transitionManager.LoadScene(nxtlvl);
          }else{
            Destroy(this.gameObject);
          }
        }
        else{
          if(startingKeys - doorkeys.Length < 0){
            //StartCoroutine(fadeIn());
            StartCoroutine(fadeOut());
            //doorText.CrossFadeAlpha(0.0f, 0.05f, false);
            open++;
          }else{
            PublicVars.keys[keyNum] -= doorkeys.Length;
          }
          if(open == 0){
            print(open);
            locked = false;
            StartCoroutine(playaudio());
            if(isSceneDoor){
              transitionManager.LoadScene(nxtlvl);
            }else{
              Destroy(this.gameObject);
            }
          }
        }
      }
    }

    IEnumerator playaudio(){
      _audiosrc.PlayOneShot(door_open);
      yield return new WaitForSeconds(2f);
    }

    IEnumerator fadeOut()
    {
      doorText.text = "I don't have enough keys...";
      doorText.CrossFadeAlpha(1.0f, 0.05f, false);
      yield return new WaitForSeconds(2f);
      doorText.CrossFadeAlpha(0.0f, 0.05f, false);
    }
/*
    IEnumerator fadeOut()
    {
      doorText.text = "I don't have enough keys...";
      yield return new WaitForSeconds(2f);
      doorText.CrossFadeAlpha(1.0f, 0.05f, false);
    }*/
}
