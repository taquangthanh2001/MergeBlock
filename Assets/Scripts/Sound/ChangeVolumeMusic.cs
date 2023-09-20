using UnityEngine;

public class ChangeVolumeMusic : MonoBehaviour
{
    protected static ChangeVolumeMusic instance;
    public static ChangeVolumeMusic Instance { get { return instance; } private set { instance = value; } }
    protected AudioSource musicAudio;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        musicAudio = GetComponent<AudioSource>();
    }
    public void ChangeVolume(float volume)
    {
        musicAudio.volume = volume;
    }

}
