using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoodCorn : MonoBehaviour
{
    public float cornSpeed;
    public float outOfRangeX;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * cornSpeed * Time.deltaTime);

        if (this.transform.position.x < outOfRangeX)
        {
            Destroy(this.gameObject);
        }
    }

}