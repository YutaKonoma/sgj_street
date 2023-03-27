using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �Q�[�����I���������Ƀn�C�X�R�A���X�V����Ă��邩�`�F�b�N����
/// </summary>
public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    [Header("����̃X�R�A")]
    float _score;

    [SerializeField]
    [Header("�n�C�X�R�A")]
    float _highScore;

    [SerializeField]
    [Header("�n�C�X�R�A��\������e�L�X�g")]
    Text _highScoreText;

    /// <summary>
    /// �Q�[�����I���������Ƀ��U���g��ʂŌĂ΂��
    /// </summary>
    public void CheckHighScore()
    {
        _score = GameManager.Instance.score;

        if (_score > _highScore) _highScore = _score;

        _highScoreText.text = "�n�C�X�R�A" + _highScore;
    }
}
