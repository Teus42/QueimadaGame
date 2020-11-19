using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pnl_dificuldade;
    public GameObject pnl_pause;
    public GameObject zumbi;

    void Start()
    {
        PlayerPrefs.SetInt("buscaPontos", 0);
    }
    public void Iniciar()
    {
        pnl_dificuldade.SetActive(true);
        zumbi.SetActive(false);
    }
    public void Voltar()
    {
        pnl_dificuldade.SetActive(false);
        zumbi.SetActive(true);

    }
    public void Normal()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("zVida",1);
        PlayerPrefs.SetInt("bVida",5);        
        PlayerPrefs.SetInt("cVida",100); 
        PlayerPrefs.SetString("Dificuldade", "Normal");      
        SceneManager.LoadScene("Jogo");
    }
    public void Dificil()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("zVida",3);
        PlayerPrefs.SetInt("bVida",15);        
        PlayerPrefs.SetInt("cVida",50);   
        PlayerPrefs.SetString("Dificuldade", "Dificil");    
        SceneManager.LoadScene("Jogo");
    }

    public void Skins()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Skins");
    }

    public void Exit()
    {
        Application.Quit();                
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void VoltarMenu()
    {
        Time.timeScale = 1;        
        SceneManager.LoadScene("Menu");        
    }   

    public void Restart()
    {
        Time.timeScale = 1;        
        SceneManager.LoadScene("Jogo");
    }
  
    public void Pausar()
    {     
        pnl_pause.SetActive(true);  
        Cursor.lockState = CursorLockMode.None;  
        Time.timeScale = 0;      
    }
    public void Retomar()
    {      
        pnl_pause.SetActive(false);   
        Time.timeScale = 1;       
        Cursor.lockState = CursorLockMode.Locked;     
    }     
}
