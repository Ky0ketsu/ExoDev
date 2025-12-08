using UnityEngine;

public interface IScoreService
{
    void AddScore(int score);
}

public class ScoreService : MonoBehaviour
{
    [SerializeField]
    public int _score;

    private void Awake()
    {
        GameServicesLocator.Register(this);
    }

    public void AddScore(int score)
    {
        _score += score;
    }
}
