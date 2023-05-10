using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   Vector3 playerPos;
   public int speed=10;
   public int bulletSpeed=10;
   public GameObject bullet;
   public float timeToAttack=0f;
   public float shootTime = 0.5f;
   private AudioSource _hitSrc;
   private AudioSource _fireSrc;
   public AudioClip hitSFX;
   public AudioClip fireSFX;
   private bool isVisible;
   private bool canShoot;
   private bool isShooting;
    // Start is called before the first frame update
    void Start()
    {
        _hitSrc = gameObject.AddComponent<AudioSource>();
       _fireSrc = gameObject.AddComponent<AudioSource>();
       canShoot = false;
       isVisible = false;
       isShooting = false;


    }
    

    private void OnBecameVisible()
    {
        isVisible = true;
        if (!isShooting)
        {
            isShooting = true;
            InvokeRepeating("Shoot", timeToAttack, shootTime);
        }
    }

    private void OnBecameInvisible()
    {
        isVisible = false;
        if (isShooting)
        {
            isShooting = false;
            CancelInvoke("Shoot");
        }  
    }

    // Update is called once per frame
    void Update()
    { 
        playerPos= GameObject.Find("Player").transform.position;
        
         Vector3 rotation = playerPos - transform.position;
         float rotZ = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg; 
         transform.rotation = Quaternion.Euler(0, 0,rotZ-90); 
        if(isVisible){
            canShoot = true;
            
        }  
        else {
          canShoot = false;
        }
         
         
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.name=="Bullet(Clone)") {
        _hitSrc.PlayOneShot(hitSFX);
        GetComponent<Renderer>().enabled = false;
        Destroy(other.gameObject);
        Destroy(this.gameObject , 0.5f);
    
      }
      
    }

    void Shoot (){
        if(canShoot){
          _fireSrc.PlayOneShot(fireSFX);
          GameObject projectile = Instantiate(this.bullet,this.gameObject.transform.GetChild(0).position,this.transform.rotation) as GameObject;
          EnemyProjectile script =  projectile.GetComponent<EnemyProjectile>();
          script.bulletSpeed=bulletSpeed;
        }
        
      
    }
}
