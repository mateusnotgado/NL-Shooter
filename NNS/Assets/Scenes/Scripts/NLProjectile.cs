using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NLProjectile : MonoBehaviour
{
  public int speed = 10;
        void Start()
    {
         Rigidbody2D bulletRigidBody = GetComponent<Rigidbody2D>();
   Vector3 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
   Vector3 direction = mousePos - transform.position;
   Vector3 rotation =  transform.position - mousePos; 
   bulletRigidBody.velocity = new Vector2(direction.x,direction.y).normalized *speed;
   float rot= Mathf.Atan2(rotation.y,rotation.x)*Mathf.Rad2Deg;
   transform.rotation=Quaternion.Euler(0,0,rot+90);
    }

    // Update is called once per frame
    void Update()
    {
  
    }
     void OnTriggerExit2D(Collider2D other)
    {
        
        Destroy(this.gameObject);
    }
      void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.name=="Enemy") {
          Destroy(this.gameObject);
        print("acertoMizeravi");
        }
}
}