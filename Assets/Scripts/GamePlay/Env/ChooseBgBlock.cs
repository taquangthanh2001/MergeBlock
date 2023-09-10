using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBgBlock : MonoBehaviour
{
    protected static ChooseBgBlock instance;
    public static ChooseBgBlock Instance { get { return instance; } }


    public bool isChoose = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

}
