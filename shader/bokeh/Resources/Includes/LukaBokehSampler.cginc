// copyright notice will go here.
#ifndef LUKA_BOKEH_SAMPLER
#define LUKA_BOKEH_SAMPLER

// BLUR HELPERS
float2 Jitter(float2 uv) {
    [branch] if (_Dithering != 0) {
        float2 jitter_cache = unity_noise_random_value(uv + frac(_Time.y * 0.1));
        jitter_cache = (jitter_cache * 2.0) - 1.0;
        jitter_cache *= _Dithering * 0.01;
        uv += jitter_cache;
    }
    return uv;
}

float2 Jitter(float2 uv, float target) {
    [branch] if (_Dithering != 0) {
        float2 jitter_cache = unity_noise_random_value(uv + frac(_Time.y * 0.1));
        jitter_cache = (jitter_cache * 2.0) - 1.0;
        jitter_cache *= _Dithering * 0.01 * target;
        uv += jitter_cache;
    }
    return uv;
}

float Find_Confusion(float base, float target) {
    float coc = 0;
    #if defined(BOKEH_PASS_ONE)
        base *= _FarPlane; 
        target *= _FarPlane;
        coc = abs(base - target) / 0.75; 
        coc *= coc * _BokehPower;
        coc = clamp(coc, 0, _MaxDiameter);
        coc = approxPow(coc, _Aperature);
    #endif // BOKEH_PASS_ONE
    return coc;
}

float4 Boolean_Union(float4 colors_one, float4 colors_two) {
    return min(colors_one, colors_two);
}

float4 Boolean_Intersection(float4 colors_one, float4 colors_two) {
    return max(colors_one, colors_two);
}

float3 Clean_Summation(float3 summation) {
    return max(summation, 0.0); // this could be a problem, i guess..
}

float2 Determine_Guide(float2 uvs, float seed_x, float seed_y) {
    #if defined(_BOKEH_RANDOMIZED)
        float index_start = 0;
        float index_speed = _GuideRandomizeSpeed;
        float index_max = _GuideRandomizeY * _GuideRandomizeX;
        float2 index_scale = floor((float2(seed_x, seed_y) + float2(1.0, 1.0)) * _GuideRandomizeVariation);
        // for some reason, unity is not liking jump tables here.. insta crash :(
        [branch] if (_GuideRandomizeStyle == 0) {
            // location
            index_start = round(hash22(index_scale).x * index_max - 1);
            index_speed = 0;
        } else if (_GuideRandomizeStyle == 2) {
            // location and time
            index_start = round(hash22(index_scale).x * index_max - 1);
            index_speed += lerp(0, index_speed, index_start);
        } else {
            // time (nothing for now..)
        }
        return make_spritesheet(_GuideRandomizeY, _GuideRandomizeX, index_max, index_speed, index_start, uvs);
    #else // _BOKEH_RANDOMIZED
        return uvs;
    #endif // _BOKEH_RANDOMIZED
}

float2 Determine_Shape(float2 uvs, float seed_x, float seed_y) {
    #if defined(_BOKEH_ANIMATION)
        float2 spread = floor((float2(seed_x, seed_y) + float2(1.0, 1.0)) * _AnimationVariation);
        [branch] if (_AnimationRotation != 0) {
            float rotation_speed = _AnimationRotationSpeed;
            [branch] if (_AnimationRotation == 2) {
                float rotation_seed = hash22(spread).x;
                rotation_speed = (rotation_seed * _AnimationRotationSpeed) + rotation_speed;
            }
            uvs = rotate_radians(uvs, float2(0.5, 0.5), rotation_speed * _Time.y);
        }
        [branch] if (_AnimationScale != 0) {
            float scale_speed = _AnimationScaleSpeed;
            [branch] if (_AnimationScale == 2) {
                float scale_seed = hash22(spread).x;
                scale_speed = (scale_seed * _AnimationScaleSpeed) + scale_speed;
            }
            float scale_time_based = abs(remap_value(scale_speed * sin(_Time.y), -scale_speed, scale_speed, _AnimationScaleMinimum, _AnimationScaleMaximum));
            uvs = lerp(uvs, zoom_uvs(uvs, float2(0.5, 0.5), -1.0 * scale_time_based), _AnimationScalePower);
        }
        if (is_out(uvs)) uvs = float2(0.99, 0.99); // "cheap" trick to retain boundaries
    #endif // _BOKEH_ANIMATION
    return uvs;
}

// BLUR FACTORS
float Factor_Depth(float depth, float coc) {
    #if defined(BOKEH_PASS_ONE)
    depth *= 50.0;
    depth = 1.0 - depth;
    if (depth < _FactorDepthCutoff) {
        // now depth needs remapped from 0 to 1 to 0 to _FactorDepthCutoff
        depth = saturate(remap_value(depth, 0, _FactorDepthCutoff, 0, 1));
        coc *= lerp(1, depth, _FactorDepthInfluence);
    }
    #endif // BOKEH_PASS_ONE
    return coc;
}

float Factor_Luma(float3 colors, float coc) {
    #if defined(BOKEH_PASS_ONE)
    float tapped_luma = get_luma(colors);
    float luma = 1.0 + (tapped_luma * 4.0);
    if (tapped_luma > _FactorLumaMinimum) {
        coc *= lerp(1, luma, _FactorLumaInfluence);
    }
    #endif // BOKEH_PASS_ONE
    return coc;
}

// BLUR STEPS
float4 Step_Seperable_Texture(float4 colors, float2 uvs,
    v2f data, float target, sampler2D grab) {
    #if defined(BOKEH_PASS_THREE)
        #if defined(_BOKEH_HD)
            const float tap_offsets_baked_x [22] = {
                float(-1),
                float(0.045454547), 
                float(0.09090909), 
                float(0.13636364), 
                float(0.18181819), 
                float(0.22727273), 
                float(0.27272728), 
                float(0.3181818), 
                float(0.36363637), 
                float(0.4090909), 
                float(0.45454547), 
                float(0.5),
                float(0.54545456), 
                float(0.59090906), 
                float(0.6363636), 
                float(0.6818182), 
                float(0.72727275), 
                float(0.77272725), 
                float(0.8181818), 
                float(0.8636364), 
                float(0.90909094), 
                float(0.95454544), 
            };
            const float tap_offsets_baked_y [22] = {
                float(-1.0),
                float(0.95454544), 
                float(0.9090909), 
                float(0.8636364), 
                float(0.8181818), 
                float(0.77272725), 
                float(0.72727275), 
                float(0.6818182), 
                float(0.6363636), 
                float(0.5909091), 
                float(0.5454545), 
                float(0.5), 
                float(0.45454544), 
                float(0.40909094), 
                float(0.36363637), 
                float(0.3181818), 
                float(0.27272725), 
                float(0.22727275), 
                float(0.18181819), 
                float(0.13636363), 
                float(0.090909064), 
                float(0.04545456),
            };
            const float tap_uv_baked [22] = {
                    float(-11.0), 
                    float(-10.0), 
                    float(-9.0), 
                    float(-8.0), 
                    float(-7.0), 
                    float(-6.0), 
                    float(-5.0), 
                    float(-4.0), 
                    float(-3.0), 
                    float(-2.0), 
                    float(-1.0), 
                    float(0.0), 
                    float(1.0), 
                    float(2.0), 
                    float(3.0), 
                    float(4.0), 
                    float(5.0), 
                    float(6.0), 
                    float(7.0), 
                    float(8.0), 
                    float(9.0), 
                    float(10.0), 
            };
        #else // _BOKEH_HD
            const float tap_offsets_baked_x[14] = {
                float(-1.0),
                float(0.0769231),
                float(0.1538462),
                float(0.2307692),
                float(0.3076923),
                float(0.3846154),
                float(0.4615385),
                float(0.5384615),
                float(0.6153846),
                float(0.6923077),
                float(0.7692308),
                float(0.8461538),
                float(0.9230769),
                float(0.9769231) // miscalculated.. sorry.... tired..
            };
            const float tap_offsets_baked_y[14] = {
                float(-1.0),
                float(0.9769231), // miscalculated.. sorry.... tired..
                float(0.9230769),
                float(0.8461538),
                float(0.7692308),
                float(0.6923077),
                float(0.6153846),
                float(0.5384615),
                float(0.4615385),
                float(0.3846154),
                float(0.3076923),
                float(0.2307692),
                float(0.1538462),
                float(0.0769231)
            };
            const float tap_uv_baked[14] = {
                float(-7.0),
                float(-6.0),
                float(-5.0),
                float(-4.0),
                float(-3.0),
                float(-2.0),
                float(-1.0),
                float(0.0),
                float(1.0),
                float(2.0),
                float(3.0),
                float(4.0),
                float(5.0),
                float(6.0)
            };
        #endif // _BOKEH_HD
    if (_Power == 0) return float4(srgb_to_linear(colors.rgb), colors.a);
    float3 convolution = float3(0, 0, 0);
    float3 weight = float3(1, 1, 1);
    [fastopt] for (int i = 1; i < BOKEH_SQRT_SAMPLES / 2.0; i++) {
        [fastopt] for (int j = 1; j < BOKEH_SQRT_SAMPLES; j++) {
            // calculate the tap offset
            float2 tap_offset = float2(0, 0);
            tap_offset.x = tap_uv_baked[i];
            tap_offset.y = tap_uv_baked[j];
            tap_offset /= _ScreenParams.xy / float(BOKEH_SQRT_SAMPLES) / _Power / target; // and make flaot
            float2 blur_uvs = Jitter(uvs + tap_offset, target);
            // calculate the uvs for the shape
            float2 tap_uvs = float2(0, 0);
            tap_uvs.x = tap_offsets_baked_x[i];
            tap_uvs.y = tap_offsets_baked_y[j];
            // modify the shape as needed
            tap_uvs = Determine_Shape(tap_uvs, blur_uvs.x, blur_uvs.y);
            tap_uvs = Determine_Guide(tap_uvs, blur_uvs.x, blur_uvs.y);
            // calculate the weight
            float tap_weight = BOKEH_LUKA_SAMPLER_SCREENSPACE(_Guide, tap_uvs);
            if (tap_weight < 1e-2) continue; // this was better off earlier on, but prohibited more complex settings
            // add and continue if needed
            convolution += tap_weight * srgb_to_linear(BOKEH_LUKA_SAMPLER_SCREENSPACE(grab, blur_uvs).rgb);
            weight += tap_weight;
        }
    }
    [fastopt] for (int i = BOKEH_SQRT_SAMPLES / 2.0; i < BOKEH_SQRT_SAMPLES; i++) {
        [fastopt] for (int j = 1; j < BOKEH_SQRT_SAMPLES; j++) {
            // calculate the tap offset
            float2 tap_offset = float2(0, 0);
            tap_offset.x = tap_uv_baked[i];
            tap_offset.y = tap_uv_baked[j];
            tap_offset /= _ScreenParams.xy / float(BOKEH_SQRT_SAMPLES) / _Power / target;
            float2 blur_uvs = Jitter(uvs + tap_offset, target);
            // calculate the uvs for the shape
            float2 tap_uvs = float2(0, 0);
            tap_uvs.x = tap_offsets_baked_x[i];
            tap_uvs.y = tap_offsets_baked_y[j];
            // modify the shape as needed
            tap_uvs = Determine_Shape(tap_uvs, blur_uvs.x, blur_uvs.y);
            tap_uvs = Determine_Guide(tap_uvs, blur_uvs.x, blur_uvs.y);
            // calculate the weight of the tap
            float tap_weight = BOKEH_LUKA_SAMPLER_SCREENSPACE(_Guide, tap_uvs);
            if (tap_weight < 1e-2) continue; // this was better off earlier on, but prohibited more complex settings
            // add and continue if needed
            convolution += tap_weight * srgb_to_linear(BOKEH_LUKA_SAMPLER_SCREENSPACE(grab, blur_uvs).rgb);
            weight += tap_weight;
        }
    }
    return float4(Clean_Summation(convolution * rcp(weight)), colors.a);
    #endif // BOKEH_PASS_THREE
    return colors;
}

float4 Step_Confusion(float4 colors, float2 uvs,
    float base, float target,
    v2f data, sampler2D grab) {
    #if defined(BOKEH_PASS_ONE)
    float coc = Find_Confusion(base, target);
    #if defined(_BOKEH_CLEAN)
    [fastopt] for (int i = -BOKEH_CLEANER; i <= BOKEH_CLEANER; i++) {
        [fastopt] for (int j = -BOKEH_CLEANER; j <= BOKEH_CLEANER; j++) {
            float2 tap_uvs = uvs * data.grabPos.w;
            tap_uvs += (float2(i, j) * _CocSpread);
            float depth_tap = getVRCLinearDepth01(data.pos, float3(tap_uvs, data.grabPos.z), data.worldDir, data.worldPos, _CameraDepthTexture);
            float tap_coc = Find_Confusion(depth_tap, target);
            coc = min(coc, tap_coc);
        }
    }
    [branch] if (_FactorDepth == 1) {
        float factor_depth_tap = getVRCLinearDepth01(data.pos, data.grabPos.xyz, data.worldDir, data.worldPos, _CameraDepthTexture);
        coc = Factor_Depth(factor_depth_tap, coc);
    }
    [branch] if (_FactorLuma == 1) {
        coc = Factor_Luma(colors.rgb, coc);
    }
    #endif // _BOKEH_CLEAN
    colors.a = coc;
    #endif // BOKEH_PASS_ONE
    return colors;
}

float4 Step_Deconstruction(float4 colors, float2 uvs) {
    #if defined(BOKEH_PASS_ONE)
    [branch] if (_Accentuate != 0) {
        float3 base = colors - 0.1;
        base /= (0.9);
        colors.rgb = lerp(colors.rgb, (base * base), _Accentuate);
    }
    #endif // BOKEH_PASS_ONE
    return colors;
}

float4 Step_Reconstruction(float4 colors, float2 uvs,
    float tap) {
    #if defined(BOKEH_PASS_THREE)
    [branch] if (_ColorGrading != 0) {
        colors.rgb = lerp(colors.rgb, aces_approximation(colors.rgb), _ColorGrading * tap);
    }
    [branch] if (_Exposure != 1) {
        colors.rgb *= (1.0 + (get_luma(colors.rgb) * _Exposure) * tap);
    }
    [branch] if (_ColorMode == 1) {
         // tap based
        float color_tap = saturate((tap + tap) * 3.0);
        colors.rgb *= lerp(float3(1, 1, 1), _Color.rgb, color_tap);
    } else if (_ColorMode == 2) {
        // screen based
        colors.rgb *= _Color.rgb;
    }
    [branch] if (_HSVMode != 0) {
        float3 colors_hsv = rgb_to_hsv(colors.rgb);
        [branch] if (_HSVMode == 1) {
            // add (1)
            colors_hsv.r += (_Hue - 1.0);
            colors_hsv.g += (_Saturation - 1.0);
            colors_hsv.b += (_Value - 1.0);
        } else {
            // multiply (2)
            colors_hsv.r *= _Hue;
            colors_hsv.g *= _Saturation;
            colors_hsv.b *= _Value;
        }
        // whether to apply to just tapped areas or whole screen
        [branch] if (_HSVTapBased == 1.0) {
            colors.rgb = lerp(colors.rgb, hsv_to_rgb(colors_hsv), saturate((tap + tap) * 3.0));       
        } else {
            colors.rgb = hsv_to_rgb(colors_hsv);
        }
    }
    #endif // BOKEH_PASS_THREE
    return colors;
}

float4 Step_Smoothen(float4 colors, float2 uvs,
    v2f data, sampler2D grab) {
    #if defined(BOKEH_PASS_TWO)
    #if defined(_BOKEH_CLEAN)
    // box blur the alpha channel
    [fastopt] for (int i = -BOKEH_CLEANER; i <= BOKEH_CLEANER; i++) {
        [fastopt] for (int j = -BOKEH_CLEANER; j <= BOKEH_CLEANER; j++) {
            float2 tap_uvs = uvs + (float2(i, j) * _BlendingRadius);
            colors.a += BOKEH_LUKA_SAMPLER_SCREENSPACE(grab, tap_uvs).a;
        }
    }
    colors.a /= (float((float)BOKEH_CLEANER * 2 + 1) * float((float)BOKEH_CLEANER * 2 + 1));
    #endif // _BOKEH_CLEAN
    #endif // BOKEH_PASS_TWO
    return colors;
}

// PERFORMING THE PASSES
#if defined(BOKEH_PASS_ONE)
    float4 Pass_One(float4 colors, float2 uvs,
        v2f data) {
        colors = Step_Deconstruction(colors, uvs);
        float depth_tap_current = getVRCLinearDepth01(data.pos, data.grabPos.xyz, data.worldDir, data.worldPos, _CameraDepthTexture);
        float depth_tap_target = _ManualFocus;
        [branch] if (_FocalMode == 1) {
            float2 center = makeCenter(uvs.xy, _FocalX, _FocalY) * data.grabPos.w;
            depth_tap_target = getVRCLinearDepth01(data.pos, float3(center.xy, data.grabPos.z), data.worldDir, data.worldPos, _CameraDepthTexture);
        } else if (_FocalMode == 0) {
            depth_tap_target = smoothstep(0.5, 0.05, depth_tap_target);
        } else {
            depth_tap_target = 1.0;
        }
        colors = Step_Confusion(colors, uvs, depth_tap_current, depth_tap_target, data, _BokehGrabOne);
        return colors;
    }
#elif defined(BOKEH_PASS_TWO)
    float4 Pass_Two(float4 colors, float2 uvs,
        v2f data) {
        float tapPower = colors.a;
        colors = Step_Smoothen(colors, uvs, data, _BokehGrabTwo);
        return colors;
    }
#elif defined(BOKEH_PASS_THREE) 
    float4 Pass_Three(float4 colors, float2 uvs,
        v2f data) {
        float tapPower = colors.a;
        colors = Step_Seperable_Texture(colors, uvs, data, tapPower, _BokehGrabThree);
        colors.rgb = linear_to_srgb(colors.rgb);
        colors = Step_Reconstruction(colors, uvs, tapPower);
        colors.a = 1.0;
        colors.a = tapPower;
        return colors;
    }
#endif // BOKEH_PASS_ONE

#endif // LUKA_BOKEH_SAMPLER