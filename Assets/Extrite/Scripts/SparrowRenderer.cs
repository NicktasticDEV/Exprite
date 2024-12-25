using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Extrite
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SparrowRenderer : MonoBehaviour
    {
        // Public Variables
        public bool isPlaying { get; private set; }
        public string currentAnimation { get; private set; }

        // Components
        private SpriteRenderer spriteRenderer;

        // Fields for internal assets
        public SO_SparrowPack sparrowPack;

        // Store IEnumerator process
        private IEnumerator currentProcess;


        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Play(string name)
        {
            if (currentProcess != null)
            {
                StopCoroutine(currentProcess);
            }

            currentProcess = PlayAnimation(name);
            StartCoroutine(currentProcess);
        }

        public IEnumerator PlayAnimation(string name)
        {
            // Get the animation from sparrowPack by name, then with the prefix, get the subtextures in order
            Animation animation = sparrowPack.GetAnimation(name);
            List<SubTexture> subTextures = sparrowPack.GetSubTexturesFromAnimName(name);

            // Check if the animation is null
            if (animation.Equals(null) || subTextures.Count == 0)
            {
                Debug.LogError("Animation not found: " + name);
                yield break;
            }

            float FPS = animation.fps;

            int frameIndex = 0;
            float timePerFrame = 1f / FPS;
            float timeAccumulator = 0f;

            while (true)
            {
                isPlaying = true;
                currentAnimation = name;

                timeAccumulator += Time.deltaTime;

                if (timeAccumulator >= timePerFrame)
                {
                    Debug.Log("Playing frame " + frameIndex);
                    timeAccumulator -= timePerFrame;

                    // Set the sprite to the current frame
                    SubTexture subTexture = subTextures[frameIndex];
                    
                    float adjustedY = sparrowPack.sparrowPack.texture.height - subTexture.y - subTexture.height;

                    Vector2 pivot = new Vector2(
                        (subTexture.frameX + animation.offset.x) / (float)subTexture.width,
                        1f - ((subTexture.frameY + animation.offset.y) / (float)subTexture.height)
                    );

                    // Create a sprite from the subtexture
                    Sprite sprite = Sprite.Create(
                        sparrowPack.sparrowPack.texture,
                        new Rect(subTexture.x, adjustedY, subTexture.width, subTexture.height),
                        pivot,
                        100f
                    );

                    spriteRenderer.sprite = sprite;

                    frameIndex++;
                    if (frameIndex >= subTextures.Count)
                    {
                        if (animation.loop)
                        {
                            frameIndex = 0;
                        }
                        else
                        {
                            isPlaying = false;
                            currentAnimation = null;
                            yield break;
                        }
                    }
                }
                yield return null;
            }
 
        }

    }
}