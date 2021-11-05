using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorEntry : MonoBehaviour
{
    public int[] doorkeys;
    public string nxtlvl;
    public bool locked = true;
    public bool isSceneDoor = false;
    public int keyNum = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other){
      int open = 0;
      int startingKeys = PublicVars.keys[keyNum];
      if(other.gameObject.CompareTag("Player")){
        if(!locked){
          if(isSceneDoor){
            SceneManager.LoadScene(nxtlvl);
          }else{
            Destroy(this.gameObject);
          }
        }
        else{
          if(startingKeys - doorkeys.Length < 0){
            open++;
          }else{
            PublicVars.keys[keyNum] -= doorkeys.Length;
          }
          if(open == 0){
            locked = false;
            if(isSceneDoor){
              SceneManager.LoadScene(nxtlvl);
            }else{
              Destroy(this.gameObject);
            }
          }
        }
      }
    }
}