using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;

public class PlayerCtrl : MonoBehaviour {

    private int controlMode;

    private Rigidbody rb;

    private Vector3 move = Vector3.right;

    public float movePower = 100.0f;
    public float rotSpeed = 5.0f;
    public static int score, scoreFactor;
    public static int life;
    public static float speed;
    public static bool magnet = false;

    public Text scoreText;
    public Text lifeText;
    private bool gameOver;
    public Text gameOverText;
    public GameObject speedUpText;
    public Button gotoMainButton;
    public RawImage gameOverWhite;
    public AudioClip gameOverSfx, coinSfx, enemySfx;
    public Text finalScoreText;

    public GameObject[] characters;

    public Light lit;

    private Transform tr;

    public GameObject maginets;
    public GameObject UHD;

    // Use this for initializatio
    private void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        speed = 2.0f;
    }

    private void Start()
    {
        Debug.Log("Game Character is " + PlayerPrefs.GetInt("Character"));
        controlMode = PlayerPrefs.GetInt("Character");
        Instantiate(characters[PlayerPrefs.GetInt("Character")], gameObject.GetComponent<Transform>());

        magnet = false;
        score = 1;
        scoreFactor = 100;
        life = 3;
        lifeText.text = life.ToString();
        gameOver = false;
        if (controlMode == 2)
        {
            rb.useGravity = false;
            rb.velocity = new Vector3(2.0f, 0.0f, 0.0f);
        }
        rb.angularVelocity = Vector3.up * rotSpeed; // 캐릭터 회전시키기
    }

    // Update is called once per frame
    void Update() {

        if (!GameManager.instance.gameOver &&
            (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            switch (controlMode)
            {
                case 0:
                    rb.velocity = Vector3.zero;
                    rb.AddForce(move * movePower);
                    break;

                case 1:
                    Physics.gravity *= -1.0f;
                    break;

                case 2:
                    rb.velocity *= -1.0f;
                    if (rb.velocity.x > 0.0f)
                    {
                        rb.velocity = new Vector3(2.0f, 0.0f, 0.0f);
                    }
                    else
                    {
                        rb.velocity = new Vector3(-2.0f, 0.0f, 0.0f);
                    }
                    break;

                case 3:
                    rb.velocity = Vector3.zero;
                    Physics.gravity *= -1.0f;
                    if (Physics.gravity.x > 0)
                    {
                        movePower = Mathf.Abs(movePower) * -1.0f;
                    }
                    else
                    {
                        movePower = Mathf.Abs(movePower);
                    }
                    rb.AddForce(move * movePower);
                    break;
            }
        }
        if (!GameManager.instance.gameOver)
        {
            score += (int)(Time.deltaTime * 100);
            scoreText.text = score.ToString();
        }
        else
        {
            GetComponent<SphereCollider>().enabled = false;
        }

        if (score % 5000 == 0)
        {
            speed += 0.5f;
            scoreFactor += 50;
            StartCoroutine(SpeedUp5000());
        }

        lit.intensity += 0.003f * Time.deltaTime;

        if (tr.position.x > 4) tr.position = tr.position + Vector3.left * 8.0f;
        else if (tr.position.x < -4) tr.position = tr.position + Vector3.right * 8.0f;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score += 100;
            scoreText.text = score.ToString();
            GameManager.instance.PlaySfx(other.transform.position, coinSfx);
            other.gameObject.SetActive(false);
            StartCoroutine(ScoreUHD(tr, "+100", Color.yellow));
        }

        if (other.gameObject.CompareTag("Heart"))
        {
            life++;
            lifeText.text = life.ToString();
            GameManager.instance.PlaySfx(other.transform.position, coinSfx);
            other.gameObject.SetActive(false);
            StartCoroutine(ScoreUHD(tr, "+1 LIFE", Color.yellow));
        }
        if (other.gameObject.CompareTag("Magnet"))
        {
            StartCoroutine(MagnetItem());
            GameManager.instance.PlaySfx(other.transform.position, coinSfx);
            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life -= 1;
            lifeText.text = life.ToString();
            if (life <= 0) GameManager.instance.GameOver();
            GameManager.instance.PlaySfx(tr.position, enemySfx);
            StartCoroutine(ScoreUHD(tr, "-1 Life", Color.red));
            //collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("GameOverTrap"))
        {
            life = 0;
            lifeText.text = life.ToString();
            StartCoroutine(ScoreUHD(tr, "Dead", Color.red));
            GameManager.instance.GameOver();
        }
    }


    IEnumerator SpeedUp5000()
    {
        speedUpText.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        speedUpText.SetActive(false);
    }

    IEnumerator MagnetItem()
    {
        magnet = true;
        maginets.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        magnet = false;
        maginets.SetActive(false);
        StopCoroutine(MagnetItem());
    }

    IEnumerator ScoreUHD(Transform tr, string str, Color color)
    {
        UHD.SetActive(true);
        UHD.transform.position = tr.position + Vector3.down * 1.3f;
        iTween.MoveBy(UHD, iTween.Hash("y", 0.3f, "time", 1.0f, "easetype", iTween.EaseType.easeInSine));
        UHD.GetComponentInChildren<Text>().text = str;
        UHD.GetComponentInChildren<Text>().color = color;
        yield return new WaitForSeconds(1.0f);
        UHD.SetActive(false);
    }

    // 구글 플레이 스토어 랭킹 시스템 관련 코드

    public void Ranking()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Google OK");
                // Report 성공
                // 그에 따른 처리
            }
            else
            {
                Debug.Log("Google NO");
                // Report 실패
                // 그에 따른 처리
            }
        });
        

        string board = "";

        switch(PlayerPrefs.GetInt("Character"))
        {
            case 0:
                board = GPGSIds.leaderboard; // 흰색 아자라마 랭킹 보드
                break;
            case 1:
                board = GPGSIds.leaderboard_2; // 파란색 아자라마 랭킹 보드
                break;
            case 2:
                board = GPGSIds.leaderboard_3; // 녹색 아자라마 랭킹 보드
                break;
            case 3:
                board = GPGSIds.leaderboard_4; // 보라색 아자라마 랭킹 보드
                break;
        }

        PlayGamesPlatform.Instance.ReportScore(score, board, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Google Ranking OK");
                PlayGamesPlatform.Instance.ShowLeaderboardUI(board);
                // Report 성공
                // 그에 따른 처리
            }
            else
            {
                Debug.Log("Google Ranking NO");
                // Report 실패
                // 그에 따른 처리
            }
        });
        
    }

}
