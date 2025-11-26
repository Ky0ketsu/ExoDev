using UnityEngine;
using UnityEngine.AI;

public class PnjOrigin : MonoBehaviour
{
    [HideInInspector]
    public int _pnjType;

    public Vector3 targetPosition;

    NavMeshAgent _agent;

    [SerializeField]
    public float _soundRadiusDetect;
    [SerializeField]
    public float _lookRadiusDetect;

    [HideInInspector]
    Transform _player;
    [SerializeField]
    Vector3 _PositionPlayer;




    private void Start()
    {
        if(_agent == null) _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //SoundDetectSphere();
        ViewDetectSphere();
    }

    public void SetDestination()
    { 
      if(ArrivedToDestination() == true)
      {

      }
    }

    bool ArrivedToDestination()
    {
        return (transform.position - targetPosition).magnitude < 2f;
    }
    
    void SoundDetectSphere()
    {
        if(Physics.CheckSphere(transform.position, _soundRadiusDetect, gameObject.layer = 6))
        {
            Gizmos.color = Color.green;   
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(transform.position, _soundRadiusDetect);
    }

    void ViewDetectSphere()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, _player.position - transform.position, out hit ,30f, gameObject.layer = 7))
        {
            Debug.DrawLine(transform.position, _player.position, Color.green, 0.5f);
            _PositionPlayer = _player.position;
        }
        else
        {
            Debug.DrawLine(transform.position, hit.point, Color.red, 0.5f);
        }
    }
}
