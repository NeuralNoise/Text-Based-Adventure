using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text DisplayText;
    public InputAction[] InputActions;

    [HideInInspector] public RoomNavigation RoomNavigation;
    [HideInInspector] public List<string> InteractionDescriptionsInRoom = new List<string>();
    List<string> actionLog = new List<string>();

    void Awake()
    {
        RoomNavigation = GetComponent<RoomNavigation>();
    }

    void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join(Environment.NewLine, actionLog.ToArray());
        DisplayText.text = logAsText;
    }
    
    public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom();
        UnpackRoom();
        string joinedInteractionDescriptions = string.Join(Environment.NewLine, InteractionDescriptionsInRoom.ToArray());
        string combinedText = RoomNavigation.CurrentRoom.Description + Environment.NewLine + joinedInteractionDescriptions;
        LogStringWithReturn(combinedText);
    }

    public void UnpackRoom()
    {
        RoomNavigation.UnpackExitsInRoom();
    }

    void ClearCollectionsForNewRoom()
    {
        InteractionDescriptionsInRoom.Clear();
        RoomNavigation.ClearExits();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + Environment.NewLine);
    }
}