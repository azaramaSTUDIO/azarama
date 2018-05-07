using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameOver = false;
    public GameObject gameOverUI;
    public AudioClip gameOverSfx;

    public Vector3 spawnPoint;
    private float spawnTime;
    private int spawnCase;
    private float spawnOffset;

    public List<Transform> items, obstacles;


    public float sfxVolume = 0.9f; // 효과음 음량
    public bool isSfxMute = false; // 효과음 음소거 여부 설정

    // Use this for initialization
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        foreach (Transform tr in GameObject.FindGameObjectWithTag("Items").transform)
        {
            items.Add(tr);
        }
        foreach (Transform tr in GameObject.FindGameObjectWithTag("Obstacles").transform)
        {
            obstacles.Add(tr);
        }
        StartCoroutine(SpawnObject(items));
        StartCoroutine(SpawnObject(obstacles));
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
        PlaySfx(gameObject.GetComponent<Transform>().position, gameOverSfx);
    }

    public void PlaySfx(Vector3 pos, AudioClip sfx)
    {
        if (isSfxMute) return;

        GameObject soundObj = new GameObject("Sfx");
        Debug.Log("SFX");

        soundObj.transform.position = pos;

        AudioSource audioSource = soundObj.AddComponent<AudioSource>();

        audioSource.clip = sfx;
        audioSource.minDistance = 10.0f; // 100% 소리가 들리는 최대 거리
        audioSource.maxDistance = 30.0f; // 0% 소리가 들리는 최대 거리
        audioSource.volume = sfxVolume;

        audioSource.Play();

        Destroy(soundObj, sfx.length);
    }

    IEnumerator SpawnObject(List<Transform> objs)
    {
        while (true)
        {
            spawnTime = Random.Range(1.5f, 3.0f);
            spawnCase = Random.Range(0, objs.Count);
            spawnOffset = Random.Range(-2.0f, 2.0f);

            if (!objs[spawnCase].gameObject.activeSelf)
            {
                objs[spawnCase].position = Vector3.right * spawnOffset + spawnPoint;
                objs[spawnCase].gameObject.SetActive(true);
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
