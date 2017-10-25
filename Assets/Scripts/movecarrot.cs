using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecarrot : MonoBehaviour
{
    public float carrotSpeed;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * carrotSpeed * Time.deltaTime);

        if (this.transform.position.x < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnEnable()
    {
        if(transform.position.x>9)
        {
            transform.position = new Vector2(9,-2);
        }
    }

}