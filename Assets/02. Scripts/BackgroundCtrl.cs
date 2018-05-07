using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCtrl : MonoBehaviour {

    private Vector3 startPos = new Vector3(0.0f, 24.0f, 5.0f);
    private Vector3 endPos = new Vector3(0.0f, -25.0f, 5.0f);

	// Use this for initialization
	void Start () {

        Move();

    }

    public void Move()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", endPos, "speed", 2.0f, "easetype", iTween.EaseType.linear, "oncomplete", "Restart", "oncompletetarget", gameObject));
    }

    public void Restart()
    {
        transform.position = startPos;
        Move();
    }
}
