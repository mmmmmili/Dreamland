﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public SpriteRenderer[] spriteRenderers;
    /// <summary>
    /// 参与随机的障碍物
    /// </summary>
    public GameObject obstacle;
   public void Init(Sprite sprite,int obstacleDir)
    {
        for(int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].sprite = sprite;
        }
        if(obstacleDir==0)//朝右边
        {
            if (obstacle != null)
            {
                obstacle.transform.localPosition = new Vector3(-obstacle.transform.localPosition.x,
                    obstacle.transform.localPosition.y, obstacle.transform.localPosition.z);
            }
        }
    }
}
