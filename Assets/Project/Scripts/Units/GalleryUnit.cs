using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryUnit : MonoBehaviour
{
    [SerializeField] private GameObject _lockImage;
    [SerializeField] private Button _button;

    private int _levelId;

    public void Init(int id, bool isAvailable)
    {
        _levelId = id;
        if (isAvailable)
        {
            _lockImage.SetActive(false);
            _button.interactable = true;
        }
        else
        {
            _lockImage.SetActive(true);
            _button.interactable = false;
        }
    }

    public void OnClick()
    {
        GameManager.Instance.StartLevel(_levelId);
    }

    private void OnDisable()
    {
        Destroy(this.gameObject);
    }
}
