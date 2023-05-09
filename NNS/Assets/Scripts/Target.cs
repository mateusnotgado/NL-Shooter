using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{   
    private AudioSource audioSrc;
    public AudioClip hitSFX;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = gameObject.AddComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Bullet(Clone)")
        {   
            audioSrc.PlayOneShot(hitSFX);
            GetComponent<Renderer>().enabled = false;
            Destroy(col.gameObject);
            Destroy(this.gameObject , 0.5f);

        }

    }
}
