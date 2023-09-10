using System.Collections.Generic;
using UnityEngine;

public abstract class LoadBlockSpawn : BaseSpawner
{
    [SerializeField] protected List<Transform> prefabs;
    protected List<Transform> objPools;

    protected override void Reset()
    {
        base.Reset();
        LoadPrefabs();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
    }
    protected override void Init()
    {
        objPools = new();
    }
    protected virtual void LoadPrefabs()
    {
        Transform prefabObj = transform.Find("Prefabs");
        if (prefabObj == null) return;
        foreach (Transform child in prefabObj)
        {
            if (!prefabs.Contains(child))
                this.prefabs.Add(child);
        }
        this.HidePrefabs();
    }

    protected virtual void HidePrefabs()
    {
        if (this.prefabs == null) return;
        foreach (var child in prefabs)
        {
            child.gameObject.SetActive(false);
        }
    }
}
