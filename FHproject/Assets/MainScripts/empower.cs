using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class empower : MonoBehaviour
{
    public GameObject needSp1; // 1번스킬 필요SP 텍스트 UI
    public GameObject needSp2; // 2번스킬 필요SP 텍스트 UI
    public GameObject needSp3; // [공용]AP상승 필요SP 텍스트UI
    public GameObject skillName1; // 1번스킬 텍스트 Ui
    public GameObject skillName2; // 2번스킬 텍스트 UI
    public GameObject skillName3; // [공용]AP상승 스킬 텍스트UI
    public GameObject currentSp; // 남은sp띄워주는 텍스트UI
    public GameObject gameManager; // 게임매니저
    public GameObject empowerPopup; // 메인 강화팝업 온오프용 (단순 온오프가 아닌 세이브가 추가됨)
    public GameObject Panel1; // 메인 강화 팝업을 제외한 패널 온오프용1
    public GameObject Panel2; // 메인 강화 팝업을 제외한 패널 온오프용2
    public GameObject Panel3; // 메인 강화 팝업을 제외한 패널 온오프용3
    bool activeEmpower; // 강화팝업 온오프용(이거로 구현하다가 위에 오브젝트로 구현했는데 쓰이는지는 체크해봐야 됨)
    int getCurrentSp; // 남은 sp받는 변수(세이브용)
    int cancelCurrentSp; // 스탯찍다 취소시 롤백받는 변수
    // Start is called before the first frame update
    void Start()
    {

        /*this.needSp1 = GameObject.Find("skill1slotSpT"); // UI상으로 보여줄 숫자가 찍힐 UI텍스트
        this.needSp2 = GameObject.Find("skill2slotSpT"); // UI상으로 보여줄 숫자가 찍힐 UI텍스트
        this.needSp3 = GameObject.Find("skill3slotSpT"); // UI상으로 보여줄 숫자가 찍힐 UI텍스트([공통]AP증가)
        this.skillName1 = GameObject.Find("skill1slotT"); // UI상으로 보여줄 스킬명이 찍힐 UI텍스트
        this.skillName2 = GameObject.Find("skill2slotT"); // UI상으로 보여줄 스킬명이 찍힐 UI텍스트
        this.skillName3 = GameObject.Find("skill3slotT"); // UI상으로 보여줄 스킬명이 찍힐 UI텍스트([공통]AP증가)
        this.currentSp = GameObject.Find("currentSpT"); // character클래스에서 가져올 남은 스킬포인트*/
        //this.empowerPopup = GameObject.Find("empowerPopup"); // 강화팝업 지정
        //this.gameManager = GameObject.Find("GameManager"); // 게임의 전반적인 모든것을 관리할 클래스(연습용 프로젝트라 모든 스크립트가 다들어가있음 empower 클래스는 하드코딩 구현이 된상태라 나중에 참조하려고 내용만 놔두고 비활성함)
        activeEmpower = false;
        //empowerPopup.SetActive(false);

    }

    //이 밑으로 this.gameManager.GetComponent<character>().characterId = 1이나 2는 현재의 캐릭터ID를 칭함. 이 ID값에 따라 다른것들이 불려올떄 값이 달라짐. 1번캐릭터면 1,2스킬 2번캐릭터면 3,4스킬이 갱신됩니다.

    // Update is called once per frame
    void Update() // 잘되는데 null 왜뜨는지모르겠음.
    {
        if (activeEmpower == true) // openEmpower 안박아서 일단 false라 실행안됨 수정해야함.
        {

            Debug.Log(PlayerPrefs.GetInt("currentSp"));
            needSp3.GetComponent<Text>().text = gameManager.GetComponent<skill7>().needSp.ToString(); // [공용] 공용스킬인 7번스킬 요구 sp출력
            skillName3.GetComponent<Text>().text = gameManager.GetComponent<skill7>().skillName.ToString(); // [공용] 공용스킬인 7번스킬 요구 sp출력
            currentSp.GetComponent<Text>().text = gameManager.GetComponent<character>().currentSp.ToString();// [공용]남은 sp 출력
            if (this.gameManager.GetComponent<character>().characterId == 1) // 1번캐릭이면
            {
                needSp1.GetComponent<Text>().text = gameManager.GetComponent<skill1>().needSp.ToString(); // 1번 캐릭일때 1번스킬 요구 sp 출력
                needSp2.GetComponent<Text>().text = gameManager.GetComponent<skill2>().needSp.ToString(); // 1번 캐릭일때 2번스킬 요구 sp 출력
                skillName1.GetComponent<Text>().text = gameManager.GetComponent<skill1>().skillName.ToString(); // 1번 캐릭일때 1번스킬 요구 sp 출력
                skillName2.GetComponent<Text>().text = gameManager.GetComponent<skill2>().skillName.ToString(); // 1번 캐릭일때 2번스킬 요구 sp 출력


            }
            else if (this.gameManager.GetComponent<character>().characterId == 2) //2번캐릭이면
            {
                
                needSp1.GetComponent<Text>().text = gameManager.GetComponent<skill3>().needSp.ToString(); // 2번 캐릭일때 1번스킬(3번) 요구 sp 출력
                needSp2.GetComponent<Text>().text = gameManager.GetComponent<skill4>().needSp.ToString(); // 2번 캐릭일때 2번스킬(4번) 요구 sp 출력
                skillName1.GetComponent<Text>().text = gameManager.GetComponent<skill3>().skillName.ToString(); // 2번 캐릭일때 1번스킬 요구 sp 출력
                skillName2.GetComponent<Text>().text = gameManager.GetComponent<skill4>().skillName.ToString(); // 2번 캐릭일때 2번스킬 요구 sp 출력

            }
        }
        
    }
    public void skillPlus1()
    {
        if (gameManager.GetComponent<character>().characterId == 1)
        {
            gameManager.GetComponent<character>().currentSp -= gameManager.GetComponent<skill1>().needSp;
            Debug.Log(gameManager.GetComponent<character>().currentSp);
            PlayerPrefs.SetInt("currentSp", gameManager.GetComponent<character>().currentSp);
        } // 캐릭터가 1번일때 1번+버튼을 누르면 남은 sp에서 1번스킬 요구 sp만큼 차감

        else if (gameManager.GetComponent<character>().characterId == 2)
        {
            gameManager.GetComponent<character>().currentSp -= gameManager.GetComponent<skill3>().needSp; // 캐릭터가 2번일떄 1번+버튼을 누르면 남은 sp에서 1번스킬(3번) 요구 sp만큼 차감
            PlayerPrefs.SetInt("currentSp", gameManager.GetComponent<character>().currentSp);

        }
    }
    public void skillMinus1()
    {
        if (gameManager.GetComponent<character>().characterId == 1)
        {
            gameManager.GetComponent<character>().currentSp += gameManager.GetComponent<skill1>().needSp; // 캐릭터가 1번일때 1번-버튼을 누르면 남은 sp에서 1번스킬 요구 SP만큼 증가
            PlayerPrefs.SetInt("currentSp", gameManager.GetComponent<character>().currentSp);
        }
        else if (gameManager.GetComponent<character>().characterId == 2)
        {
            gameManager.GetComponent<character>().currentSp += gameManager.GetComponent<skill3>().needSp; // 캐릭터가 2번일때 1번-버튼을 누르면 남은 sp에서 1번스킬(3번) 요구 sp만큼 증가
            PlayerPrefs.SetInt("currentSp", gameManager.GetComponent<character>().currentSp);
        }


    }
    public void skillPlus2()
    {
        if (gameManager.GetComponent<character>().characterId == 1)
        {
            gameManager.GetComponent<character>().currentSp -= gameManager.GetComponent<skill2>().needSp;
            PlayerPrefs.SetInt("currentSp", gameManager.GetComponent<character>().currentSp);
        } // 캐릭터가 1번일떄 2번+버튼을 누르면 남은 sp에서 2번스킬 요구 sp만큼 차감

        else if (gameManager.GetComponent<character>().characterId == 2)
        {
            gameManager.GetComponent<character>().currentSp -= gameManager.GetComponent<skill4>().needSp; // 캐릭터가 2번일떄 2번+버튼을 누르면 남은 sp에서 2번스킬(4번) 요구 sp만큼 차감
            PlayerPrefs.SetInt("currentSp", gameManager.GetComponent<character>().currentSp);
        }
    }
    public void skillMinus2()
    {
        if (gameManager.GetComponent<character>().characterId == 1)
        {
            gameManager.GetComponent<character>().currentSp += gameManager.GetComponent<skill2>().needSp; // 캐릭터가 1번일때 2번-버튼을 누르면 남은 sp에서 2번스킬 요구 sp만큼 증가
            PlayerPrefs.SetInt("currentSp", gameManager.GetComponent<character>().currentSp);
        }
        else if (gameManager.GetComponent<character>().characterId == 2)
        {
            gameManager.GetComponent<character>().currentSp += gameManager.GetComponent<skill4>().needSp; // 캐릭터가 2번일때 2번-버튼을 누르면 남은 sp에서 2번스킬(4번) 요구 sp만큼 증가
            PlayerPrefs.SetInt("currentSp", gameManager.GetComponent<character>().currentSp);
        }


    }


    public void skillPlus3()
    {
        gameManager.GetComponent<character>().currentSp -= gameManager.GetComponent<skill7>().needSp; //[공용] 3번 +버튼을 누르면 남은 sp에서 3번스킬(7번) 요구 sp만큼 차감
        PlayerPrefs.SetInt("currentSp", gameManager.GetComponent<character>().currentSp);

    }
    public void skillMinus3()
    {
        gameManager.GetComponent<character>().currentSp += gameManager.GetComponent<skill7>().needSp; //[공용] 3번-버튼을 누르면 남은 sp에서 3번스킬(7번) 요구 sp만큼 증가
        PlayerPrefs.SetInt("currentSp", gameManager.GetComponent<character>().currentSp);
    }



    public void openPanel1()
    {
        Panel1.SetActive(true);
    }
    public void openPanel2()
    {
        Panel2.SetActive(true);
    }
    public void openPanel3()
    {
        Panel3.SetActive(true);
    }
    public void closePanel1()
    {
        Panel1.SetActive(false);
    }
    public void closePanel2()
    {
        Panel2.SetActive(false);
    }
    public void closePanel3()
    {
        Panel3.SetActive(false);
    }

    public void selectFF1()
    {
        gameManager.GetComponent<character>().characterId = 1;
    }
    public void selectFF2()
    {
        gameManager.GetComponent<character>().characterId = 2;
    }
    public void selectFF3()
    {
        gameManager.GetComponent<character>().characterId = 3;
    }

    public void openEmpower()
    {

        empowerPopup.SetActive(true); // 팝업열기(임시용)

        getCurrentSp = PlayerPrefs.GetInt("currentSp");//취소시 롤백할 값 저장.
 
        Debug.Log(getCurrentSp+"openEmpower getCurrentSp디버그. 롤백값"); // 클래스에서 public int getCurrentSp 를 선언하고 세이브한 값을 불러옴
        activeEmpower = true; // 팝업창 온오프를 판정할때 온을 판정


    }
    public void swap()
    {
        if (gameManager.GetComponent<character>().characterId == 1) // 캐릭터가 1번이면 2번 캐릭터로 전환
        {
            gameManager.GetComponent<character>().characterId = 2;
            Debug.Log(gameManager.GetComponent<character>().characterId);
            Debug.Log("2번캐릭터");
        }
        else if (gameManager.GetComponent<character>().characterId == 2) // 캐릭터가 2번이면 1번캐릭터로 전환
        {
            gameManager.GetComponent<character>().characterId = 1;
            Debug.Log("1번캐릭터");
        }
    }
    public void Accept() // 스탯저장
    {

        PlayerPrefs.SetInt("currentSp", gameManager.GetComponent<character>().currentSp); // 캐릭터 클래스에서 남은 sp를 가져오고 저장.
        PlayerPrefs.Save();
        activeEmpower = false; // 팝업창 온오프를 판정할때 오프를 판정
        empowerPopup.SetActive(false); // 팝업창을 비활성시켜서 안보이게 함.


    }

    public void Cancel() // 스탯저장취소
    {
        Debug.Log(getCurrentSp);
        PlayerPrefs.SetInt("currentSp", getCurrentSp);
        
        Debug.Log(PlayerPrefs.GetInt("currentSp"));// 팝업을 열때 취소하려고 저장했던 값인 getCurrentSp를 불러와서 저장데이터에 직접 연관주는 SetInt에 값을 저장.
        gameManager.GetComponent<character>().currentSp = getCurrentSp; // 취소된 값을 캐릭터 클래스의 남은sp에 전달한다.
        

        empowerPopup.SetActive(false); // 단순 팝업만닫기

    }

    public void SceneMove()
    {
        SceneManager.LoadScene("anotherScene");
    }

}
