using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Projectile : MonoBehaviour
{ 
  public int speed = 10;
  public float degrees = 90;
  public float acc=0.1f;
  private Vector2 accDir;
  private Text text;
  private string shootingMmode = "linear";
   Rigidbody2D bulletRigidBody;
        void Start()
    {
      text = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>();
   bulletRigidBody = GetComponent<Rigidbody2D>();
   Vector3 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
   Vector3 direction = mousePos - transform.position;
   Vector3 rotation =  transform.position - mousePos; 
   bulletRigidBody.velocity = new Vector2(direction.x,direction.y).normalized *speed;
   accDir= rotate(bulletRigidBody.velocity,90);
   accDir.Normalize();
   
   //float rot= Mathf.Atan2(rotation.y,rotation.x)*Mathf.Rad2Deg;
   //transform.rotation=Quaternion.Euler(0,0,rot+90);
   
   if(text.text=="Left"){
        shootingMmode="Left";
      } else if ( text.text=="Right"){
        shootingMmode="Right";
    }
    }
    // Update is called once per frame
    void Update()
    {

     


      if(shootingMmode=="Left"){
        bulletRigidBody.velocity =  bulletRigidBody.velocity + accDir * acc;
     // bulletRigidBody.velocity = rotate(bulletRigidBody.velocity,acc);
      } else if (shootingMmode=="Right"){
       bulletRigidBody.velocity =  bulletRigidBody.velocity - accDir * acc;
     // bulletRigidBody.velocity = rotate(bulletRigidBody.velocity,-acc);
      } 
    }
      void OnCollisionEnter2D(Collision2D col)
    {
      
          Destroy(this.gameObject);
        print("acertoMizeravi");
     
}

void setSpeed(int speed){
  this.speed=speed;
}
private Vector2 rotate (Vector2 v,float degrees){
    float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
         float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
         
         float tx = v.x;
         float ty = v.y;
         v.x = (cos * tx) - (sin * ty);
         v.y = (sin * tx) + (cos * ty);
         return v;
}
}