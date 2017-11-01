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

    void OnTriggerEnter2D(Collider2D other)   // 당근을 먹었을 때
    {
        if (other.tag == "carrot")
        {
            Destroy(other.gameObject);
            score += 100;
            textScore.text = score.ToString();
        }
        else if(other.tag == "coin")
        {
 
            Destroy(other.gameObject);
            ++coin;
            textCoin.text = coin.ToString();
           
        }

    }

    void OnCollisionEnter2D(Collision2D collision) //접촉했을때
    {
        jump_number = 0;
        is_onground = true;
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
