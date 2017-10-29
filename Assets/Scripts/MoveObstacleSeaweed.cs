using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacleSeaweed : MonoBehaviour {

    public float seaweedSpeed;
    public float outOfRangeX;
    //float timeSpeed = 0f;
	// Use this for initialization
	void Start () {
 
	}

    // Update is called once per frame
    void Update() {
        //timeSpeed += Time.deltaTime;
        //if (timeSpeed > 2f)
        //{
        //    transform.position = new Vector3(6f, 0f, 0);
        //    timeSpeed = 0f;
        //}
        transform.Translate(Vector3.left * seaweedSpeed * Time.deltaTime);

        if (this.transform.position.x < outOfRangeX)
        {
             Destroy(this.gameObject);
            
        }
    }
    
}
