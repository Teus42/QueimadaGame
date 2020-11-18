using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castelo : MonoBehaviour
{
    [Header("Castelo Settings")]
    public Text vida;
    public GameObject gameOver;
    private int _casteloVida = 100;


    void Update()
    {
        Debug.Log("Vida do Castelo = "+_casteloVida);
        vida.text = "Vida do Castelo = "+_casteloVida.ToString(); 

        if(_casteloVida <= 0)
        {
            gameOver.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision other) 
    {
        
        if(other.gameObject.tag == "Enemy")
        {
            _casteloVida = _casteloVida - 5;
            Destroy(other.gameObject);            
        }
        if(other.gameObject.tag == "Boss")
        {
            _casteloVida = _casteloVida - 50;
            Destroy(other.gameObject);            
        }   
    }
}
