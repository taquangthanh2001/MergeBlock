using System.Collections.Generic;
using UnityEngine;

public class ChangeImageBlock : MonoBehaviour
{
    public float radius = 0.5f;
    [HideInInspector]
    public int value = 1;
    [SerializeField] protected List<Sprite> sprites;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public void SetSprite(int value)
    {
        this.value = value;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[value - 1];
    }
}
