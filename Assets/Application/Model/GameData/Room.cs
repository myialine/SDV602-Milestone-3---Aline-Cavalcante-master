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
   public Room currentRoom;

   //This determines the amount of rooms on the array.
   private string roomDescriptions = "default";

   public string description
   {
       get {
           return roomDescriptions;
       } 
       set {
           bedroom.roomDescriptions = "BEDROOM, 0600" + "/n" +
                "YOU WAKE UP TO THE BUZZ OF THE MAIN SYSTEM ALARM AS USUAL. THE NEW DRUGS DEVELOPED BY THE ULTRAVIOLET SCIENTISTS ARRIVE AT THE SAME TIME THROUGH THE CHEMICALS TUBE. YOU TAKE THE NEW PILLS AND FEEL NUMB."+ "/n" +
                "ANOTHER DAY IN THE ALPHA COMPLEX WITH THAT DAMNED COMPUTER. YOU HAD TO KILL THAT MUTANT YESTERDAY OR YOU WOULD BE THE ONE LOSING ANOTHER CLONE, BUT YOU GOT THE RED CLEARANCE." + "/n" +
                "LAST WEEK WAS A NIGHTMARE AND YOU DID NOT GET THE CREDITS FOR THE ASSEMBLING LINE CLEANING MISSION AND LOST THREE CLONES TO THE COMMUNIST CULPRITS." + "/n" +
                "TIME IS WASTING. YOU HAVE TO GO TO THE RED COMPUTER ROOM NOW OR RISK GETTING KILLED AGAIN FOR BEING LATE. THAT IS HOW “YOUR FRIEND THE COMPUTER” GETS THINGS DONE." + "/n" +
                "SOMETHING IS WRONG WITH THE EYE SCANNERS AND AUTOMATIC DOORS. TO BE ABLE TO LEAVE, YOU HAVE TO TYPE IN THE NAME OF THE ROOM BEHIND THE DOOR USING AN ANCIENT COMMAND MODEL: “GO” + NAME OF THE ROOM.";
           
           computerRoom.roomDescriptions = "COMPUTER ROOM, 0610" + "/n" +
                "THE COMPUTER ROOM IS SILENT, BUT THE RED ALERT PROTOCOL LIGHTS ARE ON. SOMETHING WENT WRONG AND YOU, TROUBLESHOOTER, WILL HAVE TO SHOOT THE PROBLEM ON THE FACE TODAY." + "/n" +
                "A SMALL LED SCREEN WITH A COLD GREY SHIMMER SLIDES DOWN, FOLLOWED BY THREE OCULAR CAMS AS YOUR FRIEND THE COMPUTER SALUTES YOU." + "/n" +
                "‘GREETINGS, TROUBLESHOOTER." + "/n" +
                "CONGRATULATIONS FOR ELIMINATING THAT MUTANT ON SECTOR INFRARED BETA. YOUR WELL-DESERVED RED CLEARANCE IS ACTIVE NOW." + "/n" +
                "YOUR MISSION THIS MORNING IS TO FIND THE BETRAYER THAT DISABLED THE EYE SCANNERS AND AUTOMATIC DOORS ON THE ENTIRE SECTOR AND ELIMINATE THE THREAT." + "/n" +
                "YOU WILL NEED TO REACTIVATE THE OLD INPUT CONSOLES TO PROCEED. YOU ARE NOW DESIGNATED AS TEAM LEADER FOR THE TASK FORCE I CREATED TO ADDRESS THIS INCIDENT. YOUR FELLOW TROUBLESHOOTERS AWAIT YOU ON THE TROUBLESHOOTERS RED HEADQUARTERS."+ "/n" +
                "GO. REMEMBER: BETRAYAL IS PUNISHED WITH DEATH. THE COMPUTER IS YOUR FRIEND. HAPPINESS IS MANDATORY’." + "/n" +
                "YOU RECEIVE A BLASTER PISTOL, A RED CLEARANCE SUIT AND A REPAIR MINIBOT FROM THE SYSTEM TRAY. TIME TO USE THAT OLD CONSOLE TO GO TO THE BRIEFING ROOM.";
           
           briefingRoom.roomDescriptions = "BRIEFING ROOM, 0620" + "/n" +
                "YOU ARRIVE AT AN EMPTY BRIEFING ROOM. THE TABLE HAS THE NOTES ON THE MISSION DELIVERED BY THE SYSTEM PRINTER AND THERE IS AN ELETRONIC BOX CASUALLY LEFT ON TOP OF THE TABLE." + "/n" +
                "YOU HEAR DISTANT, MUFFLED VOICES THAT SEEM TO BE IN AN ARGUMENT." + "/n" +
                "YOU LOOK INSIDE THE BAG. THERE IS A CARD AUTODECODER – A PROHIBITED ITEM THAT CAN UNLOCK ANY DOOR OR DEVICE, INDEPENDENT OF CLEARANCE – AND AN EXPERIMENTAL PROBABILITY GRENADE. YOU CAN PICK ONLY ONE OF THE ITEMS WITHOUT ANYONE NOTICING, AND THOSE VOICES SEEM TO BE GETTING CLOSER." + "/n" +
                "YOU NEED TO USE THE CONSOLE TO REMOVE ITEMS FROM THE BOX. TYPE 'PICK' + THE NAME OF THE ITEM  TO PICK THE GRENADE OR THE CARD.";

           briefingRoomGrenade.roomDescriptions = "YOU QUICKLY RELEASE THE GRENADE AND HIDE IT INSIDE OF YOUR SUIT." + "/n" + 
                "THE TWO OTHER TROUBLESHOOTERS ARRIVE. THEY ARE ALLYSS-225-RED-BETA AND kRUEGER-332-RED-ALPHA, AND YOU HAVE SEEN THEM BEFORE. THERE IS SUSPICION THAT KRUEGER IS A MUTANT, BUT SINCE YOU ARE A MUTANT TOO, YOU DECIDED NOT TO GET ON HIS WAY. ALLYSS IS FAMOUS FOR KILLING PEOPLE FOR THE SLIGHTEST INFRINGIMENTS AND YOU CAN SEE IN HER EYES SHE MIGHT KILL YOU BOTH TODAY." + "/n" +
                "KRUEGER: ALLYSS, STOP THAT NONSENSE. THERE IS NO EVIDENCE THAT I AM A BETRAYER. YOU CAN LOOK INSIDE MY BOX IF YOU WANT." + "/n" +
                "ALLYSS LOOKS AT THE BOX AND AT YOU. YOU ARE TEAM LEADER AND SHE SEEMS TO EXPECT THAT YOU CHOOSE A SIDE ON THIS MATTER." + "/n" +
                "ALLYSS: I CAN KILL HIM IF YOU DON’T MIND. HE IS SUSPICIOUS OF BEING A MUTANT ANYWAY." + "/n" +
                "AS YOU SEE IT, YOU HAVE THREE OPTIONS: LET HER KILL KRUEGER, KILL HER  FOR BEING DANGEROUS OR STOP THIS NONSENSE - YOU HAVE A MISSION AND IT WOULD BE BETTER IF YOU HAD THE NUMBERS."+ "/n" +
                "TYPE 'KILL' + THE NAME OF THE ONE WHO SHALL DIE OR 'STOP' TO FINISH THIS ARGUMENT WITH NO DEATHS";

           briefingRoomCard.roomDescriptions = "YOU QUICKLY RELEASE THE CARD AND PUT IT INSIDE OF YOUR POCKETS." + "/n" +
                "THE TWO OTHER TROUBLESHOOTERS ARRIVE. THEY ARE ALLYSS-225-RED-BETA AND KRUEGER-332-RED-ALPHA, AND YOU HAVE SEEN THEM BEFORE. THERE IS SUSPICION THAT KRUEGER IS A MUTANT, BUT SINCE YOU ARE A MUTANT TOO, YOU DECIDED NOT TO GET ON HIS WAY. ALLYSS IS FAMOUS FOR KILLING PEOPLE FOR THE SLIGHTEST INFRINGIMENTS AND YOU CAN SEE IN HER EYES SHE MIGHT KILL YOU BOTH TODAY." + "/n" +
                "KRUEGER: ALLYSS, STOP THAT NONSENSE. THERE IS NO EVIDENCE THAT I AM A BETRAYER. YOU CAN LOOK INSIDE MY BOX IF YOU WANT." + "/n" +
                "ALLYSS LOOKS AT THE BOX AND AT YOU. YOU ARE TEAM LEADER AND SHE SEEMS TO EXPECT THAT YOU CHOOSE A SIDE ON THIS MATTER." + "/n" +
                "ALLYSS: I CAN KILL HIM IF YOU DON’T MIND. HE IS SUSPICIOUS OF BEING A MUTANT ANYWAY." + "/n" +
                "AS YOU SEE IT, YOU HAVE THREE OPTIONS: LET HER KILL KRUEGER, KILL HER  FOR BEING DANGEROUS OR STOP THIS NONSENSE - YOU HAVE A MISSION AND IT WOULD BE BETTER IF YOU HAD THE NUMBERS."+ "/n" +
                "TYPE 'KILL' + THE NAME OF THE ONE WHO SHALL DIE OR 'STOP' TO FINISH THIS ARGUMENT WITH NO DEATHS";

           
           briefingKillKrueger.roomDescriptions = "ALLYSS SHOOTS THE BLASTER ON KRUEGER IN A SPLIT SECOND. HE FALLS, THE CLEANING TUBE COMES IN AND REMOVES HIS BODY." + "/n" +
                "SHE PICKS UP THE BOX AND LOOKS INSIDE." + "/n" +
                "ALLYSS: I KNEW IT! A SMALL GIFT FOR A CLEVER GIRL. GOOD RIDDANCE. THAT DAMNED TRAITOR IS FINALLY DEAD." + "/n" +
                "ALLYSS LOOKS AT YOU:" + "/n" +
                "ALLYSS: LET'S GO TO THE SERVER BASEMENT. YOU KNOW HOW TO USE THAT CONSOLE, RIGHT?"+ "/n" +
                "TYPE 'GO' + SERVER BASEMENT";

           briefingKillAlyss.roomDescriptions = "YOU PULL YOUR BLASTER AND SHOOT AT ALLYSS. SHE DOES NOT REACT BECAUSE SHE DID NOT SEE IT COMING. SHE FALLS, THE CLEANING TUBE COMES IN AND REMOVES HER BODY."+ "/n" +
                "KRUEGER PICKS UP HIS BOX AND LEAVES, SAYING HE WOULD BE RIGHT BACK" + "/n" +
                "HE COMES BACK AND GIVES YOU THE MUTANT SECRET HANDSHAKE" + "/n" +
                "KRUEGER: THANKS, TEAM LEADER. THAT WOMAM WOULD HAVE US KILLED FOR NOTHING. CAN WE GO NOW?" + "/n" +
                "TYPE 'GO' + SERVER BASEMENT TO PROCEED WITH THE MISSION";

           briefingStopFight.roomDescriptions = "YOU CALL THEM BOTH OUT FOR WASTING YOUR TIME. ALLYSS LOOKS AT YOU WITH A DEATH STARE. KRUEGER PICKS UP THE BOX AND LEAVES FOR HIS ROOM AND COMES BACK QUICKLY." + "/n" +
                "YOU ALL ARE READY TO LEAVE." + "/n" +
                "TYPE 'GO' + SERVER BASEMENT TO PROCEED WITH THE MISSION";

           serverBasement.roomDescriptions = "SERVER BASEMENT, 0700" + "/n" +
                "YOU ARRIVE AT THE SERVER BASEMENT. THE PLACE IS DESERTED AN SILENT. YOU SEE THE MAIN CONSOLE, BUT IT IS INACCESSIBLE DUE TO THE EYE SCANNER BEING DISABLED." + "/n" +
                "YOU SEE TWO DOORS: AN ORANGE CLEARANCE DOOR, WITH DIRECT ACCESS TO THE ORANGE SERVER ROOM AND MANUAL REBOOT AND CONFIGURATIONS PANEL, BUT IT IS FORBIDDEN. THERE IS ANOTHER DOOR – A RED CLEARANCE DOOR, THAT APPARENTLY LEADS TO THE MAINTENANCE ENTRY TO THE SAME ROOM, THROUGH A LONGER PATH." + "/n" +
                "THESE ARE YOUR OPTIONS:" + "/n" +
                " - YOU CAN GO THROUGH THE RED DOO AND USE THE SERVICE ENTRANCE ON THE BACK -  TYPE 'GO' + RED DOOR" + "/n" +
                " - YOU CAN TRY TO OPEN THE ORANGE DOOR - TYPE 'OPEN' + ORANGE DOOR";

           openOrangeDoor.roomDescriptions = "ORANGE SERVER ROOM, 0710" + "/n" +
                "THE DOOR OPENS. THE CONSOLE IS IN FRONT, AND YOU COMMAND THE REPAIR BOT TO FIX THE SYSTEM." + "/n" +
                "THE COMPUTER COMES IN THE CONSOLE AND TELLS YOU THE SCANNS ARE BACK ONLINE." + "/n" +
                "YOU RECEIVE A NOTIFICATION OF CREDITS ON YOUR PERSONAL DEVICE. THE MISSION IS OVER." + "/n" +  "/n" + "/n" +
                ">>>>>>> MISSION COMPLETE <<<<<<<";

           redDoorRoom.roomDescriptions = "RED SERVICE ROOM, 0710" + "/n" +
                "YOU SEE A GROUP OF TWO HUGE MEN AND ONE WOMAN TAMPERING WITH THE BACK OF THE MANUAL CONFIGURATION CONTROLLER. THEY DON’T SEE YOU YET AND YOU HAVE TO DECIDE WHAT TO DO." + "/n" +
                "YOUR OPTIONS:" + "/n" +
                " - YOU CAN TALK YOUR WAY OUT OF THE SITUATION AND FIX THE CONTROLLER - TYPE 'TALK'" + "/n" +
                " - YOU FIGHT THEM OFF WHILE THEY ARE DISTRACTED - TYPE 'FIGHT'";

           RedRoomTalkAlyssAlive.roomDescriptions = "YOU START TALKING:" + "/n" +
                "HELLO. THIS IS RED TEAM LEADER AND I OFFER YOU THE OPPORTUNITY TO LEAVE AND LET ME FIX THIS. THE COMPUTER DOESN'T HAVE TO KNOW." + "/n" +
                "THE MUTANTS RECOGNIZE YOU AND STOP TAMPERING WITH THE MACHINE." + "/n" +
                "ALLYSS: NO WAY YOU WANT TO NEGOTIATE WITH THESE MUTANTS!" + "/n" +
                "ALLYSS ATTACKS AND KILLS ONE OF THE MEN. THE WOMAN JUMPS AND LANDS ON TOP OF ALLYSS, AND BREAKS HER NECK" + "/n" +
                "THE OTHER MAN SHOOTS AT YOU. YOU ARE DEAD" + "/n" + "/n" + "/n" +
                ">>>>>>> MISSION FAILED <<<<<<<";

           RedRoomTalkKruegerAlive.roomDescriptions = "YOU START TALKING:" + "/n" +
                "HELLO. THIS IS RED TEAM LEADER AND I OFFER YOU THE OPPORTUNITY TO LEAVE AND LET ME FIX THIS. THE COMPUTER DOESN'T HAVE TO KNOW." + "/n" +
                "THE MUTANTS RECOGNIZE YOU BOTH AND STOP TAMPERING WITH THE MACHINE." + "/n" +
                "THE WOMAN SAYS “OK, BUT WE ARE GOING TO KILL SOME TELEPATHS THIS WEEKEND”. THEY ALL LEAVE." + "/n" +
                "KRUEGER: I AM GLAD THAT WAS EASY – WE WOULD BE DEAD RIGHT NOW IF WE DIDN’T KNOW THESE PEOPLE. THIS IS OUR LITTLE SECRET…" + "/n" +
                "YOU FIX THE SERVER USING THE MAINTENANCE DOOR." + "/n" +
                "THE COMPUTER COMES IN THE CONSOLE AND TELLS YOU THE SCANNS ARE BACK ONLINE. YOU RECEIVE A NOTIFICATION OF CREDITS ON YOUR PERSONAL DEVICE. THE MISSION IS OVER." + "/n" + "/n" + "/n" +
                ">>>>>>> MISSION COMPLETE <<<<<<<";
                
           RedRoomTalkAllAlive.roomDescriptions = "YOU START TALKING:" + "/n" +
                "HELLO. THIS IS RED TEAM LEADER AND I OFFER YOU THE OPPORTUNITY TO LEAVE AND LET ME FIX THIS. THE COMPUTER DOESN'T HAVE TO KNOW." + "/n" +
                "THE MUTANTS RECOGNIZE YOU AND KRUEGER AND STOP TAMPERING WITH THE MACHINE." + "/n" +
                "ALLYSS: LOOK AT WHO HAS MUTANT FRIENDS AND HAS TO DIE!" + "/n" +
                "THE MUTANT WOMAN JUMPS AND LANDS ON TOP OF ALLYSS AND BREAKS HER NECK. “ONE LESS TO HUNT, BUT THIS IS NO TELEPATHIC.” SHE THEN GOES AWAY RUNNING." + "/n" +
                "YOU FIX THE SERVER USING THE MAINTENANCE DOOR." + "/n" +
                "THE COMPUTER COMES IN THE CONSOLE AND TELLS YOU THE SCANNS ARE BACK ONLINE. YOU RECEIVE A NOTIFICATION OF CREDITS ON YOUR PERSONAL DEVICE. THE MISSION IS OVER." + "/n" + "/n" + "/n" +
                ">>>>>>> MISSION COMPLETE <<<<<<<";

           RedRoomFightAllyssAlive.roomDescriptions = "YOU PULL THE BLASTER PISTOL BUT THE CULPRITS HEAR YOU, AND THEY ATTACK FAST. YOU KILL ONE OF THE MAN, THE OTHER ONE GOES TO ALLYSS AND THE WOMAN COMES AFTER YOU." + "/n" +
                "SHE BREAKS YOUR NECK WITH A QUICK MOVEMENT. YOU ARE DEAD." + "/n" + "/n" + "/n" +
                ">>>>>>> MISSION FAILED <<<<<<<";

           RedRoomFightKruegerAlive.roomDescriptions = "YOU ARE OUTNUMBERED. KRUEGER LOOKS AT YOU AND POINTS AT THE GRENADE" + "/n" + 
                "YOU GET THE HINT. YOU PULL THE GRENADE, PRESS THE BUTTON AND LAUNCH IT." + "/n" +
                "YOU HEAR A DISTANT SCREAM BEHIND YOU FROM YOU FELLOW TROUBLESHOOTER." + "/n" +
                "A CATACLYSMIC EVENT HAPPENS. THE ENTIRE COMPLEX VANISHES AS SILENT BEAM OF LIGHT EXPANDS. YOU AND ANOTHER 10 THOUSAND PEOPLE ARE DEAD." + "/n" + "/n" + "/n" +
                ">>>>>>> MISSION FAILED <<<<<<<";

           RedRoomFightAllAlive.roomDescriptions = "IT WAS A COORDINATED ATTACK." + "/n" +
                "KRUEGER GOES AFTER THE WOMAN WHILE ALLYSS KILLS ONE OF THE MAN QUICKLY. YOU KILL THE OTHER MAN AND ALL IS OVER IN A MATTER OF SECONDS." + "/n" +
                "YOU FIX THE SERVER USING THE MAINTENANCE DOOR." + "/n" +
                "THE COMPUTER COMES IN THE CONSOLE AND TELLS YOU THE SCANNS ARE BACK ONLINE. YOU RECEIVE A NOTIFICATION OF CREDITS ON YOUR PERSONAL DEVICE. THE MISSION IS OVER." + "/n" + "/n" + "/n" +
                ">>>>>>> MISSION COMPLETE <<<<<<<";

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
