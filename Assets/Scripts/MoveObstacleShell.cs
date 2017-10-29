using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacleShell : MonoBehaviour {

    public float shellSpeed;
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
        transform.Translate(Vector3.left * shellSpeed * Time.deltaTime);

        if (this.transform.position.x < outOfRangeX)
        {
             Destroy(this.gameObject);
            
        }
    }

    void OnEnable() //start함수보다 먼저 선언되는 메서드 객체 초기화시켜주는 메서드
    {
      
    }
}
