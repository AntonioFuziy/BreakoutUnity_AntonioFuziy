using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EndGame : MonoBehaviour
{
    public Text message;
    GameManager gm;

    public AudioSource winSound;
    public AudioSource lostSound;
    
    void Start(){
        winSound = gameObject.AddComponent<AudioSource>();
        lostSound = gameObject.AddComponent<AudioSource>();
    } 
    
    private void OnEnable(){
        gm = GameManager.GetInstance();
        if(gm.vidas > 0){
            winSound.Play();
            message.text = "You Win!!!";
        } else {
            message.text = "You Lost!!!";
            lostSound.Play();
        }
    }

    public void Voltar(){
        gm.ChangeState(GameManager.GameState.GAME); 
    }
}
