using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class TitleGM : MonoBehaviour {

    public GameObject progressBarObject;
    public GameObject signupButtonObject;
    public GameObject makeIdObject;
    public GameObject messageBoxObject;//메시지상자 panel

   // public ProgressBar progressBar;
 //   public Label inputLabel;
    public Text messageTextLabel;

    void OnEnable()
    {
        int userKeyNo = PlayerPrefs.GetInt("UserKeyNo");
        if (userKeyNo > 0)
        {
            TurnOnObj(0); //사용자 정보 로딩 시작
        }
        else
        {
            TurnOnObj(1);//가입버튼 활성화
        }
    }

    void TurnOnObj(int objNo)
    {
        progressBarObject.SetActive(objNo == 0); //사용자 정보가 있으면 로딩바
        signupButtonObject.SetActive(objNo == 1); //사용자 정보가 없으면 가입
        makeIdObject.SetActive(objNo == 2); //아이디 만들기
        messageBoxObject.SetActive(objNo == 3);//메시지상자띄우기
    }
    

    /****************************************************
     * PopupWarningMessage : 메시지 박스 띄우는 메소드
     * messageText : 표시할 내용
     * **************************************************/
    public void PopupWarningMessage(string messageText)
    {
        messageTextLabel.text = messageText; //알려줄 문구 갱신하고
        messageBoxObject.SetActive(true); // 패널 활성화
    }

    public void ClickCloseMessageBox() //버튼 클릭하면 닫음 
    {
        messageBoxObject.SetActive(false);
    }

}