using UnityEngine;
using System.Collections;

[ExecuteInEditMode] //Enables command execution in edit mode
public class WorldEditor : MonoBehaviour
{

    /// <summary>
    /// Simple function to instantiate an object on a position - will be used together with our custom editor script
    /// </summary>
    /// <param name="position"></param>
    /// <param name="prefab"></param>
    public void PrefabBrush(Vector3 position, GameObject prefab)
    {
        GameObject spawnedObject = Instantiate(prefab, position, Quaternion.identity) as GameObject;
    }

}
