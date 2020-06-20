using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    public float speed;
    float wiggleTimer = 0;
    public string upKey;
    public string downKey;
    public string leftKey;
    public string rightKey;
    public float wiggleSpeed;
    public float wiggleAmount;
    bool left = false;

    // Start is called before the first frame update
    void Start()
    {
        PositionOnFloor();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = gameObject.transform.position;
        bool moved = false;

        if (Input.GetKey(downKey))
        {
            pos = new Vector3(pos.x, pos.y, pos.z - Time.deltaTime * speed);
            moved = true;    
        }
        if (Input.GetKey(upKey))
        {
            pos = new Vector3(pos.x, pos.y, pos.z + Time.deltaTime * speed);
            moved = true;
        }
        if (Input.GetKey(leftKey))
        {
            pos = new Vector3(pos.x - Time.deltaTime * speed, pos.y, pos.z);
            moved = true;
            left = true;
        }
        if (Input.GetKey(rightKey))
        {
            pos = new Vector3(pos.x + Time.deltaTime * speed, pos.y, pos.z);
            moved = true;
            left = false;
        }

        gameObject.transform.position = pos;
        
        // Update wiggle
        if (moved)
        {
            wiggleTimer += Time.deltaTime;
        }
        else
        {
            wiggleTimer = 0;
        }

        var rot = (float)Math.Sin(wiggleTimer * wiggleSpeed);
        var quat = new Quaternion(0, 0, rot / wiggleAmount, 1);
        quat.Normalize();

        if (left)
        {
            quat = quat * Quaternion.AngleAxis(180, new Vector3(0, 1, 0));
        }

        gameObject.transform.rotation = quat;
    }

    void PositionOnFloor()
    {
        var position = gameObject.transform.position;
        var sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        var height = sprite.bounds.size.y / 2;
        gameObject.transform.position = new Vector3(position.x, height, position.z);
    }
}
