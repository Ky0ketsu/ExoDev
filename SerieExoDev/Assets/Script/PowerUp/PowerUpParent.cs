using UnityEngine;

public abstract class PowerUpParent : MonoBehaviour
{
    [HideInInspector]
    protected Transform _paddle;

    public void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.GetComponentInParent<PaddleMove>())
        {

            _paddle = other.transform;
            ApplyEffect();
            
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    protected abstract void ApplyEffect();


    private void Update()
    {
        transform.position -= Vector3.up * Time.deltaTime;
    }
}
