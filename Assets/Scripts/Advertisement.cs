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
    [Header("")]
    bool _reduceCount;

    [SerializeField]
    [Header("ランダムの最小値、最大値を入れる")]
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
