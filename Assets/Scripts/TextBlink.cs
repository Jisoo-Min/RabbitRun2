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
            flashingText.text = "efsfsdfsdfsdFewf ";
            yield return new WaitForSeconds(.5f);
            flashingText.text = "asdfasdf ";
            yield return new WaitForSeconds(.5f);
        }

    }

}