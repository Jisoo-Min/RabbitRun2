using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject resultPanel;

    public GameObject wait1;
    public GameObject wait2;
    public GameObject wait3;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0;
        wait1.SetActive(true);
        new WaitForSeconds(1.0f);
        wait1.SetActive(false);
        wait2.SetActive(true);
        new WaitForSeconds(1.0f);
        wait2.SetActive(false);
        wait3.SetActive(true);
        new WaitForSeconds(1.0f);
        wait3.SetActive(false);
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        resultPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }


}
