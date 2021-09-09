using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  The class that changing panels
/// </summary>
public class UiHandler : MonoBehaviour
{
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _levelSelectPanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _completePanel;
    [SerializeField] private GameObject _currentPanel;

    private void Awake()
    {
        _currentPanel = _mainPanel;
    }
    
    /// <summary>
    ///  The method that change current panel to Selected Panel by GameState
    /// </summary>
    public void SwitchCanvas()
    {
        _currentPanel.SetActive(false);

        switch (GameManager.Instance.State)
        {
            case GameState.MainMenu:
                _currentPanel = _mainPanel;
                break;
            case GameState.LevelSelect:
                _currentPanel = _levelSelectPanel;
                break;
            case GameState.Game:
                _currentPanel = _gamePanel;
                break;
            case GameState.Complete:
                _currentPanel = _completePanel;
                break;
        }

        _currentPanel.SetActive(true);
    }
}


