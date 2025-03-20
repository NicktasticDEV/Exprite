using System.Collections.Generic;
using UnityEngine;


namespace Exprite
{
    [System.Serializable]
    public struct AnimationDefinition
    {
        // Stuff in JSON
        public string name;
        public string prefix;
        public int fps;
        public bool loop;
        public Vector2 offset;
    }
}