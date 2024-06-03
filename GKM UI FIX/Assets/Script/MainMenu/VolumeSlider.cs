using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    [Header("----- Audio Source -----")]
    [SerializeField] AudioSource _bgmSound;
    [SerializeField] AudioSource _sfxSound;

    [Header("----- Audio Clip -----")]
    [SerializeField] AudioClip _sfxClip;
    [SerializeField] AudioClip _bgmClip;

    [SerializeField] private AudioMixer _mixer;

    public static VolumeSlider instance;

    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _bgmSound.clip = _bgmClip;
        _bgmSound.Play();
        if (!PlayerPrefs.HasKey("bgmVolume"))
        {
            PlayerPrefs.SetFloat("bgmVolume", 1);
            Load();
        }
        else if(!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangebgmVolume()
    {
        float volume = bgmSlider.value;
        _mixer.SetFloat("_bgm", Mathf.Log10(volume) * 20);
        Save();
    }

    public void ChangesfxVolume()
    {
        float volume = sfxSlider.value;
        _mixer.SetFloat("_sfx", Mathf.Log10(volume)*20);
        Save();
    }

    private void Load()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("bgmVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("bgmVolume", bgmSlider.value);
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
    }
}
