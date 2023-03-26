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

    bool _gameStart;

    protected override bool _dontDestroyOnLoad { get { return true; } }
    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    void GameStart()
    {
        _scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        _timeText = GameObject.FindGameObjectWithTag("Time").GetComponent<Text>();
        _time = _startTime;
        _score = 0;
        _gameOver.SetActive(false);
        ShowScoreText();
        _gameStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameStart)
        {
            _timeText.text = string.Format("{0:00.00}", _time);
            _time = Mathf.Max(_time - Time.deltaTime, 0f);
        }

        if(_time == 0f)
        {
            _gameOver.SetActive(true);
        }
    }

    void ShowScoreText()
    {
        _scoreText.text = _score.ToString();
    }

    public void AddScore(int score = 1)
    {
        _score += score;
        ShowScoreText();
    }

    private void OnLevelWasLoaded(int level)
    {
        _time = _startTime;
    }
}
