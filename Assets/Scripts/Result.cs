using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [Tooltip("1.��Ԃ����@2.���ʁ@3.�Ⴂ�@4.��ԃ_���@���U���g�̃X�R�A")]
    [SerializeField]float[] _resultLevel = new float[4];

    /// <summary>�X�R�A</summary>
    [SerializeField]float _score;

    [Space]
    [Tooltip("�w�i�p�l��")]
    [SerializeField]Image _background;
    [Tooltip("�X�R�A�e�L�X�g")]
    [SerializeField]Text _scoreText;
    [Tooltip("1.��Ԃ����w�i�@2.���ʂ̔w�i�@3.�Ⴂ�w�i�@3.�_���Ȕw�i")]
    [SerializeField]Sprite[] _resultBackground = new Sprite[4];
    

    void Start()
    {
        AudioManager.Instance.PlayBGM(AudioManager.BgmSoundData.BGM.Result);
        //�Q�[���}�l�[�W���[����X�R�A���Ƃ�
        _score = GameManager.Instance.score;

        //�X�R�A�e�L�X�g���X�V
        _scoreText.text = $"{_score}";

        if(_score >= _resultLevel[0])
        {
            _background.sprite = _resultBackground[0];
        }//��Ԃ������U���g

        else if(_score >= _resultLevel[1])
        {
            _background.sprite = _resultBackground[1];
        }//���ʂ̃��U���g

        else if(_score >= _resultLevel[2])
        {
            _background.sprite = _resultBackground[2];
        }//�Ⴂ�Ƃ��̃��U���g

        else if(_score >= _resultLevel[3])
        {
            _background.sprite = _resultBackground[3];
        }//�_�����������̃��U���g
    }
}
