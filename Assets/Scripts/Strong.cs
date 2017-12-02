using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Strong : MonoBehaviour {

    public GameObject spoon;
    public int angle = 0;
    public float range;

    // Use this for initialization
    void Start () {
        if (CharacterName.characterName.Equals("JiSoo"))
        {
            Instantiate(spoon);

        }
        else
        {
            Destroy(spoon);
        }
        
    }
	
	// Update is called once per frame
	private void FixedUpdate() {
        if (CharacterName.characterName.Equals("JiSoo"))
        {
            UpdateStrong("eel");
            UpdateStrong("crab");
            UpdateStrong("seashell");
            UpdateStrong("seaweed");
            UpdateStrong("hook");
            UpdateStrong("red_fish");
            UpdateStrong("yellow_fish");
            UpdateStrong("blue_fish");
            UpdateStrong("octopus");
            angle += 100;
            spoon.transform.localRotation = Quaternion.Euler(0f, 0f, angle);

        }
       

    }




    void UpdateStrong(string tag)
    {
        var tags = GameObject.FindGameObjectsWithTag(tag); //해당 태그를 배열로 생성
        foreach (var item in tags)
        {
            Vector3 dir = spoon.transform.position - item.transform.position; //캐릭터위치-item위치(벡터값)
            if (dir.magnitude > range) //범위안에 들어오면 magnitude = 길이
                continue;
            iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.2, "y", 0.2, "time", 0.1f));

            Destroy(item);
        }

    }
    
}
