using MergeBlock;
using UnityEngine;
using UnityEngine.UI;

public class BodyPanelGamePlay : UIScreen
{
    [SerializeField] protected Button btnNewGame;
    [SerializeField] protected Button btnSetting;

    private void Start()
    {
        btnNewGame.onClick.AddListener(OnClickNewGame);
        btnSetting.onClick.AddListener(OnClickSetting);
    }
    protected void OnClickNewGame()
    {
        SceneFlowManager.Instance.LoadScene(Scenes.GamePlay);
    }
    protected void OnClickSetting()
    {
        UIManager.Instance.ShowPopup("Prefabs/SettingGamePlay");
    }
}
