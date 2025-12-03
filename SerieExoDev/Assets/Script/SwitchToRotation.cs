using UnityEngine;

public class SwitchToRotation : MonoBehaviour
{
    [Header("Références")]
    public Camera _cam;
    public PlayerMove _playerMove;
    public PlayerView _playerView;
    public ObjectRotator _currentRotator;

    [Header("Raycast")]
    public float _interactDistance = 3f;
    public LayerMask _interactLayer;

    private bool _isInPuzzle = false;

    void Update()
    {
        if (_currentRotator != null)
        {
            if (_currentRotator._isFinish)
            {
                ExitPuzzleMode();
                _currentRotator = null;
            }
        }
        

        if (!_isInPuzzle)
        {
            CheckForInteraction();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ExitPuzzleMode();
            }
        }
    }

    void CheckForInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, _interactDistance, _interactLayer))
            {
                ObjectRotator rot = hit.collider.GetComponent<ObjectRotator>();
                if (rot != null && rot._isFinish == false)
                {
                    EnterPuzzleMode(rot);
                }
            }
        }
    }

    void EnterPuzzleMode(ObjectRotator rot)
    {
        
        _currentRotator = rot;

        _playerMove._canMove = false;  
        _playerView._canView = false;
        _currentRotator.enabled = true;
        _isInPuzzle = true;
        _currentRotator._inPuzzle = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ExitPuzzleMode()
    {
        _currentRotator._inPuzzle = false;
        _isInPuzzle = false;

        _playerMove._canMove = true;
        _playerView._canView = true;
        _currentRotator.enabled = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
    
