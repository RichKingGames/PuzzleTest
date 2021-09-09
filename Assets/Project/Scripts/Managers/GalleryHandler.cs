using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryHandler : MonoBehaviour
{ 
    private GalleryUnit[] _levels;
    
    [SerializeField] private Transform _initParent;
    [SerializeField] private GalleryUnit _unitPrefab;


    public void InitGallery()
    {
        bool[] Availability = GameManager.Instance.Json.GetAvailable();
        
        _levels = new GalleryUnit[Availability.Length];
        
        for (int i = 0; i < Availability.Length; i++)
        {
            GameObject tempObj = Instantiate(_unitPrefab.gameObject, _initParent);
            _levels[i] = tempObj.GetComponent<GalleryUnit>();
            _levels[i].Init(i,Availability[i]);
        }
    }
}
