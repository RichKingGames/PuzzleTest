using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JsonData
{
   public List<JsonLevelInfo> Levels;

   public JsonData(List<JsonLevelInfo> levels)
   {
      Levels = levels;
   }
}
