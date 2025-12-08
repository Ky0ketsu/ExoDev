using UnityEngine;

public class PaddleMove : MonoBehaviour
{
    [SerializeField, Header("vitesse du paddle")]
    private float _speed;

    [SerializeField]
    bool _canMove;

    public float _xLimit;

    private void Update()
    {
        if (_canMove) Move();
    }

    void Move()
    {
        transform.position += Vector3.right * Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_xLimit, _xLimit), transform.position.y, transform.position.z);
    }
}
