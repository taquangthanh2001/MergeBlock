using System.Collections.Generic;
using UnityEngine;

public class ClickMoveBlock : MonoBehaviour
{
    protected static ClickMoveBlock instance;

    public static ClickMoveBlock Instance { get { return instance; } }

    protected float speed = 0.1f;
    protected Vector3 positionDef = Vector3.zero;
    protected GameObject blockMove;
    [SerializeField] protected Transform holder;
    [SerializeField] protected Transform env;
    protected List<GameObject> squareObjects = new();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        foreach (Transform child in env)
        {
            this.squareObjects.Add(child.gameObject);
        }
    }
    public void SetBlock(GameObject obj)
    {
        blockMove = obj;
        positionDef = blockMove.transform.position;
    }

    private void OnMouseDrag()
    {
        var test = SwapMousePos(Input.mousePosition);
        MoveByTarget(blockMove.transform, test);
    }
    private void OnMouseUp()
    {
        GameObject blockSpawn = GetBlockBgByMouse(SwapMousePos(Input.mousePosition));
        if (blockSpawn != null)
        {
            InstanceBlockAtTarget(blockSpawn.transform.position);
            MergeBlockCtrl.Instance.GetAllBlockToMerge(blockMove);
            blockSpawn.GetComponent<ChooseBgBlock>().isChoose = true;
            PosSpawnBlock.Instance.InstantiateBlock();
        }
        else
        {
            RestPos();
        }
    }
    protected Vector3 SwapMousePos(Vector3 mouse)
    {
        return Camera.main.ScreenToWorldPoint(mouse);
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
        blockMove.transform.position = positionDef;
    }
    public void InstanceBlockAtTarget(Vector2 target)
    {
        blockMove.transform.position = target;
        blockMove.transform.SetParent(holder);
    }
    protected GameObject GetBlockBgByMouse(Vector2 mousePos)
    {
        foreach (GameObject squareObject in squareObjects)
        {
            Collider2D squareCollider = squareObject.GetComponent<Collider2D>();

            if (squareCollider.OverlapPoint(mousePos) && !squareObject.GetComponent<ChooseBgBlock>().isChoose)
            {
                return squareObject;
            }
        }
        return null;
    }
    public GameObject GetBlockBgByBlock(Vector2 mousePos)
    {
        foreach (GameObject squareObject in squareObjects)
        {
            Collider2D squareCollider = squareObject.GetComponent<Collider2D>();

            if (squareCollider.OverlapPoint(mousePos) && squareObject.GetComponent<ChooseBgBlock>().isChoose)
            {
                return squareObject;
            }
        }
        return null;
    }
}
