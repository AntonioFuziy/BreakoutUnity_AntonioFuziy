using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuPrincipal : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }
 
    public void Comecar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}
