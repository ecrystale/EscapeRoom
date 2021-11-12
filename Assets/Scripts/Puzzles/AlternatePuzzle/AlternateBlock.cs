using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateBlock : MonoBehaviour
{
    public bool state;
    Vector3 originalPos;

    public AudioClip press;
    AudioSource _audiosrc;

    void Start(){
      _audiosrc = GetComponent<AudioSource>();
      originalPos = transform.position;
    }

    void OnMouseDown(){
        _audiosrc.PlayOneShot(press);
        List<GameObject> blocks = transform.parent.gameObject.GetComponent<AlternatePuzzle>().getBlocks();
        int blockIndex = int.Parse(gameObject.name);

        blocks[blockIndex].GetComponent<AlternateBlock>().state = !blocks[blockIndex].GetComponent<AlternateBlock>().state;
        if(blockIndex - 1 >= 0){
            blocks[blockIndex - 1].GetComponent<AlternateBlock>().state = !blocks[blockIndex - 1].GetComponent<AlternateBlock>().state;
        }

        if(blockIndex + 1 < blocks.Count){
            blocks[blockIndex + 1].GetComponent<AlternateBlock>().state = !blocks[blockIndex + 1].GetComponent<AlternateBlock>().state;
        }
    }

    void Update(){
        if(state){
            transform.position = originalPos;
        } else {
            transform.position = originalPos - new Vector3(0, 1f, 0);
        }
    }
}
