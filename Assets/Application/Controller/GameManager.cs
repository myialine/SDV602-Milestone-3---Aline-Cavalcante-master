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
    public string PlayerPassword;
    public double score;
    public DatabaseManager database;
    public JSONDropService JSON = null;

    private int previousMsgCount;
    private int lcChatMsgCount;
    private bool isChatUpdated;

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
        JSON = new JSONDropService{Token = "4c2630f1-635f-46d1-8dbc-52cf2167c01a"};
        string place = "Room = " + curentRoom + "";
        JSON.Select<ChatData, JsnReceiver>(place, chatMsgCount, ChatMsgFail);

        if(instance == null){
            instance = this;
        }

        database = new DatabaseManager ("Paranoia.db");
    }
    private float chatMsgUpdate = 1.2f, lastMsgUpdate = 0.0f;
    
    void Update(){        
        
    }

    public void Story(){
        
        GameModel.RoomNavigation();
    }

    #region Chat management
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

    void UpdateChat(List<ChatData> chatMsgList){
        for(int i = previousMsgCount; i < chatMsgList.Count; i++){
            ChatData message = chatMsgList[i];
            if(message.nameOfPlayer == PlayerUsername) continue;
            string conversation = string.Format("[{0}]: {1}", message.nameOfPlayer, message.conversation);
            chatInput.Send(conversation);
        }
        previousMsgCount = chatMsgList.Count;
    }
    #endregion   
}
