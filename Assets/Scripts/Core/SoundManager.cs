using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioClip _effectMerger;
    [SerializeField] private AudioClip _effectCombo;

    public float volume = 10f;

    //bool _vibrate = true;
    public static SoundManager Instance { get { return _instance; } }

    private static SoundManager _instance;
    private void Awake()
    {
        _instance = this;
        if (AudioManager.IsMusicEnable)
            music.Play();
        else
            music.Stop();
    }
    public void OnClickSound(Vector3 pos)
    {
        if (!AudioManager.IsSoundEnable || _clickSound == null)
            return;
        AudioSource.PlayClipAtPoint(_clickSound, pos, volume);
    }
    public void OnEffectMerger(Vector3 pos)
    {
        AudioSource.PlayClipAtPoint(_effectMerger, pos, volume);
    }
    public void OnSoundCombo(Vector3 pos)
    {
        AudioSource.PlayClipAtPoint(_effectCombo, pos, volume);
    }

    public bool OnSetupBackgroundMusic()
    {

        if (AudioManager.IsMusicEnable)
        {
            music.Stop();
            AudioManager.IsMusicEnable = false;
        }
        else
        {
            music.Play();
            AudioManager.IsMusicEnable = true;
        }
        return AudioManager.IsMusicEnable;
    }
    public bool OnSetupSound()
    {

        if (AudioManager.IsSoundEnable)
        {
            volume = 0f;
            AudioManager.IsSoundEnable = false;
        }
        else
        {
            volume = 10f;
            AudioManager.IsSoundEnable = true;
        }
        return AudioManager.IsSoundEnable;
    }
}
