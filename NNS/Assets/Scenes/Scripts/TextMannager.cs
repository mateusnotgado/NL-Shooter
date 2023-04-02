using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextMannager : MonoBehaviour
{
    public Text ShootingMode;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
          ShootingMode.text="Left";
        } else if (Input.GetKeyDown(KeyCode.Alpha2)){
             ShootingMode.text="Linear";
        } else if (Input.GetKeyDown(KeyCode.Alpha3)){
             ShootingMode.text="Right";
        }
    }
}
