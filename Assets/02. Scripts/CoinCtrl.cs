using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCtrl : MonoBehaviour
{
    private Transform player;
    public float speed = 3.0f;
    public bool magnet;
    public Vector3 disvec;
    private Rigidbody rb;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.velocity = Vector3.down * PlayerCtrl.speed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCtrl.magnet)
        {
            disvec = (player.position - this.gameObject.transform.position).normalized;
            gameObject.transform.position += disvec * Time.deltaTime * speed;
            gameObject.transform.up = disvec;
        } else {
            transform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
        }
    }
}
