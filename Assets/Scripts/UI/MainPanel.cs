using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    private Button btn_start;
    private Button btn_shop;
    private Button btn_rank;

    
    private Button btn_sound;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        btn_start = transform.Find("btn_start").GetComponent<Button>();
        btn_start.onClick.AddListener(OnStartButtonClick);



        btn_rank = transform.Find("btn_rank").GetComponent<Button>();
        btn_rank.onClick.AddListener(OnRankButtonClick);

        btn_sound = transform.Find("btn_sound").GetComponent<Button>();
        btn_sound.onClick.AddListener(OnSoundButtonClick);

        btn_shop = transform.Find("btn_shop").GetComponent<Button>();
        btn_shop.onClick.AddListener(OnShopButtonClick);
    }
    private void OnStartButtonClick()
    {
        GameManager.Instance.isGameStart = true;
        EventCenter.Broadcast(EventType.ShowGamePanel);
        gameObject.SetActive(false);
    }
    private void OnShopButtonClick()
    {

    }
    private void OnRankButtonClick()
    {

    }
    private void OnSoundButtonClick()
    {

    }
}
