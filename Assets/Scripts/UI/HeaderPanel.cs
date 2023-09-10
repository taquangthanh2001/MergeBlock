using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeaderPanel : MonoBehaviour
{
    protected static HeaderPanel instance;
    public static HeaderPanel Instance { get { return instance; } }

    protected UserData userData;
    protected DataGamePlay dataGamePlay;

    [SerializeField] protected Transform blockSuggests;
    [SerializeField] protected Transform blockImg;
    [SerializeField] protected BlockDataSO blockDataSO;

    [SerializeField] protected TextMeshProUGUI scoreInGame;
    [SerializeField] protected TextMeshProUGUI hightScore;

    protected int score;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        dataGamePlay = Commons.GetDataGamePlay();
        userData = Commons.GetUserData();
        LoadBlocksSugget();
        SetScoreTxt(0, dataGamePlay.HightScore);
    }
    internal void AddScore(int score)
    {
        this.score += score;
        dataGamePlay.HightScore = dataGamePlay.HightScore < this.score ? this.score : dataGamePlay.HightScore;
        SetScoreTxt(this.score, dataGamePlay.HightScore);
        Commons.SetGamePlayData(dataGamePlay);
    }
    protected void SetScoreTxt(int score, int hightScore)
    {
        scoreInGame.text = $"Score: {score}";
        this.hightScore.text = $"HightScore: {hightScore}";
    }
    protected void LoadBlocksSugget()
    {
        var blocks = blockDataSO.GetSpriteDatasById(userData.Id);
        foreach (var block in blocks)
        {
            var blockimg = Instantiate(blockImg);
            blockimg.SetParent(blockSuggests);
            blockimg.GetComponent<Image>().sprite = block.spriteBlock;
        }
    }
}

