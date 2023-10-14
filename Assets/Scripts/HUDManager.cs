using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : Singleton<HUDManager>
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
    }
}
