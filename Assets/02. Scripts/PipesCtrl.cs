using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesCtrl : MonoBehaviour {

    private Rigidbody rb;
    
	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
	}

    void Start()
    {
        rb.velocity = Vector3.down * PlayerCtrl.speed;
    }


    public 

    // Update is called once per frame
    void Update()
    {

    }
}
