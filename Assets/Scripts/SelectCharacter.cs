using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour {

    public static SelectCharacter selectCharacter;
    private string characterName;



	// Use this for initialization
	void Start () {
        selectCharacter = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SetCharacterName(string name)
    {
        characterName = name;
    }

    public string GetCharacterName()
    {
        return characterName;
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