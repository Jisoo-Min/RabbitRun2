using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFood: MonoBehaviour
{
    public static float foodSpeed = 5;
    public float outOfRangeX;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * foodSpeed * Time.deltaTime);

        if (this.transform.position.x < outOfRangeX)
        {
            Destroy(this.gameObject);
        }
    }

}