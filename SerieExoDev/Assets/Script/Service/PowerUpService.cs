using UnityEditor;
using UnityEngine;

public interface IPowerUpService
{
    void SpawnPowerUp(float chance, Vector3 pos);
}

public class PowerUpService : MonoBehaviour
{
    [SerializeField]
    GameObject[] _powerUp;

    public void Awake()
    {
        GameServicesLocator.Register(this);
    }

    public void SpawnPowerUp(float chance, Vector3 pos)
    {
        if(Random.Range(0, 100) < chance)
        {
            Instantiate(_powerUp[Random.Range(0, _powerUp.Length)], pos , Quaternion.identity);
        }
    }
}
