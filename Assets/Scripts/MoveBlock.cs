using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    protected static MoveBlock instance;
    public static MoveBlock Instance { get { return instance; } }

    protected float speed = 0.1f;
    protected Vector3 positionDef = Vector3.zero;

    [SerializeField] protected Transform holder;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        positionDef = transform.parent.position;
    }


    public void MoveByTarget(Transform obj, Vector2 target)
    {
        if (obj != null)
        {
            obj.position = Vector2.Lerp(obj.position, target, speed);
        }
    }
    public void RestPos()
    {
        transform.parent.position = positionDef;
    }
    public void InstanceBlockAtTarget(Vector2 target)
    {
        Debug.Log(target);
        transform.parent.position = target;
        transform.parent.SetParent(holder);
    }
}
