using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource _bgMusicSrc;
    [SerializeField] private AudioSource _sfxSrc;

    [SerializeField] private AudioClip[] _bgMusics;
    [SerializeField] private AudioClip[] _sfxClips;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        PegarVolumeBGSalvo();
        PegarVolumeSFXSalvo();
    }

    public void TocarBGMusic(int idBgMusic)
    {
        AudioClip clip = _bgMusics[idBgMusic];
        _bgMusicSrc.Stop();
        _bgMusicSrc.clip = clip;
        _bgMusicSrc.loop = true;
        _bgMusicSrc.Play();

    }
    public void TocarSFX(int idSfx)
    {
        AudioClip clip = _sfxClips[idSfx];
        _sfxSrc.PlayOneShot(clip);
    }
    public void MuteSFX(bool option)
    {
        _sfxSrc.mute = option;
    }
    public void MuteBG(bool option)
    {
        _bgMusicSrc.mute = option;
    }
    public void AtualizarVolumeSFX(float valor)
    {
        _sfxSrc.volume = valor/10;
        SalvarVolumeSFX();
    }
    public void AtualizarVolumeBG(float valor)
    {
        _bgMusicSrc.volume = valor/10;
        SalvarVolumeBG();
    }
    public void SalvarVolumeBG()
    {
        PlayerPrefs.SetFloat("VolumeBG", _bgMusicSrc.volume);

    }
    public void SalvarVolumeSFX()
    {
        PlayerPrefs.SetFloat("VolumeSFX", _sfxSrc.volume);
    }
    public float PegarVolumeBGSalvo()
    {
        float volume = PlayerPrefs.GetFloat("VolumeBG", 0.5f);
        _bgMusicSrc.volume = volume;
        return volume;
    }
    public float PegarVolumeSFXSalvo()
    {
        float volume = PlayerPrefs.GetFloat("VolumeSFX", 0.5f);
        _sfxSrc.volume = volume;
        return volume;
    }
}
