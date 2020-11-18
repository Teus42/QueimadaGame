using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Iniciar()
    {
        Time.timeScale = 1;
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
}
