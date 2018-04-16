using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform spawnPoint;
    public static GameManager instance;
    public GameObject Pipes;
    public float spawnTime = 3.0f;

    public float sfxVolume = 0.9f; // 효과음 음량
    public bool isSfxMute = false; // 효과음 음소거 여부 설정

    // Use this for initialization
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        StartCoroutine(SpawnSphere());
    }

    // Update is called once per frame
    void Update()
    {

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

    IEnumerator SpawnSphere()
    {
        while (true)
        {
            spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-2.0f, 2.0f), 0, 0);
            GameObject obj1 = Instantiate(Pipes, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
