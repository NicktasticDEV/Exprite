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
        public Animation? currentAnimation { get; private set; }

        public List<PreloadAnimData> preloadedAnimationsData;

        // Components
        private SpriteRenderer spriteRenderer;

        // Fields
        public bool preloadAnimationPack = false;

        private SO_SparrowAnimationPack previousSparrowAnimationPack;
        public SO_SparrowAnimationPack sparrowAnimationPack;

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            if (preloadAnimationPack && sparrowAnimationPack != null)
            {
                PreloadAnimationPack();
            }
        }

        void Update()
        {
            if (previousSparrowAnimationPack != sparrowAnimationPack && sparrowAnimationPack != null)
            {
                OnSparrowAnimationPackChanged();
                previousSparrowAnimationPack = sparrowAnimationPack;
            }
        }

        public void Play(string animationName)
        {
            if (isPlaying)
            {
                StopAllCoroutines();
            }

            StartCoroutine(PlayAnimation(animationName));
        }

        [ContextMenu("Import Sparrow Animation Pack")]
        public void ImportSparrowAnimationPack()
        {
            string path = Extrite.Utilities.GetPathFromDialogue("Import Sparrow Animation Pack", "esap", false);
            sparrowAnimationPack = Extrite.Utilities.ImportSparrowAnimationPack(path);
        }

        IEnumerator PlayAnimation(string animationName)
        {
            Animation animation = sparrowAnimationPack.GetAnimationByName(animationName);

            PreloadAnimData preloadAnimData;

            if (preloadAnimationPack)
            {
                preloadAnimData = GetPreloadAnimDataByName(animationName);
            }
            else
            {
                preloadAnimData = null;
            }

            isPlaying = true;
            currentAnimation = animation;

            int frameIndex = 0;
            float timePerFrame = 1f / animation.fps;
            float timeAccumulator = 0f;

            SubTexture[] subTextures = sparrowAnimationPack.GetSubTexturesFromAnimation(animation);

            while (true)
            {
                timeAccumulator += Time.deltaTime;

                // Check if we need to move to the next frame
                if (timeAccumulator >= timePerFrame)
                {
                    timeAccumulator -= timePerFrame;

                    if (!preloadAnimationPack)
                    {
                        SubTexture subTextureFrame = subTextures[frameIndex];
                        float adjustedY = sparrowAnimationPack.texture.height - subTextureFrame.y - subTextureFrame.height;

                        Vector2 pivot = new Vector2(
                            (subTextureFrame.frameX - animation.offset.x - sparrowAnimationPack.globalOffset.x) / subTextureFrame.width,
                            1f - ((subTextureFrame.frameY + animation.offset.y + sparrowAnimationPack.globalOffset.y) / subTextureFrame.height)
                        );

                        spriteRenderer.sprite = Sprite.Create(
                            sparrowAnimationPack.texture,
                            new Rect(subTextureFrame.x, adjustedY, subTextureFrame.width, subTextureFrame.height),
                            pivot
                        );
                    }
                    else
                    {
                        spriteRenderer.sprite = preloadAnimData.sprites[frameIndex];
                    }

                    frameIndex++;

                    // Check if we reached the end of the animation
                    if (frameIndex >= subTextures.Length)
                    {
                        //Check if animation is supposed to loop
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
    
        void OnSparrowAnimationPackChanged()
        {
            Debug.Log("Sparrow Animation Pack Changed");
            if (preloadAnimationPack)
            {
                PreloadAnimationPack();
            }
        }

        PreloadAnimData GetPreloadAnimDataByName(string animationName)
        {
            foreach (PreloadAnimData preloadAnimData in preloadedAnimationsData)
            {
                if (preloadAnimData.name == animationName)
                {
                    return preloadAnimData;
                }
            }

            throw new System.Exception("Preload Animation Data not found: " + animationName);
        }

        void PreloadAnimationPack()
        {
            Debug.Log("Preloading Animation Pack");
            preloadedAnimationsData = new List<PreloadAnimData>();

            foreach (Animation animation in sparrowAnimationPack.animations)
            {
                PreloadAnimData preloadAnimData = new PreloadAnimData();
                preloadAnimData.name = animation.name;
                preloadAnimData.sprites = new List<Sprite>();

                foreach (SubTexture subTexture in sparrowAnimationPack.GetSubTexturesFromAnimation(animation))
                {
                    float adjustedY = sparrowAnimationPack.texture.height - subTexture.y - subTexture.height;

                    Vector2 pivot = new Vector2(
                        (subTexture.frameX - animation.offset.x - sparrowAnimationPack.globalOffset.x) / subTexture.width,
                        1f - ((subTexture.frameY + animation.offset.y + sparrowAnimationPack.globalOffset.y) / subTexture.height)
                    );

                    Sprite sprite = Sprite.Create(
                        sparrowAnimationPack.texture,
                        new Rect(subTexture.x, adjustedY, subTexture.width, subTexture.height),
                        pivot
                    );

                    preloadAnimData.sprites.Add(sprite);
                }

                preloadedAnimationsData.Add(preloadAnimData);
            }
        }
    
    }
}