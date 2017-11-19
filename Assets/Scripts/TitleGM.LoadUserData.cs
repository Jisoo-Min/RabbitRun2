using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public partial class TitleGM : MonoBehaviour
{

    int loadRetryCounter = 0;

    // 사용자 데이터를 로딩.
    public void LoadUserData()
    {
        StartCoroutine(RequestUserData());
    }


    // 보유한 아이템 로딩.
    void LoadItemData()
    {
        StartCoroutine(RequestDataToServer<ItemData>("getUserItem", 0.3f, "useritem", "ItemData"));

    }
    

 
    // 데이터를 읽을 때 사용할  www 생성.
    WWW LoadDataFromServer(string targetPage)
    {
        int userKeyNo = PlayerPrefs.GetInt("UserKeyNo");

        WWWForm form = new WWWForm();
        form.AddField("userKeyNo", userKeyNo);

        string url = string.Format(GameData.Instance.urlPrefix, targetPage);
        WWW www = new WWW(url, form);
        return www;
    }

    // 사용자 데이터를 서버로부터  로딩.
    IEnumerator RequestUserData()
    {
        WWW www = LoadDataFromServer("getUserCoreDataWithFacebook");

        yield return www;

        if (www.isDone && www.error == null)
        {
            string responseCode = www.text.Substring(0, 5);
            switch (responseCode)
            {
                case "query":
                    // 서버에서 SQL 쿼리 에러가 발생한 경우.
                    break;
                case "none0":
                    if (loadRetryCounter > 2)
                    {
                        // error : 사용자 데이터가 없는 경우.
                        PopupWarningMessage( "사용자 데이터가 없습니다.\n운영자에게 문의하세요.");
                    }
                    else
                    {
                        // error : 데이터를 다시 로딩하는 경우.
                        PopupWarningMessage("데이터를 다시 로딩합니다");
                        ++loadRetryCounter;
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// 아이템, 친구, 메시지 데이터를 서버로부터 로딩할 때 사용.
    /// </summary>
    /// <param name="targetPage">페이지 이름.</param>
    /// <param name="progressPercent">로딩 진행 퍼센트. 0~1사이의 실수.</param>
    /// <param name="rootNode">xml 루트 노드 이름.</param>
    /// <param name="dataNode">각 데이터를 단위별로 저장하는 노드 이름.</param>
    /// <param name="targetList">데이터를 저장할 리스트.</param>
    /// <param name="nextStep">작업 종료 후 다음 단계로 처리할 메소드명.</param>
    /// <typeparam name="T">ItemData, FriendData 등 데이터를 저장할 구조체.</typeparam>
    IEnumerator RequestDataToServer<T>(string targetPage,float progressPercent,string rootNode,string dataNode, List<T> targetList,System.Action nextStep = null)
    {
        WWW www = LoadDataFromServer(targetPage);
        yield return www;

        if (www.isDone && www.error == null)
        {
            string responseCode = www.text.Substring(0, 5);
            switch (responseCode)
            {
                case "query":
                    // 서버에서 SQL 쿼리 에러가 발생한 경우.
                    break;
                default:
                    // xml 형태의 string 데이터를 변환.
                    GameData.Instance.ConvertData(
                        www.text, rootNode, dataNode, targetList);

                    // 프로그레스바 업데이트.
                    progressBar.value = progressPercent;

                    //  작업 종료 후 이후 작업을 진행한다.
                    if (nextStep != null) nextStep();
                    break;
            }
        }
    }

    //  dictionary로 처리되야하는 PriceData 등을 담당.
    IEnumerator RequestDataToServer<T>(string targetPage,float progressPercent,string rootNode,string dataNode,string noNode,Dictionary<int, T> targetDic, System.Action nextStep = null)
    {
        WWW www = LoadDataFromServer(targetPage);
        yield return www;

        if (www.isDone && www.error == null)
        {
            string responseCode = www.text.Substring(0, 5);
            switch (responseCode)
            {
                case "query":
                    // 서버에서 SQL 쿼리 에러가 발생한 경우.
                    break;
                default:
                    // xml 형태의 string 데이터를 변환.
                    GameData.Instance.ConvertData(www.text, rootNode, dataNode, noNode, targetDic);

                    // 프로그레스바 업데이트.
                    progressBar.value = progressPercent;

                    //  작업 종료 후 이후 작업을 진행한다.
                    if (nextStep != null) nextStep();
                    break;
            }
        }
    }
}
