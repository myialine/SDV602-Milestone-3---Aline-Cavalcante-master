using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using System.Linq;
using Newtonsoft.Json;


public class Room 
{
      
   //public static DataService ds = new DataService("Paranoia.db");
   private Player newPlayer = new Player();
   
   [SerializeField]
   private Room currentRoom;

   //This determines the amount of rooms on the array.
   private string roomDescriptions = "default";

   public string description
   {
       get {
           return roomDescriptions;
       } 
       set {
           bedroom.roomDescriptions = "";
           computerRoom.roomDescriptions = "";
           briefingRoom.roomDescriptions = "";

           briefingRoomGrenade.roomDescriptions = "";
           briefingRoomCard.roomDescriptions = "";

           briefingKillAlyss.roomDescriptions = "";
           briefingKillKrueger.roomDescriptions = "";
           briefingStopFight.roomDescriptions = "";

           serverBasement.roomDescriptions = "";

           openOrangeDoor.roomDescriptions = "";
           BlastOrangeDoor.roomDescriptions = "";
           ExplodeOrangeDoor.roomDescriptions = "";

           redDoorRoom.roomDescriptions = "";

           RedRoomTalkAlyssAlive.roomDescriptions = "";
           RedRoomTalkKruegerAlive.roomDescriptions = "";
           RedRoomTalkAllAlive.roomDescriptions = "";

           RedRoomFightAllyssAlive.roomDescriptions = "";
           RedRoomFightKruegerAlive.roomDescriptions = "";
           RedRoomFightAllAlive.roomDescriptions = "";

           CantGoBack.roomDescriptions = "You cannot go back. Live with your decisions";
        

       }
   }

    #region Listing Rooms
    public Room bedroom
    {
        get{
            return bedroom;
        }
        set{
            bedroom = value;
        }
    }

    public Room computerRoom
    {
        get{
            return computerRoom;
        }
        set{
            computerRoom = value;
        }
    }

    public Room briefingRoom
    {
        get{
            return briefingRoom;
        }
        set{
           briefingRoom = value;
        }
    }
    //Some paths depend on choices. Briefing room has two important choices changing the story
    public Room briefingRoomGrenade
    {
        get{
            return briefingRoomGrenade;
        }
        set{
            briefingRoomGrenade = value;
        }
    }

    public Room briefingRoomCard
    {
        get{
            return briefingRoomCard;
        }
        set{
            briefingRoomCard = value;
        }
    }

    public Room briefingKillAlyss
    {
        get{
            return briefingKillAlyss;
        }
        set{
            briefingKillAlyss = value;
        }
    }
    public Room briefingKillKrueger
    {
        get{
            return briefingKillKrueger;
        }
        set{
            briefingKillKrueger = value;
        }
    }
    
    public Room briefingStopFight
    {
        get{
            return briefingStopFight;
        }
        set{
            briefingStopFight = value;
        }
    }

    
    public Room serverBasement
    {
        get{
            return serverBasement;
        }
        set{
            serverBasement = value;
        }
    }

    public Room openOrangeDoor
    {
        get{
            return openOrangeDoor;
        }
        set{
            openOrangeDoor = value;
        }
    }

    //This one is tricky to organize the story around. Grenade, card and blaster
    public Room BlastOrangeDoor
    {
        get{
            return BlastOrangeDoor;
        }
        set{
            BlastOrangeDoor = value;
        }
    }

    public Room ExplodeOrangeDoor
    {
        get{
            return ExplodeOrangeDoor;
        }
        set{
            ExplodeOrangeDoor = value;
        }
    }

    public Room redDoorRoom
    {
        get{
            return redDoorRoom;
        }
        set{
            redDoorRoom = value;
        }
    }
    // Consequences of previous choices about Krueger and Allyss
    public Room RedRoomTalkAlyssAlive{
        get{
            return RedRoomTalkAlyssAlive;
        }
        set{
            RedRoomTalkAlyssAlive = value;
        }
    }
    public Room RedRoomTalkKruegerAlive{
        get{
            return RedRoomTalkKruegerAlive;
        }
        set{
            RedRoomTalkKruegerAlive = value;
        }
    }
    public Room RedRoomTalkAllAlive{
        get{
            return RedRoomTalkAllAlive;
        }
        set{
            RedRoomTalkAllAlive = value;
        }
    }

    public Room RedRoomFightAllyssAlive{
        get{
            return RedRoomFightAllyssAlive;
        }
        set{
            RedRoomFightAllyssAlive = value;
        }
    }
    public Room RedRoomFightKruegerAlive{
        get{
            return RedRoomFightKruegerAlive;
        }
        set{
            RedRoomFightKruegerAlive = value;
        }
    }
    public Room RedRoomFightAllAlive{
        get{
            return RedRoomFightAllAlive;
        }
        set{
            RedRoomFightAllAlive = value;
        }
    }
    public Room CantGoBack{
        get{
            return CantGoBack;
        }
        set{
            CantGoBack = value;
        }
    }
    public Room()
    {
        
    }

    
    #endregion

}
