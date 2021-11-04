using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorEntry : MonoBehaviour
{
    public int[] doorkeys;
    public string nxtlvl;
    public bool locked = true;
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
      if(other.gameObject.CompareTag("Player")){
        if(!locked){
          SceneManager.LoadScene(nxtlvl);
        }
        else{
          foreach(int i in doorkeys){
            if(!PublicVars.keys[i]){
              open++;
            }
          }
          if(open == 0){
            locked = false;
            SceneManager.LoadScene(nxtlvl);
          }
        }
      }
    }
}
