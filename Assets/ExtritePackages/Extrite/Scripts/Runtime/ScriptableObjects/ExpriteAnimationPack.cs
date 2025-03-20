using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Extrite;
using System;
using System.IO;
using System.Text;
using System.IO.Compression;

[CreateAssetMenu(fileName = "ExpriteAnimationPack", menuName = "Exprite/Exprite Animation Pack", order = 1)]
public class ExpriteAnimationPack : ScriptableObject
{

    public Texture2D texture;
    public TextAsset atlas;

    public Vector2 globalOffset;
    public Extrite.AnimationDefinition[] animations;

    XmlSerializer serializer = new XmlSerializer(typeof(TextureAtlas));

    public Extrite.AnimationDefinition GetAnimationByName(string animationName)
    {
        foreach (Extrite.AnimationDefinition animation in animations)
        {
            if (animation.name == animationName)
            {
                return animation;
            }
        }

        throw new Exception("Animation not found: " + animationName);
    }

    public SubTexture[] GetSubTexturesFromAnimation(Extrite.AnimationDefinition animation)
    {
        TextureAtlas textureAtlas = (TextureAtlas)serializer.Deserialize(new System.IO.StringReader(atlas.text));

        // Get all Subtextures from the animation that have the prefix defined in the animation
        List<SubTexture> subTextures = new List<SubTexture>();

        foreach (SubTexture subTexture in textureAtlas.SubTexture)
        {
            if (subTexture.name.StartsWith(animation.prefix))
            {
                subTextures.Add(subTexture);
            }
        }

        return subTextures.ToArray();
    }

    #if UNITY_EDITOR
    [ContextMenu("Export Animation Pack")]
    public void ExportAnimationPack()
    {
        string path = UnityEditor.EditorUtility.SaveFilePanel("Save Animation Pack", "", "animationPack", "esac");
        Extrite.Utilities.ExportSparrowAnimationPack(this, path);
    }
    #endif

}