using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToMainScene()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1); // azaramaPlay01 씬 로드
    }

    public void StoryRead()
    {
        SceneManager.LoadScene(2);
    }

    public void CharacterSelect()
    {
        SceneManager.LoadScene(3);
    }
}
