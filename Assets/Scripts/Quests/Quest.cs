using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[System.Serializable]
public class Quest
{
   public bool active;
   public bool completed;
   
   public string title;
   public string[] description;
}
