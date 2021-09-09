using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
///  The class of all movable units in game.
/// </summary>
public class MovableUnit : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas _canvasParent;
    [SerializeField] private Transform _scrollViewParent;

    private RectTransform _rect;
    private CanvasGroup _canvasGroup;

    public bool IsDropped = false;

    public int Id { get; private set; }    
   
    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    /// <summary>
    ///  The method that initialize movable unit.
    /// </summary>
    public void InitUnit(int id, Canvas parent, Transform scrollViewParent)
    {
        Id = id;
        _canvasParent = parent;
        _scrollViewParent = scrollViewParent;
        GetComponent<Image>().sprite = Resources.Load<Sprite>(id.ToString());
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(_canvasParent.transform);
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rect.anchoredPosition += eventData.delta / _canvasParent.scaleFactor;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        ResetPosition();
        _canvasGroup.blocksRaycasts = true;
    }

    public void ResetPosition()
    {
        if (!IsDropped)
        {
            _rect.SetParent(_scrollViewParent);
        }
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
