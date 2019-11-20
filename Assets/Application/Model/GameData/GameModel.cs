using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public static class GameModel 
{
    private static string playerName;
    private static Player aplayer = new Player();
    private static Room startingRoom;
    private static Room _currentRoom;

    //All the rooms in order.
    public enum Direction{bedroom, computerRoom, briefingRoom, briefingRoomGrenade, 
    briefingRoomCard, briefingKillAlyss, briefingKillKrueger, briefingStopFight, 
    serverBasement, openOrangeDoor, BlastOrangeDoor, ExplodeOrangeDoor, redDoorRoom, 
    RedRoomTalkAlyssAlive, RedRoomTalkKruegerAlive, RedRoomTalkAllAlive, RedRoomFightAllyssAlive, 
    RedRoomFightKruegerAlive, RedRoomFightAllAlive, CantGoBack};
    
    public static Room Starting_Room
    {
        get{
            return startingRoom;
        }
        set{
            startingRoom = value;
        }
    }

    public static string Name{
        get{
            return playerName;
        }
        set{
            playerName = value;
        }
    }

     public static Player currentPlayer
    {
        get{
            return aplayer;
        }
        set{
            aplayer = value;
        }
    }

    public static Room currentRoom{
        get{
            return _currentRoom;
        }

        set{
            _currentRoom = value;
        }
    }

    #region This is where the navigation and persistence are taken care of. Quite tricky
    public static void RoomNavigation(){

        Room temp;

        if(Room.ds.HaveRooms()){
            Room.LoadRooms();
           
        }else{
            startingRoom = new Room();
            temp = new Room();
            
            //I will use Room.Rooms[19] whenever the player tries to go back on the story to change decisions.

            //starting game - bedroom
            startingRoom = Room.Rooms[0];
            startingRoom.description = ""; 

            //Moving to Computer room.
            startingRoom.computerRoom = temp;
            temp = Room.Rooms[1];
            temp.bedroom.computerRoom.description = "";

            temp.computerRoom.bedroom = Room.Rooms[19]; //going back? NOPE!
            temp.computerRoom.bedroom.description = "No going back now. Don't chicken out! Go to the Briefing room";

            //moving to briefing room.
            temp.briefingRoom = new Room();
            temp = Room.Rooms[2];
            temp.description = "";
            temp.computerRoom = Room.Rooms[19]; //if you try to go back..
            temp.computerRoom.description = "Still thinking of going back to you mama? Go and finish your mission. Chose the card or the grenade";
            temp.bedroom = Room.Rooms[19];
            temp.bedroom.description = "Are you to afraid to work? Finish your mission, you lazy scum. Chose the card or the grenade";

        #region  #### Path of the grenade ####
            temp.briefingRoom.briefingRoomGrenade = new Room();
            temp = Room.Rooms[3];
            temp.description = "";
            temp.bedroom = Room.Rooms[19];
            temp.bedroom.description = "Sure, be lazy like that... NOT. Just finish you business already";
            temp.computerRoom = Room.Rooms[19];
            temp.computerRoom.description = "Still thinking of going back to you mama? Go and finish your mission.";
            temp.briefingRoom = Room.Rooms[19];
            temp.briefingRoom.description = "What are you talking about? You are at the Briefing Room!";

            #region #### Grenade, Kill Alyss, EndGame ###
            //Kill Allyss, try to go back, and endgame
            temp.briefingKillAlyss = new Room();
            temp = Room.Rooms[5];
            temp.description = "";
            
            temp.bedroom = Room.Rooms[19];
            temp.bedroom.description = "Feeling like going back to bed, you chicken? Just make the damn decision.";
            temp.computerRoom = Room.Rooms[19];
            temp.computerRoom.description = "Still thinking of going back to you mama? Go and make a decision.";
            temp.briefingRoom = Room.Rooms[19];
            temp.briefingRoom.description = "What are you talking about? You are at the Briefing Room!";
            
            temp.serverBasement = new Room();
            temp = Room.Rooms[8];
            temp.description = "";
            temp.bedroom = Room.Rooms[19];
            temp.bedroom.description = "";
            temp.computerRoom = Room.Rooms[19];
            temp.computerRoom.description = "";
            temp.briefingRoom = Room.Rooms[19];
            temp.briefingRoom.description = "";
                            
            //Endgame orange door part 1
            temp.BlastOrangeDoor = new Room();
            temp = Room.Rooms[10];
            temp.description = "";
            
            //Engame orange door part 2
            temp.ExplodeOrangeDoor = new Room();
            temp = Room.Rooms[11];
            temp.description = "";

            temp.redDoorRoom = new Room();
            temp = Room.Rooms[12];

            #endregion

            #region  ####Grenade, Kill Krueger, Endgame
            //Kill Krueger, try to go back, and endgame
            temp.briefingKillKrueger = new Room();
            temp = Room.Rooms[6];
            temp.description = "";
            temp.bedroom = Room.Rooms[19];
            temp.bedroom.description = "Feeling like going back to bed, you chicken? Just make the damn decision.";
            temp.computerRoom = Room.Rooms[19];
            temp.computerRoom.description = "Still thinking of going back to you mama? Go and make a decision.";
            temp.briefingRoom = Room.Rooms[19];
            temp.briefingRoom.description = "What are you talking about? You are at the Briefing Room!";
            


            #endregion
        
        #endregion
        
        #region  #### Path of the card ####
            temp.briefingRoom.briefingRoomCard = new Room();
            temp = Room.Rooms[4];
            temp.briefingRoomCard.description = "";
            temp.briefingRoomCard.computerRoom = Room.Rooms[19];
            temp.briefingRoomCard.computerRoom.description = "You can't go back to the computer room. Finish yout mission";

        #endregion


        }
        
    }

    #endregion  

}
