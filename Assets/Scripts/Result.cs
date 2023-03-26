using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [Tooltip("～以下の演出")]
    [SerializeField]float _lowScore;
    [Tooltip("～以上の演出")]
    [SerializeField]float _hightScore;

    /// <summary>スコア</summary>
    [SerializeField]float _score;

    [Space]
    [Tooltip("背景パネル")]
    [SerializeField]Image _background;
    [Tooltip("スコアテキスト")]
    [SerializeField]Text _scoreText;
    [Tooltip("1.一番いい背景　2.普通の背景　3.ダメな背景")]
    [SerializeField]Sprite[] _resultBackground;
    

    void Start()
    {
        //ゲームマネージャーからスコアをとる
        //_score = GameManager.Instance.score;

        //スコアテキストを更新
        _scoreText.text = $"{_score}";

        if(_score >= _hightScore)
        {
            _background.sprite = _resultBackground[0];
        }//一番いいリザルト

        else if(_score >= _lowScore)
        {
            _background.sprite = _resultBackground[1];
        }//普通のリザルト

        else
        {
            _background.sprite = _resultBackground[2];
        }//ダメだった時のリザルト
    }
}
