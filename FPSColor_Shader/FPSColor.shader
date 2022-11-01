Shader "luka/others/FPSColor"
{
    Properties
    {
        _GoodColor ("Good Color", Color) = (0., 1., 0., 1)
        _MediumColor ("Medium Color", Color) = (0., 0., 1., 1)
        _BadColor ("Bad Color", Color) = (1., 0, 0, 1)
        _GoodLimit ("Good Limit", Range(0, 100)) = 60
        _MediumLimit ("Medium Limit", Range(0, 100)) = 30
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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
                float fps : TEXCOORD1;
            };

            float _GoodLimit, _MediumLimit;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                int intFps = unity_DeltaTime.w;
	            float nDigits = (float) (floor(log10(abs(intFps))) + 1);
                if (nDigits > _GoodLimit) {
                    o.fps = 2;
                } else if (nDigits > _MediumLimit) {
                    o.fps = 1;
                } else {
                    o.fps = 0;
                }
                return o;
            }

            float4 _GoodColor, _MediumColor, _BadColor;

            fixed4 frag (v2f i) : SV_Target
            {
                float3 colorMatrix[3];
                colorMatrix[0] = _BadColor.rgb;
                colorMatrix[1] = _MediumColor.rgb;
                colorMatrix[2] = _GoodColor.rgb;
                return float4(colorMatrix[int(i.fps)], 1);
            }
            ENDCG
        }
    }
}
