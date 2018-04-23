using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public GameObject gameOverUI;
    public AudioClip gameOverSfx;

    public Transform spawnPoint;
    public Transform spikeSpawnPoint;
    public Transform stoneSpawn;
    public static GameManager instance;
    public GameObject Pipes, RedBall;
    public GameObject Coin, Heart;
    public GameObject Stone;
    public float spawnTime = 1.0f;
    public int spawnCase;

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

    IEnumerator SpawnSphere()
    {
        /*while (true)
        {
            spawnTime = Random.Range(0.7f, 1.0f);
            spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
            GameObject obj1 = Instantiate(Pipes, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnTime);

            spawnTime = Random.Range(0.7f, 1.0f);
            spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
            GameObject obj2 = Instantiate(Coin, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnTime);

            spawnTime = Random.Range(0.7f, 1.0f);
            spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
            GameObject obj3 = Instantiate(Coin, spawnPoint.position, spawnPoint.rotation);
            if(PlayerCtrl.score > 1000)
            {
                stoneSpawn.position = stoneSpawn.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                GameObject obj6 = Instantiate(Stone, stoneSpawn.position, stoneSpawn.rotation);
            }
            yield return new WaitForSeconds(spawnTime);

            spawnTime = Random.Range(0.7f, 1.0f);
            spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
            GameObject obj4 = Instantiate(Coin, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnTime);
        }*/
        while (true)
        {
            spawnTime = Random.Range(0.5f, 1.0f);
            spawnCase = Random.Range(0, 20);
            switch (spawnCase)
            {
                case 0:
                    if (PlayerCtrl.score > 10000)
                    {
                        stoneSpawn.position = stoneSpawn.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj17 = Instantiate(RedBall, stoneSpawn.position, stoneSpawn.rotation);
                    }
                    else
                    {
                        spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj2 = Instantiate(Pipes, spawnPoint.position, spawnPoint.rotation);
                    }
                    break;

                case 1:
                    if (PlayerCtrl.score > 5000)
                    {
                        stoneSpawn.position = stoneSpawn.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj10 = Instantiate(Stone, stoneSpawn.position, stoneSpawn.rotation);
                    }
                    else
                    {
                        spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj11 = Instantiate(Coin, spawnPoint.position, spawnPoint.rotation);
                    }
                    break;
                case 2:
                    if (PlayerCtrl.score > 5000)
                    {
                        stoneSpawn.position = stoneSpawn.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj12 = Instantiate(Stone, stoneSpawn.position, stoneSpawn.rotation);
                    }
                    else
                    {
                        spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj13 = Instantiate(Coin, spawnPoint.position, spawnPoint.rotation);
                    }
                    break;
                case 3:
                    if (PlayerCtrl.score > 10000)
                    {
                        stoneSpawn.position = stoneSpawn.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj14 = Instantiate(Stone, stoneSpawn.position, stoneSpawn.rotation);
                    }
                    else
                    {
                        spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj15 = Instantiate(Coin, spawnPoint.position, spawnPoint.rotation);
                    }
                    break;

                case 4:
                    if (PlayerCtrl.score > 5000)
                    {
                        stoneSpawn.position = stoneSpawn.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj16 = Instantiate(Stone, stoneSpawn.position, stoneSpawn.rotation);
                    }
                    else
                    {
                        spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj3 = Instantiate(Pipes, spawnPoint.position, spawnPoint.rotation);
                    }
                    break;

                case 5:
                    if (PlayerCtrl.score > 10000)
                    {
                        stoneSpawn.position = stoneSpawn.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj17 = Instantiate(Stone, stoneSpawn.position, stoneSpawn.rotation);
                    }
                    else
                    {
                        spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj18 = Instantiate(Coin, spawnPoint.position, spawnPoint.rotation);
                    }
                    break;

                case 6:
                    if (PlayerCtrl.score > 10000)
                    {
                        stoneSpawn.position = stoneSpawn.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj17 = Instantiate(RedBall, stoneSpawn.position, stoneSpawn.rotation);
                    }
                    else
                    {
                        spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj18 = Instantiate(Coin, spawnPoint.position, spawnPoint.rotation);
                    }
                    break;

                case 8:
                    spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                    GameObject obj4 = Instantiate(Pipes, spawnPoint.position, spawnPoint.rotation);
                    if (PlayerCtrl.score > 5000)
                    {
                        stoneSpawn.position = stoneSpawn.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj7 = Instantiate(Stone, stoneSpawn.position, stoneSpawn.rotation);
                    }

                    break;
                case 12:
                    if (PlayerCtrl.score > 5000)
                    {
                        stoneSpawn.position = stoneSpawn.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj19 = Instantiate(Stone, stoneSpawn.position, stoneSpawn.rotation);
                    }
                    else
                    {
                        spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj5 = Instantiate(Pipes, spawnPoint.position, spawnPoint.rotation);
                    }
                    break;

                case 16:
                    if (PlayerCtrl.score > 5000)
                    {
                        stoneSpawn.position = stoneSpawn.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj20 = Instantiate(Stone, stoneSpawn.position, stoneSpawn.rotation);
                    }
                    else
                    {
                        spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                        GameObject obj6 = Instantiate(Pipes, spawnPoint.position, spawnPoint.rotation);
                    }
                    break;

                case 19:
                    spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                    GameObject obj8 = Instantiate(Heart, spawnPoint.position, spawnPoint.rotation);
                    break;

                default:
                spawnPoint.position = spawnPoint.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                GameObject obj1 = Instantiate(Coin, spawnPoint.position, spawnPoint.rotation);
                break;
            }
            if (spawnPoint.position.x > 3)
            {
                spawnPoint.position = new Vector3(2, 10, 0);
            }
            if (spawnPoint.position.x < -3)
            {
                spawnPoint.position = new Vector3(-2, 10, 0);
            }
            if (stoneSpawn.position.x > 3)
            {
                stoneSpawn.position = new Vector3(2, 10, 0);
            }
            if (stoneSpawn.position.x < -3)
            {
                stoneSpawn.position = new Vector3(-2, 10, 0);
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
