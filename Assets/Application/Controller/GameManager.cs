using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text storyText;
    public Player currentPlayer;
    public Room curentRoom;
    public CommandInput chatInput;
    public string PlayerUsername;
    public DatabaseManager database;
    public JSONDropService JSON = null;

    private int previousMsgCount;
    private int lcChatMsgCount;
    private bool isChatUpdated;

    void Awake(){
         
        if(instance == null){
            instance = this;
        }
        //Chat info
        JSON = new JSONDropService{Token = "4c2630f1-635f-46d1-8dbc-52cf2167c01a"};
        string place = "Room = " + GameManager.instance.curentRoom + "";
        JSON.Select<ChatData, JsnReceiver>(place, chatMsgCount, ChatMsgFail);
        database = new DatabaseManager ("Paranoia.db");
    }
    private float chatMsgUpdate = 1.0f, lastMsgUpdate = 0.0f;
    
    void Update(){

        //
        if(Time.time > lastMsgUpdate + chatMsgUpdate){
            lastMsgUpdate = Time.time;
            string place = "Room" + GameManager.instance.curentRoom + GameManager.instance.currentPlayer;
            JSON.Select<ChatData, JsnReceiver>(place, chatMsgCount, ChatMsgFail);
        }
        
    }
   

    #region Chat management
    //count chat messages and updates list of messages
    void chatMsgCount(List<ChatData> chatMsgList){
        if(chatMsgList.Count != lcChatMsgCount && isChatUpdated){
            UpdateChat(chatMsgList);
        }

        if(!isChatUpdated){
            previousMsgCount = chatMsgList.Count;
            isChatUpdated = true;
        }

        lcChatMsgCount = chatMsgList.Count;
    }
    
    void ChatMsgFail(JsnReceiver pReceived){}

    //Updates chat
    void UpdateChat(List<ChatData> chatMsgList){
        for(int i = previousMsgCount; i < chatMsgList.Count; i++){
            ChatData message = chatMsgList[i];
            if(message.nameOfPlayer == GameManager.instance.PlayerUsername) continue;
            string conversation = string.Format("[{0}]: {1}", message.nameOfPlayer, message.conversation);
            chatInput.Send(conversation);
        }
        previousMsgCount = chatMsgList.Count;
    }
    #endregion   
}
