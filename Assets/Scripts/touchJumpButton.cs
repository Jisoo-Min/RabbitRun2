
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchJumpButton : MonoBehaviour
{

    private GameObject target; //클릭한 곳
    public GameObject jumpbutton; //점프버튼
    private float jump = 8; // jump 하는 값
    private bool isJump = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
            isJump = true;
            if ((target == jumpbutton) && isJump)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                isJump = false;
            }
        }

    }

    void CastRay()
    {
        target = null;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

        if (hit.collider != null)
        {
            target = hit.collider.gameObject;
        }

    }
}

/* button UI 이용해서 하는거 - 수정 필요
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class touchJumpButton : MonoBehaviour
{
    private bool jumpOn = false;
    private int checkTime = 0;
    private int jump = 7;

    void Update()
    {
        if (!jumpOn) 
        {
            if ((Input.GetMouseButtonDown(0))) // 버튼을 누름
            {
                if(EventSystem.current.IsPointerOverGameObject() == false)
                { // UI 위가 아니면
                    StartCoroutine("CheckButtonDownSec");
                }
            }
            else if((Input.GetMouseButtonUp(0))) // 버튼에서 땜.
            {
                if(EventSystem.current.IsPointerOverGameObject() == false)
                { //UI 위가 아니면
                    if (checkTime > 0)
                    { // 점프 수치가 있어야 실행함.
                        StartCoroutine("JumpAction");
                        CastRay();
                        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                    }
                }
                else
                { // UI위라면 점프실행X & 시간 측정 끔.
                    if(checkTime>0)
                    {
                        StopCoroutine("CheckButtonDownSec");
                        checkTime = 0;
                    }
                }
            }
        }
    }

    void CastRay()
    {
        target = null;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

        if (hit.collider != null)
        {
            target = hit.collider.gameObject;
        }

    }
}
*/