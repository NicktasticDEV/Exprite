using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Extrite;
using System;

[CreateAssetMenu(fileName = "NewSparrowPack", menuName = "Extrite/SparrowPack", order = 1)]
public class SO_SparrowPack : ScriptableObject
{
    public SparrowPack sparrowPack;
    public Extrite.Animation[] animations;

    public TextureAtlas textureAtlas { get; private set; }
    public List<SubTexture> subTextures { get; private set; }

    public void OnEnable()
    {
        LoadAtlas();
        Debug.Log("Subtextures: " + subTextures.Count);
    }

    public void LoadAtlas()
    {
        // Load the texture atlas
        XmlSerializer serializer = new XmlSerializer(typeof(TextureAtlas));
        textureAtlas = (TextureAtlas)serializer.Deserialize(new System.IO.StringReader(sparrowPack.atlas.text));
        subTextures = textureAtlas.SubTexture;
    }

    public Extrite.Animation GetAnimation(string name)
    {
        return Array.Find(animations, animation => animation.name == name);
    }

    public List<SubTexture> GetSubTexturesFromAnimName(string name)
    {
        Extrite.Animation animation = GetAnimation(name);
        List<SubTexture> subTextures = new List<SubTexture>();

        // Loop through all subtextures and add them to the list if they have the prefix
        foreach (SubTexture subTexture in this.subTextures)
        {
            if (subTexture.name.StartsWith(animation.prefix))
            {
                subTextures.Add(subTexture);
            }
        }

        return subTextures;
    }

    public Texture2D GetTextureFromSubTexture(SubTexture subTexture)
    {
        float adjustedY = sparrowPack.texture.height - subTexture.y - subTexture.height;

        Vector2 pivot = new Vector2(
            subTexture.frameX / (float)subTexture.width,
            1f - (subTexture.frameY / (float)subTexture.height)
        );

        // Create a sprite from the subtexture
        return Sprite.Create(
            sparrowPack.texture,
            new Rect(subTexture.x, adjustedY, subTexture.width, subTexture.height),
            pivot,
            1f
        ).texture;
    }

    public Sprite GetSpriteFromSubTexture(SubTexture subTexture)
    {
        float adjustedY = sparrowPack.texture.height - subTexture.y - subTexture.height;

        Vector2 pivot = new Vector2(
            subTexture.frameX / (float)subTexture.width,
            1f - (subTexture.frameY / (float)subTexture.height)
        );

        // Create a sprite from the subtexture
        return Sprite.Create(
            sparrowPack.texture,
            new Rect(subTexture.x, adjustedY, subTexture.width, subTexture.height),
            pivot,
            100f
        );
    }


}