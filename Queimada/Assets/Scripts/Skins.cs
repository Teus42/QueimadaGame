using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skins : MonoBehaviour
{
    [Header("Skins Settings")]
    public Text skins;
    private int pontos;
    
    void Update()
    {
        pontos = PlayerPrefs.GetInt("pontos");
        skins.text = "Pontos: " + pontos.ToString();
    }
}
