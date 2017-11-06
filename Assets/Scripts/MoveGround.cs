using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour {

    public static float groundSpeed = 5;
    public float outOfRangeX;
    //float timeSpeed = 0f;
	// Use this for initialization
	void Start () {
 
	}

    void Update() {

        transform.Translate(Vector3.left * groundSpeed * Time.deltaTime);

        if (this.transform.position.x < outOfRangeX)
        {
             Destroy(this.gameObject);
            
        }
    }

}
