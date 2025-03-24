using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Exprite;
using System;
using System.IO;
using System.Text;
using System.IO.Compression;


namespace Exprite
{
    public class Utilities : MonoBehaviour
    {
        public static Texture2D GetTextureFromAnimationPack(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                using (ZipArchive zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Read))
                {
                    // Load the texture
                    ZipArchiveEntry textureEntry = zipArchive.GetEntry("texture.png");
                    using (Stream stream = textureEntry.Open())
                    {
                        using (BinaryReader reader = new BinaryReader(stream))
                        {
                            byte[] textureData = reader.ReadBytes((int)textureEntry.Length);
                            Texture2D texture = new Texture2D(2, 2);
                            texture.LoadImage(textureData);
                            return texture;
                        }
                    }
                }
            }
        }

        public static TextAsset GetTextAssetFromAnimationPack(string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                using (ZipArchive zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Read))
                {
                    // Load the atlas
                    ZipArchiveEntry atlasEntry = zipArchive.GetEntry("atlas.xml");
                    using (Stream stream = atlasEntry.Open())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string atlasData = reader.ReadToEnd();
                            return new TextAsset(atlasData);
                        }
                    }
                }
            }
        }
    }
}
