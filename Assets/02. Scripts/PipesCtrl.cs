using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesCtrl : MonoBehaviour {

    private Rigidbody rb;

    public float speed = 1.0f;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
	}

    void Start()
    {
        rb.velocity = Vector3.down * speed;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
