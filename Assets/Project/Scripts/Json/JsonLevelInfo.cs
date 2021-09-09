using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class contains level info.
/// </summary>
[System.Serializable]

public class JsonLevelInfo
{
    public int Id;
    public bool IsAvailable;
    public List<Tuple<bool, Vector3>> Objects; // true if its dropped, Vector3 for end position.


    /// <param name="objects"> Item1 = is this object dropped in game</param>
    /// <param name="isAvailable"> Is this level available to play</param>
    /// <returns></returns>
    public JsonLevelInfo(int id, bool isAvailable, List<Tuple<bool, Vector3>> objects)
    {
        Id = id;
        IsAvailable = isAvailable;
        Objects = objects;
    }
}
