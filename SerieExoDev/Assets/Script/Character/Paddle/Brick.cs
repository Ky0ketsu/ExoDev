using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField]
    bool isDestroy;

    [Header("Chance de faire apparaitre un PowerUp")]
    [SerializeField, Range(0, 100)]
    float _chance;

    [Header("Definit sa la bas necessite plusieur coup")]
    public bool _solid;
    public int _healtPoint;


    

    private void Update()
    {
        if(isDestroy) gameObject.SetActive(false);
        else gameObject.SetActive(true);
    }

    public void Attack()
    {
        if (!_solid) Destroy();
        else _healtPoint--;

        if(_healtPoint == 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        isDestroy = true;
        int point = 0;
        if (_solid) point = 30;
        else point = 10;
        GameServicesLocator.Get<ScoreService>().AddScore(point);
        GameServicesLocator.Get<BrickService>().DelBrick();
        GameServicesLocator.Get<PowerUpService>().SpawnPowerUp(_chance, transform.position);
    }

    public void Generate()
    {

    }

    public void Regen()
    {
        isDestroy = false;
        GameServicesLocator.Get<BrickService>().AddBrick();
    }

    private void Start()
    {
        GameServicesLocator.Get<BrickService>().AddBrick();
        EventService.OnBrickDestroy += Destroy;
        EventService.OnBrickGenerate += Generate;
    }

    private void OnDestroy()
    {
        EventService.OnBrickDestroy -= Destroy;
        EventService.OnBrickGenerate -= Generate;
    }
}
