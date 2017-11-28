using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**********************************
 * 기능 : 선택한 캐릭터 정보 전달
 * ********************************/
public class SelectCharacter : MonoBehaviour {

  //  public static string characterName;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SetCharacterName(string name)
    {
        // Character.character.characterName = name;

        CharacterName.characterName = name;
    }


    public void ClickHyeRi()
    {
        SetCharacterName("HyeRi");
    }

    public void ClickJiSoo()
    {
        SetCharacterName("JiSoo");
    }
    public void ClickGaYeon()
    {
        SetCharacterName("GaYeon");
    }

}