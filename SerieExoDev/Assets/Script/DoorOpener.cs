using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [Header("Offset Ouverture")]
    public Vector3 _openOffset = new Vector3(0, 3f, 0);

    public float _speed = 2f;
    private bool _opening = false;
    private Vector3 _initialPos;
    private Vector3 _targetPos;

    private void Start()
    {
        _initialPos = transform.position;
        _targetPos = _initialPos + _openOffset;
    }

    public void OpenDoor()
    {
        _opening = true;
    }

    private void Update()
    {
        if (_opening)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);
        }
    }
}
