using UnityEngine;

public class FunManager : MonoBehaviour
{
    [SerializeField] float[] _levelUpValues;
    [SerializeField] GameObject[] _humans;

    void Start()
    {
        GameManager.Instance.ResetLevel();
    }

    void Update()
    {
        CheckLevel(); 
    }

    void CheckLevel()
    {
        if(GameManager.Instance.level - 1 != _levelUpValues.Length &&
            GameManager.Instance.score >= _levelUpValues[GameManager.Instance.level - 1])
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        _humans[GameManager.Instance.level - 1].SetActive(false);
        GameManager.Instance.LevelUp();
        _humans[GameManager.Instance.level - 1].SetActive(true);
    }
}
