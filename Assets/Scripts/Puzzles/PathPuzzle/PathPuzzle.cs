using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPuzzle : MonoBehaviour{

    bool solved = false;
    public GameObject[,] board;
    GameObject[] tiles;
    int[] last = new int[2];
    int numChildren;
    public Material onFinish;

    public GameObject[] keys;
    public AudioClip success;
    public AudioClip fail;
    AudioSource _audiosrc;

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
        _audiosrc = GetComponent<AudioSource>();
        foreach(GameObject key in keys){
          key.SetActive(false);
        }
        numChildren = gameObject.transform.childCount;
        tiles = new GameObject[numChildren];
        board = new GameObject[numChildren, numChildren];

        for(int i = 0; i < numChildren; i++){
            tiles[i] = gameObject.transform.GetChild(i).gameObject;
        }

        // print(tiles.Length);
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
        // print(solved);

        if(!solved){
            for(int i = 0; i < Mathf.Sqrt(tiles.Length); i++){
                for(int j = 0; j < Mathf.Sqrt(tiles.Length); j++){
                    if(!board[i, j].GetComponent<PathTile>().state && board[i, j].name != "empty"){
                        return;
                    }
                }
            }

            solved = true;
            _audiosrc.PlayOneShot(success);

            for(int i = 0; i < tiles.Length; i++){
                tiles[i].GetComponent<Renderer>().material = onFinish;
                foreach(GameObject key in keys){
                  key.SetActive(true);
                }
            }
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
        _audiosrc.PlayOneShot(fail);
        for(int i = 0; i < Mathf.Sqrt(tiles.Length); i++){
            for(int j = 0; j < Mathf.Sqrt(tiles.Length); j++){
                board[i, j].GetComponent<PathTile>().reset();
            }
        }
    }
}
