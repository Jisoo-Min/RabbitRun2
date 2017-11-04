using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BumpIntoObstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D item)
    {
       if(item.gameObject.name == "rabbit")
        {
            iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.2, "y", 0.2, "time", 0.5f));
        }
    }
}
