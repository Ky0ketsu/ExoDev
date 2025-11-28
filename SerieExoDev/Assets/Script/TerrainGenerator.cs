using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TerrainGenerator : MonoBehaviour
{
    [Header("Terrain Settings")]
    public int _gridSize = 100;                    
    public float _spacing = 1f;                    
    public GameObject _wallPrefab;                 
    public float _wallSpawnChance = 0.20f;          

    [Header("NavMesh")]
    public NavMeshSurface _navSurface;              

    private List<GameObject> _spawnedWalls = new List<GameObject>();


    public void GenerateTerrain()
    {
        ClearTerrain();

        if (_wallPrefab == null)
        {
            Debug.LogWarning("Aucun WallPrefab assigné !");
            return;
        }

        for (int x = 0; x < _gridSize; x++)
        {
            for (int z = 0; z < _gridSize; z++)
            {
                if (Random.value <= _wallSpawnChance)
                {
                    Vector3 pos = new Vector3(x * _spacing, 0, z * _spacing);
                    GameObject wall = Instantiate(_wallPrefab, transform);

                    wall.transform.localPosition = pos;
                    wall.transform.localRotation = Quaternion.Euler(0, Random.value > 0.5f ? 90f : 0f, 0);

                    _spawnedWalls.Add(wall);
                }
            }
        }

        if (_navSurface != null)
        {
            _navSurface.BuildNavMesh();
        }

        Debug.Log("Terrain régénéré !");
    }


    public void ClearTerrain()
    {
        for (int i = _spawnedWalls.Count - 1; i >= 0; i--)
        {
            if (_spawnedWalls[i] != null)
                DestroyImmediate(_spawnedWalls[i]);
        }

        _spawnedWalls.Clear();
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(TerrainGenerator))]
public class TerrainGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();


        TerrainGenerator gen = (TerrainGenerator)target;


        if (GUILayout.Button("Regenerer Terrain"))
        {
            gen.GenerateTerrain();
        }

        if (GUILayout.Button("Delete Terrain"))
        {
            gen.ClearTerrain();
        }
    }
}
#endif