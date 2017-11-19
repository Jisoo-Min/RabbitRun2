using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public struct UserData //사용자 기본 정보
{
    public string name;
    public int gems; //보석->유료아이템
    public int coins;
    public int hearts;
    public int highScore;
    public double loginTime;

    public int upgradeNo;
    public int attLv;
    public int defLv;
    public int moneyLv;
}

[XmlRoot] //아이템 정보
public struct ItemData
{
    [XmlElement]
    public int no;
    [XmlElement]
    public int itemNo;
    [XmlElement]
    public int amount;
    [XmlElement]
    public bool use;
}