using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poderzinho : MonoBehaviour
{

    public int id;
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();

        if (id == 1)
        {
            player._onSuperSpeed = true;
            player.OnSpeed();
        }
        else if (id == 2)
        {
            player._onSuperJump = true;
            player.OnJump();
        }


        Destroy(this.gameObject);
    }
}

