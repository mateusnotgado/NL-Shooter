using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float accl=0.1f;
    public float bulletAcc=0.1f;
   public GameObject bullet;
   public Rigidbody2D m_body2d;
  public int maxSpeed=5;
  public int bulletSpeed=10;
    void Start()
    {
      
    }

 
    void Update()
    {
   m_body2d =  GetComponent<Rigidbody2D>();
   move();
         Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         Vector3 rotation = mousePos - transform.position;
     float rotZ = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg; 
         transform.rotation = Quaternion.Euler(0, 0,rotZ-90);

       if(Input.GetMouseButtonDown(0)){
       Shoot();
        }

    }
      private void Shoot(){
  GameObject projectile = Instantiate(this.bullet,this.gameObject.transform.GetChild(2).position,this.transform.rotation) as GameObject;
   Projectile   script=  projectile.GetComponent<Projectile>();
      script.speed=bulletSpeed;
      script.acc=bulletAcc;
         }
     void move () {
       
         Vector3 position = transform.position;
  if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
          if(m_body2d.velocity.x>=-1*maxSpeed){
              m_body2d.velocity = new Vector2(m_body2d.velocity.x-accl,m_body2d.velocity.y);
          }  
            
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            if(m_body2d.velocity.x<=maxSpeed){
              m_body2d.velocity = new Vector2(m_body2d.velocity.x+accl,m_body2d.velocity.y);
          } 
        } else {
       m_body2d.velocity = new Vector2(m_body2d.velocity.x* (float)0.99,m_body2d.velocity.y);
        }

          if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ){
             if(m_body2d.velocity.y<=maxSpeed){
                m_body2d.velocity = new Vector2(m_body2d.velocity.x,m_body2d.velocity.y+accl);
                 }

           } else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ){
               if(m_body2d.velocity.y>=maxSpeed*-1){
                m_body2d.velocity = new Vector2(m_body2d.velocity.x,m_body2d.velocity.y-accl); }
           } else {
              m_body2d.velocity = new Vector2(m_body2d.velocity.x,m_body2d.velocity.y* (float)0.99);
           }
     }

     void OnCollisionEnter2D(Collision2D col)
    {
      
         if (col.gameObject.name=="EnemyBullet(Clone)") {
           print("perdeu");
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
       
    }
}

