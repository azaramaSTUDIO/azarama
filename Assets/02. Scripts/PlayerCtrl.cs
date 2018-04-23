using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum ControlMode { mode1, mode2, mode3, mode4 };

public class PlayerCtrl : MonoBehaviour {

    [SerializeField] // (고급기술) private 변수이지만 인스펙터뷰에 나타나게 해줌
    private ControlMode controlMode = ControlMode.mode1;

    private Rigidbody rb;

    private Vector3 move = Vector3.right;

    bool speedUp_5000 = false;
    public float movePower = 100.0f;
    public float rotSpeed = 5.0f;
    public static int score;
    public static int life;
    public static float speed;

    public Text scoreText;
    public Text lifeText;
    private bool gameOver;
    public Text gameOverText;
    public GameObject speedUpText;
    public Button gotoMainButton;
    public RawImage gameOverWhite;
    public AudioClip gameOverSfx, coinSfx;
    public Text finalScoreText;

    // Use this for initializatio
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        speed = 1.5f;
    }

    private void Start()
    {
        score = 0;
        life = 3;
        lifeText.text = life.ToString();
        gameOver = false;
        if (controlMode == ControlMode.mode3)
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
                case ControlMode.mode1:
                    rb.velocity = Vector3.zero;
                    rb.AddForce(move * movePower);
                    break;

                case ControlMode.mode2:
                    Physics.gravity *= -1.0f;
                    break;

                case ControlMode.mode3:
                    rb.velocity *= -1.0f;
                    break;

                case ControlMode.mode4:
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
        if(score > 5000)
        {
            speed = 2.0f;
            StartCoroutine(SpeedUp5000());
        }
        if(speedUp_5000 == true)
        {
            StopCoroutine(SpeedUp5000());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score += 100;
            scoreText.text = score.ToString();
            GameManager.instance.PlaySfx(other.transform.position, coinSfx);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Heart"))
        {
            life++;
            lifeText.text = life.ToString();
            GameManager.instance.PlaySfx(other.transform.position, coinSfx);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life -= 1;
            lifeText.text = life.ToString();
            if (life <= 0) GameManager.instance.GameOver();

            //collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("GameOverTrap"))
        {
            life = 0;
            lifeText.text = life.ToString();
            GameManager.instance.GameOver();
        }
    }


    IEnumerator SpeedUp5000()
    {
        speedUpText.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        speedUpText.SetActive(false);
        speedUp_5000 = true;
    }

}
