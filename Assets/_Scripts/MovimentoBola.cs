using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Range(1, 15)]
    public float velocidade = 5.0f;
    private Vector3 direcao;
    GameManager gm;

    void Start()
    {
        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(1.0f, 5.0f);

        direcao = new Vector3(dirX, dirY).normalized;
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
        
        transform.position += direcao * Time.deltaTime * velocidade;

        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);

        if( posicaoViewport.x < 0 || posicaoViewport.x > 1 )
        {
            direcao = new Vector3(-direcao.x, direcao.y);
        }
        if( posicaoViewport.y < 0 || posicaoViewport.y > 1 )
        {
            direcao = new Vector3(direcao.x, -direcao.y);
        }
        if(posicaoViewport.y < 0){
            Reset();
        }
        Debug.Log($"Vidas: {gm.vidas} \t | \t Pontos: {gm.pontos}");
    }

    private void Reset(){
        if(gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME){
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
        
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = playerPosition + new Vector3(0, 0.5f, 0);

        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(2.0f, 5.0f);

        direcao = new Vector3(dirX, dirY).normalized;
        gm.vidas--;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            float dirX = Random.Range(-5.0f, 5.0f);
            float dirY = Random.Range(1.0f, 5.0f);

            direcao = new Vector3(dirX, dirY).normalized;
        }
        else if(col.gameObject.CompareTag("Bloco"))
        {
            direcao = new Vector3(direcao.x, -direcao.y);
            gm.pontos++;
        }
    }
}