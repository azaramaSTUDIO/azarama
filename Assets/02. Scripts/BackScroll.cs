using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScroll : MonoBehaviour {

    public static float scrollSpeed = 1.5f;
    Material myMaterial;
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }
    void Update()
    {
        float newOffsetY = myMaterial.mainTextureOffset.y + scrollSpeed * Time.deltaTime;
        Vector2 newOffset = new Vector2(0, newOffsetY);
        myMaterial.mainTextureOffset = newOffset;
    }
}