using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [Tooltip("�`�ȉ��̉��o")]
    [SerializeField]float _lowScore;
    [Tooltip("�`�ȏ�̉��o")]
    [SerializeField]float _hightScore;

    /// <summary>�X�R�A</summary>
    [SerializeField]float _score;

    [Space]
    [Tooltip("�w�i�p�l��")]
    [SerializeField]Image _background;
    [Tooltip("�X�R�A�e�L�X�g")]
    [SerializeField]Text _scoreText;
    [Tooltip("1.��Ԃ����w�i�@2.���ʂ̔w�i�@3.�_���Ȕw�i")]
    [SerializeField]Sprite[] _resultBackground;
    

    void Start()
    {
        //�Q�[���}�l�[�W���[����X�R�A���Ƃ�
        //_score = GameManager.Instance.score;

        //�X�R�A�e�L�X�g���X�V
        _scoreText.text = $"{_score}";

        if(_score >= _hightScore)
        {
            _background.sprite = _resultBackground[0];
        }//��Ԃ������U���g

        else if(_score >= _lowScore)
        {
            _background.sprite = _resultBackground[1];
        }//���ʂ̃��U���g

        else
        {
            _background.sprite = _resultBackground[2];
        }//�_�����������̃��U���g
    }
}
