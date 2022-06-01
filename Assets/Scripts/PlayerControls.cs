using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _flyingForce;
    [SerializeField] public LayerMask GroundLayerMask;
    [SerializeField] public Transform GroundCheck;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private bool _isGrounded = false;
    public IAnimatable animatable;
    public IFly fly;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        animatable = GetComponent<IAnimatable>();
        fly = GetComponent<IFly>();
    }
    private void Update()
    {
        _isGrounded = Physics.Linecast(transform.position, GroundCheck.position, GroundLayerMask);

        animatable.Idle();
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        Vector3 Movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);
        Movement.Normalize();
        Movement *= _speed;

        Movement = transform.transform.TransformDirection(Movement);

        _characterController.Move(Movement * Time.deltaTime);
        
        if (Movement != Vector3.zero   )
        {
            _player.transform.rotation = Quaternion.Slerp(_player.transform.rotation, Quaternion.LookRotation(Movement), Time.deltaTime * 5.0f);
        }
       
        if (verticalMovement > Mathf.Epsilon || horizontalMovement > Mathf.Epsilon)
        {
            animatable.Walk();
        }
        if (Input.GetButton("Jump") )
        {
            _velocity.y+=_flyingForce * Time.deltaTime;
            animatable.TakeOff();
        }
        if (Input.GetButtonUp("Jump"))
        {
            _velocity.y = 0;
        }
        if (_isGrounded == false && Movement!=Vector3.zero)
        {
            animatable.FlyForward();
        }
        if (Input.mousePosition.y >= Screen.height-10 && _isGrounded == false)
        {        
            fly.Dive();          
        }
        if (Input.mousePosition.y <= 0.5 && _isGrounded == false)
        {
            fly.Ascend();        
        }
     
        _characterController.Move(_velocity * Time.deltaTime);

    }
  
}
