using UnityEngine;

public class BlockSpawner : LoadBlockSpawn
{
    protected static BlockSpawner instance;
    public static BlockSpawner Instance { get { return instance; } }

    [SerializeField] private Transform parentSpawn;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    protected virtual Transform GetObjectFromPool(Transform prefabs)
    {
        objPools ??= new();
        foreach (var obj in this.objPools)
        {
            if (obj.name == prefabs.name)
            {
                if (obj != null)
                {
                    this.objPools.Remove(obj);
                    return obj;
                }
            }
        }
        var newPrefab = this.SpawnGameObject(prefabs);
        newPrefab.name = prefabs.name;
        return newPrefab;
    }
    public virtual Transform SpawnWithPool(string name, Vector2 pos)
    {
        Transform prefab = this.GetObjectByName(name);
        if (prefab == null)
        {
            Debug.LogWarning("Frefab not found " + name);
        }
        var newprefab = this.GetObjectFromPool(prefab);
        newprefab.position = pos;
        newprefab.SetParent(parentSpawn);
        parentSpawn.GetComponent<ClickMoveBlock>().SetBlock(newprefab.gameObject);
        newprefab.gameObject.SetActive(true);

        return newprefab;
    }

    public virtual void InsertToObjPool(Transform trans)
    {
        trans.gameObject.SetActive(false);
        objPools ??= new();
        objPools.Add(trans);
    }
    protected virtual Transform GetObjectByName(string name)
    {
        foreach (var prefab in this.prefabs)
        {
            if (prefab.name == name)
                return prefab;
        }
        return null;
    }

    protected virtual Transform SpawnGameObject(Transform obj)
    {
        if (obj == null)
        {
            Debug.LogWarning("obj is null");
        }
        var newObj = Instantiate(obj);
        return newObj;
    }
}
