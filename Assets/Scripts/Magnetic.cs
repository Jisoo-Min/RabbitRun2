using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour {
    public float acc;
    public float range;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    private void FixedUpdate() //update된 후 수행
    {
        if (CharacterName.characterName.Equals("GaYeon"))
        {
            UpdateMag("carrot");
            UpdateMag("coin");
        }
    }

    void UpdateMag(string tag) 
    {
        var tags = GameObject.FindGameObjectsWithTag(tag); //해당 태그를 배열로 생성
        foreach (var item in tags)
        {
            Vector3 dir = transform.position - item.transform.position; //캐릭터위치-item위치(벡터값)
            if (dir.magnitude > range) //범위안에 들어오면 magnitude = 길이
                continue;

            dir.Normalize(); //단위벡터 

            item.transform.position = item.transform.position + dir * acc * Time.deltaTime;//가속도 붙어서 날라옴...
        }
    }
}
