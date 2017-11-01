using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pausePannel;
    public GameObject pauseButton;
    public GameObject resultPannel;
    // Use this for initialization
    void Start()
    {
        pausePannel.SetActive(false);
        resultPannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        pausePannel.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        pausePannel.SetActive(false);
    }
}
