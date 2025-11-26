using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    float _speed;

    float _xRota, _yRota;
    Vector3 _rotaWanted;

    //Ajouter un _canLook ***

    [SerializeField]
    Transform _camera;

    private void Start()
    {
        if (_speed <= 0) _speed = 10;
    }

    private void Update()
    {
        WantedLook();
    }

    void WantedLook()
    {
        _xRota = -Input.GetAxis("Mouse Y");
        _yRota = Input.GetAxis("Mouse X");

        _rotaWanted = new Vector3(_xRota, _yRota, 0) * _speed * Time.deltaTime;

        if(_rotaWanted.sqrMagnitude > 0 ) ApplyLook();
    }

    void ApplyLook()
    {
        // Ajouter une limitate a la rotation ***

        transform.eulerAngles += new Vector3(0,_rotaWanted.y,0);
        _camera.localEulerAngles += new Vector3(_rotaWanted.x, 0, 0);
    }

}
