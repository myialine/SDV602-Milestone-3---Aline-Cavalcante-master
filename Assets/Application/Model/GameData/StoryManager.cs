using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager 
{
   public string Story;
   public InputField CommandInput;
   public Text storyText;
   public Text warningText;

   Room currentRoom = new Room();
   public string command;
   public string previousComand;
   

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
                }else if(previousComand == currentRoom.briefingRoom.description){
                    storyScene = "Do you want the computer to kill you? Make a decision!";
                }else{
                    storyScene = "Too late to go back now. Finish the mission";
                }
               previousComand = storyScene;
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
               case "":
               break;
               case "":
               break;
               case "":
               break;
               case "":
               break;
               case "":
               break;
               case "":
               break;
               case "":
               break;
               case "":
               break;
               case "":
               break;
               case "":
               break;
               case "":
               break;
               default:
               break;
               
           }
       }else if(command != null && command == "kill"){
           switch(command){
               case "Allyss":
               break;

               case "Krueger":
               break;
               
               default:

               break;
           }

       }else if(command != null && command == "pick"){
           switch(command){
               case "grenade":
               break;

               case "card":
               break;

               default:
               break;

           }
           

       }else{
           warningText.text = "";
       }
       storyText.GetComponent<Text>().text = command + "/n" + storyScene;

      
   }
   




}
