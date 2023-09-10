using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockDataSO", menuName = "ScriptableObject/BlockDataSO", order = 1)]
public class BlockDataSO : ScriptableObject
{
    public List<BlockData> blockDatas = new();

    [System.Serializable]
    public struct BlockData
    {
        public int id;
        public List<SpriteData> sprites;
    }
    [System.Serializable]
    public struct SpriteData
    {
        public Sprite spriteBlock;
    }

    public List<SpriteData> GetSpriteDatasById(int id)
    {
        if (blockDatas.Count == 0)
            return null;
        return blockDatas.FirstOrDefault(x => x.id == id).sprites;
    }
}
