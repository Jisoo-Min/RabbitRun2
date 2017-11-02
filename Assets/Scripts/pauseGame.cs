﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject resultPanel;
    
    // Use this for initialization
    void Start()
    {

        pausePanel.SetActive(false); //해당 Panel을 활성화
        resultPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        Time.timeScale = 0; //화면정지
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1; //화면 정지 해제
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }


}
