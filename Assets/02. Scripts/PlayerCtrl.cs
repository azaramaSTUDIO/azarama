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

    public float movePower = 100.0f;
    public float rotSpeed = 5.0f;

    private float score;
    public Text scoreText;
    private bool gameOver;
    public Text gameOverText;
    public AudioClip gameOverSfx, coinSfx;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
	}

    private void Start()
    {
        score = 0;
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

        if (Input.GetMouseButtonDown(0))
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
                    movePower *= -1.0f;
                    rb.AddForce(move * movePower);
                    break;
            }
        }
        if (gameOver == false)
        {
            score += (int)(Time.deltaTime * 100);
            scoreText.text = score.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score += 100;
            GameManager.instance.PlaySfx(other.transform.position, coinSfx);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            gameOver = true;
            gameOverText.gameObject.SetActive(true);
            GameManager.instance.PlaySfx(gameObject.GetComponent<Transform>().position, gameOverSfx);
        }
    }

}
