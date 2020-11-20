using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{   
    [Header("IA Settings")]    
    public int ID_IA;
    private GameObject _player;
    private GameObject _castelo;
    private NavMeshAgent _agent; 

    
	void Start()
    {        
        _player = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
        _castelo = GameObject.FindGameObjectWithTag("Cast");
    }    
    void Update()
    {
        
        _castelo = GameObject.FindGameObjectWithTag("Cast");
        if(ID_IA == 1)
        {
            Perseguir(); 
        }
        if(ID_IA == 2)
        {        
            Atacar();  
        }        
              
    }

    //Persegue o Player
    public void Perseguir()
    {      
        _agent.SetDestination(_player.transform.position);         
    }   

    //Vai no Castelo
    public void Atacar()
    {
        _agent.SetDestination(_castelo.transform.position);
    }
    
    
}
