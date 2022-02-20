using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    public AudioSource destroySoundSource;
    public int blockHealth = 2;
    // public Sprite SpriteBlocoQuebrado;
    // Start is called before the first frame update
    void Start()
    {
        destroySoundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (blockHealth <= 0){
        destroySoundSource.Play();
        Destroy(gameObject);
        // } else if (blockHealth == 1) {
        //     GameObject.GetComponent<SpriteRenderer>().sprite = SpriteBlocoQuebrado;
        // } else {
        //     blockHealth--;
        // }
    }
}
