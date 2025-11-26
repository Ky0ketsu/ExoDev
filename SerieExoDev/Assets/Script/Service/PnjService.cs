using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class PnjService : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> _pnjLoad;

    public List<GameObject> _pnjRessource;

    [HideInInspector]
    PnjOrigin _currentPNJ;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            SpawnPNJ();
        }
        
        if(Input.GetKeyDown(KeyCode.P))
        {
            DespawnPNJ();
        }
    }

    void SpawnPNJ()
    {   
        _pnjLoad.Add( Instantiate(_pnjRessource[ UnityEngine.Random.Range(0, _pnjRessource.Count) ]));
        _currentPNJ = _pnjLoad[_pnjLoad.Count - 1].GetComponent<PnjOrigin>();
        SetType(_currentPNJ, true, 0);
    }

    void DespawnPNJ()
    {
        if (_pnjLoad[_pnjLoad.Count - 1] != null)
        {
            Destroy(_pnjLoad[_pnjLoad.Count - 1]);
            _pnjLoad.Remove(_pnjLoad[_pnjLoad.Count - 1]);
        }
    }

    void SetType(PnjOrigin pnj, bool random, int types)
    {
        if (random == true)
        {
            pnj._pnjType = UnityEngine.Random.Range(0, 2);
        }
        else
        {
            pnj._pnjType = types;
        }
    }

   

}
