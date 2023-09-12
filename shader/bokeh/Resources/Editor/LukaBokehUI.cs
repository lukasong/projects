
#if UNITY_EDITOR
using UnityEngine;
using System.IO;
using System;
using UnityEditor;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
#pragma warning disable 0105 // disable warning for unused variables

namespace Luka 
{

    // luka basic ui version 3
    public class BokehUI : ShaderGUI
    {

        // template variables
        private const string _version = "1.0";
        LukaSocials socials = new LukaSocials();
        private int selected_language = 0;

        // local variables
        private bool _foldout_guide = false;
        private bool _foldout_focal = false;
        private bool _foldout_camera = false;
        private bool _foldout_factor = false;
        private bool _foldout_animation = false;
        private bool _foldout_edges = false;
        private bool _foldout_lighting = false;
        private bool _foldout_technical = false;
        private string[] _dict_foldout_guide = new string[3] { "Guide Map", "Leitfaden Karte", "ガイドマップ" };
        private string[] _dict_foldout_focal = new string[3] { "Focal Settings", "Focal Einstellungen", "焦点設定" };
        private string[] _dict_foldout_camera = new string[3] { "Camera Controls", "Kamera Steuerungen", "カメラコントロール" };
        private string[] _dict_foldout_factor = new string[3] { "Additional Factors", "Zusätzliche Faktoren", "その他の要因" };
        private string[] _dict_foldout_animation = new string[3] { "Animation Settings", "Animation Einstellungen", "アニメーション設定" };
        private string[] _dict_foldout_edges = new string[3] { "Clean Edges", "Saubere Kanten", "クリーン・エッジ" };
        private string[] _dict_foldout_lighting = new string[3] { "Lighting Settings", "Beleuchtungs Einstellungen", "照明設定" };
        private string[] _dict_foldout_technical = new string[3] { "Technical Settings", "Technische Einstellungen", "技術設定" };
        private string[] _dict_toast_realtime = new string[3] { "<b>Important!</b> Bokeh Studio is suited more for renders, photographs, and previews rather than a real-time replacement. Although it can work as one, there will likely be a strong performance hit. If you want real-time bokeh and blur solutions I suggest checking out my June shader! Because of this, I suggest keeping Bokeh Studio limited to either Unity and VRChat photographs. Please see the documentation for more information! \u2665", 
        "<b>Wichtig!</b> Bokeh Studio eignet sich eher für Renderings, Fotos und Vorschauen als für einen Echtzeit-Ersatz. Obwohl es als solcher funktionieren kann, wird es wahrscheinlich einen starken Leistungseinbruch geben. Wenn Sie Bokeh- und Unschärfe-Lösungen in Echtzeit benötigen, empfehle ich Ihnen meinen June Shader! Aus diesem Grund empfehle ich, Bokeh Studio auf Unity- und VRChat-Fotos zu beschränken. Bitte lesen Sie die Dokumentation für weitere Informationen! \u2665", 
        "<b>重要</b> Bokeh Studioは、リアルタイムの代替というよりは、レンダリング、写真、プレビューに向いています。リアルタイムとして動作させることは可能ですが、パフォーマンスが大幅に低下する可能性があります。リアルタイムのボケやぼかしのソリューションが必要な場合は、私のJune shaderをチェックすることをお勧めします！ このため、Bokeh StudioをUnityとVRChatのどちらかの写真に限定することをお勧めします。詳しくはドキュメントをご覧ください！ \u2665" };
        private string[] _dict_toast_depth = new string[3] { "If you are using Bokeh Studio in VRChat, please ensure that you have a depth-light (or real-time lighting in the world) provided at use. A prefab of this can be found in the Resources folder and a more in-depth explanation can be found in the documentation!", 
        "Wenn Sie Bokeh Studio in VRChat verwenden, stellen Sie bitte sicher, dass Sie bei der Verwendung ein Tiefenlicht (oder Echtzeit-Beleuchtung in der Welt) zur Verfügung haben. Eine Vorabversion davon finden Sie im Ressourcen-Ordner und eine ausführlichere Erklärung finden Sie in der Dokumentation!", 
        "VRChatでBokeh Studioを使用する場合は、使用時にデプスライト（またはワールド内のリアルタイム照明）が提供されていることを確認してください。このプレハブは Resources フォルダにあり、より詳しい説明はドキュメントにあります！" };

        // gui
        public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            // get the material
            Material targetMat = materialEditor.target as Material;
            // get the shader name
            string shader_name = targetMat.shader.name;
            // create the GUI Style for the header 
            GUIStyle headerStyle = new GUIStyle();
            headerStyle.fontSize = 20;
            headerStyle.richText = true;
            headerStyle.alignment = TextAnchor.MiddleCenter;
            // draw the header
            EditorGUILayout.Space(10);
            string hex_pastel_blue = "#7ca9f2";
            EditorGUILayout.LabelField("<color=" + hex_pastel_blue + ">Bokeh<b>" + "Studio" + "</b></color>", headerStyle, GUILayout.ExpandWidth(true));
            // create the GUI Style for the subheader
            GUIStyle subHeaderStyle = new GUIStyle();
            subHeaderStyle.fontSize = 12;
            subHeaderStyle.richText = true;
            subHeaderStyle.alignment = TextAnchor.MiddleCenter;
            // draw the subheader
            EditorGUILayout.LabelField("<color=" + hex_pastel_blue + ">\u2605 Version<b>" + _version + "</b> \u2665</color>", subHeaderStyle, GUILayout.ExpandWidth(true));
            // creating data for the toasts
            GUIStyle toastStyle = new GUIStyle();
            toastStyle.wordWrap = true;
            toastStyle.richText = true;
            String toast_color = (EditorGUIUtility.isProSkin) ? "#b5b4b3" : "#3d3d3c";
            // draw the first toast
            EditorGUILayout.Space(5);
            EditorGUILayout.BeginVertical("GroupBox");
            EditorGUILayout.LabelField("<color=" + toast_color + ">" + _dict_toast_realtime[selected_language] + "</color>", toastStyle, GUILayout.ExpandWidth(true));
            EditorGUILayout.EndVertical();
            // render the custom gui
            EditorGUILayout.Space(5);
            EditorGUILayout.BeginVertical("Box");
            string[] _dict_hq = new string[3] { "High Quality Mode", "Hochwertiger Modus", "高品質モード" };
            MaterialProperty _prop_hd = ShaderGUI.FindProperty("_HD", properties);
            EditorGUI.BeginChangeCheck();
            materialEditor.ShaderProperty(_prop_hd, _dict_hq[selected_language]);
            if (EditorGUI.EndChangeCheck())
            {
                LukaKeywords hd = new LukaKeywords(targetMat, "_BOKEH_HD");
                hd.toggle(_prop_hd.floatValue);
            }
            _foldout_guide = draw_foldout_main(_foldout_guide, _dict_foldout_guide[selected_language], 18);
            if (_foldout_guide) {
                EditorGUILayout.Space(5);
                // define languages
                string[] _dict_guide_map = new string[3] { "Guide Map", "Leitfaden Karte", "ガイドマップ" };
                string[] _dict_guide_randomize_style = new string[3] { "Randomize Guide", "Karte zufällig auswählen", "ランダム化ガイド" };
                string[] _dict_guide_randomize_speed = new string[3] { "Randomize Speed", "Geschwindigkeit zufällig wählen", "スピードのランダム化" };
                string[] _dict_guide_randomize_variation = new string[3] { "Randomize Variation", "Randomisierte Variation", "変異のランダム化" };
                string[] _dict_guide_randomize_x = new string[3] { "Random X Rows", "Zufällige X-Reihen", "ランダムX行" };
                string[] _dict_guide_randomize_y = new string[3] { "Random Y Rows", "Zufällige Y-Reihen", "ランダムY行" };
                string[] _dict_guide_randomize = new string[3] { "Randomize Bokeh Shapes", "Zufällige Bokeh-Formen", "ランダムなボケ形状" };
                // gather the properties
                MaterialProperty _prop_guide_map = ShaderGUI.FindProperty("_Guide", properties);
                MaterialProperty _prop_guide_randomize_style = ShaderGUI.FindProperty("_GuideRandomizeStyle", properties);
                MaterialProperty _prop_guide_randomize_speed = ShaderGUI.FindProperty("_GuideRandomizeSpeed", properties);
                MaterialProperty _prop_guide_randomize_variation = ShaderGUI.FindProperty("_GuideRandomizeVariation", properties);
                MaterialProperty _prop_guide_randomize_x = ShaderGUI.FindProperty("_GuideRandomizeX", properties);
                MaterialProperty _prop_guide_randomize_y = ShaderGUI.FindProperty("_GuideRandomizeY", properties);
                MaterialProperty _prop_guide_randomize = ShaderGUI.FindProperty("_Randomize", properties);
                // draw the properties
                materialEditor.ShaderProperty(_prop_guide_map, _dict_guide_map[selected_language]);
                EditorGUI.BeginChangeCheck();
                materialEditor.ShaderProperty(_prop_guide_randomize, _dict_guide_randomize[selected_language]);
                if (EditorGUI.EndChangeCheck())
                {
                    LukaKeywords randomize = new LukaKeywords(targetMat, "_BOKEH_RANDOMIZED");
                    randomize.toggle(_prop_guide_randomize.floatValue);
                }
                if (_prop_guide_randomize.floatValue == 1.0f) {
                    EditorGUI.indentLevel++;
                    materialEditor.ShaderProperty(_prop_guide_randomize_style, _dict_guide_randomize_style[selected_language]);
                    materialEditor.ShaderProperty(_prop_guide_randomize_speed, _dict_guide_randomize_speed[selected_language]);
                    materialEditor.ShaderProperty(_prop_guide_randomize_variation, _dict_guide_randomize_variation[selected_language]);
                    materialEditor.ShaderProperty(_prop_guide_randomize_x, _dict_guide_randomize_x[selected_language]);
                    materialEditor.ShaderProperty(_prop_guide_randomize_y, _dict_guide_randomize_y[selected_language]);
                    EditorGUI.indentLevel--;
                }
                EditorGUILayout.Space(5);
            }
            _foldout_focal = draw_foldout_main(_foldout_focal, _dict_foldout_focal[selected_language], 18);
            if (_foldout_focal) {
                EditorGUILayout.Space(5);
                // define languages
                string[] _dict_focal_mode = new string[3] { "Focal Mode", "Fokusmodus", "焦点モード" };
                string[] _dict_focal_manual = new string[3] { "Manual Focus", "Manueller Fokus", "マニュアルフォーカス" };
                string[] _dict_focal_x = new string[3] { "Camera X Position", "Kamera X Position", "カメラX位置" };
                string[] _dict_focal_y = new string[3] { "Camera Y Position", "Kamera Y Position", "カメラY位置" };
                // gather the properties
                MaterialProperty _prop_focal_mode = ShaderGUI.FindProperty("_FocalMode", properties);
                MaterialProperty _prop_focal_manual = ShaderGUI.FindProperty("_ManualFocus", properties);
                MaterialProperty _prop_focal_x = ShaderGUI.FindProperty("_FocalX", properties);
                MaterialProperty _prop_focal_y = ShaderGUI.FindProperty("_FocalY", properties);
                // draw the properties
                materialEditor.ShaderProperty(_prop_focal_mode, _dict_focal_mode[selected_language]);
                switch (_prop_focal_mode.floatValue) {
                    case 0.0f: // manual
                        EditorGUI.indentLevel++;
                        materialEditor.ShaderProperty(_prop_focal_manual, _dict_focal_manual[selected_language]);
                        EditorGUI.indentLevel--;
                        break;
                    case 1.0f: // automatic
                        EditorGUI.indentLevel++;
                        materialEditor.ShaderProperty(_prop_focal_x, _dict_focal_x[selected_language]);
                        materialEditor.ShaderProperty(_prop_focal_y, _dict_focal_y[selected_language]);
                        EditorGUI.indentLevel--;
                        break;
                    default: // always
                        break;
                }
                EditorGUILayout.Space(5);
            }
            _foldout_camera = draw_foldout_main(_foldout_camera, _dict_foldout_camera[selected_language], 18);
            if (_foldout_camera) {
                EditorGUILayout.Space(5);
                // define languages
                string[] _dict_camera_power = new string[3] { "Shape Size", "Formgröße", "形状サイズ" };
                string[] _dict_camera_bokeh_power = new string[3] { "Bokeh Power", "Bokeh Leistung", "ボケパワー" };
                string[] _dict_camera_aperature = new string[3] { "Aperature", "Blende", "アパーチャ" };
                // gather the properties
                MaterialProperty _prop_camera_power = ShaderGUI.FindProperty("_Power", properties);
                MaterialProperty _prop_camera_bokeh_power = ShaderGUI.FindProperty("_BokehPower", properties);
                MaterialProperty _prop_camera_aperature = ShaderGUI.FindProperty("_Aperature", properties);
                // draw the properties
                materialEditor.ShaderProperty(_prop_camera_power, _dict_camera_power[selected_language]);
                materialEditor.ShaderProperty(_prop_camera_bokeh_power, _dict_camera_bokeh_power[selected_language]);
                materialEditor.ShaderProperty(_prop_camera_aperature, _dict_camera_aperature[selected_language]);
                EditorGUILayout.Space(5);
            }
            _foldout_factor = draw_foldout_main(_foldout_factor, _dict_foldout_factor[selected_language], 18);
            if (_foldout_factor) {
                EditorGUILayout.Space(5);
                // define languages
                string[] _dict_factor_depth = new string[3] { "Factor in Depth", "Faktor in Tiefe", "深度因子" };
                string[] _dict_factor_depth_cutoff = new string[3] { "Depth Close-Up End", "Tiefe Nahaufnahme Ende", "深度アップエンド" };
                string[] _dict_factor_depth_influence = new string[3] { "Depth Close-Up Influence", "Tiefe Nahaufnahme Einfluss", "深度アップインフルエンス" };
                string[] _dict_factor_luma = new string[3] { "Factor in Luma", "Faktor in Luma", "ルマ因子" };
                string[] _dict_factor_luma_influence = new string[3] { "Luma Influence", "Luma Einfluss", "ルマインフルエンス" };
                string[] _dict_factor_luma_minimum = new string[3] { "Luma Minimum", "Luma Minimum", "ルマ最小" };
                // gather the properties
                MaterialProperty _prop_factor_depth = ShaderGUI.FindProperty("_FactorDepth", properties);
                MaterialProperty _prop_factor_depth_cutoff = ShaderGUI.FindProperty("_FactorDepthCutoff", properties);
                MaterialProperty _prop_factor_depth_influence = ShaderGUI.FindProperty("_FactorDepthInfluence", properties);
                MaterialProperty _prop_factor_luma = ShaderGUI.FindProperty("_FactorLuma", properties);
                MaterialProperty _prop_factor_luma_influence = ShaderGUI.FindProperty("_FactorLumaInfluence", properties);
                MaterialProperty _prop_factor_luma_minimum = ShaderGUI.FindProperty("_FactorLumaMinimum", properties);
                // draw the properties
                materialEditor.ShaderProperty(_prop_factor_depth, _dict_factor_depth[selected_language]);
                if (_prop_factor_depth.floatValue == 1.0f) {
                    EditorGUI.indentLevel++;
                    materialEditor.ShaderProperty(_prop_factor_depth_cutoff, _dict_factor_depth_cutoff[selected_language]);
                    materialEditor.ShaderProperty(_prop_factor_depth_influence, _dict_factor_depth_influence[selected_language]);
                    EditorGUI.indentLevel--;
                }
                materialEditor.ShaderProperty(_prop_factor_luma, _dict_factor_luma[selected_language]);
                if (_prop_factor_luma.floatValue == 1.0f) {
                    EditorGUI.indentLevel++;
                    materialEditor.ShaderProperty(_prop_factor_luma_minimum, _dict_factor_luma_minimum[selected_language]);
                    materialEditor.ShaderProperty(_prop_factor_luma_influence, _dict_factor_luma_influence[selected_language]);
                    EditorGUI.indentLevel--;
                }
                EditorGUILayout.Space(5);
            }
            _foldout_animation = draw_foldout_main(_foldout_animation, _dict_foldout_animation[selected_language], 18);
            if (_foldout_animation) {
                EditorGUILayout.Space(5);
                // define languages
                string[] _dict_animation_variation = new string[3] { "Animation Variation", "Animationsvariation", "アニメーションバリエーション" };
                string[] _dict_animation_rotation = new string[3] { "Rotate Bokehs", "Bokehs drehen", "ボケを回転" };
                string[] _dict_animation_rotation_speed = new string[3] { "Rotation Speed", "Rotationsgeschwindigkeit", "回転速度" };
                string[] _dict_animation_scale = new string[3] { "Scale Bokehs", "Bokehs skalieren", "ボケをスケール" };
                string[] _dict_animation_scale_speed = new string[3] { "Scale Speed", "Skalierungsgeschwindigkeit", "スケール速度" };
                string[] _dict_animation_scale_power = new string[3] { "Scale Power", "Skalierungsgeschwindigkeit", "スケール速度" };
                string[] _dict_animation_scale_minimum = new string[3] { "Scale Minimum", "Skalierungsgeschwindigkeit", "スケール速度" };
                string[] _dict_animation_scale_maximum = new string[3] { "Scale Maximum", "Skalierungsgeschwindigkeit", "スケール速度" };
                string[] _dict_animation = new string[3] { "Animate Bokeh Shapes", "Bokeh-Formen animieren", "ボケ形状をアニメーション化" };
                // gather the properties
                MaterialProperty _prop_animation_variation = ShaderGUI.FindProperty("_AnimationVariation", properties);
                MaterialProperty _prop_animation_rotation = ShaderGUI.FindProperty("_AnimationRotation", properties);
                MaterialProperty _prop_animation_rotation_speed = ShaderGUI.FindProperty("_AnimationRotationSpeed", properties);
                MaterialProperty _prop_animation_scale = ShaderGUI.FindProperty("_AnimationScale", properties);
                MaterialProperty _prop_animation_scale_speed = ShaderGUI.FindProperty("_AnimationScaleSpeed", properties);
                MaterialProperty _prop_animation_scale_power = ShaderGUI.FindProperty("_AnimationScalePower", properties);
                MaterialProperty _prop_animation_scale_minimum = ShaderGUI.FindProperty("_AnimationScaleMinimum", properties);
                MaterialProperty _prop_animation_scale_maximum = ShaderGUI.FindProperty("_AnimationScaleMaximum", properties);
                MaterialProperty _prop_animation = ShaderGUI.FindProperty("_Animate", properties);
                // draw the properties
                EditorGUI.BeginChangeCheck();
                materialEditor.ShaderProperty(_prop_animation, _dict_animation[selected_language]);
                if (EditorGUI.EndChangeCheck())
                {
                    LukaKeywords animate = new LukaKeywords(targetMat, "_BOKEH_ANIMATION");
                    animate.toggle(_prop_animation.floatValue);
                }
                disable_start(_prop_animation, 1.0f);
                materialEditor.ShaderProperty(_prop_animation_variation, _dict_animation_variation[selected_language]);
                materialEditor.ShaderProperty(_prop_animation_rotation, _dict_animation_rotation[selected_language]);
                if (_prop_animation_rotation.floatValue != 0.0f && _prop_animation.floatValue == 1.0f) {
                    EditorGUI.indentLevel++;
                    materialEditor.ShaderProperty(_prop_animation_rotation_speed, _dict_animation_rotation_speed[selected_language]);
                    EditorGUI.indentLevel--;
                }
                materialEditor.ShaderProperty(_prop_animation_scale, _dict_animation_scale[selected_language]);
                if (_prop_animation_scale.floatValue != 0.0f && _prop_animation.floatValue == 1.0f) {
                    EditorGUI.indentLevel++;
                    materialEditor.ShaderProperty(_prop_animation_scale_speed, _dict_animation_scale_speed[selected_language]);
                    materialEditor.ShaderProperty(_prop_animation_scale_power, _dict_animation_scale_power[selected_language]);
                    materialEditor.ShaderProperty(_prop_animation_scale_minimum, _dict_animation_scale_minimum[selected_language]);
                    materialEditor.ShaderProperty(_prop_animation_scale_maximum, _dict_animation_scale_maximum[selected_language]);
                    EditorGUI.indentLevel--;
                }
                disable_end();
                EditorGUILayout.Space(5);
            }
            _foldout_edges = draw_foldout_main(_foldout_edges, _dict_foldout_edges[selected_language], 18);
            if (_foldout_edges) {
                EditorGUILayout.Space(5);
                // define languages
                string[] _dict_edges_clean = new string[3] { "Clean Edges", "Saubere Kanten", "クリーン・エッジ" };
                string[] _dict_edges_blending_radius = new string[3] { "Blending Radius", "Mischradius", "ブレンディング半径" };
                string[] _dict_edges_coc_spread = new string[3] { "CoC Spread", "CoC Spread", "CoC Spread" };
                // gather the properties
                MaterialProperty _prop_edges_clean = ShaderGUI.FindProperty("_Clean", properties);
                MaterialProperty _prop_edges_blending_radius = ShaderGUI.FindProperty("_BlendingRadius", properties);
                MaterialProperty _prop_edges_coc_spread = ShaderGUI.FindProperty("_CocSpread", properties);
                // draw the properties
                EditorGUI.BeginChangeCheck();
                materialEditor.ShaderProperty(_prop_edges_clean, _dict_edges_clean[selected_language]);
                if (EditorGUI.EndChangeCheck())
                {
                    LukaKeywords clean = new LukaKeywords(targetMat, "_BOKEH_CLEAN");
                    clean.toggle(_prop_edges_clean.floatValue);
                }
                disable_start(_prop_edges_clean, 1.0f);
                materialEditor.ShaderProperty(_prop_edges_blending_radius, _dict_edges_blending_radius[selected_language]);
                materialEditor.ShaderProperty(_prop_edges_coc_spread, _dict_edges_coc_spread[selected_language]);
                disable_end();
                EditorGUILayout.Space(5);
            }
            _foldout_lighting = draw_foldout_main(_foldout_lighting, _dict_foldout_lighting[selected_language], 18);
            if (_foldout_lighting) {
                EditorGUILayout.Space(5);
                // define languages
                string[] _dict_lighting_accentuate = new string[3] { "Accentuate Bokehs", "Bokehs hervorheben", "ボケを強調" };
                string[] _dict_lighting_expose = new string[3] { "Expose Bokehs", "Bokehs belichten", "ボケを露出" };
                string[] _dict_lighting_tonemap = new string[3] { "Tonemap Bokehs", "Tonemap Bokehs", "Tonemap Bokehs" };
                string[] _dict_lighting_color_mode = new string[3] { "Color Mode", "Farbmodus", "カラーモード" };
                string[] _dict_lighting_color = new string[3] { "Color", "Farbe", "色" };
                string[] _dict_lighting_hsv_mode = new string[3] { "HSV Mode", "HSV Modus", "HSVモード" };
                string[] _dict_lighting_hue = new string[3] { "Hue", "Farbton", "色相" };
                string[] _dict_lighting_saturation = new string[3] { "Saturation", "Sättigung", "彩度" };
                string[] _dict_lighting_value = new string[3] { "Brightness", "Helligkeit", "明るさ" };
                string[] _dict_lighting_hsv_tap_based = new string[3] { "Tap Based", "Tap Based", "Tap Based" };
                // gather the properties
                MaterialProperty _prop_lighting_accentuate = ShaderGUI.FindProperty("_Accentuate", properties);
                MaterialProperty _prop_lighting_expose = ShaderGUI.FindProperty("_Exposure", properties);
                MaterialProperty _prop_lighting_tonemap = ShaderGUI.FindProperty("_ColorGrading", properties);
                MaterialProperty _prop_lighting_color_mode = ShaderGUI.FindProperty("_ColorMode", properties);
                MaterialProperty _prop_lighting_color = ShaderGUI.FindProperty("_Color", properties);
                MaterialProperty _prop_lighting_hsv_mode = ShaderGUI.FindProperty("_HSVMode", properties);
                MaterialProperty _prop_lighting_hue = ShaderGUI.FindProperty("_Hue", properties);
                MaterialProperty _prop_lighting_saturation = ShaderGUI.FindProperty("_Saturation", properties);
                MaterialProperty _prop_lighting_value = ShaderGUI.FindProperty("_Value", properties);
                MaterialProperty _prop_lighting_hsv_tap_based = ShaderGUI.FindProperty("_HSVTapBased", properties);
                // draw the properties
                materialEditor.ShaderProperty(_prop_lighting_accentuate, _dict_lighting_accentuate[selected_language]);
                materialEditor.ShaderProperty(_prop_lighting_expose, _dict_lighting_expose[selected_language]);
                materialEditor.ShaderProperty(_prop_lighting_tonemap, _dict_lighting_tonemap[selected_language]);
                materialEditor.ShaderProperty(_prop_lighting_color_mode, _dict_lighting_color_mode[selected_language]);
                disable_start(_prop_lighting_color_mode, 0.0f, true);
                materialEditor.ShaderProperty(_prop_lighting_color, _dict_lighting_color[selected_language]);
                disable_end();
                materialEditor.ShaderProperty(_prop_lighting_hsv_mode, _dict_lighting_hsv_mode[selected_language]);
                disable_start(_prop_lighting_hsv_mode, 0.0f, true);
                materialEditor.ShaderProperty(_prop_lighting_hsv_tap_based, _dict_lighting_hsv_tap_based[selected_language]);
                materialEditor.ShaderProperty(_prop_lighting_hue, _dict_lighting_hue[selected_language]);
                materialEditor.ShaderProperty(_prop_lighting_saturation, _dict_lighting_saturation[selected_language]);
                materialEditor.ShaderProperty(_prop_lighting_value, _dict_lighting_value[selected_language]);
                disable_end();
                EditorGUILayout.Space(5);
            }
            _foldout_technical = draw_foldout_main(_foldout_technical, _dict_foldout_technical[selected_language], 18);
            if (_foldout_technical) {
                EditorGUILayout.Space(5);
                // define languages
                string[] _dict_technical_cull_distance = new string[3] { "Cull Distance", "Cull Entfernung", "カル・ディスタンス" };
                string[] _dict_technical_dithering = new string[3] { "Dithering", "Dithering", "ディザリング" };
                string[] _dict_technical_max_diameter = new string[3] { "Max Diameter", "Maximaler Durchmesser", "最大直径" };
                string[] _dict_technical_far_plane = new string[3] { "Far Plane", "Ferne Ebene", "遠い飛行機" };
                string[] _dict_technical_vrchat_preview = new string[3] { "VRC Camera Preview", "VRC Kamera Vorschau", "VRCカメラプレビュー" };
                string[] _dict_technical_vrchat = new string[3] { "VRC Camera Only", "VRC Kamera Nur", "VRCカメラのみ" };
                // gather the properties
                MaterialProperty _prop_technical_cull_distance = ShaderGUI.FindProperty("_CullDistance", properties);
                MaterialProperty _prop_technical_dithering = ShaderGUI.FindProperty("_Dithering", properties);
                MaterialProperty _prop_technical_max_diameter = ShaderGUI.FindProperty("_MaxDiameter", properties);
                MaterialProperty _prop_technical_far_plane = ShaderGUI.FindProperty("_FarPlane", properties);
                MaterialProperty _prop_technical_vrchat_preview = ShaderGUI.FindProperty("_VRChatPreview", properties);
                MaterialProperty _prop_technical_vrchat = ShaderGUI.FindProperty("_VRChat", properties);
                // draw the properties
                materialEditor.ShaderProperty(_prop_technical_cull_distance, _dict_technical_cull_distance[selected_language]);
                materialEditor.ShaderProperty(_prop_technical_dithering, _dict_technical_dithering[selected_language]);
                materialEditor.ShaderProperty(_prop_technical_max_diameter, _dict_technical_max_diameter[selected_language]);
                materialEditor.ShaderProperty(_prop_technical_far_plane, _dict_technical_far_plane[selected_language]);
                EditorGUI.BeginChangeCheck();
                materialEditor.ShaderProperty(_prop_technical_vrchat, _dict_technical_vrchat[selected_language]);
                if (EditorGUI.EndChangeCheck())
                {
                    LukaKeywords vrchat = new LukaKeywords(targetMat, "_BOKEH_VRCHAT");
                    vrchat.toggle(_prop_technical_vrchat.floatValue);
                }
                disable_start(_prop_technical_vrchat, 1.0f);
                materialEditor.ShaderProperty(_prop_technical_vrchat_preview, _dict_technical_vrchat_preview[selected_language]);
                disable_end();
                EditorGUILayout.Space(5);
            }
            string[] _dict_language = new string[3] { "Language", "Sprache", "言語" };
            MaterialProperty _prop_language = ShaderGUI.FindProperty("_Language", properties);
            EditorGUI.BeginChangeCheck();
            materialEditor.ShaderProperty(_prop_language, _dict_language[selected_language]);
            if (EditorGUI.EndChangeCheck())
            {
                selected_language = (int)_prop_language.floatValue;
            }
            EditorGUILayout.EndVertical();
            // draw the second toast
            EditorGUILayout.Space(5);
            EditorGUILayout.BeginVertical("GroupBox");
            EditorGUILayout.LabelField("<color=" + toast_color + ">" + _dict_toast_depth[selected_language] + "</color>", toastStyle, GUILayout.ExpandWidth(true));
            EditorGUILayout.EndVertical();
            // draw socials button
            draw_socials();
        }

        // methods
        private void open_url(string url) {
            Application.OpenURL(url);
        }

        private void popup_dialogue(string title, string message) {
            EditorUtility.DisplayDialog(title, message, "oki");
        }

        private void disable_start(MaterialProperty property, float condition, bool reverse = false) {
            if (reverse) {
                if (property.floatValue == condition) {
                    EditorGUI.BeginDisabledGroup(true);
                } else {
                    EditorGUI.BeginDisabledGroup(false);
                }
            } else {
                if (property.floatValue == condition) {
                    EditorGUI.BeginDisabledGroup(false);
                } else {
                    EditorGUI.BeginDisabledGroup(true);
                }
            }
        }

        private void disable_end() {
            EditorGUI.EndDisabledGroup();
        }

        private void draw_socials() {
            EditorGUILayout.Space(5);
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Check out my Booth!")) {
                socials.demand_fetch();
                open_url(socials.getBooth());
            }
            if (GUILayout.Button("Check out my Gumroad!")) {
                socials.demand_fetch();
                open_url(socials.getGumroad());
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Star my projects on Github!")) {
                socials.demand_fetch();
                open_url(socials.getGithub());
            }
            if (GUILayout.Button("Friend me on Discord!")) {
                socials.demand_fetch();
                popup_dialogue("My Discord Username", socials.getDiscord());
            }
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("Visit my Website!")) {
                socials.demand_fetch();
                open_url(socials.getWebsite());
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space(10);
        }
        
        public static bool draw_foldout_main(bool boolState, string inputLabel, int fontSize)
        {
            var style = new GUIStyle("ShurikenModuleTitle");
            style.font = new GUIStyle(EditorStyles.label).font;
            style.border = new RectOffset(15, 7, 4, 4);
            style.fontSize = fontSize;
            style.fixedHeight = fontSize + 10;
            style.contentOffset = new Vector2(20f, -2f);
            var rect = GUILayoutUtility.GetRect(16f, (float)fontSize + 10f, style);
            GUI.Box(rect, inputLabel, style);
            var e = Event.current;
            var toggleRect = new Rect(rect.x + 4f, rect.y + (fontSize / 3), 13f, 13f);
            if (e.type == EventType.Repaint)
            {
                EditorStyles.foldout.Draw(toggleRect, false, false, boolState, false);
            }
            if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition))
            {
                boolState = !boolState;
                e.Use();
            }
            return boolState;
        }

        public static bool draw_foldout_sub(bool boolState, string inputLabel)
        {
            // makes a sub-level foldout
            var style = new GUIStyle("ShurikenModuleTitle");
            style.font = new GUIStyle(EditorStyles.label).font;
            style.border = new RectOffset(15, 7, 4, 4);
            style.fontSize = 14;
            style.fixedHeight = 22;
            style.contentOffset = new Vector2(20f, -2f);
            var rect = GUILayoutUtility.GetRect(16f, 22f, style);
            GUI.Box(rect, inputLabel, style);
            var e = Event.current;
            var toggleRect = new Rect(rect.x + 4f, rect.y + 2f, 13f, 13f);
            if (e.type == EventType.Repaint)
            {
                EditorStyles.foldout.Draw(toggleRect, false, false, boolState, false);
            }
            if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition))
            {
                boolState = !boolState;
                e.Use();
            }
            return boolState;
        }

        // objects
        class LukaKeywords {

            // variables
            private Material target_mat;
            private string keyword;
            private bool branching;
            private string[] branching_values;
            private int branching_index;

            // constructor
            public LukaKeywords(Material target_mat, string keyword) {
                this.target_mat = target_mat;
                this.keyword = keyword;
            }

            public LukaKeywords(Material target_mat, bool branching, string[] branching_values, int branching_index) {
                this.target_mat = target_mat;
                this.branching = branching;
                this.branching_values = branching_values;
                this.branching_index = branching_index;
                this.keyword = this.branching_values[this.branching_index];
            }

            // methods
            public void enable() {
                this.target_mat.EnableKeyword(this.keyword);
            }

            public void disable() {
                this.target_mat.DisableKeyword(this.keyword);
            }

            public void toggle() {
                if (this.target_mat.IsKeywordEnabled(this.keyword)) {
                    this.target_mat.DisableKeyword(this.keyword);
                } else {
                    this.target_mat.EnableKeyword(this.keyword);
                }
            }

            public void toggle(float value) {
                if (value == 1.0f) {
                    this.target_mat.EnableKeyword(this.keyword);
                } else {
                    this.target_mat.DisableKeyword(this.keyword);
                }
            }

            public void update() {
                // for branching only
                for (int i = 0; i < this.branching_values.Length; i++) {
                    if (i == this.branching_index) {
                        this.target_mat.EnableKeyword(this.branching_values[i]);
                    } else {
                        this.target_mat.DisableKeyword(this.branching_values[i]);
                    }
                }
            }

        }

        class LukaSocials {

            // variables
            private bool state;
            private string github;
            private string booth;
            private string gumroad;
            private string website;
            private string discord;
            
            // constructor
            public LukaSocials() {
                this.state = false;
            }

            // methods
            public void demand_fetch() {
                if (this.state == false) {
                    using (HttpClient client = new HttpClient())
                    {
                        try
                        {
                            string jsonUrl = "https://www.luka.moe/go/contact.json";
                            HttpResponseMessage response = client.GetAsync(jsonUrl).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                string json = response.Content.ReadAsStringAsync().Result;
                                string[] lines = json.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (string line in lines)
                                {
                                    string[] key_value = parse_kv(line);
                                    bool is_special_case = (key_value[0] == "parse_kv_debug");
                                    if (!is_special_case)
                                    {
                                        string key = key_value[0];
                                        string value = key_value[1];
                                        switch (key)
                                        {
                                            case "github":
                                                this.github = value;
                                                break;
                                            case "booth":
                                                this.booth = value;
                                                break;
                                            case "gumroad":
                                                this.gumroad = value;
                                                break;
                                            case "website":
                                                this.website = value;
                                                break;
                                            case "discord":
                                                this.discord = value;
                                                break;
                                        }
                                    }
                                }
                                this.state = true;
                            }
                            else
                            {
                                error_defaults();
                            }
                        }
                        catch (Exception e)
                        {
                            error_defaults();
                        }
                    }
                }
            }

            private string[] parse_kv(string input)
            {
                // ensure it is not an end or start line, and if so, return a special case
                string parse_kv_console = "parse_kv_debug";
                if (input == "}" || input == "{")
                {
                    string error_message = "special_case";
                    return new string[] { parse_kv_console, error_message };
                }

                // match quotations with regex
                string pattern = "\"(.*?)\":\\s*\"(.*?)\"";
                Match match = Regex.Match(input, pattern);

                // see if it worked
                if (!match.Success)
                {
                    string error_message = "There was an error getting the contact information! I'm sorry..";
                    return new string[] { parse_kv_console, error_message };
                }

                // extract the key and value from the matched groups
                string key = match.Groups[1].Value.Trim().ToLower();
                string value = match.Groups[2].Value.Trim().ToLower();
                return new string[] { key, value };
            }

            private void error_defaults() {
                // errored..
                this.github = "There was an error getting the contact information! I'm sorry..";
                this.booth = "There was an error getting the contact information! I'm sorry..";
                this.gumroad = "There was an error getting the contact information! I'm sorry..";
                this.website = "There was an error getting the contact information! I'm sorry..";
                this.discord = "There was an error getting the contact information! I'm sorry..";
            }

            // setters
            public void setState(bool state) {
                this.state = state;
            }

            // getters
            public bool getState() {
                return this.state;
            }

            public string getGithub() {
                return this.github;
            }

            public string getBooth() {
                return this.booth;
            }

            public string getGumroad() {
                return this.gumroad;
            }

            public string getWebsite() {
                return this.website;
            }

            public string getDiscord() {
                return this.discord;
            }

        }

    }

}

#endif // UNITY_EDITOR