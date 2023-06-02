using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _coinSpawner;

    private void Start()
    {
        _gamePanel.SetActive(false);
        _coinSpawner.SetActive(false);
    }

    public void Play(GameObject panel)
    {
        panel.SetActive(false);

        _gamePanel.SetActive(true);
        _coinSpawner.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
