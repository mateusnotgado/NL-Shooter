using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RulesMannager : MonoBehaviour
{
    GameObject [] targets;
    private bool victory=false;
    private bool gameOver = false;
    private bool timeOut = false;
   
    void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("Targets");
        if (targets.Length == 0 && !victory&&!gameOver)
        {
            print("Vitoria !!!!");
            victory = true;
            SceneManager.LoadScene("VictoryScene", LoadSceneMode.Single);
        } 
        if (!victory && timeOut&&!gameOver){
            gameOver = true;
            print("perdeu compar�a");
            SceneManager.LoadScene("GameOverScreen", LoadSceneMode.Single);
        }
    }
   
    public void TimeIsOut()
    {
        this.timeOut = true;
    }

    private void Reset()
    {
        
    }
}
