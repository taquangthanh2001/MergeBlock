using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class MergeBlockCtrl : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> blocks = new();
    protected static MergeBlockCtrl instance;

    public LayerMask objectLayer;
    public float radius = 0.5f;
    public static MergeBlockCtrl Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public async void GetAllBlockToMerge(GameObject obj)
    {
        blocks.Add(obj);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(obj.transform.position, radius, objectLayer);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.name == "Block" &&
                    !blocks.Contains(collider.gameObject) &&
                     collider.gameObject.GetComponent<ChangeImageBlock>().value == blocks[0].GetComponent<ChangeImageBlock>().value)
            {
                GetAllBlockToMerge(collider.gameObject);
            }
        }
        await Task.Yield();
        MergeBlock();
    }

    protected async void MergeBlock()
    {
        var blockToMerge = blocks.FirstOrDefault();
        if (blocks.Count > 2)
        {
            blocks.Remove(blockToMerge);
            foreach (var a in blocks)
            {
                ClearBlockMerge(a.transform);
            }
            ChangeImageBlock upgradeImg = blockToMerge.GetComponent<ChangeImageBlock>();
            upgradeImg.SetSprite(upgradeImg.value + 1);
            var text = TextSpawner.Instance.SpawnWithPool(GameConst.Text, blockToMerge.transform.position);
            text.GetComponent<TextSpawned>().toe = 1f;
            int score = (upgradeImg.value - 1) * (blocks.Count + 1);
            text.GetComponent<TextSpawned>().AddPoint(score);
            HeaderPanel.Instance.AddScore(score);
            blocks.Clear();
            SoundManager.Instance.OnEffectMerger(blockToMerge.transform.position);
            if (upgradeImg.value > 5)
            {
                //MoveBlockMax(blockToMerge.transform);
                await Task.Delay(1000);
                ClearBlockMerge(blockToMerge.transform);
                return;
            }
            await Task.Delay(1000);
            GetAllBlockToMerge(blockToMerge);
        }
        else
            blocks.Clear();
    }

    protected async void MoveBlockMax(Transform tf)
    {
        Vector3 up = tf.position + Vector3.up;
        tf.position = Vector3.Lerp(tf.position, up, 1f);
        await Task.Delay(500);
        await Task.Yield();
        ClearBlockMerge(tf);
    }
    protected void ClearBlockMerge(Transform tf)
    {
        BlockSpawner.Instance.InsertToObjPool(tf);
        var g = ClickMoveBlock.Instance.GetBlockBgByBlock(tf.position);
        if (g != null)
            g.GetComponent<ChooseBgBlock>().isChoose = false;
    }
}
