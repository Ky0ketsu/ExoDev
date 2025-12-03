using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    public bool _canMove;

    [SerializeField]
    float _speed;

    float _xMove, _yMove;
    Vector3 _moveWanted;

    void Start()
    {
        _canMove = true;
        if (_speed <= 0) _speed = 10;
    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") == Input.GetAxisRaw("Vertical") == false)
        {
            if (!_canMove) Debug.Log("Le joueur ne peut pas bouger");
            if (_speed == 0) Debug.Log("La vitesse du joueur est de 0");
        }

        if(_canMove) SetMove();
    }

    void SetMove()
    {
        _xMove = Input.GetAxisRaw("Horizontal");
        _yMove = Input.GetAxisRaw("Vertical");

        _moveWanted = (transform.forward * _yMove + transform.right * _xMove).normalized * _speed * Time.deltaTime;

        // ajouter un Lerp ***

        if(_moveWanted.magnitude > 0) ApplyMove();
    }

    void ApplyMove()
    {
        transform.position += _moveWanted;
    }
}
