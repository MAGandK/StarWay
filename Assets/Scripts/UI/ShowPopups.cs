using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPopups : MonoBehaviour
{
    public static ShowPopups Instance;
    
    [SerializeField] private Transform _canvasParentTransform;
    [SerializeField]private GameObject _popupGameOver;
    private GameObject _currentPopup;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance =this;
        }
    }
    public void ShowPopup()
    {
        _currentPopup = Instantiate(_popupGameOver);
        _currentPopup.transform.SetParent(_canvasParentTransform, false);
    }

    public void ClosePopup()
    {
        if (_currentPopup != null)
        {
            _currentPopup.SetActive(false);
        }
    }

}
