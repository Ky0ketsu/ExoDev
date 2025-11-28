using UnityEngine;

[ExecuteAlways]
public class PnjEditor : MonoBehaviour
{
    [SerializeField]
    PnjOrigin _pnj;

    [SerializeField, Range(0, 2)]
    int _currentTypes;

    [SerializeField]
    GameObject[] _body;

    [SerializeField]
    GameObject _graphics;


    private void Update()
    {
        SetType();
    }

    

    void DefinePnjOrigin()
    {
        _pnj = GetComponent<PnjOrigin>();
        _pnj._pnjType = _currentTypes;
    }

    // A Rework
    void SetGraphics()
    {
        if(_graphics == null)
        {
            Debug.LogWarning("Pas de graphics");
            return;
        }

        DestroyImmediate(_graphics.transform.GetChild(0).gameObject);

        if (_body[_currentTypes] == null) Debug.Log("Pas de corp");
        Instantiate(_body[_currentTypes], _graphics.transform);
        _graphics.transform.GetChild(0).gameObject.layer = 3;
    }

    void SetType()
    {
        if (_pnj == null)
        {
            if (GetComponent<PnjOrigin>() == null)
            {
                _currentTypes = 0;
                gameObject.AddComponent<PnjPassive>();
                DefinePnjOrigin();
            }
            else _pnj = GetComponent<PnjOrigin>();
        }
        else
        {
            if (_currentTypes != _pnj._pnjType)
            {
                DestroyImmediate(_pnj);
                if (_currentTypes == 0) gameObject.AddComponent<PnjPassive>();
                if (_currentTypes == 1) gameObject.AddComponent<PnjFuyant>();
                if (_currentTypes == 2) gameObject.AddComponent<PnjAgressive>();
                DefinePnjOrigin();
                SetGraphics();
            }
        }
    }
}
