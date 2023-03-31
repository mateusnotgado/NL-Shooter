using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
     public int speed = 2;
    // Start is called before the first frame update
    void Start()
    {  }
 
    // Update is called once per frame
    void Update()
    {
        float HorMov = Input.GetAxis("Horizontal") *Time.deltaTime*speed;

        float VertMov = Input.GetAxis("Vertical") *Time.deltaTime*speed;
        
        transform.Translate(new Vector3(HorMov,VertMov,0));
      
    }
}
