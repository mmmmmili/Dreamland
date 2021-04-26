using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlatformGroupType
{
    Grass,
    Winter
}
public class PlatformSpawner : MonoBehaviour
{
    public  Vector3 startPlatformSpawnPosition=new Vector3 ( 0, -2.4f, 0 );
    /// <summary>
    /// 要生成的平台数量
    /// </summary>
    private int platformCount;
    private ManagerVars vars;
    /// <summary>
    /// 平台生成的位置
    /// </summary>
    private Vector3 platformSpawnPosition;
    /// <summary>
    /// 路径是否向左
    /// </summary>
    private bool isLeft;

    private Sprite selectedPlatformSprite;
    /// <summary>
    /// 组合平台的主题
    /// </summary>
   
    private PlatformGroupType groupType;

    /// <summary>
    /// 钉子生成方向上额外添加的平台位置
    /// </summary>
    private Vector3 spikeDirPlatformPos;

    /// <summary>
    /// 钉子生成方向上额外添加的平台数量
    /// </summary>
    private int afterSpawnSpikeSpawnCount;

    /// <summary>
    /// 是否生成钉子平台？
    /// </summary>
    private bool isSpawnSpike;
    //先
    public void Awake()

    {
        
        vars = ManagerVars.GetManagerVars();
        platformCount = 5;
        platformSpawnPosition = startPlatformSpawnPosition;
        isLeft = false;

        RandomPlatformTheme();

        //生成平台
        for (int i = 0; i < 5; i++)
        {
            platformCount = 5;
            DecidePath();
        }
        //生成人物

        GameObject character = Instantiate(vars.characterPre, transform);
        character.transform.position = new Vector3(0, -1.8f, 0);


    }

    //后
    public void Start()
    {
        EventCenter.AddListener(EventType.DecidePath, DecidePath);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventType.DecidePath, DecidePath);
    }
    
    private void DecidePath()
    {
        if (isSpawnSpike)
        {
            //Debug.Log("10");
            AfterSpawnSpikeSpawnPlatform();
            return;
        }
        if (platformCount > 0)
        {
            platformCount--;
            SpawnPlatform();
        }
        else
        {
            isLeft = !isLeft;
            platformCount = Random.Range(1, 4);
            SpawnPlatform();
        }
    }/// <summary>
    /// 生成平台
    /// </summary>
    private void SpawnPlatform()
    {
        int ranObstacleDir = Random.Range(0, 2);

        if (platformCount >= 1) //生成普通平台
        {       
            SpawnNormalPlatform(ranObstacleDir);
        }
        else if(platformCount==0)
        {//生成组合平台
            int rand = Random.Range(0, 3);
            if (rand == 0)//生成通用组合平台
            {                
                SpawnCommonPlatformGroup(ranObstacleDir);
            }
            else if (rand == 1)//主题组合平台
            {              
                switch (groupType)
                {
                    case PlatformGroupType.Grass:
                        SpawnGrassPlatformGroup(ranObstacleDir);
                        break;
                    case PlatformGroupType.Winter:
                        SpawnWinterPlatformGroup(ranObstacleDir); 
                        break;
                    default:
                        break;
                }
            }
            else
            {
               
                //生成钉子平台
                SpawnSpikePlatform(ranObstacleDir);

                isSpawnSpike = true;//这样在desidePath中就可以修改了
                afterSpawnSpikeSpawnCount = 4;
                if (isLeft)//钉子在右边嗷
                {
                    spikeDirPlatformPos = new Vector3(platformSpawnPosition.x + 1.65f, platformSpawnPosition.y + vars.next_y , 0);
                }
                else
                {
                    spikeDirPlatformPos = new Vector3(platformSpawnPosition.x - 1.65f, platformSpawnPosition.y + vars.next_y
                       , 0);
                }
                //AfterSpawnSpikeSpawnPlatform();
            }
        }
       
        if (isLeft)
        {
            platformSpawnPosition = new Vector3(platformSpawnPosition.x - vars.next_x, 
                platformSpawnPosition.y + vars.next_y,0);
           
        }
        else
        {
            platformSpawnPosition = new Vector3(platformSpawnPosition.x + vars.next_x,
                platformSpawnPosition.y + vars.next_y, 0);
           
        }
    }
    /// <summary>
    /// 生成普通平台
    /// </summary>
    private void SpawnNormalPlatform(int ranObstacleDir)
    {
        ///GameObject go = Instantiate(vars.normalPlatformPre, transform);
        GameObject go = ObjectPool.Instance.GetNormalPlatform();
        go.SetActive(true);

        go.transform.position = platformSpawnPosition;
        go.GetComponent<PlatformScript>().Init(selectedPlatformSprite,ranObstacleDir);
    }
    /// <summary>
    /// 随机选择平台风格
    /// </summary>
    private void RandomPlatformTheme()
    {
        int rand = Random.Range(0, vars.platformSpriteList.Count);
        selectedPlatformSprite = vars.platformSpriteList[rand];

        if (rand == 2)
        {
            groupType = PlatformGroupType.Winter;
        }
        else
        {
            groupType = PlatformGroupType.Grass;
        }
    }
    /// <summary>
    /// 生成通用组合平台
    /// </summary>
    private void SpawnCommonPlatformGroup(int ranObstacleDir)
    {
        //int rand = Random.Range(0, vars.commonPlatformGroupList.Count);
        //GameObject go=Instantiate(vars.commonPlatformGroupList[rand], transform);

        GameObject go = ObjectPool.Instance.GetCommonPlatformGroup();
        go.SetActive(true);

        go.transform.position = platformSpawnPosition;
        go.GetComponent<PlatformScript>().Init(selectedPlatformSprite, ranObstacleDir);
    }
    /// <summary>
    /// 生成草地组合平台
    /// </summary>
    private void SpawnGrassPlatformGroup(int ranObstacleDir)
    {
        //int rand = Random.Range(0, vars.grassPlatformGroupList.Count);
        //GameObject go = Instantiate(vars.grassPlatformGroupList[rand], transform);

        GameObject go = ObjectPool.Instance.GetGrassPlatformGroup();
        go.SetActive(true);


        go.transform.position = platformSpawnPosition;
        go.GetComponent<PlatformScript>().Init(selectedPlatformSprite, ranObstacleDir);
    }
    /// <summary>
    /// 生成冬季组合平台
    /// </summary>
    private void SpawnWinterPlatformGroup(int ranObstacleDir)
    {
        //int rand = Random.Range(0, vars.winterPlatformGroupList.Count);
        //GameObject go = Instantiate(vars.winterPlatformGroupList[rand], transform);


        GameObject go = ObjectPool.Instance.GetWinterPlatformGroup();
        go.SetActive(true);

        go.transform.position = platformSpawnPosition;
        go.GetComponent<PlatformScript>().Init(selectedPlatformSprite, ranObstacleDir);
    }
    /// <summary>
    /// 生成钉子组合平台
    /// </summary>
    /// <param name="dir"></param>
    private void SpawnSpikePlatform(int ranObstacleDir)
    {
        GameObject go=null;
        if (isLeft)
        {
            //go = Instantiate(vars.spikePlatformRight, transform);
            go = ObjectPool.Instance.GetRightSpikePlatform();
           
        }
        else
        {
            //go = Instantiate(vars.spikePlatformLeft, transform);
            go = ObjectPool.Instance.GetLeftSpikePlatform();

        }
        go.SetActive(true);
        go.transform.position = platformSpawnPosition;
        go.GetComponent<PlatformScript>().Init(selectedPlatformSprite, ranObstacleDir);
    }
    /// <summary>
    /// 生成钉子平台之后要生产的平台
    /// 包括钉子方向也包括原来方向的
    /// </summary>
    private void AfterSpawnSpikeSpawnPlatform()
    {
        if (afterSpawnSpikeSpawnCount > 0)
        {
            //Debug.Log("1");
            afterSpawnSpikeSpawnCount--;
            for (int i = 0; i < 2; i++)
            {
                //Debug.Log("2");
                //GameObject temp = Instantiate(vars.normalPlatformPre, transform);
                GameObject temp = ObjectPool.Instance.GetNormalPlatform();
                temp.SetActive(true);
                if (i==0)//生成原来方向的平台
                {
                    temp.transform.position = platformSpawnPosition;
                    if (isLeft)//如果原先路径在左边
                    {
                        //Debug.Log("3");
                        platformSpawnPosition = new Vector3(platformSpawnPosition.x - vars.next_x,
                            platformSpawnPosition.y + vars.next_y, 0);
                    }
                    else
                    {
                        //Debug.Log("4");
                        platformSpawnPosition = new Vector3(platformSpawnPosition.x + vars.next_x,
                            platformSpawnPosition.y + vars.next_y, 0);
                    }

                }
                else//生成钉子方向平台
                {
                    //Debug.Log("5");
                    temp.transform.position = spikeDirPlatformPos;
                    if (isLeft)//如果原先路径在左边,就是钉子方向在右边
                    {
                        //Debug.Log("6");
                        spikeDirPlatformPos = new Vector3(spikeDirPlatformPos.x + vars.next_x,
     spikeDirPlatformPos.y + vars.next_y, 0);
                    }
                    else
                    {
                        //Debug.Log("7");
                        spikeDirPlatformPos = new Vector3(spikeDirPlatformPos.x - vars.next_x,
                            spikeDirPlatformPos.y + vars.next_y, 0);
                    }
                }
                //Debug.Log("8");
                temp.GetComponent<PlatformScript>().Init(selectedPlatformSprite, 1);
            }
        }
        else
        {
            //Debug.Log("9");
            isSpawnSpike = false;
            DecidePath();
            
        }
    }
}
