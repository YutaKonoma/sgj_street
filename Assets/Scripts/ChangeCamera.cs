using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> _virtualCameras;
    [SerializeField] private List<Button> _changeCameraButtons;

    int _priorityNum = 11;
    int _drowNUm = 10;

    public void RightButton()
    {
        _virtualCameras[0].Priority = _priorityNum;
        _virtualCameras[1].Priority = _drowNUm;
        Debug.Log($"Right");
    }

    public void LeftButton()
    {
        _virtualCameras[1].Priority = _priorityNum;
        _virtualCameras[0].Priority = _drowNUm;
    }
}
