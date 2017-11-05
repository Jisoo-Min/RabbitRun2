using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour {

    public float speed;
    public float outOfRangeX;
    //float timeSpeed = 0f;
	// Use this for initialization
	void Start () {
 
	}

    // Update is called once per frame
    void Update() {
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (this.transform.position.x < outOfRangeX)
        {
             Destroy(this.gameObject);
            
        }
    }
    
}
