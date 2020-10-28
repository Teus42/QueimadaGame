using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class Bola : MonoBehaviour
{
    [Header("Ball Settings")]
    public float ballVelocity;
    private Vector3 _posPrev;
    public Text pointText;
    public double pontuacao;
  
    void Start()
    {
        pointText.text = $"Pontuação: {pontuacao}";
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
            if (ballVelocity > 15)
                pontuacao += 10;
            pointText.text = $"Pontuação: {pontuacao}";
            other.gameObject.GetComponent<Renderer>().material.color = Color.red;   
        }
    }
}
