using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var canvas = (Canvas)GameObject.FindObjectOfType<Canvas>();
        var text = (Text)canvas.transform.Find("Text").GetComponent<Text>();
        text.text = "YOU WIN!!!";
    }
}
