using UnityEngine;

/// <summary>
/// �L�����N���b�N�����ۂɌĂ΂�āA�摜��ς���
/// </summary>
public class Advertisement : MonoBehaviour
{
    [SerializeField] 
    [Header("�L���̃X�v���C�g")]
    SpriteRenderer _sprite;

    [SerializeField]
    [Header("�ύX�O�̃X�v���C�g")]
    Sprite _startSprites;

    [SerializeField]
    [Header("�ύX��̉摜")]
    Sprite _changeSprite;

    [SerializeField]
    [Header("�L�����ς��^�C�~���O�����Ȃ�false �����_���Ȃ�true")]
    bool _changeRandom;

    [SerializeField]
    [Header("")]
    bool _reduceCount;

    [SerializeField]
    [Header("�����_���̍ŏ��l�A�ő�l������")]
    int[] _randomCount;

    [SerializeField]
    float _count;

    private void OnMouseDown()
    {
        _sprite.sprite = _changeSprite;
       
        if(_changeRandom)
        {
            _count = Random();
            Debug.Log(_count);
        }
        _reduceCount = true;
    }

    private void FixedUpdate()
    {
        if (_reduceCount) 
        {
            _count -= Time.deltaTime;
        } 

        if(_count <= 0)
        {
            _reduceCount = false;
            _count = _randomCount[0];
            _sprite.sprite = _startSprites;
        }
    }
    
    public float Random()
    {
        _count = UnityEngine.Random.Range(_randomCount[0], _randomCount[1]);
        return _count;
    }

}
