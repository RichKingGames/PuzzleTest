using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MainMenu = 0,
    LevelSelect = 1,
    Game = 2,
    Complete = 3
}

/// <summary>
///  The main class which start all process.
/// </summary>

public class GameManager : Singleton<GameManager>
{
    public JsonHandler Json ;
    public UiHandler UiManager;
    public GalleryHandler Gallery;
    public LevelManager Level;
    public GameState State { get; private set; }

    public int CurrentLevel;

    /// <summary>
    ///  The method that change current panel to Gallery Panel
    /// </summary>
    public void OnPlayButton()
    {
        State = GameState.LevelSelect;
        UiManager.SwitchCanvas();
        Gallery.InitGallery();
    }

    /// <summary>
    ///  The method that change current panel to Main Menu Panel
    /// </summary>
    public void OnSettingsButton()
    {
        State = GameState.MainMenu;
        UiManager.SwitchCanvas();
    }

    
    /// <summary>
    ///  The method that change current panel to Selected Level Panel
    /// </summary>
    public void StartLevel(int id)
    {
        CurrentLevel = id;
        State = GameState.Game;
        UiManager.SwitchCanvas();
        
        //Start initialize level
        Level.InitLevel(Json.GetLevelInfo(id));
    }

    /// <summary>
    ///  The method that change level panel to Complete Panel
    /// </summary>
    public void CompleteLevel()
    {
        // Zeroing progress of the current level
        Json.RestartLevel(CurrentLevel);
        // Opening next Level in Gallery
        Json.SetLevelAvailable(CurrentLevel+1);
        
        State = GameState.Complete;
        UiManager.SwitchCanvas();
    }

}
