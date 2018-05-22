using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingCtrl : MonoBehaviour {

    public Toggle soundToggle;
    public Toggle sfxToggle;

    void settingOnOff(string key)
    {
        if (PlayerPrefs.GetInt(key, 1) == 0) {
            PlayerPrefs.SetInt(key, 1);
        }
        else
        {
            PlayerPrefs.SetInt(key, 0);
        }
    }

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            soundToggle.isOn = true;
        }
        else
        {
            soundToggle.isOn = false;
        }

        if (PlayerPrefs.GetInt("Sfx", 1) == 1)
        {
            sfxToggle.isOn = true;
        }
        else
        {
            sfxToggle.isOn = false;
        }


    }

    // Use this for initialization
    void Start() {

        soundToggle.onValueChanged.AddListener(delegate
        {
            settingOnOff("Sound");
        });

        sfxToggle.onValueChanged.AddListener(delegate
        {
            settingOnOff("Sfx");
        });
    }

    // Update is called once per frame
    void Update() {

    }

}
