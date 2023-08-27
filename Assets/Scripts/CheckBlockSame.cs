using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckBlockSame : MonoBehaviour
{
    public LayerMask objectLayer;
    public float radius = 0.5f;
    private bool isChecked = false;

    public void Check(List<GameObject> b)
    {

        b ??= new();
        b.Add(this.gameObject);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, objectLayer);
        bool isCheck = false;
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                if (collider.gameObject.name == "Block" && !b.Contains(collider.gameObject))
                {
                    collider.gameObject.GetComponent<CheckBlockSame>().Check(b);
                    isCheck = true;
                }
            }
        }
        if (isCheck)
        {
            return;
        }
        if (b.Count > 2)
        {
            var c = b.FirstOrDefault();
            b.Remove(c);
            foreach (var a in b)
            {
                //a.GetComponent<CheckBlockSame>().MergeBlock(a.transform, c.transform.position);
                BlockSpawner.Instance.InsertToObjPool(a.transform);
                //var g = ClickMoveBlock.Instance.Test2(a.transform.position);
                //if (g != null)
                //    g.GetComponent<ChooseBgBlock>().isChoose = false;
            }
        }

    }

    protected void MergeBlock(Transform tf, Vector2 target)
    {
        //tf.position = Vector2.Lerp(tf.position, target, 0.1f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
