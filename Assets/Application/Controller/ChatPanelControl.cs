using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatPanelControl : MonoBehaviour
{
   public GameObject chatPanel;
   public GameObject chatBtn;
   public GameObject menuBtn;

   public void ChatPanelOpen(){
       if(chatBtn != null && chatPanel != null && menuBtn != null){
           chatBtn.SetActive(false);
           menuBtn.SetActive(false);
           chatPanel.SetActive(true);
       }
   }

   public void ChatPaneClose(){
       if(chatBtn != null && chatPanel != null && menuBtn != null){
           chatBtn.SetActive(true);
           menuBtn.SetActive(true);
           chatPanel.SetActive(false);
       }
   }
}
