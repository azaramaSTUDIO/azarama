using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum ControlMode { mode1, mode2, mode3 };

public class PlayerCtrl : MonoBehaviour {

    [SerializeField] // (고급기술) private 변수이지만 인스펙터뷰에 나타나게 해줌
    private ControlMode controlMode = ControlMode.mode1;

    private Rigidbody rb;

    private Vector3 move = Vector3.right;

    public float movePower = 100.0f;

    public Text gameOverText;
    public AudioClip gameOverSfx;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
	}

    private void Start()
    {
        if (controlMode == ControlMode.mode3)
        {
            rb.useGravity = false;
            rb.velocity = new Vector3(2.0f, 0.0f, 0.0f);
        }
    }

    // Update is called once per frame
    void Update() {

        switch (controlMode)
        {
            case ControlMode.mode1:
                if (Input.GetMouseButtonDown(0))
                {
                    rb.velocity = Vector3.zero;
                    rb.AddForce(move * movePower);
                }
                break;

            case ControlMode.mode2:
                if (Input.GetMouseButtonDown(0))
                {
                    Physics.gravity *= -1.0f;
                }
                break;

            case ControlMode.mode3:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity *= -1.0f; 
                }
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameOverText.gameObject.SetActive(true);
        GameManager.instance.PlaySfx(gameObject.GetComponent<Transform>().position, gameOverSfx);
    }

}
