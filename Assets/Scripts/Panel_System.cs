using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel_System : MonoBehaviour
{
    public GameObject _screen;

    public void Active_screen()
    {
        _screen.SetActive(true);
    }
    public void Exit_screen()
    {
        _screen.SetActive(false);
    }
}
