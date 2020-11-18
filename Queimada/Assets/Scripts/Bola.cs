using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class Bola : MonoBehaviour
{
    [Header("Ball Settings")]
    public Text pointText;
    public int pontuacao;
    private float ballVelocity;
    private Vector3 _posPrev;
   
  
    void Update()
    {
        pointText.text = $"Pontuação: {pontuacao}";
        PlayerPrefs.SetInt("pontos", pontuacao);
    }
    
    void FixedUpdate()
    {        
        ballVelocity = ((transform.position - _posPrev).magnitude) / Time.deltaTime; 
        _posPrev = transform.position;   
    }

    
    int bVida = 15;  //Boss
   
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {        
            pontuacao += 100;
            pointText.text = $"Pontuação: {pontuacao}";             
            Destroy(other.gameObject);            
        }

        if(other.gameObject.tag == "Boss")
        {       
            bVida--;
            if(bVida == 0)
            {
                Destroy(other.gameObject);  
                pontuacao += 500;
                pointText.text = $"Pontuação: {pontuacao}";   
            }                             
        }     
    }
}

