using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
  public int bulletSpeed=10;
 Rigidbody2D bulletRigidBody;
    // Start is called before the first frame update
    void Start()
    {
   bulletRigidBody = GetComponent<Rigidbody2D>();
   Vector3 playerPos=GameObject.Find("Player").transform.position;
   Vector3 direction = playerPos - transform.position;
   Vector3 rotation =  transform.position - playerPos; 
   bulletRigidBody.velocity = new Vector2(direction.x,direction.y).normalized *bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      void OnCollisionEnter2D(Collision2D col)
    {
      
          Destroy(this.gameObject);
       
     
}
}
