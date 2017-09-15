using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Room")]
public class Room : ScriptableObject
{
    public string Name;
    [TextArea] public string Description;
    public Exit[] Exits;
}