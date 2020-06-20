using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;
    public GameObject target2;
    public Vector3 cameraOffset;
    public float zoomLevel = 10.0f;
    public float minDistanceBeforeZoom = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target2 == null)
        {
            var targetPos = target.transform.position;
            gameObject.transform.position = targetPos + cameraOffset;
            gameObject.transform.LookAt(target.transform);
        }
        else
        {
            var t1 = target.transform.position;
            var t2 = target2.transform.position;
            var distance = Vector3.Distance(t1, t2);
            var avg = (t1 + t2) / 2;
            var offsetMult = distance < minDistanceBeforeZoom ? 1.0 : ((distance - minDistanceBeforeZoom) / zoomLevel) + 1;

            gameObject.transform.position = avg + cameraOffset * (float)Math.Sqrt(offsetMult);
            gameObject.transform.LookAt(avg);
        }
    }
}
