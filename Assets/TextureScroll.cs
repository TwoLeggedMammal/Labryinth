using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour
{
    public float xSpeed = 0.5f;
    public float ySpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * xSpeed, Time.time * ySpeed);
    }
}
