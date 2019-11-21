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
           #region Switch between rooms that you can go
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
               case "stop":
                if(previousComand == currentRoom.briefingRoomGrenade.description){
                    storyScene = currentRoom.briefingStopFight.description;
                    previousComand = currentRoom.briefingRoomGrenade.briefingStopFight.description;

                }else if(previousComand == currentRoom.briefingRoomCard.description){
                    storyScene = currentRoom.briefingStopFight.description;
                    previousComand = currentRoom.briefingRoomCard.briefingStopFight.description;
                }else{
                    storyScene = currentRoom.CantGoBack.description;
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
                    previousComand = storyScene;

                }else if(previousComand == currentRoom.briefingRoomGrenade.briefingStopFight.description){
                    storyScene = currentRoom.briefingRoomGrenade.briefingStopFight.serverBasement.description;
                    previousComand = storyScene;
                }else if(previousComand == currentRoom.briefingRoomCard.briefingStopFight.description){
                    storyScene = currentRoom.briefingRoomCard.briefingStopFight.serverBasement.description;
                    previousComand = storyScene;

                }else{
                    storyScene = currentRoom.CantGoBack.description;
                }                
               break;              

               case "red":
               if(previousComand == currentRoom.briefingRoomGrenade.briefingKillAlyss.serverBasement.description){
                   storyScene = currentRoom.briefingRoomGrenade.briefingKillAlyss.redDoorRoom.description;
                   previousComand = storyScene;
               }else if(previousComand == currentRoom.briefingRoomGrenade.briefingKillKrueger.serverBasement.description){
                   storyScene = currentRoom.briefingRoomGrenade.briefingKillKrueger.redDoorRoom.description;
                   previousComand = storyScene;

               }else if(previousComand == currentRoom.briefingRoomCard.briefingKillAlyss.serverBasement.description){
                   storyScene = currentRoom.briefingRoomCard.briefingKillAlyss.redDoorRoom.description;
                   previousComand = storyScene;

               }else if(previousComand == currentRoom.briefingRoomCard.briefingKillKrueger.description){
                   storyScene = currentRoom.briefingRoomCard.briefingKillKrueger.redDoorRoom.description;
                   previousComand = storyScene;

               }else if(previousComand == currentRoom.briefingRoomGrenade.briefingStopFight.description){
                   storyScene = currentRoom.briefingRoomGrenade.briefingStopFight.redDoorRoom.description;
                   previousComand = storyScene;
                   
               }else if(previousComand == currentRoom.briefingRoomCard.briefingStopFight.description){
                   storyScene = currentRoom.briefingRoomCard.briefingStopFight.redDoorRoom.description;
                   previousComand = storyScene;
               }else{
                   storyScene = currentRoom.CantGoBack.description;
               }
               break;

               default:
               storyScene = "Invalid input";
               break;
               
           }
           #endregion
        
          
       }else if(command != null && command == "kill"){
           #region "Kill" 
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
                    storyScene = currentRoom.briefingKillKrueger.description;
                    previousComand = currentRoom.briefingRoomGrenade.briefingKillKrueger.description;

                }else if(previousComand == currentRoom.briefingRoomCard.description){
                     storyScene = currentRoom.briefingKillKrueger.description;
                     previousComand = currentRoom.briefingRoomCard.briefingKillKrueger.description;   
                }else{
                    storyScene = currentRoom.CantGoBack.description;
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
        
        
       }else if(command != null && command == "pick"){
           #region "Pick"
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
        
        
       }else if(command != null && command == "talk"){
           #region "Talk" - Endgame
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
        
        
       }else if(command != null && command == "fight"){
           #region "Fight" - Endgame
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
        
        
       }else if(command !=null && command == "open"){
           #region  "Open" - Engame
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
       }else{
           warningText.text = "Something went wrong...";
       }
       storyText.GetComponent<Text>().text = command + "/n" + storyScene;

      
   }
   




}
