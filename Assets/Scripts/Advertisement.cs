using System.Collections;
using UnityEngine;

/// <summary>
/// 広告をクリックした際に呼ばれて、画像を変える
/// </summary>
public class Advertisement : MonoBehaviour
{
    [SerializeField]
    [Header("このスクリプトがついている広告のスプライトレンダラー")]
    SpriteRenderer _sprite;

    [SerializeField]
    [Header("変更前(クリック前)の画像")]
    Sprite _startSprites;

    [SerializeField]
    [Header("推しアイドルの画像")]
    Sprite _favoriteIdoleSprite;

    [SerializeField]
    [Header("他のアイドルの画像")]
    Sprite _otherIdolSprite;

    [SerializeField]
    [Header("クリック時のパーティクル 非表示にしておく")]
    GameObject _particle;

    [SerializeField]
    [Header("時間が減る場合 true 減らない場合　false")]
    bool _decreaseTime　= false;

    [SerializeField]
    [Header("ランダムの最小値、最大値を入れる")]
    [Header("フィーバー状態に入ると最大値がElement2に変わる")]
    int[] _randomCount = new int[3];

    [SerializeField]
    [Header("広告が再度表示されるまでの時間")]
    float _count;

    void OnMouseDown()
    {
        if (!_decreaseTime && GameManager.Instance.gameStart && !GameManager.Instance.gameEnd)
        {
            _sprite.sprite = _favoriteIdoleSprite;
            GameManager.Instance.AddScore();
            _particle.SetActive(true);
            _count = Random();
            StartCoroutine(ChangeSprite());  
        }

        _decreaseTime = true;
    }

    IEnumerator ChangeSprite()
    {
        while (true)
        {
            if (_decreaseTime) _count -= Time.deltaTime;

            if (_count <= 0)
            {
                _particle.SetActive(false);
                _decreaseTime = false;

                if (!GameManager.Instance.feverTime) _sprite.sprite = _startSprites;
                else _sprite.sprite = _otherIdolSprite;

                break;
            }
            yield return null;
        }
    }

    float Random()
    {
        if (!GameManager.Instance.feverTime)
        {
            _count = UnityEngine.Random.Range(_randomCount[0], _randomCount[1]);
            return _count;
        }
        else
        {
            _count = UnityEngine.Random.Range(_randomCount[0], _randomCount[2]);
            return _count;
        }

    }
}
