using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    private Button btn_stop;
    private Button btn_play;
    private Text txt_score;
    private Text txt_diamondCount;

    private void Awake()
    {
        EventCenter.AddListener(EventType.ShowGamePanel, Show);
        Init();
        
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventType.ShowGamePanel, Show);
    }
    private void Init()
    {
        btn_stop = transform.Find("btn_stop").GetComponent<Button>();
        btn_stop.onClick.AddListener(OnStopButtonClick);

        btn_play = transform.Find("btn_play").GetComponent<Button>();
        btn_play.onClick.AddListener(OnPlayButtonClick);

        txt_score = transform.Find("txt_score").GetComponent<Text>();

        txt_diamondCount = transform.Find("diamond/txt_diamondCount").GetComponent<Text>();

        btn_play.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
    private void OnStopButtonClick()
    {
        btn_stop.gameObject.SetActive(false);
        btn_play.gameObject.SetActive(true);
    }
    private void OnPlayButtonClick()
    {
        btn_stop.gameObject.SetActive(true);
        btn_play.gameObject.SetActive(false);
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    
}
