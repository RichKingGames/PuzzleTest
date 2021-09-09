using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletePanel : MonoBehaviour
{
    public void RestartLevel()
    {
        GameManager.Instance.StartLevel(GameManager.Instance.CurrentLevel);
        
    }

    public void ToGallery()
    {
        GameManager.Instance.OnPlayButton();
    }
}
