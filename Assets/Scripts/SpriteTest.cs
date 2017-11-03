using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTest : MonoBehaviour {

    public Sprite rabbit1;
    public Sprite rabbit2;

    Character ch;

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = rabbit1;
	}
	
	// Update is called once per frame
	void Update () {
       if(ch.score>500)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = rabbit2;
            return;
        }
       else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = rabbit1;
            return;
        }
     }
}
