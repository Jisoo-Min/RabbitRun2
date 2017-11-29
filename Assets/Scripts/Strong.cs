using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Strong : MonoBehaviour {

    public GameObject spoon;

    // Use this for initialization
    void Start () {
        spoon.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (CharacterName.characterName.Equals("JiSoo"))
        {
            spoon.SetActive(true);
        }
        


    }
    void UpdateStrong(string tag)
    {
     //   transform.Rotate(Vector3(1, 0, 0) * speed * Time.deltaTime);
    }
    
}
