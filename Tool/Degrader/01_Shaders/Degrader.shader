Shader "Custom/TransparentDegrader"
{
    Properties
    {
        _StartColor("Start Color", Color) = (1,1,1,1)
        _EndColor("End Color", Color) = (0,0,0,1)
        _IsHorizontal("Horizontal Gradient", Range(0,1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" } // Utilisation du type de rendu Transparent
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 texcoord : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            uniform float4 _StartColor;
            uniform float4 _EndColor;
            uniform float _IsHorizontal;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                if (_IsHorizontal > 0.5)
                {
                    float4 lerpedColor = lerp(_StartColor, _EndColor, i.texcoord.x);
                    return lerpedColor;
                }
                else
                {
                    float4 lerpedColor = lerp(_StartColor, _EndColor, i.texcoord.y);
                    return lerpedColor;
                }
            }
            ENDCG
        }
    }
}
