using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームが終了した時にハイスコアが更新されているかチェックする
/// </summary>
public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    [Header("今回のスコア")]
    float _score;

    [SerializeField]
    [Header("ハイスコア")]
    float _highScore;

    [SerializeField]
    [Header("ハイスコアを表示するテキスト")]
    Text _highScoreText;

    /// <summary>
    /// ゲームが終了した時にリザルト画面で呼ばれる
    /// </summary>
    public void CheckHighScore()
    {
        _score = GameManager.Instance.score;

        if (_score > _highScore) _highScore = _score;

        _highScoreText.text = "ハイスコア" + _highScore;
    }
}
