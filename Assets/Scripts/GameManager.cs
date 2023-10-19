using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // events
    public UnityEvent gameStart;
    public UnityEvent gameRestart;
    public UnityEvent<int> scoreChange;
    public UnityEvent gameOver;
    public UnityEvent marioValidStomp;

    private int score = 0;
    private OneWayBounceBox[] allBoxes;  // Array to store all OneWayBounceBox instances

    public delegate void MarioStompDelegate();
    public MarioStompDelegate OnMarioValidStompNotifier;  // Any external class can invoke this.

    void Start()
    {
        gameStart.Invoke();
        Time.timeScale = 1.0f;

        // subscribe to scene manager scene change
        SceneManager.activeSceneChanged += SceneSetup;

        // Get all instances of OneWayBounceBox in the scene
        allBoxes = FindObjectsOfType<OneWayBounceBox>();

    }

    public void SceneSetup(Scene current, Scene next)
    {
        gameStart.Invoke();
        SetScore(score);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameRestart()
    {
        // reset score
        score = 0;
        SetScore(score);
        gameRestart.Invoke();
        Time.timeScale = 1.0f;

        // Reset all qboxes and coin positions
        if(allBoxes != null)
        {
            foreach (var box in allBoxes)
            {
                box.ResetBox();
            }

        }

    }

    public void IncreaseScore(int increment)
    {
        score += increment;
        SetScore(score);
        // use delegates to access playmermovements
    }

    public void ValidMarioStompChange()
    {
        if (OnMarioValidStompNotifier != null)
        {
            OnMarioValidStompNotifier(); // will trigger PlayerMovement to not allow mario to die 
        }
    }

    public void SetScore(int score)
    {
        scoreChange.Invoke(score);
    }


    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOver.Invoke();
    }
}