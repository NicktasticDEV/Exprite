Shader "Custom/SkewShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ShearX ("Shear X", Float) = 0.0
        _ShearY ("Shear Y", Float) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _ShearX;
            float _ShearY;

            v2f vert (appdata_t v)
            {
                v2f o;
                float4 vertex = v.vertex;

                // Apply shear transformation
                vertex.x += _ShearX * vertex.y;
                vertex.y += _ShearY * vertex.x;

                o.vertex = UnityObjectToClipPos(vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
        }
    }
}