using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        gameObject.SetActive(false);
        EventCenter.AddListener<string>(EventType.ShowText, Show);
        EventCenter.AddListener(EventType.ShowText, Show2);
    }
    public void Show(string str)
    {
        gameObject.SetActive(true);
        GetComponent<Text>().text = str;
    }
    public void Show2()
    {
       
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<string>(EventType.ShowText, Show);
        EventCenter.RemoveListener(EventType.ShowText, Show2);

    }
}
