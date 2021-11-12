using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBoard : MonoBehaviour{

    public bool solved = false;
    public GameObject[,] board;
    public GameObject[] tiles;
    public int numChildren;
    public Material onFinish;

    void Start(){
        numChildren = gameObject.transform.childCount;
        tiles = new GameObject[numChildren];
        board = new GameObject[numChildren, numChildren];
       
        for(int i = 0; i < numChildren; i++){
            tiles[i] = gameObject.transform.GetChild(i).gameObject;
        }

        int count = 0;
        for(int i = 0; i < Mathf.Sqrt(numChildren); i++){
            for(int j = 0; j < Mathf.Sqrt(numChildren); j++){
                board[i, j] = tiles[count];
                count++;
            }
        }
    }

    void LateUpdate(){
        if(solved){
            for(int i = 0; i < Mathf.Sqrt(numChildren); i++){
                for(int j = 0; j < Mathf.Sqrt(numChildren); j++){
                    Destroy(board[i, j].GetComponent<HighlightOnHover>());
                    Destroy(board[i, j].GetComponent<Tile>());
                }
            }

            Destroy(gameObject.GetComponent<TileBoard>());
            return;
        }

        int count = 1;
        for(int i = 0; i < Mathf.Sqrt(numChildren); i++){
            for(int j = 0; j < Mathf.Sqrt(numChildren); j++){
                if(board[i, j].name == count.ToString()){
                    count++;
                    if(count == tiles.Length){
                        solved = true;

                        for(int k = 0; k < tiles.Length; k++){
                            tiles[k].GetComponent<Renderer>().material = onFinish;
                        }       
                    }
                } else {
                    return;
                }
            }
        }


    }
}
