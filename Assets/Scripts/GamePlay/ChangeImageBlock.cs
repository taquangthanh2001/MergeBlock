using System.Collections.Generic;
using UnityEngine;

public class ChangeImageBlock : MonoBehaviour
{
    public float radius = 0.5f;
    internal int value = 1;
    protected List<Sprite> sprites = new();
    [SerializeField] protected BlockDataSO blockDataSO;
    protected UserData userData;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public void SetSprite(int value)
    {
        SetSprites();
        this.value = value;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[value - 1];
    }
    protected void SetSprites()
    {
        userData = Commons.GetUserData();
        var blocks = blockDataSO.GetSpriteDatasById(userData.Id);
        foreach (var block in blocks)
        {
            sprites.Add(block.spriteBlock);
        }
    }
}
