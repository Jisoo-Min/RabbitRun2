using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitCount : MonoBehaviour {

    private int Timer = 0;

    public GameObject WaitOnePanel;
    public GameObject WaitTwoPanel;
    public GameObject WaitThreePanel;
    
    // Use this for initialization
    void Start () {
        Timer = 0;

        WaitOnePanel.SetActive(false);
        WaitTwoPanel.SetActive(false);
        WaitThreePanel.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {

        //게임 시작시 정지
        if (Timer == 0)
        {
            Time.timeScale = 0.0f;
        }

        //Timer 가 90보다 작거나 같을경우 Timer 계속증가
        if (Timer <= 90)
        {
            Timer++;
            // Timer가 30보다 작을경우 3번켜기
            if (Timer < 30)
            {
                WaitThreePanel.SetActive(true);
            }
            // Timer가 30보다 클경우 3번끄고 2번켜기
            if (Timer > 30)
            {
                WaitThreePanel.SetActive(false);
                WaitTwoPanel.SetActive(true);
            }
            // Timer가 60보다 클경우 2번끄고 1번켜기
            if (Timer > 60)
            {
                WaitTwoPanel.SetActive(false);
                WaitOnePanel.SetActive(true);
            }
            //Timer 가 90보다 크거나 같을경우 1번끄고 게임시작하기. LoadingEnd () 코루틴호출 
            if (Timer >= 90)
            {
                WaitOnePanel.SetActive(false);
                StartCoroutine(this.LoadingEnd());
                Time.timeScale = 1.0f; //게임시작
            }
        }
    }

    IEnumerator LoadingEnd()
    {

        yield return new WaitForSeconds(1.0f);
    }

}
