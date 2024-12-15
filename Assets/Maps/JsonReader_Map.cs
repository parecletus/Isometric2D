using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.IO;
public class JsonReader_Map : MonoBehaviour
{
    private static Dictionary<int, int[]> MapArrays = new Dictionary<int, int[]>();
    public int mapnumber = 3;
    void Awake()
    {
        FindChunks();
    }
    public void FindChunks()
    {
        for (int i = 1; i < mapnumber + 1; i++)
        {
            // This has to be fixed.
            string maplocation = "Assets/Maps/map" + i.ToString() + "..tmj";
            string maps = File.ReadAllText(maplocation);


            JObject rss = JObject.Parse(maps);
            JArray rssTitle = (JArray)rss["layers"][0]["chunks"][0]["data"];


            int[] mals = rssTitle.ToObject<int[]>();
            MapArrays.Add(i, mals);
        }
    }
    public static int[] GetArray(int a)
    {
        if (MapArrays.ContainsKey(a))
        {
            int[] result = MapArrays[a];
            return result;
        }
        else throw new System.ArgumentNullException("Wrong index of arrays");
    }
}


