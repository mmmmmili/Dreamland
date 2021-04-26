using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName ="CreateManagerVarsContainer")]
public class ManagerVars : ScriptableObject
{
    // Start is called before the first frame update
    public List<Sprite> bgThemeSpriteList = new List<Sprite>();
    public List<Sprite> platformSpriteList = new List<Sprite>();
    public float next_x = 0.554f, next_y = 0.645f;

    
    public GameObject normalPlatformPre;//在控制台赋值的嗷
    public GameObject characterPre;//在控制台赋值的嗷

    public List<GameObject> commonPlatformGroupList =  new List<GameObject>();
    public List<GameObject> grassPlatformGroupList =  new List<GameObject>();
    public List<GameObject> winterPlatformGroupList =  new List<GameObject>();

    public GameObject spikePlatformRight;
    public GameObject spikePlatformLeft;
    public static ManagerVars GetManagerVars()
    {
        return Resources.Load<ManagerVars>("ManagerVarsContainer");
    }
}
