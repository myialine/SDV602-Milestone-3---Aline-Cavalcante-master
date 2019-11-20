using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using System.Linq;

public class Room 
{
   
   public static List<Room> Rooms = new List<Room>();
   //public static DataService ds = new DataService("Paranoia.db");
   private Player newPlayer = new Player();
   private Room currentRoom;

   //This determines the amount of rooms on the array.
   private Room[] roomPaths = new Room[20];
   private string roomDescriptions = "default";

   public string description
   {
       get {
           return roomDescriptions;
       } 
       set {
           roomDescriptions = value;
       }
   }

    #region Listing Rooms
    public Room bedroom
    {
        get{
            return roomPaths[(int)GameModel.Direction.bedroom];
        }
        set{
            roomPaths[(int)GameModel.Direction.bedroom] = value;
        }
    }

    public Room computerRoom
    {
        get{
            return roomPaths[(int)GameModel.Direction.computerRoom];
        }
        set{
            roomPaths[(int)GameModel.Direction.computerRoom] = value;
        }
    }

    public Room briefingRoom
    {
        get{
            return roomPaths[(int)GameModel.Direction.briefingRoom];
        }
        set{
            roomPaths[(int)GameModel.Direction.briefingRoom] = value;
        }
    }
    //Some paths depend on choices. Briefing room has two important choices changing the story
    public Room briefingRoomGrenade
    {
        get{
            return roomPaths[(int)GameModel.Direction.briefingRoomGrenade];
        }
        set{
            roomPaths[(int)GameModel.Direction.briefingRoomGrenade] = value;
        }
    }

    public Room briefingRoomCard
    {
        get{
            return roomPaths[(int)GameModel.Direction.briefingRoomCard];
        }
        set{
            roomPaths[(int)GameModel.Direction.briefingRoomCard] = value;
        }
    }

    public Room briefingKillAlyss
    {
        get{
            return roomPaths[(int)GameModel.Direction.briefingKillAlyss];
        }
        set{
            roomPaths[(int)GameModel.Direction.briefingKillAlyss] = value;
        }
    }
    public Room briefingKillKrueger
    {
        get{
            return roomPaths[(int)GameModel.Direction.briefingKillKrueger];
        }
        set{
            roomPaths[(int)GameModel.Direction.briefingKillKrueger] = value;
        }
    }
    
    public Room briefingStopFight
    {
        get{
            return roomPaths[(int)GameModel.Direction.briefingStopFight];
        }
        set{
            roomPaths[(int)GameModel.Direction.briefingStopFight] = value;
        }
    }

    //This is were things get ugly. If you reckless, you die.
    public Room serverBasement
    {
        get{
            return roomPaths[(int)GameModel.Direction.serverBasement];
        }
        set{
            roomPaths[(int)GameModel.Direction.serverBasement] = value;
        }
    }

    public Room openOrangeDoor
    {
        get{
            return roomPaths[(int)GameModel.Direction.openOrangeDoor];
        }
        set{
            roomPaths[(int)GameModel.Direction.openOrangeDoor] = value;
        }
    }

    //This one is tricky to organize the story around. Grenade, card and blaster
    public Room BlastOrangeDoor
    {
        get{
            return roomPaths[(int)GameModel.Direction.BlastOrangeDoor];
        }
        set{
            roomPaths[(int)GameModel.Direction.BlastOrangeDoor] = value;
        }
    }

    public Room ExplodeOrangeDoor
    {
        get{
            return roomPaths[(int)GameModel.Direction.ExplodeOrangeDoor];
        }
        set{
            roomPaths[(int)GameModel.Direction.ExplodeOrangeDoor] = value;
        }
    }

    public Room redDoorRoom
    {
        get{
            return roomPaths[(int)GameModel.Direction.redDoorRoom];
        }
        set{
            roomPaths[(int)GameModel.Direction.redDoorRoom] = value;
        }
    }
    // Consequences of previous choices about Krueger and Allyss
    public Room RedRoomTalkAlyssAlive{
        get{
            return roomPaths[(int)GameModel.Direction.RedRoomTalkAlyssAlive];
        }
        set{
            roomPaths[(int)GameModel.Direction.RedRoomTalkAlyssAlive] = value;
        }
    }
    public Room RedRoomTalkKruegerAlive{
        get{
            return roomPaths[(int)GameModel.Direction.RedRoomTalkKruegerAlive];
        }
        set{
            roomPaths[(int)GameModel.Direction.RedRoomTalkKruegerAlive] = value;
        }
    }
    public Room RedRoomTalkAllAlive{
        get{
            return roomPaths[(int)GameModel.Direction.RedRoomTalkAllAlive];
        }
        set{
            roomPaths[(int)GameModel.Direction.RedRoomTalkAllAlive] = value;
        }
    }

    public Room RedRoomFightAllyssAlive{
        get{
            return roomPaths[(int)GameModel.Direction.RedRoomFightAllyssAlive];
        }
        set{
            roomPaths[(int)GameModel.Direction.RedRoomFightAllyssAlive] = value;
        }
    }
    public Room RedRoomFightKruegerAlive{
        get{
            return roomPaths[(int)GameModel.Direction.RedRoomFightKruegerAlive];
        }
        set{
            roomPaths[(int)GameModel.Direction.RedRoomFightKruegerAlive] = value;
        }
    }
    public Room RedRoomFightAllAlive{
        get{
            return roomPaths[(int)GameModel.Direction.RedRoomFightAllAlive];
        }
        set{
            roomPaths[(int)GameModel.Direction.RedRoomFightAllAlive] = value;
        }
    }
    public Room CantGoBack{
        get{
            return roomPaths[(int)GameModel.Direction.CantGoBack];
        }
        set{
            roomPaths[(int)GameModel.Direction.CantGoBack] = value;
        }
    }

    
    #endregion

    #region Adding, Saving, and Loading Rooms
    public Room()
    {
        Room.Rooms.Add(this);
    }

   
    #endregion
}
