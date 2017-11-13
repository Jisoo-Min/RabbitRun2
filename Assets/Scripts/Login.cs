using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public partial class Login : MonoBehaviour
{

    public GameObject progressBarObject;
    public GameObject signupButtonObject;
    public GameObject makeIdObject;
    public GameObject messageBoxObject; //메시지를 띄우는 패널 

    Text messageText; //messageBox패널에 띄울 내용
    Text inputID;//아이디 입력할 때의 text
     
    void OnEnable()
    {
        int userKeyNo = PlayerPrefs.GetInt("UserKeyNo");//PlayerPrefs를 이용하여 데이터를 local에 저장

        if (userKeyNo > 0)
        {
            TurnOnObject(0); //사용자 정보 로딩 시작
        }
        else
        {
            TurnOnObject(1);//가입버튼 활성화
        }
    }

    void TurnOnObject(int objNo)
    {
        progressBarObject.SetActive(objNo == 0); //사용자 정보가 있으면 로딩바
        signupButtonObject.SetActive(objNo == 1); //사용자 정보가 없으면 가입
        makeIdObject.SetActive(objNo == 2); //아이디 만들기
        messageBoxObject.SetActive(objNo == 3);//메시지상자띄우기
    }

#region messageBox method

    event System.Action SubmitMessageBox; //sub

    /****************************************************
     * PopupWarningMessage : 메시지 박스 띄우는 메소드
     * messageText : 표시할 내용
     * submitAction : 메시지 박스 받을 때 실행되는 메소드
     * **************************************************/
    public void PopupWarningMessage(string messageContents, System.Action submitAction = null)
    {
        messageText.text = messageContents;
        messageBoxObject.SetActive(true);
       
        if (submitAction != null)
        {
            SubmitMessageBox = submitAction;
        }
        else
        {
            SubmitMessageBox = null;
        }
    }

    public void ClickCloseMessageBox()
    {
        messageBoxObject.SetActive(false);
    }
#endregion


    public void ClickOpenInputID()
    {
        TurnOnObject(2);
    }
    public void ClickInputID()
    {
        string checkID = inputID.text;
        if (!(checkID.Length >= 4 && checkID.Length <= 13))
        {
            PopupWarningMessage("Length of ID must be 4 to 14 characters");
            return;
        }
        PopupWarningMessage("Checking ID Duplication");
        StartCoroutine(InputIDToServer(checkID)); //아이디를 서버로 전달

    }
    
    IEnumerator InputIDToServer(string idText)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", idText);

        string url = ""; //채우기

        WWW www = new WWW(url, form);
        yield return www;//www클래스 통해서 값 전달 받을 때까지 대기

        if(www.isDone && www.error == null)
        {
            string responseCode = www.text.Substring(0, 5);
            switch(responseCode)
            {
                case "query": //서버에서 sql 쿼리 에러 발생한 경우
                    break;
                case "exist": //입력한 아이디가 이미 있는경우(아이디 중복)
                    PopupWarningMessage("Can't use this ID Cuz It already existed");
                    break;
                case "done0": //아이디가 정상적으로 생성된 경우
                    messageBoxObject.SetActive(false);
                    string splitUserKeyNo = www.text.Substring(5); //생성된 아이디의 키값 저장
                    int userKeyNo = System.Convert.ToInt32(splitUserKeyNo);
                    PlayerPrefs.SetInt("UserKeyNo", userKeyNo);
                    /***************************
                     * 서버로부터 필요한 정보 읽는 다음단계 진행
                     * ************************/

                    break;
            }
        }
    }
}