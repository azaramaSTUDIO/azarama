using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesCtrl : ObjCtrl
{
    public override void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        rot = new Vector3(90.0f, 0.0f, 0.0f);
    }

    public override void OnEnable()
    {
        rb.velocity = Vector3.down * PlayerCtrl.speed;

        if (PlayerCtrl.score > 10000)
            tr.Rotate(Vector3.forward * Random.Range(-30.0f, 30.0f));
    }

}
