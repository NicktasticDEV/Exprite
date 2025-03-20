using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Extrite
{
    [XmlRoot(ElementName="TextureAtlas")]
    public class TextureAtlas { 

        [XmlElement(ElementName="SubTexture")] 
        public List<SubTexture> SubTexture { get; set; } 

        [XmlAttribute(AttributeName="imagePath")] 
        public string imagePath { get; set; } 
    }
}

