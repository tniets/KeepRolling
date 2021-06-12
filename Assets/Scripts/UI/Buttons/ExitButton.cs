using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : ButtonHandler
{
    protected override void OnButtonClicked()
    {
        Application.Quit();
    }
}
