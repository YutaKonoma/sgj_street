using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [Tooltip("1.一番いい　2.普通　3.低い　4.一番ダメ　リザルトのスコア")]
    [SerializeField]float[] _resultLevel = new float[4];

    /// <summary>スコア</summary>
    [SerializeField]float _score;

    [Space]
    [Tooltip("背景パネル")]
    [SerializeField]Image _background;
    [Tooltip("スコアテキスト")]
    [SerializeField]Text _scoreText;
    [Tooltip("1.一番いい背景　2.普通の背景　3.低い背景　3.ダメな背景")]
    [SerializeField]Sprite[] _resultBackground = new Sprite[4];
    

    void Start()
    {
        AudioManager.Instance.PlayBGM(AudioManager.BgmSoundData.BGM.Result);
        //ゲームマネージャーからスコアをとる
        _score = GameManager.Instance.score;

        //スコアテキストを更新
        _scoreText.text = $"{_score}";

        if(_score >= _resultLevel[0])
        {
            _background.sprite = _resultBackground[0];
        }//一番いいリザルト

        else if(_score >= _resultLevel[1])
        {
            _background.sprite = _resultBackground[1];
        }//普通のリザルト

        else if(_score >= _resultLevel[2])
        {
            _background.sprite = _resultBackground[2];
        }//低いときのリザルト

        else if(_score >= _resultLevel[3])
        {
            _background.sprite = _resultBackground[3];
        }//ダメだった時のリザルト
    }
}
