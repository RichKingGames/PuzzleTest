using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler 
{
    private int _maxScore;
    private int _currentScore;

    public ScoreHandler(int maxScore, int currentScore)
    {
        _maxScore = maxScore;
        _currentScore = currentScore;
    }

    public void InitScore(List<Tuple<bool, Vector3>> objects)
    {

        _currentScore = 0;
        
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].Item1 == true)
            {
               
                _currentScore += 1;
                
            }
        }

        
    }
    public void PlusScore(int unitId)
    {
        _currentScore++;
        GameManager.Instance.Json.OverrideProgress(GameManager.Instance.CurrentLevel,unitId);

        // if we dropped all the units
        if (_currentScore == _maxScore)
        {
            GameManager.Instance.CompleteLevel();
        }
    }
}
