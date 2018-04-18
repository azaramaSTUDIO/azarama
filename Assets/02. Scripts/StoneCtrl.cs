﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCtrl : MonoBehaviour {

    private Rigidbody rb;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.velocity = Vector3.down * PlayerCtrl.speed * 2;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
    }
}
