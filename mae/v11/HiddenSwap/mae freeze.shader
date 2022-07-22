//|===============================================|
//|				  license   					  |
//|===============================================| 
//shader author: luka (lukasong on github, luka#8375 on discord, luka! in vrchat)
//license: this shader is to not be redistrubted or resold in any format and is limited to the buyer exclusively
//version 11.0 (July 30, 2019) 
Shader "Hidden/!luka/mae/freeze"
{
	//|===============================================|
	//|				  properties  					  |
	//|===============================================|
	Properties
	{

		//warning
		[Space(40)]
		[Header(the shader. cgincludes. and editor files are)]
		[Header(all property of luka. luka8375 on discord. lukasong on github.)]
		[Header(this is a private and paid shader)]
		[Space(20)]
		[Header(________________________________)]
		[Space(20)]
		[Header(henlo..)]
		[Header(you are prolly seeing this menu for a bad reason...)]
		[Header(... you got this shader illegally or tried to rip it)]
		[Header(... you recieved a bad copy of the shader from me)]
		[Header(... you tried to edit the shader and broke it)]
		[Space(10)] 
		[Header(no matter what the case is contact me on discord please)]
		[Header(my discord ... luka8375)]
		[Space(10)]
		[Header(________________________________)]
		[Space(10)]
		[Header(the shader will not work and is broken)]
		[Space(500)]
		[Space(500)]

		//gift to bit animator
		_BitAnimtorGoHardYahurr("Bit Animtor Go Hard YAHUR", Float) = 100
		
		//visualizer
		[Toggle(_)] _ToggleVisualizer ("Allow Visualizer?", Float) = 0
		[Enum(Vertical, 0, Classic, 1)] _VisMode ("Visualizer Mode", Float) = 0
		_VisBarLeft ("Left Bar Push", Range(-1.0, 2.5)) = -1.0
		_VisBarRight ("Right Bar Push", Range(-1.0, 2.5)) = -1.0
		_VisBarColor ("Bar Color", Color) = (0.75, 0.75, 0.75)
		_VisBaseColor ("Base Color", Color) = (0.0, 0.0, 0.0, 1.0)
		_VisBarWidth ("Bar Width", Range(0, 0.02)) = 0
		_VisBaseWidth ("Base Width", Range(0, -0.4)) = 0
		[Toggle(_)] _ToggleHSVRainbowVis("Allow Vis Rainbow", Float) = 0
		[Toggle(_)] _ToggleHSVRainbowXVis("Allow Vis Horizontal", Float) = 0
		[Toggle(_)] _ToggleHSVRainbowYVis("Allow Vis Vertical", Float) = 0
		_HSVRainbowHueVis("Hue", Range(0, 1.5)) = 0.1
		_HSVRainbowSatVis("Saturation", Range(0, 3)) = 1
		_HSVRainbowLightVis("Lightness", Range(0.1, 3)) = 1
		_HSVRainbowTimeVis("Time", Range(0, 3)) = 0.8
		_VisBarThree ("Bar Three Push", Range(-1, 2.5)) = -1
		_VisBarFour ("Bar Four Push", Range(-1, 2.5)) = -1
		_VisBarFive ("Bar Five Push", Range(-1, 2.5)) = -1
		_VisBarSix ("Bar Six Push", Range(-1, 2.5)) = -1
		_VisBarSeven ("Bar Seven Push", Range(-1, 2.5)) = -1
		_VisBarEight ("Bar Eight Push", Range(-1, 2.5)) = -1
		_VisBarNine ("Bar Nine Push", Range(-1, 2.5)) = -1
		_VisBarTen ("Bar Ten Push", Range(-1, 2.5)) = -1
		_VisStopperColor ("Stopper Color", Color) = (0, 0, 0, 1)
		[IntRange] _VisCircleSize ("Shape Size", Range(200, 10)) = 40
		_VisClassicBase ("Base Size", Range(1, -1)) = 0.20
		[Enum(Circles, 0, Squares, 1)] _VisClassicShape ("Bar Shape", Float) = 0
		[Toggle(_)] _VisBarRainbow ("Bar Rainbow", Float) = 0
		_VisClassicMaxSize ("Bar Max Size", Float) = 10.0

		//range
		_FalloffRange ("Range", Float) = 20
		[Toggle(_)] _ToggleRenderLookAtMe ("Only Render If Looking", Float) = 0
		_RenderMeTolerance ("Angle Tolerance", Range(0, 1)) = 0.8
		[Enum(UnityEngine.Rendering.CompareFunction)] _ZTest("ZTest", Int) = 8
		_OverallOpacity ("Effects Opacity", Range(0, 1)) = 1
		[Toggle(_)] _ParticleSystem ("Particle System?", Float) = 0

		//falloff
		[Toggle(_)] _AllowSmartFalloff("Allow Falloff", Float) = 1
		_SmartFalloffMin("Start Falloff Range", Float) = 10
		_SmartFalloffMax("End Falloff Range", Float) = 20
		
		//zoom range
		[Toggle(_)] _ToggleZoomRange ("Use Zoom Range?", Float) = 0
		_ZoomRange ("Zoom Range", Float) = 10
		_ZoomFStart ("Zoom Falloff Start", Float) = 5
		_ZoomFEnd ("Zoom Falloff End", Float) = 9.5

		//depth
		[Toggle(_)] _AllowDepthTest("Allow Depth Testing", Float) = 0
		[Toggle(_)] _KeepPlayerInFocus ("Keep Player In Focus?", Float) = 0
		[Toggle(_)] _ReverseDepth ("Reverse Focus?", Float) = 0
		_DepthValue ("Depth Value", Range(0, 30)) = 3.2
		_DepthPlayerTolerance("Player Tolerance", Range(0, 1)) = 0.84
		_DepthPlayerPower ("Focus on Player Strength", Range(1, 5)) = 5

		//screen tear 
		[Toggle(_)] _AllowTearFix ("Tear to Color?", Float) = 0
		_ScreenTearColor ("Screen Tear Color", Color) = (0.4, 0, 0.5, 1) 
		[Toggle(_)] _TearToMirror ("Tear to Mirror?", Float) = 1
		[Toggle(_)] _TearToRepeat ("Tear to Repeat?", Float)  = 0

		//vr
		_VRAdjust("VR Adjust", Range(0, 1)) = 1
		[Toggle(_)] _VRPreview ("Preview VR?", Float) = 0
		[Toggle(_)] _VRLeft ("Close Left Eye?", Float) = 0
		_VRLeftColor ("Left Eye", Color) = (0, 0, 0, 1)
		[Toggle(_)] _VRRight("Close Right Eye?", Float) = 0
		_VRRightColor ("Right Eye", Color) = (0, 0, 0, 1)

		//stretch
		_ToggleScreenFlip ("Screen Flip", Range(0, 1)) = 0
		_ToggleUpsideDown ("Upside Down", Range(0, 1)) = 0

		//coloring
		_SepiaStrength ("B&W Strength", Range(0, 1)) = 0
		_SepiaColor ("B&W Color Mod", Color) = (1, 1, 1, 1)
		[Enum(Invert, 0, FuckyWucky, 1)] _InvertMode ("Invert Mode", Float) = 0
		_InvertStrength("Invert", Range(0, 1)) = 0
		_InvertR ("Invert Red", Range(0, 1)) = 0
		_InvertG ("Invert Blue", Range(0,1)) = 0
		_InvertB ("Invert Blue", Range(0, 1)) = 0

		//afterimage
		[Toggle(_)] _ToggleAfterimage ("Allow Afterimage", Float) = 0
		_Offset ("First Offset", Range(-0.5, 0.5)) = 0.023
		_ExtraOffset ("Second Offset", Range(-0.5, 0.5)) = 0.041
		_offsetthree ("Third Offset", Range(-0.5, 0.5)) = 0.063

		//ascii
		[Toggle(_)] _ToggleAscii ("Allow ASCII Filter", Float) = 0
		_ASCIIVariation ("Shape Variation", Range(0, 5)) = 2.5
		_ASCIIPower ("Shape Amount", Range(30, 0.1)) = 3.5
		_ASCIISpeed ("Shape Speed", Range(0, 50)) = 0
		_ASCIIShapeOne ("Character One", Float) = 65536 //.
		_ASCIIShapeTwo ("Character Two", Float) = 65600 //:
		_ASCIIShapeThree ("Character Three", Float) = 332772 //*
		_ASCIIShapeFour ("Character Four", Float) = 15255086 //o
		_ASCIIShapeFive ("Character Five", Float) = 23385164 //&
		_ASCIIShapeSix ("Character Six", Float) = 15252014 //8
		_ASCIIShapeSeven ("Character Seven", Float) = 13199452 //@
		_ASCIIShapeEight ("Characcter Eight", Float) = 11512810 //#

		//blink
		[Enum(Vertical, 1, Horizontal, 2, Cinematic, 3)] _BlinkMode ("Blink Mode", Float) = 1
		[Toggle(_)] _ForceBlink ("Blink Over Img Overlay?", Float) = 1
		_BlinkStrength ("Blink Strength", Range(0, 1)) = 0
		_BlinkColor ("Bars Color", Color)  = (0, 0, 0, 1)
		_BlinkImage("Blink Image", 2D) = "white" {}
		_BlinkImagePower ("Image Visibility", Range(0, 1)) = 0
		_BlinkImageX ("Image X Size", Range(-5, 5)) = -2
		_BlinkImageY ("Image Y Size", Range(-5, 5)) = -2
		_BlinkImageY ("Image Y Size", Range(-5, 5)) = -2
		_BlinkBorderSize ("Border Size", Range(1.1, 0)) = 0.95
 		_BlinkBorder ("Border Color", Color) = (0, 0, 0, 0)
		_BlinkRainbow ("Allow Rainbow", Range(0, 1)) = 0
		[Toggle(_)] _BlinkRainbowX ("Allow Horizontal", Float) = 0
		[Toggle(_)] _BlinkRainbowY("Allow Vertical", Float) = 0
		_BlinkRainbowHue ("Hue", Range(0, 1.5)) = 0.1
		_BlinkRainbowSat ("Saturation", Range(0, 3)) = 1
		_BlinkRainbowLight ("Lightness", Range(0.1, 3)) = 1
		_BlinkRainbowTime ("Time", Range(0, 3)) = 0.8
		[Enum(Base, 0, Border, 1)]_BlinkRainbowMode ("Rainbow Mode", Float) = 0
	
		//blur
		[Toggle(_)] _ToggleNBlur ("Allow Blur", Float) = 0
		[Enum(Simple Blur, 6, Blur, 0, Circle, 1, Plus, 2, Direction, 3, Dual, 4, Dither, 5)] _NBlurShape ("Blur Shape", Float) = 1
		[IntRange] _NBlurItterations ("Blur Itterations", Range(1, 32)) = 2
		_NBlurPower ("Blur Strength", Range(0, 0.5)) = 0
		_NBlurSpeed ("Blur Speed", Range(0, 3)) = 0
		_NBlurRotate ("Blur Rotation", Float) = 0
		_NBlurRotateSpeed ("Blur Rotation Speed", Float) = 0
		_NBlurX ("Blur X Center Offset", Range(-1, 1)) = 0
		_NBlurY ("Blur Y Center Offset", Range(-1, 1)) = 0
		_NBlurColor ("Blur Color", Color) = (1, 1, 1, 1)
		_NBlurGlow ("Blur Glow", Range(0, 10)) = 1
		_NBlurOpacity ("Blur Opacity", Range(0, 1)) = 1

		//exposure
		_BloomGlow ("Bloom Glow", Range(1, 10)) = 1

		//bloom   
		[Toggle(_)] _RBloomToggle("Allow Bloom", Float) = 0
		[IntRange]_RBloomQuality("Bloom Quality", Range(4, 32)) = 16 
		_RBloomStrength("Bloom Strength", Range(0, 0.025)) = 0
		_RBloomBright("Bloom Brightness", Range(1, 5)) = 1.3
		_RBloomColor("Bloom Color", Color) = (1, 1, 1, 1)
		_RBloomOpacity("Bloom Opacity", Range(0, 1)) = 0.8
		_RBloomDepth("Bloom Depth", Float) = 0

		//bulge
		_ToggleBulge ("Bulge Zoom", Range(0, 1)) = 0
		_BulgeIndent ("Bulge Indent", Range(0, 1)) = 0
		_OwOStrength ("Bulge Warp", Range(1, 20)) = 5

		//zoom
		[Toggle(_)] _ToggleZoom ("Allow Zoom", Float) = 0
		[Toggle(_)] _ToggleFlipZoom ("Flip Zoom", Float) = 0
		[Toggle(_)] _ToggleSmoothZoom ("Smooth Zoom", Float) = 0 
		_ZoomInValue ("Zoom In", Range(0.01, 10)) = 1 
		_ZoomOutValue ("Zoom Out", Range(0, 10)) = 0
		[Toggle(_)] _SmoothZoom("Allow Smooth Zoom", Float) = 0
		_SmoothZoomTolerance("Angle Tolerance", Range(0, 1)) = 0.4  

		//big box zoom
		[Toggle(_)] _ToggleBigZoom ("Allow Big Box Zoom", Float) = 0
		_BigZoomAmount ("Zoom In Amount", Range(0, 1)) = 0
		_BigZoomOutAmount ("Zoom Out Amount", Range(0, 1)) = 0
		_BigZoomTolerance ("Zoom Tolerance", Range(0, 1)) = 0.8

		//coloring
		_ColorHue ("Hue", Range(0, 1)) = 0
		_ColorSaturation ("Saturation", Range(0, 1)) = 0
		_ColorValue ("Value", Range(0, 1)) = 0
		[HDR] _ColorRGB ("RGB Color Droplet", Color) = (1,1,1,1) 
		_SolidTrans ("Solid Color Transparency", Range(0, 1)) = 0
		_SolidCol ("Solid Color", Color) = (0, 0, 1, 1)
		_ColorRGBtoHSV ("RGB to HSV?", Range(0, 1)) = 0
		_ColorHSVtoRGB ("HSV to RGB?", Range(0, 1)) = 0

		//color split
		[Toggle(_)] _ToggleColorSplit ("Allow Color Split", Float) = 0
		_ColorSplitAmount ("Color Split", Range(-0.5, 0.5)) = 0
		_ColorSplitRGBone ("Left Color", Color) = (1, 1, 1, 1)
		_ColSpONEopacity ("Left Brightness", Range(0, 5)) = 1
		_ColorSplitRGBtwo ("Middle Color", Color) = (1, 1, 1, 1)
		_ColSpTWOopacity ("Middle Brightness", Range(0, 5)) = 1
		_ColorSplitRGBthree ("Right Color", Color) = (1, 1, 1, 1)
		_ColSpTHREEopacity ("Right Brightness", Range(0, 5)) = 1
		[Toggle(_)] _ToggleColorSplitStaySides ("Colors Dont Cross", Float) = 1
		[Toggle(_)] _ToggleAutoanimateColorSplit ("Animate Color Split", Float) = 0
		_ColorSplitSpeed ("Color Split Speed", Range(1, 5)) = 0
		_CSLX ("Left Horizontal Offset", Range(-0.5, 0.5)) = 0
		_CSLY ("Left Vertical Offset", Range(-0.5, 0.5)) = 0
		_CSMX ("Middle Horizontal Offset", Range(-0.5, 0.5)) = 0
		_CSMY ("Middle Vertical Offset", Range(-0.5, 0.5)) = 0
		_CSRX ("Right Horizontal Offset", Range(-0.5, 0.5)) = 0
		_CSRY ("Right Vertical Offset", Range(-0.5, 0.5)) = 0
		[IntRange] _CSL ("Split Samples", Range(1, 32)) = 16
		_CSRotate("CA Rotate", Float) = 0
		_ColSplRotateSpeed("CA Rotate Speed", Float) = 0
		_CSOffsetX("Colorsplit X Offset", Range(-1, 1)) = 0
		_CSOffsetY("Colorsplit Y Offset", Range(-1, 1)) = 0
		_CSTrans ("ColorsTransparency", Range(0, 1)) = 1

		//contrast
		_ContrastValue ("Contrast", Range(-5, 5)) = 1

		//color spin
		_ToggleCC ("Allow Corner Spin", Range(0, 1)) = 0
		[Enum(Equals, 0, Multiply, 1, Overlay, 2)] _CCApply ("Apply Method", Float) = 0
		_CCOne ("Color One", Color) = (1, 0, 0, 1)
		_CCTwo ("Color Two", Color) = (0, 1, 0, 1)
		_CCThree ("Color Three", Color) = (0, 0, 1, 1)
		_CCFour ("Color Four", Color) = (1, 0, 1, 1)
		_CCRotate ("Color Rotation", Range(0, 2)) = 0
		_CCSpeed ("Rotation Speed", Range(-0, 2)) = 0

		//Corner colors
		_CornerOneColor ("Left Bottom Color", Color) = (1, 1, 1, 1)
		_CornerTwoColor ("Left Top Color", Color) = (1, 1, 1 ,1)
		_CornerThreeColor ("Right Bottom Color", Color) = (1, 1, 1, 1)
		_CornerFourColor ("Right Top Color", Color) = (1, 1, 1, 1)
		_CornerOneTrans ("Left Bottom Transparency", Range(0, 1)) = 0
		_CornerTwoTrans ("Left Top Transparency", Range(0, 1)) = 0
		_CornerThreeTrans ("Right Bottom Transparency", Range(0, 1)) = 0
		_CornerFourTrans ("Right Top Transparency", Range(0, 1)) = 0

		//color gradient
		_GradTrans ("Gradient Transparency", Range(0, 1)) = 0
		[Enum(Horizontal, 0, Vertical, 1)] _GradMode ("Gradient Path", Float) = 0
		[Enum(Overlay, 0, Multiply, 1)] _GradApply ("Gradient Apply", Float) = 1
		_GradOne ("Gradient Color One", Color) = (0.8, 0, 0.4, 0)
		_GradTwo ("Gradient Color Two", Color) = (0.2, 0, 0.9, 0)

		//darken
		_DarknessStrength ("Darkness", Range(0, 1)) = 0

		//distortion
		[Toggle(_)] _ToggleDistortion ("Allow Distortion", Float) = 0
		_DistortionMap ("Distortion Map", 2D) = "white" {}
		_DistortionX ("X Power", Range(0, 1)) = 0
		_DistortionY ("Y Power", Range(0, 1)) = 0
		_DistortionXSpeed ("X Speed", Range(0, 5)) = 0
		_DistortionYSpeed ("Y Speed", Range(0, 5)) = 0
		_DistortionRotate ("Rotation Power", Float) = 0
		_DistortionRotateSpeed ("Rotation Speed", Float) = 0
		_DistortionTransparency ("Transparency", Range(0, 1)) = 1

		//dizzy
		[Toggle(_)] _ToggleDizzyEffect ("Allow Dizzy", Float) = 0 
		[Enum(Dizzy,1,Slide,3,Blink,4)] _DizzyMode ("Dizzy Mode", Float) = 1
		_DizzyAmountValue ("Dizzy Speed", Float) = 25
		_DizzyRotationSpeed ("Dizzy Strength", Float) = 20

		//droplet
		[Toggle(_)] _ToggleDroplet ("Allow Droplet", Float) = 0 
		[Toggle(_)] _ToggleUseHSVInstead ("Use HSV Instead (If off uses RGB) (Falloff only on HSV)", Float) = 1
		_ToggleDropletSepia ("Allow Black and White Background", Range(0, 1)) = 0
		_DropletColOne ("Old Color", Color) = (0, 0, 0, 0)
		_DropletColTwo ("New Color", Color) = (0, 0, 0, 0)
		_DropletTolerance ("Tolerance", Range(0, 0.5)) = 0.01
		_DropletIntensity ("Intensity", Range(0, 1)) = 1
		[Toggle(_)] _ToggleDropletTwo ("Allow Second Color", Float) = 0 
		_TwoDropletColOne ("Old Color", Color) = (0, 0, 0, 0)
		_TwoDropletColTwo ("New Color", Color) = (0, 0, 0, 0)
		_TwoDropletTolerance ("Tolerance", Range(0, 0.05)) = 0.01
		_TwoDropletIntensity ("Intensity", Range(0, 1)) = 1
		[Toggle(_)] _ToggleDropletThree ("Allow Third Color", Float) = 0 
		_ThreeDropletColOne ("Old Color", Color) = (0, 0, 0, 0)
		_ThreeDropletColTwo ("New Color", Color) = (0, 0, 0, 0)
		_ThreeDropletTolerance ("Tolerance", Range(0, 0.05)) = 0.01
		_ThreeDropletIntensity ("Intensity", Range(0, 1)) = 1
		[Toggle(_)] _ToggleDropletFourth("Allow Fourth Color", Float) = 0
		_FourDropletColOne("Old Color", Color) = (0, 0, 0, 0)
		_FourDropletColTwo("New Color", Color) = (0, 0, 0, 0)
		_FourDropletTolerance("Tolerance", Range(0, 0.05)) = 0.01
		_FourDropletIntensity("Intensity", Range(0, 1)) = 1

		//duotone
		_ToggleDuotone ("Allow Duotone", Range(0, 1)) = 0
		_DuotoneHardness ("Hardness", Range(1, 0.01)) = 0.01
		_DuotoneThreshold ("Threshold", Range(0, 1)) = 0.25
		_DuotoneColOne ("Old Color", Color) =  (0, 0, 0, 1)
		_DuotoneColTwo ("New Color", Color) = (1, 1, 1, 1)

		//earthquake
		[Toggle(_)] _SSAllowVerticalShake ("Vertical Shake", Float) = 0 //ss means split shake lol
		[Toggle(_)] _SSAllowHorizontalShake ("Horizontal Shake", Float) = 0
		[Toggle(_)] _SSAllowVerticalBlur ("Vertical Motion Blur", Float) = 0
		[Toggle(_)] _SSAllowHorizontalBlur ("Horizontal Motion Blur", Float) = 0
		_SSValue ("Horizontal Shakiness", Range(0, 0.08)) = 0.0226
		_SSSpeed ("Horizontal Speed", Range(0, 15)) = 6.24
		_SSValueVert ("Vertical Shakiness", Range(0, 0.08)) = 0.0272
		_SSSpeedVert ("Vertical Speed", Range(0, 15)) = 3.14
		_SSTransparency ("Blur Transparency", Range(0, 1)) = 1

		//edge detect
		[Toggle(_)] _ToggleED("Allow Outline", Float) = 0
		_EDColor("Outline Color", Color) = (1, 1, 1, 1)
		_EDTolerance("Outline Tolerance", Range(0, 5)) = 0.2
		_EDGlow("Outline Glow", Range(1, 30)) = 1
		_EDTrans("Outline Transparency", Range(0, 1)) = 1
		_EDXOffset("Horizontal Offset", Range(-1, 1)) = 0
		_EDYOffset("Vertical Offset", Range(-1, 1)) = 0
		_EDWidth ("Outline Width", Range(1, 10)) = 1
		_EDBW ("B&W Screen?", Range(0, 1)) = 0
		_EDToggleRainbow ("Allow Rainbow", Range(0, 1)) = 0
		[Toggle(_)] _EDToggleHSVRainbowX("Allow Horizontal", Float) = 0
		[Toggle(_)] _EDToggleHSVRainbowY("Allow Vertical", Float) = 0
		_EDHSVRainbowHue("Hue", Range(0, 1.5)) = 0.698
		_EDHSVRainbowSat("Saturation", Range(0, 3)) = 0.97	
		_EDHSVRainbowLight("Lightness", Range(0.1, 3)) = 1.06
		_EDHSVRainbowTime("Time", Range(0, 3)) = 0.89
		_EDBackPower ("Background Strength", Range(0, 1)) = 0
		_EDBackColor ("Background Color", Color) = (0, 0, 0, 1)
		[Toggle(_)] _EDRampAllow ("Allow Gradient Outline", Float) = 0
		_EDRampMap("Color Map", 2D) = "colorramp" {}
		_EDRampX ("Horizontal Size", Range(0.1, 3)) = 1
		_EDRampY ("Vertical Size", Range(0.1, 3)) = 1
		_EDRampSX ("Horizontal Scroll", Range(0, 2)) = 0
		_EDRampSY ("Vertical Scroll", Range(0, 2)) = 0
		[Toggle(_)] _EDRampScroll ("Autoscroll?", Float) = 1
		_EDDither ("Dither", Range(0, 1)) = 0
		_EDDitherSpeed ("Dither Speed", Range(0, 3)) = 0

		//edge smear
		[Toggle(_)] _ToggleEdgeDistort ("Allow Edge Distort", Float) = 0
		_EdgeDisX ("Horizontal Distort", Range(-2, 2)) = 0.1
		_EdgeDisY ("Vertical Distort", Range(-2, 2)) = 0.1
		[Toggle(_)] _ToggleEdgeDisRotate ("Allow Rotation", Float) = 1
		_EdgeDisRotStr ("Rotation Strength", Range(10, 0.1)) = 4.18
		_EdgeDisRotSpeed ("Rotation Speed", Range(0, 10)) = 0.93

		//fade
		[Toggle(_)] _ToggleFadeProjection("Allow Fade Projection", Float) = 0
		[Enum(Front, 0, Back, 1)] _FadeLayer ("Projection Layer:", Float) = 0
		_FPZoom ("Zoom Amount", Range(0, 1)) = 0.35
		_FPFade ("Fade Amount", Range(0, 1)) = 0.4
		_FPColor ("Projection Color", Color) = (1, 1, 1, 1)

		//filter
		[Toggle(_)] _ToggleFilter ("Allow Filter", Float) = 0 
		[Toggle(_)] _ToggleHSVFilterDisableLock ("Use HSV (Disabled, Broken)", Float) = 0
		[Toggle(_)] _ToggleAdvancedFilter ("Use Advanced Options", Float) = 0
		[Toggle(_)] _ToggleColoredFilter ("Allow Colored Background", Float) = 0
		_FilterColor ("Filtered Colored", Color) = (0, 0, 0, 0)
		_FilterTolerance ("Filter Tolerance", Range(0, 1)) = 0.1
		_FilterMinR ("[Advanced] Filter Red Min", Range(0, 1)) = 0.1 
		_FilterMaxR ("[Advanced] Filter Red Max", Range(0, 1)) = 0.1
		_FilterMinG ("[Advanced] Filter Green Min", Range(0, 1)) = 0.1 
		_FilterMaxG ("[Advanced] Filter Green Max", Range(0, 1)) = 0.1
		_FilterMinB ("[Advanced] Filter Blue Min", Range(0, 1)) = 0.1 
		_FilterMaxB ("[Advanced] Filter Blue Max", Range(0, 1)) = 0.1
		_FilterIntensity ("Color Strength", Range(0, 1)) = 1
		_BackgroundFilterIntensity ("Background Color Strength", Range(0, 1)) = 0.5
		_BackgroundFilterColor ("Background Color", Color) = (0, 0, 0, 0)

		//film
		_FilmPower ("Film Strength", Range(0, 1)) = 0
		[Toggle(_)] _FilmAllowLines ("Allow Lines?", Float) = 1
		[Toggle(_)] _FilmAllowSpots ("Allow Spots?", Float) = 1
		[Toggle(_)] _FilmAllowStripes ("Allow Stripes?", Float) = 1
		_FilmItterations ("Film Update Rate", Range(0, 25)) = 10
		_FilmBrightness ("Film Brightness", Range(0, 1)) = 0.1
		_FilmJitterAmount ("Jitter Strength", Range(0, 0.01)) = 0.004
		_FilmSpotStrength ("Spot Size", Range(0, 50)) = 1
		_FilmLinesOften ("Line Frequency", Range(0, 2)) = 0
		_FilmSpotsOften ("Spot Frequency", Range(0, 5)) = 5
		_FilmStripesOften ("Stripes Frequency", Range(0, 1)) = 1
		[Toggle(_)]_ToggleReel ("Film Reel?", Float) = 0
		[Enum(Vertical, 0, Horizontal, 1, Scroll, 2, Peak, 3, Diamond, 4)] _ReelMode ("Reel Direction", Float) = 0
		_ReelSpeed ("Reel Speed", Range(0, 2)) = 1
		_ReelColor ("Reel Color", Color) = (0, 0, 0, 1)
		_ReelBars ("Bar Thickness", Range(0, 0.02)) = 0
		_ReelBarHeigth ("Bar Heigth", Range(0, 0.4)) = 0
		_ReelWidth ("Reel Width", Range(0, -0.4)) = 0
		_ReelJitter ("Reel Jitter", Range(0, 0.05)) = 0
		[IntRange] _ReelBarAmounts ("Reel Number Bars", Range(5, 15)) = 10
		_ReelRainbow ("Rainbow Reel?", Range(0, 1)) = 0
		[Toggle(_)] _ReelRainbowX ("Rainbow X?", Float) = 0
		[Toggle(_)] _ReelRainbowY ("Rainbow Y?", Float) = 0

		//fog
		_ToggleFog ("Allow Fog", Range(0, 1)) = 0
		[Enum(Front,0,Back,1)] _FogLayer ("Fog Layer:", Float) = 0
		_FogDensity ("Fog Density", Float) = 0
		_FogColor ("Fog Color", Color) = (1, 1, 1, 1)
		_FogRainbow ("Fog Rainbow", Range(0, 1)) = 0
		_FogRainbowSpeed ("Fog Rainbow Speed", Range(0, 0.25)) = 0.1
		_FogSafe("Fog Safe Zone", Float) = 0 
		_FogSafeTol("Safe Zone Tolerance", Float) = 0

		//gamma
		_GammaRed ("Red Gamma", Range(-1, 1)) = 0
		_GammaGreen ("Green Gamma", Range(-1, 1)) = 0
		_GammaBlue ("Gamma Blue", Range(-1, 1)) = 0

		//girlscam
		[Toggle(_)] _ToggleGirlscam ("Allow Girlscam", Float) = 0
		[Enum(Horizontal, 0, Vertical, 1)] _GirlscamDir ("Direction", Float) = 0
		_GirlscamStrength ("Strength", Range(0, 3)) = 0
		_GirlscamTime ("Speed", Range(0, 10)) = 0

		//manual glitch
		[Toggle(_)] _ToggleGlitch ("Allow CRT Glitch", Float) = 0
		_GlitchRedMap ("Glitch Map", 2D) = "white" {}
		_GlitchRedDistort ("Glitch Strength", Range(-0.05, 0.05)) = 0
		_RedYGlitch ("Y Glitch", Range(3, 15)) = 10
		_RedXGlitch ("X Glitch", Range(0.05, 0.8)) = 0.35
		_RedTileGlitch ("Tile Glitch", Range(0, 10)) = 1
		[Toggle(_)] _ToggleRandomGlitch ("Animate Glitch [Beta, Mostly Testing]", Float) = 0
		[Toggle(_)] _ToggleRandomSideGlitch ("Randomize Direction", Float) = 0
		_XGAnimate ("X Animate", Range(-0.8, 0.8)) = 0.35
		_YGAnimate ("Y Animate", Range(4, 15)) = 0 
		_TileGAnimate ("Tile Animate", Range(0, 10)) = 0
		_GlitchSideFactor ("Direction Randomize", Range(0, 5)) = 0
		[Toggle(_)] _ToggleGlitchChromatic ("Allow Glitch RGB", Float) = 0
		_GlitchRGBStrength ("Glitch RGB Strength", Range(0,0.25)) = 0
		_GlitchRGBSpeed ("Glitch RGB Speed", Range(0,2)) = 0
		_GlitchRGB ("Glitch RGB Randomness", Range(0,1)) = 0

		//rgb glitch
		[Toggle(_)] _ToggleRGBGlitch ("Allow RGB Glitch", Float) = 0
		[Enum(Horizontal, 0, Vertical, 1, Both, 2)]_RGBBlockMethod ("Block Applies To:", Float) = 0
		_RedNoiseMap ("Red Noise", 2D) = "white" {}
		_GreenNoiseMap ("Green Noise", 2D) = "white" {}
		_BlueNoiseMap ("Blue Noise", 2D) = "white" {}
		_RedNoisePower ("Red Power", Float) = 0
		_RedNoiseSpeed ("Red Speed", Float) = 0
		_GreenNoisePower ("Green Power", Float) = 0
		_GreenNoiseSpeed ("Green Speed", Float) = 0
		_BlueNoisePower ("Blue Power", Float) = 0
		_BlueNoiseSpeed ("Blue Speed", Float) = 0
		_RedBlocks ("Red Block Offset", Range(0, 0.05)) = 0
		_GreenBlocks ("Green Block Offset", Range(0, 0.05)) = 0
		_BlueBlocks ("Blue Block Offset", Range(0, 0.05)) = 0
		_RedBlockCount ("Red Blocks", Range(0, 384)) = 0
		_GreenBlockCount ("Green Blocks", Range(0, 384)) = 0
		_BlueBlockCount ("Blue Blocks", Range(0, 384)) = 0
		_RedBlockSpeed ("Red Block Speed", Range(0, 0.1)) = 0
		_GreenBlockSpeed ("Green Block Speed",  Range(0, 2)) = 0
		_BlueBlockSpeed ("Blue Block Speed",  Range(0, 2)) = 0
		_RGBGlitchTrans ("RGB Glitch Transparency", Range(0, 2)) = 1

		//blocky glitch
		[Toggle(_)] _ToggleBlockyGlitch("Allow Blocky Glitch", Float) = 0
		_BlockGlitchMap("Block Glitch Map", 2D) = "white" {}
		[Toggle(_)] _AllowBGX("Allow Horizontal Glitch", Float) = 1
		[Toggle(_)] _AllowBGY("Allow Vertical Glitch", Float) = 0
		_BlockyGlitchStrength("Strength", Range(0, 25)) = 0.5
		_BlockyGlitchSpeed ("Speed", Range(0, 25)) = 1.2
		_BDepthX ("Horizontal Depth", Range(0, 1000)) = 25.0
		_BDepthY ("Vertical Depth", Range(75, 1750)) = 111.0
		_BGRandomnessInc("Randomness Amount", Range(0, 5)) = 0
		[Toggle(_)] _ToggleBlockyRGB("Allow Blocky RGB", Float) = 1
		_BlockyRGBPush("RGB Strength", Range(0, 10)) = 0.3
		_BlockyRGBSpeed("RGB Speed", Range(0, 10)) = 3.7
		[Toggle(_)] _AllowBGColors("Allow Broken Colors", Float) = 1
		_BGOverlayColor ("Overlay Color", Color) = (0.1, 0.1, 0.1, 1)
		_BGOverlayIntensity ("Color Overlay Intensity", Range(0, 0.25)) = 0.01
		_BGBrokenColorIntensity ("Broken Color Intensity", Range(0, 0.5)) = 0.1
		_BGBrokenRandom ("Broken Color Randomize", Range(0, 1)) = 0.5
		_BGOverlayToggle ("Toggle Broken Colors", Range(0, 1)) = 0
		_BGOverlayMap("Degrading Map", 2D) = "white" {}

		//scanline Glitch
		[Toggle(_)] _ToggleScanline ("Allow Scanline", Float) = 0
		[Enum(Vertical, 0, Horizontal, 1)] _ScanlineDir ("Scanline Direction", Float) = 0
		_ScanlinePush("Scanline Push", Range(-0.1, 0.1)) = 0.1
		_ScanlineSize("Scanline Size", Range(0, 0.10)) = 0
		_ScanlineSpeed("Scanline Speed", Range(-1.5, 1.5)) = 0.3

		//inception
		_ToggleInception ("Allow Inception", Range(0, 1)) = 0
		[Enum(Both, 0, Front, 1, Back, 2)] _InceptionItterations ("FX Layer:", Float) = 1
		_InceptionSize ("Copy Size",  Range(-10, 0)) = -1
		_InceptionShiftX ("X Shift", Range(-1, 1)) = 0
		_InceptionShiftY ("Y Shift", Range(-1, 1)) = 0

		//mirror
		[Toggle(_)] _ToggleMirror ("Allow Mirror", Float) = 0
		[Toggle(_)] _MirrorHU ("Horizontal Under Mirror?", Float) = 0
		[Toggle(_)] _MirrorHO("Horizontal Over Mirror?", Float) = 0
		[Toggle(_)] _MirrorVU("Vertical Under Mirror?", Float) = 0
		[Toggle(_)] _MirrorVO("Vertical Over Mirror?", Float) = 0

		//screens
		_ToggleScreens ("Allow Screens?", Range(0, 1)) = 0
		_ScreensXRow ("Horizontal Amount of Screens", Range(-1, -10)) = -1

		//overlay
		[Toggle(_)] _ToggleOverlay ("Allow Overlay", Float) = 0
		[Toggle(_)] _ToggleTransparentImage ("Transparent Image?", Float) = 0
		[Toggle(_)] _UseSepOverlay ("Use Different Image for VR", Float) = 0
		_OverlayTexture ("Overlay Texture", 2D) = "OverlayTexture" {}
		_VROverlayTexture ("VR Overlay Texture", 2D) = "VROverlayTexture" {}
		_OverlayTransparency ("Transparency", Range(0, 1)) = 1
		_OverlayYAdjust("Height", Range(0, 3)) = 0.75
		_OverlayXAdjust("Width", Range(0, 3)) = 0.75
		_OverlayTiling("Tiling", Range(-5, 5)) = -0.5
		_OverlayXShift("X Shift", Range(-3, 3)) = 0
		_OverlayYShift("Y Shift", Range(-3, 3)) = 0
		[Toggle(_)] _OverlayTrans ("Allow Transistion", Float) = 0
		_OverlayTransX ("Horizontal Transistion", Range(-2, 2)) = 0
		_OverlayTransY ("Vertical Transistion", Range(-2, 2)) = 0
		[Toggle(_)] _ToggleOverlayTwo("Allow Second Overlay", Float) = 0
		[Toggle(_)] _ToggleTransparentImageTwo ("Transparent Image?", Float) = 0
		_OverlayTextureTwo("Second Overlay Texture", 2D) = "OverlayTexture" {}
		_OverlayTransparencyTwo("Second Transparency", Range(0, 1)) = 1
		_OverlayYAdjustTwo("Second Height", Range(0, 3)) = 0.75
		_OverlayXAdjustTwo("Second Width", Range(0, 3)) = 0.75
		_OverlayTilingTwo("Second Tiling", Range(-5, 5)) = -0.5
		_OverlayXShiftTwo("Second X Shift", Range(-3, 3)) = 0
		_OverlayYShiftTwo("Second Y Shift", Range(-3, 3)) = 0
		[Toggle(_)] _OverlayTransTwo("Allow Transistion", Float) = 0
		_OverlayTransXTwo("Horizontal Transistion", Range(-2, 2)) = 0
		_OverlayTransYTwo("Vertical Transistion", Range(-2, 2)) = 0
		[Toggle(_)] _ToggleOverlayThree("Allow Third Overlay", Float) = 0
		[Toggle(_)] _ToggleTransparentImageThree ("Transparent Image?", Float) = 0
		_OverlayTextureThree("Third Overlay Texture", 2D) = "OverlayTexture" {}
		_OverlayTransparencyThree("Third Transparency", Range(0, 1)) = 1
		_OverlayYAdjustThree("Third Height", Range(0, 3)) = 0.75
		_OverlayXAdjustThree("Third Width", Range(0, 3)) = 0.75
		_OverlayTilingThree("Third Tiling", Range(-5, 5)) = -0.5
		_OverlayXShiftThree("Third X Shift", Range(-3, 3)) = 0
		_OverlayYShiftThree("Third Y Shift", Range(-3, 3)) = 0
		[Toggle(_)] _OverlayTransThree("Allow Transistion", Float) = 0
		_OverlayTransXThree("Horizontal Transistion", Range(-2, 2)) = 0
		_OverlayTransYThree("Vertical Transistion", Range(-2, 2)) = 0
		_OvScOne("Overlay Scroll", Float) = 0
		_OvScTwo("Overlay Scroll", Float) = 0
		_OvScThree("Overlay Scroll", Float) = 0
		_OvScOneY("Overlay Scroll", Float) = 0
		_OvScTwoY("Overlay Scroll", Float) = 0
		_OvScThreeY("Overlay Scroll", Float) = 0
		[Toggle(_)]_OvScOneT("Scroll and Tile?", Float) = 0
		[Toggle(_)]_OvScTwoT("Scroll and Tile?", Float) = 0
		[Toggle(_)]_OvScThreeT("Scroll and Tile?", Float) = 0   

		//gif overlay
		[Toggle(_)] _ToggleGifOverlay ("Allow Gif Overlay", Float) = 0
		[Toggle(_)] _ToggleACTUALTransparentGif ("Transparent GIF?", Float) = 0
		_OverlaySpritesheet ("Overlay Spritesheet", 2D) = "OverlaySpritesheet" {}
		_OSSRows ("Rows", Float) = 0  //oss is overlay sprite sheet for future me wondering lol
		_OSSColumns ("Columns", Float) = 0
		_OSSSpeed ("Speed", Float) = 0
		_GifTransparency ("Transparency", Range(0, 1)) = 1
		_GifYAdjust("Height", Range(0, 3)) = 0.75
		_GifXAdjust("Width", Range(0, 3)) = 0.75
		_GifTiling("Tiling", Range(-5, 5)) = -0.5
		_GifXShift("X Shift", Range(-3, 3)) = 0
		_GifYShift("Y Shift", Range(-3, 3)) = 0

		//linocut
		_LinocutPower ("Linocut Power", Range(0, 10)) = 1
		_LinocutOpacity ("Linocut Opacity", Range(0, 1)) = 0
		_LinocutColor ("Linocut Color", Color) = (1, 1, 1, 1)

		//neon outline
		_ToggleOutline ("Allow Outline", Range(0, 1)) = 0
		_OutlineSepiaAmount ("Desaturatation Amount", Range(0, 1)) = 0
		_OutlineOffset ("Outline Coverage", Range(-0.08, 0.0074)) = 0.0043
		_OutlineActualOffset ("Outline Offset", Range(0.00029, 0.01)) = 0.00505
		_OutlineModOne ("Outline Darkness", Range(0, 10)) = 1
		_OutlineModTwo ("Outline Value One", Range(0, 5)) = 0.5
		_OutlineModThree ("Outline Value Two", Range(0, 5)) = 1 
		_OutlineModFour ("Outline Value Three", Range(0, 5)) = 3

		//radial
		[Toggle(_)] _ToggleRadialBlur ("Allow Radial Blur", Float) = 0 
		_RadialBlurDistance ("Blur Strentgh", Range(0, 1)) = 0
		//_RadialBlurCenterRadius ("Center Radius", Range(0, 1)) = 0.27
		_RadialBlurVerticalCenter ("Center (Vertical Axis)", Range(0, 1)) = 0.5 
		_RadialBlurHorizontalCenter ("Center (Horizontal Axis)", Range(0, 1)) = 0.5 
		[Toggle(_)] _RBToggleED("Allow Outline", Float) = 0
		_RBEDColor("Radial Outline Color", Color) = (1, 1, 1, 1)
		_RBEDTolerance("Radial Outline Tolerance", Range(0, 5)) = 0.2
		_RBEDTrans("Radial Outline Transparency", Range(0, 1)) = 1
		_RBEDWidth("Radial Outline Width", Range(1, 10)) = 1
		_RBEDBW("Radial B&W Screen?", Range(0, 1)) = 0
		_RBEDToggleRainbow("Radial Allow Rainbow", Range(0, 1)) = 0
		[Toggle(_)] _RBEDToggleHSVRainbowX("Radial Allow Horizontal", Float) = 0
		[Toggle(_)] _RBEDToggleHSVRainbowY("Radial Allow Vertical", Float) = 0
		_RBEDHSVRainbowHue("Radial Hue", Range(0, 1.5)) = 0.698
		_RBEDHSVRainbowSat("Radial Saturation", Range(0, 3)) = 0.97
		_RBEDHSVRainbowLight("Radial Lightness", Range(0.1, 3)) = 1.06
		_RBEDHSVRainbowTime("Radial Time", Range(0, 3)) = 0.89
		_RBEDBackPower("Radial Background Strength", Range(0, 1)) = 0
		_RBEDBackColor("Radial Background Color", Color) = (0, 0, 0, 1)
		_RBDither ("Radial Dither", Float) = 0
		_RBDitherSpeed ("Radial Dither Speed", Float) = 0
		_RBToggleRainbow("Radial Allow Rainbow", Range(0, 1)) = 0
		[Toggle(_)] _RBToggleHSVRainbowX("Radial Allow Horizontal", Float) = 0
		[Toggle(_)] _RBToggleHSVRainbowY("Radial Allow Vertical", Float) = 0
		_RBHSVRainbowHue("Radial Hue", Range(0, 1.5)) = 0.698
		_RBHSVRainbowSat("Radial Saturation", Range(0, 3)) = 0.97
		_RBHSVRainbowLight("Radial Lightness", Range(0.1, 3)) = 1.06
		_RBHSVRainbowTime("Radial Time", Range(0, 3)) = 0.89
		_RBRotate ("Radial Rotate", Float) = 0
		_RBRotateSpeed ("Radial Rotation Speed", Float) = 0
		_RBCAOffset ("Radial RGB Offset", Range(0, 0.03)) = 0
		_RBCATrans ("Radial RGB Transparency", Range(0, 1)) = 1
		_RBEmpower ("Radial Power over Itteration", Range(0, 0.5)) = 0.01
		[Enum(Radial Zoom, 3, Radial, 0, Projection, 1, Rotation, 2)]_RBMode ("Radial Projection Mode", Float) = 3
		[IntRange] _RBItterations("Radial Blur Itterations", Range(1, 32)) = 16
		[Enum(OFF, 0, ON, 1)] _RBEDOnly ("Outli ne Only?", Float ) = 0
		_RBEDBalance ("Radial Balance Lighting", Range(0.1, 50)) = 1
		_RBGrainPower ("Radial Grain Power", Range(0, 1)) = 0
		_RBGrainSpeed ("Radial Grain Speed", Range(0, 10)) = 0
		_RBGrainColor ("Radial Grain Color", Color) = (1, 1, 1, 1)
		_RBGrainBlack ("Radial Black Grain?", Range(0, 1)) = 0

		//rainbow
		_ToggleHSVRainbow("Allow Rainbow", Range(0, 1)) = 0
		[Toggle(_)] _ToggleHSVRainbowX("Allow Horizontal", Float) = 0
		[Toggle(_)] _ToggleHSVRainbowY("Allow Vertical", Float) = 0
		_HSVRainbowHue("Hue", Range(0, 1.5)) = 0.1
		_HSVRainbowSat("Saturation", Range(0, 3)) = 1
		_HSVRainbowLight("Lightness", Range(0.1, 3)) = 1
		_HSVRainbowTime("Time", Range(0, 3)) = 0.8

		//ramp
		_ToggleRampEffect ("Ramp Transparency", Range(0, 1)) = 0
		[Enum(Red, 0, Green, 1, Blue, 2)] _RampColorChannel ("Ramp Color Channel", Float) = 0
		_RampMap ("Ramp Map One", 2D) = "white" {}
		_RampOneLighting ("Ramp Lighting", Range(1, 10)) = 4
		_RampOneDepth ("Ramp One Depth", Range(1, 50)) = 1
		_RampOneStrength ("Ramp One Value", Range(1, 5)) = 1
		[Toggle(_)] _ToggleRampOneAnimate ("Autoanimate Ramp One", Float) = 1 
		_RampOneSpeed ("Ramp One Speed", Range(-10, 10)) = 0 

		//recolor 
		[Toggle(_)] _ToggleRecolor ("Allow Hue Shift", Float) = 0 
		[Toggle(_)] _ToggleRecolorAnimate ("Rainbow?", Float) = 0
		_RecolorBright ("Brightness", Float) = 1 
		_RecolorSat ("Saturation", Float) = 2 
		_RecolorHue ("Hue", Float) = 3
		_RecolorSpeed ("Speed", Float) = 1

		//rgb
		[Toggle(_)] _ToggleRGB ("Allow CA?", Float) = 0
		[Enum(RGB, 0, HSB, 1, Negativity, 2)] _CAMode ("CA Mode", Float) = 0
		[Enum(Simple and Color Method, 0, Sampled, 1, Rotating, 2)] _CAStyle("CA Style", Float) = 1
		[Toggle(_)] _ToggleCleanRGB ("Clean RGB?", Float) = 0
		[IntRange] _CASamples ("CA Samples", Range(1, 32)) = 16
		_CATrans ("CA Transparency", Range(0, 1)) = 1
		_RedXValue ("Red Horizontal Offset", Range(-0.25, 0.25)) = 0.01
		_RedYValue ("Red Vertical Offset", Range(-0.25, 0.25)) = 0
		_GreenXValue ("Green Horizontal Offset", Range(-0.25, 0.25)) = 0
		_GreenYValue ("Green Vertical Offset", Range(-0.25, 0.25)) = 0
		_BlueXValue ("Blue Horizontal Offset", Range(-0.25, 0.25)) = 0.01
		_BlueYValue ("Blue Vertical Offset", Range(-0.25, 0.25)) = 0
		[Toggle(_)] _ToggleAutoanimate ("Animate RGB?", Float ) = 0
		_RGBAutoanimateSpeed ("Animate Speed", Range(0, 10)) = 0
		_CARotate ("CA Rotate", Float) = 0
		_CARotateSpeed ("CA Rotate Speed", Float) = 0
		_CAOffsetX ("CA X Offset", Range(-1, 1)) = 0
		_CAOffsetY ("CA Y Offset", Range(-1, 1)) = 0
		[Space(10)] 
		_RotationStrength ("Rotation Strength", Range(0, 0.75)) = 0
		_RotationSpeedRed ("Rotation Speed for the Red", Float) = 30.0
		_RotationSpeedBlue ("Rotation Speed for the Blue", Float) = -30.0
		_DirectionRed ("Rotation Direction for the Red", Float) = -1.0
		_DirectionBlue ("Rotation Direction for the Blue", Float) = 1.0
		_RotationSpeedGreen("Rotation Speed for the Green", Float) = 30.0
		_DirectionGreen("Rotation Direction for the Green", Float) = 1.0
		[Toggle(_)] _ToggleGreenMove ("Allow Green Rotation", Float) = 0
		[Toggle(_)] _ToggleScreenFollow ("Allow Screen Follow", Float ) = 0
		_HideRedTrans ("Red Transparency", Range(0, 2)) = 1
		_HideGreenTrans ("Green Transparency", Range(0, 2)) = 1
		_HideBlueTrans ("Blue Transparency", Range(0, 2)) = 1

		//rgb zoom
		[Toggle(_)] _ToggleRGBZoom ("Allow RGB Zoom", Float) = 0
		_RedZoom ("Red Zoom", Range(0, 0.8)) = 0.2
		_GreenZoom ("Green Zoom", Range(0, 0.8)) =  0.4
		_BlueZoom ("Blue Zoom", Range(0, 0.8)) = 0.6
		_RGBZoomTrans ("Red Visibility", Range(0, 0.8)) = 0.4
		_RGBZoomTransG ("Green Visibility", Range(0, 0.8)) = 0.4
		_RGBZoomTransB ("Blue Visibility", Range(0, 0.8)) = 0.4

		//ripple
		[Toggle(_)] _ToggleRipple ("Allow Ripple", Float) = 0
		_ShockCenterX ("Ripple Horizontal Center", Range(-1000, 1000)) = 350
		_ShockCenterY ("Ripple Vertical Center", Range(-1000, 1500)) = 350
		_ShockDis ("Shock Distortion",  Range(-100, 100)) = 0
		_ShockSpread ("Shock Spread", Range(0, 1)) = 0
		_ShockMag ("Shock Magnitude", Range(0, 0.5)) = 0

		//rotater
		[Toggle(_)] _ToggleRotater ("Allow Rotation", Float) = 0
		_RotaterValue ("Rotation Degree", Range(-360, 360)) = 0 
		[Toggle(_)] _ToggleRotaterAnimate ("Animate Rotation", Float) = 0 
		_RotaterSpin ("Rotation Speed", Range(0, 25)) = 0

		//pixelate
		[Toggle(_)] _TogglePixelate ("Allow Pixelation", Float) = 0
		_PixelateStrength ("Pixelation X", Range(1000, 15)) = 185
		_PixelateStrengthY ("Pixelation Y", Range(1000, 15)) = 185

		//glitchy pixelate
		[Toggle(_)] _GTogglePixelate ("Allow Pixelation Glitch", Float) = 0
		_GPixelGlitchMap ("Pixelate Glitch Map", 2D) = "white" {}
		_GPixelStrength ("X Pixelation Strength", Range(2000, 40)) = 200
		_GPixelStrengthY ("Y Pixelation Strength", Range(2000, 40)) = 200
		_GPixelFreq ("Pixelation Frequency", Range(1000, 0)) = 250

		//posterize 
		_PosterizeValue ("Posterization", Range(-100, -2)) = -100

		//saturation
		_SaturationValue ("Saturation", Range(-15, 15)) = 1

		//sepia
		_SepiaRStrength ("Sepia", Range(0, 1)) = 0
		_SepiaRWarmth ("Sepia Warmth", Range(-3, 3)) = 1
		_SepiaRTone ("Sepia Tone", Range(-3, 3)) = 1
	
		//scroll
		_ScrollX ("Horizontal Scroll", Range(-2, 2)) = 0
		_ScrollY ("Vertical Scroll", Range(-2, 2)) = 0

		//screenpull
		[Toggle(_)] _ToggleScreenpull ("Allow Screenpull", Float) = 0
		_ScreenpullStrength ("Screenpull Strength", Range(-1,1)) = 0 
		_ScreenpullStrengthTwo ("Screenpull Strength Two", Range(-1, 1)) = 0
		[Enum(XY, 1, Diagonal, 2, Warp, 3, Map, 4)] _ScreenpullMode("Direction", Float) = 1
		_ScreenpullMap ("Screenpull Map", 2D) = "ScreenpullMap" {}

		//screentear
		[Enum(X Tear, 4, Y Tear, 5, X Color, 6, Y Color, 7)]_ApartMode("Apart Mode", Float) = 4
		_Apart ("Apart", Range(0, 1)) = 0
		_ApartColor ("Apart Color", Color) = (0, 0, 0, 1)

		//screen zoom
		[Toggle(_)] _ToggleScreenZoom ("Screen Zoom", Float) = 0
		_ScreenZoomInValue ("Screen Zoom In", Range(0, 1)) = 0
		_ScreenZoomOutValue ("Screen Zoom Out", Range(0, 10)) = 0

		//shake
		[Toggle(_)] _ToggleShake ("Allow Shake", Float) = 0
		[Enum(Smooth, 0, Rough, 1, Noise, 2, Circle, 3, Earfquake, 4, Map, 5)] _ShakeModel ("Shake Model", Float) = 1
		[Enum(XY, 1, Diagonal, 0)] _ToggleXYShake ("Select Axis", Float) = 1
		_ShakeStrength ("Shake Strength", Range(0, 0.5)) = 0
		_ShakeSpeed ("Shake Speed", Range(0, 30)) = 0
		_emptyTex ("Optional Shake Map", 2D) = "EmptyTex" {}
		_ShakeStrength2 ("Shake Strength", Range(0, 0.5)) = 0
		_ShakeSpeed2 ("Shake Speed", Range(0, 30)) = 0

		//smear 
		[Toggle(_)] _ToggleSmear ("Allow Smear", Float) = 0 
		_CSDirection("Direction", Range(-5, 5)) = 0
		[IntRange] _CSCopies ("Smear", Range(1, 32)) = 20
		_CSRed ("Red Smear", Range(-10, 10)) = 0 
		_CSGreen ("Green Smear", Range(-10, 10)) = 0 
		_CSBlue ("Blue Smear", Range(-10, 10)) = 0 
		[Toggle(_)] _CSAutoRotate ("Rotate Smear", Float) = 0
		_CSRotateSpeed ("Rotate Speed", Range(-100, 100)) = 0 
		[Toggle(_)] _CSUseAdvanced ("Use Advanced Options", Float) = 0
		_CSRotateSpeedSinXR ("SinXR Speed", Float) = 0 
		_CSRotateSpeedCosXR ("CosXR Speed", Float) = 0 
		_CSRotateSpeedSinYR ("SinYR Speed", Float) = 0

		//static
		[Toggle(_)] _ToggleNoise ("Allow Static", Float) = 0
		_StaticIntensity ("Static Intensity", Range(0, 1)) = 0
		[Toggle(_)] _ToggleAnimatedNoise ("Animate Static", Float) = 0
		_StaticSpeed ("Static Speed", Range(0, 100)) = 1
		_StaticColor ("Static Color", Color) = (1, 1, 1, 1)
		_StaticBlack ("Use Black Static", Range(0, 1)) = 0
		[Toggle(_)] _ToggleStaticMap ("Use Static Map", Float) = 0
		_StaticMap ("Static Map", 2D) = "white" {}
		_StaticOverlay ("Static Overlay?", Range(0, 1)) = 0
		_StaticSize ("Static Size", Range(-2000, -130)) = -2000

		//silhouette
		_ToggleSilhouette("Allow Silhouette", Range(0, 1)) = 0
		_SilhouetteDepth("Silhouette Depth", Float) = 0
		_SilhouetteBack("Background Color", Color) = (1, 1, 1, 1)
		_SilhouetteFront("Front Color", Color) = (0.85, 0.85, 0.85, 1)
		[Enum(Back, 0, Front, 1)] _SilhouetteRainLayer("Rainbow Layer", Float) = 0
		_SilhouetteRainbow("Rainbow", Range(0, 1)) = 0
		_SilhouetteRainbowSpeed("Rainbow Speed", Range(0, 2)) = 1
		_SilhouetteLighting("Lighting", Range(0, 1)) = 0
		[Enum(Multiply, 0, Overlay, 1)] _SilhouetteLightingMode("Lighting Mode", Float) = 1

		//noise mask
		_ToggleNoiseMask ("Allow Noise Mask", Range(0, 1)) = 0
		_NoiseMask ("Noise Map", 2D) = "Noise" {}
		_NoiseMaskColor ("Mask Color", Color) = (1, 1, 1)
		_NoiseMaskSpeedOne ("Speed One", Range(-0.120, 0.120)) = -0.012
		_NoiseMaskSpeedTwo ("Speed Two", Range(-0.120, 0.120)) = 0.012
		_NoiseMaskScale ("Scale", Range(0.1, 8)) = 1
		_NoiseMaskGlow ("Glow", Range(0.1, 10)) = 1

		//swirl
		[Toggle(_)] _ToggleSwirl ("Allow Swirl", Float) = 0
		_SwirlPower ("Swirl Power", Range(-10, 10)) = 0
		_SwirlCenterX ("Swirl X Center", Range(0, 1)) = 0.5
		_SwirlCenterY ("Swirl Y Center", Range(0, 1)) = 0.5
		_SwirlRadius ("Swirl Radius", Range(0, 1)) = 0.5

		//split
		[Toggle(_)] _ToggleSplice ("Allow Split", Float) = 0
		_SpliceTop ("Top Shift", Range(-1, 1)) = 0
		_SpliceBot ("Bot Shift", Range(-1, 1)) = 0
		_SpliceXLimit ("Horizontal Cut Placement", Range(0, 1)) = 0.5
		_SpliceLeft ("Left Shift", Range(-1, 1)) = 0
		_SpliceRight ("Right Shift", Range(-1, 1)) = 0
		_SpliceYLimit ("Vertical Cut Placement", Range(0, 1)) = 0.5

		//thermal
		_ThermalHeat ("Thermal Heat", Range(2, 35)) = 25
		_ThermalSensitivity ("Thermal Sensitivity", Range(4, 0.75)) = 1.5
		_ThermalTransparency ("Thermal Transparency", Range(0, 1)) = 0
		_ThermalColor ("Thermal Color", Color) = (1, 1, 1, 1)

		//transistion
		[Toggle(_)] _ToggleTransistion ("Allow Transistion", Float) = 0
		_TransX ("Horizontal Transistion", Range(1, -1)) = 0.3
		_TransY ("Vertical Transistion", Range(1, -1)) = -1
		[Toggle(_)] _ToggleDiagTrans ("Allow Diagonal Transistion", Float) = 0
		_TransDL ("Left Diagonal Transistion", Range(-2, 2)) = 0.5
		_TransDR ("Right Diagonal Transition", Range(-2, 2)) = 0.5

		//vhs
		[Toggle(_)] _ToggleVHS ("Allow VHS", Float) = 0
		[Toggle(_)] _ToggleSmoothWave ("Use Smooth Wave", Float) = 0
		_VHSXDisplacement ("Horizontal Displacement", Range(0, 0.1)) = 0
		_VHSYDisplacement ("Vertical Displacement", Range(0, 0.5)) = 0
		_shadowStrength ("Shadow Strength", Range(0.5, 3)) = 2 
		_darkness ("Darkness", Range(10, 0)) = 2
		_waveyness ("Waveyness", Range(0, 2)) = 1

		//vibrance
		_VibrancePower ("Vibrance", Range(-2.5, 2.5)) = 0

		//vignette
		[Toggle(_)] _ToggleVignette ("Toggle Vignette", Float) = 0
		_VigX ("Vignette Power", Range(0, 4.5)) = 0
		[Enum(Soft, 0, Hard, 1)] _VigMode("Color Mode", Float) = 0
		_VigCol ("Vignette Color", Color) = (0, 0, 0, 1)
		_VigColPow ("Color Glow", Range(1, 3)) = 1
		[MaterialToggle] _VigReverse ("Reverse Vignette?", Float) = 0
		_VigSharpness ("Sharpness", Range(1, 15)) = 15

		//warp
		_WarpHorizontal ("Horizontal Warp", Range(0, 3)) = 1
		_WarpVertical ("Vertical Warp", Range(0, 3)) = 1

		//warp zoom
		[Toggle(_)] _ToggleWarpZoom ("Allow Warped Zoom", Float) = 0
		_WarpZoomAmount("Zoom Amount", Range(0, 200)) = 0
		_WarpZoomTolerance("Zoom Tolerance", Range(0, 1)) = 0.5

		//wavey
		[Toggle(_)] _ToggleWavey ("Allow Wavey", Float) = 0
		_WavesX ("X Waves", Range(0, 50)) = 1
		_WavesXPower ("X Power", Range(0, 10)) = 0
		_WavesXSpeed ("X Speed", Range(0, 1.5)) = 0
		_WavesY ("Y Waves", Range(0, 50)) = 1
		_WavesYPower ("Y Power", Range(0, 10)) = 0
		_WavesYSpeed ("Y Speed", Range(0, 1.5)) = 0
		
		//deepfry
		[Toggle(_)] _ToggleDeepfry ("Deepfry?", Float) = 0
		[Enum( None, 4, Fry, 0, Rainbow Puke, 1, Chrome, 2, Seizure, 3)] _DeepfryValue ("Flavor", Float) = 4
		_DeepfryBrightness ("Brightness", Range(0,5)) = 1
		_DeepfryEmbossPower ("Emboss Power", Range(0, 3)) = 0

		//gui settings
		[HideInInspector][Toggle(_)] _hideUnusedFX ("Hide Unused Effects?", Float) = 0

	}



	//|===============================================|
	//|				  subshader 					  |
	//|===============================================|
	SubShader
	{



		//|===============================================|
		//|			render settings  					  |
		//|===============================================|
		//thanks to ???????? for helping me out with screenfreeze!
		Tags
		{ 
			"RenderType" = "Geometry+100000000000000"
			"RenderType" = "Opaque"
			"Queue" = "Geometry+100000000000000"
			"IgnoreProjector" = "True"
			"IsEmissive" = "true"
			"RenderType" = "Overlay+100000000000000"
		}

		Blend Zero One
		Cull Off
		ZWrite on
		ZTest Always
		LOD 1000




		//|===============================================|
		//|				  pass: main					  |
		//|===============================================|
		GrabPass { "_LukaFrontPass" }
		Pass
		{
			Name "LukaSongFrontPass"
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 5.0
			#include "../CGInc/LukaColor.cginc"
			#include "../CGInc/LukaFrontPass.cginc"
			ENDCG
		}



		//|===============================================|
		//|				  pass: rgb    					  |
		//|===============================================|
		GrabPass{ "_LukaBackPass" }
		Pass
		{
			Name "LukaSongBackPass"
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 5.0
			#include "../CGInc/LukaColor.cginc"
			#include "../CGInc/LukaBackPass.cginc"
			ENDCG
		}
	}



	//|===============================================|
	//|				  why r u here?    				  |
	//|===============================================|
	FallBack "Diffuse"
	CustomEditor "LukaSE11"
}



//|===============================================|
//|			  <3 made with love <3 				  |
//|===============================================| 
