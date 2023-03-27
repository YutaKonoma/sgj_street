using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonovihair<GameManager>
{
    Text _scoreText;
    Text _levelText;
    //Text _timeText;
    //Slider _timeSlider;
    Image _timerObj;
    [Header("電池最大から0までの順に入れる。")]
    [SerializeField] Sprite[] _timerSprites; 
    [SerializeField] float _startTime = 100f;
    float _time;
    [Header("デバック用です。基本0にしておいてください。")]
    [SerializeField] float _startScore = 0f;
    float _score;
    public float score => _score;
    [SerializeField] GameObject _canvasParent;
    [SerializeField] GameObject _countUp;
    [SerializeField] GameObject _countUpPos;
    [SerializeField] GameObject _gameOver;
    [SerializeField] GameObject _feverTimeObj;
    [SerializeField] GameObject _levelUpPos;
    [SerializeField] GameObject _levelUpObj;
    [Header("3からGoの順に入れてください。")]
    [SerializeField] GameObject[] _countDownObject;
    int _level;
    public int level => _level;
    [SerializeField] string _sceneName;
    [Tooltip("true時、ゲームスタート(ゲーム中)")]
    bool _gameStart;
    public bool gameStart => _gameStart;
    [Tooltip("true時、ゲームエンド(ゲーム終わり)")]
    bool _gameEnd;
    public bool gameEnd => _gameEnd;
    [Tooltip("true時、フィーバータイム")]
    bool _feverTime;
    public bool feverTime => _feverTime;
    bool _oneTimer;
    bool _twoTimer;
    bool _maxbool;

    protected override bool _dontDestroyOnLoad => true;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void GameStart()
    {
        _scoreText = GameObject.FindGameObjectWithTag("Score")?.GetComponent<Text>();
        _timerObj = GameObject.FindGameObjectWithTag("Time")?.GetComponent<Image>();
        _levelText = GameObject.FindGameObjectWithTag("Level")?.GetComponent<Text>();
        //_timeText = GameObject.FindGameObjectWithTag("Time")?.GetComponent<Text>();
        //_timeSlider = GameObject.FindGameObjectWithTag("Time")?.GetComponent<Slider>();
        AudioManager.Instance.PlayBGM(AudioManager.BgmSoundData.BGM.Game);
        _time = _startTime;
        _score = _startScore;
        if (_gameOver)
        {
            _gameOver.SetActive(false);
        }
        ShowScoreText();
        StartCoroutine(CountDownTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameStart)
        {
            //if (_timeText)
            //{
            //    _timeText.text = string.Format("{0:00.00}", _time);
            //}
            //if(_timeSlider)
            //{
            //    _timeSlider.value = _time / _startTime; 
            //}
            if (_timerObj && _timerSprites.Length >= 3)
            {
                if(_time / _startTime < 0.3f && !_twoTimer)
                {
                    _twoTimer = true;
                    _timerObj.sprite = _timerSprites[_timerSprites.Length - 2];
                    _feverTime = true;
                    AudioManager.Instance.PlaySE(AudioManager.SeSoundData.SE.fever);
                    AudioManager.Instance.PlayBGM(AudioManager.BgmSoundData.BGM.fever);
                    StartCoroutine(FeverTextTime());
                }
                else if(_time / _startTime < 0.6f && !_oneTimer)
                {
                    _oneTimer = true;
                    _timerObj.sprite = _timerSprites[_timerSprites.Length - 3];
                }
            }


            _time = Mathf.Max(_time - Time.deltaTime, 0f);
        }

        if(_time == 0f && !_gameEnd)
        {
            _gameStart = false;
            if(_timerObj)
            {
                _timerObj.sprite = _timerSprites[_timerSprites.Length - 1];
            }
            if (_gameOver)
            {
                _gameOver.SetActive(true);
            }
            AudioManager.Instance.PlaySE(AudioManager.SeSoundData.SE.End);
            _gameEnd = true;
            StartCoroutine(SceneChangeTime());
        }
    }

    void ShowScoreText()
    {
        if (_scoreText && _score < 120)
        {
            _scoreText.text = _score.ToString();
        }
    }

    void ShowLevelText()
    {
        if (_levelText)
        {
            if(_level < 4)
            {
                _levelText.text = "LEVEL" + _level;
            }
            else if (_level == 4 && !_maxbool)
            {
                _maxbool = true;
                _levelText.text = "MAXLEVEL!!!";
                _levelText.color = Color.red;
            }
        }
    }

    public void AddScore(int score = 1)
    {
        if (_gameStart && !gameEnd)
        {
            _score = Mathf.Min(_score + score,120);
            ShowScoreText();
            if (_countUp && _countUpPos && _canvasParent)
            {
                var obj = Instantiate(_countUp, _countUpPos.transform.position, Quaternion.identity);
                obj.transform.parent = _canvasParent.transform;
                Destroy(obj, 2.0f);
            }
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        _time = _startTime;
        _gameEnd = false;
        _feverTime = false;
        if (_gameOver)
        {
            _gameOver.SetActive(false);
        }
    }

    IEnumerator SceneChangeTime()
    {
        yield return new WaitForSeconds(2f);
        SceneChangeController.LoadScene(_sceneName);
    }

    IEnumerator CountDownTime()
    {
        if (_countDownObject.Length > 1)
        {
            _countDownObject[0].SetActive(true);
            for (var i = 1; i < _countDownObject.Length; i++)
            {
                yield return new WaitForSeconds(1f);
                _countDownObject[i].SetActive(true);
                _countDownObject[i - 1].SetActive(false);
                AudioManager.Instance.PlaySE(AudioManager.SeSoundData.SE.CountDown);
            }
            yield return new WaitForSeconds(1f);
            _gameStart = true;
            _countDownObject[_countDownObject.Length - 1].SetActive(false);
            AudioManager.Instance.PlaySE(AudioManager.SeSoundData.SE.Start);
        }
    }

    IEnumerator FeverTextTime()
    {
        if (_feverTimeObj)
        {
            _feverTimeObj.SetActive(true);
            yield return new WaitForSeconds(2f);
            _feverTimeObj.SetActive(false);
        }

    }

    public void LevelUp()
    {
        _level++;
        ShowLevelText();
        if (_levelUpObj && _levelUpPos)
        {
            var obj = Instantiate(_levelUpObj, _levelUpPos.transform.position, Quaternion.identity);
            obj.transform.parent = _canvasParent.transform;
            Destroy(obj, 2.0f);
        }
    }

    public void ResetLevel()
    {
        _level = 1;
        ShowLevelText();
    }
}
