using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    private float jump = 8;
    public int jump_number;
    private bool is_onground;
    private GameObject target; //클릭한 곳
    public int score = 0;
    public int coin = 0;
    public Text textScore;
    public Text textCoin;
    MoveFoodCarrot ca;

    public static bool checkClick = false;

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D item)   // 당근을 먹었을 때
    {
        if (item.tag == "carrot") //기본먹이
        {
            Destroy(item.gameObject);
            score += 100;
           
        }
        else if(item.tag == "coin")
        {
            Destroy(item.gameObject);
            ++coin;
            textCoin.text = coin.ToString();
        }
        else if (item.tag == "broccoli") //크기증가먹이
        {
            Destroy(item.gameObject);
            score += 200; 
        }
        else if (item.tag =="corn") //크기감소먹이
        {
            Destroy(item.gameObject);
            score += 30;
        }
        else if(item.tag =="clover")//속도 증가먹이
        {
            Destroy(item.gameObject);
            score += 200;
        }
        textScore.text = score.ToString();
    }

    void OnCollisionEnter2D(Collision2D collision) //접촉했을때
    {
        jump_number = 0;
        is_onground = true;

        if(collision.gameObject.name == "deadline")//죽는 라인에 충돌할 경우 게임 중지 
        {
            Time.timeScale = 0;
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionExit2D() //접촉하지 않았을때
    {
        is_onground = false;
    }
    
    public void IsClick()
    {
        checkClick = true;
    }

    void Update()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        if (checkClick == true) // 화면이 클릭되었을때
        {
            ++jump_number;
            Debug.Log(jump_number);

            if (is_onground == true) //땅에 있을때
            {

                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump);

            }

            else if (is_onground == false) //점프중일때
            {
                if (jump_number <= 2)
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump);


                if (jump_number > 2) //점프횟수가 2번이 넘었을때
                {
                    //rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);

                    rigidbody.AddForce(new Vector2(0, 0));
                }
            }
        }

        checkClick = false;
    }




}
