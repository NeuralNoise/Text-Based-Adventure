using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Exit
{
    public string Name;
    [TextArea] public string Description;
    public Room Destination;
}