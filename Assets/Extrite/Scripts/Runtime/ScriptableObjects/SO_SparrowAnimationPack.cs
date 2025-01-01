using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Extrite;
using System;
using System.IO;
using System.Text;
using System.IO.Compression;

[CreateAssetMenu(fileName = "SparrowAnimationPack", menuName = "Extrite/Sparrow Animation Pack", order = 1)]
public class SO_SparrowAnimationPack : ScriptableObject
{

    public Texture2D texture;
    public TextAsset atlas;

    public Vector2 globalOffset;
    public Extrite.Animation[] animations;

    XmlSerializer serializer = new XmlSerializer(typeof(TextureAtlas));

    public Extrite.Animation GetAnimationByName(string animationName)
    {
        foreach (Extrite.Animation animation in animations)
        {
            if (animation.name == animationName)
            {
                return animation;
            }
        }

        throw new Exception("Animation not found: " + animationName);
    }

    public SubTexture[] GetSubTexturesFromAnimation(Extrite.Animation animation)
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

    [ContextMenu("Export Animation Pack")]
    public void ExportAnimationPack()
    {
        // Will store the binary, the atlas and the texture in a zip file with (.esap) extension
        #if UNITY_EDITOR
        // Use the EditorUtility to save the file
        string filePath = UnityEditor.EditorUtility.SaveFilePanel("Save Animation Pack", "", name, "esap");
        #else
        // Use the operating system dialog to save the file
        string filePath = StandaloneFileBrowser.SaveFilePanel("Save Animation Pack", "", name, "esap");
        #endif

        // Use ZIP archive to store the files
        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        {
            using (ZipArchive zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create))
            {
                // Add the binary file
                ZipArchiveEntry binaryEntry = zipArchive.CreateEntry("animation.esap");
                using (BinaryWriter writer = new BinaryWriter(binaryEntry.Open()))
                {
                    // Write Header
                    writer.Write(Encoding.UTF8.GetBytes("ESAC")); // Identifier (Extrite Sparrow Animation Configuration)
                    writer.Write((ushort)1); // Version

                    // Padding
                    writer.Write(new byte[10]);

                    // Global Offset
                    writer.Write(globalOffset.x);
                    writer.Write(globalOffset.y);

                    // Write Animation Count
                    writer.Write(animations.Length);

                    // Write Animations
                    foreach (Extrite.Animation animation in animations)
                    {
                        writer.Write(animation.name.Length);
                        writer.Write(Encoding.UTF8.GetBytes(animation.name));
                        
                        writer.Write(animation.prefix.Length);
                        writer.Write(Encoding.UTF8.GetBytes(animation.prefix));

                        writer.Write(animation.fps);
                        writer.Write(animation.loop);
                        writer.Write(animation.offset.x);
                        writer.Write(animation.offset.y);
                    }
                }

                // Add the atlas file
                ZipArchiveEntry atlasEntry = zipArchive.CreateEntry("atlas.xml");
                using (StreamWriter writer = new StreamWriter(atlasEntry.Open()))
                {
                    writer.Write(atlas.text);
                }

                // Add the texture file
                ZipArchiveEntry textureEntry = zipArchive.CreateEntry("texture.png");
                using (Stream stream = textureEntry.Open())
                {
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        writer.Write(texture.EncodeToPNG());
                    }
                }
            }
        }
        
    }

    [ContextMenu("Import Animation Pack")]
    public void ImportAnimationPack()
    {
        // Will load the binary, the atlas and the texture from a zip file with (.esap) extension
        #if UNITY_EDITOR
        // Use the EditorUtility to open the file
        string filePath = UnityEditor.EditorUtility.OpenFilePanel("Open Animation Pack", "", "esap");
        #else
        // Use the operating system dialog to open the file
        string[] filePaths = StandaloneFileBrowser.OpenFilePanel("Open Animation Pack", "", "esap", false);
        if (filePaths.Length == 0)
        {
            return;
        }
        string filePath = filePaths[0];
        #endif

        // Use ZIP archive to load the files
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        {
            using (ZipArchive zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Read))
            {
                // Load the binary file
                ZipArchiveEntry binaryEntry = zipArchive.GetEntry("animation.esap");
                using (BinaryReader reader = new BinaryReader(binaryEntry.Open()))
                {
                    // Read Header
                    byte[] identifier = reader.ReadBytes(4);
                    ushort version = reader.ReadUInt16();

                    // Padding
                    reader.ReadBytes(10);

                    // Global Offset
                    globalOffset = new Vector2(reader.ReadSingle(), reader.ReadSingle());

                    // Read Animation Count
                    int animationCount = reader.ReadInt32();

                    // Read Animations
                    animations = new Extrite.Animation[animationCount];
                    for (int i = 0; i < animationCount; i++)
                    {
                        Extrite.Animation animation = new Extrite.Animation();
                        animation.name = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()));
                        animation.prefix = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()));
                        animation.fps = reader.ReadInt32();
                        animation.loop = reader.ReadBoolean();
                        animation.offset = new Vector2(reader.ReadSingle(), reader.ReadSingle());
                        animations[i] = animation;
                    }
                }

                // Load the atlas file
                ZipArchiveEntry atlasEntry = zipArchive.GetEntry("atlas.xml");
                using (StreamReader reader = new StreamReader(atlasEntry.Open()))
                {
                    atlas = new TextAsset(reader.ReadToEnd());
                }

                // Load the texture file
                ZipArchiveEntry textureEntry = zipArchive.GetEntry("texture.png");
                using (Stream stream = textureEntry.Open())
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        texture = new Texture2D(2, 2);
                        texture.LoadImage(reader.ReadBytes((int)textureEntry.Length));
                    }
                }

            }
        }
    }


}