using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonovihair<GameManager>
{
    Text _scoreText;
    Text _timeText;
    [SerializeField] float _startTime = 100f;
    float _time;
    float _score;
    public float score => _score;
    [SerializeField] GameObject _gameOver;
    [Header("3‚©‚çGo‚Ì‡‚É“ü‚ê‚Ä‚­‚¾‚³‚¢B")]
    [SerializeField] GameObject[] _countDownObject;
    int _level;
    public int level => _level;
    [SerializeField] string _sceneName;
    bool _gameStart;
    bool _gameend;

    protected override bool _dontDestroyOnLoad => true;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void GameStart()
    {
        _scoreText = GameObject.FindGameObjectWithTag("Score")?.GetComponent<Text>();
        _timeText = GameObject.FindGameObjectWithTag("Time")?.GetComponent<Text>();

        _time = _startTime;
        _score = 0;
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
            if (_timeText)
            {
                _timeText.text = string.Format("{0:00.00}", _time);
            }
            _time = Mathf.Max(_time - Time.deltaTime, 0f);
        }

        if(_time == 0f && !_gameend)
        {
            _gameStart = false;
            if (_gameOver)
            {
                _gameOver.SetActive(true);
            }
                _gameend = true;
            StartCoroutine(SceneChangeTime());
        }
    }

    void ShowScoreText()
    {
        if (_scoreText)
        {
            _scoreText.text = _score.ToString();
        }
    }

    public void AddScore(int score = 1)
    {
        if (_gameStart)
        {
            _score += score;
            ShowScoreText();
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        _time = _startTime;
        _gameend = false;
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
            }
            yield return new WaitForSeconds(1f);
            _gameStart = true;
            _countDownObject[_countDownObject.Length - 1].SetActive(false);
        }
    }

    public void LevelUp()
    {
        _level++;
    }

    public void ResetLevel()
    {
        _level = 1;
    }
}
