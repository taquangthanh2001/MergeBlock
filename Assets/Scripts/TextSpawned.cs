using UnityEngine;

public class TextSpawned : MonoBehaviour
{
    internal float toe;

    private void Update()
    {
        if (toe > 0)
        {
            toe -= Time.deltaTime;
            if (toe < 0)
                TextSpawner.Instance.InsertToObjPool(transform);
        }
    }
}
