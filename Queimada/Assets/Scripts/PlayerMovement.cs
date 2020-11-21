using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character Settings")]
    //public CharacterController controller;    
    public Text vida;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public GameObject skinMain;
    public GameObject skin2;
    public GameObject skin3;
    private Rigidbody _rb;
    private Transform playerTransform;
    private bool isGrounded;
    private Vector3 velocity;    
    private int _vida;

    [Header("Ball Area Settings")]
    public Transform areaCheck;
    public float areaDistance = 3f;
    public LayerMask playerMask;

    [SerializeField]
    private bool isOnArea;

    [Header("Movement Settings")]
    public bool _onSuperSpeed = false;
    public float speed = 2.8f;
    public bool _onSuperJump = false;
    public float jump = 1.5f;
    public Animator _anim;
    public Animator _anim2;
    public Animator _anim3;
    private Vector3 inputMove;
    private Vector3 movement;
    private GameObject mainCamera;
    private GameObject cMira;
    private bool isWalking;
    private bool isRunning;

    [Header("Pause Settings")]
    public GameObject GameController;




    void Start()
    {

        _rb = this.GetComponent<Rigidbody>();
        playerTransform = this.GetComponent<Transform>();
        mainCamera = GameObject.Find("Main Camera");
        cMira = GameObject.Find("Mira Cam");      
        //Arrumar Som
        FindObjectOfType<AudioManager>().Play("Passos");  
        
        if(PlayerPrefs.GetString("Dificuldade") == "Normal")
        {
            _vida = 3;
        }
        if(PlayerPrefs.GetString("Dificuldade") == "Dificil")
        {
            _vida = 2;
        }
        if(PlayerPrefs.GetString("Dificuldade") == "Rudolph")
        {
            _vida = 1;
        }
    }

    void Update()
    {
        vida.text = "Vida = "+_vida.ToString();
        SelecionarSkin();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (!isGrounded)
        {
            _anim.SetBool("Jump", true);
            _anim2.SetBool("Jump", true);
            _anim3.SetBool("Jump", true);
        }
        else
        {
            _anim.SetBool("Jump", false);
            _anim2.SetBool("Jump", false);
            _anim3.SetBool("Jump", false);
        }
        
        Debug.Log("Vida = "+_vida);
    }

    private void FixedUpdate()
    {
        MovementPlayer();
        Run();
        OnAreaBall();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            _vida--;
            if(_vida <= 0)
            {
                Castelo._gameOver = true;
            }
        }
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
                _rb.AddForce(Vector3.up * jump * 2.5f, ForceMode.VelocityChange);
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
    private void OnBola()
    {        
        GetComponent<QueimadaBola>().BuscarBola();
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
            movement = movement * speed * 2.5f * Time.deltaTime;
        }


        float facing = mainCamera.transform.eulerAngles.y;

        var cam = mainCamera.transform.forward;
        Debug.DrawRay(mainCamera.transform.position, cam * 12, Color.red);

        Vector3 _relativeMovement = Quaternion.Euler(0, facing, 0) * movement;

        _rb.MovePosition(playerTransform.position + _relativeMovement);
        if (inputMove.x != 0 || inputMove.z != 0)
        {
            _anim.SetBool("Walk", true);
            _anim2.SetBool("Walk", true);
            _anim3.SetBool("Walk", true);
        }
        else
        {
            _anim.SetBool("Walk", false);
            _anim2.SetBool("Walk", false);
            _anim3.SetBool("Walk", false);
        }
    }

    void Run()
    {        
        if (isRunning)
        {
            if (inputMove.x != 0 || inputMove.z != 0)
            {
                speed = 4.5f;
                _anim.SetBool("Run", true);
                _anim2.SetBool("Run", true);
                _anim3.SetBool("Run", true);
            } else
            {
                _anim.SetBool("Run", false);
                _anim2.SetBool("Run", false);
                _anim3.SetBool("Run", false);
            }          
        }            
        else
        {
            speed = 2.5f;
            _anim.SetBool("Run", false);
            _anim2.SetBool("Run", false);
            _anim3.SetBool("Run", false);
        }    
        //Debug.Log("Input X: "+inputMove.x+" Input Z: "+inputMove.z);
    }

    void OnAreaBall()
    {
        isOnArea = Physics.CheckSphere(areaCheck.position, areaDistance, playerMask);
        /*
        if (isOnArea)
        {
            Debug.Log("Perto da bola");
        }
        else
        {
            Debug.Log("Longe da bola");
        }
        */
    }

    private void OnPause()
    {
        GameController.GetComponent<Menu>().Pausar();
    }

    public void SelecionarSkin()
    {
        if(PlayerPrefs.GetInt("skin") == 1)
        {
            skinMain.SetActive(true);
            skin2.SetActive(false);
            skin3.SetActive(false);
        }
        if(PlayerPrefs.GetInt("skin") == 2)
        {
            skin2.SetActive(true);
            skin3.SetActive(false);
            skinMain.SetActive(false);
        }
        if(PlayerPrefs.GetInt("skin") == 3)
        {
            skin3.SetActive(true);
            skin2.SetActive(false);
            skinMain.SetActive(false);
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



