using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [SerializeField, Header("vitesse de la balle")]
    private float _speed;

    [HideInInspector]
    private Rigidbody _rb;

    private void Start()
    {
        //EventService 

        if(GetComponent<Rigidbody>() == null) _rb = transform.AddComponent<Rigidbody>();
        else _rb = GetComponent<Rigidbody>();

        _rb.linearVelocity = Vector3.up * _speed;
    }

    private void Update()
    {
        //CheckSpeed();
        if (transform.position.y <= -4.5) GameServicesLocator.Get<GameService>().Defeat();
    }

    void CheckSpeed()
    {
      
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<Brick>())
        {
            other.GetComponentInParent<Brick>().Attack();
        }

        if(other.GetComponentInParent<PaddleMove>())
        {
            SetAngle(other.transform.position.x);
        }
    }

    void SetAngle(float paddle)
    {
        _rb.linearVelocity = (Vector3.up + (Vector3.right * -(paddle - transform.position.x)) * 3 ).normalized * _speed;
    }

    void SplitBall()
    {
        Instantiate(gameObject, transform.position, Quaternion.identity);
    }

}
