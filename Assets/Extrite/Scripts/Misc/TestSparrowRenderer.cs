using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Extrite
{

    [RequireComponent(typeof(SpriteRenderer))]
    public class TestSparrowRenderer : MonoBehaviour
    {
        // Components
        private SpriteRenderer spriteRenderer;

        // Fields
        public SparrowPack animationSet;
        //public SparrowPackLoadType loadType;

        // XML Data
        private TextureAtlas textureAtlas;
        private List<SubTexture> subTextures;

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            
            // Load the texture atlas
            XmlSerializer serializer = new XmlSerializer(typeof(TextureAtlas));
            textureAtlas = (TextureAtlas)serializer.Deserialize(new System.IO.StringReader(animationSet.atlas.text));
            subTextures = textureAtlas.SubTexture;

            Debug.Log("Subtextures: " + subTextures.Count);
        }

        void Start()
        {
            StartCoroutine(PlayAllFramesLoop());
        }

        void Update()
        {

            
        }

        
        IEnumerator PlayAllFramesLoop()
        {
            int frameIndex = 0;
            float timePerFrame = 1f / 24f;
            float timeAccumulator = 0f;

            while (true)
            {
                timeAccumulator += Time.deltaTime;

                if (timeAccumulator >= timePerFrame)
                {
                    timeAccumulator -= timePerFrame;

                    SubTexture subTexture = subTextures[frameIndex];
                    float adjustedY = animationSet.texture.height - subTexture.y - subTexture.height;

                    Vector2 pivot = new Vector2(
                        subTexture.frameX / (float)subTexture.width,
                        1f - (subTexture.frameY / (float)subTexture.height)
                    );

                    // Create a sprite from the subtexture
                    spriteRenderer.sprite = Sprite.Create(
                        animationSet.texture,
                        new Rect(subTexture.x, adjustedY, subTexture.width, subTexture.height),
                        pivot
                    );

                    frameIndex++;
                    if (frameIndex >= subTextures.Count)
                    {
                        frameIndex = 0; // Loop back to the first frame
                    }
                }

                yield return null;
            }
        }

    }

}