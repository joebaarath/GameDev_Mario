
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonController : MonoBehaviour, IInteractiveButton
{
    private bool isPaused = false;
    public Sprite pauseIcon;
    public Sprite playIcon;
    private Image image;
    GameObject pausePanelHolder;
    Transform pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        pausePanelHolder = GameObject.Find("PausePanelHolder");
        pausePanel = pausePanelHolder.transform.GetChild(0); // For the first child
        pausePanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseAllAudio()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Pause();
        }
    }

    // Function to resume all music and sounds
    public void ResumeAllAudio()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.UnPause();
        }
    }

    void TogglePanel()
    {
        bool currentState = pausePanel.gameObject.activeSelf;
        pausePanel.gameObject.SetActive(!currentState);
    }


    public void ButtonClick()
    {
        Time.timeScale = isPaused ? 1.0f : 0.0f;
        isPaused = !isPaused;
        TogglePanel();

        if (isPaused)
        {
            image.sprite = playIcon;
            PauseAllAudio();


        }
        else
        {
            image.sprite = pauseIcon;
            ResumeAllAudio();

        }
    }
}
