using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room CurrentRoom;
    Dictionary<string, Room> exitDictionnary = new Dictionary<string, Room>();
    GameController gameController;

    void Awake()
    {
        gameController = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        for (int i = 0; i < CurrentRoom.Exits.Length; i++)
        {
            gameController.InteractionDescriptionsInRoom.Add(CurrentRoom.Exits[i].Description);
            exitDictionnary.Add(CurrentRoom.Exits[i].Name, CurrentRoom.Exits[i].Destination);
        }
    }

    public void AttemptToChangeRooms(string directionNoun)
    {
        if(exitDictionnary.ContainsKey(directionNoun))
        {
            CurrentRoom = exitDictionnary[directionNoun];
            gameController.LogStringWithReturn("You head off to the " + directionNoun);
            gameController.DisplayRoomText();
        }
        else
        {
            gameController.LogStringWithReturn("The is no path to the " + directionNoun);
        }
    }

    public void ClearExits()
    {
        exitDictionnary.Clear();
    }
}
