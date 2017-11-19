using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public sealed class GameData : MonoBehaviour { //sealed 한정자: 이 클래스는 상속이 불가능함

    public string urlPrefix = "http://localhost/rabbitrun2/postUserID.php";
    public UserData userdata = new UserData();
    public List<ItemData> itemList = new List<ItemData>();
}
