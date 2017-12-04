using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public partial class TitleGM : MonoBehaviour {

  //  public GameObject progressBarObject;
    public GameObject signupButtonObject; //가입버튼
    public GameObject makeIdObject; //ID입력panel
    public GameObject messageBoxObject;//메시지상자 panel

    // public ProgressBar progressBar;
    public InputField inputLabel; //아이디 입력
    public Text messageTextLabel;

    void OnEnable()
    {
        int userKeyNo = PlayerPrefs.GetInt("UserKeyNo"); //UserKeyNo를 받아온다.
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
    
    //rabbitRunLogin버튼을 누르면 작동
    public void ClickOpenInputID()
    {
        TurnOnObj(2); 
    }

    public void ClickCloseLoginBox()
    {
        makeIdObject.SetActive(false);
    }
    public void ClickinputID()
    {
        //아이디 길이 체크
        string inputID = inputLabel.text;
        if(!(inputID.Length >=4 && inputID.Length <= 12)) //입력한 아이디가 4~12자가 아니면
        {
            PopupWarningMessage("아이디는 4~12자로 입력해야합니다");
            return;
        }
        PopupWarningMessage("이미 존재하는 아이디인지 확인하는 중입니다.");
        StartCoroutine(InputIDToServer(inputID)); //아이디를 서버에 전달
    }

    //아이디를 서버로 전달하는 부분 
    IEnumerator InputIDToServer(string id)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", id);

        string url = "http://localhost/rabbitrun2/postUserID.php";
        WWW www = new WWW(url, form);

        yield return www;

        if(www.isDone&& www.error==null)
        {
            Debug.Log(www.text); //전달받은 데이터의 앞 5글자를 분리하여 결과 코드로 분석
            string responseCode = www.text.Substring(0, 5);
            switch(responseCode)
            {
                case "query"://서버에서 sql 쿼리 에러가 발생한 경우
                    break;
                case "exist": //아이디 중복인 경우
                    SceneManager.LoadScene(1);
                    break;
                case "done0":
                    messageBoxObject.SetActive(false);
                    string splitUserKeyNo = www.text.Substring(5);
                    int userKeyNo = System.Convert.ToInt32(splitUserKeyNo);
                    PlayerPrefs.SetInt("UserKeyNo", userKeyNo);
                    break;
            }
        }
    }

}