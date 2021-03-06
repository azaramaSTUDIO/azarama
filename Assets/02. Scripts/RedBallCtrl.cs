﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallCtrl : MonoBehaviour
{
    private Rigidbody rb;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.velocity = Vector3.down * PlayerCtrl.speed * 2.5f;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(180, 180, 0) * Time.deltaTime);
    }
}
