using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class Bola : MonoBehaviour
{
    [Header("Ball Settings")]
    public Text pointText;
    private string _showDificuldade;    
    private int _buscaPontos;
    private float ballVelocity;
    private Vector3 _posPrev; 
    private int _tempPontos;  
   
    void Update()
    {
        _buscaPontos = PlayerPrefs.GetInt("buscaPontos");
        
        pointText.text = "Pontuação: "+_buscaPontos.ToString();
        _tempPontos = PlayerPrefs.GetInt("pontos");         
       
        if(Castelo._gameOver == true)
        {
            PlayerPrefs.SetInt("pontos", _tempPontos + _buscaPontos);  
            PlayerPrefs.SetInt("buscaPontos", 0);  
        }

        Debug.Log("Pontos: "+ PlayerPrefs.GetInt("pontos"));
        Debug.Log("Busca Pontos: "+ PlayerPrefs.GetInt("buscaPontos"));
        Debug.Log("Temp Pontos: "+ _tempPontos);

    }
    
    void FixedUpdate()
    {        
        ballVelocity = ((transform.position - _posPrev).magnitude) / Time.deltaTime; 
        _posPrev = transform.position;   
    }     
   
}

