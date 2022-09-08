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

    public GameObject selectedObject;

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

        SceneView.duringSceneGui += SceneViewGUI;
        Selection.selectionChanged += SelectionChanged;
        if (SceneView.lastActiveSceneView) SceneView.lastActiveSceneView.Repaint();
    }

    public void SelectionChanged()
    {
        tileInstance ??= SO_TilePrefabs.Instance;

        selectedObject = Selection.activeGameObject;
    }

    private void SceneViewGUI(SceneView __sceneView)
    {
        if (!selectedObject)
            return;

        Handles.BeginGUI();

        var toolbarRect = new Rect((SceneView.lastActiveSceneView.camera.pixelRect.width / 6), 5, (SceneView.lastActiveSceneView.camera.pixelRect.width * 4 / 6), SceneView.lastActiveSceneView.camera.pixelRect.height / 20);
        GUILayout.BeginArea(toolbarRect);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();



        if (selectedObject.GetComponent<ACube>() || selectedObject.name.Contains("Floor"))
        {

            if (GUILayout.Button("Oven"))
            {
                if (selectedObject.GetComponent<OvenCube>())
                    return;

                ChangeTo<OvenCube>("Oven ");
            }

            if (GUILayout.Button("Sugar"))
            {
                if (selectedObject.GetComponent<SugarCube>())
                    return;

                ChangeTo<SugarCube>("Sugar ");
            }

            if (GUILayout.Button("Jelly"))
            {
                if (selectedObject.GetComponent<JellyCube>())
                    return;

                ChangeTo<JellyCube>("Jelly ");
            }

            if (GUILayout.Button("Egg"))
            {
                if (selectedObject.GetComponent<CaramelCube>())
                    return;

                //ChangeTo<EggCube>("Egg ");
            }
        }
        else if (selectedObject.name.Contains("Floor"))
        {

        }

        // Content

        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
        Handles.EndGUI();
    }

    private void ChangeTo<T>(string newName) where T : ACube //Moyen de mettre un string du boxtype + suffixe Cube pour ensuite entrer le nom dans le Addcomponent et faire qu'une seule fonction (exple : string newBoxType = wantedType + Cube -> AddComponent<newBoxType>() )
    {
        selectedObject.name = newName + new Vector2(Mathf.FloorToInt(selectedObject.transform.position.x), Mathf.FloorToInt(selectedObject.transform.position.y));
        if (selectedObject.GetComponent<ACube>())
        {
            DestroyImmediate(selectedObject.GetComponent<ACube>());
        }
        selectedObject.AddComponent<T>();
        selectedObject.GetComponent<T>().travelTime = 1;
    }

    /*private void ChangeToSugar(GameObject __activeGameObject)
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
    }*/
}
