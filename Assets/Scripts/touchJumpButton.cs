using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchJumpButton : MonoBehaviour {

    private GameObject target;
    public GameObject jumpbutton;
    public float jump;

    public void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            CastRay();
            if (target == jumpbutton)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }
        
    }

    void CastRay()
    {
        target = null;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

        
        if(hit.collider != null)
        {
            target = hit.collider.gameObject;
        }
        
    }
}
