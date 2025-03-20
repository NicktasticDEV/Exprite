using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;
using System.IO;
using System.Text;
using System.IO.Compression;
using Exprite;

public class ExpriteWindow : EditorWindow
{
    [MenuItem("Exprite/Exprite Window")]
    public static void ShowWindow()
    {
        GetWindow<ExpriteWindow>("Exprite Window");
    }

    void OnGUI()
    {
        GUILayout.Label("Exprite Window", EditorStyles.boldLabel);

        // Import Sparrow Animation Pack
        if (GUILayout.Button("Import Exprite Animation Pack"))
        {
            importAnimationPack();
        }

        // Export Sparrow Animation Pack
        if (GUILayout.Button("Export Exprite Animation Pack"))
        {
            exportAnimationPack();
        }
    }

    void importAnimationPack()
    {
        Debug.Log("Importing Exprite Animation Pack");

        ExpriteAnimationPack sparrowAnimationPack = ScriptableObject.CreateInstance<ExpriteAnimationPack>();

        string sparrowAnimationPackPath = Exprite.Utilities.GetPathFromDialogue("Import Exprite Animation Pack", "esap", false);

        sparrowAnimationPack = Exprite.Utilities.ImportSparrowAnimationPack(sparrowAnimationPackPath);
        
        // Get texture and atlas from the animation pack
        Texture2D texture = Exprite.Utilities.GetTextureFromAnimationPack(sparrowAnimationPackPath);
        TextAsset atlas = Exprite.Utilities.GetTextAssetFromAnimationPack(sparrowAnimationPackPath);

        // Save the animation pack to the project (Make sure path is relative to the project folder) Use editor utility to save the file
        string path = EditorUtility.SaveFilePanel("Save Animation Pack", Application.dataPath, "New Animation Pack", "asset");
        if (path.Length != 0)
        {
            path = path.Replace(Application.dataPath, "Assets");
            AssetDatabase.CreateAsset(sparrowAnimationPack, path);

            // Put the texture and atlas as sub-assets of the animation pack
            AssetDatabase.AddObjectToAsset(texture, sparrowAnimationPack);
            AssetDatabase.AddObjectToAsset(atlas, sparrowAnimationPack);

            // Make sure the references are set correctly
            sparrowAnimationPack.texture = texture;
            sparrowAnimationPack.atlas = atlas;

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        Debug.Log("Imported Exprite Animation Pack");
    }

    void exportAnimationPack()
    {
        string animationPackPath = Exprite.Utilities.GetPathFromDialogue("Export Exprite Animation Pack", "asset", false);

        if (animationPackPath.Length != 0)
        {
            Debug.Log("Selected Exprite Animation Pack: " + animationPackPath);
        }
        else
        {
            return;
        }
        
        ExpriteAnimationPack sparrowAnimationPack = AssetDatabase.LoadAssetAtPath<ExpriteAnimationPack>(animationPackPath);

        string exportPath = EditorUtility.SaveFilePanel("Export Exprite Animation Pack", "", "animationPack", "esap");
        Exprite.Utilities.ExportSparrowAnimationPack(sparrowAnimationPack, exportPath);

        Debug.Log("Exported Exprite Animation Pack");
    }
}
