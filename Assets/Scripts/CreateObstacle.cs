using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour {
    public GameObject eelObj;
	// Use this for initialization
	void Start () {
        StartCoroutine(RRRR());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator RRRR()
    {
        while (true)
        {
            Instantiate(eelObj, transform.position, transform.rotation);

            yield return new WaitForSeconds(2.0f);
        }
    }



}
