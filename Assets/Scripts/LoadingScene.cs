using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public CanvasGroup c;

    public GameObject highscoreText;
    public IntVariable gameScore;

    // Start is called before the first frame update
    void Start()
    {
        SetHighscore();
        StartCoroutine(Fade());
    }

    public void SetHighscore()
    {
        highscoreText.GetComponent<TextMeshProUGUI>().text = "TOP- " + gameScore.previousHighestValue.ToString("D6");
    }

    IEnumerator Fade()
    {
        for (float alpha =1f; alpha >= -0.05f; alpha -= 0.05f)
        {
            c.alpha = alpha;
            yield return new WaitForSecondsRealtime(0.1f);
        }

        //Once done, go to next Scene
        SceneManager.LoadSceneAsync("World 1-1", LoadSceneMode.Single);
    }

    public void ReturnToMain()
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
