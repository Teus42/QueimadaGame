using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zumbi : MonoBehaviour
{
    private int pontuacao;
    private int bVida, zVida; 
    private int _buscaPontos;
    
    void Start()
    {        
        bVida = PlayerPrefs.GetInt("bVida");  //Boss
        zVida = PlayerPrefs.GetInt("zVida");  //Zumbi
    }  

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bola")
        {
            if(this.gameObject.tag == "Enemy")
            {  
                zVida--;
                if(zVida == 0)
                {      
                    pontuacao += 100;
                    _buscaPontos = PlayerPrefs.GetInt("buscaPontos");                    
                    PlayerPrefs.SetInt("buscaPontos", _buscaPontos + pontuacao);             
                    Destroy(this.gameObject);            
                }
            }

            if(this.gameObject.tag == "Boss")
            {       
                bVida--;
                if(bVida == 0)
                {
                    pontuacao += 500; 
                    _buscaPontos = PlayerPrefs.GetInt("buscaPontos");                    
                    PlayerPrefs.SetInt("buscaPontos", _buscaPontos + pontuacao);
                    Destroy(this.gameObject);           
                }                             
            }
        }
    }


}
