
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchJumpButton : MonoBehaviour
{
    private float jump = 8;
    public int jump_number;
    private bool is_onground;
    private GameObject target; //클릭한 곳
    public GameObject jumpbutton; //점프버튼

    void OnCollisionEnter2D(Collision2D collision) //접촉했을때
    {
        jump_number = 0;
        is_onground = true;
    }



    void OnCollisionExit2D() //접촉하지 않았을때
    {
        is_onground = false;
    }

    public void jump_track() //점프 횟수 세기
    {
        

        if (target == jumpbutton)
        {
            ++jump_number;
            Debug.Log(jump_number);
        }
    }

    void Update()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        if (Input.GetMouseButtonDown(0)) // 화면이 클릭되었을때
        {
            CastRay();
            jump_track();
            if (is_onground == true) //땅에 있을때
            {
                if (target == jumpbutton)
                {
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump);
                }
            }

            else if (is_onground == false) //점프중일때
            {
                if ((target == jumpbutton) && jump_number <= 2)
                {
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump);
                }

                if (jump_number > 2) //점프횟수가 2번이 넘었을때
                {
                    //rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);

                    rigidbody.AddForce(new Vector2(0, 0));
                }
            }
        }


    }

    void CastRay() // 클릭한 곳을 target으로 지정
    {
        target = null;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

        if (hit.collider != null) // 클릭되었다면 실행
        {
            target = hit.collider.gameObject; //클릭된 게임 오브젝트를 타겟으로 지정
        }

    }
}
