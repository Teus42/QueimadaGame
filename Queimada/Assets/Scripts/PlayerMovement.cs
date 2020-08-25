using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character Settings")]   
    //public CharacterController controller;    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;   
    private Rigidbody _rb;
    private Transform playerTransform;   
    private bool isGrounded;
    private Vector3 velocity;

    [Header("Ball Area Settings")]
    public Transform areaCheck;
    public float areaDistance = 3f;
    public LayerMask playerMask;

    [SerializeField]
    private bool isOnArea;     
    
    [Header("Movement Settings")]
    public float speed = 7f;
    public float jump = 2f; 
    private Vector3 inputMove; 
    private Vector3 movement; 
    private GameObject mainCamera;
    
  

    
    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
        playerTransform = this.GetComponent<Transform>();        
        mainCamera = GameObject.Find("Main Camera");       
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance,groundMask);  
    }

    private void FixedUpdate()
    {   
        MovementPlayer();
        OnAreaBall();       
    }

    private void OnMovement(InputValue value)
    {   
        var v = value.Get<Vector2>();
        inputMove = new Vector3(v.x,0,v.y);               
    }

    private void OnJump(InputValue value)
    {
        if(isGrounded)
        {
            //_rb.AddForce(new Vector3(0,jump,0), ForceMode.Impulse);
            _rb.AddForce(Vector3.up * _rb.velocity.y, ForceMode.VelocityChange);
            _rb.AddForce(Vector3.up * jump, ForceMode.VelocityChange);
        }
    }

    private void OnShoot()
    {
        GetComponent<QueimadaBola>().Arremesar();
    }

    void MovementPlayer()
    {         
        movement = new Vector3(inputMove.x,0f,inputMove.z);    
        movement = movement * speed * Time.deltaTime;
        float facing = mainCamera.transform.eulerAngles.y;

        var cam = mainCamera.transform.forward;
        Debug.DrawRay(mainCamera.transform.position,cam * 12, Color.red);   

        Vector3 _relativeMovement = Quaternion.Euler(0,facing,0) * movement;

        _rb.MovePosition(playerTransform.position + _relativeMovement);
        
    }

    void OnAreaBall()
    {
        isOnArea = Physics.CheckSphere(areaCheck.position,areaDistance,playerMask);

        if(isOnArea)
        {
            Debug.Log("Perto da bola");
        }else
        {
            Debug.Log("Longe da bola");
        }
    }

    
    

}
