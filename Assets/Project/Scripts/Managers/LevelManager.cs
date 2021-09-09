using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _movableUnitPrefab;
    [SerializeField] private GameObject _dropUnitPrefab;
    [SerializeField] private Canvas _canvasParent;
    [SerializeField] private Transform _boardParent;
    [SerializeField] private Transform _scrollView;

    private ScoreHandler _score;


   
    
    private void InitDropUnit(int i, Vector3 pos, bool IsDropped)
    {
        GameObject dropUnit = Instantiate(_dropUnitPrefab, _boardParent.transform);
        dropUnit.GetComponent<DropUnit>().InitUnit(i,pos,IsDropped);
    }

    private void InitMovableUnit(int i,bool IsDropped)
    {
        if (!IsDropped)
        {
            GameObject movableUnit = Instantiate(_movableUnitPrefab, _scrollView.transform);
            movableUnit.GetComponent<MovableUnit>().InitUnit(i, _canvasParent, _scrollView);
        }
    }
    
    public void InitLevel(List<Tuple<bool, Vector3>> objects)
    {
        _score = new ScoreHandler(objects.Count, 0);
        _score.InitScore(objects);
        
        for (int i = 0; i < objects.Count; i++)
        {
            InitDropUnit(i,objects[i].Item2, objects[i].Item1);
            InitMovableUnit(i,objects[i].Item1);
        }
    }
    

    public void PlusScore(int unitId)
    {
        _score.PlusScore(unitId);
    }
    
    public void ToGallery()
    {
        GameManager.Instance.OnPlayButton();
    }
}
