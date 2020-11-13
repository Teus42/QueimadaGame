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

        //Debug.Log("Velocidade = "+ballVelocity.ToString("0"));
        
    }

    
    int bVida = 3;  //Boss
   
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {        
            pontuacao += 10;
            pointText.text = $"Pontuação: {pontuacao}";             
            Destroy(other.gameObject);            
        }

        if(other.gameObject.tag == "Boss")
        {       
            bVida--;
            if(bVida == 0)
            {
                Destroy(other.gameObject);  
                pontuacao += 20;
                pointText.text = $"Pontuação: {pontuacao}";   
            }                             
        }     
    }
}

