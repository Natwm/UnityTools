Shader "Custom/LerpBetweenColors"
{
    Properties
    {
        _FillAmount ("Fill Amount", Range(0, 1)) = 0.5
        _ColorA ("Color A", Color) = (1, 0, 0, 1)
        _ColorB ("Color B", Color) = (0, 0, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR0;
            };

            float _FillAmount;
            fixed4 _ColorA;
            fixed4 _ColorB;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 lerpedColor = lerp(_ColorA, _ColorB, _FillAmount);
                return lerpedColor;
            }
            ENDCG
        }
    }
}
