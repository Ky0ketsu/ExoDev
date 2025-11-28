using System.Buffers.Text;
using UnityEngine;
using UnityEngine.AI;

public class PnjAgressive : PnjOrigin
{
    public Transform[] _patrolPoints;
    private int _patrolIndex = 0;

    public float _patrolRadius = 100f;
    public int _patrolPointCount = 5;
    private Vector3[] _patrolPath;

    private enum State { Patrol, Chase }
    private State state = State.Patrol;


    public float chaseDuration = 3f;
    private float loseLookTimer = 0f;


    void GeneratePatrolPath()
    {
        _patrolPath = new Vector3[_patrolPointCount];
        for (int i = 0; i < _patrolPointCount; i++)
        {
            Vector3 randomPos = transform.position + Random.insideUnitSphere * _patrolRadius;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPos, out hit, _patrolRadius, NavMesh.AllAreas))
                _patrolPath[i] = hit.position;
            else
                _patrolPath[i] = transform.position;
        }
    }


    protected override void Start()
    {
        base.Start();
        GeneratePatrolPath();
    }


    protected override void Comportement()
    {
        switch (state)
        {
            case State.Patrol: Patrol(); break;
            case State.Chase: Chase(); break;
        }
    }


    int patrolIndex = 0;


    void Patrol()
    {
        if (_patrolPath == null || _patrolPath.Length == 0) return;


        if (!_agent.hasPath || _agent.remainingDistance < 0.5f)
        {
            patrolIndex = (patrolIndex + 1) % _patrolPath.Length;
            _agent.SetDestination(_patrolPath[patrolIndex]);
        }


        if (CanSeePlayer()) state = State.Chase;
    }


    void Chase()
    {
        _agent.SetDestination(_player.position);


        if (!CanSeePlayer())
        {
            loseLookTimer += Time.deltaTime;
            if (loseLookTimer >= chaseDuration)
            {
                loseLookTimer = 0f;
                state = State.Patrol;
            }
        }
        else loseLookTimer = 0f;
    }
}

