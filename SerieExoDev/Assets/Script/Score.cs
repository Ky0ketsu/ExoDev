using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [HideInInspector]
    private int _score;

    private void Update()
    {
        if(GetComponentInChildren<TextMeshProUGUI>() == null) return;

        _score = GameServicesLocator.Get<ScoreService>()._score;
        GetComponentInChildren<TextMeshProUGUI>().text = _score.ToString();
    }
}
