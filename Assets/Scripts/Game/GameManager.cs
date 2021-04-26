using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;//单例模式
    public bool isGameStart { get; set; }//这看起来好像是一个类
    public bool isGameOver { get; set; }//这看起来好像是一个类

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
