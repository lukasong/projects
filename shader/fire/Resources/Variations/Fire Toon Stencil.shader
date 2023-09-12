Shader "luka/randoms/Fire/Toon Stencil"
{
    Properties
    {
        [Header(Color Settings)]
        [Space(5)]
        _Brightness ("Brightness", Range(0, 3)) = 1
        _MaxBrightness ("Max Brightness", Range(0, 2)) = 1.2
        [IntRange] _Toonify ("Toonify", Range(15, 1)) = 5
        _ColorLow ("Color Low", Color) = (1, 1, 1, 1)
        _ColorHigh ("Color High", Color) = (1, 1, 1, 1)
        [Header(Flame Settings)]
        [Space(5)]
        _Threshold ("Threshold", Range(0, 1)) = 0.8
        _Pointed ("Pointed", Range(0, 20)) = 10
        _MaxTravel ("Max Travel", Range(0, 1)) = 0.6
        [Space(10)]
        [Header(Distortion Settings)]
        [Space(5)]
        _DistortionTex ("Distortion Texture", 2D) = "" { }
        _DistortionScale ("Distortion Scale", Range(0, 4)) = 0.5
        _DistortionSpeed ("Distortion Speed", Range(0, 2)) = 0.5
        _DistortionPower ("Distortion Power", Range(0, 5)) = 0.05
        [Space(10)]
        [Header(Stencil Settings)]
        [Space(5)]
        [IntRange] _StencilRef ("Stencil Value", Range(0, 255)) = 0
        [HideInInspector] _Mask ("Mask", 2D) = "" { }
    }
    SubShader
    {

        // render settings
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha

        // optional stencil support
        Stencil
        {
            Ref [_StencilRef]
            Comp Always
            Pass Replace
        }

        // shader program
        Pass
        {
            CGPROGRAM
            #pragma vertex physics
            #pragma fragment pixel
            #include "UnityCG.cginc"

            // structures
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            // vertex properties
            sampler2D _Mask;
            float4 _Mask_ST;

            // vertex program
            v2f physics (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _Mask);
                return o;
            }

            // pixel functions
            float approx_pow(float a, float b)
            {
                return a / ((1. - b) * a + b);
            }

            float posterize(float value, float steps)
            {
                return floor(value * steps) / steps;
            }

            float remap_value(float value, float old_min, float old_max, float new_min, float new_max)
            {
                return (((value - old_min) * (new_max - new_min)) / (old_max - old_min)) + new_min;
            }

            float draw_circle(float2 uv, float width, float height)
            {
                float d = length((uv * 2 - 1) / float2(width, height));
                return float(saturate((1 - d) / fwidth(d)));
            }

            // pixel properties
            sampler2D _DistortionTex;
            float4 _ColorLow, _ColorHigh;
            float _DistortionScale, _DistortionSpeed, _DistortionPower;
            float _Threshold, _Brightness, _MaxBrightness, _Toonify;
            float _MaxTravel, _Pointed;

            // pixel program
            float4 pixel (v2f i) : SV_Target 
            {
                // init sample
                float4 final_col = float4(1, 1, 1, 1);
                // triangle-like culling
                [branch] if (_Pointed != 0) {
                    float x_center = approx_pow(1.0 - abs(i.uv.x - 0.5) * 2.0, _Pointed);
                    float y_test = (remap_value(i.uv.y, 0., 0.6, 0.0, 1.0));
                    x_center = lerp(1.0, x_center, y_test);
                    _DistortionPower *= x_center;
                }
                // create scrolling noise
                float2 scrolling_uvs = (i.uv * _DistortionScale) - float2(0, _Time.y * _DistortionSpeed);
                float distortion_value = tex2D(_DistortionTex, scrolling_uvs).r;
                // creating the flame distortion
                distortion_value = (distortion_value - _Threshold);
                distortion_value = distortion_value * _DistortionPower;
                // clean the edges of the flame
                float clean_edges = approx_pow(i.uv.y, 1.7);
                distortion_value *= clean_edges;
                // and create the uvs for the mask
                float2 mask_uvs = i.uv + float2(0, distortion_value);
                float original_flame = draw_circle(mask_uvs, 0.5, 0.5);
                // and create a better --> TOONY <-- "flame" shape
                float y_clone = 1.0 - mask_uvs.y;
                y_clone = pow(y_clone, 2.0);
                float2 new_uvs = float2(mask_uvs.x, y_clone);
                final_col = draw_circle(new_uvs, 0.5, 0.5);
                float temp_circ = draw_circle(new_uvs, 0.5, 0.5);
                float new_y_clone = new_uvs.y + 0.4;
                new_y_clone *= 1.5;
                new_y_clone = posterize(new_y_clone, _Toonify);
                // and combine
                final_col += new_y_clone;
                final_col.rgba = lerp(_ColorLow, _ColorHigh, final_col.r);
                // and mask
                float mask_alpha = draw_circle(new_uvs, 0.55, _MaxTravel);
                final_col.a *= mask_alpha;
                // and cull some of the top
                float cull_top_of_y = saturate(remap_value(i.uv.y, 0.7, 1.0, 1.0, -0.1));
                final_col.a *= cull_top_of_y;
                // post-process
                final_col.rgb *= _Brightness;
                final_col.rgb = clamp(final_col.rgba, 0.0, _MaxBrightness);
                // return
                return final_col;
            }

            ENDCG
        }
    }
    Fallback "Standard"
    CustomEditor "Luka.FireUI"
}
