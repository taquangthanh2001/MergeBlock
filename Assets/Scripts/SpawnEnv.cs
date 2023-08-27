using System.Collections.Generic;
using UnityEngine;

public class SpawnEnv : MonoBehaviour
{
    [SerializeField] protected GameObject blockSpawn;

    protected Transform spawnPosX;
    protected Transform spawnPosY;

    protected List<GameObject> spawnList = new();
    protected float offset = 0.018f;

    private void Awake()
    {
        GetPosSpawn();

    }
    protected void GetPosSpawn()
    {
        spawnPosX = blockSpawn.transform;
        spawnList.Add(blockSpawn);
        for (int i = 0; i < 5; ++i)
        {
            if (i == 0)
                spawnPosY = spawnList[i].transform;
            else
            {
                InstanceBlock(GetPos(spawnPosX), true);
                spawnPosY = spawnList[i].transform;
            }
            for (int j = 0; j < 4; j++)
            {
                InstanceBlock(GetPos(spawnPosY, false));
            }
        }
    }
    protected Vector2 GetPos(Transform tranf, bool isHorrizol = true)
    {
        float a;
        float test;
        if (isHorrizol)
        {
            a = tranf.transform.position.x;
            test = a + tranf.localScale.x / 2 + tranf.localScale.x * 4.5f - offset;
            return new() { x = test, y = spawnPosX.position.y };
        }
        else
        {
            a = tranf.transform.position.y;
            test = a - tranf.localScale.x / 2 - tranf.localScale.x * 4.5f + offset;
            return new() { x = spawnPosY.position.x, y = test };
        }
    }
    protected void InstanceBlock(Vector2 pos, bool isSetSpawnPos = false)
    {
        var obj = Instantiate(blockSpawn, pos, Quaternion.identity);
        obj.transform.parent = transform;
        obj.transform.localScale = blockSpawn.transform.localScale;
        if (isSetSpawnPos)
        {
            obj.name = "BlockX";
            spawnPosX = obj.transform;
            spawnList.Add(obj);
        }
        else
        {
            spawnPosY = obj.transform;
        }
    }
}
