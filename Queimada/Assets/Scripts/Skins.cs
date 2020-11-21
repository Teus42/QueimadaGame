using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skins : MonoBehaviour
{
    [Header("Skins Settings")]
    public Text skins;
    public Text skins1;
    public Text skins2;
    public Text skins3;
    public Text _desbloqueio;
    public GameObject _pnl_skins;
    public GameObject pnl_pontosInsuficientes;
    public GameObject pnl_sucesso;
    private int pontos,priceAlvins = 5000, priceGer = 10000;
    private bool _temp1,_temp2;
    
    void Update()
    {        
        pontos = PlayerPrefs.GetInt("pontos");
        skins.text = "Pontos   " + pontos.ToString();

        if(PlayerPrefs.GetInt("skin") == 1)
        {
            skins1.color = Color.green;
            skins2.color = Color.red;
            skins3.color = Color.red;
        }
        if(PlayerPrefs.GetInt("skin") == 2)
        {
            skins2.color = Color.green;
            skins3.color = Color.red;
            skins1.color = Color.red;

        }
        if(PlayerPrefs.GetInt("skin") == 3)
        {
            skins3.color = Color.green;
            skins2.color = Color.red;
            skins1.color = Color.red;
        }
        Debug.Log("PONTOS: "+PlayerPrefs.GetInt("pontos"));
    }

    public void skin()
    {
        PlayerPrefs.SetInt("skin",1);
    }
    public void skin2()
    {
        if(PlayerPrefs.GetInt("liberadoA") == 1)
        {
            PlayerPrefs.SetInt("skin",2);
        }
        else
        {
            _temp1 = true; 
            abrirPNLskins();                       
        }        
    }
    public void skin3()
    {
        if(PlayerPrefs.GetInt("liberadoB") == 1)
        {
            PlayerPrefs.SetInt("skin",3);
        }
        else
        {
            _temp2 = true;
            abrirPNLskins();            
        }  
    }

    public void desbloquearSkin()
    {
        int _tempPontos = 0;
        int p = PlayerPrefs.GetInt("pontos");

        if(_temp1)
        {
            _tempPontos = priceAlvins;
        } 
        if(_temp2)
        {
            _tempPontos = priceGer;    
        } 

        if(p >= _tempPontos)
        {               
            if(_temp1)
            {
                p = p - _tempPontos;
                PlayerPrefs.SetInt("liberadoA",1); 
                pnl_sucesso.SetActive(true); 
                PlayerPrefs.SetInt("pontos",p); 
            } 
            if(_temp2)
            {
                p = p - _tempPontos;
                PlayerPrefs.SetInt("liberadoB",1);
                pnl_sucesso.SetActive(true);
                PlayerPrefs.SetInt("pontos",p);                   
            }             
        }else
        {
            pnl_pontosInsuficientes.SetActive(true);
        }
        Debug.Log("_tempPontos: "+_tempPontos);
              
    }

    public void abrirPNLskins()
    {
        if(_temp1)
        {
            _desbloqueio.text = "Deseja     desbloquear    o    Alvins    por    "+priceAlvins+"    pontos";
            _pnl_skins.SetActive(true);
        }
        if(_temp2)
        {
            _desbloqueio.text = "Deseja    desbloquear    a    Gertudres    por   "+priceGer+"    pontos";
            _pnl_skins.SetActive(true);
        }
        
    }

    public void fecharPNLskins()
    {
        _temp1 = false;
        _temp2 = false;
        _pnl_skins.SetActive(false);
        pnl_pontosInsuficientes.SetActive(false);
        pnl_sucesso.SetActive(false); 
    }
}
