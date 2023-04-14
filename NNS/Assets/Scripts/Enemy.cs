using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 playerPos;
    public int speed=10;
   public int bulletSpeed=10;
   public GameObject bullet;
   public  float timeToAttack=3.0f;
    // Start is called before the first frame update
    void Start()
    {
        float shootTime = 0.5f;
         InvokeRepeating("Shoot",timeToAttack, shootTime);

    }

    // Update is called once per frame
    void Update()
    { 
        playerPos= GameObject.Find("Player").transform.position;
        
         Vector3 rotation = playerPos - transform.position;
     float rotZ = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg; 
         transform.rotation = Quaternion.Euler(0, 0,rotZ-90);   
    }
      void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.name=="Bullet(Clone)") {
            Destroy(this.gameObject);
        
        }
       
    }

    void Shoot (){
 GameObject projectile = Instantiate(this.bullet,this.gameObject.transform.GetChild(2).position,this.transform.rotation) as GameObject;
   EnemyProjectile   script=  projectile.GetComponent<EnemyProjectile>();
      script.bulletSpeed=bulletSpeed;
     
    }
}
