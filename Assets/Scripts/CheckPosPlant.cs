using UnityEngine;

public class CheckPosPlant : MonoBehaviour
{
    protected static CheckPosPlant instance;
    public static CheckPosPlant Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    protected GameObject block = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChooseBgBlock>() != null)
        {
            if (collision.gameObject.GetComponent<ChooseBgBlock>().isChoose) return;
            if (block != null)
            {
                block.GetComponent<ChangeColorBlock>().ResetColor();
            }
            block = collision.gameObject;
            block.GetComponent<ChangeColorBlock>().ChangeColor();
        }
    }
    public GameObject Check()
    {
        if (block)
            return block;
        else
            return null;
    }
}
