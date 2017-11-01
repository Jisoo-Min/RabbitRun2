using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*******************************************************
 * 게임메니져 역할 : 게임 전반적인 동작을 관리
 * 게임 준비, 종료, 시작을 모두 처리
 * 준비상태, 게임상태, 종료상태를 이용하여 화면 제어, 객체 제어
 * *****************************************************/
public class GameManager : MonoBehaviour
{
    public float waitingTime = 3.0f;
    static GameManager manager;
    public bool ready = true;
    public GameObject rabbit;

    // Use this for initialization
    void Start()
    {
        manager = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ready == true)
        {
            ready = false;
            InvokeRepeating("MakeRabbit", 1f, waitingTime);
        }
    }

    void MakeRabbit()
    {
        Instantiate(rabbit);
    }
}
