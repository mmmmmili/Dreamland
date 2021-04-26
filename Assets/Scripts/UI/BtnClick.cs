using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnClick : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("3");
        //GetComponent<Button>().onClick.AddListener(() =>
        //{
        //    EventCenter.Broadcast(EventType.ShowText);
        //    Debug.Log("4");
        //}
        //);
        GetComponent<Button>().onClick.AddListener(onClick);
       
    }
    private void onClick()
    {
        EventCenter.Broadcast(EventType.ShowText, "test");
        Debug.Log("5");
    }
}
