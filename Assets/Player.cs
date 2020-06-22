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
    public string jumpKey;
    public float wiggleSpeed;
    public float wiggleAmount;
    bool left = false;
    Rigidbody rigidbody;
    bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        PositionOnFloor();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = gameObject.transform.position;
        bool moved = false;
        var vel = new Vector3(0, rigidbody.velocity.y, 0);

        if (Input.GetKey(downKey))
        {
            vel.z = speed * -1;
            moved = true;    
        }
        if (Input.GetKey(upKey))
        {
            vel.z = speed;
            moved = true;
        }
        if (Input.GetKey(leftKey))
        {
            vel.x = speed * -1;
            moved = true;
            left = true;
        }
        if (Input.GetKey(rightKey))
        {
            vel.x = speed;
            moved = true;
            left = false;
        }

        if (Input.GetKey(jumpKey) && canJump)
        {
            vel.y = speed;
        }

        rigidbody.velocity = vel;

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

    private void OnCollisionEnter(Collision collision)
    {
        var a = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        canJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canJump = false;
    }
}
