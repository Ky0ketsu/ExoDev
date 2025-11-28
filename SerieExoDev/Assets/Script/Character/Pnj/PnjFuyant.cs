using UnityEngine;

public class PnjFuyant : PnjOrigin
{
    public float _moveDistance = 10f;


    protected override void Comportement()
    {
        if (CanSeePlayer())
        {
            Vector3 _wantedDir = (transform.position - _player.position).normalized;
            Vector3 _wantedPosition = transform.position + _wantedDir * _moveDistance;
            _agent.SetDestination(_wantedPosition);
        }
    }
}
