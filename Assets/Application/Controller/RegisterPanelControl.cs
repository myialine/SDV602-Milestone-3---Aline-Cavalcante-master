using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanelControl : MonoBehaviour
{
    public GameObject LoginPanel;
    public GameObject registerPanel;

    public void DisplayLoginPanel()
    {
        if(LoginPanel != null)
        {
            LoginPanel.SetActive(true);
            registerPanel.SetActive(false);
        }
    }

    public void DisplayRegisterPanel()
    {
        if(registerPanel != null)
        {
            LoginPanel.SetActive(false);
            registerPanel.SetActive(true);
        }
    }
}
