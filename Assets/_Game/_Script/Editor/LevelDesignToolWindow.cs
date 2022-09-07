using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[InitializeOnLoad]
public class LevelDesignToolWindow : EditorWindow
{
    static LevelDesignToolWindow()
    {
        Init();
    }

    [SerializeField] int gridInt = 0;
    [SerializeField] string[] tilesGrid = {"Tile1","Tile2","Tile3","Tiles4"};


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
        var toolbarRect = new Rect((SceneView.lastActiveSceneView.camera.pixelRect.width / 6), 5, (SceneView.lastActiveSceneView.camera.pixelRect.width * 4 / 6), SceneView.lastActiveSceneView.camera.pixelRect.height / 20);
        GUILayout.BeginArea(toolbarRect);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        if (GUILayout.Button(tilesGrid[0]))
        {
           
        } 

        if (GUILayout.Button(tilesGrid[1]))
            Debug.Log("Got it to work.");

        if (GUILayout.Button(tilesGrid[2]))
            Debug.Log("Got it to work.");

        if (GUILayout.Button(tilesGrid[3]))
            Debug.Log("Got it to work.");

        // Content

        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
        Handles.EndGUI();
    }
}

    
