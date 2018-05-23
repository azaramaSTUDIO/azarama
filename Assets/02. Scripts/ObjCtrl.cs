using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCtrl : MonoBehaviour {

    protected Rigidbody rb;
    protected Transform tr;
    protected Vector3 rot = new Vector3(0.0f, 180.0f, 0.0f);


    // Use this for initialization
    public virtual void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    public virtual void OnEnable()
    {
        rb.velocity = Vector3.down * PlayerCtrl.speed;
    }

    public virtual void Update()
    {
        tr.Rotate(rot * Time.deltaTime);
        if (tr.position.y <= -5.0f || tr.position.x > 5.0f || tr.position.x < -5.0f) gameObject.SetActive(false);
    }

    public virtual void OnDisable()
    {
        tr.rotation = Quaternion.Euler(Vector3.zero);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

}
