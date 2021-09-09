using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
///  The class of all movable units in game.
/// </summary>
public class DropUnit : MonoBehaviour, IDropHandler
{
    private int _id;
    private Image _image;
    public void InitUnit(int id, Vector3 pos,bool IsDropped)
    {
        _id = id;
        GetComponent<RectTransform>().anchoredPosition = pos;
        _image = GetComponent<Image>();
        _image.sprite = Resources.Load<Sprite>(id.ToString());
        

        if (IsDropped)
        {
            ChangeColorOnDropped();
        }
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            MovableUnit unit = eventData.pointerDrag.GetComponent<MovableUnit>();
            if (_id == unit.Id)
            {
                unit.IsDropped = true;
                
                GameManager.Instance.Level.PlusScore(_id);
                ChangeColorOnDropped();
                
                Destroy(unit.gameObject);
            }
        }
    }

    public void ChangeColorOnDropped()
    {
        Color color = _image.color;
        color.a = 1f;
        _image.color = color;
    }
    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
