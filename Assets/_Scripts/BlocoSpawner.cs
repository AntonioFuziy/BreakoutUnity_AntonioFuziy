using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour
{
    GameManager gm;
    public GameObject Bloco;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Construir;
        Construir();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME){
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }

    void Construir(){
        if(gm.gameState == GameManager.GameState.GAME){

            foreach(Transform child in transform){
                GameObject.Destroy(child.gameObject);
            }

            for(int i = 0; i < 12; i++){
                for(int j = 0; j < 4; j++){
                    Vector3 posicao = new Vector3(-8.5f + 1.53f * i, 4 - 0.55f * j);
                    Instantiate(Bloco, posicao, Quaternion.identity, transform);
                }
            }
        }
    }
}
