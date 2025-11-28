using UnityEngine;
using UnityEngine.AI;

public abstract class PnjOrigin : MonoBehaviour
{
    [HideInInspector]
    public int _pnjType;

    protected NavMeshAgent _agent;
    [SerializeField]
    protected Transform _player;

    [Header("Vision Settings")] public float _viewDistance = 10f;
    public float _viewAngle = 60f;
    public LayerMask _obstacleMask;

    protected virtual void Start()
    {
        if (_agent == null) _agent = GetComponent<NavMeshAgent>();

        _player = GameObject.Find("PLAYER").transform;

        _obstacleMask = ~0;
    }

    protected virtual void Update()
    {
        Comportement();
    }

    protected abstract void Comportement();

    protected bool CanSeePlayer()
    {
        Vector3 dirToPlayer = (_player.position - transform.position).normalized;
        if (Vector3.Angle(transform.forward, dirToPlayer) < _viewAngle / 2f)
        {
            float dist = Vector3.Distance(transform.position, _player.position);
            if (!Physics.Raycast(transform.position, dirToPlayer, dist, _obstacleMask))
            {
                Debug.DrawLine(transform.position, _player.position,Color.green ,0.5f);
                return true;
            }
        }
        return false;
    }

}
