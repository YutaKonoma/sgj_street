using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonovihair<GameManager>
{
    Text _scoreText;
    Text _timeText;
    AudioSource _audio;
    [SerializeField] AudioClip _music;
    [SerializeField] float _startTime = 100f;
    float _time;
    float _score;
    public float score => _score;
    [SerializeField] GameObject _gameOver;
    int _level;
    public int level => _level;
    [SerializeField] string _sceneName;
    bool _gameStart;
    bool _gameend;

    protected override bool _dontDestroyOnLoad => true;
    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    void GameStart()
    {
        _scoreText = GameObject.FindGameObjectWithTag("Score")?.GetComponent<Text>();
        _timeText = GameObject.FindGameObjectWithTag("Time")?.GetComponent<Text>();

        _audio = this?.GetComponent<AudioSource>();

        _time = _startTime;
        _score = 0;
        if (_gameOver)
        {
            _gameOver.SetActive(false);
        }
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
            _gameStart = false;
            if (_gameOver)
            {
                _gameOver.SetActive(true);
            }
            if (!_gameend)
            {
                _gameend = true;
                SceneChangeController.LoadScene(_sceneName);
            }
        }
    }

    void ShowScoreText()
    {
        _scoreText.text = _score.ToString();
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
    }
    
    public void StartGame()
    {
        GameStart();
    }

    public void LevelUp()
    {
        _level++;
        if(_audio && _music)
        {
            _audio.clip = _music;
            _audio.Play();
        }
    }

    public void ResetLevel()
    {
        _level = 1;
    }
}
