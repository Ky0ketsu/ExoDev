using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    public bool _canMove;

    [SerializeField]
    float _speed;
    float _currentSpeed;

    float _xMove, _yMove;
    Vector3 _moveWanted;

    [SerializeField]
    private LayerMask _layerMask;

    [HideInInspector]
    CharacterController _controller;

    void Start()
    {
        _canMove = true;
        if (_speed <= 0) _speed = 10;
        _currentSpeed = _speed;
        if(GetComponent<CharacterController>()) _controller = GetComponent<CharacterController>();
        else _controller = transform.AddComponent<CharacterController>();

    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") == Input.GetAxisRaw("Vertical") == false)
        {
            if (!_canMove) Debug.Log("Le joueur ne peut pas bouger");
            if (_speed == 0) Debug.Log("La vitesse du joueur est de 0");
        }

        if(_canMove) SetMove();

        IsRunning();
    }

    bool IsRunning()
    {
        return Input.GetButton("Run");
    }

    void SetMove()
    {
        _xMove = Input.GetAxisRaw("Horizontal");
        _yMove = Input.GetAxisRaw("Vertical");

        if (IsRunning())
        {
            _currentSpeed = _speed * 1.7f;
        }
        else
        {
            _currentSpeed = _speed;
        }

            _moveWanted = (transform.forward * _yMove + transform.right * _xMove).normalized * _currentSpeed * Time.deltaTime;

        // ajouter un Lerp ***

        if(_moveWanted.magnitude > 0) ApplyMove();
    }

    void ApplyMove()
    {
        _controller.Move(_moveWanted);
    }
}
