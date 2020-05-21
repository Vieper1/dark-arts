using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void BackToHome()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
