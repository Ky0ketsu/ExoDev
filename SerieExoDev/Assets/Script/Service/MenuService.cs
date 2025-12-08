using UnityEngine;

public interface IMenuService
{
    void ShowMenu(int index);
}

public class MenuService : MonoBehaviour
{

    public GameObject[] _menu;
    public int _currentIndex;

    private void Start()
    {
        ShowMenu(0);
    }

    private void Awake()
    {
        GameServicesLocator.Register(this);
    }
    public void ShowMenu(int index)
    {
        if (index == _currentIndex) return;

        foreach(GameObject menu in _menu)
        {
            menu.SetActive(false);
        }

        _menu[index].SetActive(true);
        _currentIndex = index;
    }
    
}
