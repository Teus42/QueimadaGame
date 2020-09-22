using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

public class LookCamMulti : NetworkBehaviour
{
   private Vector2 look;    
    private Vector2 lookG;    
    private float xRotation = 0f;

    [Header("Aim Look Settings")]
    public Transform playerBody;    
    public float sense = 100f;
    public float gamepadSense = 100f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }    
    void Update()
    {           
        LookMovement();        
        //LookMovementControl();        
    }

    void LookMovement()
    {   
        var mouse = Mouse.current;
        if(mouse != null) 
        {   
            look = mouse.delta.ReadValue(); 
        }      
             
        look *=  sense * Time.deltaTime;

        xRotation -= look.y;
        xRotation = Mathf.Clamp(xRotation, -5f, 10f);       
    
        this.gameObject.transform.localRotation = Quaternion.Euler(xRotation, 0f,0f);
        this.playerBody.Rotate(Vector3.up * look.x);     
    }
    void LookMovementControl()
    {   
        var gamepad = Gamepad.current;
        
        if(gamepad != null)
        { 
            Debug.Log(""+gamepad.name);
            lookG = gamepad.rightStick.ReadValue();
        }else
        {
            Debug.Log("Sem gamepad conectado");
            return;
        }
        
        
        lookG *= gamepadSense * Time.deltaTime;

        xRotation -= lookG.y;
        xRotation = Mathf.Clamp(xRotation, -50f, 50f);

        //transform.localRotation = Quaternion.Euler(xRotation, 0f,0f);
        //playerBody.Rotate(Vector3.up * lookG.x);
    }
}

