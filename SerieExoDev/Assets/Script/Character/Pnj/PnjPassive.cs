using UnityEngine;
using UnityEngine.AI;

public class PnjPassive : PnjOrigin
{
    public float _randomRadius = 5f;
    public float _moveInterval = 3f;
    private float _timer = 0f;


    protected override void Comportement()
    {
        _timer += Time.deltaTime;
        if (_timer >= _moveInterval)
        {
            _timer = 0f;
            Vector3 randomPos = transform.position + Random.insideUnitSphere * _randomRadius;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPos, out hit, _randomRadius, NavMesh.AllAreas))
                _agent.SetDestination(hit.position);
        }
    }
}
