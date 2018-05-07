using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCtrl : ObjCtrl
{
    public override void OnEnable()
    {


        if (PlayerCtrl.score > 10000)
            rb.velocity = Vector3.down * PlayerCtrl.speed * 2 + Vector3.right * Random.Range(-1.0f, 1.0f);
        else
            rb.velocity = Vector3.down * PlayerCtrl.speed * 2;
    }

}
