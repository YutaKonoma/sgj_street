using UnityEngine;

/// <summary>
/// 広告をクリックした際に呼ばれて、画像を変える
/// </summary>
public class Advertisement : MonoBehaviour
{
    [SerializeField] 
    [Header("広告のスプライト")]
    SpriteRenderer _sprite;

    [SerializeField]
    [Header("変更後の画像")]
    Sprite _changeSprite;

    private void OnMouseDown()
    {
        _sprite.sprite = _changeSprite;
    }
}
