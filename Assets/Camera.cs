using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;
    public Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var targetPos = target.transform.position;
        gameObject.transform.position = targetPos + cameraOffset;
        gameObject.transform.LookAt(target.transform);
    }
}
