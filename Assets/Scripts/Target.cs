using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Target : MonoBehaviour
{
    public int point;
    public Text textPoint;
    G
    void Start()
    {
        textPoint.text = point.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CannonBall"))
        {
            HitByCannonBall();
        }
    }

    void HitByCannonBall()
    {
        
        Destroy(gameObject);
    }
}
