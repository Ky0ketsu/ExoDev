using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [Header("Pièces a vèrifier")]
    public RotationCheck[] _pieces;

    public bool _puzzleSolved = false;

    [Header("Porte a ouvrir")]
    public DoorOpener _door;

    private void Update()
    {
        if (_puzzleSolved) return;

        foreach (var piece in _pieces)
        {
            if (!piece.IsCorrect())
                return;
        }

        _puzzleSolved = true;
        Debug.Log("Puzzle réussi !");
        _door.OpenDoor();
    }
}
