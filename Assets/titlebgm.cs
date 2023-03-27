using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titlebgm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayBGM(AudioManager.BgmSoundData.BGM.Title);
    }
}
