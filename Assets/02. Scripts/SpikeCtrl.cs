using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCtrl : MonoBehaviour
{

    private Rigidbody rb;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.velocity = Vector3.down * 1;
    }

    void Update()
    {
    }
}