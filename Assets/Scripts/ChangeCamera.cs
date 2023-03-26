using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class ChangeCamera : MonoBehaviour
{

    [SerializeField,Tooltip("クリックで移動するカメラ")] private List<CinemachineVirtualCamera> _virtualCameras;
    [SerializeField, Tooltip("各ボタン")] private List<GameObject> _changeCameraButtons;

    int _priorityNum = 11;
    int _drowNUm = 10;

    public void Awake()
    {
        
        _changeCameraButtons[1].SetActive(false);
    }

    public void RightButton()
    {
        _virtualCameras[1].Priority = _priorityNum;
        _virtualCameras[0].Priority = _drowNUm;
        _changeCameraButtons[0].SetActive(false);
        _changeCameraButtons[1].SetActive(true);
    }

    public void LeftButton()
    {
        _virtualCameras[0].Priority = _priorityNum;
        _virtualCameras[1].Priority = _drowNUm;
        _changeCameraButtons[0].SetActive(true);
        _changeCameraButtons[1].SetActive(false);
    }
}
