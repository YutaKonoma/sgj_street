using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class AudioManager : SingletonMonovihair<AudioManager>
{
    [SerializeField] AudioSource _audioBgm;
    [SerializeField] AudioSource _audioSe;

    [SerializeField] List<BgmSoundData> _bgmSoundDatas;
    [SerializeField] List<SeSoundData> _seSoundDatas;

    [SerializeField]
    private float _masterVolume = 1;
    [SerializeField]
    private float _bgmMasterVolume = 1;
    [SerializeField]
    private float _seMasterVolume = 1;
    protected override bool _dontDestroyOnLoad => true;
    
    /// <summary>
    /// BGMを再生するようにする
    /// </summary>
    /// <param name="bgm">再生したいBGMを再生する</param>
    public void PlayBGM(BgmSoundData.BGM bgm)
    {
        BgmSoundData data = _bgmSoundDatas.Find(data => data._bgm == bgm);
        _audioBgm.clip = data._audioClip;
        _audioBgm.volume = data._volume * _bgmMasterVolume * _masterVolume;
        _audioBgm.Play();
    }

    /// <summary>
    /// SEを再生するようにする
    /// </summary>
    /// <param name="se">再生したいSEを再生する</param>
    public void PlaySE(SeSoundData.SE se)
    {
        SeSoundData data = _seSoundDatas.Find(data => data.Se == se);
        _audioSe.volume = data.Volume * _seMasterVolume * _masterVolume;
        _audioSe.PlayOneShot(data.AudioClip);
    }

    [System.Serializable]
    public class BgmSoundData
    {
        public enum BGM
        {
            Title,
            Game,
            fever,
            Result,
        }

        public BGM _bgm;
        public AudioClip _audioClip;
        [Range(0f, 1f)]
        public float _volume = 1f;
    }

    [System.Serializable]
    public class SeSoundData
    {
        public enum SE
        {
            Start,
            CountDown,
            End,
            fever,
            ClickButton,
            ClickPanel,
        }

        public SE Se;
        public AudioClip AudioClip;
        [Range(0,1)]
        public float Volume = 1;
    }
}
