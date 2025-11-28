using UnityEngine;

public class PnjAgressive : PnjOrigin
{
    public Transform[] _patrolPoints;
    private int _patrolIndex = 0;


    private enum State { Patrol, Chase }
    private State _state = State.Patrol;


    public float _chaseDuration = 3f;
    private float _losePositionTimer = 0f;


    protected override void Comportement()
    {
        switch (_state)
        {
            case State.Patrol: Patrol(); break;
            case State.Chase: Chase(); break;
        }
    }


    void Patrol()
    {
        if (_patrolPoints.Length == 0) return;
        _agent.SetDestination(_patrolPoints[_patrolIndex].position);

        if (_agent.remainingDistance < 0.5f) _patrolIndex = (_patrolIndex + 1) % _patrolPoints.Length;


        if (CanSeePlayer()) _state = State.Chase;
    }


    void Chase()
    {
        _agent.SetDestination(_player.position);


        if (!CanSeePlayer())
        {
            _losePositionTimer += Time.deltaTime;
            if (_losePositionTimer >= _chaseDuration)
            {
                _losePositionTimer = 0f;
                _state = State.Patrol;
            }
        }
        else _losePositionTimer = 0f;
    }
}
