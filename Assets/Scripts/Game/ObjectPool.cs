using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //单例模式
    public static ObjectPool Instance;

    public int initSpawnCount = 5;
    private List<GameObject> normalPlatformList = new List<GameObject>();
    private List<GameObject> commonPlatformList = new List<GameObject>();
    private List<GameObject> grassPlatformList = new List<GameObject>();
    private List<GameObject> winterPlatformList = new List<GameObject>();
    private List<GameObject> spikePlatformLeftList = new List<GameObject>();
    private List<GameObject> spikePlatformRightList = new List<GameObject>();
    private ManagerVars vars;
    private void Awake()
        
    {
        Instance = this;
        vars = ManagerVars.GetManagerVars();
        Init();
    }
    private void Init()
    {
        for(int i=0;i< initSpawnCount; i++)
            InstantiateObject(vars.normalPlatformPre,ref normalPlatformList);
           
        for(int i=0;i< vars.commonPlatformGroupList.Count; i++)
            for (int j = 0; j < initSpawnCount; i++)
                InstantiateObject(vars.commonPlatformGroupList[j], ref commonPlatformList);
        for (int i = 0; i < vars.grassPlatformGroupList.Count; i++)
            for (int j = 0; j < initSpawnCount; i++)
                InstantiateObject(vars.grassPlatformGroupList[j], ref grassPlatformList);
        for (int i = 0; i < vars.winterPlatformGroupList.Count; i++)
            for (int j = 0; j < initSpawnCount; i++)
                InstantiateObject(vars.winterPlatformGroupList[j], ref winterPlatformList);

        for (int i = 0; i < initSpawnCount; i++)
            InstantiateObject(vars.spikePlatformLeft, ref spikePlatformLeftList);

        for (int i = 0; i < initSpawnCount; i++)
            InstantiateObject(vars.spikePlatformRight, ref spikePlatformRightList);

    }
    private GameObject InstantiateObject(GameObject prefab,ref List<GameObject> addList)
    {
        GameObject go = Instantiate(prefab, transform);
        go.SetActive(false);
        addList.Add(go);
        return go;
    }
    /// <summary>
    /// 获取单个平台
    /// </summary>
    /// <returns></returns>
    public GameObject GetNormalPlatform()
    {
        for (int i = 0; i < normalPlatformList.Count; i++)
            if (normalPlatformList[i].activeInHierarchy == false)
                return normalPlatformList[i];

        return InstantiateObject(vars.normalPlatformPre, ref normalPlatformList);
    }

    /// <summary>
    /// 获取通用组合平台
    /// </summary>
    /// <returns></returns>
    public GameObject GetCommonPlatformGroup()
    {
        for (int i = 0; i < commonPlatformList.Count; i++)
            if (commonPlatformList[i].activeInHierarchy == false)
                return commonPlatformList[i];

        int ran = Random.Range(0, vars.commonPlatformGroupList.Count);
        return InstantiateObject(vars.commonPlatformGroupList[ran], ref commonPlatformList);
    }
    /// <summary>
    /// 获取草地组合平台
    /// </summary>
    /// <returns></returns>
    public GameObject GetGrassPlatformGroup()
    {
        for (int i = 0; i < grassPlatformList.Count; i++)
            if (grassPlatformList[i].activeInHierarchy == false)
                return grassPlatformList[i];

        int ran = Random.Range(0, vars.grassPlatformGroupList.Count);
        return InstantiateObject(vars.grassPlatformGroupList[ran], ref grassPlatformList);
    }
    /// <summary>
    /// 获取冬季组合平台
    /// </summary>
    /// <returns></returns>
    public GameObject GetWinterPlatformGroup()
    {
        for (int i = 0; i < winterPlatformList.Count; i++)
            if (winterPlatformList[i].activeInHierarchy == false)
                return winterPlatformList[i];

        int ran = Random.Range(0, vars.winterPlatformGroupList.Count);
        return InstantiateObject(vars.winterPlatformGroupList[ran], ref winterPlatformList);
    }
    /// <summary>
    /// 获取左边钉子平台
    /// </summary>
    /// <returns></returns>
    public GameObject GetLeftSpikePlatform()
    {
        for (int i = 0; i < spikePlatformLeftList.Count; i++)
            if (spikePlatformLeftList[i].activeInHierarchy == false)
                return spikePlatformLeftList[i];

        return InstantiateObject(vars.spikePlatformLeft, ref spikePlatformLeftList);
    }
    /// <summary>
    /// 获取右边边钉子平台
    /// </summary>
    /// <returns></returns>
    public GameObject GetRightSpikePlatform()
    {
        for (int i = 0; i < spikePlatformRightList.Count; i++)
            if (spikePlatformRightList[i].activeInHierarchy == false)
                return spikePlatformRightList[i];

        return InstantiateObject(vars.spikePlatformRight, ref spikePlatformRightList);
    }
}
