using UnityEngine;
using UnityEngine.AI;

public class PnjFuyant : PnjOrigin
{
    public float _fuiteDistance = 10f;
    public float _wanderRadius = 5f;
    public float _wanderInterval = 3f;
    private float _timer = 0f;


    protected override void Comportement()
    {
        if (CanSeePlayer())
        {
            Vector3 fleeDir = (transform.position - _player.position).normalized;
            Vector3 fleePos = transform.position + fleeDir * _fuiteDistance;
            _agent.SetDestination(fleePos);
        }
        else
        {
            _timer += Time.deltaTime;
            if (_timer >= _wanderInterval)
            {
                _timer = 0f;
                Vector3 randomPos = transform.position + Random.insideUnitSphere * _wanderRadius;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPos, out hit, _wanderRadius, NavMesh.AllAreas))
                    _agent.SetDestination(hit.position);
            }
        }
    }
}
