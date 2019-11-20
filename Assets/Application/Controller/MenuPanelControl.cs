using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanelControl : MonoBehaviour
{
    /*This class controls the panel and menu button on Game Main scene */
   public GameObject menuPanel;
   public GameObject menuButton;

   public void displayMenuPanel()
   {
       if(menuPanel != null && menuButton !=null)
       {
            menuPanel.SetActive(true);
            menuButton.SetActive(false);
       }
       
   }

   public void hideMenuPanel()
   {
       if(menuPanel != null && menuButton != null)
       {
            menuPanel.SetActive(false);
            menuButton.SetActive(true);
       }
      
   }
}
