using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextBlink : MonoBehaviour {

    Text flashingText;
    
	void Start () {
        flashingText = GetComponent<Text>();
        StartBlinking();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    

    void StartBlinking()
    {
       
        StartCoroutine("Blink");
    }


    IEnumerator Blink()
    {
        while (true)
        {
            flashingText.text = " ";
            yield return new WaitForSeconds(0.5f);
            flashingText.text = "시작하려면 터치하세요.";
            yield return new WaitForSeconds(0.5f);
        }

    }

}