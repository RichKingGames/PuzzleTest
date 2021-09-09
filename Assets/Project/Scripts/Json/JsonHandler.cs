using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using UnityEditor;

/// <summary>
///  The class of Json Manager. Contains all information about progress.
/// </summary>
public class JsonHandler : MonoBehaviour
{
    private static string JSON_PATH;
    private JsonData _data;
    
    private static JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.Objects,
        Formatting = Formatting.Indented,
        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    };

    void Awake()
    {
        JSON_PATH = Path.Combine(Application.persistentDataPath, "Data.json");
        _data = Read(JSON_PATH);
    }

    
    public static void Write(JsonData data, string jsonFile)
    {
        string jsonString = JsonConvert.SerializeObject(data, Settings);
        File.WriteAllText(jsonFile, jsonString);
    }

    public JsonData Read(string jsonFile)
    {
        if (File.Exists(jsonFile)) // if game opened earlier
        {
            string jsonStringOutput = File.ReadAllText(jsonFile);
            return JsonConvert.DeserializeObject<JsonData>(jsonStringOutput, Settings);
        }
        else // else second and more opened
        {
            return FirstInit();
        }
    }

    /// <summary>
    ///  The Method that returns an array of accessibility of all levels
    /// </summary>
    /// <returns>Array of booleans</returns>
    public bool[] GetAvailable()
    {
        bool[] IsAvailable = new bool[_data.Levels.Count];
        for (int i = 0; i < _data.Levels.Count; i++)
        {
            IsAvailable[i] = _data.Levels[i].IsAvailable;
        }

        return IsAvailable;
    }

    public List<Tuple<bool, Vector3>> GetLevelInfo(int id)
    {
        return _data.Levels[id].Objects;
    }

    /// <summary>
    ///  The method that Opens the level by his ID. Invokes when level complete.
    /// </summary>
    public void SetLevelAvailable(int levelId)
    {
        _data.Levels[levelId].IsAvailable = true;
        
        Write(_data,JSON_PATH);
        _data = Read(JSON_PATH);
    }
    
    /// <summary>
    ///  The method that overwrites information about an object, whether it is dropped or not.
    /// </summary>
    public void OverrideProgress(int levelId, int unitId)
    {
        Tuple<bool, Vector3> temp = new Tuple<bool, Vector3>(true, _data.Levels[levelId].Objects[unitId].Item2);
        _data.Levels[levelId].Objects[unitId] = temp;
        
        Write(_data,JSON_PATH);
        _data = Read(JSON_PATH);
    }

    /// <summary>
    ///  The method that clear level and json info of this level.
    /// </summary>
    public void RestartLevel(int levelId)
    {
        for (int i = 0; i < _data.Levels[levelId].Objects.Count; i++)
        {
            Tuple<bool, Vector3> temp = new Tuple<bool, Vector3>(false, _data.Levels[levelId].Objects[i].Item2);
            _data.Levels[levelId].Objects[i] = temp;
        }
        
        Write(_data,JSON_PATH);
        _data = Read(JSON_PATH);
    }
    
    
    /// <summary>
    ///  The method that creat first info about all levels.
    /// </summary>
    [MenuItem("Tool/Json/FirstInit")]
    public static JsonData FirstInit()
    {
        List<JsonLevelInfo> levels = new List<JsonLevelInfo>();
        for (int i = 0; i < 6; i++)
        {
            levels.Add(new JsonLevelInfo(i, i<1 ? true: false, new List<Tuple<bool, Vector3>>()
            {
                new Tuple<bool, Vector3>(false, new Vector3()),
                new Tuple<bool, Vector3>(false, new Vector3(-250,0,0)),
                new Tuple<bool, Vector3>(false, new Vector3(150,0,0)),
                new Tuple<bool, Vector3>(false, new Vector3(50,150,0)),
                new Tuple<bool, Vector3>(false, new Vector3(-100,100,0)),
                new Tuple<bool, Vector3>(false, new Vector3(-200,-200,0)),
                new Tuple<bool, Vector3>(false, new Vector3(125,-250,0))
            }));
        }
       

        Write(new JsonData(levels), JSON_PATH);
        return new JsonData(levels);
        
    }
}