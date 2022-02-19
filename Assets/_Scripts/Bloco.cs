using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    public AudioSource destroySoundSource;
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
        destroySoundSource.Play();
        Destroy(gameObject);
    }
}
