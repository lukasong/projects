Shader "luka/commissions/Windwaker Dome/Bubbles Skybox"
{
    Properties
    {
        // coloring settings
        [Header(Coloring Settings)]
        [Space(5)]
        _ColorLow ("Low Color", Color) = (0.223529, 0.505882, 0.517647, 1)
        _ColorHigh ("High Color", Color) = (0.117647, 0.294118, 0.396078, 1)
        [PowerSlider(2.0)] _ColorBanding ("Color Bands", Range(0.1, 10)) = 2
        // noise settings
        [Space(10)]
        [Header(Bubble Settings)]
        [Space(5)]
        _WaveColor ("Bubble Color", Color) = (0.2284176, 0.5427855, 0.5566037, 1)
        _WaveScale ("Bubble Scale", Float) = 0.025
        _WaveSpeed ("Bubble Speed", Float) = 13.9
        _WaveAmount ("Bubble Amount", Float) = 1.35
        _WavePower ("Bubble Power", Float) = 0.94
        _WaveSize ("Bubble Size", Float) = 0.283
        [Toggle(_TOGGLE_BUBBLE_DISTORTION)] _BubbleDistortion ("Bubble Distortion", Range(0, 1)) = 0
        _BubbleDistortionSize ("Bubble Distortion Size", Float) = 0.1
        _BubbleDistortionPower ("Bubble Distortion Power", Float) = 1.5
    }
    SubShader {

        // rendering settings
        Tags { "RenderType"="Opaque" "Queue"="Transparent" "PreviewType"="Sphere" }
        ZWrite Off
        Cull Off

        Pass {

            // unity stuffs
            CGPROGRAM
            // #pragma fragmentoption ARB_precision_hint_fastest
            #pragma vertex phys
            #pragma fragment pixel
            #include "UnityCG.cginc"

            // declarations
            #pragma shader_feature_local _ _TOGGLE_BUBBLE_DISTORTION

            // structures
            struct appdata
            {
                float4 position : POSITION;
                float3 texcoord : TEXCOORD0;
            };
            struct v2f
            {
                float4 position : SV_POSITION;
                float3 texcoord : TEXCOORD0;
                float3 seed : TEXCOORD1;
                float precalc : TEXCOORD2;  
            };
            
            // property declarations
            float4 _ColorLow;
            float4 _ColorHigh;
            float _ColorBanding;

            float4 _WaveColor;
            float _WaveScale, _WaveSpeed, _WaveAmount,
            _WavePower, _WaveSize;

            #ifdef _TOGGLE_BUBBLE_DISTORTION
                float _BubbleDistortionPower, _BubbleDistortionSize;
            #endif 

            // functions (mostly borrowed from my june shader lol)
            float valueRemap(float value, float low1, float high1, float low2, float high2) {
                return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
            }

            // attribution for noise ports: Keijiro Takahash

            float wglnoise_mod(float x, float y)
            {
                return x - y * floor(x / y);
            }

            float2 wglnoise_mod(float2 x, float2 y)
            {
                return x - y * floor(x / y);
            }

            float3 wglnoise_mod(float3 x, float3 y)
            {
                return x - y * floor(x / y);
            }

            float4 wglnoise_mod(float4 x, float4 y)
            {
                return x - y * floor(x / y);
            }

            float2 wglnoise_fade(float2 t)
            {
                return t * t * t * (t * (t * 6 - 15) + 10);
            }

            float3 wglnoise_fade(float3 t)
            {
                return t * t * t * (t * (t * 6 - 15) + 10);
            }

            float wglnoise_mod289(float x)
            {
                return x - floor(x / 289) * 289;
            }

            float2 wglnoise_mod289(float2 x)
            {
                return x - floor(x / 289) * 289;
            }

            float3 wglnoise_mod289(float3 x)
            {
                return x - floor(x / 289) * 289;
            }

            float4 wglnoise_mod289(float4 x)
            {
                return x - floor(x / 289) * 289;
            }

            float3 wglnoise_permute(float3 x)
            {
                return wglnoise_mod289((x * 34 + 1) * x);
            }

            float4 wglnoise_permute(float4 x)
            {
                return wglnoise_mod289((x * 34 + 1) * x);
            }

            float4 SimplexNoiseGrad(float3 v) {
                // First corner
                float3 i = floor(v + dot(v, 1.0 / 3));
                float3 x0 = v - i + dot(i, 1.0 / 6);

                // Other corners
                float3 g = x0.yzx <= x0.xyz;
                float3 l = 1 - g;
                float3 i1 = min(g.xyz, l.zxy);
                float3 i2 = max(g.xyz, l.zxy);

                float3 x1 = x0 - i1 + 1.0 / 6;
                float3 x2 = x0 - i2 + 1.0 / 3;
                float3 x3 = x0 - 0.5;

                // Permutations
                i = wglnoise_mod289(i); // Avoid truncation effects in permutation
                float4 p = wglnoise_permute(i.z + float4(0, i1.z, i2.z, 1));
                p = wglnoise_permute(p + i.y + float4(0, i1.y, i2.y, 1));
                p = wglnoise_permute(p + i.x + float4(0, i1.x, i2.x, 1));

                // Gradients: 7x7 points over a square, mapped onto an octahedron.
                // The ring size 17*17 = 289 is close to a multiple of 49 (49*6 = 294)
                float4 gx = lerp(-1, 1, frac(floor(p / 7) / 7));
                float4 gy = lerp(-1, 1, frac(floor(p % 7) / 7));
                float4 gz = 1 - abs(gx) - abs(gy);

                bool4 zn = gz < - 0.01;
                gx += zn * (gx < - 0.01 ? 1 : - 1);
                gy += zn * (gy < - 0.01 ? 1 : - 1);

                float3 g0 = normalize(float3(gx.x, gy.x, gz.x));
                float3 g1 = normalize(float3(gx.y, gy.y, gz.y));
                float3 g2 = normalize(float3(gx.z, gy.z, gz.z));
                float3 g3 = normalize(float3(gx.w, gy.w, gz.w));

                // Compute noise and gradient at P
                float4 m = float4(dot(x0, x0), dot(x1, x1), dot(x2, x2), dot(x3, x3));
                float4 px = float4(dot(g0, x0), dot(g1, x1), dot(g2, x2), dot(g3, x3));

                m = max(0.5 - m, 0);
                float4 m3 = m * m * m;
                float4 m4 = m * m3;

                float4 temp = -8 * m3 * px;
                float3 grad = m4.x * g0 + temp.x * x0 +
                m4.y * g1 + temp.y * x1 +
                m4.z * g2 + temp.z * x2 +
                m4.w * g3 + temp.w * x3;

                return 107 * float4(grad, dot(m4, px));
            }

            float SimplexNoise(float3 v) {
                return SimplexNoiseGrad(v).w;
            }

            float ClassicNoise_impl(float3 pi0, float3 pf0, float3 pi1, float3 pf1)
            {
                pi0 = wglnoise_mod289(pi0);
                pi1 = wglnoise_mod289(pi1);

                float4 ix = float4(pi0.x, pi1.x, pi0.x, pi1.x);
                float4 iy = float4(pi0.y, pi0.y, pi1.y, pi1.y);
                float4 iz0 = pi0.z;
                float4 iz1 = pi1.z;

                float4 ixy = wglnoise_permute(wglnoise_permute(ix) + iy);
                float4 ixy0 = wglnoise_permute(ixy + iz0);
                float4 ixy1 = wglnoise_permute(ixy + iz1);

                float4 gx0 = lerp(-1, 1, frac(floor(ixy0 / 7) / 7));
                float4 gy0 = lerp(-1, 1, frac(floor(ixy0 % 7) / 7));
                float4 gz0 = 1 - abs(gx0) - abs(gy0);

                bool4 zn0 = gz0 < - 0.01;
                gx0 += zn0 * (gx0 < - 0.01 ? 1 : - 1);
                gy0 += zn0 * (gy0 < - 0.01 ? 1 : - 1);

                float4 gx1 = lerp(-1, 1, frac(floor(ixy1 / 7) / 7));
                float4 gy1 = lerp(-1, 1, frac(floor(ixy1 % 7) / 7));
                float4 gz1 = 1 - abs(gx1) - abs(gy1);

                bool4 zn1 = gz1 < - 0.01;
                gx1 += zn1 * (gx1 < - 0.01 ? 1 : - 1);
                gy1 += zn1 * (gy1 < - 0.01 ? 1 : - 1);

                float3 g000 = normalize(float3(gx0.x, gy0.x, gz0.x));
                float3 g100 = normalize(float3(gx0.y, gy0.y, gz0.y));
                float3 g010 = normalize(float3(gx0.z, gy0.z, gz0.z));
                float3 g110 = normalize(float3(gx0.w, gy0.w, gz0.w));
                float3 g001 = normalize(float3(gx1.x, gy1.x, gz1.x));
                float3 g101 = normalize(float3(gx1.y, gy1.y, gz1.y));
                float3 g011 = normalize(float3(gx1.z, gy1.z, gz1.z));
                float3 g111 = normalize(float3(gx1.w, gy1.w, gz1.w));

                float n000 = dot(g000, pf0);
                float n100 = dot(g100, float3(pf1.x, pf0.y, pf0.z));
                float n010 = dot(g010, float3(pf0.x, pf1.y, pf0.z));
                float n110 = dot(g110, float3(pf1.x, pf1.y, pf0.z));
                float n001 = dot(g001, float3(pf0.x, pf0.y, pf1.z));
                float n101 = dot(g101, float3(pf1.x, pf0.y, pf1.z));
                float n011 = dot(g011, float3(pf0.x, pf1.y, pf1.z));
                float n111 = dot(g111, pf1);

                float3 fade_xyz = wglnoise_fade(pf0);
                float4 n_z = lerp(float4(n000, n100, n010, n110),
                float4(n001, n101, n011, n111), fade_xyz.z);
                float2 n_yz = lerp(n_z.xy, n_z.zw, fade_xyz.y);
                float n_xyz = lerp(n_yz.x, n_yz.y, fade_xyz.x);
                return 1.46 * n_xyz;
            }

            // Classic Perlin noise
            float ClassicNoise(float3 p)
            {
                float3 i = floor(p);
                float3 f = frac(p);
                return ClassicNoise_impl(i, f, i + 1, f - 1);
            }

            // Classic Perlin noise, periodic variant
            float PeriodicNoise(float3 p, float3 rep)
            {
                float3 i0 = wglnoise_mod(floor(p), rep);
                float3 i1 = wglnoise_mod(i0 + 1, rep);
                float3 f = frac(p);
                return ClassicNoise_impl(i0, f, i1, f - 1);
            }

            void doPixelateFloat(inout float2 inputUVs,
            float inputPixelateX, float inputPixelateY) {
                // simple, square pixelation that will automatically format for floats :D
                float2 pixelateValues = ceil(abs(float2(inputPixelateX, inputPixelateY)));
                inputUVs = (floor((pixelateValues * inputUVs)) / pixelateValues);
            }

            // vertex pass
            v2f phys(appdata v) {
                v2f o;
                o.position = UnityObjectToClipPos(v.position);
                o.texcoord = v.texcoord;
                o.seed = mul(unity_ObjectToWorld, v.position);
                o.precalc.x = abs(sin((abs(v.texcoord.y - 0.5) * 2.0) * _ColorBanding)); // sky has like alternating gradients
                return o;
            }
            
            // pixel pass
            float4 pixel(v2f i) : COLOR {
                float4 skyColor = lerp(_ColorLow, _ColorHigh, i.precalc.x); 
                float softenFactor = saturate(valueRemap((/* 1.0 - */ (abs(i.texcoord.y - 0.5) * 2.0)), 0.6, 0, 0, 1)); // soften the waves by the top and bottom of sphere cos stretching
                // fade out on edges of x factor too and move this to vertice
                // skyColor.rgb = lerp(skyColor.rgb, _WaveColor.rgb, softenFactor);
                i.seed.y -= (_Time.y * _WaveSpeed);
                i.seed.x *= 2;
                i.seed.z *= 2;
                #ifdef _TOGGLE_BUBBLE_DISTORTION
                    i.seed.y += ((sin(i.seed.x * _BubbleDistortionSize) * _BubbleDistortionPower) + cos(i.seed.z * _BubbleDistortionSize) * _BubbleDistortionPower);
                #endif 
                // make the noise more jagged
                // float noise = PeriodicNoise(i.seed * 0.05, float3(0, 0, 0));
                float noise = SimplexNoise(i.seed * _WaveScale);
                noise += SimplexNoise(i.seed * _WaveScale * 0.5) - 0.5;
                // less waves
                noise += _WaveAmount;
                // cut out the centers
                if (noise > _WaveSize) noise = 0;
                // remap 0 to 0.4 to 0 to 1
                float waveFade = valueRemap(noise, 0, 0.4, 0, 1);
                // now move it from 0->1 to 0->1->0
                waveFade = 1.0 - (abs(waveFade - 0.5) * 2.0);
                noise = waveFade;
                // remap noise from 0.4 to 1.0 to 0.0 to 1.0
                //noise = valueRemap(noise, 0, 0.4, 0, 1);
                // skyColor.rgb += _WaveColor.rgb * _WaveAmount * pow(noise, _WavePower) * softenFactor;
                skyColor.rgb = lerp(skyColor.rgb, _WaveColor.rgb, _WavePower * saturate((noise)));


                return skyColor;
            }
            ENDCG

        }
    }
}
