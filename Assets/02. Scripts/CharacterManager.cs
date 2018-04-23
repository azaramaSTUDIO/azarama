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

    // Use this for initialization
    void Start() {

        if (PlayerPrefs.GetInt("Character") == 0)
        {
            characterNum = 0;
        }

        PlayerPrefs.SetInt("Character", characterNum);
        SetCharacters(PlayerPrefs.GetInt("Character"));

    }

    private void SetCharacters(int n)
    {
        PlayerPrefs.SetInt("Character", n);
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
        SetCharacters(characterNum);
    }

    private void LTR()
    {
        iTween.MoveBy(characters, iTween.Hash("x", 5, "time", 0.5f));
        characterNum = characterNum - 1 < 0 ? 3 : characterNum - 1;
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
