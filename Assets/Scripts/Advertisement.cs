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
    [Header("�ύX��̉摜")]
    Sprite _changeSprite;

    private void OnMouseDown()
    {
        _sprite.sprite = _changeSprite;
    }
}
