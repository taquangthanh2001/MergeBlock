using UnityEngine;

public class PosSpawnBlock : MonoBehaviour
{
    protected static PosSpawnBlock instance;
    public static PosSpawnBlock Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    [SerializeField] private BlockSpawner blockSpawner;

    private void Start()
    {
        this.InstantiateBlock();
    }
    private void Reset()
    {
        LoadBlockSpawner();
    }
    protected void LoadBlockSpawner()
    {
        if (blockSpawner != null) return;
        blockSpawner = FindObjectOfType<BlockSpawner>();
    }

    public void InstantiateBlock()
    {
        blockSpawner.SpawnWithPool(GameConst.Block, transform.position);
    }
}
