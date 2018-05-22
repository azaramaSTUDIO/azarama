using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour {

    private Vector3 startPos = new Vector3(10, 0, 0);

    private Vector3 startPosition, endPosition = Vector3.zero;
    private float deltaX, deltaY;

    public int characterNum;

    public GameObject characters;
    private Transform[] trs;

    public Text characterText;
    private string[] characterStrings =
    {
        "흰색 아자라마\n자유로운 여정을 위해 순수하고 하얗고\n깨끗한 마음으로 준비되는 친구다.\n자신의 색을 찾기 위해\n오늘도 여정을 떠난다.\n난이도 : 매우 쉬움",
        "파란색 아자라마\n파란색을 가장 좋아하는 자폐성 장애 친구이다.\n순간 집중력을 보이면서도\n언제 어떻게 튈지 모르는 성격을 가지고 있다.\n조작 난이도 : 어려움",
        "녹색 아자라마\n환경을 중요시 하며 푸른 숲에서 오는 친구다.\n자연을 너무 좋아한 나머지\n도시를 극도로 싫어하게 되었다.\n조작 난이도 : 쉬움",
        "보라색 아자라마\n포도를 먹으면서 성장하더니 보라색이 되어버렸다.\n언젠가 트로피카나 광고모델을 위해\n삼시세끼를 포도로 먹는다.\n조작 난이도 : 보통"
    };


    // Use this for initialization
    void Start() {

        if (PlayerPrefs.GetInt("Character") == 0)
        {
            characterNum = 0;
        }

        PlayerPrefs.SetInt("Character", characterNum);
        characterText.text = characterStrings[characterNum];
        SetCharacters(PlayerPrefs.GetInt("Character"));

    }

    private void SetCharacters(int n)
    {
        trs = characters.GetComponentsInChildren<Transform>();
        Debug.Log("Player is " + PlayerPrefs.GetInt("Character"));
        for (int i = 1; i < trs.Length; i++)
        {
            if (trs[i].position.x < -5) trs[i].position = new Vector3(10.0f, 0.0f, 0.0f);
            if (trs[i].position.x > 10) trs[i].position = new Vector3(-5.0f, 0.0f, 0.0f);
        }
    }

    private void RTL()
    {
        iTween.MoveBy(characters, iTween.Hash("x", -5, "time", 0.5f));
        characterNum = characterNum + 1 > 3 ? 0 : characterNum + 1;
        PlayerPrefs.SetInt("Character", characterNum);
        characterText.text = characterStrings[characterNum];
        SetCharacters(characterNum);
    }

    private void LTR()
    {
        iTween.MoveBy(characters, iTween.Hash("x", 5, "time", 0.5f));
        characterNum = characterNum - 1 < 0 ? 3 : characterNum - 1;
        PlayerPrefs.SetInt("Character", characterNum);
        characterText.text = characterStrings[characterNum];
        SetCharacters(characterNum);
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))    // swipe begins
        {
            Debug.Log("START : " + startPosition);
            Debug.Log(Input.mousePosition);
            startPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))    // swipe ends
        {
            Debug.Log("END : " + endPosition);
            endPosition = Input.mousePosition;
        }

        if (startPosition != endPosition && startPosition != Vector3.zero && endPosition != Vector3.zero)
        {
            deltaX = endPosition.x - startPosition.x;
            deltaY = endPosition.y - startPosition.y;
            if ((deltaX > 5.0f || deltaX < -5.0f) && (deltaY >= -1.0f || deltaY <= 1.0f))
            {
                if (startPosition.x < endPosition.x) // swipe LTR
                {
                    LTR();
                    print("LTR");
                }
                else // swipe RTL
                {
                    RTL();

                    print("RTL");
                }
            }
            startPosition = endPosition = Vector3.zero;
        }
    }
}
