using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueimadaBola : MonoBehaviour
{
    private GameObject _ball;
    private Rigidbody _rbBall;    
    private GameObject _player;

    [Header("Throw Ball Settings")]
    public float forceThrow = 1000f;
    
    [SerializeField]
    private bool ballIn = false;
    
    


    private Vector3 onHands;    
    void Start()
    {
        
        _ball = GameObject.Find("Bola");
        _player = this.gameObject;
        _rbBall = _ball.GetComponent<Rigidbody>();
        onHands = new Vector3(1.5f,0.168f,0.05f);
        
                
    }

    // Update is called once per frame
    void Update()
    {
        var _face = _ball.transform.forward;
        Debug.DrawRay(_ball.transform.position,_face * 30, Color.green);   
    }  

    private void FixedUpdate() 
    {
        if(ballIn)
        {
            _ball.transform.localPosition = onHands;            
            _ball.transform.localRotation = Quaternion.Euler(0,0,0);
            _rbBall.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            _rbBall.isKinematic = true;           
        }    
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject == _ball)
        {
            _ball.transform.parent = _player.gameObject.transform;            
            ballIn = true;
        } 
    }

    public void Arremesar()
    {  

        float facing = _ball.transform.eulerAngles.y;      

        //Vector3 _relativeShoot = Quaternion.Euler(0,facing,0);

        if(ballIn)
        {                           
            _rbBall.isKinematic = false;
            _rbBall.collisionDetectionMode = CollisionDetectionMode.Continuous;
            _ball.transform.parent = null;
            _rbBall.AddForce(_ball.transform.forward * forceThrow);
            ballIn = false;           
        }
    }

    public void BuscarBola()
    {
        if(ballIn == false)
        {
            _ball.transform.parent = _player.gameObject.transform;            
            ballIn = true;
        }
    }   
}
