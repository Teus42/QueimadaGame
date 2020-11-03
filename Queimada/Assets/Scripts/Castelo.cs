using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castelo : MonoBehaviour
{
    [Header("Castelo Settings")]
    public int _casteloVida = 10;

    void Update()
    {
        Debug.Log("Vida do Castelo = "+_casteloVida);
    }

    private void OnCollisionEnter(Collision other) 
    {
        
        if(other.gameObject.tag == "Enemy")
        {
            _casteloVida--;
            Destroy(other.gameObject);

            if(_casteloVida == 0)
            {
                Destroy(this.gameObject);
            }
        }   
    }
}
