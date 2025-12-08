using UnityEditor;
using UnityEngine;

public interface IBrickService
{
    public void RegenBrick();
    public void DestroyBrick();
    public void AddBrick();
    public void DelBrick();
}

public class BrickService : MonoBehaviour
{
    [SerializeField]
    int _CurrentBricks;

    private void Awake()
    {
        GameServicesLocator.Register(this);
    }

    public void RegenBrick()
    {
        EventService.InvokeBrickGenerate();
    }

    public void DestroyBrick()
    {
        EventService.InvokeBrickDestroy();
    }

    public void AddBrick()
    {
        _CurrentBricks++;
    }

    public void DelBrick()
    {
        _CurrentBricks--;
        if (_CurrentBricks == 0) GameServicesLocator.Get<GameService>().Win();
    }
}

/*#if UNITY_EDITOR
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
#endif*/
