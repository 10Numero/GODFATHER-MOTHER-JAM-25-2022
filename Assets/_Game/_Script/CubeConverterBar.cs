using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class CubeConverterBar : EditorWindow
{
    public static Action selectionChanged;

    private SO_TilePrefabs tileInstance;

    public GameObject testGO;

    static CubeConverterBar()
    {
        Init();
    }

    [MenuItem("Window/Level Design Tool")]
    static void Init()
    {
        var window = (CubeConverterBar)GetWindow(typeof(CubeConverterBar));
        window.Close();
    }

    private void OnEnable()
    {
        tileInstance = SO_TilePrefabs.Instance;

        Selection.selectionChanged += SceneViewGUI;
        if (SceneView.lastActiveSceneView) SceneView.lastActiveSceneView.Repaint();
    }

    public void SceneViewGUI()
    {
        tileInstance ??= SO_TilePrefabs.Instance;

        var selectedObject = Selection.activeGameObject;

        Handles.BeginGUI();

        var toolbarRect = new Rect((SceneView.lastActiveSceneView.camera.pixelRect.width / 6), 5, (SceneView.lastActiveSceneView.camera.pixelRect.width * 4 / 6), SceneView.lastActiveSceneView.camera.pixelRect.height / 20);
        GUILayout.BeginArea(toolbarRect);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        if (selectedObject.GetComponent<ACube>())
        {
            if (GUILayout.Button("Oven"))
            {
                if (selectedObject.GetComponent<OvenCube>())
                    return;

                Debug.Log("Switching to OvenCube");

                ChangeToOven(selectedObject);
            }

            if (GUILayout.Button("Sugar"))
            {
                if (selectedObject.GetComponent<SugarCube>())
                    return;

                Debug.Log("Switching to SugarCube");

                ChangeToSugar(selectedObject);
            }

            if (GUILayout.Button("Jelly"))
            {
                if (selectedObject.GetComponent<JellyCube>())
                    return;

                Debug.Log("Switching to JellyCube");

                ChangeToJelly(selectedObject);
            }

            if (GUILayout.Button("Caramel"))
            {
                if (selectedObject.GetComponent<CaramelCube>())
                    return;

                Debug.Log("Switching to CaramelCube");

                ChangeToCaramel(selectedObject);
            }
        }

        // Content

        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
        Handles.EndGUI();
    }

    private void ChangeToOven(GameObject __activeGameObject) //Moyen de mettre un string du boxtype + suffixe Cube pour ensuite entrer le nom dans le Addcomponent et faire qu'une seule fonction (exple : string newBoxType = wantedType + Cube -> AddComponent<newBoxType>() )
    {
        Destroy(__activeGameObject.GetComponent<ACube>());
        __activeGameObject.AddComponent<OvenCube>();
        name = "Oven " + new Vector2(testGO.transform.position.x, testGO.transform.position.y);
    }
    private void ChangeToSugar(GameObject __activeGameObject)
    {
        Destroy(__activeGameObject.GetComponent<ACube>());
        __activeGameObject.AddComponent<SugarCube>();
        name = "Sugar " + new Vector2(testGO.transform.position.x, testGO.transform.position.y);
    }
    private void ChangeToJelly(GameObject __activeGameObject)
    {
        Destroy(__activeGameObject.GetComponent<ACube>());
        __activeGameObject.AddComponent<JellyCube>();
        name = "Jelly " + new Vector2(testGO.transform.position.x, testGO.transform.position.y);
    }
    private void ChangeToCaramel(GameObject __activeGameObject)
    {
        Destroy(__activeGameObject.GetComponent<ACube>());
        __activeGameObject.AddComponent<CaramelCube>();
        name = "Caramel " + new Vector2(testGO.transform.position.x, testGO.transform.position.y);
    }
}
