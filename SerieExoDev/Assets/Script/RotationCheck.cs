using UnityEngine;

public class RotationCheck : MonoBehaviour
{
    [Header("Rotation cible")]

    public Vector3 _targetRotation;

    [Header("Tolèrance d'erreur")]
    public float _tolerance = 5f;

    public bool IsCorrect()
    {
        Vector3 current = transform.eulerAngles;

        return Mathf.Abs(Mathf.DeltaAngle(current.x, _targetRotation.x)) <= _tolerance &&
               Mathf.Abs(Mathf.DeltaAngle(current.y, _targetRotation.y)) <= _tolerance &&
               Mathf.Abs(Mathf.DeltaAngle(current.z, _targetRotation.z)) <= _tolerance;
    }

    private void Update()
    {
        if (transform.GetComponent<ObjectRotator>()._isFinish == true)
        {
            PerfectRota();
        }

    }

    public void PerfectRota()
    {
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, _targetRotation, Time.deltaTime * 2);
    }
}
