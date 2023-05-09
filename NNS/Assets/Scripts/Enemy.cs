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
   private AudioSource _audioSrc;
   public AudioClip hitSFX;
    // Start is called before the first frame update
    void Start()
    {
        _audioSrc = gameObject.AddComponent<AudioSource>();
        InvokeRepeating("Shoot", timeToAttack, shootTime);
       
        

    }
    private bool isVisible = false;
    private bool canShoot = false;

    private void OnBecameVisible()
    {
        isVisible = true;
    }

    private void OnBecameInvisible()
    {
        isVisible = false;   
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
        _audioSrc.PlayOneShot(hitSFX);
        Debug.Log(hitSFX);
        Destroy(this.gameObject);
    
      }
      
    }

    void Shoot (){
        GameObject projectile = Instantiate(this.bullet,this.gameObject.transform.GetChild(0).position,this.transform.rotation) as GameObject;
        EnemyProjectile script =  projectile.GetComponent<EnemyProjectile>();
        script.bulletSpeed=bulletSpeed;
      
    }
}
