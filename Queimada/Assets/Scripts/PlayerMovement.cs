﻿using System.Collections;
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
    public bool _onSuperSpeed = false;
    public float speed = 4f;
    public bool _onSuperJump = false;
    public float jump = 6f;
    public Animator _anim;
    private Vector3 inputMove;
    private Vector3 movement;
    private GameObject mainCamera;
    private bool isWalking;
    private bool isRunning;



    void Start()
    {

        _rb = this.GetComponent<Rigidbody>();
        playerTransform = this.GetComponent<Transform>();
        mainCamera = GameObject.Find("Main Camera");

    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded)
        {
            _anim.SetBool("Grounded", true);
        }
        else
        {
            _anim.SetBool("Grounded", false);
        }
    }

    private void FixedUpdate()
    {
        MovementPlayer();
        Run();
        OnAreaBall();
    }

    private void OnMovement(InputValue value)
    {
        var v = value.Get<Vector2>();
        inputMove = new Vector3(v.x, 0, v.y);
    }

    private void OnJump(InputValue value)
    {
        if (isGrounded)
        {
            if (_onSuperJump == false)
            {
                _rb.AddForce(Vector3.up * _rb.velocity.y, ForceMode.VelocityChange);
                _rb.AddForce(Vector3.up * jump, ForceMode.VelocityChange);
            }
            else if (_onSuperJump == true)
            {
                _rb.AddForce(Vector3.up * _rb.velocity.y, ForceMode.VelocityChange);
                _rb.AddForce(Vector3.up * jump * 3, ForceMode.VelocityChange);
            }
        }
    }
    private void OnRun(InputValue value)
    {
        if (value.isPressed)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }


    private void OnShoot()
    {
        GetComponent<QueimadaBola>().Arremesar();
    }

    void MovementPlayer()
    {
        movement = new Vector3(inputMove.x, 0f, inputMove.z);

        if (_onSuperSpeed == false)
        {
            movement = movement * speed * Time.deltaTime;
        }
        else if (_onSuperSpeed == true)
        {
            movement = movement * speed * 2 * Time.deltaTime;
        }


        float facing = mainCamera.transform.eulerAngles.y;

        var cam = mainCamera.transform.forward;
        Debug.DrawRay(mainCamera.transform.position, cam * 12, Color.red);

        Vector3 _relativeMovement = Quaternion.Euler(0, facing, 0) * movement;

        _rb.MovePosition(playerTransform.position + _relativeMovement);
        if (inputMove.x != 0 || inputMove.z != 0)
        {
            _anim.SetBool("Walk", true);
        }
        else
        {
            _anim.SetBool("Walk", false);
        }
    }

    void Run()
    {
        if (isRunning)
        {
            speed = 12f;
            _anim.SetBool("Run", true);
        }
        else
        {
            speed = 4f;
            _anim.SetBool("Run", false);
        }
    }

    void OnAreaBall()
    {
        isOnArea = Physics.CheckSphere(areaCheck.position, areaDistance, playerMask);

        if (isOnArea)
        {
            Debug.Log("Perto da bola");
        }
        else
        {
            Debug.Log("Longe da bola");
        }
    }

    // Corrotinas

    /* Super Speed  */
    public void OnSpeed()
    {

        StartCoroutine(SpeedCorroutine());
    }
    public IEnumerator SpeedCorroutine()
    {
        yield return new WaitForSeconds(5.0f);
        _onSuperSpeed = false;
    }


    /* Super Jump  */
    public void OnJump()
    {

        StartCoroutine(JumpCorroutine());
    }
    public IEnumerator JumpCorroutine()
    {
        yield return new WaitForSeconds(5.0f);
        _onSuperJump = false;
    }

}

