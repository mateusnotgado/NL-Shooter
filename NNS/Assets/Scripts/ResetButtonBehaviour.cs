using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetButtonBehaviour : MonoBehaviour
{
        int n;
        public void OnButtonPress()
        {
           
           print("Button clicked " + n + " times.");
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
