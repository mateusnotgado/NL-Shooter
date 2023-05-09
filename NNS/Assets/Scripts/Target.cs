using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{   
    private AudioSource _audioSrc;
    public AudioClip hitSFX;
    // Start is called before the first frame update
    void Start()
    {
        _audioSrc = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Bullet(Clone)")
        {   
            _audioSrc.PlayOneShot(hitSFX);
            Destroy(this.gameObject);

        }

    }
}
