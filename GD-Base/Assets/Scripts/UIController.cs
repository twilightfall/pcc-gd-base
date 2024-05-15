using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private string Name;
    private bool Status;

    [SerializeField]
    private TMP_Text DisplayNameTextBlock;
    [SerializeField]
    private TMP_Text DisplayStatusTextBlock;

    [SerializeField]
    private TMP_InputField NameInputField;

    [SerializeField]
    private Toggle OnlineToggle;
    [SerializeField]
    private Toggle InvisibleToggle;

    public void SetName()
    {
        Name = NameInputField.text;
    }

    public void SetStatus()
    {
        if (OnlineToggle.isOn)
        {
            Status = true;
        }
        else if (InvisibleToggle.isOn)
        {
            Status = false;
        }
    }

    public void OnButtonClick()
    {
        DisplayNameTextBlock.text = Name;
        DisplayStatusTextBlock.text = Status == true ? "Online" : "Away";
    }
}
