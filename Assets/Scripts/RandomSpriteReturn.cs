using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteReturn
{
    float _count;

    int[] _randomCount;

    public  float OnClick()
    {
        _count = Random.Range(_randomCount[0], _randomCount[1]);
        Debug.Log(_randomCount[0]);
        return _count;
    }
}
