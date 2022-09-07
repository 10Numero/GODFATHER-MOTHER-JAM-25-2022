/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[InitializeOnLoad]
public class LevelDesignToolWindow : EditorWindow
{
    GameObject selectedItem;

    static LevelDesignToolWindow()
    {
        Init();
    }

    [SerializeField] int gridInt = 0;
    [SerializeField] string[] tilesGrid = { "Tile1", "Tile2", "Tile3", "Tiles4" };


    private SO_TilePrefabs tileInstance;

    private void OnEnable()
    {
        tileInstance = SO_TilePrefabs.Instance;

        SceneView.duringSceneGui += SceneViewGUI;
        if (SceneView.lastActiveSceneView) SceneView.lastActiveSceneView.Repaint();
    }



    [MenuItem("Window/Level Design Tool")]
    static void Init()
    {
        var window = (LevelDesignToolWindow)GetWindow(typeof(LevelDesignToolWindow));
        window.Close();
    }

    public void SceneViewGUI(SceneView __view)
    {
        tileInstance ??= SO_TilePrefabs.Instance;

        Handles.BeginGUI();



        *//*Event e = Event.current;
        switch (e.type)
        {
            case EventType.MouseDown:
                Debug.Log("a");
                if (selectedItem != null)
                {

                    var pos = new Vector3(a.x, -a.y - 2, 0);

                    var x = Mathf.RoundToInt(pos.x);
                    var y = Mathf.RoundToInt(pos.y);

                    Instantiate(selectedItem, new Vector3(x, y, 0), Quaternion.identity);

                    Debug.Log("cam pos : " + SceneView.lastActiveSceneView.camera.transform.position);
                    Debug.Log(new Vector2(a.x + SceneView.lastActiveSceneView.camera.transform.position.x, a.y));
                    if (Physics.Raycast(SceneView.lastActiveSceneView.camera.transform.position, ray.direction, out var hit, Mathf.Infinity))
                    {

                        if (hit.collider.transform.gameObject.layer == LayerMask.NameToLayer("ColliderLD"))
                        {
                            var x = Mathf.RoundToInt(hit.point.x);
                            var y = Mathf.RoundToInt(hit.point.y);

                            Instantiate(selectedItem, new Vector3(x, y, 0), Quaternion.identity);
                        }
                    }
                }

                break;
        }*//*

        var toolbarRect = new Rect((SceneView.lastActiveSceneView.camera.pixelRect.width / 6), 5, (SceneView.lastActiveSceneView.camera.pixelRect.width * 4 / 6), SceneView.lastActiveSceneView.camera.pixelRect.height / 20);
        GUILayout.BeginArea(toolbarRect);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        foreach (var item in tileInstance.tiles)
        {
            if (GUILayout.Button(item.name))
            {
                selectedItem = item;

            }


        }
        // Content

        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
        Handles.EndGUI();
    }

}


*/