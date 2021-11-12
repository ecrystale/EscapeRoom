using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPuzzle : MonoBehaviour{

    bool solved = false;
    public static GameObject[,] board;
    GameObject[] tiles;
    int[] last = new int[2];

    public void setLast(GameObject curr){
        int[] currPos = new int[2];

        for(int i = 0; i < Mathf.Sqrt(tiles.Length); i++){
            for(int j = 0; j < Mathf.Sqrt(tiles.Length); j++){
                if(board[i, j] == curr){
                    currPos[0] = i;
                    currPos[1] = j;
                }
            }
        }
        
        last = currPos;
    }

    void Start(){
        tiles = GameObject.FindGameObjectsWithTag("PathTile");
        board = new GameObject[(int) Mathf.Sqrt(tiles.Length), (int) Mathf.Sqrt(tiles.Length)];

        int count = 0;
        for(int i = 0; i < Mathf.Sqrt(tiles.Length); i++){
            for(int j = 0; j < Mathf.Sqrt(tiles.Length); j++){
                if(tiles[count].name == "start"){
                    last[0] = i;
                    last[1] = j;
                }

                board[i, j] = tiles[count];
                count++;
            }
        }
    }

    void LateUpdate(){
        if(!solved){
            for(int i = 0; i < Mathf.Sqrt(tiles.Length); i++){
                for(int j = 0; j < Mathf.Sqrt(tiles.Length); j++){
                    if(!board[i, j].GetComponent<PathTile>().state && board[i, j].name != "empty"){
                        return;
                    }
                }
            }

            solved = true;
        }

        Destroy(GetComponent<PathPuzzle>());
        for(int i = 0; i < Mathf.Sqrt(tiles.Length); i++){
            for(int j = 0; j < Mathf.Sqrt(tiles.Length); j++){
                Destroy(board[i, j].GetComponent<PathTile>());
                Destroy(board[i, j].GetComponent<HighlightOnHover>());
            }
        }
    }

    public bool isAdjacent(GameObject curr){
        int[,] offset = {{1, 0}, {0, 1}, {-1, 0}, {0, -1}};
        int[] currPos = new int[2];

        for(int i = 0; i < Mathf.Sqrt(tiles.Length); i++){
            for(int j = 0; j < Mathf.Sqrt(tiles.Length); j++){
                if(board[i, j] == curr){
                    currPos[0] = i;
                    currPos[1] = j;
                }
            }
        }

        if(currPos[0] == last[0] && currPos[1] == last[1]){
            return true;
        }

        for(int i = 0; i < 4; i++){
            if(currPos[0] + offset[i, 0] == last[0] && currPos[1] + offset[i, 1] == last[1]){
                return true;
            }
        }

        return false;
    }

    public void reset(){
        for(int i = 0; i < Mathf.Sqrt(tiles.Length); i++){
            for(int j = 0; j < Mathf.Sqrt(tiles.Length); j++){
                board[i, j].GetComponent<PathTile>().reset();
            }
        }
    }
}
