using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCtrl : ObjCtrl
{
    private Transform player;
    public float speed = 3.0f;
    public bool magnet;
    public Vector3 disvec;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public override void OnEnable()
    {
        rb.velocity = Vector3.down * PlayerCtrl.speed;
    }

    // Update is called once per frame
    public override void Update()
    {

        if (tr.position.y <= -5.0f) gameObject.SetActive(false);

        if (PlayerCtrl.magnet)
        {
            disvec = (player.position - this.gameObject.transform.position).normalized;
            gameObject.transform.position += disvec * Time.deltaTime * speed;
            gameObject.transform.up = disvec;
            tr.Rotate(rot * Time.deltaTime);
        }
        else
        {
            tr.Rotate(rot * Time.deltaTime);
        }
    }
}
