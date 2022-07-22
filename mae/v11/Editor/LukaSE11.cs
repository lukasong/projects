//|===============================================|
//|				  license   					  |
//|===============================================|
//shader author: luka (lukasong on github, luka#8375 on discord, luka! in vrchat)
//license: this shader is to not be redistrubted or resold in any format and is limited to the buyer exclusively
//version 11.0 (July 30,  2019)

#if UNITY_EDITOR
using UnityEngine;
using System;
using System.Net;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Collections.Generic;
#endif

public class LukaSE11 : ShaderGUI
{

    //=== variables ====
    #region variables
    //Variables 
    static String versionNumber = "11.0";
    static String shaderVersionNumber = "release ";
    static String shaderUpdate = "July 30, 2019";
    static String versionDedicate = "buyer";
    static String myDiscord = "luka#8375";
    static String shaderDirectory = "!luka/mae";
    static String freezeDirectory = "Hidden/" + shaderDirectory + "/freeze";
    static String limitDirectory = "Hidden/" + shaderDirectory + "/limitbreak";
    static String filesDirectory = "Assets/luka 11";
    static String myFullUsername = "LukaSong";
    static String shaderName = "mae";
    static String okButton = "got it";
    static String authKey;
    static String authUser;
    static String propertyQuery;
    static String gameobjQuery;
    static int propertyPlace;
    static GameObject thisMesh;
    static ArrayList searchedCache = new ArrayList();
    static ArrayList matchingCache = new ArrayList();
    static List<string> resultedCache = new List<string>();
    //Properties    
    //other menu variables
    Boolean authHowClick;
    Boolean authWhyClick;
    Boolean authDataClick;
    Boolean authClick = false;
    static Boolean needToUpdate = false;
    int authOption = 0;
    static Boolean superUser = false;
    static Boolean vaporUser = false;
    Boolean neverShowChangelog;
    static char uniHeart = '\u2665';
    static String redHeart = "  <color=red>" + uniHeart.ToString() + "</color>  ";
    //global settings
    static Boolean showChange;
    static String activeDisplay = "";
    static Boolean menuUgly;
    static Boolean particleDefault;
    static String safetyVersion = "";
    static Boolean displayEula;
    static Boolean displayAuth;
    static Boolean displayChangelog;
    //presets
    static int selectedPreset = 0;
    static string[] presetOption = new string[]
    {
                "Molly", "RGB Blur", "Visualizer", "Cinema", "Old Timey", "Matrix", "UFO",
    };
    //render 
    MaterialProperty _Range;
    MaterialProperty _ToggleRenderLookAtMe;
    MaterialProperty _RenderMeTolerance;
    MaterialProperty _ZTest;
    MaterialProperty _AllowSmartFalloff;
    MaterialProperty _SmartFalloffMin;
    MaterialProperty _SmartFalloffMax;
    MaterialProperty _OverallOpacity;
    MaterialProperty _ParticleSystem;
    public String ztestDescription;
    //depth
    MaterialProperty _AllowDepthTest;
    MaterialProperty _DepthValue;
    MaterialProperty _KeepPlayerInFocus;
    MaterialProperty _DepthPlayerTolerance;
    MaterialProperty _DepthPlayerPower;
    MaterialProperty _ReverseDepth;
    //tear fix
    MaterialProperty _AllowTearFix;
    MaterialProperty _ScreenTearColor;
    MaterialProperty _TearToMirror;
    MaterialProperty _TearToRepeat;
    //screenspace 
    //MaterialProperty _ToggleSepia;
    //MaterialProperty _ToggleInvert;
    MaterialProperty _SepiaStrength;
    MaterialProperty _SepiaColor;
    MaterialProperty _InvertMode;
    MaterialProperty _InvertStrength;
    MaterialProperty _InvertR;
    MaterialProperty _InvertG;
    MaterialProperty _InvertB;
    MaterialProperty _ToggleScreenFlip;
    MaterialProperty _ToggleUpsideDown;
    //ascii
    MaterialProperty _ToggleAscii;
    MaterialProperty _ASCIIVariation;
    MaterialProperty _ASCIIPower;
    MaterialProperty _ASCIISpeed;
    MaterialProperty _ASCIIShapeOne;
    MaterialProperty _ASCIIShapeTwo;
    MaterialProperty _ASCIIShapeThree;
    MaterialProperty _ASCIIShapeFour;
    MaterialProperty _ASCIIShapeFive;
    MaterialProperty _ASCIIShapeSix;
    MaterialProperty _ASCIIShapeSeven;
    MaterialProperty _ASCIIShapeEight;
    //big box zoom
    MaterialProperty _ToggleBigZoom;
    MaterialProperty _BigZoomAmount;
    MaterialProperty _BigZoomTolerance;
    MaterialProperty _BigZoomOutAmount;
    //blink
    MaterialProperty _BlinkMode;
    MaterialProperty _BlinkForce;
    MaterialProperty _BlinkStrength;
    MaterialProperty _BlinkColor;
    MaterialProperty _BlinkImage;
    MaterialProperty _BlinkImagePower;
    MaterialProperty _BlinkImageX;
    MaterialProperty _BlinkImageY;
    MaterialProperty _BlinkBorderSize;
    MaterialProperty _BlinkBorder;
    MaterialProperty _BlinkRainbow;
    MaterialProperty _BlinkRainbowX;
    MaterialProperty _BlinkRainbowY;
    MaterialProperty _BlinkRainbowHue;
    MaterialProperty _BlinkRainbowSat;
    MaterialProperty _BlinkRainbowLight;
    MaterialProperty _BlinkRainbowTime;
    MaterialProperty _BlinkRainbowMode;
    //new blur
    MaterialProperty _ToggleNBlur;
    MaterialProperty _NBlurShape;
    MaterialProperty _NBlurItterations;
    MaterialProperty _NBlurPower;
    MaterialProperty _NBlurSpeed;
    MaterialProperty _NBlurRotate;
    MaterialProperty _NBlurRotateSpeed;
    MaterialProperty _NBlurX;
    MaterialProperty _NBlurY;
    MaterialProperty _NBlurColor;
    MaterialProperty _NBlurGlow;
    MaterialProperty _NBlurOpacity;
    //blur 
    MaterialProperty _ToggleBlur;
    MaterialProperty _ToggleSimpleBlur;
    MaterialProperty _BlurNondistanceOffset;
    MaterialProperty _BlurOffset;
    MaterialProperty _ToggleAutoanimateBlur;
    MaterialProperty _BlurAutoanimateSpeed;
    //bloom
    MaterialProperty _BloomGlow;
    MaterialProperty _BloomGlowRGB;
    //bloom
    MaterialProperty _RBloomToggle;
    MaterialProperty _RBloomQuality;
    MaterialProperty _RBloomStrength;
    MaterialProperty _RBloomBright;
    MaterialProperty _RBloomColor;
    MaterialProperty _RBloomOpacity;
    MaterialProperty _RBloomDepth;
    //bulge
    MaterialProperty _ToggleBulge;
    MaterialProperty _BulgeIndent;
    MaterialProperty _OwoStrength;
    //centered zoom
    MaterialProperty _ToggleZoom;
    MaterialProperty _ToggleFlipZoom;
    MaterialProperty _ZoomInValue;
    MaterialProperty _ZoomOutValue;
    MaterialProperty _SmoothZoom;
    MaterialProperty _SmoothZoomTolerance;
    //MaterialProperty _SmoothZoomClampMinTWO;
    //MaterialProperty _SmoothZoomClampMaxTWO;
    MaterialProperty _SmoothZoomDistanceMod;
    Boolean showAdvancedSmoothZoom;
    //colors 
    //MaterialProperty _ToggleColorTint;
    MaterialProperty _ColorHue;
    MaterialProperty _ColorSaturation;
    MaterialProperty _ColorValue;
    //MaterialProperty _ToggleRGBTint;
    MaterialProperty _ColorRGB;
    MaterialProperty _SolidTrans;
    MaterialProperty _SolidCol;
    //extra color options
    MaterialProperty _ColorRGBtoHSV;
    MaterialProperty _ColorHSVtoRGB;
    //color split
    MaterialProperty _ToggleColorSplit;
    MaterialProperty _ColorSplitAmount;
    MaterialProperty _ColorSplitRGBone;
    MaterialProperty _ColorSplitRGBtwo;
    MaterialProperty _ColorSplitRGBthree;
    MaterialProperty _ColSpONEopacity;
    MaterialProperty _ColSpTWOopacity;
    MaterialProperty _ColSpTHREEOpacity;
    MaterialProperty _ToggleColorSplitStaySides;
    MaterialProperty _ToggleAutoanimateColorSplit;
    MaterialProperty _ColorSplitSpeed;
    MaterialProperty _CSLX;
    MaterialProperty _CSLY;
    MaterialProperty _CSMX;
    MaterialProperty _CSMY;
    MaterialProperty _CSRX;
    MaterialProperty _CSRY;
    MaterialProperty _CSL;
    MaterialProperty _CSRotate;
    MaterialProperty _ColSplRotateSpeed;
    MaterialProperty _CSOffsetX;
    MaterialProperty _CSOffsetY;
    MaterialProperty _CSTrans;
    Boolean showColorSplitAnimate;
    //corner spin
    MaterialProperty _ToggleCC;
    MaterialProperty _CCApply;
    MaterialProperty _CCOne;
    MaterialProperty _CCTwo;
    MaterialProperty _CCThree;
    MaterialProperty _CCFour;
    MaterialProperty _CCRotate;
    MaterialProperty _CCSpeed;
    //corner colors
    MaterialProperty _CornerOneColor;
    MaterialProperty _CornerTwoColor;
    MaterialProperty _CornerThreeColor;
    MaterialProperty _CornerFourColor;
    MaterialProperty _CornerOneTrans;
    MaterialProperty _CornerTwoTrans;
    MaterialProperty _CornerThreeTrans;
    MaterialProperty _CornerFourTrans;
    //color gradient
    MaterialProperty _GradTrans;
    MaterialProperty _GradMode;
    MaterialProperty _GradApply;
    MaterialProperty _GradOne;
    MaterialProperty _GradTwo;
    //darken
    //MaterialProperty _ToggleDarken;
    MaterialProperty _DarknessStrength;
    //new distortion
    MaterialProperty _ToggleDistortion;
    MaterialProperty _DistortionMap;
    MaterialProperty _DistortionX;
    MaterialProperty _DistortionY;
    MaterialProperty _DistortionXSpeed;
    MaterialProperty _DistortionYSpeed;
    MaterialProperty _DistortionRotate;
    MaterialProperty _DistortionRotateSpeed;
    MaterialProperty _DistortionTransparency;
    //dizzy
    MaterialProperty _ToggleDizzyEffect;
    MaterialProperty _DizzyMode;
    MaterialProperty _DizzyAmountValue;
    MaterialProperty _DizzyRotationSpeed;
    //droplet
    MaterialProperty _ToggleDroplet;
    MaterialProperty _ToggleDropletSepia;
    MaterialProperty _DropletColOne;
    MaterialProperty _DropletColTwo;
    MaterialProperty _DropletTolerance;
    MaterialProperty _DropletIntensity;
    MaterialProperty _ToggleDropletTwo;
    MaterialProperty _TwoDropletColOne;
    MaterialProperty _TwoDropletColTwo;
    MaterialProperty _TwoDropletTolerance;
    MaterialProperty _TwoDropletIntensity;
    MaterialProperty _ToggleDropletThree;
    MaterialProperty _ThreeDropletColOne;
    MaterialProperty _ThreeDropletColTwo;
    MaterialProperty _ThreeDropletTolerance;
    MaterialProperty _ThreeDropletIntensity;
    MaterialProperty _ToggleDropletFour;
    MaterialProperty _FourDropletColOne;
    MaterialProperty _FourDropletColTwo;
    MaterialProperty _FourDropletTolerance;
    MaterialProperty _FourDropletIntensity;
    Boolean dropletHSVorRGB;
    //duotone
    MaterialProperty _ToggleDuotone;
    MaterialProperty _DuotoneHardness;
    MaterialProperty _DuotoneThreshold;
    MaterialProperty _DuotoneColOne;
    MaterialProperty _DuotoneColTwo;
    //earthquake
    MaterialProperty _SSAllowVerticalShake;
    MaterialProperty _SSAllowHorizontalShake;
    MaterialProperty _SSAllowVerticalBlur;
    MaterialProperty _SSAllowHorizontalBlur;
    MaterialProperty _SSValue;
    MaterialProperty _SSSpeed;
    MaterialProperty _SSValueVert;
    MaterialProperty _SSSpeedVert;
    MaterialProperty _SSTransparency;
    //edge detection
    MaterialProperty _ToggleED;
    MaterialProperty _EDColor;
    MaterialProperty _EDTolerance;
    MaterialProperty _EDGlow;
    MaterialProperty _EDTrans;
    MaterialProperty _EDXOffset;
    MaterialProperty _EDYOffset;
    MaterialProperty _EDToggleRainbow;
    MaterialProperty _EDToggleHSVRainbowX;
    MaterialProperty _EDToggleHSVRainbowY;
    MaterialProperty _EDHSVRainbowHue;
    MaterialProperty _EDHSVRainbowSat;
    MaterialProperty _EDHSVRainbowLight;
    MaterialProperty _EDHSVRainbowTime;
    //edge dither
    MaterialProperty _EDDither;
    MaterialProperty _EDDitherSpeed;
    //edge distortion
    MaterialProperty _ToggleEdgeDistort;
    MaterialProperty _EdgeDisX;
    MaterialProperty _EdgeDisY;
    MaterialProperty _ToggleEdgeDisRotate;
    MaterialProperty _EdgeDisRotStr;
    MaterialProperty _EdgeDisRotSpeed;
    //fade
    MaterialProperty _ToggleFadeProjection;
    MaterialProperty _FPFade;
    MaterialProperty _FPZoom;
    MaterialProperty _FadeLayer;
    MaterialProperty _FPColor;
    //filter
    MaterialProperty _ToggleFilter;
    MaterialProperty _ToggleAdvancedFilter;
    MaterialProperty _ToggleColoredFilter;
    MaterialProperty _FilterColor;
    MaterialProperty _FilterTolerance;
    MaterialProperty _FilterMinR;
    MaterialProperty _FilterMaxR;
    MaterialProperty _FilterMinG;
    MaterialProperty _FilterMaxG;
    MaterialProperty _FilterMinB;
    MaterialProperty _FilterMaxB;
    MaterialProperty _FilterIntensity;
    MaterialProperty _BackgroundFilterIntensity;
    MaterialProperty _BackgroundFilterColor;
    public Boolean showFilterAdvanced;
    public Boolean showFilterColoredBG;
    //film
    MaterialProperty _FilmPower;
    MaterialProperty _FilmAllowLines;
    MaterialProperty _FilmAllowSpots;
    MaterialProperty _FilmAllowStripes;
    //MaterialProperty _FilmAllowJitter;
    MaterialProperty _FilmItterations;
    MaterialProperty _FilmBrightness;
    MaterialProperty _FilmJitterAmount;
    MaterialProperty _FilmSpotStrength;
    MaterialProperty _FilmLinesOften;
    MaterialProperty _FilmSpotsOften;
    MaterialProperty _FilmStripesOften;
    //reel
    MaterialProperty _ToggleReel;
    MaterialProperty _ReelMode;
    MaterialProperty _ReelSpeed;
    MaterialProperty _ReelColor;
    MaterialProperty _ReelBars;
    MaterialProperty _ReelWidth;
    MaterialProperty _ReelBarHeigth;
    MaterialProperty _ReelBarAmounts;
    MaterialProperty _ReelJitter;
    MaterialProperty _ReelRainbow;
    MaterialProperty _ReelRainbowX;
    MaterialProperty _ReelRainbowY;
    //fog
    MaterialProperty _ToggleFog;
    MaterialProperty _FogDensity;
    MaterialProperty _FogColor;
    MaterialProperty _FogRainbow;
    MaterialProperty _FogRainbowSpeed;
    MaterialProperty _FogLayer;
    MaterialProperty _FogSafe;
    MaterialProperty _FogSafeTol;
    //gamma correction
    //MaterialProperty _ToggleGammaCorrect;
    MaterialProperty _GammaRed;
    MaterialProperty _GammaGreen;
    MaterialProperty _GammaBlue;
    //girlscam
    MaterialProperty _ToggleGirlscam;
    MaterialProperty _GirlscamStrength;
    MaterialProperty _GirlscamTime;
    MaterialProperty _GirlscamDir;
    //glitch
    MaterialProperty _ToggleGlitch;
    MaterialProperty _GlitchRedMap;
    MaterialProperty _GlitchRedDistort;
    MaterialProperty _RedYGlitch;
    MaterialProperty _RedXGlitch;
    MaterialProperty _RedTileGlitch;
    MaterialProperty _ToggleRandomGlitch;
    MaterialProperty _ToggleRandomSideGlitch;
    MaterialProperty _XGAnimate;
    MaterialProperty _YGAnimate;
    MaterialProperty _TileGAnimate;
    MaterialProperty _GlitchSideFactor;
    MaterialProperty _ToggleGlitchChromatic;
    MaterialProperty _GlitchRGBStrength;
    MaterialProperty _GlitchRGBSpeed;
    MaterialProperty _GlitchRGB;
    public Boolean showGlitchAnimate;
    public Boolean showGlitchRandDirection;
    public Boolean showGlitchRGB;
    public Boolean showGlitchBrokenColors;
    //rgb glitch
    MaterialProperty _ToggleRGBGlitch;
    MaterialProperty _RGBBlockMethod;
    MaterialProperty _RedNoiseMap;
    MaterialProperty _GreenNoiseMap;
    MaterialProperty _BlueNoiseMap;
    MaterialProperty _RedNoisePower;
    MaterialProperty _RedNoiseSpeed;
    MaterialProperty _GreenNoisePower;
    MaterialProperty _GreenNoiseSpeed;
    MaterialProperty _BlueNoisePower;
    MaterialProperty _BlueNoiseSpeed;
    MaterialProperty _RedBlocks;
    MaterialProperty _GreenBlocks;
    MaterialProperty _BlueBlocks;
    MaterialProperty _RedBlockCount;
    MaterialProperty _GreenBlockCount;
    MaterialProperty _BlueBlockCount;
    MaterialProperty _RedBlockSpeed;
    MaterialProperty _GreenBlockSpeed;
    MaterialProperty _BlueBlockSpeed;
    MaterialProperty _RGBGlitchTrans;
    //glitch scanline
    MaterialProperty _ToggleScanline;
    MaterialProperty _ScanlinePush;
    MaterialProperty _ScanlineSize;
    MaterialProperty _ScanlineSpeed;
    MaterialProperty _ScanlineDir;
    //glitch static
    MaterialProperty _ToggleStaticGlitch;
    MaterialProperty _StaticGlitchMap;
    MaterialProperty _StaticGlitchPush;
    MaterialProperty _StaticGlitchRange;
    //glitch blocky
    MaterialProperty _ToggleBlockyGlitch;
    MaterialProperty _BlockGlitchMap;
    MaterialProperty _AllowBGX;
    MaterialProperty _AllowBGY;
    MaterialProperty _BlockyGlitchStrength;
    MaterialProperty _BGOverlayToggle;
    MaterialProperty _BGOverlayMap;
    //MaterialProperty _AllowRandomnessIncrease;
    MaterialProperty _BGRandomnessIncrease;
    MaterialProperty _ToggleBlockyRGB;
    MaterialProperty _BlockyRGBPush;
    MaterialProperty _BlockyRGBSpeed;
    MaterialProperty _AllowBGColors;
    MaterialProperty _BGOverlayColor;
    MaterialProperty _BGOverlayIntensity;
    MaterialProperty _BGColorIntensity;
    MaterialProperty _BlockyGlitchSpeed;
    MaterialProperty _BDepthX;
    MaterialProperty _BDepthY;
    MaterialProperty _BGBrokenRandom;
    //inception
    MaterialProperty _ToggleInception;
    MaterialProperty _InceptionItterations;
    MaterialProperty _InceptionSize;
    MaterialProperty _InceptionShiftX;
    MaterialProperty _InceptionShiftY;
    //mirror
    MaterialProperty _ToggleMirror;
    MaterialProperty _MirrorHU;
    MaterialProperty _MirrorHO;
    MaterialProperty _MirrorVU;
    MaterialProperty _MirrorVO;
    //multiple screens
    MaterialProperty _ToggleScreens;
    MaterialProperty _MultiScreenX;
    //overlay
    MaterialProperty _ToggleOverlay;
    MaterialProperty _UseSepOverlay;
    MaterialProperty _OverlayTexture;
    MaterialProperty _VROverlayTexture;
    MaterialProperty _OverlayTransparency;
    MaterialProperty _OverlayYAdjust;
    MaterialProperty _OverlayXAdjust;
    MaterialProperty _OverlayTiling;
    MaterialProperty _OverlayXShift;
    MaterialProperty _OverlayYShift;
    MaterialProperty _OverlayTrans;
    MaterialProperty _OverlayTransX;
    MaterialProperty _OverlayTransY;
    MaterialProperty _OvScOne;
    MaterialProperty _OvScOneY;
    MaterialProperty _OvScTwo;
    MaterialProperty _OvScTwoY;
    MaterialProperty _OvScThree;
    MaterialProperty _OvScThreeY;
    MaterialProperty _OvScOneT;
    MaterialProperty _OvScTwoT;
    MaterialProperty _OvScThreeT;
    public Boolean showVRTexture;
    //overlay two
    MaterialProperty _ToggleOverlayTwo;
    MaterialProperty _OverlayTextureTwo;
    MaterialProperty _OverlayTransparencyTwo;
    MaterialProperty _OverlayYAdjustTwo;
    MaterialProperty _OverlayXAdjustTwo;
    MaterialProperty _OverlayTilingTwo;
    MaterialProperty _OverlayXShiftTwo;
    MaterialProperty _OverlayYShiftTwo;
    MaterialProperty _OverlayTransTwo;
    MaterialProperty _OverlayTransXTwo;
    MaterialProperty _OverlayTransYTwo;
    //overlay three
    MaterialProperty _ToggleOverlayThree;
    MaterialProperty _OverlayTextureThree;
    MaterialProperty _OverlayTransparencyThree;
    MaterialProperty _OverlayYAdjustThree;
    MaterialProperty _OverlayXAdjustThree;
    MaterialProperty _OverlayTilingThree;
    MaterialProperty _OverlayXShiftThree;
    MaterialProperty _OverlayYShiftThree;
    MaterialProperty _OverlayTransThree;
    MaterialProperty _OverlayTransXThree;
    MaterialProperty _OverlayTransYThree;
    //gif overlay
    MaterialProperty _ToggleGifOverlay;
    MaterialProperty _OverlaySpritesheet;
    MaterialProperty _OSSRows;
    MaterialProperty _OSSColumns;
    MaterialProperty _OSSSpeed;
    MaterialProperty _GifTransparency;
    MaterialProperty _GifYAdjust;
    MaterialProperty _GifXAdjust;
    MaterialProperty _GifTiling;
    MaterialProperty _GifXShift;
    MaterialProperty _GifYShift;
    public Boolean showCutoutGif;
    //transparent stuff
    MaterialProperty _ToggleTransparentImage;
    MaterialProperty _ToggleTransparentImageTwo;
    MaterialProperty _ToggleTransparentImageThree;
    MaterialProperty _ToggleACTUALTransparentGif;
    //linocut
    MaterialProperty _LinocutPower;
    MaterialProperty _LinocutOpacity;
    MaterialProperty _LinocutColor;
    //noise mask
    MaterialProperty _ToggleNoiseMask;
    MaterialProperty _NoiseMask;
    MaterialProperty _NoiseMaskColor;
    MaterialProperty _NoiseMaskSpeedOne;
    MaterialProperty _NoiseMaskSpeedTwo;
    MaterialProperty _NoiseMaskScale;
    MaterialProperty _NoiseMaskGlow;
    //outline
    MaterialProperty _ToggleOutline;
    MaterialProperty _ToggleSepiaOutline;
    MaterialProperty _OutlineOffset;
    MaterialProperty _OutlineActualOffset;
    MaterialProperty _OutlineModOne;
    MaterialProperty _OutlineModTwo;
    MaterialProperty _OutlineModThree;
    MaterialProperty _OutlineModFour;
    //radial blur
    MaterialProperty _ToggleRadialBlur;
    MaterialProperty _RadialBlurDistance;
    MaterialProperty _RadialBlurVerticalCenter;
    MaterialProperty _RadialBlurHorizontalCenter;
    MaterialProperty _RBToggleED;
    MaterialProperty _RBEDTolerance;
    MaterialProperty _RBEDTrans;
    MaterialProperty _RBEDWidth;
    MaterialProperty _RBEDBW;
    MaterialProperty _RBEDToggleRainbow;
    MaterialProperty _RBEDToggleHSVRainbowX;
    MaterialProperty _RBEDToggleHSVRainbowY;
    MaterialProperty _RBEDHSVRainbowHue;
    MaterialProperty _RBEDHSVRainbowSat;
    MaterialProperty _RBEDHSVRainbowLight;
    MaterialProperty _RBEDHSVRainbowTime;
    MaterialProperty _RBEDBackPower;
    MaterialProperty _RBDither;
    MaterialProperty _RBDitherSpeed;
    MaterialProperty _RBToggleRainbow;
    MaterialProperty _RBToggleHSVRainbowX;
    MaterialProperty _RBToggleHSVRainbowY;
    MaterialProperty _RBHSVRainbowHue;
    MaterialProperty _RBHSVRainbowSat;
    MaterialProperty _RBHSVRainbowLight;
    MaterialProperty _RBHSVRainbowTime;
    MaterialProperty _RBRotate;
    MaterialProperty _RBRotateSpeed;
    MaterialProperty _RBCAOffset;
    MaterialProperty _RBCATrans;
    MaterialProperty _RBEmpower;
    MaterialProperty _RBMode;
    MaterialProperty _RBEDBackColor;
    MaterialProperty _RBEDColor;
    MaterialProperty _RBItterations;
    MaterialProperty _RBEDOnly;
    MaterialProperty _RBEDBalance;
    MaterialProperty _RBGrainPower;
    MaterialProperty _RBGrainSpeed;
    MaterialProperty _RBGrainColor;
    MaterialProperty _RBGrainBlack;
    //ramp
    MaterialProperty _ToggleRampEffect;
    MaterialProperty _RampColorChannel;
    MaterialProperty _RampMap;
    MaterialProperty _RampOneLighting;
    MaterialProperty _RampOneDepth;
    MaterialProperty _RampOneStrength;
    MaterialProperty _RampOneSpeed;
    MaterialProperty _ToggleRampOneAnimate;
    public Boolean showRampOneAA;
    //recolor
    MaterialProperty _ToggleRecolor;
    MaterialProperty _RecolorBright;
    MaterialProperty _RecolorSat;
    MaterialProperty _RecolorHue;
    MaterialProperty _RecolorSpeed;
    MaterialProperty _ToggleRecolorAnimate;
    //rgb
    MaterialProperty _ToggleRGB;
    MaterialProperty _ToggleCleanRGB;
    MaterialProperty _CAMode;
    MaterialProperty _CASamples;
    MaterialProperty _CATrans;
    MaterialProperty _CARotate;
    MaterialProperty _CARotateSpeed;
    MaterialProperty _CAOffsetX;
    MaterialProperty _CAOffsetY;
    MaterialProperty _RedXValue;
    MaterialProperty _RedYValue;
    MaterialProperty _GreenXValue;
    MaterialProperty _GreenYValue;
    MaterialProperty _BlueXValue;
    MaterialProperty _BlueYValue;
    MaterialProperty _ToggleAutoanimate;
    MaterialProperty _RGBAutoanimateSpeed;
    MaterialProperty _CAStyle;
    MaterialProperty _RotationStrength;
    MaterialProperty _RotationSpeedRed;
    MaterialProperty _RotationSpeedBlue;
    MaterialProperty _DirectionRed;
    MaterialProperty _DirectionBlue;
    MaterialProperty _RotationSpeedGreen;
    MaterialProperty _DirectionGreen;
    MaterialProperty _ToggleScreenFollow;
    MaterialProperty _ToggleGreenMove;
    //rgb hide
    MaterialProperty _HideRedTrans;
    MaterialProperty _HideGreenTrans;
    MaterialProperty _HideBlueTrans;
    //rgb zoom
    MaterialProperty _ToggleRGBZoom;
    MaterialProperty _RedZoom;
    MaterialProperty _GreenZoom;
    MaterialProperty _BlueZoom;
    MaterialProperty _RGBZoomTrans;
    MaterialProperty _RGBZoomTransB;
    MaterialProperty _RGBZoomTransG;
    //ripple
    MaterialProperty _ToggleRipple;
    MaterialProperty _ShockCenterX;
    MaterialProperty _ShockCenterY;
    MaterialProperty _ShockDis;
    MaterialProperty _ShockSpread;
    MaterialProperty _ShockMag;
    //rotation 
    MaterialProperty _ToggleRotater;
    MaterialProperty _RotaterValue;
    MaterialProperty _ToggleRotaterAnimate;
    MaterialProperty _RotaterSpin;
    //pixelate
    MaterialProperty _TogglePixelate;
    MaterialProperty _PixelateStrength;
    MaterialProperty _PixelateStrengthY;
    MaterialProperty _GTogglePixelate;
    MaterialProperty _GPixelStrength;
    MaterialProperty _GPixelStrengthY;
    MaterialProperty _GPixelFreq;
    MaterialProperty _GPixelGlitchMap;
    //posterize 
    MaterialProperty _PosterizeValue;
    //rainbow
    MaterialProperty _ToggleHSVRainbow;
    MaterialProperty _ToggleHSVRainbowX;
    MaterialProperty _ToggleHSVRainbowY;
    MaterialProperty _HSVRainbowHue;
    MaterialProperty _HSVRainbowSat;
    MaterialProperty _HSVRainbowLight;
    MaterialProperty _HSVRainbowTime;
    //saturation
    MaterialProperty _SaturationValue;
    //sepia
    MaterialProperty _SepiaRStrength;
    MaterialProperty _SepiaRWarmth;
    MaterialProperty _SEpiaRTone;
    //contrast
    MaterialProperty _ContrastValue;
    //scroll
    MaterialProperty _ScrollX;
    MaterialProperty _ScrollY;
    //screenpull
    MaterialProperty _ToggleScreenpull;
    MaterialProperty _ScreenpullMode;
    MaterialProperty _ScreenpullStrength;
    MaterialProperty _ScreenpullStrengthTwo;
    MaterialProperty _ScreenpullMap;
    //apart
    MaterialProperty _ApartMode;
    MaterialProperty _Apart;
    MaterialProperty _ApartColor;
    //screenzoom
    MaterialProperty _ToggleScreenZoom;
    MaterialProperty _ScreenZoomInValue;
    MaterialProperty _ScreenZoomOutValue;
    //shake
    MaterialProperty _ToggleShake;
    MaterialProperty _ShakeModel;
    MaterialProperty _ToggleXYShake;
    MaterialProperty _ShakeStrength;
    MaterialProperty _ShakeSpeed;
    MaterialProperty _emptyTex;
    MaterialProperty _ShakeStrength2;
    MaterialProperty _ShakeSpeed2;
    Boolean showXYShake;
    //smear
    MaterialProperty _ToggleSmear;
    MaterialProperty _CSDirection;
    MaterialProperty _CSCopies;
    MaterialProperty _CSRed;
    MaterialProperty _CSGreen;
    MaterialProperty _CSBlue;
    MaterialProperty _CSAutoRotate;
    MaterialProperty _CSRotateSpeed;
    MaterialProperty _CSUseAdvanced;
    MaterialProperty _CSRotateSpeedSinXR;
    MaterialProperty _CSRotateSpeedCosXR;
    MaterialProperty _CSRotateSpeedSinYR;
    public Boolean showCSAnimate;
    public Boolean showCSAdv;
    public Boolean showColor;
    //static
    MaterialProperty _ToggleNoise;
    MaterialProperty _StaticIntensity;
    MaterialProperty _ToggleAnimatedNoise;
    MaterialProperty _StaticSize;
    MaterialProperty _StaticSpeed;
    MaterialProperty _StaticBlack;
    MaterialProperty _StaticColor;
    MaterialProperty _ToggleStaticMap;
    MaterialProperty _StaticMap;
    MaterialProperty _StaticOverlay;
    //swirl
    MaterialProperty _ToggleSwirl;
    MaterialProperty _SwirlPower;
    MaterialProperty _SwirlCenterX;
    MaterialProperty _SwirlCenterY;
    MaterialProperty _SwirlRadius;
    //splice
    MaterialProperty _ToggleSplice;
    MaterialProperty _SpliceTop;
    MaterialProperty _SpliceBot;
    MaterialProperty _SpliceXLimit;
    MaterialProperty _SpliceLeft;
    MaterialProperty _SpliceRight;
    MaterialProperty _SpliceYLimit;
    //silhouette
    MaterialProperty _ToggleSilhouette;
    MaterialProperty _SilhouetteDepth;
    MaterialProperty _SilhouetteBack;
    MaterialProperty _SilhouetteFront;
    MaterialProperty _SilhouetteRainLayer;
    MaterialProperty _SilhouetteRainbow;
    MaterialProperty _SilhouetteRainbowSpeed;
    MaterialProperty _SilhouetteLighting;
    MaterialProperty _SilhouetteLightingMode;
    //thermal
    MaterialProperty _ThermalHeat;
    MaterialProperty _ThermalSensitivity;
    MaterialProperty _ThermalTransparency;
    MaterialProperty _ThermalColor;
    //transistion
    MaterialProperty _ToggleTransistion;
    MaterialProperty _TransX;
    MaterialProperty _TransY;
    MaterialProperty _ToggleDiagTrans;
    MaterialProperty _TransDL;
    MaterialProperty _TransDR;
    //vhs 
    MaterialProperty _ToggleVHS;
    MaterialProperty _ToggleSmoothWave;
    MaterialProperty _VHSXDisplacement;
    MaterialProperty _VHSYDisplacement;
    MaterialProperty _shadowStrength;
    MaterialProperty _darkness;
    MaterialProperty _waveyness;
    //vignette
    MaterialProperty _ToggleVignette;
    MaterialProperty _VigX;
    MaterialProperty _VigColor;
    MaterialProperty _VigColPow;
    MaterialProperty _VigMode;
    MaterialProperty _VigReverse;
    MaterialProperty _VigSharpness;
    //visualizer
    MaterialProperty _ToggleVisualizer;
    MaterialProperty _VisBarLeft;
    MaterialProperty _VisBarRight;
    MaterialProperty _VisBarColor;
    MaterialProperty _VisBaseColor;
    MaterialProperty _VisBarWidth;
    MaterialProperty _VisBaseWidth;
    MaterialProperty _VisMode;
    MaterialProperty _VisBarThree;
    MaterialProperty _VisBarFour;
    MaterialProperty _VisBarFive;
    MaterialProperty _VisBarSix;
    MaterialProperty _VisBarSeven;
    MaterialProperty _VisBarEight;
    MaterialProperty _VisBarNine;
    MaterialProperty _VisBarTen;
    MaterialProperty _VisStopperColor;
    MaterialProperty _VisCircleSize;
    MaterialProperty _VisClassicBase;
    MaterialProperty _VisClassicShape;
    MaterialProperty _VisBarRainbow;
    MaterialProperty _VisClassicMaxSize;
    //visualizer rainbow
    MaterialProperty _ToggleHSVRainbowVis;
    MaterialProperty _ToggleHSVRainbowXVis;
    MaterialProperty _ToggleHSVRainbowYVis;
    MaterialProperty _HSVRainbowHueVis;
    MaterialProperty _HSVRainbowSatVis;
    MaterialProperty _HSVRainbowLightVis;
    MaterialProperty _HSVRainbowTimeVis;
    //vibrance
    MaterialProperty _VibrancePower;
    //warp
    MaterialProperty _WarpHorizontal;
    MaterialProperty _WarpVertical;
    //deepfry
    MaterialProperty _ToggleDeepfry;
    MaterialProperty _DeepfryValue;
    MaterialProperty _DeepfryBrightness;
    MaterialProperty _DeepfryEmbossPower;
    //zoom range
    MaterialProperty _ToggleZoomRange;
    MaterialProperty _ZoomRange;
    MaterialProperty _ZoomFStart;
    MaterialProperty _ZoomFEnd;
    //warp zoom
    MaterialProperty _ToggleWarpZoom;
    MaterialProperty _WarpZoomAmount;
    MaterialProperty _WarpZoomTolerance;
    //wavey
    MaterialProperty _ToggleWavey;
    MaterialProperty _WavesX;
    MaterialProperty _WavesXPower;
    MaterialProperty _WavesXSpeed;
    MaterialProperty _WavesY;
    MaterialProperty _WavesYPower;
    MaterialProperty _WavesYSpeed;
    //edge width stuff added down here all at once uwu
    MaterialProperty _EDBW;
    MaterialProperty _EDWidth;
    MaterialProperty _EPWidth;
    MaterialProperty _ROWidth;
    //edge addon stuff added down here all at once uwu
    MaterialProperty _EDBackPower;
    MaterialProperty _EDBackColor;
    MaterialProperty _EDRampAllow;
    MaterialProperty _EDRampMap;
    MaterialProperty _EDRampX;
    MaterialProperty _EDRampY;
    MaterialProperty _EDRampSX;
    MaterialProperty _EDRampSY;
    MaterialProperty _EDRampScroll;
    //VR
    MaterialProperty _VRAdjust;
    MaterialProperty _VRPreview;
    MaterialProperty _VRLeft;
    MaterialProperty _VRLeftColor;
    MaterialProperty _VRRight;
    MaterialProperty _VRRightColor;
    //gui settings
    //MaterialProperty _unityThemeColor;
    MaterialProperty __hideUnusedFX;
    //Styles 
    GUIStyle dropdownStyle;
    GUIStyle subdropdownStyle;
    GUIStyle headernameStyle;
    GUIStyle versionheaderStyle;
    GUIStyle thankyouStyle;
    GUIStyle loveStyle;
    GUIStyle distributeStyle;
    GUIStyle propInfoStyle;
    GUIStyle propInfoTinyStyle;
    GUIStyle helpHeaderStyle;
    GUIStyle helpInfoStyle;
    static GUIStyle friendStyle;
    GUIStyle fakePropertyStyle;
    GUIStyle sectionStyle;
    //click me senpai pls
    static bool animateClick;
    static bool dropdownClick; //used for render settings
    static bool depthClick;
    static bool renderatmeClick;
    static bool screentearClick;
    static bool screenspaceClick;
    static bool screencolorClick;
    static bool afterimageClick;
    static bool asciiClick;
    static bool blackandwhiteClick;
    static bool bigboxzoomClick;
    static bool centerzoomInstructionsClick;
    static bool blinkClick;
    static bool blurClick;
    static bool fragmentblurClick;
    static bool bloomClick;
    static bool rbloomClick;
    static bool bulgeClick;
    static bool zoomClick;
    static bool circularBlur;
    static bool circshakeClick;
    static bool colorClick;
    static bool colorsplitClick;
    static bool cornercolorClick;
    static bool cornerClick;
    static bool darkenClick;
    static bool divideClick;
    static bool distortClick;
    static bool heatdistortClick;
    static bool distortAdvClick;
    static bool dizzyClick;
    static bool dropletClick;
    static bool dropletColOneClick;
    static bool dropletColTwoClick;
    static bool dropletColThreeClick;
    static bool dropletColFourClick;
    static bool duotoneClick;
    static bool earthquakeClick;
    static bool edgyClick;
    static bool edgeDetectClick;
    static bool edgeProjectClick;
    static bool edgeDistortClick;
    static bool edgeBackgroundClick;
    static bool edgeRainbowClick;
    static bool edgeRampClick;
    static bool edgeDitherClick;
    static bool embossClick;
    static bool falloffClick;
    static bool fadeprojectionClick;
    static bool filterClick;
    static bool filterAdvClick;
    static bool filterColBGClick;
    static bool filmClick;
    static bool fogClick;
    static bool fisheyeClick;
    static bool gammaClick;
    static bool gaussianClick;
    static bool girlscamClick;
    static bool glitchClick;
    static bool glitchBlockClick;
    static bool glitchColorsClick;
    static bool glitchpixelClick;
    static bool glitchCRTClick;
    static bool glitchScanlineClick;
    static bool glitchStaticClick;
    static bool glitchAnimClick;
    static bool glitchRandClick;
    static bool glitchRGBClick;
    static bool invertClick;
    static bool inceptionClick;
    static bool magnitudeClick;
    static bool mirrorClick;
    static bool multiscreenClick;
    static bool overlayClick;
    static bool overlaytwoClick;
    static bool overlaythreeClick;
    static bool gifClick;
    static bool horizontalblurClick;
    static bool linocutClick;
    static bool noisemaskClick;
    static bool outlineClick;
    static bool rainbowOutlineClick;
    static bool rainbowClick;
    static bool radialblurClick;
    static bool radialsettingsClick;
    static bool radialoutlineClick;
    static bool radialditherClick;
    static bool radialrgbClick;
    static bool radialrotateClick;
    static bool radialrainbowClick;
    static bool radialClick;
    static bool radialGrainClick;
    static bool rampClick;
    static bool recolorClick;
    static bool rgbClick;
    static bool rgbrotateClick;
    static bool rgbscreenfollowClick;
    static bool rgbcolorClick;
    static bool rgbgridClick;
    static bool rgbzoomClick;
    static bool rippleClick;
    static bool rotateClick;
    static bool pixelateClick;
    static bool posterizeClick;
    static bool projectionClick;
    static bool projectionAdvClick;
    static bool saturationClick;
    static bool scrollClick;
    static bool screeninscreenClick;
    static bool screensquishClick;
    static bool screenpullClick;
    static bool apartClick;
    static bool screenzoomClick;
    static bool screenfreezeClick;
    static bool shakeClick;
    static bool smearClick;
    static bool staticClick;
    static bool swirlClick;
    static bool spliceClick;
    static bool silhouetteClick;
    static bool thermalClick;
    static bool transClick;
    static bool twistClick;
    static bool verticalblurClick;
    static bool vhsClick;
    static bool vignetteClick;
    static bool visualizerClick;
    static bool warpClick;
    static bool warpZoomClick;
    static bool waveyClick;
    static bool deepfryClick;
    static bool vrClick;
    static bool allzoomsClick;
    static bool alloutlineClick;
    static bool allshakesClick;
    static bool allrgbClick;
    static bool alldistortClick;
    //other clicks
    static bool deepfryListClick;
    static bool asciiAdvanvedClick;
    static bool unusedshakeClick;
    static bool helpClick;
    static bool changelogClick;
    static bool friendspatreonClick;
    static bool friendsClick;
    static bool patreonClick;
    static bool settingsClick;
    static bool zoomhelpClick;
    static bool zoomrangeClick;
    static bool acknowledgesmentClick;
    //help sections
    static bool multFxClick;
    static bool whatdoesClick;
    static bool laggingmeClick;
    static bool dontunderstandClick;
    static bool featureClick;
    static bool shadertoyClick;
    static bool howusefalloffClick;
    static bool rangehelpClick;
    static bool lookatmehelpClick;
    static bool termshelpClick;
    static bool basedonClick;
    static bool eulaClick;
    //optimization stuff
    static bool toggleAnimateClick;
    //description settings
    static bool falloffdescriptionClick;
    static bool depthdescriptionClick;
    static bool renderatmedescriptionClick;
    //settings
    static string settingsToggledOn = "(Enabled)";
    //if effects are toggled or notall gui side (new toggle)
    static bool ntFalloff;
    static bool ntDepthTest;
    static bool ntScreentear;
    static bool ntApart;
    static bool ntSepia;
    static bool ntInvert;
    static bool ntScreenspace;
    static bool ntUpsideDown;
    static bool ntScreenFlip;
    static bool ntAfterimage;
    static bool ntAscii;
    static bool ntbigboxZoom;
    static bool ntBlink;
    static bool ntBlur;
    static bool ntBloom;
    static bool ntRBloom;
    static bool ntBulge;
    static bool ntZoom;
    static bool ntCircularBlur;
    static bool ntCircShake;
    static bool ntColorTint;
    static bool ntColorSplit;
    static bool ntCornerColor;
    static bool ntCorners;
    static bool ntDarken;
    static bool ntDivide;
    static bool ntDistort;
    static bool ntDizzy;
    static bool ntDroplet;
    static bool ntDuotone;
    static bool ntSplitShake;
    static bool ntEdgeDetect;
    static bool ntEdgeBackground;
    static bool ntEdgeRainbow;
    static bool ntEdgeRamp;
    static bool ntEdgeDither;
    static bool ntEdgeProject;
    static bool ntEdgeDistort;
    static bool ntEdgy;
    static bool ntEmboss;
    static bool ntFadeProjection;
    static bool ntFilter;
    static bool ntFilm;
    static bool ntFog;
    static bool ntFisheye;
    static bool ntGammaCorrect;
    static bool ntUnfocusBlur;
    static bool ntGirlscam;
    static bool ntGlitch;
    static bool ntGlitchChromatic;
    static bool ntBlockyGlitch;
    static bool ntPixelGlitch;
    static bool ntScanline;
    static bool ntHorizontalBlur;
    static bool ntHeatDistort;
    static bool ntInception;
    static bool ntMagnitude;
    static bool ntMirror;
    static bool ntMultiscreen;
    static bool ntOverlay;
    static bool ntGifOverlay;
    static bool ntLinocut;
    static bool ntOutline;
    static bool ntRadialBlur;
    static bool ntRadialSettings;
    static bool ntRadialOutline;
    static bool ntRadial;
    static bool ntRadialDither;
    static bool ntRadialRGB;
    static bool ntRadialRotate;
    static bool ntRadialRainbow;
    static bool ntRadialGrain;
    static bool ntHSVRainbow;
    static bool ntRampEffect;
    static bool ntRecolor;
    static bool ntRenderAtMe;
    static bool ntRGB;
    static bool ntRGBGrid;
    static bool ntRGBGlitch;
    static bool ntRGBZoom;
    static bool ntRipple;
    static bool ntRotater;
    static bool ntPixelate;
    static bool ntPosterize;
    static bool ntProjection;
    static bool ntSaturation;
    static bool ntScroll;
    static bool ntScreenSquish;
    static bool ntScreenpull;
    static bool ntScreenzoom;
    static bool ntScreenfreeze;
    static bool ntShake;
    static bool ntSmear;
    static bool ntSwirl;
    static bool ntSplice;
    static bool ntSilhouette;
    static bool ntNoise;
    static bool ntNoiseMask;
    static bool ntThermal;
    static bool ntTransistion;
    static bool ntTwist;
    static bool ntVHS;
    static bool ntVignette;
    static bool ntVisualizer;
    static bool ntVerticalBlur;
    static bool ntWarp;
    static bool ntWarpZoom;
    static bool ntWavey;
    static bool ntDeepfry;
    static bool ntVR;
    static bool ntAllZooms;
    static bool ntAllOutlines;
    static bool ntAllShakes;
    static bool ntAllRGB;
    static bool ntAllDistort;
    #endregion


    //==== formatting ===
    #region formatting

    //setting up the custom submenu foldout
    private static bool SubmenuFoldout(string title, bool display)
    {
        var style = new GUIStyle("ShurikenModuleTitle");
        style.font = new GUIStyle(EditorStyles.label).font;
        style.border = new RectOffset(15, 7, 4, 4);
        style.fixedHeight = 22;
        style.contentOffset = new Vector2(20f, -2f);

        var rect = GUILayoutUtility.GetRect(16f, 22f, style);
        GUI.Box(rect, title, style);

        var e = Event.current;

        var toggleRect = new Rect(rect.x + 4f, rect.y + 2f, 13f, 13f);
        if (e.type == EventType.Repaint)
        {
            EditorStyles.foldout.Draw(toggleRect, false, false, display, false);
        }

        if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition))
        {
            display = !display;
            e.Use();
        }

        return display;
    }

    //reading properties from the shader
    private void findProperty(MaterialProperty[] properties)
    {

        //Render settings
        _Range = ShaderGUI.FindProperty("_FalloffRange", properties);
        _ToggleRenderLookAtMe = ShaderGUI.FindProperty("_ToggleRenderLookAtMe", properties);
        _RenderMeTolerance = ShaderGUI.FindProperty("_RenderMeTolerance", properties);
        _ZTest = ShaderGUI.FindProperty("_ZTest", properties);
        _AllowSmartFalloff = ShaderGUI.FindProperty("_AllowSmartFalloff", properties);
        _SmartFalloffMin = ShaderGUI.FindProperty("_SmartFalloffMin", properties);
        _SmartFalloffMax = ShaderGUI.FindProperty("_SmartFalloffMax", properties);
        _OverallOpacity = ShaderGUI.FindProperty("_OverallOpacity", properties);
        _ParticleSystem = ShaderGUI.FindProperty("_ParticleSystem", properties);

        //Depth settings
        _AllowDepthTest = ShaderGUI.FindProperty("_AllowDepthTest", properties);
        _DepthValue = ShaderGUI.FindProperty("_DepthValue", properties);
        _KeepPlayerInFocus = ShaderGUI.FindProperty("_KeepPlayerInFocus", properties);
        _DepthPlayerTolerance = ShaderGUI.FindProperty("_DepthPlayerTolerance", properties);
        _DepthPlayerPower = ShaderGUI.FindProperty("_DepthPlayerPower", properties);
        _ReverseDepth = ShaderGUI.FindProperty("_ReverseDepth", properties);

        //Screentear settings
        _AllowTearFix = ShaderGUI.FindProperty("_AllowTearFix", properties);
        _ScreenTearColor = ShaderGUI.FindProperty("_ScreenTearColor", properties);
        _TearToMirror = ShaderGUI.FindProperty("_TearToMirror", properties);
        _TearToRepeat = ShaderGUI.FindProperty("_TearToRepeat", properties);

        //VR settings
        _VRAdjust = ShaderGUI.FindProperty("_VRAdjust", properties);
        _VRPreview = ShaderGUI.FindProperty("_VRPreview", properties);
        _VRLeft = ShaderGUI.FindProperty("_VRLeft", properties);
        _VRLeftColor = ShaderGUI.FindProperty("_VRLeftColor", properties);
        _VRRight = ShaderGUI.FindProperty("_VRRight", properties);
        _VRRightColor = ShaderGUI.FindProperty("_VRRightColor", properties);

        //Screenspace settings
        //_ToggleSepia = ShaderGUI.FindProperty("_ToggleSepia", properties);
        //_ToggleInvert = ShaderGUI.FindProperty("_ToggleInvert", properties);
        _SepiaStrength = ShaderGUI.FindProperty("_SepiaStrength", properties);
        _SepiaColor = ShaderGUI.FindProperty("_SepiaColor", properties);
        _InvertMode = ShaderGUI.FindProperty("_InvertMode", properties);
        _InvertStrength = ShaderGUI.FindProperty("_InvertStrength", properties);
        _InvertR = ShaderGUI.FindProperty("_InvertR", properties);
        _InvertB = ShaderGUI.FindProperty("_InvertB", properties);
        _InvertG = ShaderGUI.FindProperty("_InvertG", properties);
        _ToggleScreenFlip = ShaderGUI.FindProperty("_ToggleScreenFlip", properties);
        _ToggleUpsideDown = ShaderGUI.FindProperty("_ToggleUpsideDown", properties);

        //Ascii settings
        _ToggleAscii = ShaderGUI.FindProperty("_ToggleAscii", properties);
        _ASCIIVariation = ShaderGUI.FindProperty("_ASCIIVariation", properties);
        _ASCIIPower = ShaderGUI.FindProperty("_ASCIIPower", properties);
        _ASCIISpeed = ShaderGUI.FindProperty("_ASCIISpeed", properties);
        _ASCIIShapeOne = ShaderGUI.FindProperty("_ASCIIShapeOne", properties);
        _ASCIIShapeTwo = ShaderGUI.FindProperty("_ASCIIShapeTwo", properties);
        _ASCIIShapeThree = ShaderGUI.FindProperty("_ASCIIShapeThree", properties);
        _ASCIIShapeFour = ShaderGUI.FindProperty("_ASCIIShapeFour", properties);
        _ASCIIShapeFive = ShaderGUI.FindProperty("_ASCIIShapeFive", properties);
        _ASCIIShapeSix = ShaderGUI.FindProperty("_ASCIIShapeSix", properties);
        _ASCIIShapeSeven = ShaderGUI.FindProperty("_ASCIIShapeSeven", properties);
        _ASCIIShapeEight = ShaderGUI.FindProperty("_ASCIIShapeEight", properties);

        //Big box zoom settings
        _ToggleBigZoom = ShaderGUI.FindProperty("_ToggleBigZoom", properties);
        _BigZoomAmount = ShaderGUI.FindProperty("_BigZoomAmount", properties);
        _BigZoomTolerance = ShaderGUI.FindProperty("_BigZoomTolerance", properties);
        _BigZoomOutAmount = ShaderGUI.FindProperty("_BigZoomOutAmount", properties);

        //Blink settings
        _BlinkMode = ShaderGUI.FindProperty("_BlinkMode", properties);
        _BlinkStrength = ShaderGUI.FindProperty("_BlinkStrength", properties);
        _BlinkColor = ShaderGUI.FindProperty("_BlinkColor", properties);
        _BlinkForce = ShaderGUI.FindProperty("_ForceBlink", properties);
        _BlinkImage = ShaderGUI.FindProperty("_BlinkImage", properties);
        _BlinkImagePower = ShaderGUI.FindProperty("_BlinkImagePower", properties);
        _BlinkImageX = ShaderGUI.FindProperty("_BlinkImageX", properties);
        _BlinkImageY = ShaderGUI.FindProperty("_BlinkImageY", properties);
        _BlinkBorderSize = ShaderGUI.FindProperty("_BlinkBorderSize", properties);
        _BlinkBorder = ShaderGUI.FindProperty("_BlinkBorder", properties);
        _BlinkRainbow = ShaderGUI.FindProperty("_BlinkRainbow", properties);
        _BlinkRainbowX = ShaderGUI.FindProperty("_BlinkRainbowX", properties);
        _BlinkRainbowY = ShaderGUI.FindProperty("_BlinkRainbowY", properties);
        _BlinkRainbowHue = ShaderGUI.FindProperty("_BlinkRainbowHue", properties);
        _BlinkRainbowSat = ShaderGUI.FindProperty("_BlinkRainbowSat", properties);
        _BlinkRainbowLight = ShaderGUI.FindProperty("_BlinkRainbowLight", properties);
        _BlinkRainbowTime = ShaderGUI.FindProperty("_BlinkRainbowTime", properties);
        _BlinkRainbowMode = ShaderGUI.FindProperty("_BlinkRainbowMode", properties);

        //Bloom settings
        _BloomGlow = ShaderGUI.FindProperty("_BloomGlow", properties);

        //Bloom settings
        _RBloomToggle = ShaderGUI.FindProperty("_RBloomToggle", properties);
        _RBloomQuality = ShaderGUI.FindProperty("_RBloomQuality", properties);
        _RBloomStrength = ShaderGUI.FindProperty("_RBloomStrength", properties);
        _RBloomBright = ShaderGUI.FindProperty("_RBloomBright", properties);
        _RBloomColor = ShaderGUI.FindProperty("_RBloomColor", properties);
        _RBloomOpacity = ShaderGUI.FindProperty("_RBloomOpacity", properties);
        _RBloomDepth = ShaderGUI.FindProperty("_RBloomDepth", properties);

        //New blur settings
        _ToggleNBlur = ShaderGUI.FindProperty("_ToggleNBlur", properties);
        _NBlurShape = ShaderGUI.FindProperty("_NBlurShape", properties);
        _NBlurItterations = ShaderGUI.FindProperty("_NBlurItterations", properties);
        _NBlurPower = ShaderGUI.FindProperty("_NBlurPower", properties);
        _NBlurSpeed = ShaderGUI.FindProperty("_NBlurSpeed", properties);
        _NBlurRotate = ShaderGUI.FindProperty("_NBlurRotate", properties);
        _NBlurRotateSpeed = ShaderGUI.FindProperty("_NBlurRotateSpeed", properties);
        _NBlurX = ShaderGUI.FindProperty("_NBlurX", properties);
        _NBlurY = ShaderGUI.FindProperty("_NBlurY", properties);
        _NBlurColor = ShaderGUI.FindProperty("_NBlurColor", properties);
        _NBlurGlow = ShaderGUI.FindProperty("_NBlurGlow", properties);
        _NBlurOpacity = ShaderGUI.FindProperty("_NBlurOpacity", properties);

        //Bulge settings
        _ToggleBulge = ShaderGUI.FindProperty("_ToggleBulge", properties);
        _BulgeIndent = ShaderGUI.FindProperty("_BulgeIndent", properties);
        _OwoStrength = ShaderGUI.FindProperty("_OwOStrength", properties);

        //Centered zoom settings
        _ToggleZoom = ShaderGUI.FindProperty("_ToggleZoom", properties);
        _ToggleFlipZoom = ShaderGUI.FindProperty("_ToggleFlipZoom", properties);
        _ZoomInValue = ShaderGUI.FindProperty("_ZoomInValue", properties);
        _ZoomOutValue = ShaderGUI.FindProperty("_ZoomOutValue", properties);
        _SmoothZoom = ShaderGUI.FindProperty("_SmoothZoom", properties);
        _SmoothZoomTolerance = ShaderGUI.FindProperty("_SmoothZoomTolerance", properties);

        //Color settings
        //_ToggleColorTint = ShaderGUI.FindProperty("_ToggleColorTint", properties);
        _ColorHue = ShaderGUI.FindProperty("_ColorHue", properties);
        _ColorSaturation = ShaderGUI.FindProperty("_ColorSaturation", properties);
        _ColorValue = ShaderGUI.FindProperty("_ColorValue", properties);
        //_ToggleRGBTint = ShaderGUI.FindProperty("_ToggleRGBTint", properties);
        _ColorRGB = ShaderGUI.FindProperty("_ColorRGB", properties);
        _SolidTrans = ShaderGUI.FindProperty("_SolidTrans", properties);
        _SolidCol = ShaderGUI.FindProperty("_SolidCol", properties);
        //extra color options
        _ColorRGBtoHSV = ShaderGUI.FindProperty("_ColorRGBtoHSV", properties);
        _ColorHSVtoRGB = ShaderGUI.FindProperty("_ColorHSVtoRGB", properties);

        //Color split settings
        _ToggleColorSplit = ShaderGUI.FindProperty("_ToggleColorSplit", properties);
        _ColorSplitAmount = ShaderGUI.FindProperty("_ColorSplitAmount", properties);
        _ColorSplitRGBone = ShaderGUI.FindProperty("_ColorSplitRGBone", properties);
        _ColorSplitRGBtwo = ShaderGUI.FindProperty("_ColorSplitRGBtwo", properties);
        _ColSpONEopacity = ShaderGUI.FindProperty("_ColSpONEopacity", properties);
        _ColSpTWOopacity = ShaderGUI.FindProperty("_ColSpTWOopacity", properties);
        _ColSpTHREEOpacity = ShaderGUI.FindProperty("_ColSpTHREEopacity", properties);
        _ColorSplitRGBthree = ShaderGUI.FindProperty("_ColorSplitRGBthree", properties);
        _ToggleColorSplitStaySides = ShaderGUI.FindProperty("_ToggleColorSplitStaySides", properties);
        _ToggleAutoanimateColorSplit = ShaderGUI.FindProperty("_ToggleAutoanimateColorSplit", properties);
        _ColorSplitSpeed = ShaderGUI.FindProperty("_ColorSplitSpeed", properties);
        _CSLX = ShaderGUI.FindProperty("_CSLX", properties);
        _CSLY = ShaderGUI.FindProperty("_CSLY", properties);
        _CSMX = ShaderGUI.FindProperty("_CSMX", properties);
        _CSMY = ShaderGUI.FindProperty("_CSMY", properties);
        _CSRX = ShaderGUI.FindProperty("_CSRX", properties);
        _CSRY = ShaderGUI.FindProperty("_CSRY", properties);
        _CSL = ShaderGUI.FindProperty("_CSL", properties);
        _CSRotate = ShaderGUI.FindProperty("_CSRotate", properties);
        _ColSplRotateSpeed = ShaderGUI.FindProperty("_ColSplRotateSpeed", properties);
        _CSOffsetX = ShaderGUI.FindProperty("_CSOffsetX", properties);
        _CSOffsetY = ShaderGUI.FindProperty("_CSOffsetY", properties);
        _CSTrans = ShaderGUI.FindProperty("_CSTrans", properties);

        //Color spin settings
        _ToggleCC = ShaderGUI.FindProperty("_ToggleCC", properties);
        _CCApply = ShaderGUI.FindProperty("_CCApply", properties);
        _CCOne = ShaderGUI.FindProperty("_CCOne", properties);
        _CCTwo = ShaderGUI.FindProperty("_CCTwo", properties);
        _CCThree = ShaderGUI.FindProperty("_CCThree", properties);
        _CCFour = ShaderGUI.FindProperty("_CCFour", properties);
        _CCRotate = ShaderGUI.FindProperty("_CCRotate", properties);
        _CCSpeed = ShaderGUI.FindProperty("_CCSpeed", properties);

        //Corner color settings
        _CornerOneColor = ShaderGUI.FindProperty("_CornerOneColor", properties);
        _CornerTwoColor = ShaderGUI.FindProperty("_CornerTwoColor", properties);
        _CornerThreeColor = ShaderGUI.FindProperty("_CornerThreeColor", properties);
        _CornerFourColor = ShaderGUI.FindProperty("_CornerFourColor", properties);
        _CornerOneTrans = ShaderGUI.FindProperty("_CornerOneTrans", properties);
        _CornerTwoTrans = ShaderGUI.FindProperty("_CornerTwoTrans", properties);
        _CornerThreeTrans = ShaderGUI.FindProperty("_CornerThreeTrans", properties);
        _CornerFourTrans = ShaderGUI.FindProperty("_CornerFourTrans", properties);

        //Color gradient settings
        _GradTrans = ShaderGUI.FindProperty("_GradTrans", properties);
        _GradMode = ShaderGUI.FindProperty("_GradMode", properties);
        _GradApply = ShaderGUI.FindProperty("_GradApply", properties);
        _GradOne = ShaderGUI.FindProperty("_GradOne", properties);
        _GradTwo = ShaderGUI.FindProperty("_GradTwo", properties);

        //Darkness settings
        //_ToggleDarken = ShaderGUI.FindProperty("_ToggleDarken", properties);
        _DarknessStrength = ShaderGUI.FindProperty("_DarknessStrength", properties);

        //new distortion settings
        _ToggleDistortion = ShaderGUI.FindProperty("_ToggleDistortion", properties);
        _DistortionMap = ShaderGUI.FindProperty("_DistortionMap", properties);
        _DistortionX = ShaderGUI.FindProperty("_DistortionX", properties);
        _DistortionY = ShaderGUI.FindProperty("_DistortionY", properties);
        _DistortionXSpeed = ShaderGUI.FindProperty("_DistortionXSpeed", properties);
        _DistortionYSpeed = ShaderGUI.FindProperty("_DistortionYSpeed", properties);
        _DistortionRotate  = ShaderGUI.FindProperty("_DistortionRotate", properties);
        _DistortionRotateSpeed  = ShaderGUI.FindProperty("_DistortionRotateSpeed", properties);
        _DistortionTransparency  = ShaderGUI.FindProperty("_DistortionTransparency", properties);

        //Dizzy settings
        _ToggleDizzyEffect = ShaderGUI.FindProperty("_ToggleDizzyEffect", properties);
        _DizzyMode = ShaderGUI.FindProperty("_DizzyMode", properties);
        _DizzyAmountValue = ShaderGUI.FindProperty("_DizzyAmountValue", properties);
        _DizzyRotationSpeed = ShaderGUI.FindProperty("_DizzyRotationSpeed", properties);

        //Droplet settings
        _ToggleDroplet = ShaderGUI.FindProperty("_ToggleDroplet", properties);
        _ToggleDropletSepia = ShaderGUI.FindProperty("_ToggleDropletSepia", properties);
        _DropletColOne = ShaderGUI.FindProperty("_DropletColOne", properties);
        _DropletColTwo = ShaderGUI.FindProperty("_DropletColTwo", properties);
        _DropletTolerance = ShaderGUI.FindProperty("_DropletTolerance", properties);
        _DropletIntensity = ShaderGUI.FindProperty("_DropletIntensity", properties);
        _ToggleDropletTwo = ShaderGUI.FindProperty("_ToggleDropletTwo", properties);
        _TwoDropletColOne = ShaderGUI.FindProperty("_TwoDropletColOne", properties);
        _TwoDropletColTwo = ShaderGUI.FindProperty("_TwoDropletColTwo", properties);
        _TwoDropletTolerance = ShaderGUI.FindProperty("_TwoDropletTolerance", properties);
        _TwoDropletIntensity = ShaderGUI.FindProperty("_TwoDropletIntensity", properties);
        _ToggleDropletThree = ShaderGUI.FindProperty("_ToggleDropletThree", properties);
        _ThreeDropletColOne = ShaderGUI.FindProperty("_ThreeDropletColOne", properties);
        _ThreeDropletColTwo = ShaderGUI.FindProperty("_ThreeDropletColTwo", properties);
        _ThreeDropletTolerance = ShaderGUI.FindProperty("_ThreeDropletTolerance", properties);
        _ThreeDropletIntensity = ShaderGUI.FindProperty("_ThreeDropletIntensity", properties);
        _ToggleDropletFour = ShaderGUI.FindProperty("_ToggleDropletFourth", properties);
        _FourDropletColOne = ShaderGUI.FindProperty("_FourDropletColOne", properties);
        _FourDropletColTwo = ShaderGUI.FindProperty("_FourDropletColTwo", properties);
        _FourDropletTolerance = ShaderGUI.FindProperty("_FourDropletTolerance", properties);
        _FourDropletIntensity = ShaderGUI.FindProperty("_FourDropletIntensity", properties);

        //Duotone settings
        _ToggleDuotone = ShaderGUI.FindProperty("_ToggleDuotone", properties);
        _DuotoneHardness = ShaderGUI.FindProperty("_DuotoneHardness", properties);
        _DuotoneThreshold = ShaderGUI.FindProperty("_DuotoneThreshold", properties);
        _DuotoneColOne = ShaderGUI.FindProperty("_DuotoneColOne", properties);
        _DuotoneColTwo = ShaderGUI.FindProperty("_DuotoneColTwo", properties);

        //Earthquake settings
        _SSAllowVerticalShake = ShaderGUI.FindProperty("_SSAllowVerticalShake", properties);
        _SSAllowHorizontalShake = ShaderGUI.FindProperty("_SSAllowHorizontalShake", properties);
        _SSAllowVerticalBlur = ShaderGUI.FindProperty("_SSAllowVerticalBlur", properties);
        _SSAllowHorizontalBlur = ShaderGUI.FindProperty("_SSAllowHorizontalBlur", properties);
        _SSValue = ShaderGUI.FindProperty("_SSValue", properties);
        _SSSpeed = ShaderGUI.FindProperty("_SSSpeed", properties);
        _SSValueVert = ShaderGUI.FindProperty("_SSValueVert", properties);
        _SSSpeedVert = ShaderGUI.FindProperty("_SSSpeedVert", properties);
        _SSTransparency = ShaderGUI.FindProperty("_SSTransparency", properties);

        //Edge detection settings
        _ToggleED = ShaderGUI.FindProperty("_ToggleED", properties);
        _EDColor = ShaderGUI.FindProperty("_EDColor", properties);
        _EDTolerance = ShaderGUI.FindProperty("_EDTolerance", properties);
        _EDGlow = ShaderGUI.FindProperty("_EDGlow", properties);
        _EDTrans = ShaderGUI.FindProperty("_EDTrans", properties);
        _EDXOffset = ShaderGUI.FindProperty("_EDXOffset", properties);
        _EDYOffset = ShaderGUI.FindProperty("_EDYOffset", properties);
        _EDBW = ShaderGUI.FindProperty("_EDBW", properties);
        _EDToggleRainbow = ShaderGUI.FindProperty("_EDToggleRainbow", properties);
        _EDToggleHSVRainbowX = ShaderGUI.FindProperty("_EDToggleHSVRainbowX", properties);
        _EDToggleHSVRainbowY = ShaderGUI.FindProperty("_EDToggleHSVRainbowY", properties);
        _EDHSVRainbowHue = ShaderGUI.FindProperty("_EDHSVRainbowHue", properties);
        _EDHSVRainbowSat = ShaderGUI.FindProperty("_EDHSVRainbowSat", properties);
        _EDHSVRainbowLight = ShaderGUI.FindProperty("_EDHSVRainbowLight", properties);
        _EDHSVRainbowTime = ShaderGUI.FindProperty("_EDHSVRainbowTime", properties);

        //Edge settings
        _EDWidth = ShaderGUI.FindProperty("_EDWidth", properties);

        //Edge addon settings
        _EDBackPower = ShaderGUI.FindProperty("_EDBackPower", properties);
        _EDBackColor = ShaderGUI.FindProperty("_EDBackColor", properties);
        _EDRampAllow = ShaderGUI.FindProperty("_EDRampAllow", properties);
        _EDRampMap = ShaderGUI.FindProperty("_EDRampMap", properties);
        _EDRampX = ShaderGUI.FindProperty("_EDRampX", properties);
        _EDRampY = ShaderGUI.FindProperty("_EDRampY", properties);
        _EDRampSX = ShaderGUI.FindProperty("_EDRampSX", properties);
        _EDRampSY = ShaderGUI.FindProperty("_EDRampSY", properties);
        _EDRampScroll = ShaderGUI.FindProperty("_EDRampScroll", properties);
        _EDDither = ShaderGUI.FindProperty("_EDDither", properties);
        _EDDitherSpeed = ShaderGUI.FindProperty("_EDDitherSpeed", properties);

        //Edge distort settings
        _ToggleEdgeDistort = ShaderGUI.FindProperty("_ToggleEdgeDistort", properties);
        _EdgeDisX = ShaderGUI.FindProperty("_EdgeDisX", properties);
        _EdgeDisY = ShaderGUI.FindProperty("_EdgeDisY", properties);
        _ToggleEdgeDisRotate = ShaderGUI.FindProperty("_ToggleEdgeDisRotate", properties);
        _EdgeDisRotStr = ShaderGUI.FindProperty("_EdgeDisRotStr", properties);
        _EdgeDisRotSpeed = ShaderGUI.FindProperty("_EdgeDisRotSpeed", properties);

        //Fade settings
        _ToggleFadeProjection = ShaderGUI.FindProperty("_ToggleFadeProjection", properties);
        _FPFade = ShaderGUI.FindProperty("_FPFade", properties);
        _FPZoom = ShaderGUI.FindProperty("_FPZoom", properties);
        _FPColor = ShaderGUI.FindProperty("_FPColor", properties);
        _FadeLayer = ShaderGUI.FindProperty("_FadeLayer", properties);

        //Filter settings
        _ToggleFilter = ShaderGUI.FindProperty("_ToggleFilter", properties);
        _ToggleAdvancedFilter = ShaderGUI.FindProperty("_ToggleAdvancedFilter", properties);
        _ToggleColoredFilter = ShaderGUI.FindProperty("_ToggleColoredFilter", properties);
        _FilterColor = ShaderGUI.FindProperty("_FilterColor", properties);
        _FilterTolerance = ShaderGUI.FindProperty("_FilterTolerance", properties);
        _FilterMinR = ShaderGUI.FindProperty("_FilterMinR", properties);
        _FilterMaxR = ShaderGUI.FindProperty("_FilterMaxR", properties);
        _FilterMinG = ShaderGUI.FindProperty("_FilterMinG", properties);
        _FilterMaxG = ShaderGUI.FindProperty("_FilterMaxG", properties);
        _FilterMinB = ShaderGUI.FindProperty("_FilterMinB", properties);
        _FilterMaxB = ShaderGUI.FindProperty("_FilterMaxB", properties);
        _FilterIntensity = ShaderGUI.FindProperty("_FilterIntensity", properties);
        _BackgroundFilterIntensity = ShaderGUI.FindProperty("_BackgroundFilterIntensity", properties);
        _BackgroundFilterColor = ShaderGUI.FindProperty("_BackgroundFilterColor", properties);
        if (_ToggleAdvancedFilter.floatValue == 1) showFilterAdvanced = true; else showFilterAdvanced = false;
        if (_ToggleColoredFilter.floatValue == 1) showFilterColoredBG = true; else showFilterColoredBG = false;

        //Film settings
        _FilmPower = ShaderGUI.FindProperty("_FilmPower", properties);
        _FilmAllowLines = ShaderGUI.FindProperty("_FilmAllowLines", properties);
        _FilmAllowSpots = ShaderGUI.FindProperty("_FilmAllowSpots", properties);
        _FilmAllowStripes = ShaderGUI.FindProperty("_FilmAllowStripes", properties);
        //_FilmAllowJitter = ShaderGUI.FindProperty("_FilmAllowJitter", properties);
        _FilmItterations = ShaderGUI.FindProperty("_FilmItterations", properties);
        _FilmBrightness = ShaderGUI.FindProperty("_FilmBrightness", properties);
        _FilmJitterAmount = ShaderGUI.FindProperty("_FilmJitterAmount", properties);
        _FilmSpotStrength = ShaderGUI.FindProperty("_FilmSpotStrength", properties);
        _FilmLinesOften = ShaderGUI.FindProperty("_FilmLinesOften", properties);
        _FilmSpotsOften = ShaderGUI.FindProperty("_FilmSpotsOften", properties);
        _FilmStripesOften = ShaderGUI.FindProperty("_FilmStripesOften", properties);
        _ToggleReel = ShaderGUI.FindProperty("_ToggleReel", properties);
        _ReelMode = ShaderGUI.FindProperty("_ReelMode", properties);
        _ReelSpeed = ShaderGUI.FindProperty("_ReelSpeed", properties);
        _ReelColor = ShaderGUI.FindProperty("_ReelColor", properties);
        _ReelBars = ShaderGUI.FindProperty("_ReelBars", properties);
        _ReelWidth = ShaderGUI.FindProperty("_ReelWidth", properties);
        _ReelBarHeigth = ShaderGUI.FindProperty("_ReelBarHeigth", properties);
        _ReelBarAmounts = ShaderGUI.FindProperty("_ReelBarAmounts", properties);
        _ReelJitter = ShaderGUI.FindProperty("_ReelJitter", properties);
        _ReelRainbow = ShaderGUI.FindProperty("_ReelRainbow", properties);
        _ReelRainbowX = ShaderGUI.FindProperty("_ReelRainbowX", properties);
        _ReelRainbowY = ShaderGUI.FindProperty("_ReelRainbowY", properties);

        //fog
        _ToggleFog = ShaderGUI.FindProperty("_ToggleFog", properties);
        _FogDensity = ShaderGUI.FindProperty("_FogDensity", properties);
        _FogColor = ShaderGUI.FindProperty("_FogColor", properties);
        _FogRainbow = ShaderGUI.FindProperty("_FogRainbow", properties);
        _FogRainbowSpeed = ShaderGUI.FindProperty("_FogRainbowSpeed", properties);
        _FogLayer = ShaderGUI.FindProperty("_FogLayer", properties);
        _FogSafe = ShaderGUI.FindProperty("_FogSafe", properties);
        _FogSafeTol = ShaderGUI.FindProperty("_FogSafeTol", properties);

        //Gamma correction settings
        //_ToggleGammaCorrect = ShaderGUI.FindProperty("_ToggleGammaCorrect", properties);
        _GammaRed = ShaderGUI.FindProperty("_GammaRed", properties);
        _GammaGreen = ShaderGUI.FindProperty("_GammaGreen", properties);
        _GammaBlue = ShaderGUI.FindProperty("_GammaBlue", properties);

        //Girlscam settings
        _ToggleGirlscam = ShaderGUI.FindProperty("_ToggleGirlscam", properties);
        _GirlscamStrength = ShaderGUI.FindProperty("_GirlscamStrength", properties);
        _GirlscamTime = ShaderGUI.FindProperty("_GirlscamTime", properties);
        _GirlscamDir = ShaderGUI.FindProperty("_GirlscamDir", properties);

        //Glitch settings
        _ToggleGlitch = ShaderGUI.FindProperty("_ToggleGlitch", properties);
        _GlitchRedMap = ShaderGUI.FindProperty("_GlitchRedMap", properties);
        _GlitchRedDistort = ShaderGUI.FindProperty("_GlitchRedDistort", properties);
        _RedYGlitch = ShaderGUI.FindProperty("_RedYGlitch", properties);
        _RedXGlitch = ShaderGUI.FindProperty("_RedXGlitch", properties);
        _RedTileGlitch = ShaderGUI.FindProperty("_RedTileGlitch", properties);
        _ToggleRandomGlitch = ShaderGUI.FindProperty("_ToggleRandomGlitch", properties);
        _ToggleRandomSideGlitch = ShaderGUI.FindProperty("_ToggleRandomSideGlitch", properties);
        _XGAnimate = ShaderGUI.FindProperty("_XGAnimate", properties);
        _YGAnimate = ShaderGUI.FindProperty("_YGAnimate", properties);
        _TileGAnimate = ShaderGUI.FindProperty("_TileGAnimate", properties);
        _GlitchSideFactor = ShaderGUI.FindProperty("_GlitchSideFactor", properties);
        _ToggleGlitchChromatic = ShaderGUI.FindProperty("_ToggleGlitchChromatic", properties);
        _GlitchRGBStrength = ShaderGUI.FindProperty("_GlitchRGBStrength", properties);
        _GlitchRGBSpeed = ShaderGUI.FindProperty("_GlitchRGBSpeed", properties);
        _GlitchRGB = ShaderGUI.FindProperty("_GlitchRGB", properties);
        if (_ToggleRandomGlitch.floatValue == 1) showGlitchAnimate = true; else showGlitchAnimate = false;
        if (_ToggleRandomSideGlitch.floatValue == 1) showGlitchRandDirection = true; else showGlitchRandDirection = false;
        if (_ToggleGlitchChromatic.floatValue == 1) showGlitchRGB = true; else showGlitchRGB = false;

        //rgb glitch settings
        _ToggleRGBGlitch = ShaderGUI.FindProperty("_ToggleRGBGlitch", properties);
        _RGBBlockMethod = ShaderGUI.FindProperty("_RGBBlockMethod", properties);
        _RedNoiseMap = ShaderGUI.FindProperty("_RedNoiseMap", properties);
        _GreenNoiseMap = ShaderGUI.FindProperty("_GreenNoiseMap", properties);
        _BlueNoiseMap = ShaderGUI.FindProperty("_BlueNoiseMap", properties);
        _RedNoisePower = ShaderGUI.FindProperty("_RedNoisePower", properties);
        _RedNoiseSpeed = ShaderGUI.FindProperty("_RedNoiseSpeed", properties);
        _GreenNoisePower = ShaderGUI.FindProperty("_GreenNoisePower", properties);
        _GreenNoiseSpeed = ShaderGUI.FindProperty("_GreenNoiseSpeed", properties);
        _BlueNoisePower = ShaderGUI.FindProperty("_BlueNoisePower", properties);
        _BlueNoiseSpeed = ShaderGUI.FindProperty("_BlueNoiseSpeed", properties);
        _RedBlocks = ShaderGUI.FindProperty("_RedBlocks", properties);
        _GreenBlocks = ShaderGUI.FindProperty("_GreenBlocks", properties);
        _BlueBlocks = ShaderGUI.FindProperty("_BlueBlocks", properties);
        _RedBlockCount = ShaderGUI.FindProperty("_RedBlockCount", properties);
        _GreenBlockCount = ShaderGUI.FindProperty("_GreenBlockCount", properties);
        _BlueBlockCount = ShaderGUI.FindProperty("_BlueBlockCount", properties);
        _RedBlockSpeed = ShaderGUI.FindProperty("_RedBlockSpeed", properties);
        _GreenBlockSpeed = ShaderGUI.FindProperty("_GreenBlockSpeed", properties);
        _BlueBlockSpeed = ShaderGUI.FindProperty("_BlueBlockSpeed", properties);
        _RGBGlitchTrans = ShaderGUI.FindProperty("_RGBGlitchTrans", properties);

        //Scanline glitch settings
        _ToggleScanline = ShaderGUI.FindProperty("_ToggleScanline", properties);
        _ScanlinePush = ShaderGUI.FindProperty("_ScanlinePush", properties);
        _ScanlineSize = ShaderGUI.FindProperty("_ScanlineSize", properties);
        _ScanlineSpeed = ShaderGUI.FindProperty("_ScanlineSpeed", properties);
        _ScanlineDir = ShaderGUI.FindProperty("_ScanlineDir", properties);

        //Block glitch settings
        _ToggleBlockyGlitch = ShaderGUI.FindProperty("_ToggleBlockyGlitch", properties);
        _BlockGlitchMap = ShaderGUI.FindProperty("_BlockGlitchMap", properties);
        _AllowBGX = ShaderGUI.FindProperty("_AllowBGX", properties);
        _AllowBGY = ShaderGUI.FindProperty("_AllowBGY", properties);
        _BlockyGlitchStrength = ShaderGUI.FindProperty("_BlockyGlitchStrength", properties);
        //_AllowRandomnessIncrease = ShaderGUI.FindProperty("_AllowRandomnessIncrease", properties);
        _BGRandomnessIncrease = ShaderGUI.FindProperty("_BGRandomnessInc", properties);
        _ToggleBlockyRGB = ShaderGUI.FindProperty("_ToggleBlockyRGB", properties);
        _BlockyRGBPush = ShaderGUI.FindProperty("_BlockyRGBPush", properties);
        _BlockyRGBSpeed = ShaderGUI.FindProperty("_BlockyRGBSpeed", properties);
        _AllowBGColors = ShaderGUI.FindProperty("_AllowBGColors", properties);
        _BGOverlayColor = ShaderGUI.FindProperty("_BGOverlayColor", properties);
        _BGOverlayIntensity = ShaderGUI.FindProperty("_BGOverlayIntensity", properties);
        _BGColorIntensity = ShaderGUI.FindProperty("_BGBrokenColorIntensity", properties);
        _BlockyGlitchSpeed = ShaderGUI.FindProperty("_BlockyGlitchSpeed", properties);
        _BDepthX = ShaderGUI.FindProperty("_BDepthX", properties);
        _BDepthY = ShaderGUI.FindProperty("_BDepthY", properties);
        _BGBrokenRandom = ShaderGUI.FindProperty("_BGBrokenRandom", properties);
        _BGOverlayToggle = ShaderGUI.FindProperty("_BGOverlayToggle", properties);
        _BGOverlayMap = ShaderGUI.FindProperty("_BGOverlayMap", properties);

        //Inception settings
        _ToggleInception = ShaderGUI.FindProperty("_ToggleInception", properties);
        _InceptionItterations = ShaderGUI.FindProperty("_InceptionItterations", properties);
        _InceptionSize = ShaderGUI.FindProperty("_InceptionSize", properties);
        _InceptionShiftX = ShaderGUI.FindProperty("_InceptionShiftX", properties);
        _InceptionShiftY = ShaderGUI.FindProperty("_InceptionShiftY", properties);

        //Mirror settings
        _ToggleMirror = ShaderGUI.FindProperty("_ToggleMirror", properties);
        _MirrorHO = ShaderGUI.FindProperty("_MirrorHO", properties);
        _MirrorHU = ShaderGUI.FindProperty("_MirrorHU", properties);
        _MirrorVO = ShaderGUI.FindProperty("_MirrorVO", properties);
        _MirrorVU = ShaderGUI.FindProperty("_MirrorVU", properties);

        //Multiple screen settings
        _ToggleScreens = ShaderGUI.FindProperty("_ToggleScreens", properties);
        _MultiScreenX = ShaderGUI.FindProperty("_ScreensXRow", properties);

        //Noise mask settings
        _ToggleNoiseMask = ShaderGUI.FindProperty("_ToggleNoiseMask", properties);
        _NoiseMask = ShaderGUI.FindProperty("_NoiseMask", properties);
        _NoiseMaskColor = ShaderGUI.FindProperty("_NoiseMaskColor", properties);
        _NoiseMaskSpeedOne = ShaderGUI.FindProperty("_NoiseMaskSpeedOne", properties);
        _NoiseMaskSpeedTwo = ShaderGUI.FindProperty("_NoiseMaskSpeedTwo", properties);
        _NoiseMaskScale = ShaderGUI.FindProperty("_NoiseMaskScale", properties);
        _NoiseMaskGlow = ShaderGUI.FindProperty("_NoiseMaskGlow", properties);

        //Overlay settings
        _ToggleOverlay = ShaderGUI.FindProperty("_ToggleOverlay", properties);
        _UseSepOverlay = ShaderGUI.FindProperty("_UseSepOverlay", properties);
        _OverlayTexture = ShaderGUI.FindProperty("_OverlayTexture", properties);
        _VROverlayTexture = ShaderGUI.FindProperty("_VROverlayTexture", properties);
        _OverlayTransparency = ShaderGUI.FindProperty("_OverlayTransparency", properties);
        _OverlayYAdjust = ShaderGUI.FindProperty("_OverlayYAdjust", properties);
        _OverlayXAdjust = ShaderGUI.FindProperty("_OverlayXAdjust", properties);
        _OverlayTiling = ShaderGUI.FindProperty("_OverlayTiling", properties);
        _OverlayXShift = ShaderGUI.FindProperty("_OverlayXShift", properties);
        _OverlayYShift = ShaderGUI.FindProperty("_OverlayYShift", properties);
        _OverlayTrans = ShaderGUI.FindProperty("_OverlayTrans", properties);
        _OverlayTransX = ShaderGUI.FindProperty("_OverlayTransX", properties);
        _OverlayTransY = ShaderGUI.FindProperty("_OverlayTransY", properties);
        _OvScOne = ShaderGUI.FindProperty("_OvScOne", properties);
        _OvScOneY = ShaderGUI.FindProperty("_OvScOneY", properties);
        _OvScTwo = ShaderGUI.FindProperty("_OvScTwo", properties);
        _OvScTwoY = ShaderGUI.FindProperty("_OvScTwoY", properties);
        _OvScThree = ShaderGUI.FindProperty("_OvScThree", properties);
        _OvScThreeY = ShaderGUI.FindProperty("_OvScThreeY", properties);
        _OvScOneT = ShaderGUI.FindProperty("_OvScOneT", properties);
        _OvScTwoT = ShaderGUI.FindProperty("_OvScTwoT", properties);
        _OvScThreeT = ShaderGUI.FindProperty("_OvScThreeT", properties);
        if (_UseSepOverlay.floatValue == 1) showVRTexture = true; else showVRTexture = false;

        //Overlay two settings
        _ToggleOverlayTwo = ShaderGUI.FindProperty("_ToggleOverlayTwo", properties);
        _OverlayTextureTwo = ShaderGUI.FindProperty("_OverlayTextureTwo", properties);
        _OverlayTransparencyTwo = ShaderGUI.FindProperty("_OverlayTransparencyTwo", properties);
        _OverlayYAdjustTwo = ShaderGUI.FindProperty("_OverlayYAdjustTwo", properties);
        _OverlayXAdjustTwo = ShaderGUI.FindProperty("_OverlayXAdjustTwo", properties);
        _OverlayTilingTwo = ShaderGUI.FindProperty("_OverlayTilingTwo", properties);
        _OverlayXShiftTwo = ShaderGUI.FindProperty("_OverlayXShiftTwo", properties);
        _OverlayYShiftTwo = ShaderGUI.FindProperty("_OverlayYShiftTwo", properties);
        _OverlayTransTwo = ShaderGUI.FindProperty("_OverlayTransTwo", properties);
        _OverlayTransXTwo = ShaderGUI.FindProperty("_OverlayTransXTwo", properties);
        _OverlayTransYTwo = ShaderGUI.FindProperty("_OverlayTransYTwo", properties);

        //Overlay three settings
        _ToggleOverlayThree = ShaderGUI.FindProperty("_ToggleOverlayThree", properties);
        _OverlayTextureThree = ShaderGUI.FindProperty("_OverlayTextureThree", properties);
        _OverlayTransparencyThree = ShaderGUI.FindProperty("_OverlayTransparencyThree", properties);
        _OverlayYAdjustThree = ShaderGUI.FindProperty("_OverlayYAdjustThree", properties);
        _OverlayXAdjustThree = ShaderGUI.FindProperty("_OverlayXAdjustThree", properties);
        _OverlayTilingThree = ShaderGUI.FindProperty("_OverlayTilingThree", properties);
        _OverlayXShiftThree = ShaderGUI.FindProperty("_OverlayXShiftThree", properties);
        _OverlayYShiftThree = ShaderGUI.FindProperty("_OverlayYShiftThree", properties);
        _OverlayTransThree = ShaderGUI.FindProperty("_OverlayTransThree", properties);
        _OverlayTransXThree = ShaderGUI.FindProperty("_OverlayTransXThree", properties);
        _OverlayTransYThree = ShaderGUI.FindProperty("_OverlayTransYThree", properties);

        //Gif settings
        _ToggleGifOverlay = ShaderGUI.FindProperty("_ToggleGifOverlay", properties);
        _OverlaySpritesheet = ShaderGUI.FindProperty("_OverlaySpritesheet", properties);
        _OSSRows = ShaderGUI.FindProperty("_OSSRows", properties);
        _OSSColumns = ShaderGUI.FindProperty("_OSSColumns", properties);
        _OSSSpeed = ShaderGUI.FindProperty("_OSSSpeed", properties);
        _GifTransparency = ShaderGUI.FindProperty("_GifTransparency", properties);
        _GifYAdjust = ShaderGUI.FindProperty("_GifYAdjust", properties);
        _GifXAdjust = ShaderGUI.FindProperty("_GifXAdjust", properties);
        _GifTiling = ShaderGUI.FindProperty("_GifTiling", properties);
        _GifXShift = ShaderGUI.FindProperty("_GifXShift", properties);
        _GifYShift = ShaderGUI.FindProperty("_GifYShift", properties);

        //Transparent image settings
        _ToggleTransparentImage = ShaderGUI.FindProperty("_ToggleTransparentImage", properties);
        _ToggleTransparentImageTwo = ShaderGUI.FindProperty("_ToggleTransparentImageTwo", properties);
        _ToggleTransparentImageThree = ShaderGUI.FindProperty("_ToggleTransparentImageThree", properties);
        _ToggleACTUALTransparentGif = ShaderGUI.FindProperty("_ToggleACTUALTransparentGif", properties);

        //Linocut settings
        _LinocutPower = ShaderGUI.FindProperty("_LinocutPower", properties);
        _LinocutOpacity = ShaderGUI.FindProperty("_LinocutOpacity", properties);
        _LinocutColor = ShaderGUI.FindProperty("_LinocutColor", properties);

        //Outline settings
        _ToggleOutline = ShaderGUI.FindProperty("_ToggleOutline", properties);
        _ToggleSepiaOutline = ShaderGUI.FindProperty("_OutlineSepiaAmount", properties);
        _OutlineOffset = ShaderGUI.FindProperty("_OutlineOffset", properties);
        _OutlineActualOffset = ShaderGUI.FindProperty("_OutlineActualOffset", properties);
        _OutlineModOne = ShaderGUI.FindProperty("_OutlineModOne", properties);
        _OutlineModTwo = ShaderGUI.FindProperty("_OutlineModTwo", properties);
        _OutlineModThree = ShaderGUI.FindProperty("_OutlineModThree", properties);
        _OutlineModFour = ShaderGUI.FindProperty("_OutlineModFour", properties);

        //Rainbow settings
        _ToggleHSVRainbow = ShaderGUI.FindProperty("_ToggleHSVRainbow", properties);
        _ToggleHSVRainbowX = ShaderGUI.FindProperty("_ToggleHSVRainbowX", properties);
        _ToggleHSVRainbowY = ShaderGUI.FindProperty("_ToggleHSVRainbowY", properties);
        _HSVRainbowHue = ShaderGUI.FindProperty("_HSVRainbowHue", properties);
        _HSVRainbowSat = ShaderGUI.FindProperty("_HSVRainbowSat", properties);
        _HSVRainbowLight = ShaderGUI.FindProperty("_HSVRainbowLight", properties);
        _HSVRainbowTime = ShaderGUI.FindProperty("_HSVRainbowTime", properties);

        //Radial blur settings
        _ToggleRadialBlur = ShaderGUI.FindProperty("_ToggleRadialBlur", properties);
        _RadialBlurDistance = ShaderGUI.FindProperty("_RadialBlurDistance", properties);
        _RadialBlurVerticalCenter = ShaderGUI.FindProperty("_RadialBlurVerticalCenter", properties);
        _RadialBlurHorizontalCenter = ShaderGUI.FindProperty("_RadialBlurHorizontalCenter", properties);
        _RBToggleED = ShaderGUI.FindProperty("_RBToggleED", properties);
        _RBEDColor = ShaderGUI.FindProperty("_RBEDColor", properties);
        _RBEDTolerance = ShaderGUI.FindProperty("_RBEDTolerance", properties);
        _RBEDTrans = ShaderGUI.FindProperty("_RBEDTrans", properties);
        _RBEDWidth = ShaderGUI.FindProperty("_RBEDWidth", properties);
        _RBEDBW = ShaderGUI.FindProperty("_RBEDBW", properties);
        _RBEDToggleRainbow = ShaderGUI.FindProperty("_RBEDToggleRainbow", properties);
        _RBEDToggleHSVRainbowX = ShaderGUI.FindProperty("_RBEDToggleHSVRainbowX", properties);
        _RBEDToggleHSVRainbowY = ShaderGUI.FindProperty("_RBEDToggleHSVRainbowY", properties);
        _RBEDHSVRainbowHue = ShaderGUI.FindProperty("_RBEDHSVRainbowHue", properties);
        _RBEDHSVRainbowSat = ShaderGUI.FindProperty("_RBEDHSVRainbowSat", properties);
        _RBEDHSVRainbowLight = ShaderGUI.FindProperty("_RBEDHSVRainbowLight", properties);
        _RBEDHSVRainbowTime = ShaderGUI.FindProperty("_RBEDHSVRainbowTime", properties);
        _RBEDBackPower = ShaderGUI.FindProperty("_RBEDBackPower", properties);
        _RBEDBackColor = ShaderGUI.FindProperty("_RBEDBackColor", properties);
        _RBDither = ShaderGUI.FindProperty("_RBDither", properties);
        _RBDitherSpeed = ShaderGUI.FindProperty("_RBDitherSpeed", properties);
        _RBToggleRainbow = ShaderGUI.FindProperty("_RBToggleRainbow", properties);
        _RBToggleHSVRainbowX = ShaderGUI.FindProperty("_RBToggleHSVRainbowX", properties);
        _RBToggleHSVRainbowY = ShaderGUI.FindProperty("_RBToggleHSVRainbowY", properties);
        _RBHSVRainbowHue = ShaderGUI.FindProperty("_RBHSVRainbowHue", properties);
        _RBHSVRainbowSat = ShaderGUI.FindProperty("_RBHSVRainbowSat", properties);
        _RBHSVRainbowLight = ShaderGUI.FindProperty("_RBHSVRainbowLight", properties);
        _RBHSVRainbowTime = ShaderGUI.FindProperty("_RBHSVRainbowTime", properties);
        _RBRotate = ShaderGUI.FindProperty("_RBRotate", properties);
        _RBRotateSpeed = ShaderGUI.FindProperty("_RBRotateSpeed", properties);
        _RBCAOffset = ShaderGUI.FindProperty("_RBCAOffset", properties);
        _RBCATrans = ShaderGUI.FindProperty("_RBCATrans", properties);
        _RBEmpower = ShaderGUI.FindProperty("_RBEmpower", properties);
        _RBMode = ShaderGUI.FindProperty("_RBMode", properties);
        _RBItterations = ShaderGUI.FindProperty("_RBItterations", properties);
        _RBEDOnly = ShaderGUI.FindProperty("_RBEDOnly", properties);
        _RBEDBalance = ShaderGUI.FindProperty("_RBEDBalance", properties);
        _RBGrainPower = ShaderGUI.FindProperty("_RBGrainPower", properties);
        _RBGrainSpeed = ShaderGUI.FindProperty("_RBGrainSpeed", properties);
        _RBGrainColor = ShaderGUI.FindProperty("_RBGrainColor", properties);
        _RBGrainBlack = ShaderGUI.FindProperty("_RBGrainBlack", properties);

        //Ramp settings
        _ToggleRampEffect = ShaderGUI.FindProperty("_ToggleRampEffect", properties);
        _RampColorChannel = ShaderGUI.FindProperty("_RampColorChannel", properties);
        _RampMap = ShaderGUI.FindProperty("_RampMap", properties);
        _RampOneLighting = ShaderGUI.FindProperty("_RampOneLighting", properties);
        _RampOneDepth = ShaderGUI.FindProperty("_RampOneDepth", properties);
        _RampOneStrength = ShaderGUI.FindProperty("_RampOneStrength", properties);
        _RampOneSpeed = ShaderGUI.FindProperty("_RampOneSpeed", properties);
        _ToggleRampOneAnimate = ShaderGUI.FindProperty("_ToggleRampOneAnimate", properties);

        //Recolor settings
        _ToggleRecolor = ShaderGUI.FindProperty("_ToggleRecolor", properties);
        _RecolorBright = ShaderGUI.FindProperty("_RecolorBright", properties);
        _RecolorSat = ShaderGUI.FindProperty("_RecolorSat", properties);
        _RecolorHue = ShaderGUI.FindProperty("_RecolorHue", properties);
        _RecolorSpeed = ShaderGUI.FindProperty("_RecolorSpeed", properties);
        _ToggleRecolorAnimate = ShaderGUI.FindProperty("_ToggleRecolorAnimate", properties);

        //Rgb settings
        _ToggleRGB = ShaderGUI.FindProperty("_ToggleRGB", properties);
        _ToggleCleanRGB = ShaderGUI.FindProperty("_ToggleCleanRGB", properties);
        _CAMode = ShaderGUI.FindProperty("_CAMode", properties);
        _CASamples = ShaderGUI.FindProperty("_CASamples", properties);
        _CATrans = ShaderGUI.FindProperty("_CATrans", properties);
        _CARotate = ShaderGUI.FindProperty("_CARotate", properties);
        _CARotateSpeed = ShaderGUI.FindProperty("_CARotateSpeed", properties);
        _CAOffsetX = ShaderGUI.FindProperty("_CAOffsetX", properties);
        _CAOffsetY = ShaderGUI.FindProperty("_CAOffsetY", properties);
        _RedXValue = ShaderGUI.FindProperty("_RedXValue", properties);
        _RedYValue = ShaderGUI.FindProperty("_RedYValue", properties);
        _GreenXValue = ShaderGUI.FindProperty("_GreenXValue", properties);
        _GreenYValue = ShaderGUI.FindProperty("_GreenYValue", properties);
        _BlueXValue = ShaderGUI.FindProperty("_BlueXValue", properties);
        _BlueYValue = ShaderGUI.FindProperty("_BlueYValue", properties);
        _ToggleAutoanimate = ShaderGUI.FindProperty("_ToggleAutoanimate", properties);
        _RGBAutoanimateSpeed = ShaderGUI.FindProperty("_RGBAutoanimateSpeed", properties);

        _CAStyle = ShaderGUI.FindProperty("_CAStyle", properties);
        _RotationStrength = ShaderGUI.FindProperty("_RotationStrength", properties);
        _RotationSpeedRed = ShaderGUI.FindProperty("_RotationSpeedRed", properties);
        _RotationSpeedBlue = ShaderGUI.FindProperty("_RotationSpeedBlue", properties);
        _DirectionRed = ShaderGUI.FindProperty("_DirectionRed", properties);
        _DirectionBlue = ShaderGUI.FindProperty("_DirectionBlue", properties);
        _RotationSpeedGreen = ShaderGUI.FindProperty("_RotationSpeedGreen", properties);
        _DirectionGreen = ShaderGUI.FindProperty("_DirectionGreen", properties);
        _ToggleScreenFollow = ShaderGUI.FindProperty("_ToggleScreenFollow", properties);
        _ToggleGreenMove = ShaderGUI.FindProperty("_ToggleGreenMove", properties);

        //Rgb hide settings
        _HideRedTrans = ShaderGUI.FindProperty("_HideRedTrans", properties);
        _HideGreenTrans = ShaderGUI.FindProperty("_HideGreenTrans", properties);
        _HideBlueTrans = ShaderGUI.FindProperty("_HideBlueTrans", properties);

        //Rgb zoom settings
        _ToggleRGBZoom = ShaderGUI.FindProperty("_ToggleRGBZoom", properties);
        _RedZoom = ShaderGUI.FindProperty("_RedZoom", properties);
        _GreenZoom = ShaderGUI.FindProperty("_GreenZoom", properties);
        _BlueZoom = ShaderGUI.FindProperty("_BlueZoom", properties);
        _RGBZoomTrans = ShaderGUI.FindProperty("_RGBZoomTrans", properties);
        _RGBZoomTransG = ShaderGUI.FindProperty("_RGBZoomTransG", properties);
        _RGBZoomTransB = ShaderGUI.FindProperty("_RGBZoomTransB", properties);

        //Ripple settings
        _ToggleRipple = ShaderGUI.FindProperty("_ToggleRipple", properties);
        _ShockCenterX = ShaderGUI.FindProperty("_ShockCenterX", properties);
        _ShockCenterY = ShaderGUI.FindProperty("_ShockCenterY", properties);
        _ShockSpread = ShaderGUI.FindProperty("_ShockSpread", properties);
        _ShockDis = ShaderGUI.FindProperty("_ShockDis", properties);
        _ShockMag = ShaderGUI.FindProperty("_ShockMag", properties);

        //Rotate settings
        _ToggleRotater = ShaderGUI.FindProperty("_ToggleRotater", properties);
        _RotaterValue = ShaderGUI.FindProperty("_RotaterValue", properties);
        _ToggleRotaterAnimate = ShaderGUI.FindProperty("_ToggleRotaterAnimate", properties);
        _RotaterSpin = ShaderGUI.FindProperty("_RotaterSpin", properties);

        //Pixelate settings
        _TogglePixelate = ShaderGUI.FindProperty("_TogglePixelate", properties);
        _PixelateStrength = ShaderGUI.FindProperty("_PixelateStrength", properties);
        _PixelateStrengthY = ShaderGUI.FindProperty("_PixelateStrengthY", properties);

        //Glitchy pixelate settings
        _GTogglePixelate = ShaderGUI.FindProperty("_GTogglePixelate", properties);
        _GPixelStrength = ShaderGUI.FindProperty("_GPixelStrength", properties);
        _GPixelStrengthY = ShaderGUI.FindProperty("_GPixelStrengthY", properties);
        _GPixelFreq = ShaderGUI.FindProperty("_GPixelFreq", properties);
        _GPixelGlitchMap = ShaderGUI.FindProperty("_GPixelGlitchMap", properties);

        //Posterize settings
        _PosterizeValue = ShaderGUI.FindProperty("_PosterizeValue", properties);

        //Saturation settings
        _SaturationValue = ShaderGUI.FindProperty("_SaturationValue", properties);

        //Sepia settings
        _SepiaRStrength = ShaderGUI.FindProperty("_SepiaRStrength", properties);
        _SepiaRWarmth = ShaderGUI.FindProperty("_SepiaRWarmth", properties);
        _SEpiaRTone = ShaderGUI.FindProperty("_SepiaRTone", properties);

        //Contrast settings
        _ContrastValue = ShaderGUI.FindProperty("_ContrastValue", properties);

        //Scroll settings
        _ScrollX = ShaderGUI.FindProperty("_ScrollX", properties);
        _ScrollY = ShaderGUI.FindProperty("_ScrollY", properties);

        //Screenpull settings
        _ToggleScreenpull = ShaderGUI.FindProperty("_ToggleScreenpull", properties);
        _ScreenpullMode = ShaderGUI.FindProperty("_ScreenpullMode", properties);
        _ScreenpullStrength = ShaderGUI.FindProperty("_ScreenpullStrength", properties);
        _ScreenpullStrengthTwo = ShaderGUI.FindProperty("_ScreenpullStrengthTwo", properties);
        _ScreenpullMap = ShaderGUI.FindProperty("_ScreenpullMap", properties);

        //Apart
        _ApartMode = ShaderGUI.FindProperty("_ApartMode", properties);
        _Apart = ShaderGUI.FindProperty("_Apart", properties);
        _ApartColor = ShaderGUI.FindProperty("_ApartColor", properties);

        //Screen zoom settings
        _ToggleScreenZoom = ShaderGUI.FindProperty("_ToggleScreenZoom", properties);
        _ScreenZoomInValue = ShaderGUI.FindProperty("_ScreenZoomInValue", properties);
        _ScreenZoomOutValue = ShaderGUI.FindProperty("_ScreenZoomOutValue", properties);

        //Shake settings
        _ToggleShake = ShaderGUI.FindProperty("_ToggleShake", properties);
        _ShakeModel = ShaderGUI.FindProperty("_ShakeModel", properties);
        _ToggleXYShake = ShaderGUI.FindProperty("_ToggleXYShake", properties);
        _ShakeStrength = ShaderGUI.FindProperty("_ShakeStrength", properties);
        _ShakeSpeed = ShaderGUI.FindProperty("_ShakeSpeed", properties);
        _emptyTex = ShaderGUI.FindProperty("_emptyTex", properties);
        _ShakeStrength2 = ShaderGUI.FindProperty("_ShakeStrength2", properties);
        _ShakeSpeed2 = ShaderGUI.FindProperty("_ShakeSpeed2", properties);
        if (_ToggleXYShake.floatValue == 1) showXYShake = true; else showXYShake = false;

        //Smear settings
        _ToggleSmear = ShaderGUI.FindProperty("_ToggleSmear", properties);
        _CSDirection = ShaderGUI.FindProperty("_CSDirection", properties);
        _CSCopies = ShaderGUI.FindProperty("_CSCopies", properties);
        _CSRed = ShaderGUI.FindProperty("_CSRed", properties);
        _CSGreen = ShaderGUI.FindProperty("_CSGreen", properties);
        _CSBlue = ShaderGUI.FindProperty("_CSBlue", properties);
        _CSAutoRotate = ShaderGUI.FindProperty("_CSAutoRotate", properties);
        _CSRotateSpeed = ShaderGUI.FindProperty("_CSRotateSpeed", properties);
        _CSUseAdvanced = ShaderGUI.FindProperty("_CSUseAdvanced", properties);
        _CSRotateSpeedSinXR = ShaderGUI.FindProperty("_CSRotateSpeedSinXR", properties);
        _CSRotateSpeedCosXR = ShaderGUI.FindProperty("_CSRotateSpeedCosXR", properties);
        _CSRotateSpeedSinYR = ShaderGUI.FindProperty("_CSRotateSpeedSinYR", properties);
        if (_CSAutoRotate.floatValue == 1) showCSAnimate = true; else showCSAnimate = false;
        if (_CSUseAdvanced.floatValue == 1) showCSAdv = true; else showCSAdv = false;


        //Static settings
        _ToggleNoise = ShaderGUI.FindProperty("_ToggleNoise", properties);
        _StaticIntensity = ShaderGUI.FindProperty("_StaticIntensity", properties);
        _ToggleAnimatedNoise = ShaderGUI.FindProperty("_ToggleAnimatedNoise", properties);
        _StaticSpeed = ShaderGUI.FindProperty("_StaticSpeed", properties);
        _StaticSize = ShaderGUI.FindProperty("_StaticSize", properties);
        _StaticColor = ShaderGUI.FindProperty("_StaticColor", properties);
        _StaticBlack = ShaderGUI.FindProperty("_StaticBlack", properties);
        _ToggleStaticMap = ShaderGUI.FindProperty("_ToggleStaticMap", properties);
        _StaticMap = ShaderGUI.FindProperty("_StaticMap", properties);
        _StaticOverlay = ShaderGUI.FindProperty("_StaticOverlay", properties);

        //Swirl settings
        _ToggleSwirl = ShaderGUI.FindProperty("_ToggleSwirl", properties);
        _SwirlPower = ShaderGUI.FindProperty("_SwirlPower", properties);
        _SwirlCenterX = ShaderGUI.FindProperty("_SwirlCenterX", properties);
        _SwirlCenterY = ShaderGUI.FindProperty("_SwirlCenterY", properties);
        _SwirlRadius = ShaderGUI.FindProperty("_SwirlRadius", properties);

        //Splice settings
        _ToggleSplice = ShaderGUI.FindProperty("_ToggleSplice", properties);
        _SpliceTop = ShaderGUI.FindProperty("_SpliceTop", properties);
        _SpliceBot = ShaderGUI.FindProperty("_SpliceBot", properties);
        _SpliceXLimit = ShaderGUI.FindProperty("_SpliceXLimit", properties);
        _SpliceLeft = ShaderGUI.FindProperty("_SpliceLeft", properties);
        _SpliceRight = ShaderGUI.FindProperty("_SpliceRight", properties);
        _SpliceYLimit = ShaderGUI.FindProperty("_SpliceYLimit", properties);

        //Silhouette settings
        _ToggleSilhouette = ShaderGUI.FindProperty("_ToggleSilhouette", properties);
        _SilhouetteDepth = ShaderGUI.FindProperty("_SilhouetteDepth", properties);
        _SilhouetteBack = ShaderGUI.FindProperty("_SilhouetteBack", properties);
        _SilhouetteFront = ShaderGUI.FindProperty("_SilhouetteFront", properties);
        _SilhouetteRainLayer = ShaderGUI.FindProperty("_SilhouetteRainLayer", properties);
        _SilhouetteRainbow = ShaderGUI.FindProperty("_SilhouetteRainbow", properties);
        _SilhouetteRainbowSpeed = ShaderGUI.FindProperty("_SilhouetteRainbowSpeed", properties);
        _SilhouetteLighting = ShaderGUI.FindProperty("_SilhouetteLighting", properties); 
        _SilhouetteLightingMode = ShaderGUI.FindProperty("_SilhouetteLightingMode", properties);

        //Thermal settings
        _ThermalHeat = ShaderGUI.FindProperty("_ThermalHeat", properties);
        _ThermalSensitivity = ShaderGUI.FindProperty("_ThermalSensitivity", properties);
        _ThermalTransparency = ShaderGUI.FindProperty("_ThermalTransparency", properties);
        _ThermalColor = ShaderGUI.FindProperty("_ThermalColor", properties);

        //Transistion settings
        _ToggleTransistion = ShaderGUI.FindProperty("_ToggleTransistion", properties);
        _TransX = ShaderGUI.FindProperty("_TransX", properties);
        _TransY = ShaderGUI.FindProperty("_TransY", properties);
        _ToggleDiagTrans = ShaderGUI.FindProperty("_ToggleDiagTrans", properties);
        _TransDL = ShaderGUI.FindProperty("_TransDL", properties);
        _TransDR = ShaderGUI.FindProperty("_TransDR", properties);

        //Vhs settings 
        _ToggleVHS = ShaderGUI.FindProperty("_ToggleVHS", properties);
        _ToggleSmoothWave = ShaderGUI.FindProperty("_ToggleSmoothWave", properties);
        _VHSXDisplacement = ShaderGUI.FindProperty("_VHSXDisplacement", properties);
        _VHSYDisplacement = ShaderGUI.FindProperty("_VHSYDisplacement", properties);
        _shadowStrength = ShaderGUI.FindProperty("_shadowStrength", properties);
        _darkness = ShaderGUI.FindProperty("_darkness", properties);
        _waveyness = ShaderGUI.FindProperty("_waveyness", properties);

        //Vignette settings
        _ToggleVignette = ShaderGUI.FindProperty("_ToggleVignette", properties);
        _VigX = ShaderGUI.FindProperty("_VigX", properties);
        _VigColor = ShaderGUI.FindProperty("_VigCol", properties);
        _VigColPow = ShaderGUI.FindProperty("_VigColPow", properties);
        _VigMode = ShaderGUI.FindProperty("_VigMode", properties);
        _VigReverse = ShaderGUI.FindProperty("_VigReverse", properties);
        _VigSharpness = ShaderGUI.FindProperty("_VigSharpness", properties);

        //Vibrance settings
        _VibrancePower = ShaderGUI.FindProperty("_VibrancePower", properties);

        //Visualizer settings
        _ToggleVisualizer = ShaderGUI.FindProperty("_ToggleVisualizer", properties);
        _VisBarLeft = ShaderGUI.FindProperty("_VisBarLeft", properties);
        _VisBarRight = ShaderGUI.FindProperty("_VisBarRight", properties);
        _VisBarColor = ShaderGUI.FindProperty("_VisBarColor", properties);
        _VisBaseColor = ShaderGUI.FindProperty("_VisBaseColor", properties);
        _VisBarWidth = ShaderGUI.FindProperty("_VisBarWidth", properties);
        _VisBaseWidth = ShaderGUI.FindProperty("_VisBaseWidth", properties);
        _VisMode = ShaderGUI.FindProperty("_VisMode", properties);
        _VisBarThree = ShaderGUI.FindProperty("_VisBarThree", properties);
        _VisBarFour = ShaderGUI.FindProperty("_VisBarFour", properties);
        _VisBarFive = ShaderGUI.FindProperty("_VisBarFive", properties);
        _VisBarSix = ShaderGUI.FindProperty("_VisBarSix", properties);
        _VisBarSeven = ShaderGUI.FindProperty("_VisBarSeven", properties);
        _VisBarEight = ShaderGUI.FindProperty("_VisBarEight", properties);
        _VisBarNine = ShaderGUI.FindProperty("_VisBarNine", properties);
        _VisBarTen = ShaderGUI.FindProperty("_VisBarTen", properties);
        _VisStopperColor = ShaderGUI.FindProperty("_VisStopperColor", properties);
        _VisCircleSize = ShaderGUI.FindProperty("_VisCircleSize", properties);
        _VisClassicBase = ShaderGUI.FindProperty("_VisClassicBase", properties);
        _VisClassicShape = ShaderGUI.FindProperty("_VisClassicShape", properties);
        _VisBarRainbow = ShaderGUI.FindProperty("_VisBarRainbow", properties);
        _VisClassicMaxSize = ShaderGUI.FindProperty("_VisClassicMaxSize", properties);

        //visualizer rainbow settings
        _ToggleHSVRainbowVis = ShaderGUI.FindProperty("_ToggleHSVRainbowVis", properties);
        _ToggleHSVRainbowXVis = ShaderGUI.FindProperty("_ToggleHSVRainbowXVis", properties);
        _ToggleHSVRainbowYVis = ShaderGUI.FindProperty("_ToggleHSVRainbowYVis", properties);
        _HSVRainbowHueVis = ShaderGUI.FindProperty("_HSVRainbowHueVis", properties);
        _HSVRainbowSatVis = ShaderGUI.FindProperty("_HSVRainbowSatVis", properties);
        _HSVRainbowLightVis = ShaderGUI.FindProperty("_HSVRainbowLightVis", properties);
        _HSVRainbowTimeVis = ShaderGUI.FindProperty("_HSVRainbowTimeVis", properties);

        //Warp settings
        _WarpHorizontal = ShaderGUI.FindProperty("_WarpHorizontal", properties);
        _WarpVertical = ShaderGUI.FindProperty("_WarpVertical", properties);

        //Warp zoom settings
        _ToggleWarpZoom = ShaderGUI.FindProperty("_ToggleWarpZoom", properties);
        _WarpZoomAmount = ShaderGUI.FindProperty("_WarpZoomAmount", properties);
        _WarpZoomTolerance = ShaderGUI.FindProperty("_WarpZoomTolerance", properties);

        //wavey settings
        _ToggleWavey = ShaderGUI.FindProperty("_ToggleWavey", properties);
        _WavesX = ShaderGUI.FindProperty("_WavesX", properties);
        _WavesXPower = ShaderGUI.FindProperty("_WavesXPower", properties);
        _WavesXSpeed = ShaderGUI.FindProperty("_WavesXSpeed", properties);
        _WavesY = ShaderGUI.FindProperty("_WavesY", properties);
        _WavesYPower = ShaderGUI.FindProperty("_WavesYPower", properties);
        _WavesYSpeed = ShaderGUI.FindProperty("_WavesYSpeed", properties);

        //Deepfry settings
        _ToggleDeepfry = ShaderGUI.FindProperty("_ToggleDeepfry", properties);
        _DeepfryValue = ShaderGUI.FindProperty("_DeepfryValue", properties);
        _DeepfryBrightness = ShaderGUI.FindProperty("_DeepfryBrightness", properties);
        _DeepfryEmbossPower = ShaderGUI.FindProperty("_DeepfryEmbossPower", properties);

        //Zoom range settings
        _ToggleZoomRange = ShaderGUI.FindProperty("_ToggleZoomRange", properties);
        _ZoomRange = ShaderGUI.FindProperty("_ZoomRange", properties);
        _ZoomFStart = ShaderGUI.FindProperty("_ZoomFStart", properties);
        _ZoomFEnd = ShaderGUI.FindProperty("_ZoomFEnd", properties);

        //GUI settings
        //_unityThemeColor = ShaderGUI.FindProperty("_unityThemeColor", properties);
        __hideUnusedFX = ShaderGUI.FindProperty("_hideUnusedFX", properties);

    }

    //defining styles 
    private void defineStyles()
    {

        //Dropdown bar style
        dropdownStyle = new GUIStyle(EditorStyles.boldLabel);
        dropdownStyle.alignment = TextAnchor.MiddleCenter;
        dropdownStyle.richText = true;

        //Subdropdown bar style
        subdropdownStyle = new GUIStyle(EditorStyles.label);
        subdropdownStyle.alignment = TextAnchor.MiddleCenter;

        //Property info style
        propInfoStyle = new GUIStyle();
        propInfoStyle.richText = true;
        propInfoStyle.fontSize = 12;
        propInfoStyle.alignment = TextAnchor.MiddleCenter;

        //Property info t i n y style
        propInfoTinyStyle = new GUIStyle();
        propInfoTinyStyle.richText = true;
        propInfoTinyStyle.fontSize = 10;
        propInfoTinyStyle.alignment = TextAnchor.MiddleCenter;

        //Header style
        headernameStyle = new GUIStyle();
        headernameStyle.richText = true;
        headernameStyle.fontSize = 18;
        headernameStyle.alignment = TextAnchor.MiddleCenter;

        //Version style
        versionheaderStyle = new GUIStyle();
        versionheaderStyle.richText = true;
        versionheaderStyle.fontSize = 15;
        versionheaderStyle.alignment = TextAnchor.MiddleCenter;

        //Distribute style
        distributeStyle = new GUIStyle();
        distributeStyle.richText = true;
        distributeStyle.fontSize = 10;
        distributeStyle.alignment = TextAnchor.MiddleCenter;

        //Thank you style
        thankyouStyle = new GUIStyle();
        thankyouStyle.richText = true;
        thankyouStyle.fontSize = 15;
        thankyouStyle.alignment = TextAnchor.MiddleCenter;

        //Love style
        loveStyle = new GUIStyle();
        loveStyle.richText = true;
        loveStyle.fontSize = 12;
        loveStyle.alignment = TextAnchor.MiddleCenter;

        //Help header style
        helpHeaderStyle = new GUIStyle(EditorStyles.boldLabel);
        helpHeaderStyle.richText = true;
        helpHeaderStyle.fontSize = 14;
        helpHeaderStyle.alignment = TextAnchor.MiddleCenter;

        //Help info style
        helpInfoStyle = new GUIStyle();
        helpInfoStyle.richText = true;
        helpInfoStyle.fontSize = 12;
        helpInfoStyle.alignment = TextAnchor.MiddleCenter;

        //Friend special style
        friendStyle = new GUIStyle();
        friendStyle.richText = true;
        friendStyle.fontSize = 12;
        friendStyle.alignment = TextAnchor.MiddleCenter;

        //Fake property style
        fakePropertyStyle = new GUIStyle();
        fakePropertyStyle.richText = true;
        fakePropertyStyle.fontSize = 11;
        fakePropertyStyle.alignment = TextAnchor.MiddleLeft;

        //Section style
        sectionStyle = new GUIStyle();
        sectionStyle.richText = true;
        sectionStyle.fontSize = 16;
        sectionStyle.alignment = TextAnchor.MiddleCenter;

    }

    //properties styles
    private static class propStyles
    {

        //Gui styles
        public static GUIStyle simpleTextStyle = new GUIStyle();
        public static GUIContent DropdownRender = new GUIContent("Render Settings", "Range, and Only Render If Looking");
        public static GUIContent Falloff = new GUIContent("Falloff", "Let effects fade in and out based on range distance.");
        public static GUIContent RenderAtMe = new GUIContent("Only Render At Me", "Only renders effects when looking at you! more wholesome");
        public static GUIContent Depth = new GUIContent("Depth of Field", "Camera focus-like effect for effects.");
        public static GUIContent Tear = new GUIContent("Screen Tear Fix", "Replaces screen tear with a color.");
        public static GUIContent Animate = new GUIContent("Toggle Animation Mode", "Turn this on when animating for easier keyframing! PLEASE USE AND DONT FORGET TO TURN OFF! UWU SORRY");
        public static GUIContent Screenspace = new GUIContent("Screenspace", "Basic screenspace options.");
        public static GUIContent Screencolor = new GUIContent("Screencolor Options", "Invert the screen colors and apply a black and white filter.");
        public static GUIContent Afterimage = new GUIContent("Afterimage", "Adds three motion-blur like copies to the screen");
        public static GUIContent Ascii = new GUIContent("ASCII", "Filters the screen with ascii characters or characters of your choosing.");
        public static GUIContent Apart = new GUIContent("Apart", "Pulls the screen apart.");
        public static GUIContent BlackandWhite = new GUIContent("Black and White", "Removes color from  the screen.");
        public static GUIContent BigBoxZoom = new GUIContent("Middle Zoom", "Zoom but use normal box to use other fx normally.");
        public static GUIContent Blink = new GUIContent("Blink", "Adds bars that close in on the screen.");
        public static GUIContent Blur = new GUIContent("Blurs", "Multiple types of effects that blur the screen.");
        public static GUIContent Bloom = new GUIContent("Exposure", "Adds bloom (exposure, lighting, glow) to the screen.");
        public static GUIContent Bulge = new GUIContent("Bulge", "OwO! Whwats thwiss?");
        public static GUIContent CenteredZoom = new GUIContent("Focus Zoom", "Zooms in the screen if looking at object and follows the object.");
        public static GUIContent CircularShake = new GUIContent("Circular Shake", "Shakes screen in a ...... circular way !");
        public static GUIContent Color = new GUIContent("Color", "Adds a color tint to the screen.");
        public static GUIContent ColorChannels = new GUIContent("Color Channels", "Allows you to replace individual color channel colors.");
        public static GUIContent ColorSplit = new GUIContent("Color Split", "Splits the screen into three colors.");
        public static GUIContent CornerColor = new GUIContent("Color Spin", "Applies different colors to each corner, can be rotated.");
        public static GUIContent Corners = new GUIContent("Corners", "Apply colors to the corners");
        public static GUIContent Darkness = new GUIContent("Darkness", "Darkens the screen.");
        public static GUIContent DivideScreen = new GUIContent("Divide", "Divides the screen into two to four parts.");
        public static GUIContent Distort = new GUIContent("Distortion", "Distorts the screen based on a map.");
        public static GUIContent Dizzy = new GUIContent("Dizzy", "Woah.. I'm feeling dizzy...");
        public static GUIContent Droplet = new GUIContent("Color Droplet", "Replace certain colors with other colors with a photoshop-like tolerance setting.");
        public static GUIContent Duotone = new GUIContent("Duotone", "Duotone: a halftone illustration made from a single original with two different colors at different screen angles.");
        public static GUIContent Earthquake = new GUIContent("Earthquake", "An effect that combines an x and y axis blur with shake.");
        public static GUIContent EdgeDetection = new GUIContent("Colored Outline", "Applies an outline on edges.");
        public static GUIContent EdgeDetectionBackground = new GUIContent("Outline Background", "Applies color to everything that isn't an outline.");
        public static GUIContent EdgeRainbow = new GUIContent("Outline Rainbow", "Makes the outline all rainbowie!");
        public static GUIContent EdgeDetectionRamp = new GUIContent("Outline Gradient", "Gradient color to outline.");
        public static GUIContent EdgeDither = new GUIContent("Outline Dither", "Dithers the outline.");
        public static GUIContent EdgeProjection = new GUIContent("Outline Projection", "Projects an outline lol duhh");
        public static GUIContent EdgeDistort = new GUIContent("Edge Smear", "Smears the screen based on uv's edges.");
        public static GUIContent Edgy = new GUIContent("Negativity Split", "rgb split but edgy OooOoO.");
        public static GUIContent Emboss = new GUIContent("Emboss", "Print-like effect.");
        public static GUIContent Fade = new GUIContent("Fade Projection", "Brings out a faded version of the screen closer.");
        public static GUIContent Filter = new GUIContent("Filter", "Turns the world black and white (or a color) excpet for one color with a specificed tolerance.");
        public static GUIContent Film = new GUIContent("Film", "Applies an old-film artifact filter over the screen with customizable parts.");
        public static GUIContent Fog = new GUIContent("Fog", "i cant see");
        public static GUIContent Fisheye = new GUIContent("Fisheye", "Distorts the screen with a fish eye lens effect and a barrel blur.");
        public static GUIContent Gamma = new GUIContent("Gamma Correction", "Changes the gamma levels of each RGB color.");
        public static GUIContent Gaussian = new GUIContent("Gaussian Blur", "A blur that recreates the effect of unfocusing the screen.");
        public static GUIContent Grid = new GUIContent("Grid", "Creates a slightly animated and customizable grid overlay on the screen.");
        public static GUIContent Glitch = new GUIContent("Glitches (Five Types)", "Distort the screen in a glitch-like way.");
        public static GUIContent Heat = new GUIContent("Heat", "Heat distortion");
        public static GUIContent HorizontalBlur = new GUIContent("Horizontal Blur", "Blurs the horizontal offset of the screen.");
        public static GUIContent Invert = new GUIContent("Invert", "Inverts the colors of the screen.");
        public static GUIContent Inceptions = new GUIContent("Inception", "Put screens on the screen..");
        public static GUIContent Magnitude = new GUIContent("Magnitude", "Shake but random and zoomy.");
        public static GUIContent Mirror = new GUIContent("Mirror", "Mirrors the screen.");
        public static GUIContent MultipleScreen = new GUIContent("Screens", "Allows for the display of multiple screens in a grid-like style.");
        public static GUIContent NoiseMask = new GUIContent("Noise Mask", "Applies a mask of noise over the screen.");
        public static GUIContent Overlay = new GUIContent("Overlay", "Displays a texture over top of the screen. (looks good in vr, yes yes)");
        public static GUIContent GifOverlay = new GUIContent("Gif Overlay", "Displays a gif over top of the screen. (looks good in vr, yes yes)");
        public static GUIContent Linocut = new GUIContent("Linocut", "Based upon a wooden print making technique.");
        public static GUIContent Outline = new GUIContent("Nein Outline", "Renders the world with customizable outlines and colors.");
        public static GUIContent RadialBlur = new GUIContent("Radial Blur", "Blurs around a centered point.");
        public static GUIContent RadialOutline = new GUIContent("Radial Outline", "why do people like this");
        public static GUIContent Rainbow = new GUIContent("Rainbow", "Rainbow-ify the screen! uwu");
        public static GUIContent Ramp = new GUIContent("Ramp", "Combines the world's colors with a ramp map.");
        public static GUIContent Recolor = new GUIContent("Hue Shift", "Recolors the world through HSV cycles.");
        public static GUIContent RGB = new GUIContent("RGB Split", "Recolors the world through HSV cycles.");
        public static GUIContent RGBHide = new GUIContent("RGB Hide", "Like RGB Split but you can hide the color channels.");
        public static GUIContent RGBGrid = new GUIContent("RGB Grid", "Simulates the look of a monitor up close.");
        public static GUIContent RGBZoom = new GUIContent("RGB Zoom", "Zooms in on RGB channels.");
        public static GUIContent RGBGlitch = new GUIContent("RGB Glitch", "brrrr");
        public static GUIContent Ripple = new GUIContent("Ripple", "Displays a customizable ripple on the screen.");
        public static GUIContent Rotate = new GUIContent("Rotate", "Rotates the screeen at a certain angle.");
        public static GUIContent Pixelate = new GUIContent("Pixelate", "Pixelates the screen.");
        public static GUIContent PixelateGlitch = new GUIContent("Pixelate Glitch", "Randomly pixelate the screen.");
        public static GUIContent Posterize = new GUIContent("Posterize", "Converts the screen to only render using a small number of tones.");
        public static GUIContent Projection = new GUIContent("Projection", "Projects copies of the screen.");
        public static GUIContent Saturation = new GUIContent("Saturation", "Controls the saturation of the screen.");
        public static GUIContent Scroll = new GUIContent("Scroll", "Scrolls the screen.");
        public static GUIContent Screensquish = new GUIContent("Screensquish", "Squishes the screen, actual cancer.");
        public static GUIContent Screenpull = new GUIContent("Push", "Pulls the screen in a direction depeneding on the map.");
        public static GUIContent ScreenZoom = new GUIContent("Screen Zoom", "Zooms in the screen at every angle, not on an object.");
        public static GUIContent Screenfreeze = new GUIContent("Screenfreeze", "Freezes the screen.");
        public static GUIContent Shake = new GUIContent("Shake", "Shakes the screen.");
        public static GUIContent Smear = new GUIContent("Smear", "Smears the screen.");
        public static GUIContent Static = new GUIContent("Static", "Adds customizable noise to the screen.");
        public static GUIContent Swirl = new GUIContent("Spiral", "Swirls the screen... duh");
        public static GUIContent Splice = new GUIContent("Split", "Cuts the screen into multiple parts.");
        public static GUIContent Silhouette = new GUIContent("Silhouette", "Makes a silhoeutte.. duh?");
        public static GUIContent Thermal = new GUIContent("Thermal", "Applies a thermal-vision heat like effect to the screen.");
        public static GUIContent Transistion = new GUIContent("Transition", "Moves effects across the screen.");
        public static GUIContent Twist = new GUIContent("Twist", "Warps the screen.");
        public static GUIContent VHS = new GUIContent("VHS", "Applies a VHS-like filter over the screen.");
        public static GUIContent Vignette = new GUIContent("Vignette", "Applys a soft black border around the screen, such as in older films or vhs.");
        public static GUIContent Visualizer = new GUIContent("Visualizer", "Adds bars to screen that you can use to animate to music.");
        public static GUIContent VerticalBlur = new GUIContent("Vertical Blur", "Blurs the y-axis of the screen.");
        public static GUIContent Warp = new GUIContent("Warp", "Warps the screen, like screen pull but smoother.");
        public static GUIContent WarpZoom = new GUIContent("Fisheye Zoom", "Like zoom but W A R P");
        public static GUIContent Wavey = new GUIContent("Wavey", "woooooahhhhh");
        public static GUIContent Deepfry = new GUIContent("Deepfry", "Type any value, 1 to 34, for different deepfry effects.");
        public static GUIContent VR = new GUIContent("VR Adjustments", "Adjust the strength of effects in VR.");
        public static GUIContent UnusedShake = new GUIContent("Deprecated Shake", "(Uses vertex to shake, scuffed) Moves the verts of the object around to move the screen.");
        public static GUIContent AllZooms = new GUIContent("Zooms", "Big Box Zoom, Centered Zoom, Screen Zoom...");
        public static GUIContent AllShakes = new GUIContent("Shake", "BRRRR my screen");
        public static GUIContent AllRGB = new GUIContent("RGB", "All RGB fx go here..");
        public static GUIContent AllDistort = new GUIContent("Distortions", "All distortion fx  go here..");
        public static GUIContent AllRadial = new GUIContent("Radial", "all radial fx go here..");

        //Glitches sub menu
        public static GUIContent BlockGlitch = new GUIContent("Glitch: Block", "Glitches the screen in a traditional rectangle-styled way with broken colors and a blocky rgb.");
        public static GUIContent CRTGlitch = new GUIContent("Glitch: Manual", "Ever seen an old television glitch? No? oh");
        public static GUIContent ChromaticGlitch = new GUIContent("Glitchc: RGB", "Like RGB Split but randomized.");
        public static GUIContent ScanlineGlitch = new GUIContent("Glitch: Scanline", "Scanline going up/down the screen.");
        public static GUIContent StaticGlitch = new GUIContent("Glitch: Static", "SCreen glitch but a whole mess of things.");

        //Render settings
        public static GUIContent RangeStyle = new GUIContent("Range", "How many meters the object is visible for.");
        public static GUIContent LookAtMeStyle = new GUIContent("Only Render If Looking", "Only displays the effect if the user is looking at the (small) mesh.");
        public static GUIContent ZTestStyle = new GUIContent("ZTest", "Controls the rendering priority. (Always = Always Over Render)");
        public static GUIContent AllowSmartFalloffStyle = new GUIContent("Allow Falloff", "Effects will fade out/in rather than suddenly stop/appear.");
        public static GUIContent SmartFalloffMinStyle = new GUIContent("Start Falloff Range", "The range where the effect begans to fade out.");
        public static GUIContent SmartFalloffMaxStyle = new GUIContent("End Falloff Range", "The range where the effect is completely faded out. (should be more than start)");
        public static GUIContent AllowFadingFalloffStyle = new GUIContent("Allow Fading Falloff", "(applies to some fx) Effects will fade out, should prolly keep this on.");
        public static GUIContent AllowScalarFalloffStyle = new GUIContent("Allow Scalar Falloff", "(applies to some fx) Effects' strength will lessen, should prolly keep this on.");

        //Depth settings
        public static GUIContent AllowDepthTestStyle = new GUIContent("Allow Depth of Field", "Camera focus-like effect for effects.");
        public static GUIContent DepthValueStyle = new GUIContent("Focus Distance", "Controls how far away things should be in focus or out of focus.");

        //Screenspace settings
        public static GUIContent ToggleSepiaStyle = new GUIContent("Allow Black and White", "Converts the colors of the screen to greyscale.");
        public static GUIContent ToggleInvertStyle = new GUIContent("Allow Invert", "Inverts the colors of the screen.");
        public static GUIContent SepiaStrengthStyle = new GUIContent("B&W Strength", "Controls how black and white the screen should be.");
        public static GUIContent InvertStrengthStyle = new GUIContent("Invert Strength", "Controls how much the screen should be inverted.");
        public static GUIContent ToggleScreenFlipStyle = new GUIContent("Screen Flip Power", "Flips the screen (inverts controls).");
        public static GUIContent ToggleUpsideDown = new GUIContent("Upside Down Power", "Turns the screen upside down.");

        //Afterimage settings
        public static GUIContent ToggleAfterimageStyle = new GUIContent("Allow Afterimage", "Adds three motion-blur like copies to the screen.");
        public static GUIContent OffsetStyle = new GUIContent("First Offset", "Placement of the first copy.");
        public static GUIContent ExtraOffsetStyle = new GUIContent("Second Offset", "Placement of the second copy.");
        public static GUIContent OffsetThreeStyle = new GUIContent("Third Offset", "Placement of the third copy.");

        //Ascii settings
        public static GUIContent ToggleAsciiStyle = new GUIContent("Allow ASCII", "Filters the screen with ascii characters or characters of your choosing.");
        public static GUIContent ASCIIVariationStyle = new GUIContent("Character Variation", "The variation of characters on the screen.");
        public static GUIContent ASCIIPowerStyle = new GUIContent("Character Amount", "The amount of characters on the screen.");

        //Blink settings
        public static GUIContent BlinkStrengthStyle = new GUIContent("Blink Strength", "How far the bars should move in on the screen.");
        public static GUIContent BlinkColorStyle = new GUIContent("Blink Color", "The color of the bars.");

        //Blur settings
        public static GUIContent ToggleBlurStyle = new GUIContent("Allow Blur", "Blurs the screen.");
        public static GUIContent ToggleSimpleBlurStyle = new GUIContent("Smoothen Blur", "Smoothens the blur when the user is moving, please use this lol.");
        public static GUIContent BlurNondistanceOffsetStyle = new GUIContent("Smoothness Factor", "Calculated in the blur's equation to help determine the strength w/ smoothness.");
        public static GUIContent BlurOffsetStyle = new GUIContent("Blur Offset", "Strength of the blur.");
        public static GUIContent ToggleAutoanimateBlurStyle = new GUIContent("Animate Blur", "Animates the strength of the blur automatically.");
        public static GUIContent BlurAutoanimteSpeed = new GUIContent("Blur Speed", "Speed of the blur's animation.");

        //Bloom // exposure settings
        public static GUIContent ToggleBloomStyle = new GUIContent("Allow Bloom", "Adds bloom (exposure, lighting, glow) to the screen.");
        public static GUIContent BloomGlowStyle = new GUIContent("Exposure", "The level of exposure that should be applied to the screen.");
        public static GUIContent BloomGlowRGBStyle = new GUIContent("Exposure Color", "Color of exposure.");

        //Bulge settings
        public static GUIContent ToggleBulgeStyle = new GUIContent("Bulge Zoom", "OwO! Whwats thwiss?");
        public static GUIContent OwOStrengthStyle = new GUIContent("Bulge Warp", "OwO Meter: 110%");

        //Centered zoom settings
        public static GUIContent ToggleZoomStyle = new GUIContent("Allow Focus Zoom", "Zooms in the screen if looking at object and follows the object.");
        public static GUIContent ToggleFlipZoomStyle = new GUIContent("Flip Zoom", "Flips the zoom upside down.");
        public static GUIContent ZoomInValueStyle = new GUIContent("Zoom In", "How much the screen should be zoomed in on the object.");
        public static GUIContent ZoomOutValueStyle = new GUIContent("Zoom Out", "How much the screen should be zoomed out of the object, a bit scuffed cause screentear.");
        public static GUIContent ToggleSmoothZoomStyle = new GUIContent("Smoothen Zoom", "Changes zoom amount based off of angle and ONLY ZOOM IN FROM FRONT.");
        public static GUIContent ToggleSmoothAdvancedStyle = new GUIContent("Customize Smoothen", "Change the constraits and math for the angle smoothen. [FOR ADVANCED USERS MOSTLY]");
        public static GUIContent SmoothZoomClampMinONEStyle = new GUIContent("Smooth Maximum", "The maximum zoom in point, aka how much it will be zoomed in when directly looking.");
        public static GUIContent SmoothZoomClampMaxONEStyle = new GUIContent("Smooth Minimum", "The minimum zoom in point, aka how much it wont be zoomed in when not looking.");
        public static GUIContent SmoothZoomDistanceModStyle = new GUIContent("Distance Modifier", "How much distance factors into the zoom.");

        //Circulur blur settings
        public static GUIContent ToggleCircularBlurStyle = new GUIContent("Allow Circular Blur?", "Blurs the screen in a circle.");
        public static GUIContent CircleBlurOffsetStyle = new GUIContent("Blur Strength", "The offset of the circuluar blur copies.");

        //Circular shake settings
        public static GUIContent ToggleCircularShakeStyle = new GUIContent("Allow Circular Shake", "Shakes the screen in a ..... circular way !");
        public static GUIContent CircShakeSpeedStyle = new GUIContent("Circular Shake Speed", "How fast the screen should shake. (in a circular way!)");
        public static GUIContent CircShakeStrStyle = new GUIContent("Circular Shake Strength", "How strong the screen should shake. (in a circular way!)");

        //Color settings
        public static GUIContent ToggleColorTintStyle = new GUIContent("Allow Color", "Adds a color tint to the screen.");
        public static GUIContent ColorHueStyle = new GUIContent("Hue", "Change the HSV Hue");
        public static GUIContent ColorSaturationStyle = new GUIContent("Saturation", "Change the HSV Saturation");
        public static GUIContent ColorValueStyle = new GUIContent("Value", "Change the HSV Value");
        public static GUIContent ToggleRGBTintStyle = new GUIContent("Use RGB (HDR) Color", "Use the color droplet picker instead of three sliders.");
        public static GUIContent ColorRGBStyle = new GUIContent("RGB Color Droplet", "Choose a color for the RGB option here. (duh)");

        //Color split settings
        public static GUIContent ToggleColorSplitStyle = new GUIContent("Allow Color Split", "Splits the screen into three colors.");
        public static GUIContent ColorSplitAmountStyle = new GUIContent("Color Split Strength", "How far apart the colors should be split by.");
        public static GUIContent ColorSplitRGBoneStyle = new GUIContent("Left Color", "Chooses the color of the left color being split.");
        public static GUIContent ColorSplitRGBtwoStyle = new GUIContent("Middle Color", "Chooses the color of the middle color being split.");
        public static GUIContent ColorSplitRGBthreeStyle = new GUIContent("Right Color", "Chooses the color of the right color being split.");
        public static GUIContent ColSpONEopacityStyle = new GUIContent("Left Visbility", "Visibility of the left color.");
        public static GUIContent ColSpTWOopacityStyle = new GUIContent("Middle Visibility", "Visiblity of the middle color.");
        public static GUIContent ColSpTHREEopacityStyle = new GUIContent("Right Visibility", "Visibility of the right color.");
        public static GUIContent ToggleColorSplitStaySidesStyle = new GUIContent("Colors Dont Cross", "When animated, the sides being color split will stay on their sides and not switch.");
        public static GUIContent ToggleAutoanimateColorSplitStyle = new GUIContent("Animate Color Split (null)", "Automatically move the sides of the color split.");
        public static GUIContent ColorSplitSpeedStyle = new GUIContent("Color Split Speed", "The speed of the color split's animation.");
        public static GUIContent CSLXStyle = new GUIContent("Left Horizontal Offset", "X-axis offset of the left color split.");
        public static GUIContent CSLYStyle = new GUIContent("Left Vertical Offset", "Y-axis offset of the left color split.");
        public static GUIContent CSMXStyle = new GUIContent("Middle Horizontal Offset", "X-axis offset of the middle color split.");
        public static GUIContent CSMYStyle = new GUIContent("Middle Vertical Offset", "Y-axis offset of the middle color split.");
        public static GUIContent CSRXStyle = new GUIContent("Right Horizontal Offset", "X-axis offset of the right color split.");
        public static GUIContent CSRYStyle = new GUIContent("Right Vertical Offset", "Y-axis offset of the right color split.");

        //Darkness settings
        public static GUIContent ToggleDarknessStyle = new GUIContent("Allow Darkness", "Darkens the screen.");
        public static GUIContent DarknessStrengthStyle = new GUIContent("Darkness", "Controls how dark the screen is.");

        //Divide settings
        public static GUIContent ToggleDividestyle = new GUIContent("Divide", "Divides the screen into two to four parts.");
        public static GUIContent DivideLStyle = new GUIContent("Left Division", "Controls the placement of the left division.");
        public static GUIContent DivideRStyle = new GUIContent("Right Division", "Controls the placement of the right division.");

        //Distort settings
        public static GUIContent ToggleDistortStyle = new GUIContent("Allow Distortion", "Distorts the screen based on a distortion map.");
        public static GUIContent RedMapStyle = new GUIContent("Distortion Map", "Map (texture) that will be used to distort the screen.");
        public static GUIContent ToggleDistortAnimateStyle = new GUIContent("Animate Distortion", "Automatically move the distortion around the screen.");
        public static GUIContent ToggleDistortAdvControlStyle = new GUIContent("Use Animate Controls Manually", "Use the animation modifiers without actually animating the screen automatically.");
        public static GUIContent DistortAmountStyle = new GUIContent("Amount", "Strength of the distortion.");
        public static GUIContent DistortOffsetStyle = new GUIContent("Offset", "Adjust how much the distortion pushes the screen (NOT distorts the screen, that is strength). Use this to make the screen be distorted but not be pushed to the side a lot.");
        public static GUIContent DistortRedSpeedStyle = new GUIContent("Speed", "The speed of the animated distortion.");
        public static GUIContent DistortYAnimStyle = new GUIContent("Y Modifier", "Y axis modifier for animation/advanced controls.");
        public static GUIContent DistortXAnimStyle = new GUIContent("X Modifier", "X axis modifier for animation/advanced controls.");
        public static GUIContent DistortTileAnimStyle = new GUIContent("Scale Modifier", "Tile modifier for animation/advanced controls.");
        public static GUIContent DistortFadeStyle = new GUIContent("Fade Amount", "Controls how much the distorted screen is visible over the normal screen.");

        //Dizzy settings
        public static GUIContent ToggleDizzyEffectStyle = new GUIContent("Allow Dizzy", "Woah.. I'm feeling dizzy...");
        public static GUIContent DizzyModeStyle = new GUIContent("Dizzy Mode", "Changes the math that controls the dizzy effect.");
        public static GUIContent DizzyAmountValueStyle = new GUIContent("Dizzy Speed", "Controls the speed of the dizzy effect.");
        public static GUIContent DizzyRotationSpeedStyle = new GUIContent("Dizzy Strength", "Controls the rotation strength of the dizzy effect.");
        public static GUIContent DizzyDirectionStyle = new GUIContent("DIzzy Direction", "Controls the direction of the dizzy effect.");

        //Droplet settings
        public static GUIContent ToggleDropletStyle = new GUIContent("Allow Color Droplet", "Replace certain colors with other colors with a photoshop-like tolerance setting.");
        public static GUIContent ToggleUseHSVInsteadStyle = new GUIContent("Use HSV Instead (Currently Using: Null)", "Changes the method of filtering colors from HSV to RGB.");
        public static GUIContent ToggleDropletSepiaStyle = new GUIContent("Black White Background Strength", "Turns all colors that aren't replaced to black and white.");
        public static GUIContent DropletColOneStyle = new GUIContent("Old Color", "The color to replace.");
        public static GUIContent DropletColTwoStyle = new GUIContent("New Color", "The color to replace with.");
        public static GUIContent DropletToleranceStyle = new GUIContent("Tolerance", "Photoshop-like tolerance level for the old color to be replaced. (higher = wider range of colors for replacement)");
        public static GUIContent DropletIntensityStyle = new GUIContent("Intensity", "Intensity of the new color.");
        public static GUIContent ToggleDropletTwoStyle = new GUIContent("Allow Second Color", "Allow another color to be replaced.");
        public static GUIContent TwoDropletColOneStyle = new GUIContent("Old Color", "The color to replace.");
        public static GUIContent TwoDropletColTwoStyle = new GUIContent("New Color", "The color to replace with.");
        public static GUIContent TwoDropletToleranceStyle = new GUIContent("Tolerance", "Photoshop-like tolerance level for the old color to be replaced. (higher = wider range of colors for replacement)");
        public static GUIContent TwoDropletIntensityStyle = new GUIContent("Intensity", "Intensity of the new color.");
        public static GUIContent ToggleDropletThreeStyle = new GUIContent("Allow Third Color", "Allow another color to be replaced.");
        public static GUIContent ThreeDropletColOneStyle = new GUIContent("Old Color", "The color to replace.");
        public static GUIContent ThreeDropletColTwoStyle = new GUIContent("New Color", "The color to replace with.");
        public static GUIContent ThreeDropletToleranceStyle = new GUIContent("Tolerance", "Photoshop-like tolerance level for the old color to be replaced. (higher = wider range of colors for replacement)");
        public static GUIContent ThreeDropletIntensityStyle = new GUIContent("Intensity", "Intensity of the new color.");
        public static GUIContent ToggleDropletFourStyle = new GUIContent("Allow Fourth Color", "Allow another color to be replaced.");
        public static GUIContent FourDropletColOneStyle = new GUIContent("Old Color", "The color to replace.");
        public static GUIContent FourDropletColTwoStyle = new GUIContent("New Color", "The color to replace with.");
        public static GUIContent FourDropletToleranceStyle = new GUIContent("Tolerance", "Photoshop-like tolerance level for the old color to be replaced. (higher = wider range of colors for replacement)");
        public static GUIContent FourDropletIntensityStyle = new GUIContent("Intensity", "Intensity of the new color.");

        //Duotone settings
        public static GUIContent ToggleDuotoneStyle = new GUIContent("Allow Duotone", "Duotone: a halftone illustration made from a single original with two different colors at different screen angles.");
        public static GUIContent DuotoneHardEdgesStyle = new GUIContent("Hard Edges Only?", "Means only one color the other.");
        public static GUIContent DuotoneHardnessStyle = new GUIContent("Duotone Hardness", "Controls the hardness/edges");
        public static GUIContent DuotoneThresholdStyle = new GUIContent("Duotone Threshold", "Tolerance level of what colors should be what. Best to just play with it.");
        public static GUIContent DuotoneColOneStyle = new GUIContent("Color One", "First color to be used in the duotone algorithm.");
        public static GUIContent DuotoneColTwoStyle = new GUIContent("Color Two", "Second color to be used in the duotone algorithm.");

        //Earthquake settings
        public static GUIContent ToggleSplitShakeStyle = new GUIContent("Allow Earthquake", "An effect that combines blur with shake.");
        public static GUIContent SSAllowVerticalShakeStyle = new GUIContent("Vertical Shake", "Shakes on the y axis.");
        public static GUIContent SSAllowHorizontalShakeStyle = new GUIContent("Horizontal Shake", "Shakes on the x axis.");
        public static GUIContent SSAllowVerticalBlurStyle = new GUIContent("Vertical Motion Blur", "Blurs on the y axis.");
        public static GUIContent SSAllowHorizontalBlurStyle = new GUIContent("Horizontal Motion Blur", "Blurs on the x axis.");
        public static GUIContent SSValueStyle = new GUIContent("Horizontal Shakiness", "Controls the shakiness on the x axis.");
        public static GUIContent SSSpeedStyle = new GUIContent("Horizontal Speed", "Controls the speed on the x axis.");
        public static GUIContent SSValueVertStyle = new GUIContent("Vertical Shakiness", "Controls the shakiness on the y axis.");
        public static GUIContent SSSpeedVertStyle = new GUIContent("Vertical Speed", "Controls the motion blur on the y axis.");
        public static GUIContent SSTransparencyStyle = new GUIContent("Blur Transparency", "Controls the transparency of the bluring afterimage effect.");

        //Edge detection settings
        public static GUIContent AllOutlines = new GUIContent("Outlines", "All outline fx are in here!");
        public static GUIContent ToggleEdgeDetection = new GUIContent("Allow Colored Outline", "Applies an outline on edges.");
        public static GUIContent EDColorStyle = new GUIContent("Outline Color", "Color of the outline.");
        public static GUIContent EDIntensityStyle = new GUIContent("Outline Intensity", "How strong the outline should be.");
        public static GUIContent EDToleranceStyle = new GUIContent("Outline Tolerance", "How much should be outlined.");
        public static GUIContent EDGlowStyle = new GUIContent("Outline Glow", "Glow of the outline.");
        public static GUIContent EDTransStyle = new GUIContent("Outline Transparency", "The transparency of the outline.");
        public static GUIContent EDXOffsetStyle = new GUIContent("Horizontal Offset", "X axis offset of the outline.");
        public static GUIContent EDYOffsetStyle = new GUIContent("Vertical Offset", "Y axis offset of the outline.");

        //Edge distort settings
        public static GUIContent ToggleEdgeDistortStyle = new GUIContent("Allow Edge Smear", "Smears the screen based on uv's edges.");
        public static GUIContent EdgeDisXStyle = new GUIContent("Horizontal Smear", "Controls the smear on the screen's x axis.");
        public static GUIContent EdgeDisYStyle = new GUIContent("Vertical Smear", "Controls the smear on the screen's y axis.");
        public static GUIContent ToggleEdgeDisRotateStyle = new GUIContent("Allow Rotation", "Automatically rotates the smear.");
        public static GUIContent EdgeDisRotStrStyle = new GUIContent("Rotation Strength", "How strong should the rotation be?");
        public static GUIContent EdgeDisRotSpeedStyle = new GUIContent("Rotation Speed", "How fast should the rotation be?");

        //Edgy settings
        public static GUIContent ToggleEdgyStyle = new GUIContent("Allow Edgy World", "RGB-Split like edgy neon setting.");
        public static GUIContent EdgyOffsetStyle = new GUIContent("Edgy Offset", "Offset of the first edgy copy.");
        public static GUIContent EdgyOffsetTwoStyle = new GUIContent("Edgy Two Offset", "Offset of the second edgy copy.");
        public static GUIContent EdgyMultiStyle = new GUIContent("Edgy Value", "Value that the edgy world colors is multiplied by, prolly just leave alone.");

        //Emboss settings
        public static GUIContent ToggleEmbossStyle = new GUIContent("Allow Emboss", "Print-like effect.");
        public static GUIContent EmbossCoverageStyle = new GUIContent("Emboss Coverage", "How much of the screen should be embossed.");
        public static GUIContent EmbossWidthStyle = new GUIContent("Emboss Width", "Controls the width of the lines of the emboss.");
        public static GUIContent EmbossBrightStyle = new GUIContent("Emboss Light", "Brightness of the emboss.");

        //Fade settings
        public static GUIContent FadeStyle = new GUIContent("Allow Fade Projection", "Brings out a faded version of the screen closer.");
        public static GUIContent FPFadeStyle = new GUIContent("Projection Transparency", "Controls the actual 'fade' variable.");
        public static GUIContent FPZoomStyle = new GUIContent("Projection Zoom", "Controls how close it is to the screen (or rather appears to be).");

        //Filter settings
        public static GUIContent ToggleFilterStyle = new GUIContent("Allow Filter", "Turns the world black and white (or a color) excpet for one color with a specificed tolerance.");
        public static GUIContent ToggleAdvancedFilterStyle = new GUIContent("Use Advanced Options (Null)", "Allows more control over the color being filtered.");
        public static GUIContent ToggleColoredFilterStyle = new GUIContent("Allow Colored Background", "Instead of turning everything else black and white, turns it to a color with a specificed intensity.");
        public static GUIContent FilterColorStyle = new GUIContent("Filtered Color", "Color to allow through the black and white.");
        public static GUIContent FilterToleranceStyle = new GUIContent("Filter Tolerance", "Photoshop-like tolerance level for the old color to be replaced. (higher = wider range of colors to allow through)");
        public static GUIContent _FilterMinRStyle = new GUIContent("Minimum Red Filter Level", "Minimum red in RGB or HSV to be converted.");
        public static GUIContent _FilterMaxRStyle = new GUIContent("Maximum Red Filter Level", "Maximum red in RGB or HSV to be converted.");
        public static GUIContent _FilterMinGStyle = new GUIContent("Minimum Green Filter Level", "Minimum red in RGB or HSV to be converted.");
        public static GUIContent _FilterMaxGStyle = new GUIContent("Maximum Green Filter Level", "Maximum red in RGB or HSV to be converted.");
        public static GUIContent _FilterMinBStyle = new GUIContent("Minimum Blue Filter Level", "Minimum red in RGB or HSV to be converted.");
        public static GUIContent _FilterMaxBStyle = new GUIContent("Maximum Blue Filter Level", "Maximum red in RGB or HSV to be converted.");
        public static GUIContent _FilterIntensityStyle = new GUIContent("Color Strength", "Intensity of the new color to be replaced.");
        public static GUIContent _BackgroundFilterIntensityStyle = new GUIContent("Background Color Strength", "Intensity of the background's new color");
        public static GUIContent _BackgroundFilterColorStyle = new GUIContent("Background Color", "Color to swap the background to");

        //Film settings
        public static GUIContent ToggleFilmStyles = new GUIContent("Allow Film", "Applies an old-film artifact filter over the screen with customizable parts.");
        public static GUIContent FilmAllowLinesStyle = new GUIContent("Allow Line Artifacts", "Applies line artifacts to the screen.");
        public static GUIContent FilmAllowSpotsStyle = new GUIContent("Allow Spot Artifacts", "Applies blotch artifacts to the screen.");
        public static GUIContent FilmAllowStripesStyle = new GUIContent("Allow Striped Artifacts", "Like line artifacts but smaller and more frequent.");
        public static GUIContent FilmItterationsStyle = new GUIContent("Artifact Update Rate", "How often the artifacts should be updated.");
        public static GUIContent FilmBrightnessStyle = new GUIContent("Flash Brightness", "Brightness of the film filter.");
        public static GUIContent FilmJitterAmountStyle = new GUIContent("Jitter Strength", "Strength of shake effect.");
        public static GUIContent FilmSpotStrengthStyle = new GUIContent("Spot Size", "How large the blotch artifacts should be.");
        public static GUIContent FilmLinesOftenStyle = new GUIContent("Line Frequency", "How often the line artifacts should appear.");
        public static GUIContent FilmSpotsOftenStyle = new GUIContent("Spot Frequency", "How often the spots should appear on the screen.");
        public static GUIContent FilmStripesOftenStyle = new GUIContent("Stripes Frequency", "How often the stripes should appear on the screen.");

        //Fisheye settings
        public static GUIContent ToggleFisheyeStyle = new GUIContent("Allow Fisheye", "Distorts the screen with a fish eye lens effect and a barrel blur.");
        public static GUIContent FisheyeSizeStyle = new GUIContent("Fisheye Size", "Controls the size of the fish eye lens.");

        //Gamma correction settings
        public static GUIContent ToggleGammaStyle = new GUIContent("Allow Gamma Correction", "Changes the gamma levels of each RGB color.");
        public static GUIContent GammaRedStyle = new GUIContent("Red Gamma", "Changes the gamma levels of the red color.");
        public static GUIContent GammaGreenStyle = new GUIContent("Green Gamma", "Changes the gamma levels of each green color.");
        public static GUIContent GammaBlueStyle = new GUIContent("Blue Gamma", "Changes the gamma levels of each blue color.");

        //Gaussian blur settings
        public static GUIContent ToggleUnfocusBlurStyle = new GUIContent("Allow Gaussian Blur", "A blur that recreates the effect of unfocusing the screen.");
        public static GUIContent UnfocusBlurOffsetStyle = new GUIContent("Unfocus Strength", "The strength of the blur.");

        //Girlscam settings
        public static GUIContent ToggleGirlscamStyle = new GUIContent("Allow Girlscam?", "Screen distortion that breaks the screen into lines. Originally made by liuhaidong.");
        public static GUIContent GirlscamStrengthStyle = new GUIContent("Strength", "How much the distortion should push the screen.");
        public static GUIContent GirlscamDriftStyle = new GUIContent("Color Drift", "How much the colors should be pushed on the edges of the screen.");
        public static GUIContent GirlscamTimeStyle = new GUIContent("Speed", "Time factor of the distortion.");

        //Glitch settings
        public static GUIContent ToggleGlitchStyle = new GUIContent("Allow Manual Glitch", "Distorts the screen in a glitch-like way using a glitch map.");
        public static GUIContent GlitchRedMapStyle = new GUIContent("Glitch Map", "Map (texture) that determines how the screen will be distorted.");
        public static GUIContent GlitchRedDistortStyle = new GUIContent("Glitch Strength", "How much the screen will be pushed by the glitch map.");
        public static GUIContent RedYGlitchStyle = new GUIContent("Vertical Glitch", "Glitch strength of the Y-Axis.");
        public static GUIContent RedXGlitchStyle = new GUIContent("Horizontal Glitch", "Glitch strength of the X-Axis.");
        public static GUIContent RedTileGlitchStyle = new GUIContent("Scroll Glitch Map", "Scrolls the glitch map across the screen.");
        public static GUIContent ToggleRandomGlitchStyle = new GUIContent("Animate Glitch (null)", "[Still expiremental] Automatically animates the glitch map and values.");
        public static GUIContent ToggleRandomSideGlitchStyle = new GUIContent("Randomize Glitch Direction (null)", "Allows the glitch to randomly move in different directions.");
        public static GUIContent XGAnimateStyle = new GUIContent("Horizontal Glitch", "Determines the factor in the animation in the X-Axis.");
        public static GUIContent YGAnimateStyle = new GUIContent("Vertical Glitch", "Determines the factor in the animation in the Y-Axis.");
        public static GUIContent TileGAnimateStyle = new GUIContent("Speed", "Determines the factor in the animation in the scaling of the map");
        public static GUIContent GlitchSideFactorStyle = new GUIContent("Randomize Chance", "Higher = more randomization in the direction.");
        public static GUIContent ToggleGlitchChromaticStyle = new GUIContent("Allow Glitch RGB", "Randomly enables a customizable chromatic abberation effect.");
        public static GUIContent GlitchRGBStrengthStyle = new GUIContent("RGB Strength", "Strength of the random RGB Split.");
        public static GUIContent GlitchRGBSpeedStyle = new GUIContent("RGB Speed", "Speed of the random RGB Split.");
        public static GUIContent GlitchRGBStyle = new GUIContent("RGB Chance", "Higher = rgb occurs more often.");
        public static GUIContent BDepthXStyle = new GUIContent("Horizontal Depth", "Changes the size of the x axis glitch.");
        public static GUIContent BDepthYStyle = new GUIContent("Vertical Depth", "Changes the size of the y axis glitch.");

        //Scanline glitch settings
        public static GUIContent ToggleScanlineStyle = new GUIContent("Allow Scanline", "Scanline going up/down the screen.");
        public static GUIContent ScanlineMapStyle = new GUIContent("Scanline Map", "Drag the scanline map from the maps folder here!");
        public static GUIContent ScanlinePushStyle = new GUIContent("Scanline Push", "How much the scanline should distort the screen.");
        public static GUIContent ScanlineSizeStyle = new GUIContent("Scanline Size", "Size of the scanline.");
        public static GUIContent ScanlineSpeedStyle = new GUIContent("Scanline Speed", "Speed of the scanline, whether going up or down.");

        //Static glitch settings
        public static GUIContent ToggleStaticGlitchStyle = new GUIContent("Allow Static Glitch", "Static-y glitch.");
        public static GUIContent StaticGlitchMapStyle = new GUIContent("Static Glitch Map", "Map to push the static.");
        public static GUIContent StaticGlitchPushStyle = new GUIContent("Static Amount", "How much the glitch map should push the static.");
        public static GUIContent StaticGlitchRangeStyle = new GUIContent("Static Spread", "How much the static is spraed out.");

        //Blocky glitch settings
        public static GUIContent ToggleBlockyGlitchStyle = new GUIContent("Allow Blocky Glitch", "Glitches the screen in the traditional rectangle style with broken color overlay and blocky rgb.");
        public static GUIContent BlockGlitchMapStyle = new GUIContent("Blocky Glitch Map", "Map that will be used to push the screen around.");
        public static GUIContent AllowBGXStyle = new GUIContent("Allow Horizontal Glitch", "Glitches the screen horizontally.");
        public static GUIContent AllowBGYStyle = new GUIContent("Allow Vertical Glitc (not suggest)", "Glitches the screen vertically.");
        public static GUIContent BlockyGlitchStrengthStyle = new GUIContent("Glitch Strength", "How much the screen will be pushed.");
        public static GUIContent AllowRandomnessIncreaseStyle = new GUIContent("Allow More Randomness", "Makes the glitch appear more random.");
        public static GUIContent BGRandomnessInceStyle = new GUIContent("Randomness Amount", "How much more random should the glitch appear?");
        public static GUIContent ToggleBlockyRGBStyle = new GUIContent("Allow Blocky Abberation", "Pushes the screen's r g and b colors.");
        public static GUIContent BlockyRGBPushStyle = new GUIContent("RGB Strength", "How much should the rgb split be pushed?");
        public static GUIContent AllowBGColorsStyle = new GUIContent("Allow Color Degrading", "Randomly overlay colors in a glitchy style.");
        public static GUIContent BGOverlayColorStyle = new GUIContent("Overlay Color", "Color to overlay onto the screen in a glitchy way.");
        public static GUIContent BGOverlayIntensityStyle = new GUIContent("Color Overlay Intensity", "Intensity of the glitchy color overlay.");
        public static GUIContent BGBrokenColorIntensityStyle = new GUIContent("Degrading Intensity", "Intensity of the broken colors on the screen.");
        public static GUIContent BlockyGlitchSpeedStyle = new GUIContent("Glitch Speed", "Speed of the blocky glitch.");
        public static GUIContent BlockyRGBSpeedStyle = new GUIContent("RGB Speed", "Speed of the chromatic abberation.");

        //Magnitude settings
        public static GUIContent ToggleMagnitudeStyle = new GUIContent("Allow Magnitude", "Shake but random and zoomy.");
        public static GUIContent MagnitudeZoomStyle = new GUIContent("Zoom Factor", "Controls the zoom of the shake.");
        public static GUIContent MagnitudeShakeStyle = new GUIContent("Shake Factor", "Controls how shake-y the shake will be lol.");
        public static GUIContent ToggleMagRandZoomStyle = new GUIContent("Randomize Zoom?", "Randomly zooms in rather than a set zoom.");

        //Mirror settings
        public static GUIContent ToggleMirrorStyle = new GUIContent("Allow Mirror", "Mirrors the screen. Just play with fx im too lazy to explain lol.");
        public static GUIContent MirrorUHStyle = new GUIContent("Mirror Left?", "Mirrors the screen at under halfway horizontally.");
        public static GUIContent MirrorOHStyle = new GUIContent("Mirror Right?", "Mirrors the screen at over halfway horizontally.");
        public static GUIContent MirrorUVStyle = new GUIContent("Mirror Bottom?", "Mirrors the screen at under vertically horizontally.");
        public static GUIContent MirrorOVStyle = new GUIContent("Mirror Top?", "Mirrors the screen at over vertically horizontally.");

        //Multiple screen settings
        public static GUIContent MultipleSreenStyle = new GUIContent("Allow Multiple Screens", "Allows for the display of multiple screens in a grid-like style.");
        public static GUIContent MultiScreenXStyle = new GUIContent("Horizontal Screens", "How many screens will be displayed across the x-axis.");
        public static GUIContent MultiScreenYtyle = new GUIContent("Vertical Screens", "How many screens will be displayed across the y-axis.");
        public static GUIContent MultiScreenFalloffStyle = new GUIContent("Allow Multiscreen Falloff?", "Looks smooth but kind of weird.");

        //Overlay settings
        public static GUIContent ToggleOverlayStyle = new GUIContent("Overlay", "Displays a texture over top of the screen. (looks good in vr, yes yes)");
        public static GUIContent UseSepOverlayStyle = new GUIContent("Use Different Image for VR (null)", "Displays one image to desktop users and a different image to VR users.");
        public static GUIContent OverlayTextureStyle = new GUIContent("Overlay Texture", "Texture to be overlayed.");
        public static GUIContent VROverlayTextureStyle = new GUIContent("Vr Overlay Texture", "Image to be displayed to VR users if enabled.");
        public static GUIContent OverlayTransparencyStyle = new GUIContent("Visibility", "Opacity of the overlay.");
        public static GUIContent OverlayYAdjustStyle = new GUIContent("Height", "Adjust the height of the image.");
        public static GUIContent OverlayXAdjustStyle = new GUIContent("Width", "Adjust the width of the image.");
        public static GUIContent OverlayTilingStyle = new GUIContent("Scale", "Adjust the scale of the image.");
        public static GUIContent OverlayXShiftStyle = new GUIContent("Horizontal Shift", "Adjust the horizontal posistion of the image.");
        public static GUIContent OverlayYShiftStyle = new GUIContent("Vertical Shift", "Adjust the vertical posistion of the image.");
        public static GUIContent OverlayTransStyle = new GUIContent("Allow Transistion?", "Transistions the overlay onto the screen. Similiar to transistion effect.");
        public static GUIContent OverlayTransXStyle = new GUIContent("Horizontal Transistion", "Transistions the overlay horizontally onto the screen. Similiar to transistion effect.");
        public static GUIContent OverlayTransYStyle = new GUIContent("Vertical Transistion", "Transistions the overlay vertically onto the screen. Similiar to transistion effect.");

        //Overlay two settings
        public static GUIContent ToggleOverlayStyleTwo = new GUIContent("Second Overlay", "Displays a texture over top of the screen. (looks good in vr, yes yes)");
        public static GUIContent OverlayTextureStyleTwo = new GUIContent("Second Overlay Texture", "Texture to be overlayed.");
        public static GUIContent OverlayTransparencyStyleTwo = new GUIContent("Second Visibility", "Opacity of the overlay.");
        public static GUIContent OverlayYAdjustStyleTwo = new GUIContent("Second Height", "Adjust the height of the image.");
        public static GUIContent OverlayXAdjustStyleTwo = new GUIContent("Second Width", "Adjust the width of the image.");
        public static GUIContent OverlayTilingStyleTwo = new GUIContent("Second Scale", "Adjust the scale of the image.");
        public static GUIContent OverlayXShiftStyleTwo = new GUIContent("Second Horizontal Shift", "Adjust the horizontal posistion of the image.");
        public static GUIContent OverlayYShiftStyleTwo = new GUIContent("Second Vertical Shift", "Adjust the vertical posistion of the image.");
        public static GUIContent OverlayTransStyleTwo = new GUIContent("Allow Transistion?", "Transistions the overlay onto the screen. Similiar to transistion effect.");
        public static GUIContent OverlayTransXStyleTwo = new GUIContent("Horizontal Transistion", "Transistions the overlay horizontally onto the screen. Similiar to transistion effect.");
        public static GUIContent OverlayTransYStyleTwo = new GUIContent("Vertical Transistion", "Transistions the overlay vertically onto the screen. Similiar to transistion effect.");

        //Overlay two settings
        public static GUIContent ToggleOverlayStyleThree = new GUIContent("Third Overlay", "Displays a texture over top of the screen. (looks good in vr, yes yes)");
        public static GUIContent OverlayTextureStyleThree = new GUIContent("Third Overlay Texture", "Texture to be overlayed.");
        public static GUIContent OverlayTransparencyStyleThree = new GUIContent("Third Visibility", "Opacity of the overlay.");
        public static GUIContent OverlayYAdjustStyleThree = new GUIContent("Third Height", "Adjust the height of the image.");
        public static GUIContent OverlayXAdjustStyleThree = new GUIContent("Third Width", "Adjust the width of the image.");
        public static GUIContent OverlayTilingStyleThree = new GUIContent("Third Scale", "Adjust the scale of the image.");
        public static GUIContent OverlayXShiftStyleThree = new GUIContent("Third Horizontal Shift", "Adjust the horizontal posistion of the image.");
        public static GUIContent OverlayYShiftStyleThree = new GUIContent("Third Vertical Shift", "Adjust the vertical posistion of the image.");
        public static GUIContent OverlayTransStyleThree = new GUIContent("Third Transistion?", "Transistions the overlay onto the screen. Similiar to transistion effect.");
        public static GUIContent OverlayTransXStyleThree = new GUIContent("Third Transistion", "Transistions the overlay horizontally onto the screen. Similiar to transistion effect.");
        public static GUIContent OverlayTransYStyleThree = new GUIContent("Third Transistion", "Transistions the overlay vertically onto the screen. Similiar to transistion effect.");

        //Gif overlay settings
        public static GUIContent ToggleGifOverlayStyle = new GUIContent("Allow Gif Overlay", "Displays a gif over top of the screen. (looks good in vr, yes yes)");
        public static GUIContent OverlaySpritesheetStyle = new GUIContent("Overlay Spritesheet", "Gif image as spritesheet. (use online converter)");
        public static GUIContent OSSRowsStyle = new GUIContent("Rows", "Rows in the spritesheet.");
        public static GUIContent OSSColumnsStyle = new GUIContent("Columns", "Columns in the spritesheet.");
        public static GUIContent OSSSpeedsStyle = new GUIContent("Speed", "Speed the gif plays at.");
        public static GUIContent GifTransparencyStyle = new GUIContent("Visibility", "Opacity of the overlay.");
        public static GUIContent GifYAdjustStyle = new GUIContent("Height", "Adjust height of the gif.");
        public static GUIContent GifXAdjustStyle = new GUIContent("Width", "Adjust width of the gif.");
        public static GUIContent GifTilingStyle = new GUIContent("Scale", "Adjust the scale of the gif/");
        public static GUIContent GifXShiftStyle = new GUIContent("Horizontal Shift", "Adjust the horizontal posistion of the image.");
        public static GUIContent GifYShiftStyle = new GUIContent("Vertical Shift", "Adjust the vertical posistion of the image.");
        public static GUIContent ToggleTransparentGifStyle = new GUIContent("Cutout Background Color (null)", "Allow a transparent gif by cutting out a colored background.");
        public static GUIContent GifColorToCutStyle = new GUIContent("Background Color", "Color to turn transparent.");
        public static GUIContent GifBackgroundToleranceStyle = new GUIContent("Tolerance", "Photoshop-like tolerance level for the old color tbe replaced. (higher = wider range of colors cut out)");

        //Horizontal blur settingss
        public static GUIContent ToggleHorizontalBlurStyle = new GUIContent("Allow Horizontal Blur", "Blurs the x-axis of the screen.");
        public static GUIContent HorizontalBlurOffsetStyle = new GUIContent("Strength", "Strength of the blur.");
        public static GUIContent ToggleHorizontalBlurAnimateStyle = new GUIContent("Animate Blur", "Automatically moves the strength of the blur.");
        public static GUIContent HorizontalBlurSpeedStyle = new GUIContent("Speed", "Speed of the blur's autoanimation.");

        //Linocut
        public static GUIContent ToggleLinocutStyle = new GUIContent("Allow Linocut", "Basd upon a wood printing technique.");
        public static GUIContent LinocutPowerStyle = new GUIContent("Linocut Size", "Power of the linocut effect.");
        public static GUIContent LinocutOpacityStyle = new GUIContent("Linocut Visibility", "Opacity of the effect.");

        //Outline settings
        public static GUIContent ToggleOutlineStyle = new GUIContent("Allow Neon", "Renders the world with customizable outlines and colors.");
        public static GUIContent ToggleSepiaOutlineStyle = new GUIContent("Desaturatation Amount", "Turns the outline and world into black and white.");
        public static GUIContent OutlineOffsetStyle = new GUIContent("Outline Coverage", "How much the outline should cover");
        public static GUIContent OutlineActualOffsetStyle = new GUIContent("Outline Offset", "Offset of the outline.");
        public static GUIContent OutlineModOneStyle = new GUIContent("Outline Darkness", "Controls the darkness of the outline/world.");
        public static GUIContent OutlineModTwoStyle = new GUIContent("Outline Red Value", "Factor in the outline equation in determining color.");
        public static GUIContent OutlineModThreeStyle = new GUIContent("Outline Green Value", "Factor in the outline equation in determining color.");
        public static GUIContent OutlineModFourStyle = new GUIContent("Outline Blue Value", "Factor in the outline equation in determining color.");

        //Radial blur settings
        public static GUIContent ToggleRadialBlurStyle = new GUIContent("Allow Radial Blur", "Blurs around a center point.");
        public static GUIContent RadialBlurDistanceStyle = new GUIContent("Blur Strength", "Determines the strength of the blur.");
        public static GUIContent RadialBlurCenterRadiusStyle = new GUIContent("Center Radius", "The radius of the center the screen is blurred around.");
        public static GUIContent RadialBlurVerticalCenterStyle = new GUIContent("Vertical Center Placement", "Adjust the vertical posistion of the center.");
        public static GUIContent RadialBlurHorizontalCenterStyle = new GUIContent("Horizontal Center Placement", "Adjust the horizontal posistion of the center.");

        //Radial outline settings
        public static GUIContent ToggleRadialOutlineStyle = new GUIContent("Allow Radial Outline", "like radial blur but with OUTLINE");
        public static GUIContent RODistanceStyle = new GUIContent("Blur Strength", "Determines the strength of the blur.");
        public static GUIContent ROCenterRadius = new GUIContent("Center Radius", "The radius of the center the screen is blurred around.");
        public static GUIContent ROColorStyle = new GUIContent("Outline Color", "Color of the outline.");
        public static GUIContent ROIntensityStyle = new GUIContent("Outline Intensity", "How strong the outline should be.");
        public static GUIContent ROToleranceStyle = new GUIContent("Outline Tolerance", "How much should be outlined.");
        public static GUIContent ROGlowStyle = new GUIContent("Outline Glow", "Glow of the outline.");
        public static GUIContent ROTransStyle = new GUIContent("Outline Transparency", "The transparency of the outline.");

        //Rainbow settings
        public static GUIContent ToggleHSVRainbowStyle = new GUIContent("Allow Rainbow", "Rainbow-ify the screen! uwu");
        public static GUIContent ToggleHSVRainbowXStyle = new GUIContent("Horizontal Scroll?", "Scrolls the colors horizontally across the screen.");
        public static GUIContent ToggleHSVRainbowYStyle = new GUIContent("Vertical Scroll?", "Scrolls the colors vertically across the screen.");
        public static GUIContent HSVRainbowHueStyle = new GUIContent("Color Spread", "Controls the hue of the rainbow.");
        public static GUIContent HSVRainbowSatStyle = new GUIContent("Saturation", "Controls the saturation of the rainbow.");
        public static GUIContent HSVRainbowLightStyle = new GUIContent("Light", "Controls the brightness of the rainbow.");
        public static GUIContent HSVRainbowTimeStyle = new GUIContent("Time", "Controls how fast the colors scroll across the screen.");

        //Ramp settings
        public static GUIContent ToggleRampEffectStyle = new GUIContent("Allow Ramp", "Combines the world's colors with a ramp map.");
        public static GUIContent ToggleRampRedStyle = new GUIContent("Red Channel", "Use the red color channel.");
        public static GUIContent ToggleRampBlueStyle = new GUIContent("Blue Channel", "Use the blue color channel.");
        public static GUIContent ToggleRampGreenStyle = new GUIContent("Green Channel", "Use the green color channel.");
        public static GUIContent RampMapStyle = new GUIContent("Ramp Map", "Ramp map for the first ramp.");
        public static GUIContent RampOneLightingStyle = new GUIContent("Ramp Lighting", "Adjust lighting for the first ramp.");
        public static GUIContent RampOneDepthStyle = new GUIContent("Ramp Depth", "Depth of the ramp pixels idk lol im tired of writing these");
        public static GUIContent RampOneStrengthStyle = new GUIContent("Ramp Value", "Value of the ramp, for manual animating.");
        public static GUIContent ToggleRampOneAnimateStyle = new GUIContent("Animate Ramp One", "Automatically move the ramp across the world.");
        public static GUIContent RampOneSpeedStyle = new GUIContent("Ramp One Speed", "The speed at which ramp one will move.");
        public static GUIContent ToggleRampTwoStyle = new GUIContent("Allow Second Ramp Map", "Allows another ramp map to be used in combination with the first.");
        public static GUIContent ToggleRampTwoRedStyle = new GUIContent("Ramp Two Red Channel", "Use the red color channel.");
        public static GUIContent ToggleRampTwoBlueStyle = new GUIContent("Ramp Two Blue Channel", "Use the blue color channel.");
        public static GUIContent ToggleRampTwoGreenStyle = new GUIContent("Ramp Two Green Channel", "Use the green color channel.");
        public static GUIContent RampMapTwoStyle = new GUIContent("Ramp Two Map", "Ramp map for the second ramp.");
        public static GUIContent RampTwoLightingStyle = new GUIContent("Ramp Two Lighting", "Adjust the lighting for the second ramp.");
        public static GUIContent RampTwoDepthStyle = new GUIContent("Ramp Two Depth", "Adjust the depth of the second ramp.");
        public static GUIContent RampTwoStrengthStyle = new GUIContent("Ramp Two Value", "For manual animating.");
        public static GUIContent ToggleRampTwoAnimateStyle = new GUIContent("Animate Ramp Two", "Automatically move the second ramp across the world.");
        public static GUIContent RampTwoSpeedStyle = new GUIContent("Ramp Two Speed", "Speed for ramp two animation.");
        public static GUIContent RampBlendingStyle = new GUIContent("Ramp Blending", "Control the blending of the two ramps.");

        //Recolor settings
        public static GUIContent ToggleRecolorStyle = new GUIContent("Allow Hue Shift", "Recolors the world through HSV cycles.");
        public static GUIContent RecolorBrightStyle = new GUIContent("Brightness", "Brightness.. duh");
        public static GUIContent RecolorSaturationStyle = new GUIContent("Saturation", "um what does the name say?? can u read??");
        public static GUIContent RecolorHueStyle = new GUIContent("Hue Shift", "literally read the name lol cmon");
        public static GUIContent RecolorSpeedStyle = new GUIContent("Speed", "Speed at which the HSV will be cycled.");
        public static GUIContent ToggleRecolorAnimateStyle = new GUIContent("Rainbow?", "Will automatically move the colors, like the old recolor option.");

        //Rgb settings
        public static GUIContent ToggleRGBStyle = new GUIContent("Allow RGB Split", "Splits the screen into red, green, and  blue.");
        public static GUIContent AmountValueStyle = new GUIContent("Strength", "Distance the RGB will be split.");
        public static GUIContent ToggleVerticalRGBStyle = new GUIContent("Allow Vertical Split", "Splits the RGB vertically rather than horizontally.");
        public static GUIContent ToggleAutoanimateStyle = new GUIContent("Animate RGB", "Automatically moves the RGB split. RGB Rotate always has this enabled.");
        public static GUIContent RGBAutoanimateSpeedStyle = new GUIContent("Speed", "Speed of the animated RGB split.");
        public static GUIContent ToggleRotationStyle = new GUIContent("Allow Rotation", "Rotates the RGB split.");
        public static GUIContent RotationSpeedRedStyle = new GUIContent("Red Rotation Speed", "Determines the rotation speed for the red copy.");
        public static GUIContent RotationSpeedBlueStyle = new GUIContent("Blue Rotation Speed", "Determines the rotation speed for the blue copy.");
        public static GUIContent DirectionRedStyle = new GUIContent("Red Rotation Direction", "Determines the rotation direction for the red.");
        public static GUIContent DirectionBlueStyle = new GUIContent("Blue Rotation Direction", "Determines the rotation driection for the blue.");
        public static GUIContent ToggleGreenMovementStyle = new GUIContent("Allow Green Movement", "Allows the green copy to be moved.");
        public static GUIContent RotationSpeedGreenStyle = new GUIContent("Green Rotation Speed", "Determines the rotation speed for the green copy.");
        public static GUIContent DirectionGreenStyle = new GUIContent("Green Rotation Direction", "Determines the rotation direction for the green.");
        public static GUIContent ToggleScreenFollowStyle = new GUIContent("Allow Screen Follow", "Will make the users screen move with the rotating rgb.");
        public static GUIContent StrengthModStyle = new GUIContent("Increase Screen Follow Strength", "Adjust the strength of the screen follow.");
        public static GUIContent ToggleColorStyle = new GUIContent("Allow Custom Colors", "Change colors of the split.");
        public static GUIContent RedCustomColorStyle = new GUIContent("Red Custom Color", "Control the color of the red split.");
        public static GUIContent BlueCustomColorStyle = new GUIContent("Blue Custom Color", "Control the color of the blue split.");
        public static GUIContent GreenCustomColorStyle = new GUIContent("Green Custom Color", "Control the color of the green split.");
        public static GUIContent rgbrotate = new GUIContent("RGB Rotate", "Rotates the RGB split.");
        public static GUIContent rgbscreenfollow = new GUIContent("Force Screen Follow", "Makes the players screen follow the rotating rgb.");
        public static GUIContent rgbcolor = new GUIContent("Custom Colors", "Change the colors of the splits.");
        //new rgb stuff bleh
        public static GUIContent RedXValueStyle = new GUIContent("Red Horizontal Abberation", "...");
        public static GUIContent RedYValueStyle = new GUIContent("Red Vertical Abberation", "...");
        public static GUIContent GreenXValueStyle = new GUIContent("Green Horizontal Abberation", "...");
        public static GUIContent GreenYValueStyle = new GUIContent("Green Vertical Abberation", "...");
        public static GUIContent BlueXValueStyle = new GUIContent("Blue Horizontal Abberation", "...");
        public static GUIContent BlueYValueStyle = new GUIContent("Blue Vertical Abberation", "...");

        //Rgb hide settings
        public static GUIContent HideRedTransStyle = new GUIContent("Red Visibility", "Controls the visibility of the red channel.");
        public static GUIContent HideGreeenTransStyle = new GUIContent("Green Visibility", "Controls the visibility of the green channel.");
        public static GUIContent HideBlueTransStyle = new GUIContent("Blue Visibility", "Controls the visibility of the blue channel.");

        //Rgb grid settings
        public static GUIContent ToggleRGBGridStyle = new GUIContent("Allow RGB Grid", "Simulates the look of a monitor up close.");
        public static GUIContent RGBGridSizeStyle = new GUIContent("Grid Size", "Size of the grid.");

        //Rgb zoom settings
        public static GUIContent ToggleRGBZoomStyle = new GUIContent("Allow RGB Zoom", "Zooms in on RGB channels.");
        public static GUIContent RedZoomStyle = new GUIContent("Red Zoom", "Zooms in on Red channel.");
        public static GUIContent GreenZoomStyle = new GUIContent("Green Zoom", "Zooms in on Green channel.");
        public static GUIContent BlueZoomStyle = new GUIContent("Blue Zoom", "Zooms in on Blue channel.");
        public static GUIContent RGBZoomTransStyle = new GUIContent("RGB Zoom Transparency", "Transparency of the RGB zoom.");

        //Rotate settings
        public static GUIContent ToggleRotaterStyle = new GUIContent("Allow Rotation", "Rotates the screen at a certain angle.");
        public static GUIContent RotaterValueStyle = new GUIContent("Rotation Degree", "Degree to be rotated.");
        public static GUIContent ToggleRotaterAnimateStyle = new GUIContent("Animate Rotation", "Automatically spins the screen around.");
        public static GUIContent RotaterSpinStyle = new GUIContent("Rotation Speed", "Speed at which the screen will be spun.");

        //Ripple settings
        public static GUIContent ToggleRippleStyle = new GUIContent("Toggle Ripple", "Displays a customizable ripple on the screen.");
        public static GUIContent ShockCenterXStyle = new GUIContent("Horizontal Center", "Displays a customizable ripple on the screen.");
        public static GUIContent ShockCenterYStyle = new GUIContent("Vertical Center", "Displays a customizable ripple on the screen.");
        public static GUIContent ShockDisStyle = new GUIContent("Ripple Distortion", "Controls the amount of distortion in the ripple.");
        public static GUIContent ShockMagStyle = new GUIContent("Ripple Size", "Controls the size of the ripple on the screen.");
        public static GUIContent ShockSpreadStyle = new GUIContent("Ripple Spread", "Control how spraed out the ripple on the screen.");

        //Pixelate settings
        public static GUIContent TogglePixelateStyle = new GUIContent("Allow Pixelation", "Pixelates the screen.");
        public static GUIContent PixelateStrengthStyle = new GUIContent("Pixelate", "Strength of pixelation on x axis.");
        //public static GUIContent ToggleAdvPixelateStyle = new GUIContent("Use Seperate Controls?", "Allows you to customize the x and y axis pixelate separately.");
        //public static GUIContent PixelateStrengthYStyle = new GUIContent("Vertical Pixelate", "Strength of pixelation on y axis.");

        //Posterize settings
        public static GUIContent TogglePosterizeStyle = new GUIContent("Allow Posterize", "Converts the screen to only render using a small number of tones.");
        public static GUIContent PosterizeValueStyle = new GUIContent("Posterization", "Amount of tones permitted.");

        //Projection settings
        public static GUIContent ToggleProjectionStyle = new GUIContent("Allow Projection", "Projects copies of the screen.");
        public static GUIContent ProjectionStrengthStyle = new GUIContent("Projection Strength", "Distance of the projected copies.");
        public static GUIContent ProjectionCopiesStyle = new GUIContent("Projection Copies", "Amount of copies that are made.");
        public static GUIContent ProjectionDirectionStyle = new GUIContent("Projection Direction", "Direction of the projected copies.");
        public static GUIContent ProjectionBrightnessStyle = new GUIContent("Projection Brightness", "Adjust the brightness of the screen when creating projections.");
        public static GUIContent ProjectionFadeStyle = new GUIContent("Projection Fade", "Controls the opacity of the projections.");
        public static GUIContent ProjectionAdvStyle = new GUIContent("Use Manual Settings", "Instead of rotating settings.");
        public static GUIContent ProjAdvXStyle = new GUIContent("X Shift", "Shifts the X axis of the projections.");
        public static GUIContent ProjAdvYStyle = new GUIContent("Y Shift", "Shifts the y axis of the projections.");
        public static GUIContent ProjScaleXStyle = new GUIContent("X Scale", "Scales the copies on the x axis.");
        public static GUIContent ProjScaleYStyle = new GUIContent("Y Scale", "Scales the copies on the y axis.");

        //Saturation settings
        public static GUIContent SaturationStyle = new GUIContent("Allow Saturation", "Changes the saturation of the screen.");
        public static GUIContent SaturationValue = new GUIContent("Saturation", "Controls the amount of saturation.");

        //Screensquish settings
        public static GUIContent ToggleScreensquishStyle = new GUIContent("Allow Screensquish", "Squishes the screen, actual cancer.");
        public static GUIContent ScreenSquishXStyle = new GUIContent("Horizontal Squish", "Squish the x-axis.");
        public static GUIContent ScreenSquishYStyle = new GUIContent("Vertical Squish", "Squish the y-axis.");

        //Screenpull settings
        public static GUIContent ToggleScreenpullStyle = new GUIContent("Allow Screenpush", "Pulls the screen depending on a map.");
        public static GUIContent ScreenpullStrengthStyle = new GUIContent("Strength", "How much the screen is pushed.");
        public static GUIContent ScreenpullStrenghthTwoStyle = new GUIContent("Vertical Push", "How much the screen is pushed.");
        public static GUIContent ScreenpullModeStyle = new GUIContent("Direction", "Determines how the screen will be pulled.");
        public static GUIContent ScreenpullMapstyle = new GUIContent("Map", "Map that determines which direction the screen will be pulled. Maps included in the pack.");

        //Screen zoom settings
        public static GUIContent ToggleScreenZoomStyle = new GUIContent("Allow Screen Zoom", "Zooms in the screen at every angle, not on an objec.t");
        public static GUIContent ScreenZoomInValueStyle = new GUIContent("Screen Zoom In", "Strength of the zoom.");
        public static GUIContent ToggleAutoanimateScreenZoomStyle = new GUIContent("Autoanimate Screen Zoom", "Automatically zooms the screen in and out.");
        public static GUIContent ScreenzoomSpeedStyle = new GUIContent("Screen Zoom Speed", "Speed of the screen zoom autoanimation.");

        //Shake settings
        public static GUIContent ToggleShakeStyle = new GUIContent("Allow Shake", "Shakes the screen.");
        public static GUIContent ToggleXYShakeStyle = new GUIContent("Use XY Shake", "Shakes the screen in multiple directions instead.");
        public static GUIContent ShakeStrengthStyle = new GUIContent("Shake Strength", "Strength of the screenshake.");
        public static GUIContent ShakeSpeedStyle = new GUIContent("Shake Speed", "Speed of the screenshake.");
        public static GUIContent emptyTexStyle = new GUIContent("Optional Shake Map", "Optional shake map to control the direction of the shake");
        public static GUIContent ShakeStrength2Style = new GUIContent("Y Strength", "Shake strength of the y-axis");
        public static GUIContent ShakeSpeed2Style = new GUIContent("Y Speed", "Shake speed of the y-axis.");

        //Smear settings
        public static GUIContent ToggleSmearStyle = new GUIContent("Allow Smear", "Smears the screen.");
        public static GUIContent CSDirectionStyle = new GUIContent("Direction", "Direction of the smear.");
        public static GUIContent CSRedStyle = new GUIContent("Red Smear", "Amount of red color smear.");
        public static GUIContent CSGreenStyle = new GUIContent("Green Smear", "Amount of green color smear.");
        public static GUIContent CSBlueStyle = new GUIContent("Blue Smear", "Amount of blue color smear.");
        public static GUIContent CSAutoRotateStyle = new GUIContent("Rotate Smear", "Automatically rotates the smear.");
        public static GUIContent CSRotateSpeedStyle = new GUIContent("Rotate Speed", "Speed of the rotation.");
        public static GUIContent CSRotateDirectionStyle = new GUIContent("Rotate Direction", "Direction of the rotation matrix.");
        public static GUIContent CSUseAdvancedStyle = new GUIContent("Use Advanced Options", "Allow advanced control over the animated rotation matrix.");
        public static GUIContent CSRotateSpeedSinXRStyle = new GUIContent("SinXR Speed", "Rotation matrix sin xr value.");
        public static GUIContent CSRotateSpeedCosXRStyle = new GUIContent("CosXR Speed", "Rotation matrix cos xr value.");
        public static GUIContent CSRotateSpeedSinYRStyle = new GUIContent("SinYR Speed", "Rotation matrix sin yr value.");
        public static GUIContent ToggleCSColorStyle = new GUIContent("Tint Smear", "Adds colors to the smear.");
        public static GUIContent CSColorTintStyle = new GUIContent("Color", "Color of the smear.");

        //Static settings
        public static GUIContent ToggleNoiseStyle = new GUIContent("Allow Grain", "Adds customizable noise to the screen.");
        public static GUIContent StaticIntensityStyle = new GUIContent("Grain Intensity", "Visibility of the static.");
        public static GUIContent ToggleAnimatedNoiseStyle = new GUIContent("Animate Grain", "Automatically move the static around.");
        public static GUIContent StaticSpeedStyle = new GUIContent("Grain Speed", "Speed the static moves.");
        public static GUIContent StaticColorStyle = new GUIContent("Grain Color", "Color of the statc.");

        //Swirl settings
        public static GUIContent ToggleSwirlStyle = new GUIContent("Allow Spiral", "Swirls the screen... duh");
        public static GUIContent SwirlPowerStyle = new GUIContent("Spiral Strength", "How strong the twist should be.");
        public static GUIContent SwirlAngleStyle = new GUIContent("Spiral Angle", "Angle of the swirl.");
        public static GUIContent SwirlCenterXStyle = new GUIContent("Horizontal Center", "Swirls center on the x axis.");
        public static GUIContent SwirlCenterYStyle = new GUIContent("Vertical Center", "Swirls center on the y axis.");
        public static GUIContent SwirlRadiusStyle = new GUIContent("Spiral Radius", "Radius of the swirl.. duh");

        //Splice settings
        public static GUIContent ToggleSpliceStyle = new GUIContent("Allow Split", "Splits the screen into multiple parts.");
        public static GUIContent SplitTopStyle = new GUIContent("Top Split", "Cuts the top half of the screen.");
        public static GUIContent SplitBotStyle = new GUIContent("Bot Split", "Cuts the bot half of the screen.");
        public static GUIContent SplitXLimitStyle = new GUIContent("Horizontal Cut Placement", "Determines where on the x axis the screen will be split.");
        public static GUIContent SplitLeftStyle = new GUIContent("Left Split", "Cuts the left half of the screen.");
        public static GUIContent SplitRightStyle = new GUIContent("Right Split", "Splits the right half of the screen.");
        public static GUIContent SplitYLimitStyle = new GUIContent("Vertical Cut Placement", "Determines where on the y axis the screen will be split.");
        public static GUIContent SpliceFixStyle = new GUIContent("Fix Splice Ends?", "Mirrors stretched ends of splice. Can be kind of weird.");

        //Thermal settings
        public static GUIContent ToggleThermalStyle = new GUIContent("Allow Thermal", "Applies a thermal-vision heat like effect to the screen.");
        public static GUIContent ThermalHeatStyle = new GUIContent("Thermal Heat", "Changes the heat threshold of the thermal levels. (makes colors warmer, e.g. more red)");
        public static GUIContent ThermalSensitivityStyle = new GUIContent("Thermal Sensitivity", "How sensitive the effect should be when applying.");
        public static GUIContent ThermalTransparencyStyle = new GUIContent("Thermal Transparency", "Visibility of the effect.");

        //Transistion settings
        public static GUIContent ToggleTransistionStyle = new GUIContent("Allow Transistion", "Moves effects across the screen.");
        public static GUIContent TransXStyle = new GUIContent("Horizontal Transistion", "Moves effects horizontally across the screen.");
        public static GUIContent TransYStyle = new GUIContent("Vertical Transistion", "Moves effects vertically across the screen.");
        public static GUIContent ToggleDiagTrans = new GUIContent("Allow Diagonal Transistion", "Similar to transistion but diagonal lol");
        public static GUIContent TransDLStyle = new GUIContent("Left Diagonal Transistion", "Moves effects diagonally left.");
        public static GUIContent TransDRStyle = new GUIContent("Right Diagonal Transistion", "Moves effects diagonally right.");

        //Twist settings
        public static GUIContent ToggleTwistStyle = new GUIContent("Allow Twist", "Warps the screen.");
        public static GUIContent TwistValueStyle = new GUIContent("Twist Value", "Amount of twist.");
        public static GUIContent TwistOffsetStyle = new GUIContent("Twist Offset", "Offset of the twist.");

        //Vhs settings
        public static GUIContent ToggleVHSStyle = new GUIContent("Allow VHS", "Applies a VHS-like effect over the screen.");
        public static GUIContent ToggleSmoothWaveStyle = new GUIContent("Smooth Jitter?", "Makes the wavey displacement smooth.");
        public static GUIContent VHSXDisplacementStyle = new GUIContent("Horizontal Jitter", "Horizontal jitter values. Ignore the last one!");
        public static GUIContent VHSYDisplacementStyle = new GUIContent("Vertical Jitter", "Vertical jitter values. Ignore the last one!");
        public static GUIContent shadowMinStyle = new GUIContent("Mimumum Shadow Strength", "Lowest strength of shadow border effect.");
        public static GUIContent shadowStrengthStyle = new GUIContent("Vignette", "Average strength of the shadow border effect.");
        public static GUIContent shadowMaxStyle = new GUIContent("Maximum Shadow Strength", "Maximum strength of the shadow border effect.");
        public static GUIContent shadowFlickerStyle = new GUIContent("Shadow Flicker", "Speed of the shadow's strength flickering in and out.");
        public static GUIContent darknessStyle = new GUIContent("Scanline Darkness", "Darkness of the line effect of the filter. (Lower = Darker)");
        public static GUIContent waveynessStyle = new GUIContent("Waveyness", "Allows for a wavey-distort to the horizontal axis.");

        //Vignette settings
        public static GUIContent ToggleVignetteStyle = new GUIContent("Allow Vignette", "Applys a soft black border around the screen, such as in older films or vhs.");
        public static GUIContent VigAdvStyle = new GUIContent("Use Separete Controls?", "Allows you to customize the x and y axis vignette separately.");
        public static GUIContent VigXStyle = new GUIContent("Vignette Strength", "Controls strenght of the vignette on the x-axis.");
        public static GUIContent VigYStyle = new GUIContent("Vertical Vignette Strength", "Controls strenght of the vignette on the y-axis.");

        //Vertical blur settings
        public static GUIContent ToggleVerticalBlurStyle = new GUIContent("Allow Vertical Blur", "Blurs the y-axis of the screen.");
        public static GUIContent VerticalBlurOffsetStyle = new GUIContent("Strength", "Strength of the blur.");
        public static GUIContent ToggleVerticalBlurAnimateStyle = new GUIContent("Animate Blur", "Automatically moves the strength of the blur.");
        public static GUIContent VerticalBlurSpeedStyle = new GUIContent("Speed", "Speed of the blur's autoanimation.");

        //Warp settings
        public static GUIContent WarpHorizontalStyle = new GUIContent("Horizontal Warp", "Warps the screen horizontally, like screen pull but smoother.");
        public static GUIContent WarpVerticalStyle = new GUIContent("Vertical Warp", "Warps the screen vertically, like screen pull but smoother.");

        //Deepfry settings
        public static GUIContent ToggleDeepfryStyle = new GUIContent("Allow Deepfry", "Type any value, 1 to 34, for different world effects.");
        public static GUIContent DeepfryValueStyle = new GUIContent("Effect (1-34)", "Type any value, 1 to 34, for different world effects.");
        public static GUIContent DeepfryBrightnessStyle = new GUIContent("Brightness", "Brightness of the effect.");
        public static GUIContent ToggleSuperSpeedyModeStyle = new GUIContent("Super Speedy Mode", "Not reccomended.");
        public static GUIContent ShowDeepfryList = new GUIContent("Show Effects List", "Displays the name of hte effect that the number goes with.");

    }

    //setting up gui 
    private void prepareGUI()
    {

        //fool proof 

        //droplet hsv or rgb
        if (dropletHSVorRGB == true)
        {
            propStyles.ToggleUseHSVInsteadStyle = new GUIContent("Use HSV Instead (Currently: HSV)", "Changes the method of filtering colors from HSV to RGB.");
        }
        else
        {
            propStyles.ToggleUseHSVInsteadStyle = new GUIContent("Use HSV Instead (Currently: RGB)", "Changes the method of filtering colors from HSV to RGB.");
        }

        //filter advanced
        if (showFilterAdvanced == true)
        {
            propStyles.ToggleAdvancedFilterStyle = new GUIContent("Use Advanced Options (shown)", "[Advanced controls are on] Allows more control over the color being filtered.");
        }
        else
        {
            propStyles.ToggleAdvancedFilterStyle = new GUIContent("Use Advanced Options (hidden)", "[Advanced controls are hidden until enabled] Allows more control over the color being filtered.");
        }

        //filter colored background
        if (showFilterColoredBG == true)
        {
            propStyles.ToggleColoredFilterStyle = new GUIContent("Allow Colored Background (shown)", "[Colored background is on] Instead of turning everything else black and white, turns it to a color with a specificed intensity.");
        }
        else
        {
            propStyles.ToggleColoredFilterStyle = new GUIContent("Allow Colored Background (hidden)", "[Colored background controls are hidden until enabled] Instead of turning everything else black and white, turns it to a color with a specificed intensity.");
        }

        //glitch animation
        if (showGlitchAnimate == true)
        {
            propStyles.ToggleRandomGlitchStyle = new GUIContent("Animate Glitch (shown)", "[Still expiremental] Automatically animates the glitch map and values.");
        }
        else
        {
            propStyles.ToggleRandomGlitchStyle = new GUIContent("Animate Glitch (hidden)", "[Still expiremental] Automatically animates the glitch map and values.");
        }

        //glitch direction
        if (showGlitchRandDirection == true)
        {
            propStyles.ToggleRandomSideGlitchStyle = new GUIContent("Randomize Glitch Direction (shown)", "Allows the glitch to randomly move in different directions.");
        }
        else
        {
            propStyles.ToggleRandomSideGlitchStyle = new GUIContent("Randomize Glitch Direction (hidden)", "Allows the glitch to randomly move in different directions.");
        }

        //glitch rgb
        if (showGlitchRGB == true)
        {
            propStyles.ToggleGlitchChromaticStyle = new GUIContent("Allow Glitch RGB", "Randomly enables a customizable chromatic abberation effect.");
        }
        else
        {
            propStyles.ToggleGlitchChromaticStyle = new GUIContent("Allow Glitch RGB", "Randomly enables a customizable chromatic abberation effect.");
        }

        //overlay seperate image
        if (showVRTexture == true)
        {
            propStyles.UseSepOverlayStyle = new GUIContent("Use Different Image for VR (shown)", "Displays one image to desktop users and a different image to VR users.");
        }
        else
        {
            propStyles.UseSepOverlayStyle = new GUIContent("Use Different Image for VR (hidden)", "Displays one image to desktop users and a different image to VR users.");
        }

        //gif background color
        if (showCutoutGif == true)
        {
            propStyles.ToggleTransparentGifStyle = new GUIContent("Cutout Background Color (shown)", "Allow a transparent gif by cutting out a colored background.");
        }
        else
        {
            propStyles.ToggleTransparentGifStyle = new GUIContent("Cutout Background Color (hidden)", "Allow a transparent gif by cutting out a colored background.");
        }

        //color split animate
        if (showColorSplitAnimate == true)
        {
            propStyles.ToggleAutoanimateColorSplitStyle = new GUIContent("Animate Color Split (shown)", "Automatically move the sides of the color split.");
        }
        else
        {
            propStyles.ToggleAutoanimateColorSplitStyle = new GUIContent("Animate Color Split (hidden)", "Automatically move the sides of the color split.");
        }

        //xy shake 
        if (showXYShake == true)
        {
            propStyles.ShakeStrengthStyle = new GUIContent("X Strength", "Shake strength of the x-axis.");
            propStyles.ShakeSpeedStyle = new GUIContent("X Speed", "Shake speed of the x-axis.");
            propStyles.ToggleXYShakeStyle = new GUIContent("Toggle XY Shake (shown)", "Shakes the screen in multiple directions at once.");
        }
        else
        {
            propStyles.ShakeStrengthStyle = new GUIContent("Shake Strength", "Strength of the shake.");
            propStyles.ShakeSpeedStyle = new GUIContent("Shake Speed", "Speed of the shake.");
            propStyles.ToggleXYShakeStyle = new GUIContent("Toggle XY Shake (hidden)", "Shakes the screen in multiple directions at once.");
        }

        //for those who aren't familiar with ztest
        //wait no, its locked now
        //oops its not locked anymore and i think i deleted all the other definitions oof
        ztestDescription = "It is (highly) recommended to use ZTest Always c:";

    }

    //drawing a divider
    private static void drawDivider()
    {
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        var divideSpace = GUILayoutUtility.GetRect(0, int.MaxValue, 5, 30);
        Texture2D divideTex = Resources.Load<Texture2D>("LukaResource_DividerDark");
        if (EditorGUIUtility.isProSkin == true) divideTex = Resources.Load<Texture2D>("LukaResource_DividerPro");
        if (superUser == true) divideTex = Resources.Load<Texture2D>("LukaResource_DividerRainbow");
        if (vaporUser == true) divideTex = Resources.Load<Texture2D>("LukaResource_DividerVapor");
        GUI.DrawTexture(divideSpace, divideTex);
        EditorGUILayout.Space();
    }

    //applying if fx is used in titles
    private void currentlyToggled()
    {

        //easier to change to see what looks best
        string addonCheck = " " + settingsToggledOn;
        string betaCheck = " [beta]";
        string lockCheck = " [locked]";
        if (superUser) betaCheck = rainbowfy(betaCheck);
        //if(superUser) lockCheck = rainbowfy(lockCheck);
        if (vaporUser) betaCheck = vaporfy(betaCheck);

        //checking and applying


        //render stuff
        if(_OverallOpacity.floatValue < 1)
        {
            propStyles.DropdownRender.text = "Render Settings (Strength: " + _OverallOpacity.floatValue + ")";
        }
        else
        {
            propStyles.DropdownRender.text = "Render Settings";
        }


        //Falloff
        if (_AllowSmartFalloff.floatValue == 1)
        {
            propStyles.Falloff.text = "Falloff" + addonCheck;
            ntFalloff = true;
        }
        else
        {
            propStyles.Falloff.text = "Falloff";
            ntFalloff = false;
        }



        //Depth
        if (_AllowDepthTest.floatValue == 1)
        {
            propStyles.Depth.text = "Depth of Field" + addonCheck;
            ntDepthTest = true;
        }
        else
        {
            propStyles.Depth.text = "Depth of Field";
            ntDepthTest = false;
        }



        //Depth
        if (_ToggleRenderLookAtMe.floatValue == 1)
        {
            propStyles.RenderAtMe.text = "Only Render At Me" + addonCheck;
            ntRenderAtMe = true;
        }
        else
        {
            propStyles.RenderAtMe.text = "Only Render At Me";
            ntRenderAtMe = false;
        }



        //Tear
        if (_AllowTearFix.floatValue == 1 || _TearToMirror.floatValue == 1 || _TearToRepeat.floatValue == 1)
        {
            propStyles.Tear.text = "Screentear" + addonCheck;
            ntScreentear = true;
        }
        else
        {
            propStyles.Tear.text = "Screentear";
            ntScreentear = false;
        }



        //Sepia
        if (_SepiaStrength.floatValue > 0)
        {
            propStyles.BlackandWhite.text = "Black and White" + addonCheck;
            ntSepia = true;
        }
        else
        {
            propStyles.BlackandWhite.text = "Black and White";
            ntSepia = false;
        }



        //Invert
        if (_InvertStrength.floatValue > 0 || _InvertB.floatValue > 0 || _InvertG.floatValue > 0 || _InvertR.floatValue > 1)
        {
            propStyles.Invert.text = "Invert" + addonCheck;
            ntInvert = true;
        }
        else
        {
            propStyles.Invert.text = "Invert";
            ntInvert = false;
        }



        //Upside down
        if (_ToggleUpsideDown.floatValue > 0)
        {
            //propStyles.Screenspace.text = "Screenspace Options" + addonCheck;
            ntUpsideDown = true;
        }
        else
        {
            //propStyles.Screenspace.text = "Screenspace Options";
            ntUpsideDown = false;
        }



        //Screen flip
        if (_ToggleScreenFlip.floatValue > 0)
        {
            //propStyles.Screenspace.text = "Screenspace Options" + addonCheck;
            ntScreenFlip = true;
        }
        else
        {
            //propStyles.Screenspace.text = "Screenspace Options";
            ntScreenFlip = false;
        }



        //Screenspace options
        if (ntScreenFlip || ntUpsideDown)
        {
            propStyles.Screenspace.text = "Screenspace" + addonCheck;
            ntScreenspace = true;
        }
        else
        {
            propStyles.Screenspace.text = "Screenspace";
            ntScreenspace = false;
        }



        //Ascii
        if (_ToggleAscii.floatValue == 1)
        {
            propStyles.Ascii.text = "ASCII" + addonCheck;
            ntAscii = true;
        }
        else
        {
            propStyles.Ascii.text = "ASCII";
            ntAscii = false;
        }



        //Blink
        if (_ToggleBigZoom.floatValue > 0)
        {
            propStyles.BigBoxZoom.text = "Middle Zoom" + addonCheck;
            ntbigboxZoom = true;
        }
        else
        {
            propStyles.BigBoxZoom.text = "Middle Zoom";
            ntbigboxZoom = false;
        }



        //Blink
        if (_BlinkStrength.floatValue > 0)
        {
            propStyles.Blink.text = "Blink" + addonCheck;
            ntBlink = true;
        }
        else
        {
            propStyles.Blink.text = "Blink";
            ntBlink = false;
        }


        //Bloom // actually exposue
        //Color tint
        if (!(_BloomGlow.floatValue == 1))
        {
            propStyles.Bloom.text = "Exposure" + addonCheck;
            ntBloom = true;
        }
        else
        {
            propStyles.Bloom.text = "Exposure";
            ntBloom = false;
        }



        //Bloom
        if (_RBloomToggle.floatValue == 1)
        {
            propStyles.Bloom.text = "Bloom" + addonCheck;
            ntRBloom = true;
        }
        else
        {
            propStyles.Bloom.text = "Bloom";
            ntRBloom = false;
        }



        //Bulge
        if (_ToggleBulge.floatValue + _BulgeIndent.floatValue > 0)
        {
            propStyles.Bulge.text = "Bulge" + addonCheck;
            ntBulge = true;
        }
        else
        {
            propStyles.Bulge.text = "Bulge";
            ntBulge = false;
        }



        //Center zoom
        if (_ToggleZoom.floatValue == 1)
        {
            propStyles.CenteredZoom.text = "Focus Zoom" + addonCheck;
            ntZoom = true;
        }
        else
        {
            propStyles.CenteredZoom.text = "Focus Zoom";
            ntZoom = false;
        }



        //Color tint
        float rgbValue = _ColorRGB.colorValue.r + _ColorRGB.colorValue.g + _ColorRGB.colorValue.b;
        if (
           !(rgbValue == 3) ||
           (_ColorValue.floatValue > 0)  ||
           (_SolidTrans.floatValue > 0) ||
           ntDarken ||
           ntSepia ||
           ntGammaCorrect ||
           ntPosterize || 
           ntBloom ||
           ntInvert ||
           ntSaturation ||
           !(_VibrancePower.floatValue == 0) ||
           !(_ContrastValue.floatValue == 1) ||
           (_SepiaRStrength.floatValue > 0 ) ||
           _GradTrans.floatValue > 0)
        {
            propStyles.Color.text = "Coloring" + addonCheck;
            ntColorTint = true;
        }
        else
        {
            propStyles.Color.text = "Coloring";
            ntColorTint = false;
        }



        //Color split
        if (_ToggleColorSplit.floatValue == 1)
        {
            propStyles.ColorSplit.text = "Color Split" + addonCheck;
            ntColorSplit = true;
        }
        else
        {
            propStyles.ColorSplit.text = "Color Split";
            ntColorSplit = false;
        }



        //Corner spin
        if (_ToggleCC.floatValue > 0)
        {
            propStyles.CornerColor.text = "Color Spin" + addonCheck;
            ntCornerColor = true;
        }
        else
        {
            propStyles.CornerColor.text = "Color Spin";
            ntCornerColor = false;
        }


        //Toggle corner colors
        if ((_CornerOneTrans.floatValue > 0) || (_CornerTwoTrans.floatValue > 0) || (_CornerThreeTrans.floatValue > 0) || (_CornerFourTrans.floatValue > 0))
        {
            propStyles.Corners.text = "Corners" + addonCheck;
            ntCorners = true;
        }
        else
        {
            propStyles.Corners.text = "Corners";
            ntCorners = false;
        }

        //Darken
        if (_DarknessStrength.floatValue > 0)
        {
            propStyles.Darkness.text = "Darkness" + addonCheck;
            ntDarken = true;
        }
        else
        {
            propStyles.Darkness.text = "Darkness";
            ntDarken = false;
        }



        //Distort
        if (_ToggleDistortion.floatValue == 1)
        {
            propStyles.Distort.text = "Distortion" + addonCheck;
            ntDistort = true;
        }
        else
        {
            propStyles.Distort.text = "Distortion";
            ntDistort = false;
        }



        //Dizzy
        if (_ToggleDizzyEffect.floatValue == 1)
        {
            propStyles.Dizzy.text = "Dizzy" + addonCheck;
            ntDizzy = true;
        }
        else
        {
            propStyles.Dizzy.text = "Dizzy";
            ntDizzy = false;
        }



        //Droplet
        if (_ToggleDroplet.floatValue == 1)
        {
            propStyles.Droplet.text = "Color Droplet" + addonCheck;
            ntDroplet = true;
        }
        else
        {
            propStyles.Droplet.text = "Color Droplet";
            ntDroplet = false;
        }



        //Duotone
        if (_ToggleDuotone.floatValue > 0 )
        {
            propStyles.Duotone.text = "Duotone" + addonCheck;
            ntDuotone = true;
        }
        else
        {
            propStyles.Duotone.text = "Duotone";
            ntDuotone = false;
        }


        //Edge detection
        if (_ToggleED.floatValue == 1)
        {
            propStyles.EdgeDetection.text = "Colored Outline" + addonCheck;
            ntEdgeDetect = true;
        }
        else
        {
            propStyles.EdgeDetection.text = "Colored Outline";
            ntEdgeDetect = false;
        }



        //Edge background ~ doesnt affect overall edge tab cos if edge detect isnt enabled this does nothing 
        if(_EDBackPower.floatValue > 0)
        {
            propStyles.EdgeDetectionBackground.text = "Outline Background" + addonCheck;
            ntEdgeBackground = true;
        }
        else
        {
            propStyles.EdgeDetectionBackground.text = "Outline Background";
            ntEdgeBackground = false;
        }


        //Edge rainbow ~ doesnt affect overall edge tab cos if edge detect isnt enabled this does nothing 
        if (_EDToggleRainbow.floatValue > 0)
        {
            propStyles.EdgeRainbow.text = "Outline Rainbow" + addonCheck;
            ntEdgeRainbow = true;
        }
        else
        {
            propStyles.EdgeRainbow.text = "Outline Rainbow";
            ntEdgeRainbow = false;
        }


        //Edge ramp ~ doesnt affect overall edge tab cos if edge detect isnt enabled this does nothing 
        if (_EDRampAllow.floatValue == 1)
        {
            propStyles.EdgeDetectionRamp.text = "Outline Gradient" + addonCheck;
            ntEdgeRamp = true;
        }
        else
        {
            propStyles.EdgeDetectionRamp.text = "Outline Gradient";
            ntEdgeRamp = false;
        }


        //Edge dither ~ doesnt affect overall edge tab cos if edge detect isnt enabled this does nothing 
        if (_EDDither.floatValue > 0)
        {
            propStyles.EdgeDither.text = "Outline Dither" + addonCheck;
            ntEdgeRamp = true;
        }
        else
        {
            propStyles.EdgeDither.text = "Outline Dither";
            ntEdgeRamp = false;
        }


        //Edge distortion
        if (_ToggleEdgeDistort.floatValue == 1)
        {
            propStyles.EdgeDistort.text = "Edge Smear" + addonCheck;
            ntEdgeDistort = true;
        }
        else
        {
            propStyles.EdgeDistort.text = "Edge Smear";
            ntEdgeDistort = false;
        }


        //Fade projection
        if (_ToggleFadeProjection.floatValue == 1)
        {
            propStyles.Fade.text = "Fade Projection" + addonCheck;
            ntFadeProjection = true;
        }
        else
        {
            propStyles.Fade.text = "Fade Projection";
            ntFadeProjection = false;
        }



        //Filter
        if (_ToggleFilter.floatValue == 1)
        {
            propStyles.Filter.text = "Filter" + addonCheck;
            ntFilter = true;
        }
        else
        {
            propStyles.Filter.text = "Filter";
            ntFilter = false;
        }



        //Film
        if (_FilmPower.floatValue > 0)
        {
            propStyles.Film.text = "Film" + addonCheck;
            ntFilm = true;
        }
        else
        {
            propStyles.Film.text = "Film";
            ntFilm = false;
        }



        //Fog
        if (_ToggleFog.floatValue > 0)
        {
            propStyles.Fog.text = "Fog" + addonCheck;
            ntFog = true;
        }
        else
        {
            propStyles.Fog.text = "Fog";
            ntFog = false;
        }



        //Gamma correct
        if (!(_GammaBlue.floatValue == 0) || !(_GammaRed.floatValue == 0) || !(_GammaGreen.floatValue == 0))
        {
            propStyles.Gamma.text = "Gamma" + addonCheck;
            ntGammaCorrect = true;
        }
        else
        {
            propStyles.Gamma.text = "Gamma";
            ntGammaCorrect = false;
        }



        //Glitch
        if (_ToggleGlitch.floatValue == 1 || _ToggleRGBGlitch.floatValue == 1 || _ToggleBlockyGlitch.floatValue == 1 || _ToggleScanline.floatValue == 1 || _ToggleGirlscam.floatValue == 1 || ntPixelGlitch || _BGOverlayToggle.floatValue > 0)
        {
            propStyles.Glitch.text = "Glitches" + addonCheck;
            ntGlitch = true;
        }
        else
        {
            propStyles.Glitch.text = "Glitches";
            ntGlitch = false;
        }


        //RGB Glitch (for lock)
        if (_ToggleRGBGlitch.floatValue == 1){
            propStyles.RGBGlitch.text = "RGB Glitch";
            ntRGBGlitch = true;
        }else{
            propStyles.RGBGlitch.text = "RGB Glitch";
            //if(_ToggleRGB.floatValue == 1) propStyles.RGBGlitch.text = "RGB Glitch" + lockCheck;
            ntRGBGlitch = false;
        }


        //Inception
        if(_ToggleInception.floatValue > 0)
        {
            propStyles.Inceptions.text = "Inception" + betaCheck + addonCheck;
            ntInception = true;
        }
        else
        {
            propStyles.Inceptions.text = "Inception"  + betaCheck;
            ntInception = false;
        }


        //Mirror
        if (_ToggleMirror.floatValue == 1)
        {
            propStyles.Mirror.text = "Mirror" + addonCheck;
            ntMirror = true;
        }
        else
        {
            propStyles.Mirror.text = "Mirror";
            ntMirror = false;
        }



        //Multiscreen
        if (_ToggleScreens.floatValue > 0)
        {
            propStyles.MultipleScreen.text = "Screens" + addonCheck;
            ntMultiscreen = true;
        }
        else
        {
            propStyles.MultipleScreen.text = "Screens";
            ntMultiscreen = false;
        }



        //Noise mask
        if(_ToggleNoiseMask.floatValue > 0)
        {
            propStyles.NoiseMask.text = "Noise Mask" + addonCheck;
            ntNoiseMask = true;
        }
        else
        {
            propStyles.NoiseMask.text = "Noise Mask";
            ntNoiseMask = false;
        }



        //Overlay
        if (_ToggleOverlay.floatValue == 1)
        {
            propStyles.Overlay.text = "Image Overlays" + addonCheck;
            ntOverlay = true;
        }
        else
        {
            propStyles.Overlay.text = "Image Overlays";
            ntOverlay = false;
        }



        //Gif Overlay
        if (_ToggleGifOverlay.floatValue == 1)
        {
            propStyles.GifOverlay.text = "GIF Overlay" + addonCheck;
            ntGifOverlay = true;
        }
        else
        {
            propStyles.GifOverlay.text = "GIF Overlay";
            ntGifOverlay = false;
        }



        //Linocut
        if (_LinocutOpacity.floatValue > 0)
        {
            propStyles.Linocut.text = "Linocut" + addonCheck;
            ntLinocut = true;
        }
        else
        {
            propStyles.Linocut.text = "Linocut";
            ntLinocut = false;
        }



        //Outline
        if (_ToggleOutline.floatValue > 0)
        {
            propStyles.Outline.text = "Neon Outline" + addonCheck;
            ntOutline = true;
        }
        else
        {
            propStyles.Outline.text = "Neon Outline";
            ntOutline = false;
        }



        //HSV Rainbow
        if (_ToggleHSVRainbow.floatValue > 0)
        {
            propStyles.Rainbow.text = "Rainbow" + addonCheck;
            ntHSVRainbow = true;
        }
        else
        {
            propStyles.Rainbow.text = "Rainbow";
            ntHSVRainbow = false;
        }


        //All radial
        if (_ToggleRadialBlur.floatValue == 1)
        {
            propStyles.AllRadial.text = "Radial" + addonCheck;
            ntRadial = true;
        }
        else
        {
            propStyles.AllRadial.text = "Radial";
            //if(ntBlur) propStyles.AllRadial.text = "Radial" + lockCheck;
            ntRadial = false;
        }

        //Ramp effect
        if (_ToggleRampEffect.floatValue > 0)
        {
            propStyles.Ramp.text = "Ramp" + addonCheck;
            ntRampEffect = true;
        }
        else
        {
            propStyles.Ramp.text = "Ramp";
            ntRampEffect = false;
        }



        //Recolor
        if (_ToggleRecolor.floatValue == 1)
        {
            propStyles.Recolor.text = "Hue Shift" + addonCheck;
            ntRecolor = true;
        }
        else
        {
            propStyles.Recolor.text = "Hue Shift";
            ntRecolor = false;
        }



        //RGB
        if (_ToggleRGB.floatValue == 1)
        {
            propStyles.RGB.text = "Chromatic Abberation" + addonCheck;
            ntRGB = true;
        }
        else
        {
            propStyles.RGB.text = "Chromatic Abberation";
            //if(_ToggleRGBGlitch.floatValue == 1) propStyles.RGB.text = "Chromatic Abberation" + lockCheck;
            ntRGB = false;
        }



        //RGB Zoom
        if (_ToggleRGBZoom.floatValue == 1)
        {
            propStyles.RGBZoom.text = "RGB Projection" + addonCheck;
            ntRGBZoom = true;
        }
        else
        {
            propStyles.RGBZoom.text = "RGB Projection";
            ntRGBZoom = false;
        }



        //Ripple
        if (_ToggleRipple.floatValue == 1)
        {
            propStyles.Ripple.text = "Ripple" + addonCheck;
            ntRipple = true;
        }
        else
        {
            propStyles.Ripple.text = "Ripple";
            ntRipple = false;
        }



        //Rotater
        if (_ToggleRotater.floatValue == 1)
        {
            propStyles.Rotate.text = "Rotate" + addonCheck;
            ntRotater = true;
        }
        else
        {
            propStyles.Rotate.text = "Rotate";
            ntRotater = false;
        }



        //Pixelate
        if (_TogglePixelate.floatValue == 1)
        {
            propStyles.Pixelate.text = "Pixelate" + addonCheck;
            ntPixelate = true;
        }
        else
        {
            propStyles.Pixelate.text = "Pixelate";
            ntPixelate = false;
        }



        //Glitchy Pixelate
        if (_GTogglePixelate.floatValue == 1)
        {
            propStyles.PixelateGlitch.text = "Pixelate Glitch" + addonCheck;
            ntPixelGlitch = true;
        }
        else
        {
            propStyles.PixelateGlitch.text = "Pixelate Glitch";
            ntPixelGlitch = false;
        }



        //Posterize
        if (_PosterizeValue.floatValue > -100)
        {
            propStyles.Posterize.text = "Posterize" + addonCheck;
            ntPosterize = true;
        }
        else {
            propStyles.Posterize.text = "Posterize";
            ntPosterize = false;
        }


        //Saturation
        if (!(_SaturationValue.floatValue == 1))
        {
            propStyles.Saturation.text = "Saturation" + addonCheck;
            ntSaturation = true;
        }
        else
        {
            propStyles.Saturation.text = "Saturation";
            ntSaturation = false;
        }



        //Screenpull
        if (!(_ScrollX.floatValue == 0) || !(_ScrollY.floatValue == 0))
        {
            propStyles.Scroll.text = "Scroll" + addonCheck;
            ntScroll = true;
        }
        else
        {
            propStyles.Scroll.text = "Scroll";
            ntScroll = false;
        }



        //Screenpull
        if (_ToggleScreenpull.floatValue == 1)
        {
            propStyles.Screenpull.text = "Push" + addonCheck;
            ntScreenpull = true;
        }
        else
        {
            propStyles.Screenpull.text = "Push";
            ntScreenpull = false;
        }


        //apart
        if(_Apart.floatValue > 0)
        {
            propStyles.Apart.text = "Apart" + addonCheck;
            ntApart = true;
        }
        else
        {
            propStyles.Apart.text = "Apart";
            ntApart = false;
        }


        //Screen zoome
        if (_ToggleScreenZoom.floatValue == 1)
        {
            propStyles.ScreenZoom.text = "Screen Zoom" + addonCheck;
            ntScreenzoom = true;
        }
        else
        {
            propStyles.ScreenZoom.text = "Screen Zoom";
            ntScreenzoom = false;
        }


        //Shake
        if (_ToggleShake.floatValue == 1)
        {
            propStyles.Shake.text = "Shake" + addonCheck;
            ntShake = true;
        }
        else
        {
            propStyles.Shake.text = "Shake";
            ntShake = false;
        }



        //Smear
        if (_ToggleSmear.floatValue == 1)
        {
            propStyles.Smear.text = "Smear" + addonCheck;
            ntSmear = true;
        }
        else
        {
            propStyles.Smear.text = "Smear";
            ntSmear = false;
        }



        //Swirl
        if (_ToggleSwirl.floatValue == 1)
        {
            propStyles.Swirl.text = "Spiral" + addonCheck;
            ntSwirl = true;
        }
        else
        {
            propStyles.Swirl.text = "Spiral";
            ntSwirl = false;
        }



        //Splice
        if (_ToggleSplice.floatValue == 1)
        {
            propStyles.Splice.text = "Splice" + addonCheck;
            ntSplice = true;
        }
        else
        {
            propStyles.Splice.text = "Splice";
            ntSplice = false;
        }



        //Sihhouette
        if (_ToggleSilhouette.floatValue == 1)
        {
            propStyles.Silhouette.text = "Silhouette" + addonCheck;
            ntSilhouette = true;
        }
        else
        {
            propStyles.Silhouette.text = "Silhouette";
            ntSilhouette = false;
        }



        //Noise
        if (_ToggleNoise.floatValue == 1)
        {
            propStyles.Static.text = "Grain" + addonCheck;
            ntNoise = true;
        }
        else
        {
            propStyles.Static.text = "Grain";
            ntNoise = false;
        }



        //Thermal
        if (_ThermalTransparency.floatValue > 0)
        {
            propStyles.Thermal.text = "Thermal" + addonCheck;
            ntThermal = true;
        }
        else
        {
            propStyles.Thermal.text = "Thermal";
            ntThermal = false;
        }



        //Transistion
        if (_ToggleTransistion.floatValue == 1)
        {
            propStyles.Transistion.text = "Transition" + addonCheck;
            ntTransistion = true;
        }
        else
        {
            propStyles.Transistion.text = "Transition";
            ntTransistion = false;
        }



        //VHS
        if (_ToggleVHS.floatValue == 1)
        {
            propStyles.VHS.text = "VHS" + addonCheck;
            ntVHS = true;
        }
        else
        {
            propStyles.VHS.text = "VHS";
            ntVHS = false;
        }



        //Vignette
        if (_ToggleVignette.floatValue > 0)
        {
            propStyles.Vignette.text = "Vignette" + addonCheck;
            ntVignette = true;
        }
        else
        {
            propStyles.Vignette.text = "Vignette";
            ntVignette = false;
        }



        //Visualizer
        if (_ToggleVisualizer.floatValue == 1)
        {
            propStyles.Visualizer.text = "Visualizer" + addonCheck;
            ntVisualizer = true;
        }
        else
        {
            propStyles.Visualizer.text = "Visualizer";
            ntVisualizer = false;
        }



        //VR
        if (!(_VRAdjust.floatValue == 1) || _VRLeft.floatValue == 1 || _VRRight.floatValue == 1)
        {
            propStyles.VR.text = "VR Adjustments" + addonCheck;
            ntVisualizer = true;
        }
        else
        {
            propStyles.VR.text = "VR Adjustments";
            ntVisualizer = false;
        }



        //Warp zoom
        if (_ToggleWarpZoom.floatValue == 1)
        {
            propStyles.WarpZoom.text = "Fisheye Zoom" + addonCheck;
            ntWarpZoom = true;
        }
        else
        {
            propStyles.WarpZoom.text = "Fisheye Zoom";
            ntWarpZoom = false;
        }


        //wavey
        if(_ToggleWavey.floatValue == 1){
            propStyles.Wavey.text = "Wavey" + addonCheck;
            ntWavey = true;
        }else
        {
            propStyles.Wavey.text = "Wavey";
            ntWavey = false;
        }


        //Deepfry
        if (_ToggleDeepfry.floatValue == 1)
        {
            propStyles.Deepfry.text = "Deepfry" + addonCheck;
            ntDeepfry = true;
        }
        else
        {
            propStyles.Deepfry.text = "Deepfry";
            ntDeepfry = false;
        }





        //All stuff

        //All zooms
        if (ntZoom || ntbigboxZoom || ntScreenzoom || ntWarpZoom)
        {
            propStyles.AllZooms.text = "Zooms" + addonCheck;
            ntAllZooms = true;
        }
        else
        {
            propStyles.AllZooms.text = "Zooms";
            ntAllZooms = false;
        }


        //All blurs
        if (_ToggleNBlur.floatValue == 1)
        {
            propStyles.Blur.text = "Blur" + addonCheck;
            ntBlur = true;
        }
        else
        {
            propStyles.Blur.text = "Blur";
            //if(ntRadial) propStyles.Blur.text = "Blur" + lockCheck;
            ntBlur = false;
        }


        //All outlines
        if (ntEdgeDetect || ntRadialOutline || ntEdgeProject || ntOutline)
        {
            propStyles.AllOutlines.text = "Outlines" + addonCheck;
            ntAllOutlines = true;
        }
        else
        {
            propStyles.AllOutlines.text = "Outlines";
            ntAllOutlines = false;
        }


        //All shakes
        if (ntShake)
        {
            propStyles.AllShakes.text = "Shake" + addonCheck;
            ntAllShakes = true;
        }
        else
        {
            propStyles.AllShakes.text = "Shake";
            ntAllShakes = false;
        }

        //All distorts
        if (ntDistort || ntRipple || ntSwirl || ntWavey)
        {
            propStyles.AllDistort.text = "Distortions" + addonCheck;
            ntAllDistort = true;
        }
        else
        {
            propStyles.AllDistort.text = "Distortions";
            ntAllDistort = false;
        }


    }

    //no image error
    private void noImageError(String imgName)
    {
        for (int i = 0; i < 5; i++) EditorGUILayout.Space();
        GUILayout.Label("ERROR! The shader was unable to load the image: " + imgName, headernameStyle);
        for (int i = 0; i < 10; i++) EditorGUILayout.Space();
    }

    //applying dark or light theme text
    private static void generateMessage(String textToDis, GUIStyle textStyle)
    {
        String colorModifier = "000000";
        if (EditorGUIUtility.isProSkin == true) colorModifier = "B4B4B4";
        if (superUser)
        {
            GUILayout.Label(rainbowfy(textToDis), textStyle);
        }
        else if (vaporUser)
        {
            GUILayout.Label(vaporfy(textToDis), textStyle);
        }
        else
        {
            GUILayout.Label("<color=#" + colorModifier + ">" + textToDis + "</color>", textStyle);
        }
    }

    //applying dark or light theme text with spacing 
    private void generateSection(String textToDis, GUIStyle textStyle)
    {
        EditorGUILayout.Space();
        generateMessage(textToDis, textStyle);
        EditorGUILayout.Space();
    }

    //creating social bar with my media to be used in multiple menus
    private void drawSocialBar(String formatShape)
    {
        //starting 
        GUILayout.BeginHorizontal(formatShape);
        GUILayout.FlexibleSpace();
        Texture iconGithub = (Texture)Resources.Load<Texture2D>("LukaResource_IconGithub");
        GUIContent buttonGithub = new GUIContent(iconGithub);
        if (GUILayout.Button(buttonGithub, GUILayout.Width(70), GUILayout.Height(70)))
        {
            // Debug.Log("<color=magenta>luka mega:</color> github opened!");
            System.Diagnostics.Process.Start("https://github.com/lukasong");
        }
        Texture iconWebsite = (Texture)Resources.Load<Texture2D>("LukaResource_IconLuka");
        GUIContent buttonWebsite = new GUIContent(iconWebsite);
        if (GUILayout.Button(buttonWebsite, GUILayout.Width(70), GUILayout.Height(70)))
        {
            System.Diagnostics.Process.Start("http://www.luka.moe");
        }
        Texture iconDiscord = (Texture)Resources.Load<Texture2D>("LukaResource_IconDiscord");
        GUIContent buttonDiscord = new GUIContent(iconDiscord);
        if (GUILayout.Button(buttonDiscord, GUILayout.Width(70), GUILayout.Height(70)))
        {
            EditorUtility.DisplayDialog("uwu add me on discord", "my discord is: luka#8375", "okay, awesome");
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }
    #endregion 


    //=== menu bar ===
    #region menubar
#if UNITY_EDITOR
    /*[MenuItem("luka/verify: auth key validated", false, 0)]
    static void LukaMenuVerify()
    {
        EditorUtility.DisplayDialog("luka mega shader", "Your shader is authenticated!" +
            "\nAuth Key: " + authKey +
            "\nAuth User: " + authUser +
            "\nAuthentication is hardware ID and IP secure c:", "okay, neat");
    }*/
    [MenuItem("luka/version: unr11.0", false, 0)]
    static void LukaMenuVersion()
    {
        String latest = checkUpdate();
        String message = "\nLatest version: " + latest + ", check the Discord for more info!";
        if (latest.Equals(versionNumber))
        {
            message = "\nYou are up to date!";
        }
        EditorUtility.DisplayDialog("luka mega shader", "You are currently using " + shaderVersionNumber + versionNumber + ".\n" +
            "Your copy wast last updated " + shaderUpdate + "." +
            message, "okay, cool");
    }
    [MenuItem("luka/create new shader cube", false, 11)]
    static void LukaMenuCube()
    {
        Boolean directExist = Directory.Exists(filesDirectory + "/Materials/");
        if (!directExist) Directory.CreateDirectory(filesDirectory + "/Materials/");
        Material createdMaterial = new Material(Shader.Find(shaderDirectory));
        String matName = "Luka Gen";
        int matCounter = 0;
        while (AssetDatabase.GetMainAssetTypeAtPath(filesDirectory + "/Materials/" + matName + " " + matCounter + ".mat") != null) matCounter++;
        matName += " " + matCounter;
        AssetDatabase.CreateAsset(createdMaterial, filesDirectory + "/Materials/" + matName + ".mat");
        GameObject createdCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        createdCube.SetActive(true);
        createdCube.transform.position = new Vector3(0, 0, 0);
        createdCube.transform.localScale = new Vector3(20, 20, 20);
        createdCube.GetComponent<Renderer>().material = createdMaterial;
        createdCube.GetComponent<Renderer>().receiveShadows = false;
        createdCube.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        UnityEngine.Object.DestroyImmediate(createdCube.GetComponent<BoxCollider>());
        createdCube.name = "Luka Mega Cube " + matCounter;
    }
    [MenuItem("luka/create new shader sphere", false, 11)]
    static void LukaMenuSphere()
    {
        Boolean directExist = Directory.Exists(filesDirectory + "/Materials/");
        if (!directExist) Directory.CreateDirectory(filesDirectory + "/Materials/");
        Material createdMaterial = new Material(Shader.Find(shaderDirectory));
        String matName = "Luka Gen";
        int matCounter = 0;
        while (AssetDatabase.GetMainAssetTypeAtPath(filesDirectory + "/Materials/" + matName + " " + matCounter + ".mat") != null) matCounter++;
        matName += " " + matCounter;
        AssetDatabase.CreateAsset(createdMaterial, filesDirectory + "/Materials/" + matName + ".mat");
        GameObject createdCube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        createdCube.SetActive(true);
        createdCube.transform.position = new Vector3(0, 0, 0);
        createdCube.transform.localScale = new Vector3(20, 20, 20);
        createdCube.GetComponent<Renderer>().material = createdMaterial;
        createdCube.GetComponent<Renderer>().receiveShadows = false;
        createdCube.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        UnityEngine.Object.DestroyImmediate(createdCube.GetComponent<SphereCollider>());
        createdCube.name = "Luka Mega Sphere " + matCounter;
    }
    [MenuItem("luka/luka.moe", false, 22)]
    static void LukaMenuSite()
    {
        System.Diagnostics.Process.Start("http://www.luka.moe");
    }
    /*[MenuItem("luka/luka.moe/feedback", false, 22)]
    static void LukaMenuFeedback()
    {
       
    }
    [MenuItem("luka/luka.moe/see changelog", false, 22)]
    static void LukaMenuChangelog()
    {
        
    }*/
    [MenuItem("luka/luka#8375", false, 22)]
    static void LukaMenuDiscord()
    {
        EditorUtility.DisplayDialog("luka mega shader", "feel free to add me on discord c:", "okay, maybe");
    }
#endif
    #endregion


    //== settings ==
    #region settings

    //read/write settings
    private static void loadSettings()
    {
        //setting up
        String userRoaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        String directoryPath = userRoaming + "/" + myFullUsername;
        String optionPath = directoryPath + "/lukaOptions.txt";


        //directory exist?
        Boolean directExist = Directory.Exists(directoryPath);
        if (!directExist)
        {
            Directory.CreateDirectory(directoryPath);
        }

        //file exist?
        Boolean fileExist = File.Exists(optionPath);
        if (!fileExist)
        {
            //writings
            String blankContents = "" +
                "showChange=true\n" +
                "activeDisplay=(enabled)\n" +
                "menuUgly=false\n" +
                "particleDefault=false\n" +
                "ver=" + versionNumber;
            System.IO.File.WriteAllText(optionPath, blankContents);

            //setting values
            showChange = true;
            activeDisplay = "(enabled)";
            menuUgly = false;
            particleDefault = false;

        }
        else
        {
            //reading
            System.IO.StreamReader file = new System.IO.StreamReader(optionPath);
            String readLine;
            int readCounter = 0;
            while ((readLine = file.ReadLine()) != null)
            {
                readCounter++;
                switch (readCounter)
                {
                    case 1:
                        if (readLine.ToLower().Contains("true")) showChange = true; else showChange = false;
                        break;
                    case 2:
                        activeDisplay = readLine.Substring(14);
                        if (superUser) activeDisplay = rainbowfy(activeDisplay);
                        if (vaporUser) activeDisplay = vaporfy(activeDisplay);                 
                        break;
                    case 3:
                        if (readLine.ToLower().Contains("true")) menuUgly = true; else menuUgly = false;
                        break;
                    case 4:
                        if (readLine.ToLower().Contains("true")) particleDefault = true; else particleDefault = false;
                        break;
                    case 5:
                        safetyVersion = readLine.Substring(4); //safety version not needed in 11
                        break;
                    default:
                        Debug.Log("<color=magenta><b> " +shaderDirectory  + " </b></color>: There was an error reading the options file: no case found!");
                        break;
                }
            }
        }
    }

    //update settings
    private static void updateSettings(String newSetting, int caseSetting)
    {
        //setting up
        String userRoaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        String directoryPath = userRoaming + "/" + myFullUsername;
        String optionPath = directoryPath + "/lukaOptions.txt";

        //what setting to update?
        switch (caseSetting)
        {

            case 1:
                showChange = Boolean.Parse(newSetting);
                break;
            case 2:
                activeDisplay = newSetting;
                settingsToggledOn = activeDisplay;
                if (superUser) settingsToggledOn = rainbowfy(settingsToggledOn);
                if (vaporUser) settingsToggledOn = vaporfy(settingsToggledOn);
                break;
            case 3:
                menuUgly = Boolean.Parse(newSetting);
                break;
            case 4:
                particleDefault = Boolean.Parse(newSetting);
                break;
            default:
                Debug.Log("<color=magenta><b> " + shaderDirectory + " </b></color>: There was an error updating the options file: no case found!");
                break;

        }

        //rewriting the settings
        String newContents = "" +
            "showChange=" + showChange + "\n" +
            "activeDisplay=" + activeDisplay + "\n" +
            "menuUgly=" + menuUgly + "\n" +
            "particleDefault=" + particleDefault + "\n" +
            "ver=" + versionNumber;
        System.IO.File.WriteAllText(optionPath, newContents);


    }

    //read/write superuser settings
    private static void loadSuperuser()
    {
        //setting up
        String userRoaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        String directoryPath = userRoaming + "/" + myFullUsername;
        String superPath = directoryPath + "/superUserStatus.txt";

        //directory exist?
        Boolean directExist = Directory.Exists(directoryPath);
        if (!directExist)
        {
            Directory.CreateDirectory(directoryPath);
        }

        //file exist?
        Boolean fileExist = File.Exists(superPath);
        if (!fileExist)
        {
            //writings
            String blankContents = "false";
            System.IO.File.WriteAllText(superPath, blankContents);

            //setting values
            superUser = false;
        }
        else
        {
            //reading
            System.IO.StreamReader file = new System.IO.StreamReader(superPath);
            String readLine;
            while ((readLine = file.ReadLine()) != null)
            {
                if (readLine.ToLower().Equals("true"))
                    superUser = true;
                else
                    superUser = false;
            }
        }
    }

    //update settings
    private static void updateSuperuser(String newSetting)
    {
        //setting up
        String userRoaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        String directoryPath = userRoaming + "/" + myFullUsername;
        String superPath = directoryPath + "/superUserStatus.txt";

        //rewriting the settings and updating
        String newContents = newSetting;
        System.IO.File.WriteAllText(superPath, newContents);
        superUser = Boolean.Parse(newContents);
    }

    //read/write vaporwave settings
    private static void loadVapor()
    {
        //setting up
        String userRoaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        String directoryPath = userRoaming + "/" + myFullUsername;
        String superPath = directoryPath + "/80sUserStatus.txt";

        //directory exist?
        Boolean directExist = Directory.Exists(directoryPath);
        if (!directExist)
        {
            Directory.CreateDirectory(directoryPath);
        }

        //file exist?
        Boolean fileExist = File.Exists(superPath);
        if (!fileExist)
        {
            //writings
            String blankContents = "false";
            System.IO.File.WriteAllText(superPath, blankContents);

            //setting values
            vaporUser = false;
        }
        else
        {
            //reading
            System.IO.StreamReader file = new System.IO.StreamReader(superPath);
            String readLine;
            while ((readLine = file.ReadLine()) != null)
            {
                if (readLine.ToLower().Equals("true"))
                    vaporUser = true;
                else
                    vaporUser = false;
            }
        }
    }

    //update settings
    private static void updateVapor(String newSetting)
    {
        //setting up
        String userRoaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        String directoryPath = userRoaming + "/" + myFullUsername;
        String superPath = directoryPath + "/80sUserStatus.txt";

        //rewriting the settings and updating
        String newContents = newSetting;
        System.IO.File.WriteAllText(superPath, newContents);
        vaporUser = Boolean.Parse(newContents);
    }
    #endregion


    //=== security === 
    #region security

    //eula check
    private static Boolean eulaCheck()
    {

        //setting up
        Boolean eulaStatus = false;
        String userRoaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        String directoryPath = userRoaming + "/" + myFullUsername;
        String eulaPath = directoryPath + "/lukaEULA.txt";


        //directory exist?
        Boolean directExist = Directory.Exists(directoryPath);
        if (!directExist)
        {
            Directory.CreateDirectory(directoryPath);
        }

        //file exist?
        Boolean fileExist = File.Exists(eulaPath);
        if (!fileExist)
        {
            //writings
            String blankContents = "lukaEulaStatus=false";
            System.IO.File.WriteAllText(eulaPath, blankContents);
        }
        else
        {
            //reading
            String readContents = File.ReadAllText(eulaPath).ToLower();
            if (readContents.Contains("true") && !readContents.Contains("false")) eulaStatus = true;
        }


        return eulaStatus;
    }

    //agree to eula
    private void eulaAgree()
    {
        //setting up
        String userRoaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        String directoryPath = userRoaming + "/" + myFullUsername;
        String eulaPath = directoryPath + "/lukaEULA.txt";

        //writings
        String blankContents = "lukaEulaStatus=true";
        System.IO.File.WriteAllText(eulaPath, blankContents);

    }
    #endregion


    //== changelog ==
    #region changelog

    //changelog check
    private static void checkChangelog()
    {

        //setting up
        String userRoaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        String directoryPath = userRoaming + "/" + myFullUsername;
        String changelogPath = directoryPath + "/lukaChangelog11.txt";


        //directory exist?
        Boolean directExist = Directory.Exists(directoryPath);
        if (!directExist)
        {
            Directory.CreateDirectory(directoryPath);
        }

        //file exist?
        Boolean fileExist = File.Exists(changelogPath);
        if (!fileExist)
        {
            //writings
            String blankContents = "lukaChangelogStatus=false";
            System.IO.File.WriteAllText(changelogPath, blankContents);
            displayChangelog = false;
        }
        else
        {
            //reading
            String readContents = File.ReadAllText(changelogPath).ToLower();
            if (readContents.Contains("true") && !readContents.Contains("false")) displayChangelog = true; else displayChangelog = false;
        }

    }

    //agree to eula
    private static void changelogAcknowledge()
    {
        //setting up
        String userRoaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        String directoryPath = userRoaming + "/" + myFullUsername;
        String changelogPath = directoryPath + "/lukaChangelog11.txt";

        //writings
        String blankContents = "lukaChangelogStatus=true";
        System.IO.File.WriteAllText(changelogPath, blankContents);

    }
    #endregion


    //== loading on startup ==
    #region startup

    [InitializeOnLoad]
    public class Startup
    {
        static Startup()
        {
            loadSuperuser(); //superuser? uwu
            loadVapor(); //vaporwave? owo
            displayEula = !eulaCheck(); //loading eula
            loadSettings(); //loading settings
            checkChangelog(); //to display changelog
            settingsToggledOn = activeDisplay; //setting toggled on
            if (!checkUpdate().Equals(versionNumber)) needToUpdate = true;
        }
    }
    #endregion


    //== helper functions ==
    #region helper 

    private ArrayList GrabProperties(Material targetMat, Shader thisShader)
    {

        //building array list of properties
        ArrayList shaderProperties = new ArrayList();
        for (int i = 0; i < ShaderUtil.GetPropertyCount(thisShader); i++)
        {
            if (!ShaderUtil.IsShaderPropertyHidden(thisShader, i) && ShaderUtil.GetPropertyType(thisShader, i) != ShaderUtil.ShaderPropertyType.TexEnv)
            {
                shaderProperties.Add(ShaderUtil.GetPropertyName(thisShader, i));
            }
        }

        //returning
        return shaderProperties;

    }

    private ArrayList GrabDescriptions(Material targetMat, Shader thisShader)
    {

        //building array list of properties
        ArrayList shaderProperties = new ArrayList();
        for (int i = 0; i < ShaderUtil.GetPropertyCount(thisShader); i++)
        {
            if (!ShaderUtil.IsShaderPropertyHidden(thisShader, i) && ShaderUtil.GetPropertyType(thisShader, i) != ShaderUtil.ShaderPropertyType.TexEnv)
            {
                shaderProperties.Add(ShaderUtil.GetPropertyDescription(thisShader, i));
            }
        }

        //returning
        return shaderProperties;

    }

    private float bomo(double min, double max)
    {
        System.Random bomoRandom = new System.Random();
        double randomNumber = bomoRandom.NextDouble() * (max - min) + min;
        float randomReturn = (float)randomNumber;
        return randomReturn;
    }

    private static String rainbowfy(String messageToRainbowfy)
    {
        messageToRainbowfy = System.Text.RegularExpressions.Regex.Replace(messageToRainbowfy, "<.*?>", String.Empty);
        int stringLength = messageToRainbowfy.Length;
        String rainbowRebuild = "";
        int currentROYGBIVslot = 0;
        for(int i = 0; i < stringLength; i++)
        {
            currentROYGBIVslot++;
            if (currentROYGBIVslot > 7) currentROYGBIVslot = 1;
            String currentLetter = Char.ToString(messageToRainbowfy[i]);
            if (currentLetter.Equals(" ")) currentROYGBIVslot--;
            String currentColour = "";
            switch (currentROYGBIVslot)
            {
                case 1:
                    currentColour = "<color=#e52e07>";
                    break;
                case 2:
                    currentColour = "<color=#dda20f>";
                    break;
                case 3:
                    currentColour = "<color=#E9EF37>";
                    break;
                case 4:
                    currentColour = "<color=#05b02f>";
                    break;
                case 5:
                    currentColour = "<color=#12a7db>";
                    break;
                case 6:
                    currentColour = "<color=#ae2dfe>";
                    break;
                case 7:
                    currentColour = "<color=#b00591>";
                    break;
                default:
                    currentColour = "<color=#e52e07>";
                    break;
            }
            currentLetter = currentColour + currentLetter + "</color>";
            rainbowRebuild += currentLetter;
        }
        return rainbowRebuild;
    }

    private static String vaporfy(String messageToVaporfy)
    {
        messageToVaporfy = System.Text.RegularExpressions.Regex.Replace(messageToVaporfy, "<.*?>", String.Empty);
        int stringLength = messageToVaporfy.Length;
        String vaporRebuild = "";
        int currentROYGBIVslot = 0;
        for (int i = 0; i < stringLength; i++)
        {
            currentROYGBIVslot++;
            if (currentROYGBIVslot > 5) currentROYGBIVslot = 1;
            String currentLetter = Char.ToString(messageToVaporfy[i]);
            if (currentLetter.Equals(" ")) currentROYGBIVslot--;
            String currentColour = "";
            switch (currentROYGBIVslot)
            {
                //color pallete from u/-Space-Cadet- on r/Outrun
                case 1:
                    currentColour = "<color=#0350c4>";//old = 023788 too dark
                    break;
                case 2:
                    currentColour = "<color=#650D89>";
                    break;
                case 3:
                    currentColour = "<color=#920075>";
                    break;
                case 4:
                    currentColour = "<color=#F6019D>";
                    break;
                case 5:
                    currentColour = "<color=#D40078>";
                    break;
                default:
                    currentColour = "<color=#023788>";
                    break;
            }
            currentLetter = currentColour + currentLetter + "</color>";
            vaporRebuild += currentLetter;
        }
        return vaporRebuild;
    }

    private static void lockMessage(String effectName, String conflictingEffects, bool multipleEffects){
         string singlePlural = "is";
         string amountIndicator = "";
         if(multipleEffects){
            singlePlural = "are"; 
            amountIndicator = "s";
         }
        //if(!particleDefault) EditorUtility.DisplayDialog(shaderName, effectName + " is locked because " + conflictingEffects + " " + singlePlural + " enabled. To use " + effectName + ", disable the conflicting effect" + amountIndicator + ". These notificaitons can be disabled from the settings menu.", okButton);
        EditorGUILayout.Space();
        if (!particleDefault) generateMessage(effectName + " cannot be used because " + conflictingEffects + " " + singlePlural + " enabled. \nTo use " + effectName + ", disable the conflicting effect" + amountIndicator + ".\n These notificaitons can be disabled \nfrom the settings menu.", friendStyle);
    }

    private static void drawDepth(bool drawSafe){
            EditorGUILayout.Space();
            drawDivider();
            EditorGUILayout.Space();
            String safeInfo = "";
            if(drawSafe) safeInfo = "\nWant to create a safe space around you?\nUse the depth effect.";
            generateMessage("This is a depth effect!\nIt requires a depth light." + safeInfo + "\nTo preview in Unity,\nhit the light in the scene toolbar.", friendStyle);
            EditorGUILayout.Space();
            drawDivider();
            EditorGUILayout.Space();
    }
    
    private static String checkUpdate()
    {
        try
        {
            String latestURL = "http://luka.moe/api/lukashaderversion.html";
            String shaderVersion = (new WebClient()).DownloadString(latestURL).ToString();
            return shaderVersion;
        }catch(Exception e)
        {
            Debug.Log("Can't connect to luka#8375 server.. setting latest version as " + versionNumber);
            return versionNumber;
        }
    }
    #endregion


    //=== writing the gui ===


    //drawing GUI
    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
    {

        //gui tint
        //GUI.color = new Color(255, 255, 255);


        //render the default gui
        Material targetMat = materialEditor.target as Material;


        //preparing to draw the gui
        defineStyles(); 
        prepareGUI();
        //propertyQuery

        //auth for display
        Boolean displayAuth = false;


        //eula menu s
        if (displayEula)
        {
            //displaying eula 

            //my tag
            EditorGUILayout.Space();
            var lukaTagSpace = GUILayoutUtility.GetRect(0, int.MaxValue, 85, 30);
            Texture2D lukaTagTex = Resources.Load<Texture2D>("LukaResource_EditorBanner");
            EditorGUI.DrawPreviewTexture(lukaTagSpace, lukaTagTex, null, ScaleMode.ScaleAndCrop);
            EditorGUILayout.Space();

            //header
            EditorGUILayout.Space();
            generateMessage("luka's mega after effects " + shaderVersionNumber + versionNumber, helpHeaderStyle);
            generateMessage("hey! it looks like it is your first time using the shader!" +
                "\nplease read and agree to these terms! After you agree this time," +
                "\nyou will never see this message again. c:", helpInfoStyle);

            //terms
            EditorGUILayout.Space();
            drawDivider();
            EditorGUILayout.Space();
            generateMessage("by using the shader, you <b>agree to the following terms</b>" +
                "\n- distribution, in ANY format, is prohibited" +
                "\n- the code is NOT to be reused or shared in any format" +
                "\n\nhowever, you are <b>allowed to</b>" +
                "\n- sell avatar uploads with the shader" +
                "\n- modify the code for personal use" +
                "\n\nby hitting <b>i agree</b> you fully agree\nand will be held responsible." +
                "\nshader includes cgincludes and gui", helpInfoStyle);
            EditorGUILayout.Space();
            drawDivider();
            EditorGUILayout.Space();

            //button to agree
            EditorGUILayout.Space();
            var agreeButtonSpace = GUILayoutUtility.GetRect(0, int.MaxValue, 15, 10);
            Boolean agreeButton = GUI.Button(agreeButtonSpace, "i agree! uwu");
            if (agreeButton)
            {
                eulaAgree();
                agreeButton = false;
                displayEula = !eulaCheck();
            }

            //nadeshiko
            var nadeSpace = GUILayoutUtility.GetRect(100, int.MaxValue, 200, 100);
            Texture2D nadeTex = Resources.Load<Texture2D>("LukaResource_EulaReadStandard");
            if (EditorGUIUtility.isProSkin == true) nadeTex = Resources.Load<Texture2D>("LukaResource_EulaReadPro");
            EditorGUI.DrawPreviewTexture(nadeSpace, nadeTex, null, ScaleMode.ScaleToFit);
            EditorGUILayout.Space();

            //social bar
            EditorGUILayout.Space();
            drawSocialBar("box");




            drawDivider();


            //end displaying eula


        }


        //authentication menu, rest in peace ~ ~~2019-~~ never even lived :(
        else if (displayAuth)
        {

            //authentication menu 

            //my tag
            EditorGUILayout.Space();
            var lukaTagSpace = GUILayoutUtility.GetRect(0, int.MaxValue, 85, 30);
            Texture2D lukaTagTex = Resources.Load<Texture2D>("LukaResource_EditorBanner");
            EditorGUI.DrawPreviewTexture(lukaTagSpace, lukaTagTex, null, ScaleMode.ScaleAndCrop);
            EditorGUILayout.Space();

            //header
            EditorGUILayout.Space();
            generateMessage("authentication menu", helpHeaderStyle);
            generateMessage("after you authenticate this update, this menu will go away. " +
                "\nyou have to do this once per version." +
                "\nauthenticating will unlock the shader", helpInfoStyle);

            //terms
            EditorGUILayout.Space();
            drawDivider();
            EditorGUILayout.Space();
            authKey = EditorGUILayout.TextField("Auth Key: ", authKey);
            authUser = EditorGUILayout.TextField("Auth Id: ", authUser);
            EditorGUILayout.Space();
            if (GUILayout.Button("authenticate me! uwu"))
            {
                authClick = true;
                
            }
            if (authClick == true)
            {
                //EditorGUILayout.LabelField("<color=#F59597> The authentication key/id was invalid!</color>", helpHeaderStyle); //90D0B6 ~ good green, F59597 ~ good red
                GUILayout.Label("<color=#90D0B6> The authentication was successful!</color>", helpHeaderStyle);
            }
            drawDivider();
            EditorGUILayout.Space();


            //faq
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            generateMessage("FAQ", helpInfoStyle);
            EditorGUILayout.Space();
            authHowClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), authHowClick, GUIContent.none, "box");
            EditorGUILayout.Toggle(authHowClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
            EditorGUILayout.LabelField("how do i authenticate?", dropdownStyle);
            EditorGUILayout.EndHorizontal();
            if (authHowClick)
            {
                EditorGUILayout.Space();
                generateMessage("Upon purchasing the shader, I provided a\nkey and Id for you to use. Simply enter those and hit authenticate!\n(you must be connected to the internet)", helpInfoStyle);
                EditorGUILayout.Space();
            }
            authWhyClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), authWhyClick, GUIContent.none, "box");
            EditorGUILayout.Toggle(authWhyClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
            EditorGUILayout.LabelField("why do i need to authenticate?", dropdownStyle);
            EditorGUILayout.EndHorizontal();
            if (authWhyClick)
            {
                EditorGUILayout.Space();
                generateMessage("for extra security + make sure u bought shader c:", helpInfoStyle);
                EditorGUILayout.Space();
            }
            authDataClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), authDataClick, GUIContent.none, "box");
            EditorGUILayout.Toggle(authDataClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
            EditorGUILayout.LabelField("what is used to authenticate?", dropdownStyle);
            EditorGUILayout.EndHorizontal();
            if (authDataClick)
            {
                EditorGUILayout.Space();
                generateMessage("when you authentic, (as well as the key and id).\nthese are purely to keep track of who bought the shader.", helpInfoStyle);
                EditorGUILayout.Space();
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            drawDivider();


        }


        //changelog menu
        else if (!displayChangelog)
        {
            //my tag
            EditorGUILayout.Space();
            var lukaTagSpace = GUILayoutUtility.GetRect(0, int.MaxValue, 85, 30);
            Texture2D lukaTagTex = Resources.Load<Texture2D>("LukaResource_EditorBanner");
            EditorGUI.DrawPreviewTexture(lukaTagSpace, lukaTagTex, null, ScaleMode.ScaleAndCrop);

            //header
            EditorGUILayout.Space();
            generateMessage("welcome to mega " + shaderVersionNumber + versionNumber + "!", helpHeaderStyle);
            generateMessage("see what was changed in this update", helpInfoStyle);
            EditorGUILayout.Space();
            drawDivider();

            //update notes
            EditorGUILayout.Space();
            generateMessage(
                  "- a whole lot" +
                "\n- of stuff" +
                ""
                , helpInfoStyle);

            //bottom divider
            EditorGUILayout.Space();
            drawDivider();

            //options
            EditorGUILayout.Space();
            EditorGUILayout.Space();

            neverShowChangelog = EditorGUILayout.Toggle("In new updates, hide changelog?", neverShowChangelog);
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            if (GUILayout.Button("close changelog"))
            {
                if(neverShowChangelog == true)
                {
                    updateSettings("false", 1);
                }
                else
                {
                    updateSettings("true", 1);
                }
                changelogAcknowledge();
                checkChangelog();
            }


            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();


        }


        //shader menu
        else
        {

   
            //Finding Properties
            findProperty(properties);


            //preparing names if toggled on
            currentlyToggled();



            //header
            if (__hideUnusedFX.floatValue == 0 && menuUgly == false)
            {
                var imageHeaderSpace = GUILayoutUtility.GetRect(0, int.MaxValue, 280, 30);
                Texture2D imageHeaderTexture = Resources.Load<Texture2D>("LukaResource_EditorHeader");
                if (vaporUser) imageHeaderTexture = Resources.Load<Texture2D>("LukaResource_NadeVapor");
                EditorGUI.DrawPreviewTexture(imageHeaderSpace, imageHeaderTexture, null, ScaleMode.ScaleAndCrop);
            }
            if (__hideUnusedFX.floatValue == 0)
            {
                if (menuUgly == true) for(int i = 0; i < 4; i++) EditorGUILayout.Space();
                EditorGUILayout.Space();
                generateMessage("mae", friendStyle);
                generateMessage("luka's mega after effects", friendStyle);
                generateMessage(shaderVersionNumber + versionNumber, friendStyle);
                generateMessage("presented by luka#8375", friendStyle);
                if (needToUpdate)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    generateMessage("theres a new version out! (" + "" + ")\ncheck discord for more details!", helpHeaderStyle);
                }
            }
            else
            {
                //var imageHeaderSpace = GUILayoutUtility.GetRect(0, int.MaxValue, 280, 30);
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                generateMessage("luka's mega  " + shaderVersionNumber, friendStyle); //start info
                generateMessage("good luck keyframing uwu", helpHeaderStyle);
                generateMessage("effects not enabled and additional menu tabs", helpInfoStyle);
                generateMessage("are being hidden", helpInfoStyle); //end info
            }

            //Divider
            drawDivider();

            //renderer header
            generateSection("Rendering", sectionStyle);
            //GUILayout.Label(rainbowfy("rebb b like: glub glub"), sectionStyle);

            //render
            dropdownClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), dropdownClick, GUIContent.none, "box");
            EditorGUILayout.Toggle(dropdownClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
            EditorGUILayout.LabelField(propStyles.DropdownRender, dropdownStyle);
            EditorGUILayout.EndHorizontal();
            if (dropdownClick)
            {
                EditorGUILayout.Space();
                materialEditor.ShaderProperty(_Range, propStyles.RangeStyle);
                //materialEditor.ShaderProperty(_ToggleRenderLookAtMe, propStyles.LookAtMeStyle);
                materialEditor.ShaderProperty(_OverallOpacity, "Shader Strength");
               // materialEditor.ShaderProperty(_ParticleSystem, "NOT FINISHED Use Particle System?"); oeuf..
                materialEditor.ShaderProperty(_ZTest, propStyles.ZTestStyle);
                String renderQueue = targetMat.renderQueue.ToString();
                generateMessage("Render Queue: " + renderQueue, fakePropertyStyle);
                //for those who aren't very familiar with render settings..
                //GUILayout.Space(10);
                EditorGUILayout.Space();
               // generateMessage(ztestDescription, friendStyle);
                EditorGUILayout.Space();
            }


            //falloff
            falloffClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), falloffClick, GUIContent.none, "box");
            EditorGUILayout.Toggle(falloffClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
            EditorGUILayout.LabelField(propStyles.Falloff, dropdownStyle);
            EditorGUILayout.EndHorizontal();
            if (falloffClick)
            {
                EditorGUILayout.Space();
                materialEditor.ShaderProperty(_AllowSmartFalloff, propStyles.AllowSmartFalloffStyle);
                materialEditor.ShaderProperty(_SmartFalloffMin, propStyles.SmartFalloffMinStyle);
                materialEditor.ShaderProperty(_SmartFalloffMax, propStyles.SmartFalloffMaxStyle);
                EditorGUILayout.Space();
                //falloffdescriptionClick = SubmenuFoldout("What is this?", falloffdescriptionClick);
                if (falloffdescriptionClick)
                {
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    String descriptionFalloff =
                        "Falloff is similar to range, however, instead of effects simply stopping they\n" +
                        "'fall off', or fade in and out as the player walks towards or away the mesh.\n" +
                        "However, it is not a replacement for range. You still need a range value!\n" +
                        "I recommend using range 0.5 larger than your 'end falloff range',\n" +
                        "so the the effect is full faded away before the player exits the mesh\n" +
                        "and thus doesn't see mesh. But what do these different settings do?\n" +
                        "Allow Fading Falloff enables falloff for effects that simply 'fade away'\n" +
                        "Allow Scalar Falloff enables falloff for effects thats values scale over distance\n" +
                        "to simulate fading away. If neither are toggled, the shader will choose settings\n" +
                        "for effects. However, I suggest turning both on! Start Falloff Range is the range\n" +
                        "from the center of the  mesh that the effects will start to fade out,\n" +
                        "and End Falloff Range is the distance from the center of the mesh where the effect\n" +
                        "will be fully faded away.";
                    generateMessage(descriptionFalloff, helpInfoStyle);
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                }
                EditorGUILayout.Space();
            }


            //render at me options 
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntRenderAtMe))
            {
                renderatmeClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), renderatmeClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(renderatmeClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.RenderAtMe, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (renderatmeClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleRenderLookAtMe, "Only Render At Me");
                    materialEditor.ShaderProperty(_RenderMeTolerance, "Angle Tolerance");
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                }
            }


            //depth
            depthClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), depthClick, GUIContent.none, "box");
            EditorGUILayout.Toggle(depthClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
            EditorGUILayout.LabelField(propStyles.Depth, dropdownStyle);
            EditorGUILayout.EndHorizontal();
            if (depthClick)
            {
                EditorGUILayout.Space();
                drawDivider();
                EditorGUILayout.Space();
                generateMessage("Depth of Field", helpInfoStyle);
                EditorGUILayout.Space();
                materialEditor.ShaderProperty(_AllowDepthTest, propStyles.AllowDepthTestStyle);
                materialEditor.ShaderProperty(_DepthValue, propStyles.DepthValueStyle);
                EditorGUILayout.Space();
                drawDivider();
                EditorGUILayout.Space();
                generateMessage("Only Affect Players", helpInfoStyle);
                EditorGUILayout.Space();
                materialEditor.ShaderProperty(_ReverseDepth, "Reverse Focus?");
                EditorGUILayout.Space();
                drawDivider();
                EditorGUILayout.Space();
                generateMessage("Focus On You", helpInfoStyle);
                EditorGUILayout.Space();
                materialEditor.ShaderProperty(_KeepPlayerInFocus, "Keep You In Focus?");
                materialEditor.ShaderProperty(_DepthPlayerPower, "Focus on You Strength");
                materialEditor.ShaderProperty(_DepthPlayerTolerance, "You Focus Tolerance");
                EditorGUILayout.Space();
                drawDepth(false);
                EditorGUILayout.Space();
                EditorGUILayout.Space();
            }


            //screen tear fix  
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntScreentear))
            {
                screentearClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), screentearClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(screentearClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Tear, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (screentearClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_TearToMirror, "Tear to mirror?");
                    materialEditor.ShaderProperty(_TearToRepeat, "Tear to repeat?");
                    materialEditor.ShaderProperty(_AllowTearFix, "Tear to color?");
                    materialEditor.ShaderProperty(_ScreenTearColor, "Tear color");
                    EditorGUILayout.Space();
                }
            }


            //Transistion
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntTransistion))
            {
                transClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), transClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(transClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Transistion, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (transClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleTransistion, propStyles.ToggleTransistionStyle);
                    materialEditor.ShaderProperty(_TransX, propStyles.TransXStyle);
                    materialEditor.ShaderProperty(_TransY, propStyles.TransYStyle);
                    materialEditor.ShaderProperty(_ToggleDiagTrans, propStyles.ToggleDiagTrans);
                    if (_ToggleDiagTrans.floatValue == 1)
                    {
                        materialEditor.ShaderProperty(_TransDL, propStyles.TransDLStyle);
                        materialEditor.ShaderProperty(_TransDR, propStyles.TransDRStyle);
                    }
                    EditorGUILayout.Space();
                }
            }


            //VR
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntVR))
            {
                vrClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), vrClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(vrClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.VR, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (vrClick)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    drawDivider();
                    generateMessage("VR Strength Tuning", helpInfoStyle);
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_VRAdjust, "VR Strength Adjustment");
                    materialEditor.ShaderProperty(_VRPreview, "Preview VR Strength?");
                    generateMessage("Turn preview off before uploading!", helpInfoStyle);
                    drawDivider();
                    generateMessage("VR Eye Options", helpInfoStyle);
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_VRLeft, "Close Left Eye?");
                    materialEditor.ShaderProperty(_VRLeftColor, "Left Eye Color");
                    materialEditor.ShaderProperty(_VRRight, "Close Right Eye?");
                    materialEditor.ShaderProperty(_VRRightColor, "Right Eye Color");
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                }
            }


            //animating
            animateClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), animateClick, GUIContent.none, "box");
            EditorGUILayout.Toggle(animateClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
            EditorGUILayout.LabelField("Animating", dropdownStyle);
            EditorGUILayout.EndHorizontal();
            if (animateClick)
            {
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                materialEditor.ShaderProperty(__hideUnusedFX, "Hide disabled effects?");
                generateMessage("Using GVAS? Use this to help easily find property names!", fakePropertyStyle);
                propertyQuery = EditorGUILayout.TextField("Property Search: ", propertyQuery);
                String indexedProperties = "";
                if (GUILayout.Button("search property"))
                {
                    searchedCache.Clear();
                    resultedCache.Clear();

                    //Searching purely based on the value name
                    searchedCache = GrabProperties(targetMat, targetMat.shader);
                    resultedCache.Clear();
                    foreach (var item in searchedCache)
                    {
                        if (item.ToString().ToLower().Contains(propertyQuery.ToLower()))
                        {
                            resultedCache.Add(item.ToString());
                            indexedProperties += item + ", ";
                            //Debug.Log(item + " found for " + propertyQuery);
                        }

                    }

                    //Searching based on descriptions
                    matchingCache.Clear();
                    matchingCache = GrabDescriptions(targetMat, targetMat.shader);
                    int loopTime = 0;
                    foreach (var item in matchingCache)
                    {
                        if (item.ToString().ToLower().Contains(propertyQuery.ToLower()))
                        {
                            resultedCache.Add(searchedCache[loopTime].ToString());
                            indexedProperties += item + ", ";
                            //Debug.Log(item + " found for " + propertyQuery);
                        }
                        loopTime++;
                    }

                }
                propertyPlace = EditorGUILayout.Popup("View Properties", propertyPlace, resultedCache.ToArray());
                generateMessage(indexedProperties, helpInfoStyle);
                EditorGUILayout.Space();
            }


            //Divider
            drawDivider();

            //renderer header
            generateSection("Effects", sectionStyle);


            //ascii 
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntAscii))
            {
                asciiClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), asciiClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(asciiClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Ascii, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (asciiClick)
                {
                    EditorGUILayout.Space();

                    //normal
                    materialEditor.ShaderProperty(_ToggleAscii, propStyles.ToggleAsciiStyle);
                    materialEditor.ShaderProperty(_ASCIIVariation, propStyles.ASCIIVariationStyle);
                    materialEditor.ShaderProperty(_ASCIIPower, propStyles.ASCIIPowerStyle);
                    materialEditor.ShaderProperty(_ASCIISpeed, "Character Speed");
                    EditorGUILayout.Space();

                    //advanced
                    asciiAdvanvedClick = SubmenuFoldout("Advanced Settings", asciiAdvanvedClick);
                    if (asciiAdvanvedClick)
                    {
                        EditorGUILayout.Space();
                        var openURLSpace = GUILayoutUtility.GetRect(0, int.MaxValue, 15, 10);
                        Boolean openURLButton = GUI.Button(openURLSpace, "Open website to make own shapes?");
                        if (openURLButton)
                        {
                            Application.OpenURL("http://thrill-project.com/archiv/coding/bitmap/");
                            openURLButton = false;
                        }
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ASCIIShapeOne, "Ascii Shape One?");
                        materialEditor.ShaderProperty(_ASCIIShapeTwo, "Ascii Shape Two?");
                        materialEditor.ShaderProperty(_ASCIIShapeThree, "Ascii Shape Three?");
                        materialEditor.ShaderProperty(_ASCIIShapeFour, "Ascii Shape Four?");
                        materialEditor.ShaderProperty(_ASCIIShapeFive, "Ascii Shape Five?");
                        materialEditor.ShaderProperty(_ASCIIShapeSix, "Ascii Shape Six?");
                        materialEditor.ShaderProperty(_ASCIIShapeSeven, "Ascii Shape Seven?");
                        materialEditor.ShaderProperty(_ASCIIShapeEight, "Ascii Shape Eight?");
                        EditorGUILayout.Space();
                        var asciiResetSpace = GUILayoutUtility.GetRect(0, int.MaxValue, 15, 10);
                        Boolean resetButtons = GUI.Button(asciiResetSpace, "Reset values !");
                        if (resetButtons)
                        {
                            //resetting values
                            _ASCIIShapeOne.floatValue = 65536;
                            _ASCIIShapeTwo.floatValue = 65600;
                            _ASCIIShapeThree.floatValue = 332772;
                            _ASCIIShapeFour.floatValue = 15255086;
                            _ASCIIShapeFive.floatValue = 23385164;
                            _ASCIIShapeSix.floatValue = 15252014;
                            _ASCIIShapeSeven.floatValue = 13199452;
                            _ASCIIShapeEight.floatValue = 11512810;
                            //resetting button so its not spamming keyframes
                            resetButtons = false;
                        }
                    }
                    EditorGUILayout.Space();
                }
            }
            
            
            
            //apart 
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntApart))
            {
                apartClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), apartClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(apartClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Apart, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (apartClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ApartMode, "Apart Mode:");
                    materialEditor.ShaderProperty(_Apart, "Apart Strength");
                    materialEditor.ShaderProperty(_ApartColor, "Apart Color");
                    EditorGUILayout.Space();
                }
            }


            //blink
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntBlink))
            {
                blinkClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), blinkClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(blinkClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Blink, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (blinkClick)
                {
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    generateMessage("Blink", helpInfoStyle);
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_BlinkMode, "Shape");
                    materialEditor.ShaderProperty(_BlinkForce, "Blink Over Overlay?");
                    materialEditor.ShaderProperty(_BlinkStrength, propStyles.BlinkStrengthStyle);
                    materialEditor.ShaderProperty(_BlinkColor, propStyles.BlinkColorStyle);
                    materialEditor.ShaderProperty(_BlinkBorderSize, "Border Size");
                    materialEditor.ShaderProperty(_BlinkBorder, "Border Color");
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    generateMessage("Rainbow", helpInfoStyle);
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_BlinkRainbow, "Rainbow?");
                    if (_BlinkRainbow.floatValue > 0)
                    {
                        materialEditor.ShaderProperty(_BlinkRainbowMode, "Rainbow Effects:");
                        materialEditor.ShaderProperty(_BlinkRainbowX, "X Rainbow?");
                        materialEditor.ShaderProperty(_BlinkRainbowY, "Y Rainbow?");
                        materialEditor.ShaderProperty(_BlinkRainbowHue, "Rainbow Hue");
                        materialEditor.ShaderProperty(_BlinkRainbowSat, "Rainbow Saturation");
                        materialEditor.ShaderProperty(_BlinkRainbowLight, "Rainbow Light");
                        materialEditor.ShaderProperty(_BlinkRainbowTime, "Rainbow Time");
                    }
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    generateMessage("Image", helpInfoStyle);
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_BlinkImagePower, "Image Transparency");
                    if (_BlinkImagePower.floatValue > 0)
                    {
                        materialEditor.ShaderProperty(_BlinkImage, "Blink Image");
                        materialEditor.ShaderProperty(_BlinkImageX, "Image X Size");
                        materialEditor.ShaderProperty(_BlinkImageY, "Image Y Size");
                    }
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                }
            }


            //bloom
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntBloom))
            {
                bloomClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), bloomClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(bloomClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Bloom, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (bloomClick)
                {
                    EditorGUILayout.Space();
                    var bloomLagSpace = GUILayoutUtility.GetRect(0, int.MaxValue, 10, 30);
                    float samplesRemapped = (float)Math.Round(0 + (_RBloomQuality.floatValue - 4) * (1 - 0) / (32 - 4), 2);
                    EditorGUI.ProgressBar(bloomLagSpace, samplesRemapped, "");
                    EditorGUILayout.Space();
                    generateMessage("Bloom Lag Amount:" + (samplesRemapped * 100).ToString() + "%", helpInfoStyle);
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_RBloomToggle, "Allow Bloom");
                    materialEditor.ShaderProperty(_RBloomQuality, "Bloom Quality");
                    materialEditor.ShaderProperty(_RBloomStrength, "Bloom Strength");
                    materialEditor.ShaderProperty(_RBloomBright, "Bloom Brightness");
                    materialEditor.ShaderProperty(_RBloomColor, "Bloom Color");
                    materialEditor.ShaderProperty(_RBloomOpacity, "Bloom Opacity");
                    materialEditor.ShaderProperty(_RBloomDepth, "Bloom Depth");
                    EditorGUILayout.Space();
                }
            }


            //blur 
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntBlur))
            {
                blurClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), blurClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(blurClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Blur, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (blurClick)
                {
                    //lock
                    if(ntRadial){
                        /*if (!(_ToggleBlur.floatValue == 1 && _ToggleRadialBlur.floatValue == 1))
                        {
                            lockMessage("Blur", "Radial", false);
                            blurClick = false;
                        }*/
                        lockMessage("Blur", "Radial", false);
                    }
                    //space
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    if (!(_NBlurShape.floatValue == 5) && !(_NBlurShape.floatValue == 6))
                    {
                        var blurLagSpace = GUILayoutUtility.GetRect(0, int.MaxValue, 10, 30);
                        float samplesRemapped = (float)Math.Round(0 + (_NBlurItterations.floatValue - 1) * (1 - 0) / (32 - 1), 2);
                        EditorGUI.ProgressBar(blurLagSpace, samplesRemapped, "");
                        EditorGUILayout.Space();
                        generateMessage("Blur Lag Amount:" + (samplesRemapped * 100).ToString() + "%", helpInfoStyle);
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleNBlur, "Allow Blur");
                        materialEditor.ShaderProperty(_NBlurShape, "Blur Shape");
                        materialEditor.ShaderProperty(_NBlurItterations, "Blur Itterations");
                        materialEditor.ShaderProperty(_NBlurPower, "Blur Strength");
                        materialEditor.ShaderProperty(_NBlurSpeed, "Blur Speed");
                        materialEditor.ShaderProperty(_NBlurRotate, "Blur Rotation");
                        materialEditor.ShaderProperty(_NBlurRotateSpeed, "Blur Rot. Speed");
                        materialEditor.ShaderProperty(_NBlurX, "Blur X Offset");
                        materialEditor.ShaderProperty(_NBlurY, "Blur Y Offset");
                        materialEditor.ShaderProperty(_NBlurColor, "Blur Colour");
                        materialEditor.ShaderProperty(_NBlurGlow, "Blur Glow");
                        materialEditor.ShaderProperty(_NBlurOpacity, "Blur Opacity");
                    }
                    else if (_NBlurShape.floatValue == 6)
                    {
                        materialEditor.ShaderProperty(_ToggleNBlur, "Allow Blur");
                        materialEditor.ShaderProperty(_NBlurShape, "Blur Shape");
                        materialEditor.ShaderProperty(_NBlurPower, "Blur Strength");
                        materialEditor.ShaderProperty(_NBlurSpeed, "Blur Speed");
                        materialEditor.ShaderProperty(_NBlurColor, "Blur Colour");
                        materialEditor.ShaderProperty(_NBlurGlow, "Blur Glow");
                        materialEditor.ShaderProperty(_NBlurOpacity, "Blur Opacity");
                    }
                    else
                    {
                        materialEditor.ShaderProperty(_ToggleNBlur, "Allow Blur");
                        materialEditor.ShaderProperty(_NBlurShape, "Blur Shape");
                        materialEditor.ShaderProperty(_NBlurPower, "Blur Strength");
                        materialEditor.ShaderProperty(_NBlurSpeed, "Blur Speed");
                        materialEditor.ShaderProperty(_NBlurColor, "Blur Colour");
                        materialEditor.ShaderProperty(_NBlurGlow, "Blur Glow");
                        materialEditor.ShaderProperty(_NBlurOpacity, "Blur Opacity");
                    }


                    //space
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();

                }
            }


            //bulge
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntBulge))
            {
                bulgeClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), bulgeClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(bulgeClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Bulge, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (bulgeClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleBulge, propStyles.ToggleBulgeStyle);
                    materialEditor.ShaderProperty(_BulgeIndent, "Bulge Indent");
                    materialEditor.ShaderProperty(_OwoStrength, propStyles.OwOStrengthStyle);
                    generateMessage("owo", propInfoTinyStyle);
                    EditorGUILayout.Space();
                }
            }


            //rgb
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntRGB))
            {
                rgbClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), rgbClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(rgbClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.RGB, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (rgbClick)
                {
                    //lock
                    if(ntRGBGlitch){
                        lockMessage("Chromatic Abberation", "RGB Glitch", false);
                        //rgbClick = false;
                    }
                    //general settings
                    drawDivider();
                    generateMessage("General Settings", helpHeaderStyle);
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleRGB, propStyles.ToggleRGBStyle);
                    materialEditor.ShaderProperty(_CAStyle, "CA Style?");
                    if (!(_CAStyle.floatValue == 1)) materialEditor.ShaderProperty(_CAMode, "CA Color Method?");
                    if (!(_CAStyle.floatValue == 1)) materialEditor.ShaderProperty(_ToggleCleanRGB, "Clean RGB Tear?");
                    if (!(_CAStyle.floatValue == 2))
                    {
                        materialEditor.ShaderProperty(_ToggleAutoanimate, propStyles.ToggleAutoanimateStyle);
                        materialEditor.ShaderProperty(_RGBAutoanimateSpeed, propStyles.RGBAutoanimateSpeedStyle);
                    }
                    materialEditor.ShaderProperty(_CATrans, "CA Transparency");
                    EditorGUILayout.Space();
                    if (GUILayout.Button("reset all"))
                    {
                        _ToggleAutoanimate.floatValue = 0;
                        _RGBAutoanimateSpeed.floatValue = 0;
                        _CATrans.floatValue = 1;
                        _CASamples.floatValue = 1;
                        _RedXValue.floatValue = 0;
                        _RedYValue.floatValue = 0;
                        _HideRedTrans.floatValue = 1;
                        if ((_CAStyle.floatValue == 1)) _GreenXValue.floatValue = (float)0.06; else _GreenXValue.floatValue = 0;
                        _GreenYValue.floatValue = 0;
                        _HideGreenTrans.floatValue = 1;
                        _BlueXValue.floatValue = 0;
                        _BlueYValue.floatValue = 0;
                        _HideBlueTrans.floatValue = 1;
                        _CAStyle.floatValue = 1;
                        _RotationStrength.floatValue = 0;
                        _CAMode.floatValue = 0;
                        _CASamples.floatValue = 10;
                        _CARotate.floatValue = 0;
                        _CARotateSpeed.floatValue = 0;
                        _CAOffsetX.floatValue = 0;
                        _CAOffsetY.floatValue = 0;
                    }
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    drawDivider();

                    if (_CAStyle.floatValue == 0)
                    {
                        //red settings
                        if (_CAMode.floatValue == 0)
                        {
                            generateMessage("<color=#ff0000>Red</color>", helpHeaderStyle);
                        }
                        else if (_CAMode.floatValue == 1)
                        {
                            generateMessage(rainbowfy("Hue"), helpHeaderStyle);
                        }
                        else if (_CAMode.floatValue == 2)
                        {
                            generateMessage("Left Negative", helpHeaderStyle);
                        }
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_RedXValue, propStyles.RedXValueStyle);
                        materialEditor.ShaderProperty(_RedYValue, propStyles.RedYValueStyle);
                        materialEditor.ShaderProperty(_HideRedTrans, "Red Visibility");
                        EditorGUILayout.Space();
                        drawDivider();
                        //end red settings


                        //green settings
                        if (_CAMode.floatValue == 0)
                        {
                            generateMessage("<color=#00ff00>Green</color>", helpHeaderStyle);
                        }
                        else if (_CAMode.floatValue == 1)
                        {
                            generateMessage(rainbowfy("Saturation"), helpHeaderStyle);
                        }
                        else if (_CAMode.floatValue == 2)
                        {
                            generateMessage("Normal", helpHeaderStyle);
                        }
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_GreenXValue, propStyles.GreenXValueStyle);
                        materialEditor.ShaderProperty(_GreenYValue, propStyles.GreenYValueStyle);
                        materialEditor.ShaderProperty(_HideGreenTrans, "Green Visibility");
                        EditorGUILayout.Space();
                        drawDivider();
                        //end green settings


                        //blue settings
                        if (_CAMode.floatValue == 0)
                        {
                            generateMessage("<color=#0000ff>Blue</color>", helpHeaderStyle);
                        }
                        else if (_CAMode.floatValue == 1)
                        {
                            generateMessage(rainbowfy("Brightness"), helpHeaderStyle);
                        }
                        else if (_CAMode.floatValue == 2)
                        {
                            generateMessage("Right Negative", helpHeaderStyle);
                        }
                        materialEditor.ShaderProperty(_BlueXValue, propStyles.BlueXValueStyle);
                        materialEditor.ShaderProperty(_BlueYValue, propStyles.BlueYValueStyle);
                        materialEditor.ShaderProperty(_HideBlueTrans, "Blue Visibility");
                        EditorGUILayout.Space();
                        drawDivider();
                        //end blue settings



                        //sample 
                        }
                        else if (_CAStyle.floatValue == 1)
                        {

                            //general settings
                            generateMessage("Sampled RGB Settings", helpHeaderStyle);
                            var caLagSpace = GUILayoutUtility.GetRect(0, int.MaxValue, 10, 30);
                            float samplesRemapped = (float)Math.Round(0 + (_CASamples.floatValue - 1) * (1 - 0) / (32 - 1), 2);
                            EditorGUI.ProgressBar(caLagSpace, samplesRemapped, "");
                            EditorGUILayout.Space();
                            generateMessage("CA Lag Amount:" + (samplesRemapped * 100).ToString() + "%", helpInfoStyle);
                            EditorGUILayout.Space();
                            EditorGUILayout.Space();
                            materialEditor.ShaderProperty(_CASamples, "CA Samples");
                            materialEditor.ShaderProperty(_RedXValue, "Red Abberation");
                            materialEditor.ShaderProperty(_GreenXValue, "Green Abberation");
                            materialEditor.ShaderProperty(_BlueXValue, "Blue Abberation");
                            materialEditor.ShaderProperty(_HideRedTrans, "Red Visibility");
                            materialEditor.ShaderProperty(_HideGreenTrans, "Green Visibility");
                            materialEditor.ShaderProperty(_HideBlueTrans, "Blue Visibility");
                            materialEditor.ShaderProperty(_CARotate, "CA Rotate");
                            materialEditor.ShaderProperty(_CARotateSpeed, "CA Rotate Speed");
                            materialEditor.ShaderProperty(_CAOffsetX, "CA X Offset");
                            materialEditor.ShaderProperty(_CAOffsetY, "CA Y Offset");
                            EditorGUILayout.Space();
                            drawDivider();


                        //rotate 
                        }
                        else if (_CAStyle.floatValue == 2)
                        {
                            //general settings
                            generateMessage("RGB Rotation Settings", helpHeaderStyle);
                            EditorGUILayout.Space();
                            materialEditor.ShaderProperty(_RotationStrength, "Rotation Strength");
                            materialEditor.ShaderProperty(_ToggleScreenFollow, propStyles.ToggleScreenFollowStyle);
                            EditorGUILayout.Space();
                            drawDivider();

                            //red settings
                            generateMessage("<color=#ff0000>Rotating Red</color>", helpHeaderStyle);
                            EditorGUILayout.Space();
                            materialEditor.ShaderProperty(_RotationSpeedRed, propStyles.RotationSpeedRedStyle);
                            materialEditor.ShaderProperty(_DirectionRed, propStyles.DirectionRedStyle);
                            EditorGUILayout.Space();
                            drawDivider();
                            //end red settings


                            //green settings
                            generateMessage("<color=#00ff00>Rotating Green</color>", helpHeaderStyle);
                            EditorGUILayout.Space();
                            materialEditor.ShaderProperty(_ToggleGreenMove, "Allow Green Rotation?");
                            materialEditor.ShaderProperty(_RotationSpeedGreen, propStyles.RotationSpeedGreenStyle);
                            materialEditor.ShaderProperty(_DirectionGreen, propStyles.DirectionGreenStyle);
                            EditorGUILayout.Space();
                            drawDivider();
                            //end green settings


                            //blue settings
                            generateMessage("<color=#0000ff>Rotating Blue</color>", helpHeaderStyle);
                            materialEditor.ShaderProperty(_RotationSpeedBlue, propStyles.RotationSpeedBlueStyle);
                            materialEditor.ShaderProperty(_DirectionBlue, propStyles.DirectionBlueStyle);
                            EditorGUILayout.Space();
                            drawDivider();
                            //end blue settings

                    }


                    EditorGUILayout.Space();
                }


            }


            //colors 
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntColorTint))
            {
                colorClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), colorClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(colorClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Color, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (colorClick)
                {
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    if (GUILayout.Button("reset all"))
                    {
                        _DarknessStrength.floatValue = 0;
                        _SepiaStrength.floatValue = 0;
                        _SepiaColor.colorValue = Color.white;
                        _PosterizeValue.floatValue = -100;
                        _SaturationValue.floatValue = 1;
                        _VibrancePower.floatValue = 0;
                        _ContrastValue.floatValue = 1;
                        _BloomGlow.floatValue = 1;
                        _SepiaRStrength.floatValue = 0;
                        _SepiaRWarmth.floatValue = 1;
                        _SEpiaRTone.floatValue = 1;
                        _ColorRGBtoHSV.floatValue = 0;
                        _ColorHSVtoRGB.floatValue = 0;
                        _ColorHue.floatValue = 0;
                        _ColorSaturation.floatValue = 0;
                        _ColorValue.floatValue = 0;
                        _ColorRGB.colorValue = Color.white;
                        _SolidTrans.floatValue = 0;
                        _CornerOneTrans.floatValue = 0;
                        _CornerTwoTrans.floatValue = 0;
                        _CornerThreeTrans.floatValue = 0;
                        _CornerFourTrans.floatValue = 0;
                        _GammaBlue.floatValue = 0;
                        _GammaRed.floatValue = 0;
                        _GammaGreen.floatValue = 0;
                        _GradTrans.floatValue = 0;
                    }
                    EditorGUILayout.Space();
                    //hsv
                    EditorGUILayout.Space();
                    generateMessage("HSV Controls", helpInfoStyle);
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ColorHue, propStyles.ColorHueStyle);
                    materialEditor.ShaderProperty(_ColorSaturation, propStyles.ColorSaturationStyle);
                    materialEditor.ShaderProperty(_ColorValue, propStyles.ColorValueStyle);
                    EditorGUILayout.Space();
                    drawDivider();

                    //rgb tint
                    EditorGUILayout.Space();
                    generateMessage("HDR <color=#af0c3a>R</color><color=#077a4c>G</color><color=#281299>B</color> Controls", helpInfoStyle);
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ColorRGB, propStyles.ColorRGBStyle);
                    EditorGUILayout.Space();
                    drawDivider();

                    //solid color
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    generateMessage("Solid Color", helpInfoStyle);
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_SolidCol, "Solid Color");
                    materialEditor.ShaderProperty(_SolidTrans, "Color Transparency");
                    EditorGUILayout.Space();
                    drawDivider();

                    //gardient color
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    generateMessage("Gradient", helpInfoStyle);
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_GradTrans, "Grad Transparency");
                    materialEditor.ShaderProperty(_GradMode, "Gradient Path");
                    materialEditor.ShaderProperty(_GradApply, "Apply Method");
                    materialEditor.ShaderProperty(_GradOne, "Grad Col One");
                    materialEditor.ShaderProperty(_GradTwo, "Grad Col Two");
                    EditorGUILayout.Space();
                    drawDivider();

                    //darkness and greyscale
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    generateMessage("Color Control", helpInfoStyle);
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_DarknessStrength, propStyles.DarknessStrengthStyle);
                    materialEditor.ShaderProperty(_SepiaStrength, propStyles.SepiaStrengthStyle);
                    materialEditor.ShaderProperty(_SepiaColor, "B&W Color Mod");
                    materialEditor.ShaderProperty(_PosterizeValue, propStyles.PosterizeValueStyle);
                    materialEditor.ShaderProperty(_SaturationValue, propStyles.SaturationValue);
                    materialEditor.ShaderProperty(_VibrancePower, "Vibrance");
                    materialEditor.ShaderProperty(_ContrastValue, "Contrast");
                    materialEditor.ShaderProperty(_BloomGlow, propStyles.BloomGlowStyle);
                    materialEditor.ShaderProperty(_SepiaRStrength, "Sepia");
                    materialEditor.ShaderProperty(_SepiaRWarmth, "Sepia Warmth");
                    materialEditor.ShaderProperty(_SEpiaRTone, "Sepia Tone");
                    materialEditor.ShaderProperty(_ColorRGBtoHSV, "RGB 2 HSV?");
                    materialEditor.ShaderProperty(_ColorHSVtoRGB, "HSV 2 RGB?");
                    EditorGUILayout.Space();
                    drawDivider();

                    //gamma correction              
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    generateMessage("Gamma Correction", helpInfoStyle);
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_GammaRed, propStyles.GammaRedStyle);
                    materialEditor.ShaderProperty(_GammaGreen, propStyles.GammaGreenStyle);
                    materialEditor.ShaderProperty(_GammaBlue, propStyles.GammaBlueStyle);
                    EditorGUILayout.Space();
                    drawDivider();

                    //Invert
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    generateMessage("Channel Invertation", helpInfoStyle);
                    EditorGUILayout.Space();
                    if(GUILayout.Button("reset all"))
                    {
                        _InvertMode.floatValue = 0;
                        _InvertStrength.floatValue = 0;
                        _InvertR.floatValue = 0;
                        _InvertG.floatValue = 0;
                        _InvertB.floatValue = 0;
                    }
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_InvertMode, "Invertation Mode");
                    materialEditor.ShaderProperty(_InvertStrength, "Invert Strength");
                    materialEditor.ShaderProperty(_InvertR, "Red Invert");
                    materialEditor.ShaderProperty(_InvertG, "Green Invert");
                    materialEditor.ShaderProperty(_InvertB, "Blue Invert");
                    EditorGUILayout.Space();
                    drawDivider();


                    //end
                    EditorGUILayout.Space();
                }
            }


            //(color) droplet
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntDroplet))
            {
                dropletClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), dropletClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(dropletClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Droplet, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (dropletClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleDroplet, propStyles.ToggleDropletStyle);
                    materialEditor.ShaderProperty(_ToggleDropletSepia, "Greyscale");

                    //color one
                    String colFoldoutOne = "Color One";
                    if (_ToggleDroplet.floatValue == 1) colFoldoutOne += " (Being Filtered)";
                    dropletColOneClick = SubmenuFoldout(colFoldoutOne, dropletColOneClick);
                    if (dropletColOneClick)
                    {
                        materialEditor.ShaderProperty(_DropletColOne, propStyles.DropletColOneStyle);
                        materialEditor.ShaderProperty(_DropletColTwo, propStyles.DropletColTwoStyle);
                        materialEditor.ShaderProperty(_DropletTolerance, propStyles.DropletToleranceStyle);
                        materialEditor.ShaderProperty(_DropletIntensity, propStyles.DropletIntensityStyle);
                    }

                    //color two
                    String colFoldoutTwo = "Color Two";
                    if (_ToggleDropletTwo.floatValue == 1) colFoldoutTwo += " (Being Filtered)";
                    dropletColTwoClick = SubmenuFoldout(colFoldoutTwo, dropletColTwoClick);
                    if (dropletColTwoClick)
                    {
                        materialEditor.ShaderProperty(_ToggleDropletTwo, propStyles.ToggleDropletTwoStyle);
                        materialEditor.ShaderProperty(_TwoDropletColOne, propStyles.TwoDropletColOneStyle);
                        materialEditor.ShaderProperty(_TwoDropletColTwo, propStyles.TwoDropletColTwoStyle);
                        materialEditor.ShaderProperty(_TwoDropletTolerance, propStyles.TwoDropletToleranceStyle);
                        materialEditor.ShaderProperty(_TwoDropletIntensity, propStyles.TwoDropletIntensityStyle);
                    }

                    //color three
                    String colFoldoutThree = "Color Three";
                    if (_ToggleDropletThree.floatValue == 1) colFoldoutThree += " (Being Filtered)";
                    dropletColThreeClick = SubmenuFoldout(colFoldoutThree, dropletColThreeClick);
                    if (dropletColThreeClick)
                    {
                        materialEditor.ShaderProperty(_ToggleDropletThree, propStyles.ToggleDropletThreeStyle);
                        materialEditor.ShaderProperty(_ThreeDropletColOne, propStyles.ThreeDropletColOneStyle);
                        materialEditor.ShaderProperty(_ThreeDropletColTwo, propStyles.ThreeDropletColTwoStyle);
                        materialEditor.ShaderProperty(_ThreeDropletTolerance, propStyles.ThreeDropletToleranceStyle);
                        materialEditor.ShaderProperty(_ThreeDropletIntensity, propStyles.ThreeDropletIntensityStyle);
                    }

                    //color four
                    String colFoldoutFour = "Color Four";
                    if (_ToggleDropletFour.floatValue == 1) colFoldoutFour += " (Being Filtered)";
                    dropletColFourClick = SubmenuFoldout(colFoldoutFour, dropletColFourClick);
                    if (dropletColFourClick)
                    {
                        materialEditor.ShaderProperty(_ToggleDropletFour, propStyles.ToggleDropletFourStyle);
                        materialEditor.ShaderProperty(_FourDropletColOne, propStyles.FourDropletColOneStyle);
                        materialEditor.ShaderProperty(_FourDropletColTwo, propStyles.FourDropletColTwoStyle);
                        materialEditor.ShaderProperty(_FourDropletTolerance, propStyles.FourDropletToleranceStyle);
                        materialEditor.ShaderProperty(_FourDropletIntensity, propStyles.FourDropletIntensityStyle);
                    }

                    EditorGUILayout.Space();
                }
            }


            //color split 
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntColorSplit))
            {
                colorsplitClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), colorsplitClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(colorsplitClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.ColorSplit, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (colorsplitClick)
                {
                    EditorGUILayout.Space();

                    //general settings
                    drawDivider();
                    generateMessage("General Settings", helpHeaderStyle);
                    materialEditor.ShaderProperty(_ToggleColorSplit, "Allow Color Split");
                    materialEditor.ShaderProperty(_ToggleAutoanimateColorSplit, "Animate Split?");
                    materialEditor.ShaderProperty(_ColorSplitSpeed, "Split Speed");
                    materialEditor.ShaderProperty(_CSL, "Split Samples");
                    materialEditor.ShaderProperty(_CSRotate, "Rotate");
                    materialEditor.ShaderProperty(_ColSplRotateSpeed, "Rotate Speed");
                    materialEditor.ShaderProperty(_CSOffsetX, "X Offset");
                    materialEditor.ShaderProperty(_CSOffsetY, "Y Offset");
                    materialEditor.ShaderProperty(_CSTrans, "Transparency");
                    EditorGUILayout.Space();
                    drawDivider();

                    //left color
                    EditorGUILayout.Space();
                    generateMessage("Left Split", helpHeaderStyle);
                    materialEditor.ShaderProperty(_ColorSplitRGBone, "Left Color");
                    materialEditor.ShaderProperty(_ColSpONEopacity, "Left Glow");
                    materialEditor.ShaderProperty(_CSLX, "Left X Offset");
                    materialEditor.ShaderProperty(_CSLY, "Left Y Offset");
                    EditorGUILayout.Space();
                    drawDivider();

                    //middle color
                    EditorGUILayout.Space();
                    generateMessage("Middle Split", helpHeaderStyle);
                    materialEditor.ShaderProperty(_ColorSplitRGBtwo, "Middle Color");
                    materialEditor.ShaderProperty(_ColSpTWOopacity, "Middle Glow");
                    materialEditor.ShaderProperty(_CSMX, "Middle X Offset");
                    materialEditor.ShaderProperty(_CSMY, "Middle Y Offset");
                    EditorGUILayout.Space();
                    drawDivider();

                    //right color
                    EditorGUILayout.Space();
                    generateMessage("Right Split", helpHeaderStyle);
                    materialEditor.ShaderProperty(_ColorSplitRGBthree, "Right Color");
                    materialEditor.ShaderProperty(_ColSpTHREEOpacity, "Right Glow");
                    materialEditor.ShaderProperty(_CSRX, "Right X Offset");
                    materialEditor.ShaderProperty(_CSRY, "Right Y Offset");
                    EditorGUILayout.Space();
                    drawDivider();

                    //animation
                    EditorGUILayout.Space();
                    if (showColorSplitAnimate)
                    {
                        generateMessage("Animation Settings", helpHeaderStyle);
                        materialEditor.ShaderProperty(_ColorSplitAmount, propStyles.ColorSplitAmountStyle);
                        materialEditor.ShaderProperty(_ToggleColorSplitStaySides, propStyles.ToggleColorSplitStaySidesStyle);
                        materialEditor.ShaderProperty(_ColorSplitSpeed, propStyles.ColorSplitSpeedStyle);
                        EditorGUILayout.Space();
                        drawDivider();
                    }
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                }
            }


            //color spin
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntCornerColor))
            {
                cornercolorClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), cornercolorClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(cornercolorClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.CornerColor, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (cornercolorClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleCC, "Colors Transparency");
                    materialEditor.ShaderProperty(_CCApply, "Apply Method");
                    materialEditor.ShaderProperty(_CCOne, "Color One");
                    materialEditor.ShaderProperty(_CCTwo, "Color Two");
                    materialEditor.ShaderProperty(_CCThree, "Color Three");
                    materialEditor.ShaderProperty(_CCFour, "Color Four");
                    materialEditor.ShaderProperty(_CCRotate, "Rotation Angle");
                    materialEditor.ShaderProperty(_CCSpeed, "Rotation Speed");
                    EditorGUILayout.Space();
                }
            }


            //corners
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntCorners))
            {
                cornerClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), cornerClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(cornerClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Corners, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (cornerClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_CornerOneColor, "Bottom Left");
                    materialEditor.ShaderProperty(_CornerOneTrans, "BL Transparency");
                    materialEditor.ShaderProperty(_CornerTwoColor, "Top Left");
                    materialEditor.ShaderProperty(_CornerTwoTrans, "TL Transparency");
                    materialEditor.ShaderProperty(_CornerThreeColor, "Bottom Right");
                    materialEditor.ShaderProperty(_CornerThreeTrans, "BR Transparency");
                    materialEditor.ShaderProperty(_CornerFourColor, "Top Right");
                    materialEditor.ShaderProperty(_CornerFourTrans, "TR Transparency");
                    EditorGUILayout.Space();
                }
            }


            //deepfry
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntDeepfry))
            {
                deepfryClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), deepfryClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(deepfryClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Deepfry, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (deepfryClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleDeepfry, "Deepfry?");
                    materialEditor.ShaderProperty(_DeepfryValue, "Color Flavor");
                    materialEditor.ShaderProperty(_DeepfryBrightness, "Fryer Strength");
                    materialEditor.ShaderProperty(_DeepfryEmbossPower, "JPEG-ify?");
                    if (GUILayout.Button(":b:omo :b:eepfry?"))
                    {
                        _ToggleDeepfry.floatValue = 1;
                        _DeepfryValue.floatValue = 0;
                        _DeepfryBrightness.floatValue = bomo(0.1, 1);
                        _DeepfryEmbossPower.floatValue = bomo(0.5, 3);
                        _BloomGlow.floatValue = bomo(1, 5);
                        _ContrastValue.floatValue = bomo(1, 4);
                        _PosterizeValue.floatValue = bomo(-100, -2);
                        _SepiaRStrength.floatValue = bomo(0, 1);
                        _DarknessStrength.floatValue = bomo(0, 0.3);
                        _ToggleNoise.floatValue = 1;
                        _StaticBlack.floatValue = 1;
                        _StaticSize.floatValue = bomo(-2000, -500);
                        _StaticIntensity.floatValue = bomo(0, 0.6);
                    }
                    EditorGUILayout.Space();
                }
            }


            //all distortions
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntAllDistort))
            {

                alldistortClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), alldistortClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(alldistortClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.AllDistort, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (alldistortClick)
                {


                    //Distortion
                    EditorGUILayout.Space();
                    distortClick = SubmenuFoldout(propStyles.Distort.text, distortClick);
                    if (distortClick)
                    {
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleDistortion, "Allow Distortion");
                        materialEditor.ShaderProperty(_DistortionMap, "Distortion Map");
                        materialEditor.ShaderProperty(_DistortionX, "X Power");
                        materialEditor.ShaderProperty(_DistortionXSpeed, "X Speed");
                        materialEditor.ShaderProperty(_DistortionY, "Y Power");
                        materialEditor.ShaderProperty(_DistortionYSpeed, "Y Speed");
                        materialEditor.ShaderProperty(_DistortionRotate, "Rotation");
                        materialEditor.ShaderProperty(_DistortionRotateSpeed, "Rotation Speed");
                        materialEditor.ShaderProperty(_DistortionTransparency, "Transparency");
                        EditorGUILayout.Space();
                        drawDivider();
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                    }


                    //Ripple
                    rippleClick = SubmenuFoldout(propStyles.Ripple.text, rippleClick);
                    if (rippleClick)
                    {
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleRipple, propStyles.ToggleRippleStyle);
                        materialEditor.ShaderProperty(_ShockCenterX, propStyles.ShockCenterXStyle);
                        materialEditor.ShaderProperty(_ShockCenterY, propStyles.ShockCenterYStyle);
                        materialEditor.ShaderProperty(_ShockSpread, propStyles.ShockSpreadStyle);
                        materialEditor.ShaderProperty(_ShockMag, propStyles.ShockMagStyle);
                        materialEditor.ShaderProperty(_ShockDis, propStyles.ShockDisStyle);
                        EditorGUILayout.Space();
                    }


                    //Swirl
                    swirlClick = SubmenuFoldout(propStyles.Swirl.text, swirlClick);
                    if (swirlClick)
                    {
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleSwirl, propStyles.ToggleSwirlStyle);
                        materialEditor.ShaderProperty(_SwirlPower, propStyles.SwirlPowerStyle);
                        materialEditor.ShaderProperty(_SwirlRadius, propStyles.SwirlRadiusStyle);
                        materialEditor.ShaderProperty(_SwirlCenterX, propStyles.SwirlCenterXStyle);
                        materialEditor.ShaderProperty(_SwirlCenterY, propStyles.SwirlCenterYStyle);
                        EditorGUILayout.Space();
                    }



                    //Wavey
                    waveyClick = SubmenuFoldout(propStyles.Wavey.text, waveyClick);
                    if (waveyClick)
                    {
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleWavey, "Allow Wavey");
                        materialEditor.ShaderProperty(_WavesX, "X Waves");
                        materialEditor.ShaderProperty(_WavesXPower, "X Power");
                        materialEditor.ShaderProperty(_WavesXSpeed, "X Speed");
                        materialEditor.ShaderProperty(_WavesY, "Y Waves");
                        materialEditor.ShaderProperty(_WavesYPower, "Y Power");
                        materialEditor.ShaderProperty(_WavesYSpeed, "Y Speed");
                        EditorGUILayout.Space();
                    }


                    EditorGUILayout.Space();
                }
            }



            //dizzy
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntDizzy))
            {
                dizzyClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), dizzyClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(dizzyClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Dizzy, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (dizzyClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleDizzyEffect, propStyles.ToggleDizzyEffectStyle);
                    materialEditor.ShaderProperty(_DizzyMode, propStyles.DizzyModeStyle);
                    materialEditor.ShaderProperty(_DizzyAmountValue, propStyles.DizzyAmountValueStyle);
                    materialEditor.ShaderProperty(_DizzyRotationSpeed, propStyles.DizzyRotationSpeedStyle);
                    EditorGUILayout.Space();
                }
            }


            //duotone
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntDuotone))
            {
                duotoneClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), duotoneClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(duotoneClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Duotone, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (duotoneClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleDuotone, propStyles.ToggleDuotoneStyle);
                    materialEditor.ShaderProperty(_DuotoneHardness, propStyles.DuotoneHardnessStyle);
                    materialEditor.ShaderProperty(_DuotoneThreshold, propStyles.DuotoneThresholdStyle);
                    materialEditor.ShaderProperty(_DuotoneColOne, propStyles.DuotoneColOneStyle);
                    materialEditor.ShaderProperty(_DuotoneColTwo, propStyles.DuotoneColTwoStyle);
                    EditorGUILayout.Space();
                    //generateMessage("my duotone algorithm is based off of zoidbergs math", friendStyle); //credit
                    EditorGUILayout.Space();
                }
            }



            //edge distort
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntEdgeDistort))
            {
                edgeDistortClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), edgeDistortClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(edgeDistortClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.EdgeDistort, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (edgeDistortClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleEdgeDistort, propStyles.ToggleEdgeDistortStyle);
                    materialEditor.ShaderProperty(_EdgeDisX, propStyles.EdgeDisXStyle);
                    materialEditor.ShaderProperty(_EdgeDisY, propStyles.EdgeDisYStyle);
                    materialEditor.ShaderProperty(_ToggleEdgeDisRotate, propStyles.ToggleEdgeDisRotateStyle);
                    if (_ToggleEdgeDisRotate.floatValue == 1)
                    {
                        materialEditor.ShaderProperty(_EdgeDisRotStr, propStyles.EdgeDisRotStrStyle);
                        materialEditor.ShaderProperty(_EdgeDisRotSpeed, propStyles.EdgeDisRotSpeedStyle);
                    }
                    EditorGUILayout.Space();
                }
            }


            //fade projection
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntFadeProjection))
            {
                fadeprojectionClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), fadeprojectionClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(fadeprojectionClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Fade, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (fadeprojectionClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleFadeProjection, "Allow Fade Project");
                    materialEditor.ShaderProperty(_FadeLayer, "Project Layer:");
                    materialEditor.ShaderProperty(_FPZoom, "Project Zoom");
                    materialEditor.ShaderProperty(_FPFade, "Project Fade");
                    materialEditor.ShaderProperty(_FPColor, "Project Color");
                    if(_FadeLayer.floatValue == 1)
                    {
                        drawDepth(false);
                    }
                    EditorGUILayout.Space();
                }
            }


            //filter
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntFilter))
            {
                filterClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), filterClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(filterClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Filter, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (filterClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleFilter, propStyles.ToggleFilterStyle);
                    materialEditor.ShaderProperty(_ToggleAdvancedFilter, "Precise Controls?");
                    materialEditor.ShaderProperty(_ToggleColoredFilter, "Color Background?");
                    materialEditor.ShaderProperty(_FilterColor, propStyles.FilterColorStyle);
                    materialEditor.ShaderProperty(_FilterTolerance, propStyles.FilterToleranceStyle);
                    materialEditor.ShaderProperty(_FilterIntensity, propStyles._FilterIntensityStyle);
                    if (_ToggleAdvancedFilter.floatValue == 1)
                    {
                        materialEditor.ShaderProperty(_FilterMinR, "Min Red?");
                        materialEditor.ShaderProperty(_FilterMaxR, "Max Red?");
                        materialEditor.ShaderProperty(_FilterMinG, "Min Green?");
                        materialEditor.ShaderProperty(_FilterMaxG, "Max Green?");
                        materialEditor.ShaderProperty(_FilterMinB, "Min Blue?");
                        materialEditor.ShaderProperty(_FilterMaxB, "Max Blue?");
                    }
                    if (_ToggleColoredFilter.floatValue == 1)
                    {
                        materialEditor.ShaderProperty(_BackgroundFilterIntensity, "Backgrouund Strength");
                        materialEditor.ShaderProperty(_BackgroundFilterColor, "Background Color");
                    }
                    EditorGUILayout.Space();
                }
            }


            //film
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntFilm))
            {
                filmClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), filmClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(filmClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Film, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (filmClick)
                {
                    EditorGUILayout.Space();
                    //allow film
                    generateMessage("Main Settings", propInfoStyle);
                    materialEditor.ShaderProperty(_FilmPower, "Film Strength");
                    materialEditor.ShaderProperty(_FilmJitterAmount, propStyles.FilmJitterAmountStyle);
                    materialEditor.ShaderProperty(_FilmBrightness, propStyles.FilmBrightnessStyle);
                    materialEditor.ShaderProperty(_FilmItterations, propStyles.FilmItterationsStyle);
                    EditorGUILayout.Space();
                    drawDivider();
                    //line artifacts
                    generateMessage("Line Artifacts", propInfoStyle);
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_FilmAllowLines, propStyles.FilmAllowLinesStyle);
                    materialEditor.ShaderProperty(_FilmLinesOften, propStyles.FilmLinesOftenStyle);
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    //spot artifacts
                    generateMessage("Spot Artifacts", propInfoStyle);
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_FilmAllowSpots, propStyles.FilmAllowSpotsStyle);
                    materialEditor.ShaderProperty(_FilmSpotStrength, propStyles.FilmSpotStrengthStyle);
                    materialEditor.ShaderProperty(_FilmSpotsOften, propStyles.FilmSpotsOftenStyle);
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    //stripe artifacts
                    generateMessage("Stripe Artifacts", propInfoStyle);
                    materialEditor.ShaderProperty(_FilmAllowStripes, propStyles.FilmAllowStripesStyle);
                    materialEditor.ShaderProperty(_FilmStripesOften, propStyles.FilmStripesOftenStyle);
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    //stripe artifacts
                    generateMessage("Film Reel", propInfoStyle);
                    materialEditor.ShaderProperty(_ToggleReel, "Allow Film Reel?");
                    materialEditor.ShaderProperty(_ReelMode, "Reel Space");
                    materialEditor.ShaderProperty(_ReelSpeed, "Reel Speed");
                    materialEditor.ShaderProperty(_ReelJitter, "Reel Jitter");
                    materialEditor.ShaderProperty(_ReelWidth, "Reel Width");
                    materialEditor.ShaderProperty(_ReelBarAmounts, "Bar Amount");
                    materialEditor.ShaderProperty(_ReelBars, "Bar Thickness");
                    materialEditor.ShaderProperty(_ReelBarHeigth, "Bar Heigth");
                    materialEditor.ShaderProperty(_ReelRainbow, "Rainbow Reel?");
                    materialEditor.ShaderProperty(_ReelRainbowX, "X Rainbow?");
                    materialEditor.ShaderProperty(_ReelRainbowY, "Y Rainbow?");
                    materialEditor.ShaderProperty(_ReelColor, "Bar Color");
                    //footer
                    EditorGUILayout.Space();
                    drawDivider();

                    EditorGUILayout.Space();
                }
            }



            //fog
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntFog))
            {
                fogClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), fogClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(fogClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Fog, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (fogClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleFog, "Allow Fog");
                    materialEditor.ShaderProperty(_FogLayer, "Fog Layer:");
                    materialEditor.ShaderProperty(_FogDensity, "Fog Density");
                    materialEditor.ShaderProperty(_FogColor, "Fog Color");
                    materialEditor.ShaderProperty(_FogRainbow, "Rainbow Fog?");
                    materialEditor.ShaderProperty(_FogRainbowSpeed, "Rainbow Speed");
                    materialEditor.ShaderProperty(_FogSafe, "Safe Zone Around You?");
                    materialEditor.ShaderProperty(_FogSafeTol, "Zone Angle Tolerance");
                    drawDepth(true);
                    EditorGUILayout.Space();
                }
            }



            //glitch
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntGlitch))
            {
                glitchClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), glitchClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(glitchClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Glitch, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (glitchClick)
                {
                    EditorGUILayout.Space();

                    //CRT
                    glitchCRTClick = SubmenuFoldout("Manual Glitch", glitchCRTClick);
                    if (glitchCRTClick)
                    {
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleGlitch, propStyles.ToggleGlitchStyle);
                        materialEditor.ShaderProperty(_GlitchRedMap, propStyles.GlitchRedMapStyle);
                        materialEditor.ShaderProperty(_GlitchRedDistort, propStyles.GlitchRedDistortStyle);
                        materialEditor.ShaderProperty(_RedXGlitch, propStyles.RedXGlitchStyle);
                        materialEditor.ShaderProperty(_RedYGlitch, propStyles.RedYGlitchStyle);
                        materialEditor.ShaderProperty(_RedTileGlitch, propStyles.RedTileGlitchStyle);
                        materialEditor.ShaderProperty(_ToggleRandomGlitch, propStyles.ToggleRandomGlitchStyle);

                        //glitch animation controls
                        if (showGlitchAnimate == true)
                        {
                            glitchAnimClick = SubmenuFoldout("Glitch Animation", glitchAnimClick);
                            if (glitchAnimClick)
                            {
                                materialEditor.ShaderProperty(_ToggleRandomSideGlitch, propStyles.ToggleRandomSideGlitchStyle);
                                materialEditor.ShaderProperty(_XGAnimate, propStyles.XGAnimateStyle);
                                materialEditor.ShaderProperty(_YGAnimate, propStyles.YGAnimateStyle);
                                materialEditor.ShaderProperty(_TileGAnimate, propStyles.TileGAnimateStyle);
                                if (showGlitchRandDirection == true)
                                {
                                    glitchRandClick = SubmenuFoldout("Randomness Settings", glitchRandClick);
                                    if (glitchRandClick)
                                    {
                                        materialEditor.ShaderProperty(_GlitchSideFactor, propStyles.GlitchSideFactorStyle);
                                    }
                                }
                            }
                        }

                        //footer
                        drawDivider();
                    }

                    //Girlscam
                    girlscamClick = SubmenuFoldout("Girlscam Glitch", girlscamClick);
                    if (girlscamClick)
                    {
                        EditorGUILayout.Space();

                        //options
                        materialEditor.ShaderProperty(_ToggleGirlscam, propStyles.ToggleGirlscamStyle);
                        materialEditor.ShaderProperty(_GirlscamDir, "Direction");
                        materialEditor.ShaderProperty(_GirlscamStrength, propStyles.GirlscamStrengthStyle);
                        materialEditor.ShaderProperty(_GirlscamTime, propStyles.GirlscamTimeStyle);

                      
                        //footer
                        drawDivider();
                    }

                    //RGB
                    glitchRGBClick = SubmenuFoldout(propStyles.RGBGlitch.text, glitchRGBClick);
                    if (glitchRGBClick)
                    {
                        //lock
                        if(ntRGB){
                            lockMessage("RGB Glitch", "Chromatic Abberation", false);
                            //glitchRGBClick = false;
                        }
                        EditorGUILayout.Space();
                        generateMessage("maps not required for block glitch", friendStyle);
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleRGBGlitch, "Allow RGB Glitch?");
                        materialEditor.ShaderProperty(_RGBBlockMethod, "Block Applies To:");
                        materialEditor.ShaderProperty(_RedNoiseMap, "Red Noise Map");
                        materialEditor.ShaderProperty(_RedNoisePower, "Red Noise Power");
                        materialEditor.ShaderProperty(_RedNoiseSpeed, "Red Noise Speed");
                        materialEditor.ShaderProperty(_RedBlockCount, "Red Blocks");
                        materialEditor.ShaderProperty(_RedBlocks, "Red Block Power");
                        materialEditor.ShaderProperty(_RedBlockSpeed, "Red Block Speed");
                        materialEditor.ShaderProperty(_GreenNoiseMap, "Green Noise Map");
                        materialEditor.ShaderProperty(_GreenNoisePower, "Green Noise Power");
                        materialEditor.ShaderProperty(_GreenNoiseSpeed, "Green Noise Speed");
                        materialEditor.ShaderProperty(_GreenBlockCount, "Green Blocks");
                        materialEditor.ShaderProperty(_GreenBlocks, "Green Block Power");
                        materialEditor.ShaderProperty(_GreenBlockSpeed, "Green Block Speed");
                        materialEditor.ShaderProperty(_BlueNoiseMap, "Blue Noise Map");
                        materialEditor.ShaderProperty(_BlueNoisePower, "Blue Noise Power");
                        materialEditor.ShaderProperty(_BlueNoiseSpeed, "Blue Noise Speed");
                        materialEditor.ShaderProperty(_BlueBlockCount, "Blue Blocks");
                        materialEditor.ShaderProperty(_BlueBlocks, "Blue Block Power");
                        materialEditor.ShaderProperty(_BlueBlockSpeed, "Blue Block Speed");
                        materialEditor.ShaderProperty(_RGBGlitchTrans, "RGB Glitch Transparency");

                        //footer
                        drawDivider();
                    }

                    //Block
                    glitchBlockClick = SubmenuFoldout("Block Glitch", glitchBlockClick);
                    if (glitchBlockClick)
                    {
                        EditorGUILayout.Space();

                        //settings
                        EditorGUILayout.Space();
                        drawDivider();
                        generateMessage("Main Settings", propInfoStyle);
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleBlockyGlitch, propStyles.ToggleBlockyGlitchStyle);
                        materialEditor.ShaderProperty(_BlockGlitchMap, "Block Noise Map");
                        materialEditor.ShaderProperty(_AllowBGX, propStyles.AllowBGXStyle);
                        materialEditor.ShaderProperty(_AllowBGY, propStyles.AllowBGYStyle);
                        materialEditor.ShaderProperty(_BlockyGlitchStrength, propStyles.BlockyGlitchStrengthStyle);
                        materialEditor.ShaderProperty(_BlockyGlitchSpeed, propStyles.BlockyGlitchSpeedStyle);
                        materialEditor.ShaderProperty(_BDepthX, propStyles.BDepthXStyle);
                        materialEditor.ShaderProperty(_BDepthY, propStyles.BDepthYStyle);
                        //materialEditor.ShaderProperty(_AllowRandomnessIncrease, propStyles.AllowRandomnessIncreaseStyle);
                        materialEditor.ShaderProperty(_BGRandomnessIncrease, propStyles.BGRandomnessInceStyle);
                        EditorGUILayout.Space();
                        drawDivider();
                        EditorGUILayout.Space();
                        generateMessage("Abberation Settings", propInfoStyle);
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleBlockyRGB, propStyles.ToggleBlockyRGBStyle);
                        materialEditor.ShaderProperty(_BlockyRGBPush, propStyles.BlockyRGBPushStyle);
                        materialEditor.ShaderProperty(_BlockyRGBSpeed, propStyles.BlockyRGBSpeedStyle);
                        //footer
                        EditorGUILayout.Space();
                        drawDivider();
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                    }

                    //Colors
                    glitchColorsClick = SubmenuFoldout("Degrading Glitch", glitchColorsClick);
                    if (glitchColorsClick)
                    {
                        materialEditor.ShaderProperty(_BGOverlayToggle, "Allow Color Degrading");
                        materialEditor.ShaderProperty(_BGOverlayMap, "Degrading Noise Map");
                        materialEditor.ShaderProperty(_AllowBGColors, propStyles.AllowBGColorsStyle);
                        materialEditor.ShaderProperty(_BGOverlayColor, propStyles.BGOverlayColorStyle);
                        materialEditor.ShaderProperty(_BGBrokenRandom, "Color Randomness");
                        materialEditor.ShaderProperty(_BGOverlayIntensity, propStyles.BGOverlayIntensityStyle);
                        materialEditor.ShaderProperty(_BGColorIntensity, propStyles.BGBrokenColorIntensityStyle);
                    }


                    //Scanline
                    glitchScanlineClick = SubmenuFoldout("Scanline Glitch", glitchScanlineClick);
                    if (glitchScanlineClick)
                    {
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleScanline, propStyles.ToggleScanlineStyle);
                        materialEditor.ShaderProperty(_ScanlineDir, "Scanline  Direction");
                        materialEditor.ShaderProperty(_ScanlinePush, propStyles.ScanlinePushStyle);
                        materialEditor.ShaderProperty(_ScanlineSize, propStyles.ScanlineSizeStyle);
                        materialEditor.ShaderProperty(_ScanlineSpeed, propStyles.ScanlineSpeedStyle);
                        EditorGUILayout.Space();
                    }

                    //Pixelate Glitch
                    glitchpixelClick = SubmenuFoldout("Pixelation Glitch", glitchpixelClick);
                    if (glitchpixelClick)
                    {
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_GTogglePixelate, "Allow Pixelation Glitch");
                        materialEditor.ShaderProperty(_GPixelGlitchMap, "Pixelation Noise Map");
                        materialEditor.ShaderProperty(_GPixelStrength, "X Pixelation");
                        materialEditor.ShaderProperty(_GPixelStrengthY, "Y Pixelation");
                        materialEditor.ShaderProperty(_GPixelFreq, "Pixelation Frequency"); 
                        EditorGUILayout.Space();
                    }

                    EditorGUILayout.Space();
                }
            }


            //Grain (Static)
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntNoise))
            {
                staticClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), staticClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(staticClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Static, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (staticClick)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    drawDivider();
                    generateMessage("Color Settings", helpInfoStyle);
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleNoise, propStyles.ToggleNoiseStyle);
                    materialEditor.ShaderProperty(_StaticIntensity, propStyles.StaticIntensityStyle);
                    materialEditor.ShaderProperty(_StaticSize, "Grain Size");
                    materialEditor.ShaderProperty(_StaticColor, propStyles.StaticColorStyle);
                    materialEditor.ShaderProperty(_StaticBlack, "Use Black Grain");
                    materialEditor.ShaderProperty(_StaticOverlay, "Black Grain Overlay?");
                    EditorGUILayout.Space();
                    drawDivider();
                    generateMessage("Animation", helpInfoStyle);
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleAnimatedNoise, propStyles.ToggleAnimatedNoiseStyle);
                    materialEditor.ShaderProperty(_StaticSpeed, propStyles.StaticSpeedStyle);
                    EditorGUILayout.Space();
                    drawDivider();
                    generateMessage("Map", helpInfoStyle);
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleStaticMap, "Use Grain Map?");
                    materialEditor.ShaderProperty(_StaticMap, "Grain Map");
                    drawDivider();
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                }
            }


            //HUE (recolor)
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntRecolor))
            {
                recolorClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), recolorClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(recolorClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Recolor, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (recolorClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleRecolor, propStyles.ToggleRecolorStyle);
                    materialEditor.ShaderProperty(_ToggleRecolorAnimate, "Animate?");
                    materialEditor.ShaderProperty(_RecolorBright, propStyles.RecolorBrightStyle);
                    materialEditor.ShaderProperty(_RecolorSat, propStyles.RecolorSaturationStyle);
                    materialEditor.ShaderProperty(_RecolorHue, propStyles.RecolorHueStyle);
                    if (_ToggleRecolorAnimate.floatValue == 1)
                    {
                        materialEditor.ShaderProperty(_RecolorSpeed, propStyles.RecolorSpeedStyle);
                    }
                    EditorGUILayout.Space();
                }
            }


            //linocut
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntLinocut))
            {
                linocutClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), linocutClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(linocutClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Linocut, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (linocutClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_LinocutOpacity, propStyles.LinocutOpacityStyle);
                    materialEditor.ShaderProperty(_LinocutPower, propStyles.LinocutPowerStyle);
                    materialEditor.ShaderProperty(_LinocutColor, "Linocut Color");
                    EditorGUILayout.Space();
                }
            }


            //inception
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntInception))
            {
                inceptionClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), inceptionClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(inceptionClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Inceptions, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (inceptionClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleInception, "Allow Inception");
                    materialEditor.ShaderProperty(_InceptionSize, "Screen Size");
                    materialEditor.ShaderProperty(_InceptionShiftX, "X Shift");
                    materialEditor.ShaderProperty(_InceptionShiftY, "Y Shift");
                    materialEditor.ShaderProperty(_InceptionItterations, "FX Layer:");
                    EditorGUILayout.Space();
                }
            }


            //mirror
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntMirror))
            {
                mirrorClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), mirrorClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(mirrorClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Mirror, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (mirrorClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleMirror, propStyles.ToggleMirrorStyle);
                    materialEditor.ShaderProperty(_MirrorHU, propStyles.MirrorUHStyle);
                    materialEditor.ShaderProperty(_MirrorHO, propStyles.MirrorOHStyle);
                    materialEditor.ShaderProperty(_MirrorVU, propStyles.MirrorUVStyle);
                    materialEditor.ShaderProperty(_MirrorVO, propStyles.MirrorOVStyle);
                    EditorGUILayout.Space();
                }
            }


            //mirror
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntNoiseMask))
            {
                noisemaskClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), noisemaskClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(noisemaskClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.NoiseMask, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (noisemaskClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleNoiseMask, "Allow Noise Mask");
                    materialEditor.ShaderProperty(_NoiseMask, "Noise Mask");
                    materialEditor.ShaderProperty(_NoiseMaskColor, "Mask Color");
                    materialEditor.ShaderProperty(_NoiseMaskSpeedOne, "Mask Speed One");
                    materialEditor.ShaderProperty(_NoiseMaskSpeedTwo, "Mask Speed Two");
                    materialEditor.ShaderProperty(_NoiseMaskScale, "Mask Scale");
                    materialEditor.ShaderProperty(_NoiseMaskGlow, "Mask Glow");
                    EditorGUILayout.Space();
                }
            }


            //all outline stuff
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntAllOutlines))
            {
                alloutlineClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), alloutlineClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(alloutlineClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.AllOutlines, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (alloutlineClick)
                {
                    EditorGUILayout.Space();


                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    drawDivider();
                    generateMessage("Colored Outline Effects", helpInfoStyle);
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();

                    //colored outline // edge detection
                    if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntEdgeDetect))
                    {
                        edgeDetectClick = SubmenuFoldout(propStyles.EdgeDetection.text, edgeDetectClick);
                        if (edgeDetectClick)
                        {
                            EditorGUILayout.Space();
                            EditorGUILayout.Space();
                            drawDivider();
                            generateMessage("Draw Settings", helpInfoStyle);
                            EditorGUILayout.Space();
                            EditorGUILayout.Space();
                            materialEditor.ShaderProperty(_ToggleED, propStyles.ToggleEdgeDetection);
                            materialEditor.ShaderProperty(_EDColor, propStyles.EDColorStyle);
                            materialEditor.ShaderProperty(_EDWidth, "Outline Width");
                            materialEditor.ShaderProperty(_EDTolerance, propStyles.EDToleranceStyle);
                            EditorGUILayout.Space();
                            drawDivider();
                            generateMessage("Offset Settings", helpInfoStyle);
                            EditorGUILayout.Space();
                            EditorGUILayout.Space();
                            materialEditor.ShaderProperty(_EDXOffset, propStyles.EDXOffsetStyle);
                            materialEditor.ShaderProperty(_EDYOffset, propStyles.EDYOffsetStyle);
                            EditorGUILayout.Space();
                            drawDivider();
                            generateMessage("Color Settings", helpInfoStyle);
                            EditorGUILayout.Space();
                            EditorGUILayout.Space();
                            materialEditor.ShaderProperty(_EDBW, "B&W Screen?");
                            materialEditor.ShaderProperty(_SepiaColor, "B&W Color Mod");
                            materialEditor.ShaderProperty(_EDGlow, propStyles.EDGlowStyle);
                            materialEditor.ShaderProperty(_EDTrans, propStyles.EDTransStyle);
                            EditorGUILayout.Space();
                            drawDivider();
                            EditorGUILayout.Space();
                            EditorGUILayout.Space();
                        }
                    }


                    //edge rainbow
                    if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntEdgeRainbow))
                    {
                        edgeRainbowClick = SubmenuFoldout(propStyles.EdgeRainbow.text, edgeRainbowClick);
                        if (edgeRainbowClick)
                        {
                            EditorGUILayout.Space();
                            materialEditor.ShaderProperty(_EDToggleRainbow, "Allow Rainbow?");
                            materialEditor.ShaderProperty(_EDToggleHSVRainbowX, "Vertical Rainbow?");
                            materialEditor.ShaderProperty(_EDToggleHSVRainbowY, "Horizontal Rainbow?");
                            materialEditor.ShaderProperty(_EDHSVRainbowHue, "Color Spread");
                            materialEditor.ShaderProperty(_EDHSVRainbowSat, "Saturation");
                            materialEditor.ShaderProperty(_EDHSVRainbowLight, "Lightness");
                            materialEditor.ShaderProperty(_EDHSVRainbowTime, "Time");
                            EditorGUILayout.Space();
                        }
                    }


                    //edge background
                    if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntEdgeBackground))
                    {
                        edgeBackgroundClick = SubmenuFoldout(propStyles.EdgeDetectionBackground.text, edgeBackgroundClick);
                        if (edgeBackgroundClick)
                        {
                            materialEditor.ShaderProperty(_EDBackPower, "Background Power");
                            materialEditor.ShaderProperty(_EDBackColor, "Background Color");
                        }
                    }



                    //edge ramp
                    if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntEdgeRamp))
                    {
                        edgeRampClick = SubmenuFoldout(propStyles.EdgeDetectionRamp.text, edgeRampClick);
                        if (edgeRampClick)
                        {
                            materialEditor.ShaderProperty(_EDRampAllow, "Allow Gradient?");
                            materialEditor.ShaderProperty(_EDRampMap, "Color Map");
                            materialEditor.ShaderProperty(_EDRampX, "X Size");
                            materialEditor.ShaderProperty(_EDRampY, "Y Size");
                            materialEditor.ShaderProperty(_EDRampSX, "X Scroll");
                            materialEditor.ShaderProperty(_EDRampSY, "Y Scroll");
                            materialEditor.ShaderProperty(_EDRampScroll, "Autoscroll?");
                        }
                    }


                    //edge dither
                    if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntEdgeDither))
                    {
                        edgeDitherClick = SubmenuFoldout(propStyles.EdgeDither.text, edgeDitherClick);
                        if (edgeDitherClick)
                        {
                            materialEditor.ShaderProperty(_EDDither, "Dither Amount");
                            materialEditor.ShaderProperty(_EDDitherSpeed , "Dither Speed");
                        }
                    }


                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    drawDivider();
                    generateMessage("Other Outlines", helpInfoStyle);
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();


                    //neon outline
                    if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntOutline))
                    {
                        outlineClick = SubmenuFoldout(propStyles.Outline.text, outlineClick);
                        if (outlineClick)
                        {
                            EditorGUILayout.Space();
                            materialEditor.ShaderProperty(_ToggleOutline, "Neon Power");
                            materialEditor.ShaderProperty(_ToggleSepiaOutline, "Desaturation");
                            materialEditor.ShaderProperty(_OutlineOffset, "Tolerance");
                            materialEditor.ShaderProperty(_OutlineActualOffset, "Clarity");
                            materialEditor.ShaderProperty(_OutlineModOne, "Darkness");
                            materialEditor.ShaderProperty(_OutlineModTwo, "Red Value");
                            materialEditor.ShaderProperty(_OutlineModThree, "Green Value");
                            materialEditor.ShaderProperty(_OutlineModFour, "Blue Value");
                            EditorGUILayout.Space();
                        }
                    }

                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();


                    EditorGUILayout.Space();
                }
            }




            //overlay
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntOverlay))
            {
                overlayClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), overlayClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(overlayClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Overlay, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (overlayClick)
                {
                    EditorGUILayout.Space();
                    drawDivider();
                    materialEditor.ShaderProperty(_ToggleOverlay, propStyles.ToggleOverlayStyle);
                    materialEditor.ShaderProperty(_UseSepOverlay, "Different VR Image?");
                    materialEditor.ShaderProperty(_OverlayTexture, propStyles.OverlayTextureStyle);
                    if (showVRTexture == true)
                    {
                        materialEditor.ShaderProperty(_VROverlayTexture, propStyles.VROverlayTextureStyle);
                    }
                    drawDivider();
                    materialEditor.ShaderProperty(_ToggleTransparentImage, "Transparent Image?");
                    materialEditor.ShaderProperty(_OverlayTransparency, propStyles.OverlayTransparencyStyle);
                    drawDivider();
                    if (_OverlayTiling.floatValue > 0) generateMessage("overlay may be flipped! set to negative value to fix", friendStyle);
                    materialEditor.ShaderProperty(_OverlayTiling, propStyles.OverlayTilingStyle);
                    materialEditor.ShaderProperty(_OverlayYAdjust, propStyles.OverlayYAdjustStyle);
                    materialEditor.ShaderProperty(_OverlayXAdjust, propStyles.OverlayXAdjustStyle);
                    drawDivider();
                    materialEditor.ShaderProperty(_OverlayYShift, propStyles.OverlayXShiftStyle);
                    materialEditor.ShaderProperty(_OverlayXShift, propStyles.OverlayYShiftStyle);
                    drawDivider();
                    materialEditor.ShaderProperty(_OvScOneT, "Tile and Scroll?");
                    materialEditor.ShaderProperty(_OvScOne, "X Scroll");
                    materialEditor.ShaderProperty(_OvScOneY, "Y Scroll");
                    drawDivider();
                    materialEditor.ShaderProperty(_OverlayTrans, propStyles.OverlayTransStyle);
                    if (_OverlayTrans.floatValue == 1)
                    {
                        materialEditor.ShaderProperty(_OverlayTransX, propStyles.OverlayTransXStyle);
                        materialEditor.ShaderProperty(_OverlayTransY, propStyles.OverlayTransYStyle);
                    }
                    drawDivider();
                    EditorGUILayout.Space();
                    generateMessage("need more images?", helpInfoStyle);
                    EditorGUILayout.Space();
                    //second overlay
                    overlaytwoClick = SubmenuFoldout("Second Overlay", overlaytwoClick);
                    if (overlaytwoClick)
                    {
                        drawDivider();
                        materialEditor.ShaderProperty(_ToggleOverlayTwo, propStyles.ToggleOverlayStyleTwo);
                        materialEditor.ShaderProperty(_OverlayTextureTwo, propStyles.OverlayTextureStyleTwo);
                        drawDivider();
                        materialEditor.ShaderProperty(_ToggleTransparentImageTwo, "Transparent Image?");
                        materialEditor.ShaderProperty(_OverlayTransparencyTwo, propStyles.OverlayTransparencyStyleTwo);
                        drawDivider();
                        if (_OverlayTilingTwo.floatValue > 0) generateMessage("overlay may be flipped! set to negative value to fix", friendStyle);
                        materialEditor.ShaderProperty(_OverlayTilingTwo, propStyles.OverlayTilingStyleTwo);
                        materialEditor.ShaderProperty(_OverlayYAdjustTwo, propStyles.OverlayYAdjustStyleTwo);
                        materialEditor.ShaderProperty(_OverlayXAdjustTwo, propStyles.OverlayXAdjustStyleTwo);
                        drawDivider();
                        materialEditor.ShaderProperty(_OverlayYShiftTwo, propStyles.OverlayXShiftStyleTwo);
                        materialEditor.ShaderProperty(_OverlayXShiftTwo, propStyles.OverlayYShiftStyleTwo);
                        drawDivider();
                        materialEditor.ShaderProperty(_OvScTwoT, "Tile and Scroll?");
                        materialEditor.ShaderProperty(_OvScTwo, "X Scroll");
                        materialEditor.ShaderProperty(_OvScTwoY, "Y Scroll");
                        drawDivider();
                        materialEditor.ShaderProperty(_OverlayTransTwo, propStyles.OverlayTransStyleTwo);
                        if (_OverlayTransTwo.floatValue == 1)
                        {
                            materialEditor.ShaderProperty(_OverlayTransXTwo, propStyles.OverlayTransXStyleTwo);
                            materialEditor.ShaderProperty(_OverlayTransYTwo, propStyles.OverlayTransYStyleTwo);
                        }
                        drawDivider();
                        EditorGUILayout.Space();
                    }


                    //third overlay
                    overlaythreeClick = SubmenuFoldout("Third Overlay", overlaythreeClick);
                    if (overlaythreeClick)
                    {
                        drawDivider();
                        materialEditor.ShaderProperty(_ToggleOverlayThree, propStyles.ToggleOverlayStyleThree);
                        materialEditor.ShaderProperty(_OverlayTextureThree, propStyles.OverlayTextureStyleThree);
                        drawDivider();
                        materialEditor.ShaderProperty(_ToggleTransparentImageThree, "Transparent Image?");
                        materialEditor.ShaderProperty(_OverlayTransparencyThree, propStyles.OverlayTransparencyStyleThree);
                        drawDivider();
                        if (_OverlayTilingThree.floatValue > 0) generateMessage("overlay may be flipped! set to negative value to fix", friendStyle);
                        materialEditor.ShaderProperty(_OverlayTilingThree, propStyles.OverlayTilingStyleThree);
                        materialEditor.ShaderProperty(_OverlayYAdjustThree, propStyles.OverlayYAdjustStyleThree);
                        materialEditor.ShaderProperty(_OverlayXAdjustThree, propStyles.OverlayXAdjustStyleThree);
                        drawDivider();
                        materialEditor.ShaderProperty(_OverlayYShiftThree, propStyles.OverlayXShiftStyleThree);
                        materialEditor.ShaderProperty(_OverlayXShiftThree, propStyles.OverlayYShiftStyleThree);
                        drawDivider();
                        materialEditor.ShaderProperty(_OvScThreeT, "Tile and Scroll?");
                        materialEditor.ShaderProperty(_OvScThree, "X Scroll");
                        materialEditor.ShaderProperty(_OvScThreeY, "Y Scroll");
                        drawDivider();
                        materialEditor.ShaderProperty(_OverlayTransThree, propStyles.OverlayTransStyleThree);
                        if (_OverlayTransThree.floatValue == 1)
                        {
                            materialEditor.ShaderProperty(_OverlayTransXThree, propStyles.OverlayTransXStyleThree);
                            materialEditor.ShaderProperty(_OverlayTransYThree, propStyles.OverlayTransYStyleThree);
                        }
                        drawDivider();
                    }


                    EditorGUILayout.Space();
                }
            }


            //gif
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntGifOverlay))
            {
                gifClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), gifClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(gifClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.GifOverlay, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (gifClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleGifOverlay, propStyles.ToggleGifOverlayStyle);
                    materialEditor.ShaderProperty(_OverlaySpritesheet, propStyles.OverlaySpritesheetStyle);
                    materialEditor.ShaderProperty(_ToggleACTUALTransparentGif, "Transparent GIF?");
                    materialEditor.ShaderProperty(_GifTransparency, propStyles.GifTransparencyStyle);
                    drawDivider();
                    materialEditor.ShaderProperty(_OSSRows, propStyles.OSSRowsStyle);
                    materialEditor.ShaderProperty(_OSSColumns, propStyles.OSSColumnsStyle);
                    materialEditor.ShaderProperty(_OSSSpeed, propStyles.OSSSpeedsStyle);
                    drawDivider();
                    materialEditor.ShaderProperty(_GifTiling, propStyles.GifTilingStyle);
                    materialEditor.ShaderProperty(_GifYAdjust, propStyles.GifYAdjustStyle);
                    materialEditor.ShaderProperty(_GifXAdjust, propStyles.GifXAdjustStyle);
                    drawDivider();
                    materialEditor.ShaderProperty(_GifXShift, propStyles.GifXShiftStyle);
                    materialEditor.ShaderProperty(_GifYShift, propStyles.GifYShiftStyle);
                    drawDivider();
                    EditorGUILayout.Space();
                }
            }


            //radial
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntRadial))
            {
                radialClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), radialClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(radialClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.AllRadial, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (radialClick)
                {
                    //lock
                    if(ntBlur){
                        lockMessage("Radial", "Blur", false);
                        //radialClick = false;
                    }
                    drawDivider();
                    EditorGUILayout.Space();
                    generateMessage("Radial Settings", helpInfoStyle);
                    EditorGUILayout.Space();
                    //radial blur
                    radialblurClick = SubmenuFoldout("Blur Settings", radialblurClick);
                    if (radialblurClick)
                    {
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleRadialBlur, "Allow Radial Blur");
                        materialEditor.ShaderProperty(_RBMode, "Projection Mode");
                        materialEditor.ShaderProperty(_RadialBlurDistance, "Blur");
                        materialEditor.ShaderProperty(_RBItterations, "Itterations");
                        materialEditor.ShaderProperty(_RBEmpower, "Power by Itteration?");
                        EditorGUILayout.Space();
                    }
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    generateMessage("Radial Effects", helpInfoStyle);
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    //didnt mean nt meant click but oh well oof
                    //radial outline
                    if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntRadialOutline))
                    {
                        radialoutlineClick = SubmenuFoldout(propStyles.RadialOutline.text, radialoutlineClick);
                        if (radialoutlineClick)
                        {
                            EditorGUILayout.Space();
                            EditorGUILayout.Space();
                            drawDivider();
                            generateMessage("Outline Settings", friendStyle);
                            EditorGUILayout.Space();
                            materialEditor.ShaderProperty(_RBToggleED, propStyles.ToggleEdgeDetection);
                            materialEditor.ShaderProperty(_RBEDOnly, "Outline Only:");
                            if(_RBEDOnly.floatValue == 1) materialEditor.ShaderProperty(_RBEDBalance, "Lighting Balance");
                            materialEditor.ShaderProperty(_RBEDColor, propStyles.EDColorStyle);
                            materialEditor.ShaderProperty(_RBEDWidth, "Outline Width");
                            materialEditor.ShaderProperty(_RBEDTolerance, propStyles.EDToleranceStyle);
                            materialEditor.ShaderProperty(_RBEDBW, "B&W Screen?");
                            materialEditor.ShaderProperty(_SepiaColor, "B&W Color Mod");
                            materialEditor.ShaderProperty(_RBEDTrans, propStyles.EDTransStyle);
                            materialEditor.ShaderProperty(_RBEDBackPower, "Background Power");
                            materialEditor.ShaderProperty(_RBEDBackColor, "Background Color");
                            EditorGUILayout.Space();
                            drawDivider();
                            generateMessage("Rainbow?", friendStyle);
                            EditorGUILayout.Space();
                            materialEditor.ShaderProperty(_RBEDToggleRainbow, "Allow Rainbow?");
                            materialEditor.ShaderProperty(_RBEDToggleHSVRainbowX, "Vertical Rainbow?");
                            materialEditor.ShaderProperty(_RBEDToggleHSVRainbowY, "Horizontal Rainbow?");
                            materialEditor.ShaderProperty(_RBEDHSVRainbowHue, "Color Spread");
                            materialEditor.ShaderProperty(_RBEDHSVRainbowSat, "Saturation");
                            materialEditor.ShaderProperty(_RBEDHSVRainbowLight, "Lightness");
                            materialEditor.ShaderProperty(_RBEDHSVRainbowTime, "Time");
                            EditorGUILayout.Space();
                            drawDivider();
                            EditorGUILayout.Space();
                        }
                    }
                    //radial dither
                    radialditherClick = SubmenuFoldout("Radial Dither", radialditherClick);
                    if (radialditherClick)
                    {
                        materialEditor.ShaderProperty(_RBDither, "Dither Power");
                        materialEditor.ShaderProperty(_RBDitherSpeed, "Dither Speed");
                    }
                    //radial rgb
                    radialrgbClick = SubmenuFoldout("Radial CA", radialrgbClick);
                    if (radialrgbClick)
                    {
                        materialEditor.ShaderProperty(_RBCAOffset, "CA Offset");
                        materialEditor.ShaderProperty(_RBCATrans, "CA Transparency");
                    }
                    //radial rotate
                    radialrotateClick = SubmenuFoldout("Radial Rotate", radialrotateClick);
                    if (radialrotateClick)
                    {
                        materialEditor.ShaderProperty(_RBRotate, "Rotate");
                        materialEditor.ShaderProperty(_RBRotateSpeed, "Rotate speed");
                    }
                    //radial rainbow
                    ntRadialRainbow = SubmenuFoldout("Radial Rainbow", ntRadialRainbow);
                    if (ntRadialRainbow)
                    {
                        materialEditor.ShaderProperty(_RBToggleRainbow, "Allow Rainbow?");
                        materialEditor.ShaderProperty(_RBToggleHSVRainbowX, "Vertical Rainbow?");
                        materialEditor.ShaderProperty(_RBToggleHSVRainbowY, "Horizontal Rainbow?");
                        materialEditor.ShaderProperty(_RBHSVRainbowHue, "Color Spread");
                        materialEditor.ShaderProperty(_RBHSVRainbowSat, "Saturation");
                        materialEditor.ShaderProperty(_RBHSVRainbowLight, "Lightness");
                        materialEditor.ShaderProperty(_RBHSVRainbowTime, "Time");
                    }
                    //radial grain
                    ntRadialGrain = SubmenuFoldout("Radial Grain", ntRadialGrain);
                    if (ntRadialGrain)
                    {
                        materialEditor.ShaderProperty(_RBGrainPower, "Grain Power");
                        materialEditor.ShaderProperty(_RBGrainSpeed, "Grain Speed");
                        materialEditor.ShaderProperty(_RBGrainColor, "Grain Color");
                        materialEditor.ShaderProperty(_RBGrainBlack, "Black Grain?");
                    }

                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                }
            }


            //rainbow
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntHSVRainbow))
            {
                rainbowClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), rainbowClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(rainbowClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Rainbow, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (rainbowClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleHSVRainbow, "Rainbow Transparency");
                    materialEditor.ShaderProperty(_ToggleHSVRainbowX, propStyles.ToggleHSVRainbowXStyle);
                    materialEditor.ShaderProperty(_ToggleHSVRainbowY, propStyles.ToggleHSVRainbowYStyle);
                    materialEditor.ShaderProperty(_HSVRainbowHue, propStyles.HSVRainbowHueStyle);
                    materialEditor.ShaderProperty(_HSVRainbowSat, propStyles.HSVRainbowSatStyle);
                    materialEditor.ShaderProperty(_HSVRainbowLight, propStyles.HSVRainbowLightStyle);
                    materialEditor.ShaderProperty(_HSVRainbowTime, propStyles.HSVRainbowTimeStyle);
                    EditorGUILayout.Space();
                }
            }


            //ramp
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntRampEffect))
            {
                rampClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), rampClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(rampClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Ramp, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (rampClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleRampEffect, "Ramp Transparency");
                    materialEditor.ShaderProperty(_RampColorChannel, "Use Color Channel");
                    materialEditor.ShaderProperty(_RampMap, propStyles.RampMapStyle);
                    materialEditor.ShaderProperty(_RampOneLighting, propStyles.RampOneLightingStyle);
                    materialEditor.ShaderProperty(_RampOneDepth, propStyles.RampOneDepthStyle);
                    materialEditor.ShaderProperty(_RampOneStrength, propStyles.RampOneStrengthStyle);
                    materialEditor.ShaderProperty(_ToggleRampOneAnimate, propStyles.ToggleRampOneAnimateStyle);
                    materialEditor.ShaderProperty(_RampOneSpeed, propStyles.RampOneSpeedStyle);
                    EditorGUILayout.Space();
                }
            }


            //Rgb zoom
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntRGBZoom))
            {
                rgbzoomClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), rgbzoomClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(rgbzoomClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.RGBZoom, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (rgbzoomClick)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    drawDivider();
                    generateMessage("Zoom Settings", helpInfoStyle);
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleRGBZoom, propStyles.ToggleRGBZoomStyle);
                    materialEditor.ShaderProperty(_RedZoom, propStyles.RedZoomStyle);
                    materialEditor.ShaderProperty(_GreenZoom, propStyles.GreenZoomStyle);
                    materialEditor.ShaderProperty(_BlueZoom, propStyles.BlueZoomStyle);
                    EditorGUILayout.Space();
                    drawDivider();
                    generateMessage("Transparency Settings", helpInfoStyle);
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_RGBZoomTrans, "Red Visibility");
                    materialEditor.ShaderProperty(_RGBZoomTransG, "Green Visibility");
                    materialEditor.ShaderProperty(_RGBZoomTransB, "Blue Visibility");
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                }
            }


            //Rotate
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntRotater))
            {
                rotateClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), rotateClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(rotateClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Rotate, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (rotateClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleRotater, propStyles.ToggleRotaterStyle);
                    materialEditor.ShaderProperty(_RotaterValue, propStyles.RotaterValueStyle);
                    materialEditor.ShaderProperty(_ToggleRotaterAnimate, propStyles.ToggleRotaterAnimateStyle);
                    materialEditor.ShaderProperty(_RotaterSpin, propStyles.RotaterSpinStyle);
                    EditorGUILayout.Space();
                }
            }


            //Pixelate
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntPixelate))
            {
                pixelateClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), pixelateClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(pixelateClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Pixelate, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (pixelateClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_TogglePixelate, propStyles.TogglePixelateStyle);
                    materialEditor.ShaderProperty(_PixelateStrength, "X Pixelate");
                    materialEditor.ShaderProperty(_PixelateStrengthY, "Y Pixelate");
                    EditorGUILayout.Space();
                }
            }


            //Screenpull
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntScreenpull))
            {
                screenpullClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), screenpullClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(screenpullClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Screenpull, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (screenpullClick)
                {
                    EditorGUILayout.Space();
                    if (_TearToMirror.floatValue == 1 || _TearToRepeat.floatValue == 1 || _AllowTearFix.floatValue == 1)
                    {
                        generateMessage("Screentear is being fixed! Turn this option off\nfor best screen push results.", helpInfoStyle);
                        EditorGUILayout.Space();
                    }
                    materialEditor.ShaderProperty(_ToggleScreenpull, "Allow Screen Push");
                    materialEditor.ShaderProperty(_ScreenpullMode, "Push By");
                    if (_ScreenpullMode.floatValue == 1)
                    {
                        materialEditor.ShaderProperty(_ScreenpullStrength, "Horizontal Push");
                        materialEditor.ShaderProperty(_ScreenpullStrengthTwo, "Vertical Push");
                    }
                    else if (_ScreenpullMode.floatValue == 2)
                    {
                        materialEditor.ShaderProperty(_ScreenpullStrength, "Diagonal Push");
                    }
                    else if (_ScreenpullMode.floatValue == 3)
                    {
                        materialEditor.ShaderProperty(_WarpHorizontal, propStyles.WarpHorizontalStyle);
                        materialEditor.ShaderProperty(_WarpVertical, propStyles.WarpVerticalStyle);
                    }
                    else if (_ScreenpullMode.floatValue == 4)
                    {
                        materialEditor.ShaderProperty(_ScreenpullMap, "Map");
                        materialEditor.ShaderProperty(_ScreenpullStrength, "Push");
                    }
                    EditorGUILayout.Space();
                }
            }



            //(multiple) screens
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntMultiscreen))
            {
                multiscreenClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), multiscreenClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(multiscreenClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.MultipleScreen, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (multiscreenClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleScreens, "Allow Screens?");
                    materialEditor.ShaderProperty(_MultiScreenX, "Zoom Out Strength");
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                }
            }


            //screenspace options 
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntScreenspace))
            {
                screenspaceClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), screenspaceClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(screenspaceClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Screenspace, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (screenspaceClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleScreenFlip, propStyles.ToggleScreenFlipStyle);
                    materialEditor.ShaderProperty(_ToggleUpsideDown, propStyles.ToggleUpsideDown);
                    EditorGUILayout.Space();
                }
            }


            //scroll options 
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntScroll))
            {
                scrollClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), scrollClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(scrollClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Scroll, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (scrollClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ScrollX, "Horizontal Scroll");
                    materialEditor.ShaderProperty(_ScrollY, "Vertical Scroll");
                    EditorGUILayout.Space();
                }
            }


            //Screenfreeze
            String screenfreezeName = "Screenfreeze";
            String freezeBeta = " [beta]";
            if (superUser) freezeBeta = rainbowfy(freezeBeta);
            if (vaporUser) freezeBeta = vaporfy(freezeBeta);
            screenfreezeName += freezeBeta;
            if (targetMat.shader.ToString().ToString().Contains("freeze"))
            {
                String freezeNotifier = " " + activeDisplay;
                if (superUser) freezeNotifier = rainbowfy(freezeNotifier);
                if (vaporUser) freezeNotifier = vaporfy(freezeNotifier);
                screenfreezeName += freezeNotifier;
            }
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntScreenfreeze))
            {
                screenfreezeClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), screenfreezeClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(screenfreezeClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(screenfreezeName, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (screenfreezeClick)
                {
                    gameobjQuery = EditorGUILayout.TextField("Enter GameObject Name: ", gameobjQuery);
                    EditorGUILayout.Space();
                    if (GUILayout.Button("freeze the screen! uwu"))
                    {                    
                        try
                        {
                            thisMesh = GameObject.Find(gameobjQuery);
                            thisMesh.SetActive(false);
                            targetMat.shader = Shader.Find(freezeDirectory);
                            EditorUtility.DisplayDialog(shaderName, "screenfreeze was applied. if screenfreeze is shown in your unity, it has the potential to break your scene. for this reason, the mesh was HIDDEN. after unfreezing the screen, the mesh will automatically be unhidden. !!! Please Remember To Remove The Keyframes For Hiding The Screen Generated In The Animation !!!", okButton);
                        }
                        catch(Exception e)
                        {
                            EditorUtility.DisplayDialog(shaderName, "The GameObject name was incorrect! Please enter in the name of the cube/sphere in the screenfreeze section of the shader. c:", okButton);
                        }
                    }
                    if (GUILayout.Button("unfreeze the screen! owo"))
                    {
                        try
                        {
                            targetMat.shader = Shader.Find(shaderDirectory);
                            thisMesh.SetActive(true);
                            EditorUtility.DisplayDialog(shaderName, "the mesh was now unhidden and screenfreeze was unapplied. !!! Please Remember To Remove The Keyframes For Hiding The Screen Generated In The Animation !!!", okButton);
                        }
                        catch(Exception e)
                        {
                            EditorUtility.DisplayDialog(shaderName, "The GameObject name was incorrect! Please enter in the name of the cube/sphere in the screenfreeze section of the shader. c:", okButton);
                        }
                    }
                    EditorGUILayout.Space();
                }
            }


            //All shakes
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntAllShakes))
            {
                allshakesClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), allshakesClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(allshakesClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.AllShakes, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (allshakesClick)
                {
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleShake, propStyles.ToggleShakeStyle);
                    materialEditor.ShaderProperty(_ShakeModel, "Shake Model");
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();

                    //smooth 
                    if (_ShakeModel.floatValue == 0)
                    {
                        materialEditor.ShaderProperty(_ToggleXYShake, "Axis Mode");
                        if (showXYShake == true)
                        {
                            materialEditor.ShaderProperty(_ShakeStrength, "Horizontal Strength");
                            materialEditor.ShaderProperty(_ShakeSpeed, "Horizontal Speed");
                            materialEditor.ShaderProperty(_ShakeStrength2, "Vertical Strength");
                            materialEditor.ShaderProperty(_ShakeSpeed2, "Vertical Speed");
                        }
                        else
                        {
                            materialEditor.ShaderProperty(_ShakeStrength, "Speed");
                            materialEditor.ShaderProperty(_ShakeSpeed, "Shake");
                        }
                    }
                    //rough
                    else if (_ShakeModel.floatValue == 1)
                    {
                        materialEditor.ShaderProperty(_ShakeStrength, "Horizontal Strength");
                        materialEditor.ShaderProperty(_ShakeSpeed, "Horizontal Speed");
                        materialEditor.ShaderProperty(_ShakeStrength2, "Vertical Strength");
                        materialEditor.ShaderProperty(_ShakeSpeed2, "Vertical Speed");
                    }
                    //noise
                    else if (_ShakeModel.floatValue == 2)
                    {
                        materialEditor.ShaderProperty(_emptyTex, "Noise Map");
                        materialEditor.ShaderProperty(_ShakeStrength, "Horizontal Strength");
                        materialEditor.ShaderProperty(_ShakeSpeed, "Horizontal Speed");
                        materialEditor.ShaderProperty(_ShakeStrength2, "Vertical Strength");
                        materialEditor.ShaderProperty(_ShakeSpeed2, "Vertical Speed");
                    }
                    //circle shake
                    else if (_ShakeModel.floatValue == 3)
                    {
                        materialEditor.ShaderProperty(_ShakeStrength, "Circ Shake Strength");
                        materialEditor.ShaderProperty(_ShakeSpeed, "Circ Shake Speed");
                    }
                    //earfquake
                    else if (_ShakeModel.floatValue == 4)
                    {
                        generateMessage("Visuals", helpInfoStyle);
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_SSAllowVerticalShake, propStyles.SSAllowVerticalShakeStyle);
                        materialEditor.ShaderProperty(_SSAllowHorizontalShake, propStyles.SSAllowHorizontalShakeStyle);
                        materialEditor.ShaderProperty(_SSAllowVerticalBlur, propStyles.SSAllowVerticalBlurStyle);
                        materialEditor.ShaderProperty(_SSAllowHorizontalBlur, propStyles.SSAllowHorizontalBlurStyle);
                        materialEditor.ShaderProperty(_SSTransparency, propStyles.SSTransparencyStyle);
                        EditorGUILayout.Space();
                        drawDivider();
                        generateMessage("Power", helpInfoStyle);
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_SSValue, propStyles.SSValueStyle);
                        materialEditor.ShaderProperty(_SSSpeed, propStyles.SSSpeedStyle);
                        materialEditor.ShaderProperty(_SSValueVert, propStyles.SSValueVertStyle);
                        materialEditor.ShaderProperty(_SSSpeedVert, propStyles.SSSpeedVertStyle);
                    }
                    else if (_ShakeModel.floatValue == 5)
                    {
                        materialEditor.ShaderProperty(_emptyTex, "Push Map");
                        materialEditor.ShaderProperty(_ShakeStrength, "Horizontal Strength");
                        materialEditor.ShaderProperty(_ShakeSpeed, "Horizontal Speed");
                        materialEditor.ShaderProperty(_ShakeStrength2, "Vertical Strength");
                        materialEditor.ShaderProperty(_ShakeSpeed2, "Vertical Speed");
                    }

                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    generateMessage("reminder: animate strength not speed!", helpInfoStyle);
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                }
            }




            //Smear
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntSmear))
            {
                smearClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), smearClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(smearClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Smear, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (smearClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleSmear, propStyles.ToggleSmearStyle);
                    materialEditor.ShaderProperty(_CSDirection, propStyles.CSDirectionStyle);
                    materialEditor.ShaderProperty(_CSCopies, "Smear Amount");
                    materialEditor.ShaderProperty(_CSRed, "Red Push");
                    materialEditor.ShaderProperty(_CSGreen, "Green Push");
                    materialEditor.ShaderProperty(_CSBlue, "Blue Push");
                    materialEditor.ShaderProperty(_CSAutoRotate, propStyles.CSAutoRotateStyle);
                    if (showCSAnimate)
                    {
                        materialEditor.ShaderProperty(_CSRotateSpeed, propStyles.CSRotateSpeedStyle);
                        materialEditor.ShaderProperty(_CSUseAdvanced, propStyles.CSUseAdvancedStyle);
                        if (showCSAdv)
                        {
                            materialEditor.ShaderProperty(_CSRotateSpeedSinXR, propStyles.CSRotateSpeedSinXRStyle);
                            materialEditor.ShaderProperty(_CSRotateSpeedCosXR, propStyles.CSRotateSpeedCosXRStyle);
                            materialEditor.ShaderProperty(_CSRotateSpeedSinYR, propStyles.CSRotateSpeedSinYRStyle);
                        }
                    }

                    EditorGUILayout.Space();
                }
            }



            //Splice
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntSplice))
            {
                spliceClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), spliceClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(spliceClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Splice, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (spliceClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleSplice, propStyles.ToggleSpliceStyle);
                    materialEditor.ShaderProperty(_SpliceTop, propStyles.SplitTopStyle);
                    materialEditor.ShaderProperty(_SpliceBot, propStyles.SplitBotStyle);
                    materialEditor.ShaderProperty(_SpliceXLimit, "Cut Placement");
                    materialEditor.ShaderProperty(_SpliceLeft, propStyles.SplitLeftStyle);
                    materialEditor.ShaderProperty(_SpliceRight, propStyles.SplitRightStyle);
                    materialEditor.ShaderProperty(_SpliceYLimit, "Cut Placement");
                    EditorGUILayout.Space();
                }
            }


            //Silhouette
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntSilhouette))
            {
                silhouetteClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), silhouetteClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(silhouetteClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Silhouette, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (silhouetteClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleSilhouette, "Allow Silhouette?");
                    materialEditor.ShaderProperty(_SilhouetteDepth, "Silhouette Density");
                    materialEditor.ShaderProperty(_SilhouetteBack, "Back Color");
                    materialEditor.ShaderProperty(_SilhouetteFront, "Front Color");
                    materialEditor.ShaderProperty(_SilhouetteLightingMode, "Lighting Mode");
                    materialEditor.ShaderProperty(_SilhouetteLighting, "Lighting");
                    materialEditor.ShaderProperty(_SilhouetteRainLayer, "Rainbow Effects:");
                    materialEditor.ShaderProperty(_SilhouetteRainbow, "Rainbow Silhouette");
                    materialEditor.ShaderProperty(_SilhouetteRainbowSpeed, "Rainbow Speed");
                    EditorGUILayout.Space();
                }
            }


            //Thermal
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntThermal))
            {
                thermalClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), thermalClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(thermalClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Thermal, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (thermalClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ThermalTransparency, propStyles.ThermalTransparencyStyle);
                    materialEditor.ShaderProperty(_ThermalHeat, propStyles.ThermalHeatStyle);
                    materialEditor.ShaderProperty(_ThermalSensitivity, propStyles.ThermalSensitivityStyle);
                    materialEditor.ShaderProperty(_ThermalColor, "Color Scheme:");
                    EditorGUILayout.Space();
                }
            }


            //Vhs
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntVHS))
            {
                vhsClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), vhsClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(verticalblurClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.VHS, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (vhsClick)
                {
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleVHS, propStyles.ToggleVHSStyle);
                    materialEditor.ShaderProperty(_ToggleSmoothWave, propStyles.ToggleSmoothWaveStyle);
                    materialEditor.ShaderProperty(_VHSXDisplacement, propStyles.VHSXDisplacementStyle);
                    materialEditor.ShaderProperty(_VHSYDisplacement, propStyles.VHSYDisplacementStyle);
                    materialEditor.ShaderProperty(_waveyness, propStyles.waveynessStyle);
                    materialEditor.ShaderProperty(_shadowStrength, propStyles.shadowStrengthStyle);
                    materialEditor.ShaderProperty(_darkness, propStyles.darknessStyle);
                    EditorGUILayout.Space();
                }
            }


            //Vignette
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntVignette))
            {
                vignetteClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), vignetteClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(vignetteClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Vignette, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (vignetteClick)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    drawDivider();
                    generateMessage("Strength", helpInfoStyle);
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_ToggleVignette, "Vignette Transparency");
                    materialEditor.ShaderProperty(_VigX, propStyles.VigXStyle);
                    materialEditor.ShaderProperty(_VigSharpness, "Sharpness");
                    materialEditor.ShaderProperty(_VigReverse, "Reverse Vignette?");
                    drawDivider();
                    generateMessage("Color", helpInfoStyle);
                    EditorGUILayout.Space();
                    materialEditor.ShaderProperty(_VigMode, "Color Apply Method?");
                    materialEditor.ShaderProperty(_VigColor, "Color");
                    materialEditor.ShaderProperty(_VigColPow, "Glow");
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                }
            }


            //Visualizer
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntVisualizer))
            {
                visualizerClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), visualizerClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(visualizerClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.Visualizer, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (visualizerClick)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                    if (_VisMode.floatValue == 0)
                    {
                        generateMessage("Visualizer Settings", helpInfoStyle);
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleVisualizer, "Allow Visualizer");
                        materialEditor.ShaderProperty(_VisMode, "Visualizer Style");
                        materialEditor.ShaderProperty(_VisBarColor, "Bar Color");
                        materialEditor.ShaderProperty(_VisBaseColor, "Base Color");
                        materialEditor.ShaderProperty(_VisBarWidth, "Bar Width");
                        materialEditor.ShaderProperty(_VisBaseWidth, "Base Width");
                        EditorGUILayout.Space();
                        drawDivider();
                        EditorGUILayout.Space();
                        generateMessage("Bar Strength", helpInfoStyle);
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_VisBarLeft, "Left Bar Push");
                        materialEditor.ShaderProperty(_VisBarRight, "Right Bar Push");
                        EditorGUILayout.Space();
                        drawDivider();
                        EditorGUILayout.Space();
                        generateMessage("Rainbow!!", helpInfoStyle);
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleHSVRainbowVis, propStyles.ToggleHSVRainbowStyle);
                        materialEditor.ShaderProperty(_ToggleHSVRainbowXVis, propStyles.ToggleHSVRainbowXStyle);
                        materialEditor.ShaderProperty(_ToggleHSVRainbowYVis, propStyles.ToggleHSVRainbowYStyle);
                        materialEditor.ShaderProperty(_HSVRainbowHueVis, propStyles.HSVRainbowHueStyle);
                        materialEditor.ShaderProperty(_HSVRainbowSatVis, propStyles.HSVRainbowSatStyle);
                        materialEditor.ShaderProperty(_HSVRainbowLightVis, propStyles.HSVRainbowLightStyle);
                        materialEditor.ShaderProperty(_HSVRainbowTimeVis, propStyles.HSVRainbowTimeStyle);
                    }else if (_VisMode.floatValue == 1)
                    {
                        generateMessage("Visualizer Settings", helpInfoStyle);
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleVisualizer, "Allow Visualizer");
                        materialEditor.ShaderProperty(_VisMode, "Visualizer Style");
                        materialEditor.ShaderProperty(_VisClassicShape, "Visualizer Shape");
                        materialEditor.ShaderProperty(_VisBarColor, "Circle Color One");
                        materialEditor.ShaderProperty(_VisBaseColor, "Circle Color Two");
                        materialEditor.ShaderProperty(_VisBarRainbow, "Make bar :rainbow: too?");
                        materialEditor.ShaderProperty(_VisCircleSize, "Shape Size");
                        materialEditor.ShaderProperty(_VisClassicBase, "Base Size");
                        EditorGUILayout.Space();
                        drawDivider();
                        EditorGUILayout.Space();
                        generateMessage("Bar Strength", helpInfoStyle);
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_VisClassicMaxSize, "Max Bar Size");
                        materialEditor.ShaderProperty(_VisBarLeft, "Bar One Push");
                        materialEditor.ShaderProperty(_VisBarRight, "Bar Two Push");
                        materialEditor.ShaderProperty(_VisBarThree, "Bar Three Push");
                        materialEditor.ShaderProperty(_VisBarFour, "Bar Four Push");
                        materialEditor.ShaderProperty(_VisBarFive, "Bar Five Push");
                        materialEditor.ShaderProperty(_VisBarSix, "Bar Six Push");
                        materialEditor.ShaderProperty(_VisBarSeven, "Bar Seven Push");
                        materialEditor.ShaderProperty(_VisBarEight, "Bar Eight Push");
                        materialEditor.ShaderProperty(_VisBarNine, "Bar Nine Push");
                        materialEditor.ShaderProperty(_VisBarTen, "Bar Ten Push");
                        EditorGUILayout.Space();
                        drawDivider();
                        EditorGUILayout.Space();
                        generateMessage("Border Settings", helpInfoStyle);
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_VisStopperColor, "Stopper Color");
                        materialEditor.ShaderProperty(_ToggleHSVRainbowVis, propStyles.ToggleHSVRainbowStyle);
                        materialEditor.ShaderProperty(_ToggleHSVRainbowXVis, propStyles.ToggleHSVRainbowXStyle);
                        materialEditor.ShaderProperty(_ToggleHSVRainbowYVis, propStyles.ToggleHSVRainbowYStyle);
                        materialEditor.ShaderProperty(_HSVRainbowHueVis, propStyles.HSVRainbowHueStyle);
                        materialEditor.ShaderProperty(_HSVRainbowSatVis, propStyles.HSVRainbowSatStyle);
                        materialEditor.ShaderProperty(_HSVRainbowLightVis, propStyles.HSVRainbowLightStyle);
                        materialEditor.ShaderProperty(_HSVRainbowTimeVis, propStyles.HSVRainbowTimeStyle);
                    }
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    drawDivider();
                    EditorGUILayout.Space();
                }
            }


            //Zooms
            if ((__hideUnusedFX.floatValue == 0) || (__hideUnusedFX.floatValue == 1 && ntAllZooms))
            {


                allzoomsClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), allzoomsClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(allzoomsClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField(propStyles.AllZooms, dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (allzoomsClick)
                {
                    EditorGUILayout.Space();

                    EditorGUILayout.Space();
                    drawDivider();
                    generateMessage("Settings & Info", helpInfoStyle);
                    EditorGUILayout.Space();

                    //zoom help
                    EditorGUILayout.Space();
                    zoomhelpClick = SubmenuFoldout("which zoom do i use?", zoomhelpClick);
                    if (zoomhelpClick)
                    {
                        EditorGUILayout.Space();
                        generateMessage("" +
                            "\n<b>fisheye zoom</b> functions the same as middle zoom,\n but warps the edges around the zoom\n" +
                            "\n<b>focus zoom</b> forces your zoom on to the users screen,\nand works by using a tiny mesh where u want to zoom.\n" +
                            "\n<b>middle zoom</b> zooms in when looking at the\n center of the mesh (where your avatar is).\n" +
                            "\n<b>screen zoom</b> always zooms in the screen,\n no matter where looking.\n"
                            , helpInfoStyle);
                        EditorGUILayout.Space();
                    }

                    //zoom range
                    zoomrangeClick = SubmenuFoldout("Zoom Range", zoomrangeClick);
                    if (zoomrangeClick)
                    {
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleZoomRange, "Dif Range for Zooms?");
                        materialEditor.ShaderProperty(_ZoomRange, "Zooms Range");
                        materialEditor.ShaderProperty(_ZoomFStart, "Zooms Falloff Start");
                        materialEditor.ShaderProperty(_ZoomFEnd, "Zooms Faloff End");
                        EditorGUILayout.Space();
                    }

                    EditorGUILayout.Space();
                    drawDivider();
                    generateMessage("Zooms", helpInfoStyle);
                    EditorGUILayout.Space();

                    //warp zoom            
                    warpZoomClick = SubmenuFoldout(propStyles.WarpZoom.text, warpZoomClick);
                    if (warpZoomClick)
                    {
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleWarpZoom, "Allow Fisheye Zoom");
                        materialEditor.ShaderProperty(_WarpZoomAmount, "Zoom Amount");
                        materialEditor.ShaderProperty(_WarpZoomTolerance, "Zoom Tolerance");
                        EditorGUILayout.Space();
                    }

                    //centered zoom
                    zoomClick = SubmenuFoldout(propStyles.CenteredZoom.text, zoomClick);
                    if (zoomClick)
                    {
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleZoom, propStyles.ToggleZoomStyle);
                        materialEditor.ShaderProperty(_ToggleFlipZoom, propStyles.ToggleFlipZoomStyle);
                        materialEditor.ShaderProperty(_ZoomInValue, propStyles.ZoomInValueStyle);
                        //materialEditor.ShaderProperty(_ZoomOutValue, propStyles.ZoomOutValueStyle); broken ? not needed ? all of the above :sunglasses: needs removed from other code tho
                        materialEditor.ShaderProperty(_SmoothZoom, "Smoothen Zoom?");
                        materialEditor.ShaderProperty(_SmoothZoomTolerance, "Smooth Tolerance?");
                        GUILayout.Space(10);
                        centerzoomInstructionsClick = SubmenuFoldout("Focus Zoom Instructions", centerzoomInstructionsClick);
                        if (centerzoomInstructionsClick)
                        {
                            generateMessage("Make sure the mesh is small!\nAround 0.01x0.01x0.01 or smaller!", friendStyle); //start info
                            generateMessage("Put the mesh inside the object you want to zoom into.", friendStyle); //end info
                            generateMessage("Other effects will still work with zoom in the small mesh!", friendStyle); //end info
                        }
                        EditorGUILayout.Space();
                    }

                    //big box zoom             
                    bigboxzoomClick = SubmenuFoldout(propStyles.BigBoxZoom.text, bigboxzoomClick);
                    if (bigboxzoomClick)
                    {
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleBigZoom, "Allow Middle Zoom");
                        materialEditor.ShaderProperty(_BigZoomAmount, "Zoom In Amount");
                        materialEditor.ShaderProperty(_BigZoomOutAmount, "Zoom Out Amount");
                        materialEditor.ShaderProperty(_BigZoomTolerance, "Angle Tolerance");
                        EditorGUILayout.Space();
                    }

                    //screen zoom            
                    screenzoomClick = SubmenuFoldout(propStyles.ScreenZoom.text, screenzoomClick);
                    if (screenzoomClick)
                    {
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        materialEditor.ShaderProperty(_ToggleScreenZoom, propStyles.ToggleScreenZoomStyle);
                        materialEditor.ShaderProperty(_ScreenZoomInValue, "Zoom In");
                        materialEditor.ShaderProperty(_ScreenZoomOutValue, "Zoom Out");
                        EditorGUILayout.Space();
                    }

                    EditorGUILayout.Space();

                    EditorGUILayout.Space();
                }

            }


        
            

















            //Divider
            drawDivider();

            //extra section
            generateSection("Extra", sectionStyle);

            //help
            if (__hideUnusedFX.floatValue == 0 && menuUgly == false)
            {
                helpClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), helpClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(helpClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField("Help", dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (helpClick)
                {

                    EditorGUILayout.Space();
                    multFxClick = SubmenuFoldout("How do I use transparent overlays?", multFxClick);
                    if (multFxClick)
                    {
                        EditorGUILayout.Space();
                        drawDivider();
                        EditorGUILayout.Space();
                        generateMessage("Transparency is a bit weird on some pics for optimization purposes!\nCheck out the " +
                            "transparent example\nin the tutorials folder, cos some\ncompression of pngs can mess it up." +
                            " Feel free to\nuse the example as a base for your image!", helpInfoStyle);
                        drawDivider();
                        EditorGUILayout.Space();
                    }
                    EditorGUILayout.Space();
                    whatdoesClick = SubmenuFoldout("Why can I see the shader in scene but not in game?", whatdoesClick);
                    if (whatdoesClick)
                    {
                        EditorGUILayout.Space();
                        drawDivider();
                        EditorGUILayout.Space();
                        generateMessage("Unity is GLITCHY. Close the scene tab by right\nclicking it and open a new one\nby right clicking elsewhere in the bar.", helpInfoStyle);
                        drawDivider();
                        EditorGUILayout.Space();
                    }
                    EditorGUILayout.Space();
                    laggingmeClick = SubmenuFoldout("Can I use this shader in a commission?", laggingmeClick);
                    if (laggingmeClick)
                    {
                        EditorGUILayout.Space();
                        drawDivider();
                        EditorGUILayout.Space();
                        generateMessage("As long as the commission is <b>upload only</b>, \ni have no problem what you use the shader for c:", helpInfoStyle);
                        drawDivider();
                        EditorGUILayout.Space();
                    }
                    EditorGUILayout.Space();
                    dontunderstandClick = SubmenuFoldout("How do I hide all of my untoggled effects?", dontunderstandClick);
                    if (dontunderstandClick)
                    {
                        EditorGUILayout.Space();
                        drawDivider();
                        EditorGUILayout.Space();
                        generateMessage("Check out the new option under <b>Animating</b>!", helpInfoStyle);
                        drawDivider();
                        EditorGUILayout.Space();
                    }
                    EditorGUILayout.Space();
                    featureClick = SubmenuFoldout("I want a feature! Can you change this?", featureClick);
                    if (featureClick)
                    {
                        EditorGUILayout.Space();
                        drawDivider();
                        EditorGUILayout.Space();
                        generateMessage("<b>Yeah!</b> I need ideas! Please message me with your ideas" +
                            "\nand suggestions/improvements at luka#8375!", helpInfoStyle);
                        drawDivider();
                        EditorGUILayout.Space();
                    }
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    generateMessage("need more help? check out", helpInfoStyle);
                    generateMessage("<b>luka.moe/help</b>", helpInfoStyle);
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    generateMessage("<b>hey, you</b>", helpInfoStyle);
                    generateMessage("did u get this shader for free?\n DM luka#8375 or add luka!", helpInfoStyle);
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    drawSocialBar("box");
                    EditorGUILayout.Space();
                    drawDivider();
                }
            }

            //thanks
            if (__hideUnusedFX.floatValue == 0 && menuUgly == false)
            {
                friendspatreonClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), friendspatreonClick, GUIContent.none, "box");
                EditorGUILayout.Toggle(friendspatreonClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
                EditorGUILayout.LabelField("Thanks", dropdownStyle);
                EditorGUILayout.EndHorizontal();
                if (friendspatreonClick)
                {

                    //spacing
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();

                    //donators menu
                    patreonClick = SubmenuFoldout("original supporters", patreonClick);
                    if (patreonClick)
                    {
                        EditorGUILayout.Space();
                        drawDivider();
                        EditorGUILayout.Space();
                        generateMessage(redHeart + "thx to all of my original supporters" + redHeart, friendStyle);
                        generateMessage(redHeart + "you allowed me to make this" + redHeart, friendStyle);
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();


                        //start teer          
                        //image
                        EditorGUILayout.Space();
                        generateMessage("Teer", helpHeaderStyle);
                        EditorGUILayout.Space();
                        var teerXStokieSize = GUILayoutUtility.GetRect(0, int.MaxValue, 250, 30);
                        Texture2D teerXStokie = Resources.Load<Texture2D>("LukaResource_DonatorTeer");
                        EditorGUI.DrawPreviewTexture(teerXStokieSize, teerXStokie, null, ScaleMode.ScaleToFit);
                        EditorGUILayout.Space();  
                        drawDivider();
                        EditorGUILayout.Space();
                        //end teer

                        //start trevor          
                        //image
                        EditorGUILayout.Space();
                        generateMessage("TrevorLeviathan", helpHeaderStyle);
                        EditorGUILayout.Space();
                        var trevorHereSpace = GUILayoutUtility.GetRect(0, int.MaxValue, 250, 30);
                        Texture2D trevHereImage = Resources.Load<Texture2D>("LukaResource_DonatorTrevor");
                        EditorGUI.DrawPreviewTexture(trevorHereSpace, trevHereImage, null, ScaleMode.ScaleToFit);
                        EditorGUILayout.Space();
                        generateMessage("'trevors here to cuck you'", helpHeaderStyle);
                        EditorGUILayout.Space();
                        drawDivider();
                        //end trevor


                        //start stargazer
                        EditorGUILayout.Space();
                        generateMessage("stargazer", helpHeaderStyle);
                        EditorGUILayout.Space();
                        generateMessage("if you see this you owe me erp - star", helpHeaderStyle);
                        EditorGUILayout.Space();
                        drawDivider();
                        //end stargazer


                        //start laptop
                        EditorGUILayout.Space();
                        generateMessage("Laptop", helpHeaderStyle);
                        EditorGUILayout.Space();
                        var laptopImageSpace = GUILayoutUtility.GetRect(0, int.MaxValue, 250, 30);
                        Texture2D laptopImage = Resources.Load<Texture2D>("LukaResource_DonatorLaptop");
                        EditorGUI.DrawPreviewTexture(laptopImageSpace, laptopImage, null, ScaleMode.ScaleToFit);
                        EditorGUILayout.Space();
                        drawDivider();
                        //end laptop


                        //spacing
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();

                    }

                    //friends menu
                    friendsClick = SubmenuFoldout("friends and stuff", friendsClick);
                    if (friendsClick)
                    {
                        EditorGUILayout.Space();
                        //friends
                        drawDivider();
                        EditorGUILayout.Space();
                        var loveHuggieSpace = GUILayoutUtility.GetRect(0, int.MaxValue, 100, 30);
                        Texture2D loveHuggieImage = Resources.Load<Texture2D>("LukaResource_LoveHuggie");
                        if (EditorGUIUtility.isProSkin == true) loveHuggieImage = Resources.Load<Texture2D>("LukaResource_LoveHuggiePro");
                        EditorGUI.DrawPreviewTexture(loveHuggieSpace, loveHuggieImage, null, ScaleMode.ScaleToFit);
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        generateMessage(redHeart + "DocMe for help with VR" + redHeart, friendStyle);
                        generateMessage(redHeart + "Poiyomi for inspiring me" + redHeart, friendStyle);
                        generateMessage(redHeart + redHeart + redHeart + "Joao with money and graphics" + redHeart + redHeart + redHeart, friendStyle);
                        generateMessage(redHeart + redHeart + redHeart + "Rebb for testing and new ideas" + redHeart + redHeart + redHeart, friendStyle);
                        generateMessage(redHeart + redHeart + redHeart + "Cruel for being there from the start" + redHeart + redHeart + redHeart, friendStyle);
                        generateMessage(redHeart + redHeart + redHeart + "Trauma for being so supportive" + redHeart + redHeart + redHeart, friendStyle);
                        generateMessage(redHeart + redHeart + redHeart + "Yuma for being an amazing person" + redHeart + redHeart + redHeart, friendStyle);
                        generateMessage(redHeart + "FReal for being the local idiot" + redHeart, friendStyle);
                        generateMessage(redHeart + uniHeart.ToString() + uniHeart.ToString() + " PLoX for doing things the PLoX way " + uniHeart.ToString() + uniHeart.ToString() + redHeart, friendStyle);
                        generateMessage(redHeart + "Puniie for always helping out" + redHeart, friendStyle);
                        generateMessage(redHeart + "Commando for telling me how bad at blender i am" + redHeart, friendStyle);
                        generateMessage(redHeart + "Fade for keeping his gamer headset up" + redHeart, friendStyle);
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        generateMessage(redHeart + "All my buyers for the support" + redHeart, friendStyle);
                        generateMessage(redHeart + "Anyone who has ever reported a bug" + redHeart, friendStyle);
                        generateMessage(redHeart + "Anyone who has ever messaged me kind things" + redHeart, friendStyle);
                        generateMessage(redHeart + "All the idiot leakers who promoted me" + redHeart, friendStyle);
                        generateMessage(redHeart + "All the ppl online who teach abt shaders" + redHeart, friendStyle);
                        generateMessage(redHeart + "All the other shaders that inspired me to be better" + redHeart, friendStyle);
                        //vidvox corner colors
                        generateMessage(redHeart + "You" + redHeart, friendStyle);
                        EditorGUILayout.Space();
                    }

                    //acknowledgements
                    acknowledgesmentClick = SubmenuFoldout("acknowledgements", acknowledgesmentClick);
                    if(acknowledgesmentClick){
                        EditorGUILayout.Space();
                        generateMessage(
                        "i will be brief:\n" +
                        "almost every shader on vrchat uses\n" +
                        "code or math taken from other things.\n"  +
                        "little credit is given, if any, it is in the code.\n" +
                        "that is not acceptable.\n" +
                        "i am a student and not even for computer science" +
                        "\nand im learning as i go. unlike\n" +
                        "other creators, i want to be clear and\n" +
                        "give thanks to the resources i have used\n" +
                        "to provide all of you with the best fx i can.\n" +
                        "<3", friendStyle);
                        EditorGUILayout.Space();
                        EditorGUILayout.Space();
                        generateMessage(redHeart + "liuhaidong for original webgl girlscam math" + redHeart, friendStyle);
                        generateMessage(redHeart + "Gaktan for part of scanline formula" + redHeart, friendStyle);
                        generateMessage(redHeart + "Nshelton for randomisation methods for block glitch" + redHeart, friendStyle);
                        generateMessage(redHeart + "donald for some math on smear" + redHeart, friendStyle);
                        generateMessage(redHeart + "clip shader for some vhs math" + redHeart, friendStyle);
                        generateMessage(redHeart + "jojjesv for inspiration for my rgb glitch" + redHeart, friendStyle);
                        generateMessage(redHeart + "my friend PikPik for blink inspiration" + redHeart, friendStyle);
                        generateMessage(redHeart + "some random film shader on github i remade more optimized" + redHeart, friendStyle);
                        generateMessage(redHeart + "spite for some of my linocut formula" + redHeart, friendStyle);
                        generateMessage(redHeart + "Agnius Vasiliauskas / VIDVOX (not orignal) for thermal base" + redHeart, friendStyle);
                        generateMessage(redHeart + "based my new scanline formula off of some random math online" + redHeart, friendStyle);
                        generateMessage(redHeart + "?????? for advice on screenfreeze" + redHeart, friendStyle);
                        generateMessage(redHeart + "yuma and joao for help with graphics" + redHeart, friendStyle);
                        EditorGUILayout.Space();
                    }

                    //footer
                    EditorGUILayout.Space();
                    drawDivider();
                }
            }


            //Settings 
            String settingsName = "Settings";
            if (targetMat.shader.ToString().ToString().Contains("limitbreak"))
            {
                String limitBreakNotifier = " [LIMITS BROKEN]";
                if (superUser) limitBreakNotifier = rainbowfy(limitBreakNotifier);
                if (vaporUser) limitBreakNotifier = vaporfy(limitBreakNotifier);
                settingsName += limitBreakNotifier;
            }
            settingsClick = GUI.Toggle(EditorGUILayout.BeginHorizontal("box"), settingsClick, GUIContent.none, "box");
            EditorGUILayout.Toggle(settingsClick, EditorStyles.foldout, GUILayout.MaxWidth(10));
            EditorGUILayout.LabelField(settingsName, dropdownStyle);
            EditorGUILayout.EndHorizontal();
            if (settingsClick)
            {
                EditorGUILayout.Space();
                String lastActiveDisplay = activeDisplay;
                neverShowChangelog = EditorGUILayout.Toggle("Hide Changelog?", neverShowChangelog);
                activeDisplay = EditorGUILayout.TextField("Toggled Notifier", System.Text.RegularExpressions.Regex.Replace(activeDisplay, "<.*?>", String.Empty));
                menuUgly = EditorGUILayout.Toggle("Declutter Menu?", menuUgly);
                particleDefault = EditorGUILayout.Toggle("Hide lock warnings?", particleDefault);
                if (targetMat.shader.ToString().ToString().Contains("limitbreak"))
                {
                    if (GUILayout.Button("restore limits"))
                    {
                        EditorUtility.DisplayDialog("luka mega shader", "the limtis have been restored!", okButton);
                        targetMat.shader = Shader.Find(shaderDirectory);
                    }
                }
                else
                {
                    if (GUILayout.Button("limit break"))
                    {
                        EditorUtility.DisplayDialog("luka mega shader", "the shader on the material has been swapped. pleased don't change it or else limit break will be removed..", okButton);
                        targetMat.shader = Shader.Find(limitDirectory);
                    }
                }

                //rainbowfy
                GUILayout.BeginHorizontal("box");
                GUILayout.FlexibleSpace();
                Texture nyanIcon = (Texture)Resources.Load<Texture2D>("LukaResource_Rainbow");
                if (!superUser) nyanIcon = (Texture)Resources.Load<Texture2D>("LukaResource_Grey");
                GUIContent rainbowButton = new GUIContent(nyanIcon);
                if (GUILayout.Button(rainbowButton, GUILayout.Width(400), GUILayout.Height(40)))
                {
                    if (superUser)
                        updateSuperuser("false");
                    else
                        updateSuperuser("true");
                    updateSettings(activeDisplay, 2);
                }
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                //vaporfy
                GUILayout.BeginHorizontal("box");
                GUILayout.FlexibleSpace();
                Texture vaporIcon = (Texture)Resources.Load<Texture2D>("LukaResource_VaporOn");
                if (!vaporUser) vaporIcon = (Texture)Resources.Load<Texture2D>("LukaResource_VaporOff");
                GUIContent vaporButton = new GUIContent(vaporIcon);
                if (GUILayout.Button(vaporButton, GUILayout.Width(400), GUILayout.Height(40)))
                {
                    if (vaporUser)
                        updateVapor("false");
                    else
                        updateVapor("true");
                    updateSettings(activeDisplay, 2);
                }
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                if (GUILayout.Button("save settings"))
                {
                    updateSettings(activeDisplay, 2);
                    updateSettings(neverShowChangelog.ToString(), 1);
                    updateSettings(menuUgly.ToString(), 3);
                    updateSettings(particleDefault.ToString(), 4);
                }

                //footer
                EditorGUILayout.Space();
                if (__hideUnusedFX.floatValue == 0)
                {
                    drawDivider();
                }
            }



            //Presets
            selectedPreset = EditorGUILayout.Popup("Presets", selectedPreset, presetOption);
            if (GUILayout.Button("Apply Preset"))
            {
                switch (selectedPreset)
                {
                    case 0:
                        _TearToMirror.floatValue = 1;
                        _ToggleRadialBlur.floatValue = 1;
                        _RBMode.floatValue = 3;
                        _RadialBlurDistance.floatValue = (float)0.353;
                        _RBItterations.floatValue = 16;
                        _RBEmpower.floatValue = (float)0.01;
                        _RBDither.floatValue = (float)4.57;
                        _RBRotate.floatValue = 11;
                        _RBRotateSpeed.floatValue = (float)3.13;
                        _RBToggleRainbow.floatValue = 1;
                        _RBHSVRainbowHue.floatValue = (float)0.698;
                        _RBHSVRainbowSat.floatValue = (float)0.97;
                        _RBHSVRainbowLight.floatValue = (float)1.06;
                        _RBHSVRainbowTime.floatValue = (float)0.89;
                        _ToggleRotater.floatValue = 1;
                        _RotaterValue.floatValue = -5;
                        _ToggleRotaterAnimate.floatValue = 1;
                        _RotaterSpin.floatValue = (float)4.2;
                        _ToggleShake.floatValue = 1;
                        _ShakeModel.floatValue = 1;
                        _ShakeStrength.floatValue = (float)0.203;
                        _ShakeSpeed.floatValue = (float)3.3;
                        _ShakeStrength2.floatValue = (float)0.249;
                        _ShakeSpeed2.floatValue = (float)1.8;
                        break;
                    case 1:                      
                        _ToggleNBlur.floatValue = 1;
                        _NBlurShape.floatValue = 4;
                        _NBlurItterations.floatValue = 32;
                        _NBlurPower.floatValue = (float)0.152;
                        _NBlurSpeed.floatValue = 3;
                        _NBlurRotate.floatValue = 4;
                        _NBlurRotateSpeed.floatValue = (float)1.29;
                        _NBlurOpacity.floatValue = (float)0.703;
                        _ToggleRGB.floatValue = 1;
                        _CAStyle.floatValue = 1;
                        _RGBAutoanimateSpeed.floatValue = (float)4.52;
                        _ToggleAutoanimate.floatValue = 1;
                        _CASamples.floatValue = 32;
                        _RedXValue.floatValue = (float)0.059;
                        _GreenXValue.floatValue = (float)0.04;
                        _BlueXValue.floatValue = (float)0.04;
                        _HideRedTrans.floatValue = 1;
                        _HideBlueTrans.floatValue = 1;
                        _HideGreenTrans.floatValue = 1;
                        _CARotate.floatValue = (float)2.08;
                        _CARotateSpeed.floatValue = (float)1.29;
                        _SepiaStrength.floatValue = 1;
                        break;
                    case 2:
                        _FilmPower.floatValue = (float)0.784;
                        _FilmJitterAmount.floatValue = (float)0.004;
                        _FilmBrightness.floatValue = (float)0.1;
                        _FilmItterations.floatValue = 10;
                        _FilmAllowLines.floatValue = 1;
                        _FilmAllowSpots.floatValue = 1;
                        _FilmAllowStripes.floatValue = 1;
                        _ToggleHSVRainbow.floatValue = 1;
                        _HSVRainbowHue.floatValue = (float)0.244;
                        _HSVRainbowSat.floatValue = 1;
                        _HSVRainbowLight.floatValue = 1;
                        _HSVRainbowTime.floatValue = (float)1.62;
                        _ToggleNBlur.floatValue = 1;
                        _NBlurShape.floatValue = 5;
                        _NBlurPower.floatValue = (float)0.129;
                        _NBlurSpeed.floatValue = (float)0.01;
                        _NBlurOpacity.floatValue = (float)0.293;
                        _SepiaRStrength.floatValue = (float)0.981;
                        _DarknessStrength.floatValue = (float)0.365;
                        _SepiaStrength.floatValue = (float)0.37;
                        _ToggleVignette.floatValue = 1;
                        _VigX.floatValue = (float)1.35;
                        _VigSharpness.floatValue = 15;
                        _VigMode.floatValue = 0;
                        _ToggleVisualizer.floatValue = 1;
                        _VisMode.floatValue = 1;
                        _VisClassicShape.floatValue = 1;
                        _VisBarRainbow.floatValue = 1;
                        _VisCircleSize.floatValue = 196;
                        _VisClassicBase.floatValue = (float)0.044;
                        _VisClassicMaxSize.floatValue = (float)25.4;
                        _ToggleHSVRainbowVis.floatValue = 1;
                        _HSVRainbowHue.floatValue = (float)0.378;
                        _HSVRainbowSat.floatValue = (float)1.39;
                        _HSVRainbowLight.floatValue = (float)0.35;
                        _HSVRainbowSat.floatValue = (float)0.87;
                        break;
                    case 3:
                        _SepiaStrength.floatValue = 1;
                        _DarknessStrength.floatValue = (float)0.58;
                        _FilmPower.floatValue = 1;
                        _ToggleReel.floatValue = 1;
                        _ReelMode.floatValue = 4;
                        _ReelRainbow.floatValue = 1;
                        _ReelRainbowX.floatValue = 1;
                        _ReelRainbowY.floatValue = 1;
                        break;
                    case 4:
                        _DarknessStrength.floatValue = (float)0.61;
                        _SepiaStrength.floatValue = (float)0.424;
                        _SepiaRStrength.floatValue = (float)0.519;
                        _FilmPower.floatValue = 1;
                        _FilmItterations.floatValue = (float)4.5;
                        _ToggleVignette.floatValue = 1;
                        _VigX.floatValue = (float)0.89;
                        break;
                    case 5:
                        _AllowDepthTest.floatValue = 1;
                        _DepthValue.floatValue = (float)29;
                        _KeepPlayerInFocus.floatValue = 1;
                        _DepthPlayerTolerance.floatValue = (float)0.84;
                        _DepthPlayerPower.floatValue = 5;
                        _ToggleAscii.floatValue = 1;
                        _ASCIIVariation.floatValue = 5;
                        _ASCIIPower.floatValue = (float)15.4;
                        _ASCIISpeed.floatValue = (float)48.4;
                        targetMat.SetColor("_ColorRGB", Color.green);
                        break;
                    case 6:
                        _BlinkStrength.floatValue = (float)0.601;
                        targetMat.SetColor("_BlinkColor", Color.black);
                        _BlinkBorderSize.floatValue = (float)0.414;
                        _BlinkRainbow.floatValue = 1;
                        _BlinkRainbowMode.floatValue = 1;
                        _BlinkMode.floatValue = 3;
                        break;
                    default:
                        break;
                }
            }


            //<3
            if (__hideUnusedFX.floatValue == 0 && menuUgly == false)
            {
                EditorGUILayout.Space();
                generateMessage("luka#8375", helpHeaderStyle);
                //generateMessage("no more overpriced super duper private shaders", friendStyle);
                generateMessage("the only effects shader you need", friendStyle);
                generateMessage("by using this shader, you agree to the terms uwu", friendStyle);
                //generateMessage("could you not leak my shader? thx", friendStyle);
                EditorGUILayout.Space();
            }


            //Divider
            drawDivider();

            //Fixing dividers idk what im doing lol
            if (__hideUnusedFX.floatValue == 1 &&  menuUgly == false)
            {
                var dividerFix = GUILayoutUtility.GetRect(0, 0, 200, 0);
            }

            //space and banner
            if (__hideUnusedFX.floatValue == 0 && menuUgly == false)
            {
                var imageSpace = GUILayoutUtility.GetRect(0, int.MaxValue, 250, 30);
                Texture2D imageTexture = Resources.Load<Texture2D>("LukaResource_EditorBanner");
                //GUI.DrawTexture(imageSpace, imageTexture);
                EditorGUI.DrawPreviewTexture(imageSpace, imageTexture, null, ScaleMode.ScaleToFit);
            }


            //checking to see what passes should be enabled
            EditorGUI.BeginChangeCheck();


        }






    }



}
 
