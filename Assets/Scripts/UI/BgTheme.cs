using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgTheme : MonoBehaviour
{
    public SpriteRenderer bgsprite;
    public ManagerVars vars ;
    private void Awake()
    {
        vars = ManagerVars.GetManagerVars();
        bgsprite = GetComponent<SpriteRenderer>();
        bgsprite.sprite = vars.bgThemeSpriteList[Random.Range(0, vars.bgThemeSpriteList.Count)];
       // bgsprite.sprite = vars.bgThemeSpriteList[2];
    }
}
