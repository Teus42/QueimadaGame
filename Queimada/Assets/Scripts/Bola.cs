using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    [Header("Ball Settings")]
    public float ballVelocity;
    private Vector3 _posPrev;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        ballVelocity = ((transform.position - _posPrev).magnitude) / Time.deltaTime; 
        _posPrev = transform.position;

        Debug.Log("Velocidade = "+ballVelocity.ToString("0"));
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {   
            if(ballVelocity > 15)         
            other.gameObject.GetComponent<Renderer>().material.color = Color.red;   
        }
    }
}
