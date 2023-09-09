using UnityEngine;

public class BlockSpawner : Spawner
{
    protected static BlockSpawner instance;
    public static BlockSpawner Instance { get { return instance; } }

    [SerializeField] protected Transform parentSpawn;
    internal int valueImg;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public override Transform SpawnWithPool(string name, Vector2 pos)
    {
        Transform prefab = this.GetObjectByName(name);
        if (prefab == null)
        {
            Debug.LogWarning("Frefab not found " + name);
        }
        var newprefab = this.GetObjectFromPool(prefab);
        newprefab.position = pos;
        newprefab.SetParent(parentSpawn);
        newprefab.GetComponent<ChangeImageBlock>().SetSprite(valueImg);
        parentSpawn.GetComponent<ClickMoveBlock>().SetBlock(newprefab.gameObject);
        newprefab.gameObject.SetActive(true);

        return newprefab;
    }
}
