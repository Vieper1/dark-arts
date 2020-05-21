using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [Header("Timer")]
    public float GoldTime = 6f;
    public float SilverTime = 12f;
    public float BronzeTime = 18f;
    public float GameTime = 0f;





    void Start()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
        GameTime = 0;


    }

    void Update()
    {
        
    }
}
