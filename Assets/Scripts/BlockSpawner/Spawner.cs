using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected Transform holder;

    protected virtual void Reset()
    {
        LoadComponent();
    }
    protected virtual void LoadComponent()
    {
        if (this.holder != null) return;
        Transform holder = transform.Find("Holder");
        this.holder = holder;
    }
    protected virtual void Init()
    {
    }
}
