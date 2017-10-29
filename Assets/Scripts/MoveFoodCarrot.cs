using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoodCarrot : MonoBehaviour
{
    public float carrotSpeed;
    public float outOfRangeX;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * carrotSpeed * Time.deltaTime);

        if (this.transform.position.x < outOfRangeX)
        {
            Destroy(this.gameObject);
        }
    }

}