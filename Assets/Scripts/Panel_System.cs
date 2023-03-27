using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AudioManager.SeSoundData;
using static AudioManager;

public class Panel_System : MonoBehaviour
{
    public GameObject _screen;

    public void Active_screen()
    {
        _screen.SetActive(true);
        AudioManager.Instance.PlaySE(SeSoundData.SE.ClickButton);
    }
    public void Exit_screen()
    {
        _screen.SetActive(false);
        AudioManager.Instance.PlaySE(SeSoundData.SE.ClickButton);
    }
}
