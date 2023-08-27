using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorBlock : MonoBehaviour
{
    protected static ChangeColorBlock instance;
    public static ChangeColorBlock Instance { get { return instance; } }

    [SerializeField] protected Color colorChange;
    [SerializeField] protected Color colorDef;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void ChangeColor()
    {
        gameObject.GetComponent<SpriteRenderer>().material.color = colorChange;
    }
    public void ResetColor()
    {
        gameObject.GetComponent<SpriteRenderer>().material.color = colorDef;
    }
}
