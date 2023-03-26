using System.Collections;
using System.Collections.Generic;
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
    [Header("変更前のスプライト")]
    Sprite _startSprites;

    [SerializeField]
    [Header("変更後の画像")]
    Sprite _changeSprite;

    [SerializeField]
    [Header("広告が変わるタイミングが一定ならfalse ランダムならtrue")]
    bool _changeRandom;

    [SerializeField]
    [Header("時間が減る場合 true 減らない場合　false")]
    bool _reduceTime;

    [SerializeField]
    [Header("ランダムの最小値、最大値を入れる")]
    int[] _randomCount = new int[2];

    [SerializeField]
    [Header("広告が表示されるまでの時間")]
    float _count;

    private void OnMouseDown()
    {
        _sprite.sprite = _changeSprite;

        if (_changeRandom && !_reduceTime)
        {
            _count = Random();
            StartCoroutine(ChangeSprite());
            Debug.Log(_count);
        }

        _reduceTime = true;   
    }

    IEnumerator ChangeSprite() 
    {
        while (true)
        {
            if (_reduceTime) _count -= Time.deltaTime;

            if (_count <= 0)
            {
                _reduceTime = false;
                _count = _randomCount[0];
                _sprite.sprite = _startSprites;
                break;
            }
            yield return null;
        }
    }

    public float Random()
    {
        _count = UnityEngine.Random.Range(_randomCount[0], _randomCount[1]);
        return _count;
    }

}
