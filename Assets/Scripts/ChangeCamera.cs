using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static AudioManager;

public class ChangeCamera : MonoBehaviour
{

    [SerializeField,Tooltip("�N���b�N�ňړ�����J����")] private List<CinemachineVirtualCamera> _virtualCameras;
    [SerializeField, Tooltip("�e�{�^��")] private List<GameObject> _changeCameraButtons;

    int _priorityNum = 11;
    int _drowNUm = 10;

    public void Awake()
    {
        _changeCameraButtons[0].SetActive(false);
    }

    public void RightButton()
    {
        _virtualCameras[1].Priority = _priorityNum;
        _virtualCameras[0].Priority = _drowNUm;
        AudioManager.Instance.PlaySE(SeSoundData.SE.ClickButton);
        _changeCameraButtons[0].SetActive(false);
        _changeCameraButtons[1].SetActive(true);
    }

    public void LeftButton()
    {
        _virtualCameras[0].Priority = _priorityNum;
        _virtualCameras[1].Priority = _drowNUm;
        AudioManager.Instance.PlaySE(SeSoundData.SE.ClickButton);
        _changeCameraButtons[0].SetActive(true);
        _changeCameraButtons[1].SetActive(false);
    }
}
