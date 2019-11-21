using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryManager 
{
   public InputField CommandInput;
   public GameObject ResetStory;
   public Text storyText;
   public Text warningText;

   Room currentRoom = new Room();
   public string command;
   public string previousComand;
   
    /*
        This is just an attempt to have persistence on the story.
    */
   public void MakeStory(){
       
       command = CommandInput.GetComponent<Text>().text;
       InputManager inputManager = new InputManager();
       inputManager.commandParse(command);
       Room currentRoom = new Room();
       string storyScene = currentRoom.bedroom.description;
       previousComand = storyScene;

       if(command != null && command == "go"){           

           switch(command){
               case "bedroom":               
                if(previousComand == currentRoom.computerRoom.description){
                    storyScene = "You cannot go back to you room, don't be lazy!";
                    previousComand = currentRoom.computerRoom.description;

                }else if(previousComand == currentRoom.briefingRoom.description){
                    storyScene = "Do you want the computer to kill you? Make a decision!";
                    previousComand = currentRoom.briefingRoom.description;

                }else if(previousComand == currentRoom.briefingRoom.description){
                    storyScene = currentRoom.CantGoBack.description;
                    previousComand = currentRoom.briefingRoom.description;

                }else if(previousComand == currentRoom.serverBasement.description){
                    storyScene = currentRoom.CantGoBack.description;
                    previousComand = currentRoom.serverBasement.description;
                }
               break;

               case "computer room":
               storyScene = currentRoom.computerRoom.description;
               previousComand = storyScene; 
               break;

               case "briefing room":
                if(previousComand == currentRoom.computerRoom.description){
                    storyScene = currentRoom.briefingRoom.description;
                    previousComand = storyScene;
                }else{
                    storyScene = "What are you talking about?";
                    previousComand = currentRoom.briefingRoom.description;
                }               
               break;
               case "server":
                if(previousComand == currentRoom.briefingRoomGrenade.briefingKillAlyss.description){
                    storyScene = currentRoom.briefingRoomGrenade.briefingKillAlyss.serverBasement.description;
                    previousComand = storyScene;
                    
                }else if(previousComand == currentRoom.briefingRoomCard.briefingKillAlyss.description){
                    storyScene = currentRoom.briefingRoomCard.briefingKillAlyss.serverBasement.description;
                    previousComand = storyScene;
                    
                }else if(previousComand == currentRoom.briefingRoomGrenade.briefingKillKrueger.description){
                    storyScene = currentRoom.briefingRoomGrenade.briefingKillKrueger.serverBasement.description;
                    previousComand = storyScene;
                }else if(previousComand == currentRoom.briefingRoomCard.briefingKillKrueger.description){
                    storyScene = currentRoom.briefingRoomCard.briefingKillKrueger.serverBasement.description;
                }else{
                    storyScene = currentRoom.CantGoBack.description;
                }
                
               break;

              

               case "red":
               break;

               default:
               storyScene = "Invalid input";
               break;
               
           }
        #region "Kill"   
       }else if(command != null && command == "kill"){
           switch(command){
               case "Allyss":
                if(previousComand == currentRoom.briefingRoomGrenade.description){
                    storyScene = currentRoom.briefingKillAlyss.description;
                    previousComand = currentRoom.briefingRoomGrenade.briefingKillAlyss.description;

                }else if(previousComand == currentRoom.briefingRoomCard.description){
                    storyScene = currentRoom.briefingKillAlyss.description;
                    previousComand = currentRoom.briefingRoomCard.briefingKillAlyss.description;
                }else{
                    storyScene = currentRoom.CantGoBack.description;
                }
               break;

               case "Krueger":
                if(previousComand == currentRoom.briefingRoomGrenade.description){

                }else if(previousComand == currentRoom.briefingRoomCard.description){
                        
                }else{

                }
               break;
               
               default:
                if(previousComand == currentRoom.briefingRoomGrenade.description){
                    storyScene = "Invalid input";
                    previousComand = currentRoom.briefingRoomGrenade.description;

                }else if(previousComand == currentRoom.briefingRoomCard.description){
                    storyScene = "Invalid input";
                    previousComand = currentRoom.briefingRoomCard.description;
                }else{
                    storyScene = currentRoom.CantGoBack.description;
                }

               break;
           }
        #endregion
        
        #region "Pick"
       }else if(command != null && command == "pick"){
           switch(command){
               case "grenade":
                if(previousComand == currentRoom.briefingRoom.description){
                   storyScene = currentRoom.briefingRoomGrenade.description;
                   previousComand = storyScene;     
                }else{
                   storyScene = currentRoom.CantGoBack.description;
                   previousComand = currentRoom.briefingRoom.description;
                }
               break;

               case "card":
                if(previousComand == currentRoom.briefingRoom.description){
                    storyScene = currentRoom.briefingRoomCard.description;
                    previousComand = storyScene;
                }else{
                    storyScene = currentRoom.CantGoBack.description;
                    previousComand = currentRoom.briefingRoom.description;
                }
               break;

               default:
                storyScene = "Invalid Input";
               break;

           }
        #endregion   
        
        #region "Talk" - Endgame
       }else if(command != null && command == "talk"){
           if(previousComand == currentRoom.briefingRoomGrenade.briefingKillAlyss.redDoorRoom.description){
               storyScene = currentRoom.RedRoomTalkKruegerAlive.description;
               CommandInput.DeactivateInputField();
               ResetStory.SetActive(true);

           }else if(previousComand == currentRoom.briefingRoomGrenade.briefingKillKrueger.redDoorRoom.description){
               storyScene = currentRoom.RedRoomTalkAlyssAlive.description;
               CommandInput.DeactivateInputField();
               ResetStory.SetActive(true);

           }else if(previousComand == currentRoom.briefingRoomCard.briefingKillKrueger.redDoorRoom.description){
               storyScene = currentRoom.RedRoomTalkAlyssAlive.description;
               CommandInput.DeactivateInputField();
               ResetStory.SetActive(true);

           }else if(previousComand == currentRoom.briefingRoomCard.briefingKillAlyss.redDoorRoom.description){
               storyScene = currentRoom.RedRoomTalkKruegerAlive.description;
               CommandInput.DeactivateInputField();
               ResetStory.SetActive(true);

           }else if(previousComand == currentRoom.briefingRoomCard.briefingStopFight.redDoorRoom.description){
               storyScene = currentRoom.RedRoomTalkAllAlive.description;
               CommandInput.DeactivateInputField();
               ResetStory.SetActive(true);

           }else if(previousComand == currentRoom.briefingRoomGrenade.briefingStopFight.redDoorRoom.description){
               storyScene = currentRoom.RedRoomTalkAllAlive.description;
               CommandInput.DeactivateInputField();
               ResetStory.SetActive(true);

           }else{
               storyScene = "What was that?";
           }
        #endregion  
        
        #region "Fight" - Endgame
       }else if(command != null && command == "fight"){
           if(previousComand == currentRoom.briefingRoomGrenade.briefingKillAlyss.redDoorRoom.description){
               storyScene = currentRoom.briefingRoomGrenade.RedRoomFightKruegerAlive.description;
               CommandInput.DeactivateInputField();
               ResetStory.SetActive(true);

           }else if(previousComand == currentRoom.briefingRoomCard.briefingKillAlyss.redDoorRoom.description){
               storyScene = currentRoom.briefingRoomCard.RedRoomFightKruegerAlive.description;
               CommandInput.DeactivateInputField();
               ResetStory.SetActive(true);

           }else if(previousComand == currentRoom.briefingRoomCard.briefingKillKrueger.redDoorRoom.description){
               storyScene = currentRoom.briefingRoomCard.RedRoomFightAllyssAlive.description;
               CommandInput.DeactivateInputField();
               ResetStory.SetActive(true);

           }else if(previousComand == currentRoom.briefingRoomGrenade.briefingKillKrueger.redDoorRoom.description){
               storyScene = currentRoom.briefingRoomGrenade.RedRoomFightAllyssAlive.description;
               CommandInput.DeactivateInputField();
               ResetStory.SetActive(true);

           }else if(previousComand == currentRoom.briefingRoomCard.briefingStopFight.redDoorRoom.description){
               storyScene = currentRoom.briefingRoomCard.RedRoomFightAllAlive.description;
               CommandInput.DeactivateInputField();
               ResetStory.SetActive(true);

           }else if(previousComand == currentRoom.briefingRoomGrenade.briefingStopFight.redDoorRoom.description){
               storyScene = currentRoom.briefingRoomGrenade.RedRoomFightAllAlive.description;
               CommandInput.DeactivateInputField();
               ResetStory.SetActive(true);

           }else{
               storyScene = "Invalid command";
           }
        #endregion   
        
        #region  "Open" - Engame
       }else if(command !=null && command == "open"){
           if(previousComand == currentRoom.briefingRoomGrenade.briefingKillAlyss.serverBasement.description){
               storyScene = "Cannot open door without the card!";
               previousComand = currentRoom.briefingRoomGrenade.briefingKillAlyss.serverBasement.description;

           }else if(previousComand == currentRoom.briefingRoomGrenade.briefingKillKrueger.serverBasement.description){
               storyScene = "Cannot open door without the card!";
               previousComand = currentRoom.briefingRoomGrenade.briefingKillKrueger.serverBasement.description;

           }else if(previousComand == currentRoom.briefingRoomCard.briefingKillKrueger.serverBasement.description){
               storyScene = currentRoom.openOrangeDoor.description;
               CommandInput.DeactivateInputField();
               ResetStory.SetActive(true);

           }else if(previousComand == currentRoom.briefingRoomCard.briefingKillAlyss.serverBasement.description){
               storyScene = currentRoom.openOrangeDoor.description;
               CommandInput.DeactivateInputField();
               ResetStory.SetActive(true);

           }else if(previousComand == currentRoom.briefingRoomCard.briefingStopFight.serverBasement.description){
               storyScene = currentRoom.openOrangeDoor.description;
               CommandInput.DeactivateInputField();
               ResetStory.SetActive(true);
           }
        #endregion
       }
       
       else{
           warningText.text = "Something went wrong...";
       }
       storyText.GetComponent<Text>().text = command + "/n" + storyScene;

      
   }
   




}
