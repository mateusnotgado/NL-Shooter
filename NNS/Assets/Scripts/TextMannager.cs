using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TextMannager : MonoBehaviour
{
    public Text ShootingMode;
    public Text TimerText;
    public string[] GunMode = {"Left" , "Linear" , "Right"};
    public int idx_GunMode = 1; //starts at linear
    // Start is called before the first frame update
    public int mod_floor(int i) {
      return ((i % 3) + 3) % 3;
    }
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

        if(Input.GetKeyDown(KeyCode.Q)){
          idx_GunMode = mod_floor(idx_GunMode - 1);
          ShootingMode.text = GunMode[idx_GunMode];
        }
        else if(Input.GetKeyDown(KeyCode.E)){
          idx_GunMode = mod_floor(idx_GunMode + 1);
          ShootingMode.text = GunMode[idx_GunMode];
        }
    }
}
