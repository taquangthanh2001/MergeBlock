using TMPro;
using UnityEngine;

public class TextSpawned : MonoBehaviour
{
    internal float toe;
    [SerializeField] protected TextMeshPro pointTxt;

    private void Update()
    {
        if (toe > 0)
        {
            toe -= Time.deltaTime;
            if (toe < 0)
                TextSpawner.Instance.InsertToObjPool(transform);
        }
    }
    internal void AddPoint(int point)
    {
        pointTxt.text = $"+{point}";
    }
}
