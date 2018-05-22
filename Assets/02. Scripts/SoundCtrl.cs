using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCtrl : MonoBehaviour {

    private AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            audio.volume = 0.9f;
        }
        else
        {
            audio.volume = 0.0f;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
