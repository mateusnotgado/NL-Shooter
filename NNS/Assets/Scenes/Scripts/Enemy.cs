using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 playerPos;
    Vector3 movDir;
    public int speed=1;
    // Start is called before the first frame update
    void Start()
    {
        playerPos= GameObject.Find("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movDir= playerPos - transform.position;
        
    }
      void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.name=="Bullet(Clone)") {
            Destroy(this.gameObject);
        
        }
       
    }
}
