using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{

    public static float obstacleSpeed = 5;
    public float outOfRangeX;
    //float timeSpeed = 0f;
    // Use this for initialization
    void Start()
    {
        this.transform.localScale = new Vector2(this.transform.localScale.x * 0.5f, this.transform.localScale.y * 0.5f);

    }
    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.left * obstacleSpeed * Time.deltaTime);

        if (this.transform.position.x < outOfRangeX)
        {
            Destroy(this.gameObject);

        }
    }
    void OnTriggerEnter2D(Collider2D item)   
    {
      // if(item.tag=="flag")
            this.transform.localScale = new Vector2(2f, 2f);
        
    }
}
