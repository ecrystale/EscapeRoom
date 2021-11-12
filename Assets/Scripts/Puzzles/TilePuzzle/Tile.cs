using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{

    private int[,] offset = {{1, 0}, {0, 1}, {-1, 0},  {0, -1}};

    void OnMouseDown(){
        int[] pos = new int[2];
        int numChildren = (int) Mathf.Sqrt(transform.parent.gameObject.GetComponent<TileBoard>().numChildren);

        print(transform.parent.gameObject.GetComponent<TileBoard>().board);
        for(int i = 0; i < numChildren; i++){
            for(int j = 0; j < numChildren; j++){
                if(transform.parent.gameObject.GetComponent<TileBoard>().board[i, j] == gameObject){
                    pos[0] = i;
                    pos[1] = j;
                }
            }
        }
        print(pos[0]);
        print(pos[1]);

        // print((pos[0]).ToString() + (pos[1]).ToString());
        bool moved = false;
        for(int i = 0; i < 4 && !moved; i++){
            if(pos[0] + offset[i, 0] < 0 || pos[0] + offset[i, 0] > numChildren - 1 ||
               pos[1] + offset[i, 1] < 0 || pos[1] + offset[i, 1] > numChildren - 1){
                continue;
            }


            GameObject offsetTile = transform.parent.gameObject.GetComponent<TileBoard>().board[pos[0] + offset[i, 0], pos[1] + offset[i, 1]];
            // print(offsetTile.gameObject.name);
            if(offsetTile.gameObject.name == "empty"){
                // print("movable");
                Vector3 tempPos = gameObject.transform.position;
                gameObject.transform.position = offsetTile.transform.position;
                offsetTile.transform.position = tempPos;

                GameObject temp = transform.parent.gameObject.GetComponent<TileBoard>().board[pos[0], pos[1]];
                transform.parent.gameObject.GetComponent<TileBoard>().board[pos[0], pos[1]] = transform.parent.gameObject.GetComponent<TileBoard>().board[pos[0] + offset[i, 0], pos[1] + offset[i, 1]];
                transform.parent.gameObject.GetComponent<TileBoard>().board[pos[0] + offset[i, 0], pos[1] + offset[i, 1]] = temp;
                
                moved = true;
            }
        }
    }
}
