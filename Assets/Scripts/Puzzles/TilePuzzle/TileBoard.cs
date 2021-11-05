using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBoard : MonoBehaviour{
    public static GameObject[,] board = new GameObject[3, 3];
    public GameObject[] tiles = new GameObject[9];

    void Start(){
        tiles = GameObject.FindGameObjectsWithTag("Tile");
       
        int count = 0;
        for(int i = 0; i < 3; i++){
            for(int j = 0; j < 3; j++){
               board[i, j] = tiles[count];
               count++;
            }
        }
    }

    void Update(){
        if(PublicVars.TilePuzzleSolved){
            for(int i = 0; i < 3; i++){
                for(int j = 0; j < 3; j++){
                    Destroy(board[i, j].GetComponent<HighlightOnHover>());
                    Destroy(board[i, j].GetComponent<Tile>());
                }
            }

            Destroy(gameObject.GetComponent<TileBoard>());
            return;
        }

        int count = 1;
        for(int i = 0; i < 3; i++){
            for(int j = 0; j < 3; j++){
                print(count);
                if(board[i, j].name == count.ToString()){
                    count++;
                    if(count == 9){
                        PublicVars.TilePuzzleSolved = true;
                    }
                } else {
                    return;
                }
            }
        }


    }
}
