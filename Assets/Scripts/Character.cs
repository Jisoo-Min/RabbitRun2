using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour
{

    private float jump = 8;
    public float health = 100;
    private int jumpNumber;
    public int slideNumber=0;
    private bool isOnground;

 
    public static bool checkClick = false;
  
    public static Character character;

    public Sprite rabbit1;
    public Sprite rabbit2;

    void Start()
    {
        character = this;
      
    }

    void OnTriggerEnter2D(Collider2D item)   // 당근을 먹었을 때
    {
        if (item.tag == "carrot") //기본먹이
        {
            Destroy(item.gameObject);
            GameManager.manager.AddScore(100);
           
        }
        else if(item.tag == "coin")
        {
            Destroy(item.gameObject);
            GameManager.manager.AddCoin(1);
            
        }
        else if (item.tag == "broccoli") //크기증가먹이
        {
            Destroy(item.gameObject);
            GameManager.manager.AddScore(200);
            Character.character.transform.localScale = new Vector2(0.4f,0.4f);
            Invoke("SetNormal", 3);
        }
        else if (item.tag =="corn") //크기감소먹이
        {
            Destroy(item.gameObject);
            GameManager.manager.AddScore(30);
            transform.localScale = new Vector2(0.2f, 0.15f);
            Invoke("SetNormal", 3);
        }
        else if(item.tag =="clover")//속도 증가먹이
        {
            GameManager.manager.AddScore(200);
            Destroy(item.gameObject);

            MoveFood.foodSpeed = 10;
            MoveObstacle.obstacleSpeed = 10;
            MoveGround.groundSpeed = 10;
            Invoke("SetNormal", 3);
            
        }

        if((item.tag =="eel") || (item.tag=="crab") || (item.tag == "seashell") || (item.tag == "seaweed") || (item.tag == "hook") || (item.tag == "red_fish") || (item.tag == "yellow_fish") || (item.tag == "blue_fish") || (item.tag == "octopus"))
        {
            iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.2, "y", 0.2, "time", 0.1f));
            health = health - 20.0f;
        }

    }

    void SetNormal()
    {
        MoveFood.foodSpeed = 5;
        MoveObstacle.obstacleSpeed = 5;
        MoveGround.groundSpeed = 5;
        transform.localScale = new Vector2(0.3f, 0.26f);


    }
    void OnCollisionEnter2D(Collision2D collision) //접촉했을때
    {
        jumpNumber = 0;
        isOnground = true;

        if(collision.gameObject.name == "deadline" || collision.gameObject.name=="turtle" )//죽는 라인에 충돌할 경우 게임 중지 
        {
            GameManager.manager.GameOver();            
        }
    }

    void OnCollisionExit2D() //접촉하지 않았을때
    {
        isOnground = false;
    }

    public void IsClick()             //화면의 오른쪽 클릭
    {
        checkClick = true;
    }

    public void PointerDown()      //slideButton 클릭했을때
    {
        GetComponent<SpriteRenderer>().sprite = rabbit2;
    }
    public void PointerUp()           //slideButton 클릭을 안했을때
    {
        GetComponent<SpriteRenderer>().sprite = rabbit1;
    }

    void Update()
    {
        
        if (GameManager.manager.end == false) //end가 false 일 경우만 점프가능
        {
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

            

            if (checkClick == true) // 화면이 클릭되었을때
            {
                ++jumpNumber;
                Debug.Log(jumpNumber);

                if (isOnground == true) //땅에 있을때
                {

                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump);

                }

                else if (isOnground == false) //점프중일때
                {
                    if (jumpNumber <= 2)
                        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump);


                    if (jumpNumber > 2) //점프횟수가 2번이 넘었을때
                    {
                        //rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);

                        rigidbody.AddForce(new Vector2(0, 0));
                    }
                }
            }
        }

        checkClick = false;
    
    }

 



}
