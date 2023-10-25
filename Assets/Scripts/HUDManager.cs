using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    private Vector3[] scoreTextPosition = {
        new Vector3(-747, 473, 0),
        new Vector3(0, 0, 0)
        };
    private Vector3[] restartButtonPosition = {
        new Vector3(844, 455, 0),
        new Vector3(0, -150, 0)
    };

    public GameObject inGamePanel;
    public GameObject inGameScoreText;
    //public Transform gameOverRestartButton;
    public GameObject gameOverPanel;
    public GameObject gameOverScoreText;

    public GameObject highscoreText;
    public IntVariable gameScore;

    void Awake()
    {
        // subscribe to events
        GameManager.instance.gameStart.AddListener(GameStart);
        GameManager.instance.gameOver.AddListener(GameOver);
        GameManager.instance.gameRestart.AddListener(GameStart);
        GameManager.instance.scoreChange.AddListener(SetScore);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        // hide gameover panel
        gameOverPanel.SetActive(false);
        inGamePanel.SetActive(true);
        //scoreText.transform.localPosition = scoreTextPosition[0];
        //gameOverRestartButton.localPosition = restartButtonPosition[0];
    }

    public void SetScore(int score)
    {
        string scoreText = "Score: " + score.ToString();
        inGameScoreText.GetComponent<TextMeshProUGUI>().text = scoreText;
        gameOverScoreText.GetComponent<TextMeshProUGUI>().text = scoreText;
    }


    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        inGamePanel.SetActive(false);
        //scoreText.transform.localPosition = scoreTextPosition[1];
        //gameOverRestartButton.localPosition = restartButtonPosition[1];

        // set highscore
        highscoreText.GetComponent<TextMeshProUGUI>().text = "TOP- " + gameScore.previousHighestValue.ToString("D6");
        // show
        highscoreText.SetActive(true);
    }
}
