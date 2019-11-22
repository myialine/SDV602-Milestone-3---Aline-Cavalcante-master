using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    JSONDropService jSONDrop = new JSONDropService {Token = "4c2630f1-635f-46d1-8dbc-52cf2167c01a"};
    public DatabaseManager DB = new DatabaseManager("Player");
    private string pUsername, pEmail, pPassword, startingRoom;
    public Text promptText;
    
    public void Register(string userName, string userEmail, string userPassword, string currentRoom){
          userName = pUsername;
          userEmail = pEmail;
          userPassword = pPassword;
          currentRoom = startingRoom;

          PlayerExists(pUsername);
          
          jSONDrop.Store<Player, JsnReceiver>( new List<Player>{
              new Player{ PlayerName = userName, PlayerPassword = userPassword, PlayerEmail = userEmail, currentRoom = GameModel.currentRoom.bedroom.description}
          }, jsnReceiverDel);
        
    }

    public void Login(string pUsername,string pPassword){
        jSONDrop.Select<Player, JsnReceiver>("PlayerName = '"+pUsername+"' AND  PlayerPassword = '"+pPassword+"'", jsnReceiverDel_CorrectLogin, jsnReceiverDel_IncorrectLogin);
        
    }

    public void PlayerExists(string Username){
        jSONDrop.Select<Player, JsnReceiver>("PlayerName = '" + pUsername + "'", JsnReceiverDel_PlayerExists, JsnReceiverDel_CreatePlayer);

    }

    public void JsnReceiverDel_PlayerExists(List<Player> pReceivedList){
        promptText.text = "Username taken! Try a different one.";
        
    }

    public void JsnReceiverDel_CreatePlayer(JsnReceiver pReceived){
        if(pReceived.Msg.Contains("Nothing selected from")){
            Room bedroom = new Room();
            jSONDrop.Store<Player, JsnReceiver>(new List<Player>
            {
                new Player{
                    PlayerName =  pUsername, PlayerPassword = pPassword, currentRoom = GameModel.currentRoom.bedroom.description
                }
            }, jsnReceiverDel_CheckRegistrationSuccess);
                
            
        }else{
            promptText.text = "Database error: Request could not be processed.";

        }
    }

    public void jsnReceiverDel_CheckRegistrationSuccess(JsnReceiver pReceived){
    
        if(pReceived.JsnMsg.Contains("SUCCESS")){
            promptText.text = "Registration successful";
        }else{
            promptText.text = "Registration failed. Try again";
        }
    }
    public void jsnReceiverDel(JsnReceiver pReceived)
    {
        Debug.Log(pReceived.JsnMsg + " ..." + pReceived.Msg);
        // To do: parse and produce an appropriate response
    }

    public void jsnListReceiverDel(List<Player> pReceived)
    {
        Debug.Log("Received items " + pReceived.Count());
        foreach (Player lcReceived in pReceived)
        {
            Debug.Log("Received {" + lcReceived.PlayerName + "," + lcReceived.PlayerPassword + "," + lcReceived.PlayerEmail+ "," + lcReceived.currentRoom +"}");
        }// for

        
    }

    public void jsnReceiverDel_CorrectLogin(List<Player> pReceived){
        GameManager.instance.currentPlayer.PlayerName = pUsername;
        SceneManager.LoadScene("GameMain");

    }

    public void jsnReceiverDel_IncorrectLogin(JsnReceiver pReceived){
        if(pReceived.Msg.Contains("Nothing selected from")){
            promptText.text = "Login information incorrect";
        }else{
            promptText.text = "Error: database could not process the request";
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        #region Test jsn drop
        JSONDropService jsDrop = new JSONDropService { Token = "4c2630f1-635f-46d1-8dbc-52cf2167c01a" };
        
        // Create table Player
        jsDrop.Create<Player, JsnReceiver>(new Player
        {
            PlayerName = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            PlayerPassword = "***********************************************",
            PlayerEmail = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            currentRoom = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
        }, jsnReceiverDel);

        //Store Player records
        jsDrop.Store<Player,JsnReceiver> (new List<Player>
        {
            new Player{PlayerName = "Jack",PlayerPassword = "12345",PlayerEmail ="player@player.com"},
            new Player{PlayerName = "Jonny",PlayerPassword = "54321",PlayerEmail ="player1@player.com"},
            new Player{PlayerName = "Jill",PlayerPassword = "2345678",PlayerEmail ="player2@player.com"}
         }, jsnReceiverDel);
        
        // // Retreive all player records
        //jsDrop.All<Player, JsnReceiver>(jsnListReceiverDel, jsnReceiverDel);
        
        //jsDrop.Select<Player,JsnReceiver>("HighScore > 200",jsnListReceiverDel, jsnReceiverDel);
        
        //jsDrop.Delete<Player, JsnReceiver>("PersonID = 'Jonny'", jsnReceiverDel);

        //jsDrop.Drop<Player, JsnReceiver>(jsnReceiverDel);
        #endregion

    }

    
}
