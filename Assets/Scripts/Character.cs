using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterName
{
    public static string characterName;
}


public class Character : MonoBehaviour
{

    private float jump = 10;
    public float health = 100;
    private int jumpNumber;
    private bool isOnground;

    public static bool checkClick = false;

    public static Character character;

    public Sprite rabbit1;
    public Sprite rabbit2;
    public Sprite hyeri;
    public Sprite slideHyeRi;
    public Sprite jisoo;
    public Sprite slideJiSoo;

    public Sprite effect_rabbit;
    public bool ignore = false;



    void Start()
    {

        if (CharacterName.characterName.Equals("JiSoo"))
        {
            rabbit1 = jisoo;
            rabbit2 = slideJiSoo;
        }
        else if (CharacterName.characterName.Equals("HyeRi"))
        {
            rabbit1 = hyeri;
            rabbit2 = slideHyeRi;
        }

        character = this;
        PointerUp();
    }

    void OnTriggerEnter2D(Collider2D item)   // 먹이를 먹었을 때
    {
        if (item.tag == "carrot") //기본먹이
        {

            Destroy(item.gameObject);
            GameManager.manager.AddScore(100);

        }
        else if (item.tag == "chick")  //chick을 먹으면  StartIgnore() 실행
        {
            Destroy(item.gameObject);
            GameManager.manager.AddScore(300);

            if (CharacterName.characterName.Equals("HyeRi"))
            {
                ignore = true;

                StartCoroutine("SetIgnore");
                Character.character.transform.localScale = new Vector2(0.6f, 0.4f);
                MoveFood.foodSpeed = 10;
                MoveObstacle.obstacleSpeed = 10;
                MoveGround.groundSpeed = 10;
                Invoke("SetNormal", 3);
            }



        }

        else if (item.tag == "heart")
        {
            Destroy(item.gameObject);
            if (health + 20 > 100)
            {
                health = 100;
            }
            else
            {
                health = health + 20.0f;
            }

        }
        else if (item.tag == "coin")
        {
            Destroy(item.gameObject);
            GameManager.manager.AddCoin(1);

        }
        else if (item.tag == "broccoli") //크기증가먹이
        {

            Destroy(item.gameObject);
            GameManager.manager.AddScore(200);
            Character.character.transform.localScale = new Vector2(0.6f, 0.4f);
            Invoke("SetNormal", 3);
        }
        else if (item.tag == "corn") //크기감소먹이
        {
            Destroy(item.gameObject);
            GameManager.manager.AddScore(30);
             Character.character.transform.localScale = new Vector2(0.2f, 0.15f);
            Invoke("SetNormal", 3);
        }
        else if (item.tag == "clover")//속도 증가먹이
        {
            GameManager.manager.AddScore(200);
            Destroy(item.gameObject);

            MoveFood.foodSpeed = 10;
            MoveObstacle.obstacleSpeed = 10;
            MoveGround.groundSpeed = 10;
            Invoke("SetNormal", 3);

        }

        if (CharacterName.characterName.Equals("HyeRi") && ignore) //장애물만 무시하기 위해 아래로 이동 -> 위치는 먹이랑 장애물 사이
        {
            return;
        }
        else if ((item.tag == "eel") || (item.tag == "crab") || (item.tag == "seashell") || (item.tag == "seaweed") || (item.tag == "hook") || (item.tag == "red_fish") || (item.tag == "yellow_fish") || (item.tag == "blue_fish") || (item.tag == "octopus"))
        {
            iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.2, "y", 0.2, "time", 0.1f));
            health = health - 20.0f;
        }


    }


    IEnumerator SetIgnore()
    {
        yield return new WaitForSeconds(3);   //3초후에 다음 명령어 실행
        ignore = false;

    }

    void SetNormal()
    {
        MoveFood.foodSpeed = 5;
        MoveObstacle.obstacleSpeed = 5;
        MoveGround.groundSpeed = 5;
        GetComponent<SpriteRenderer>().sprite = rabbit1;
        transform.localScale = new Vector2(0.3f, 0.26f);


    }
    void OnCollisionEnter2D(Collision2D collision) //접촉했을때
    {
        jumpNumber = 0;
        isOnground = true;

        if (collision.gameObject.name == "deadline" || collision.gameObject.name == "turtle_side")//죽는 라인에 충돌할 경우 게임 중지 
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
