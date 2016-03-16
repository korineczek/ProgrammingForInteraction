using UnityEditor;
using UnityEngine;
using System.Collections;

[CanEditMultipleObjects]
[CustomEditor(typeof(WorldEditor))] // declares that this is a custom editor script
[System.SerializableAttribute]
public class WorldEditorEditor : Editor //inherits from the editor class to do all the good stuff
{

    [SerializeField] private Object prefab;
    private bool inEditMode = false;
    private WorldEditor worldEditor; 

    /// <summary>
    /// what happens when script gets enabled
    /// </summary>
    void OnEnable()
    {
        
    }

    /// <summary>
    /// Function that overrides the normal editor with a custom one we are going to make
    /// </summary>
    public override void OnInspectorGUI()
    {
        prefab = EditorGUILayout.ObjectField("Prefab To Paint", prefab, typeof (GameObject));
    }

    /// <summary>
    /// Function that handles all the input in the actual scene window
    /// </summary>
    void OnSceneGUI()
    {
        //Check for edit mode
        if (Event.current.alt)
        {
            inEditMode = false;
        }
        else
        {
            inEditMode = true;
        }
        // if in edit mode, start processing inputs
        if (inEditMode)
        {
            //Disable mouse selection while in edit mode to prevent selection
            if (Event.current.type == EventType.layout)
            {
                HandleUtility.AddDefaultControl(GUIUtility.GetControlID(GetHashCode(), FocusType.Passive));
            }

            if (Event.current.type == EventType.mouseDown)
            {
                Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition); //cast ray from screen point towards 3d space - super useful
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit, 1000f))
                {
                    //if we hit terrain, execute prop instantiation.
                    Vector3 brushPosition = hit.point;
                    worldEditor = (WorldEditor) target;
                    worldEditor.PrefabBrush(brushPosition,(GameObject)prefab);
                }
            }
        }
    }
}
