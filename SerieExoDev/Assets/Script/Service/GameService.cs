using UnityEngine;

public interface IGameService
{
    void Win();
    void Defeat();
}

public class GameService : MonoBehaviour
{
    private void Awake()
    {
        GameServicesLocator.Register(this);
    }

    public void Win()
    {
        GameServicesLocator.Get<MenuService>().ShowMenu(1);
    }

    public void Defeat()
    {
        GameServicesLocator.Get<MenuService>().ShowMenu(2);
    }
}
