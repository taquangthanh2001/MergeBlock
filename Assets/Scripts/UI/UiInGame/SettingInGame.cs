using MergeBlock;
using UnityEngine;
using UnityEngine.UI;

public class SettingInGame : UIScreen
{
    [SerializeField] protected Slider musicSlide;
    [SerializeField] protected Button btnClose;
    protected float value;

    private void Start()
    {
        musicSlide.onValueChanged.AddListener(delegate { ChangeValueMusic(); });
        btnClose.onClick.AddListener(OnClickHidePopup);
    }
    protected void ChangeValueMusic()
    {
        ChangeVolumeMusic.Instance.ChangeVolume(musicSlide.value);
    }
    protected void OnClickHidePopup()
    {
        UIManager.Instance.HidePopup();
    }
}
