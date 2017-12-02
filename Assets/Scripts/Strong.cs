using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Strong : MonoBehaviour {

    public GameObject spoon;
    public int angle = 0;

    // Use this for initialization
    void Start () {
        spoon.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (CharacterName.characterName.Equals("JiSoo"))
        {
            spoon.SetActive(true);
            UpdateStrong();
        }

    }
    void UpdateStrong()
    {
        angle += 100;
        spoon.transform.localRotation = Quaternion.Euler(0f, 0f, angle);
        //transform.localEulerAngles = new Vector3(10, 0, 0);

    }
    
}
