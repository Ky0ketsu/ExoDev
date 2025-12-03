using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public float _rotationSpeed = 200f;
    private bool _dragging = false;

    public bool _inPuzzle;

    void OnEnable()
    {
        _dragging = false;
    }

    void Update()
    {
        if (!_inPuzzle) return;

        if (Input.GetMouseButtonDown(0))
            _dragging = true;

        if (Input.GetMouseButtonUp(0))
            _dragging = false;

        if (_dragging)
        {
            float rotX = Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;
            float rotY = -Input.GetAxis("Mouse Y") * _rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, rotX, Space.World);
            transform.Rotate(Vector3.right, rotY, Space.World);
        }
    }
}
