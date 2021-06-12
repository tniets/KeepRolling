using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : ButtonHandler
{
    [SerializeField] private GameObject _gameObject;

    protected override void OnButtonClicked()
    {
        _gameObject.SetActive(!_gameObject.activeSelf);
    }
}
