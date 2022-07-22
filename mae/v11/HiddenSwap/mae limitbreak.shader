//|===============================================|
//|				  license   					  |
//|===============================================| 
//shader author: luka (lukasong on github, luka#8375 on discord, luka! in vrchat)
//license: this shader is to not be redistrubted or resold in any format and is limited to the buyer exclusively
//version 11.0 (July 30, 2019)
Shader "Hidden/!luka/mae/limitbreak"
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
		_VisBarLeft ("Left Bar Push", Float) = -1.0
		_VisBarRight ("Right Bar Push", Float) = -1.0
		_VisBarColor ("Bar Color", Color) = (0.75, 0.75, 0.75)
		_VisBaseColor ("Base Color", Color) = (0.0, 0.0, 0.0, 1.0)
		_VisBarWidth ("Bar Width", Float) = 0
		_VisBaseWidth ("Base Width", Float) = 0
		[Toggle(_)] _ToggleHSVRainbowVis("Allow Vis Rainbow", Float) = 0
		[Toggle(_)] _ToggleHSVRainbowXVis("Allow Vis Horizontal", Float) = 0
		[Toggle(_)] _ToggleHSVRainbowYVis("Allow Vis Vertical", Float) = 0
		_HSVRainbowHueVis("Hue", Float) = 0.1
		_HSVRainbowSatVis("Saturation", Float) = 1
		_HSVRainbowLightVis("Lightness", Float) = 1
		_HSVRainbowTimeVis("Time", Float) = 0.8
		_VisBarThree ("Bar Three Push", Float) = -1
		_VisBarFour ("Bar Four Push", Float) = -1
		_VisBarFive ("Bar Five Push", Float) = -1
		_VisBarSix ("Bar Six Push", Float) = -1
		_VisBarSeven ("Bar Seven Push", Float) = -1
		_VisBarEight ("Bar Eight Push", Float) = -1
		_VisBarNine ("Bar Nine Push", Float) = -1
		_VisBarTen ("Bar Ten Push", Float) = -1
		_VisStopperColor ("Stopper Color", Color) = (0, 0, 0, 1)
		 _VisCircleSize ("Shape Size", Float) = 40
		_VisClassicBase ("Base Size", Float) = 0.20
		[Enum(Circles, 0, Squares, 1)] _VisClassicShape ("Bar Shape", Float) = 0
		[Toggle(_)] _VisBarRainbow ("Bar Rainbow", Float) = 0
		_VisClassicMaxSize ("Bar Max Size", Float) = 10.0

		//range
		_FalloffRange ("Range", Float) = 20
		[Toggle(_)] _ToggleRenderLookAtMe ("Only Render If Looking", Float) = 0
		_RenderMeTolerance ("Angle Tolerance", Float) = 0.8
		[Enum(UnityEngine.Rendering.CompareFunction)] _ZTest("ZTest", Int) = 8
		_OverallOpacity ("Effects Opacity", Float) = 1
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
		_DepthValue ("Depth Value", Float) = 3.2
		_DepthPlayerTolerance("Player Tolerance", Float) = 0.84
		_DepthPlayerPower ("Focus on Player Strength", Float) = 5

		//screen tear 
		[Toggle(_)] _AllowTearFix ("Tear to Color?", Float) = 0
		_ScreenTearColor ("Screen Tear Color", Color) = (0.4, 0, 0.5, 1) 
		[Toggle(_)] _TearToMirror ("Tear to Mirror?", Float) = 1
		[Toggle(_)] _TearToRepeat ("Tear to Repeat?", Float)  = 0

		//vr
		_VRAdjust("VR Adjust", Float) = 1
		[Toggle(_)] _VRPreview ("Preview VR?", Float) = 0
		[Toggle(_)] _VRLeft ("Close Left Eye?", Float) = 0
		_VRLeftColor ("Left Eye", Color) = (0, 0, 0, 1)
		[Toggle(_)] _VRRight("Close Right Eye?", Float) = 0
		_VRRightColor ("Right Eye", Color) = (0, 0, 0, 1)

		//stretch
		_ToggleScreenFlip ("Screen Flip", Float) = 0
		_ToggleUpsideDown ("Upside Down", Float) = 0

		//coloring
		_SepiaStrength ("B&W Strength", Float) = 0
		_SepiaColor ("B&W Color Mod", Color) = (1, 1, 1, 1)
		[Enum(Invert, 0, FuckyWucky, 1)] _InvertMode ("Invert Mode", Float) = 0
		_InvertStrength("Invert", Float) = 0
		_InvertR ("Invert Red", Float) = 0
		_InvertG ("Invert Blue", Float) = 0
		_InvertB ("Invert Blue", Float) = 0

		//afterimage
		[Toggle(_)] _ToggleAfterimage ("Allow Afterimage", Float) = 0
		_Offset ("First Offset", Float) = 0.023
		_ExtraOffset ("Second Offset", Float) = 0.041
		_offsetthree ("Third Offset", Float) = 0.063

		//ascii
		[Toggle(_)] _ToggleAscii ("Allow ASCII Filter", Float) = 0
		_ASCIIVariation ("Shape Variation", Float) = 2.5
		_ASCIIPower ("Shape Amount", Float) = 3.5
		_ASCIISpeed ("Shape Speed", Float) = 0
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
		_BlinkStrength ("Blink Strength", Float) = 0
		_BlinkColor ("Bars Color", Color)  = (0, 0, 0, 1)
		_BlinkImage("Blink Image", 2D) = "white" {}
		_BlinkImagePower ("Image Visibility", Float) = 0
		_BlinkImageX ("Image X Size", Float) = -2
		_BlinkImageY ("Image Y Size", Float) = -2
		_BlinkImageY ("Image Y Size", Float) = -2
		_BlinkBorderSize ("Border Size", Float) = 0.95
 		_BlinkBorder ("Border Color", Color) = (0, 0, 0, 0)
		_BlinkRainbow ("Allow Rainbow", Float) = 0
		[Toggle(_)] _BlinkRainbowX ("Allow Horizontal", Float) = 0
		[Toggle(_)] _BlinkRainbowY("Allow Vertical", Float) = 0
		_BlinkRainbowHue ("Hue", Float) = 0.1
		_BlinkRainbowSat ("Saturation", Float) = 1
		_BlinkRainbowLight ("Lightness", Float) = 1
		_BlinkRainbowTime ("Time", Float) = 0.8
		[Enum(Base, 0, Border, 1)]_BlinkRainbowMode ("Rainbow Mode", Float) = 0
	
		//blur
		[Toggle(_)] _ToggleNBlur ("Allow Blur", Float) = 0
		[Enum(Simple Blur, 6, Blur, 0, Circle, 1, Plus, 2, Direction, 3, Dual, 4, Dither, 5)] _NBlurShape ("Blur Shape", Float) = 1
		 _NBlurItterations ("Blur Itterations", Float) = 2
		_NBlurPower ("Blur Strength", Float) = 0
		_NBlurSpeed ("Blur Speed", Float) = 0
		_NBlurRotate ("Blur Rotation", Float) = 0
		_NBlurRotateSpeed ("Blur Rotation Speed", Float) = 0
		_NBlurX ("Blur X Center Offset", Float) = 0
		_NBlurY ("Blur Y Center Offset", Float) = 0
		_NBlurColor ("Blur Color", Color) = (1, 1, 1, 1)
		_NBlurGlow ("Blur Glow", Float) = 1
		_NBlurOpacity ("Blur Opacity", Float) = 1

		//exposure
		_BloomGlow ("Bloom Glow", Float) = 1

		//bloom
		[Toggle(_)] _RBloomToggle ("Allow Bloom", Float) = 0       
		_RBloomQuality("Bloom Quality", Float) = 16
		_RBloomStrength("Bloom Strength", Float) = 0
		_RBloomBright("Bloom Brightness", Float) = 1.3
		_RBloomColor("Bloom Color", Color) = (1, 1, 1, 1)
		_RBloomOpacity("Bloom Opacity", Float) = 0.8
		_RBloomDepth("Bloom Depth", Float) = 0

		//bulge
		_ToggleBulge ("Bulge Zoom", Float) = 0
		_BulgeIndent ("Bulge Indent", Float) = 0
		_OwOStrength ("Bulge Warp", Float) = 5

		//zoom
		[Toggle(_)] _ToggleZoom ("Allow Zoom", Float) = 0
		[Toggle(_)] _ToggleFlipZoom ("Flip Zoom", Float) = 0
		[Toggle(_)] _ToggleSmoothZoom ("Smooth Zoom", Float) = 0 
		_ZoomInValue ("Zoom In", Float) = 1
		_ZoomOutValue ("Zoom Out", Float) = 0 
		[Toggle(_)] _SmoothZoom ("Allow Smooth Zoom", Float) = 0
		_SmoothZoomTolerance ("Angle Tolerance", Float) = 0.4  

		//big box zoom
		[Toggle(_)] _ToggleBigZoom ("Allow Big Box Zoom", Float) = 0
		_BigZoomAmount ("Zoom In Amount", Float) = 0
		_BigZoomOutAmount ("Zoom Out Amount", Float) = 0
		_BigZoomTolerance ("Zoom Tolerance", Float) = 0.8

		//coloring
		_ColorHue ("Hue", Float) = 0
		_ColorSaturation ("Saturation", Float) = 0
		_ColorValue ("Value", Float) = 0
		[HDR] _ColorRGB ("RGB Color Droplet", Color) = (1,1,1,1) 
		_SolidTrans ("Solid Color Transparency", Float) = 0
		_SolidCol ("Solid Color", Color) = (0, 0, 1, 1)
		_ColorRGBtoHSV ("RGB to HSV?", Float) = 0
		_ColorHSVtoRGB ("HSV to RGB?", Float) = 0

		//color split
		[Toggle(_)] _ToggleColorSplit ("Allow Color Split", Float) = 0
		_ColorSplitAmount ("Color Split", Float) = 0
		_ColorSplitRGBone ("Left Color", Color) = (1, 1, 1, 1)
		_ColSpONEopacity ("Left Brightness", Float) = 1
		_ColorSplitRGBtwo ("Middle Color", Color) = (1, 1, 1, 1)
		_ColSpTWOopacity ("Middle Brightness", Float) = 1
		_ColorSplitRGBthree ("Right Color", Color) = (1, 1, 1, 1)
		_ColSpTHREEopacity ("Right Brightness", Float) = 1
		[Toggle(_)] _ToggleColorSplitStaySides ("Colors Dont Cross", Float) = 1
		[Toggle(_)] _ToggleAutoanimateColorSplit ("Animate Color Split", Float) = 0
		_ColorSplitSpeed ("Color Split Speed", Float) = 0
		_CSLX ("Left Horizontal Offset", Float) = 0
		_CSLY ("Left Vertical Offset", Float) = 0
		_CSMX ("Middle Horizontal Offset", Float) = 0
		_CSMY ("Middle Vertical Offset", Float) = 0
		_CSRX ("Right Horizontal Offset", Float) = 0
		_CSRY ("Right Vertical Offset", Float) = 0
		 _CSL ("Split Samples", Float) = 16
		_CSRotate("CA Rotate", Float) = 0
		_ColSplRotateSpeed("CA Rotate Speed", Float) = 0
		_CSOffsetX("Colorsplit X Offset", Float) = 0
		_CSOffsetY("Colorsplit Y Offset", Float) = 0
		_CSTrans ("ColorsTransparency", Float) = 1

		//contrast
		_ContrastValue ("Contrast", Float) = 1

		//color spin
		_ToggleCC ("Allow Corner Spin", Float) = 0
		[Enum(Equals, 0, Multiply, 1, Overlay, 2)] _CCApply ("Apply Method", Float) = 0
		_CCOne ("Color One", Color) = (1, 0, 0, 1)
		_CCTwo ("Color Two", Color) = (0, 1, 0, 1)
		_CCThree ("Color Three", Color) = (0, 0, 1, 1)
		_CCFour ("Color Four", Color) = (1, 0, 1, 1)
		_CCRotate ("Color Rotation", Float) = 0
		_CCSpeed ("Rotation Speed", Float) = 0

		//Corner colors
		_CornerOneColor ("Left Bottom Color", Color) = (1, 1, 1, 1)
		_CornerTwoColor ("Left Top Color", Color) = (1, 1, 1 ,1)
		_CornerThreeColor ("Right Bottom Color", Color) = (1, 1, 1, 1)
		_CornerFourColor ("Right Top Color", Color) = (1, 1, 1, 1)
		_CornerOneTrans ("Left Bottom Transparency", Float) = 0
		_CornerTwoTrans ("Left Top Transparency", Float) = 0
		_CornerThreeTrans ("Right Bottom Transparency", Float) = 0
		_CornerFourTrans ("Right Top Transparency", Float) = 0

		//color gradient
		_GradTrans ("Gradient Transparency", Float) = 0
		[Enum(Horizontal, 0, Vertical, 1)] _GradMode ("Gradient Path", Float) = 0
		[Enum(Overlay, 0, Multiply, 1)] _GradApply ("Gradient Apply", Float) = 1
		_GradOne ("Gradient Color One", Color) = (0.8, 0, 0.4, 0)
		_GradTwo ("Gradient Color Two", Color) = (0.2, 0, 0.9, 0)

		//darken
		_DarknessStrength ("Darkness", Float) = 0

		//distortion
		[Toggle(_)] _ToggleDistortion ("Allow Distortion", Float) = 0
		_DistortionMap ("Distortion Map", 2D) = "white" {}
		_DistortionX ("X Power", Float) = 0
		_DistortionY ("Y Power", Float) = 0
		_DistortionXSpeed ("X Speed", Float) = 0
		_DistortionYSpeed ("Y Speed", Float) = 0
		_DistortionRotate ("Rotation Power", Float) = 0
		_DistortionRotateSpeed ("Rotation Speed", Float) = 0
		_DistortionTransparency ("Transparency", Float) = 1

		//dizzy
		[Toggle(_)] _ToggleDizzyEffect ("Allow Dizzy", Float) = 0 
		[Enum(Dizzy,1,Slide,3,Blink,4)] _DizzyMode ("Dizzy Mode", Float) = 1
		_DizzyAmountValue ("Dizzy Speed", Float) = 25
		_DizzyRotationSpeed ("Dizzy Strength", Float) = 20

		//droplet
		[Toggle(_)] _ToggleDroplet ("Allow Droplet", Float) = 0 
		[Toggle(_)] _ToggleUseHSVInstead ("Use HSV Instead (If off uses RGB) (Falloff only on HSV)", Float) = 1
		_ToggleDropletSepia ("Allow Black and White Background", Float) = 0
		_DropletColOne ("Old Color", Color) = (0, 0, 0, 0)
		_DropletColTwo ("New Color", Color) = (0, 0, 0, 0)
		_DropletTolerance ("Tolerance", Float) = 0.01
		_DropletIntensity ("Intensity", Float) = 1
		[Toggle(_)] _ToggleDropletTwo ("Allow Second Color", Float) = 0 
		_TwoDropletColOne ("Old Color", Color) = (0, 0, 0, 0)
		_TwoDropletColTwo ("New Color", Color) = (0, 0, 0, 0)
		_TwoDropletTolerance ("Tolerance", Float) = 0.01
		_TwoDropletIntensity ("Intensity", Float) = 1
		[Toggle(_)] _ToggleDropletThree ("Allow Third Color", Float) = 0 
		_ThreeDropletColOne ("Old Color", Color) = (0, 0, 0, 0)
		_ThreeDropletColTwo ("New Color", Color) = (0, 0, 0, 0)
		_ThreeDropletTolerance ("Tolerance", Float) = 0.01
		_ThreeDropletIntensity ("Intensity", Float) = 1
		[Toggle(_)] _ToggleDropletFourth("Allow Fourth Color", Float) = 0
		_FourDropletColOne("Old Color", Color) = (0, 0, 0, 0)
		_FourDropletColTwo("New Color", Color) = (0, 0, 0, 0)
		_FourDropletTolerance("Tolerance", Float) = 0.01
		_FourDropletIntensity("Intensity", Float) = 1

		//duotone
		_ToggleDuotone ("Allow Duotone", Float) = 0
		_DuotoneHardness ("Hardness", Float) = 0.01
		_DuotoneThreshold ("Threshold", Float) = 0.25
		_DuotoneColOne ("Old Color", Color) =  (0, 0, 0, 1)
		_DuotoneColTwo ("New Color", Color) = (1, 1, 1, 1)

		//earthquake
		[Toggle(_)] _SSAllowVerticalShake ("Vertical Shake", Float) = 0 //ss means split shake lol
		[Toggle(_)] _SSAllowHorizontalShake ("Horizontal Shake", Float) = 0
		[Toggle(_)] _SSAllowVerticalBlur ("Vertical Motion Blur", Float) = 0
		[Toggle(_)] _SSAllowHorizontalBlur ("Horizontal Motion Blur", Float) = 0
		_SSValue ("Horizontal Shakiness", Float) = 0.0226
		_SSSpeed ("Horizontal Speed", Float) = 6.24
		_SSValueVert ("Vertical Shakiness", Float) = 0.0272
		_SSSpeedVert ("Vertical Speed", Float) = 3.14
		_SSTransparency ("Blur Transparency", Float) = 1

		//edge detect
		[Toggle(_)] _ToggleED("Allow Outline", Float) = 0
		_EDColor("Outline Color", Color) = (1, 1, 1, 1)
		_EDTolerance("Outline Tolerance", Float) = 0.2
		_EDGlow("Outline Glow", Float) = 1
		_EDTrans("Outline Transparency", Float) = 1
		_EDXOffset("Horizontal Offset", Float) = 0
		_EDYOffset("Vertical Offset", Float) = 0
		_EDWidth ("Outline Width", Float) = 1
		_EDBW ("B&W Screen?", Float) = 0
		_EDToggleRainbow ("Allow Rainbow", Float) = 0
		[Toggle(_)] _EDToggleHSVRainbowX("Allow Horizontal", Float) = 0
		[Toggle(_)] _EDToggleHSVRainbowY("Allow Vertical", Float) = 0
		_EDHSVRainbowHue("Hue", Float) = 0.698
		_EDHSVRainbowSat("Saturation", Float) = 0.97	
		_EDHSVRainbowLight("Lightness", Float) = 1.06
		_EDHSVRainbowTime("Time", Float) = 0.89
		_EDBackPower ("Background Strength", Float) = 0
		_EDBackColor ("Background Color", Color) = (0, 0, 0, 1)
		[Toggle(_)] _EDRampAllow ("Allow Gradient Outline", Float) = 0
		_EDRampMap("Color Map", 2D) = "colorramp" {}
		_EDRampX ("Horizontal Size", Float) = 1
		_EDRampY ("Vertical Size", Float) = 1
		_EDRampSX ("Horizontal Scroll", Float) = 0
		_EDRampSY ("Vertical Scroll", Float) = 0
		[Toggle(_)] _EDRampScroll ("Autoscroll?", Float) = 1
		_EDDither ("Dither", Float) = 0
		_EDDitherSpeed ("Dither Speed", Float) = 0

		//edge smear
		[Toggle(_)] _ToggleEdgeDistort ("Allow Edge Distort", Float) = 0
		_EdgeDisX ("Horizontal Distort", Float) = 0.1
		_EdgeDisY ("Vertical Distort", Float) = 0.1
		[Toggle(_)] _ToggleEdgeDisRotate ("Allow Rotation", Float) = 1
		_EdgeDisRotStr ("Rotation Strength", Float) = 4.18
		_EdgeDisRotSpeed ("Rotation Speed", Float) = 0.93

		//fade
		[Toggle(_)] _ToggleFadeProjection("Allow Fade Projection", Float) = 0
		[Enum(Front, 0, Back, 1)] _FadeLayer ("Projection Layer:", Float) = 0
		_FPZoom ("Zoom Amount", Float) = 0.35
		_FPFade ("Fade Amount", Float) = 0.4
		_FPColor ("Projection Color", Color) = (1, 1, 1, 1)

		//filter
		[Toggle(_)] _ToggleFilter ("Allow Filter", Float) = 0 
		[Toggle(_)] _ToggleHSVFilterDisableLock ("Use HSV (Disabled, Broken)", Float) = 0
		[Toggle(_)] _ToggleAdvancedFilter ("Use Advanced Options", Float) = 0
		[Toggle(_)] _ToggleColoredFilter ("Allow Colored Background", Float) = 0
		_FilterColor ("Filtered Colored", Color) = (0, 0, 0, 0)
		_FilterTolerance ("Filter Tolerance", Float) = 0.1
		_FilterMinR ("[Advanced] Filter Red Min", Float) = 0.1 
		_FilterMaxR ("[Advanced] Filter Red Max", Float) = 0.1
		_FilterMinG ("[Advanced] Filter Green Min", Float) = 0.1 
		_FilterMaxG ("[Advanced] Filter Green Max", Float) = 0.1
		_FilterMinB ("[Advanced] Filter Blue Min", Float) = 0.1 
		_FilterMaxB ("[Advanced] Filter Blue Max", Float) = 0.1
		_FilterIntensity ("Color Strength", Float) = 1
		_BackgroundFilterIntensity ("Background Color Strength", Float) = 0.5
		_BackgroundFilterColor ("Background Color", Color) = (0, 0, 0, 0)

		//film
		_FilmPower ("Film Strength", Float) = 0
		[Toggle(_)] _FilmAllowLines ("Allow Lines?", Float) = 1
		[Toggle(_)] _FilmAllowSpots ("Allow Spots?", Float) = 1
		[Toggle(_)] _FilmAllowStripes ("Allow Stripes?", Float) = 1
		_FilmItterations ("Film Update Rate", Float) = 10
		_FilmBrightness ("Film Brightness", Float) = 0.1
		_FilmJitterAmount ("Jitter Strength", Float) = 0.004
		_FilmSpotStrength ("Spot Size", Float) = 1
		_FilmLinesOften ("Line Frequency", Float) = 0
		_FilmSpotsOften ("Spot Frequency", Float) = 5
		_FilmStripesOften ("Stripes Frequency", Float) = 1
		[Toggle(_)]_ToggleReel ("Film Reel?", Float) = 0
		[Enum(Vertical, 0, Horizontal, 1, Scroll, 2, Peak, 3, Diamond, 4)] _ReelMode ("Reel Direction", Float) = 0
		_ReelSpeed ("Reel Speed", Float) = 1
		_ReelColor ("Reel Color", Color) = (0, 0, 0, 1)
		_ReelBars ("Bar Thickness", Float) = 0
		_ReelBarHeigth ("Bar Heigth", Float) = 0
		_ReelWidth ("Reel Width", Float) = 0
		_ReelJitter ("Reel Jitter", Float) = 0
		 _ReelBarAmounts ("Reel Number Bars", Float) = 10
		_ReelRainbow ("Rainbow Reel?", Float) = 0
		[Toggle(_)] _ReelRainbowX ("Rainbow X?", Float) = 0
		[Toggle(_)] _ReelRainbowY ("Rainbow Y?", Float) = 0

		//fog
		_ToggleFog ("Allow Fog", Float) = 0
		[Enum(Front,0,Back,1)] _FogLayer ("Fog Layer:", Float) = 0
		_FogDensity ("Fog Density", Float) = 0
		_FogColor ("Fog Color", Color) = (1, 1, 1, 1)
		_FogRainbow ("Fog Rainbow", Float) = 0
		_FogRainbowSpeed ("Fog Rainbow Speed", Float) = 0.1
		_FogSafe("Fog Safe Zone", Float) = 0 
		_FogSafeTol("Safe Zone Tolerance", Float) = 0

		//gamma
		_GammaRed ("Red Gamma", Float) = 0
		_GammaGreen ("Green Gamma", Float) = 0
		_GammaBlue ("Gamma Blue", Float) = 0

		//girlscam
		[Toggle(_)] _ToggleGirlscam ("Allow Girlscam", Float) = 0
		[Enum(Horizontal, 0, Vertical, 1)] _GirlscamDir ("Direction", Float) = 0
		_GirlscamStrength ("Strength", Float) = 0
		_GirlscamTime ("Speed", Float) = 0

		//manual glitch
		[Toggle(_)] _ToggleGlitch ("Allow CRT Glitch", Float) = 0
		_GlitchRedMap ("Glitch Map", 2D) = "white" {}
		_GlitchRedDistort ("Glitch Strength", Float) = 0
		_RedYGlitch ("Y Glitch", Float) = 10
		_RedXGlitch ("X Glitch", Float) = 0.35
		_RedTileGlitch ("Tile Glitch", Float) = 1
		[Toggle(_)] _ToggleRandomGlitch ("Animate Glitch [Beta, Mostly Testing]", Float) = 0
		[Toggle(_)] _ToggleRandomSideGlitch ("Randomize Direction", Float) = 0
		_XGAnimate ("X Animate", Float) = 0.35
		_YGAnimate ("Y Animate", Float) = 0 
		_TileGAnimate ("Tile Animate", Float) = 0
		_GlitchSideFactor ("Direction Randomize", Float) = 0
		[Toggle(_)] _ToggleGlitchChromatic ("Allow Glitch RGB", Float) = 0
		_GlitchRGBStrength ("Glitch RGB Strength", Float) = 0
		_GlitchRGBSpeed ("Glitch RGB Speed", Float) = 0
		_GlitchRGB ("Glitch RGB Randomness", Float) = 0

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
		_RedBlocks ("Red Block Offset", Float) = 0
		_GreenBlocks ("Green Block Offset", Float) = 0
		_BlueBlocks ("Blue Block Offset", Float) = 0
		_RedBlockCount ("Red Blocks", Float) = 0
		_GreenBlockCount ("Green Blocks", Float) = 0
		_BlueBlockCount ("Blue Blocks", Float) = 0
		_RedBlockSpeed ("Red Block Speed", Float) = 0
		_GreenBlockSpeed ("Green Block Speed",  Float) = 0
		_BlueBlockSpeed ("Blue Block Speed",  Float) = 0
		_RGBGlitchTrans ("RGB Glitch Transparency", Float) = 1

		//blocky glitch
		[Toggle(_)] _ToggleBlockyGlitch("Allow Blocky Glitch", Float) = 0
		_BlockGlitchMap("Block Glitch Map", 2D) = "white" {}
		[Toggle(_)] _AllowBGX("Allow Horizontal Glitch", Float) = 1
		[Toggle(_)] _AllowBGY("Allow Vertical Glitch", Float) = 0
		_BlockyGlitchStrength("Strength", Float) = 0.5
		_BlockyGlitchSpeed ("Speed", Float) = 1.2
		_BDepthX ("Horizontal Depth", Float) = 25.0
		_BDepthY ("Vertical Depth", Float) = 111.0
		_BGRandomnessInc("Randomness Amount", Float) = 0
		[Toggle(_)] _ToggleBlockyRGB("Allow Blocky RGB", Float) = 1
		_BlockyRGBPush("RGB Strength", Float) = 0.3
		_BlockyRGBSpeed("RGB Speed", Float) = 3.7
		[Toggle(_)] _AllowBGColors("Allow Broken Colors", Float) = 1
		_BGOverlayColor ("Overlay Color", Color) = (0.1, 0.1, 0.1, 1)
		_BGOverlayIntensity ("Color Overlay Intensity", Float) = 0.01
		_BGBrokenColorIntensity ("Broken Color Intensity", Float) = 0.1
		_BGBrokenRandom ("Broken Color Randomize", Float) = 0.5
		_BGOverlayToggle ("Toggle Broken Colors", Float) = 0
		_BGOverlayMap("Degrading Map", 2D) = "white" {}

		//scanline Glitch
		[Toggle(_)] _ToggleScanline ("Allow Scanline", Float) = 0
		[Enum(Vertical, 0, Horizontal, 1)] _ScanlineDir ("Scanline Direction", Float) = 0
		_ScanlinePush("Scanline Push", Float) = 0.1
		_ScanlineSize("Scanline Size", Float) = 0
		_ScanlineSpeed("Scanline Speed", Float) = 0.3

		//inception
		_ToggleInception ("Allow Inception", Float) = 0
		[Enum(Both, 0, Front, 1, Back, 2)] _InceptionItterations ("FX Layer:", Float) = 1
		_InceptionSize ("Copy Size",  Float) = -1
		_InceptionShiftX ("X Shift", Float) = 0
		_InceptionShiftY ("Y Shift", Float) = 0

		//mirror
		[Toggle(_)] _ToggleMirror ("Allow Mirror", Float) = 0
		[Toggle(_)] _MirrorHU ("Horizontal Under Mirror?", Float) = 0
		[Toggle(_)] _MirrorHO("Horizontal Over Mirror?", Float) = 0
		[Toggle(_)] _MirrorVU("Vertical Under Mirror?", Float) = 0
		[Toggle(_)] _MirrorVO("Vertical Over Mirror?", Float) = 0

		//screens
		_ToggleScreens ("Allow Screens?", Float) = 0
		_ScreensXRow ("Horizontal Amount of Screens", Float) = -1

		//overlay
		[Toggle(_)] _ToggleOverlay ("Allow Overlay", Float) = 0
		[Toggle(_)] _ToggleTransparentImage ("Transparent Image?", Float) = 0
		[Toggle(_)] _UseSepOverlay ("Use Different Image for VR", Float) = 0
		_OverlayTexture ("Overlay Texture", 2D) = "OverlayTexture" {}
		_VROverlayTexture ("VR Overlay Texture", 2D) = "VROverlayTexture" {}
		_OverlayTransparency ("Transparency", Float) = 1
		_OverlayYAdjust("Height", Float) = 0.75
		_OverlayXAdjust("Width", Float) = 0.75
		_OverlayTiling("Tiling", Float) = -0.5
		_OverlayXShift("X Shift", Float) = 0
		_OverlayYShift("Y Shift", Float) = 0
		[Toggle(_)] _OverlayTrans ("Allow Transistion", Float) = 0
		_OverlayTransX ("Horizontal Transistion", Float) = 0
		_OverlayTransY ("Vertical Transistion", Float) = 0
		[Toggle(_)] _ToggleOverlayTwo("Allow Second Overlay", Float) = 0
		[Toggle(_)] _ToggleTransparentImageTwo ("Transparent Image?", Float) = 0
		_OverlayTextureTwo("Second Overlay Texture", 2D) = "OverlayTexture" {}
		_OverlayTransparencyTwo("Second Transparency", Float) = 1
		_OverlayYAdjustTwo("Second Height", Float) = 0.75
		_OverlayXAdjustTwo("Second Width", Float) = 0.75
		_OverlayTilingTwo("Second Tiling", Float) = -0.5
		_OverlayXShiftTwo("Second X Shift", Float) = 0
		_OverlayYShiftTwo("Second Y Shift", Float) = 0
		[Toggle(_)] _OverlayTransTwo("Allow Transistion", Float) = 0
		_OverlayTransXTwo("Horizontal Transistion", Float) = 0
		_OverlayTransYTwo("Vertical Transistion", Float) = 0
		[Toggle(_)] _ToggleOverlayThree("Allow Third Overlay", Float) = 0
		[Toggle(_)] _ToggleTransparentImageThree ("Transparent Image?", Float) = 0
		_OverlayTextureThree("Third Overlay Texture", 2D) = "OverlayTexture" {}
		_OverlayTransparencyThree("Third Transparency", Float) = 1
		_OverlayYAdjustThree("Third Height", Float) = 0.75
		_OverlayXAdjustThree("Third Width", Float) = 0.75
		_OverlayTilingThree("Third Tiling", Float) = -0.5
		_OverlayXShiftThree("Third X Shift", Float) = 0
		_OverlayYShiftThree("Third Y Shift", Float) = 0
		[Toggle(_)] _OverlayTransThree("Allow Transistion", Float) = 0
		_OverlayTransXThree("Horizontal Transistion", Float) = 0
		_OverlayTransYThree("Vertical Transistion", Float) = 0
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
		_GifTransparency ("Transparency", Float) = 1
		_GifYAdjust("Height", Float) = 0.75
		_GifXAdjust("Width", Float) = 0.75
		_GifTiling("Tiling", Float) = -0.5
		_GifXShift("X Shift", Float) = 0
		_GifYShift("Y Shift", Float) = 0

		//linocut
		_LinocutPower ("Linocut Power", Float) = 1
		_LinocutOpacity ("Linocut Opacity", Float) = 0
		_LinocutColor ("Linocut Color", Color) = (1, 1, 1, 1)

		//neon outline
		_ToggleOutline ("Allow Outline", Float) = 0
		_OutlineSepiaAmount ("Desaturatation Amount", Float) = 0
		_OutlineOffset ("Outline Coverage", Float) = 0.0043
		_OutlineActualOffset ("Outline Offset", Float) = 0.00505
		_OutlineModOne ("Outline Darkness", Float) = 1
		_OutlineModTwo ("Outline Value One", Float) = 0.5
		_OutlineModThree ("Outline Value Two", Float) = 1 
		_OutlineModFour ("Outline Value Three", Float) = 3

		//radial
		[Toggle(_)] _ToggleRadialBlur ("Allow Radial Blur", Float) = 0 
		_RadialBlurDistance ("Blur Strentgh", Float) = 0
		//_RadialBlurCenterRadius ("Center Radius", Float) = 0.27
		_RadialBlurVerticalCenter ("Center (Vertical Axis)", Float) = 0.5 
		_RadialBlurHorizontalCenter ("Center (Horizontal Axis)", Float) = 0.5 
		[Toggle(_)] _RBToggleED("Allow Outline", Float) = 0
		_RBEDColor("Radial Outline Color", Color) = (1, 1, 1, 1)
		_RBEDTolerance("Radial Outline Tolerance", Float) = 0.2
		_RBEDTrans("Radial Outline Transparency", Float) = 1
		_RBEDWidth("Radial Outline Width", Float) = 1
		_RBEDBW("Radial B&W Screen?", Float) = 0
		_RBEDToggleRainbow("Radial Allow Rainbow", Float) = 0
		[Toggle(_)] _RBEDToggleHSVRainbowX("Radial Allow Horizontal", Float) = 0
		[Toggle(_)] _RBEDToggleHSVRainbowY("Radial Allow Vertical", Float) = 0
		_RBEDHSVRainbowHue("Radial Hue", Float) = 0.698
		_RBEDHSVRainbowSat("Radial Saturation", Float) = 0.97
		_RBEDHSVRainbowLight("Radial Lightness", Float) = 1.06
		_RBEDHSVRainbowTime("Radial Time", Float) = 0.89
		_RBEDBackPower("Radial Background Strength", Float) = 0
		_RBEDBackColor("Radial Background Color", Color) = (0, 0, 0, 1)
		_RBDither ("Radial Dither", Float) = 0
		_RBDitherSpeed ("Radial Dither Speed", Float) = 0
		_RBToggleRainbow("Radial Allow Rainbow", Float) = 0
		[Toggle(_)] _RBToggleHSVRainbowX("Radial Allow Horizontal", Float) = 0
		[Toggle(_)] _RBToggleHSVRainbowY("Radial Allow Vertical", Float) = 0
		_RBHSVRainbowHue("Radial Hue", Float) = 0.698
		_RBHSVRainbowSat("Radial Saturation", Float) = 0.97
		_RBHSVRainbowLight("Radial Lightness", Float) = 1.06
		_RBHSVRainbowTime("Radial Time", Float) = 0.89
		_RBRotate ("Radial Rotate", Float) = 0
		_RBRotateSpeed ("Radial Rotation Speed", Float) = 0
		_RBCAOffset ("Radial RGB Offset", Float) = 0
		_RBCATrans ("Radial RGB Transparency", Float) = 1
		_RBEmpower ("Radial Power over Itteration", Float) = 0.01
		[Enum(Radial Zoom, 3, Radial, 0, Projection, 1, Rotation, 2)]_RBMode ("Radial Projection Mode", Float) = 3
		 _RBItterations("Radial Blur Itterations", Float) = 16
		[Enum(OFF, 0, ON, 1)] _RBEDOnly ("Outli ne Only?", Float ) = 0
		_RBEDBalance ("Radial Balance Lighting", Float) = 1
		_RBGrainPower ("Radial Grain Power", Float) = 0
		_RBGrainSpeed ("Radial Grain Speed", Float) = 0
		_RBGrainColor ("Radial Grain Color", Color) = (1, 1, 1, 1)
		_RBGrainBlack ("Radial Black Grain?", Float) = 0

		//rainbow
		_ToggleHSVRainbow("Allow Rainbow", Float) = 0
		[Toggle(_)] _ToggleHSVRainbowX("Allow Horizontal", Float) = 0
		[Toggle(_)] _ToggleHSVRainbowY("Allow Vertical", Float) = 0
		_HSVRainbowHue("Hue", Float) = 0.1
		_HSVRainbowSat("Saturation", Float) = 1
		_HSVRainbowLight("Lightness", Float) = 1
		_HSVRainbowTime("Time", Float) = 0.8

		//ramp
		_ToggleRampEffect ("Ramp Transparency", Float) = 0
		[Enum(Red, 0, Green, 1, Blue, 2)] _RampColorChannel ("Ramp Color Channel", Float) = 0
		_RampMap ("Ramp Map One", 2D) = "white" {}
		_RampOneLighting ("Ramp Lighting", Float) = 4
		_RampOneDepth ("Ramp One Depth", Float) = 1
		_RampOneStrength ("Ramp One Value", Float) = 1
		[Toggle(_)] _ToggleRampOneAnimate ("Autoanimate Ramp One", Float) = 1 
		_RampOneSpeed ("Ramp One Speed", Float) = 0 

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
		 _CASamples ("CA Samples", Float) = 16
		_CATrans ("CA Transparency", Float) = 1
		_RedXValue ("Red Horizontal Offset", Float) = 0.01
		_RedYValue ("Red Vertical Offset", Float) = 0
		_GreenXValue ("Green Horizontal Offset", Float) = 0
		_GreenYValue ("Green Vertical Offset", Float) = 0
		_BlueXValue ("Blue Horizontal Offset", Float) = 0.01
		_BlueYValue ("Blue Vertical Offset", Float) = 0
		[Toggle(_)] _ToggleAutoanimate ("Animate RGB?", Float ) = 0
		_RGBAutoanimateSpeed ("Animate Speed", Float) = 0
		_CARotate ("CA Rotate", Float) = 0
		_CARotateSpeed ("CA Rotate Speed", Float) = 0
		_CAOffsetX ("CA X Offset", Float) = 0
		_CAOffsetY ("CA Y Offset", Float) = 0
		[Space(10)] 
		_RotationStrength ("Rotation Strength", Float) = 0
		_RotationSpeedRed ("Rotation Speed for the Red", Float) = 30.0
		_RotationSpeedBlue ("Rotation Speed for the Blue", Float) = -30.0
		_DirectionRed ("Rotation Direction for the Red", Float) = -1.0
		_DirectionBlue ("Rotation Direction for the Blue", Float) = 1.0
		_RotationSpeedGreen("Rotation Speed for the Green", Float) = 30.0
		_DirectionGreen("Rotation Direction for the Green", Float) = 1.0
		[Toggle(_)] _ToggleGreenMove ("Allow Green Rotation", Float) = 0
		[Toggle(_)] _ToggleScreenFollow ("Allow Screen Follow", Float ) = 0
		_HideRedTrans ("Red Transparency", Float) = 1
		_HideGreenTrans ("Green Transparency", Float) = 1
		_HideBlueTrans ("Blue Transparency", Float) = 1

		//rgb zoom
		[Toggle(_)] _ToggleRGBZoom ("Allow RGB Zoom", Float) = 0
		_RedZoom ("Red Zoom", Float) = 0.2
		_GreenZoom ("Green Zoom", Float) =  0.4
		_BlueZoom ("Blue Zoom", Float) = 0.6
		_RGBZoomTrans ("Red Visibility", Float) = 0.4
		_RGBZoomTransG ("Green Visibility", Float) = 0.4
		_RGBZoomTransB ("Blue Visibility", Float) = 0.4

		//ripple
		[Toggle(_)] _ToggleRipple ("Allow Ripple", Float) = 0
		_ShockCenterX ("Ripple Horizontal Center", Float) = 350
		_ShockCenterY ("Ripple Vertical Center", Float) = 350
		_ShockDis ("Shock Distortion",  Float) = 0
		_ShockSpread ("Shock Spread", Float) = 0
		_ShockMag ("Shock Magnitude", Float) = 0

		//rotater
		[Toggle(_)] _ToggleRotater ("Allow Rotation", Float) = 0
		_RotaterValue ("Rotation Degree", Float) = 0 
		[Toggle(_)] _ToggleRotaterAnimate ("Animate Rotation", Float) = 0 
		_RotaterSpin ("Rotation Speed", Float) = 0

		//pixelate
		[Toggle(_)] _TogglePixelate ("Allow Pixelation", Float) = 0
		_PixelateStrength ("Pixelation X", Float) = 185
		_PixelateStrengthY ("Pixelation Y", Float) = 185

		//glitchy pixelate
		[Toggle(_)] _GTogglePixelate ("Allow Pixelation Glitch", Float) = 0
		_GPixelGlitchMap ("Pixelate Glitch Map", 2D) = "white" {}
		_GPixelStrength ("X Pixelation Strength", Float) = 200
		_GPixelStrengthY ("Y Pixelation Strength", Float) = 200
		_GPixelFreq ("Pixelation Frequency", Float) = 250

		//posterize 
		_PosterizeValue ("Posterization", Float) = -100

		//saturation
		_SaturationValue ("Saturation", Float) = 1

		//sepia
		_SepiaRStrength ("Sepia", Float) = 0
		_SepiaRWarmth ("Sepia Warmth", Float) = 1
		_SepiaRTone ("Sepia Tone", Float) = 1
	
		//scroll
		_ScrollX ("Horizontal Scroll", Float) = 0
		_ScrollY ("Vertical Scroll", Float) = 0

		//screenpull
		[Toggle(_)] _ToggleScreenpull ("Allow Screenpull", Float) = 0
		_ScreenpullStrength ("Screenpull Strength", Float) = 0 
		_ScreenpullStrengthTwo ("Screenpull Strength Two", Float) = 0
		[Enum(XY, 1, Diagonal, 2, Warp, 3, Map, 4)] _ScreenpullMode("Direction", Float) = 1
		_ScreenpullMap ("Screenpull Map", 2D) = "ScreenpullMap" {}

		//screentear
		[Enum(X Tear, 4, Y Tear, 5, X Color, 6, Y Color, 7)]_ApartMode("Apart Mode", Float) = 4
		_Apart ("Apart", Float) = 0
		_ApartColor ("Apart Color", Color) = (0, 0, 0, 1)

		//screen zoom
		[Toggle(_)] _ToggleScreenZoom ("Screen Zoom", Float) = 0
		_ScreenZoomInValue ("Screen Zoom In", Float) = 0
		_ScreenZoomOutValue ("Screen Zoom Out", Float) = 0

		//shake
		[Toggle(_)] _ToggleShake ("Allow Shake", Float) = 0
		[Enum(Smooth, 0, Rough, 1, Noise, 2, Circle, 3, Earfquake, 4, Map, 5)] _ShakeModel ("Shake Model", Float) = 1
		[Enum(XY, 1, Diagonal, 0)] _ToggleXYShake ("Select Axis", Float) = 1
		_ShakeStrength ("Shake Strength", Float) = 0
		_ShakeSpeed ("Shake Speed", Float) = 0
		_emptyTex ("Optional Shake Map", 2D) = "EmptyTex" {}
		_ShakeStrength2 ("Shake Strength", Float) = 0
		_ShakeSpeed2 ("Shake Speed", Float) = 0

		//smear 
		[Toggle(_)] _ToggleSmear ("Allow Smear", Float) = 0 
		_CSDirection("Direction", Float) = 0
		 _CSCopies ("Smear", Float) = 20
		_CSRed ("Red Smear", Float) = 0 
		_CSGreen ("Green Smear", Float) = 0 
		_CSBlue ("Blue Smear", Float) = 0 
		[Toggle(_)] _CSAutoRotate ("Rotate Smear", Float) = 0
		_CSRotateSpeed ("Rotate Speed", Float) = 0 
		[Toggle(_)] _CSUseAdvanced ("Use Advanced Options", Float) = 0
		_CSRotateSpeedSinXR ("SinXR Speed", Float) = 0 
		_CSRotateSpeedCosXR ("CosXR Speed", Float) = 0 
		_CSRotateSpeedSinYR ("SinYR Speed", Float) = 0

		//static
		[Toggle(_)] _ToggleNoise ("Allow Static", Float) = 0
		_StaticIntensity ("Static Intensity", Float) = 0
		[Toggle(_)] _ToggleAnimatedNoise ("Animate Static", Float) = 0
		_StaticSpeed ("Static Speed", Float) = 1
		_StaticColor ("Static Color", Color) = (1, 1, 1, 1)
		_StaticBlack ("Use Black Static", Float) = 0
		[Toggle(_)] _ToggleStaticMap ("Use Static Map", Float) = 0
		_StaticMap ("Static Map", 2D) = "white" {}
		_StaticOverlay ("Static Overlay?", Float) = 0
		_StaticSize ("Static Size", Float) = -2000

		//noise mask
		_ToggleNoiseMask ("Allow Noise Mask", Float) = 0
		_NoiseMask ("Noise Map", 2D) = "Noise" {}
		_NoiseMaskColor ("Mask Color", Color) = (1, 1, 1)
		_NoiseMaskSpeedOne ("Speed One", Float) = -0.012
		_NoiseMaskSpeedTwo ("Speed Two", Float) = 0.012
		_NoiseMaskScale ("Scale", Float) = 1
		_NoiseMaskGlow ("Glow", Float) = 1

		//swirl
		[Toggle(_)] _ToggleSwirl ("Allow Swirl", Float) = 0
		_SwirlPower ("Swirl Power", Float) = 0
		_SwirlCenterX ("Swirl X Center", Float) = 0.5
		_SwirlCenterY ("Swirl Y Center", Float) = 0.5
		_SwirlRadius ("Swirl Radius", Float) = 0.5

		//split
		[Toggle(_)] _ToggleSplice ("Allow Split", Float) = 0
		_SpliceTop ("Top Shift", Float) = 0
		_SpliceBot ("Bot Shift", Float) = 0
		_SpliceXLimit ("Horizontal Cut Placement", Float) = 0.5
		_SpliceLeft ("Left Shift", Float) = 0
		_SpliceRight ("Right Shift", Float) = 0
		_SpliceYLimit ("Vertical Cut Placement", Float) = 0.5
			 
		//silhouette
		_ToggleSilhouette("Allow Silhouette", Float) = 0
		_SilhouetteDepth("Silhouette Depth", Float) = 0
		_SilhouetteBack("Background Color", Color) = (1, 1, 1, 1)
		_SilhouetteFront("Front Color", Color) = (0.85, 0.85, 0.85, 1)
		[Enum(Back, 0, Front, 1)] _SilhouetteRainLayer("Rainbow Layer", Float) = 0
		_SilhouetteRainbow("Rainbow", Float) = 0
		_SilhouetteRainbowSpeed("Rainbow Speed", Float) = 1
		_SilhouetteLighting("Lighting", Float) = 0
		[Enum(Multiply, 0, Overlay, 1)] _SilhouetteLightingMode("Lighting Mode", Float) = 1

		//thermal
		_ThermalHeat ("Thermal Heat", Float) = 25
		_ThermalSensitivity ("Thermal Sensitivity", Float) = 1.5
		_ThermalTransparency ("Thermal Transparency", Float) = 0
		_ThermalColor ("Thermal Color", Color) = (1, 1, 1, 1)

		//transistion
		[Toggle(_)] _ToggleTransistion ("Allow Transistion", Float) = 0
		_TransX ("Horizontal Transistion", Float) = 0.3
		_TransY ("Vertical Transistion", Float) = -1
		[Toggle(_)] _ToggleDiagTrans ("Allow Diagonal Transistion", Float) = 0
		_TransDL ("Left Diagonal Transistion", Float) = 0.5
		_TransDR ("Right Diagonal Transition", Float) = 0.5

		//vhs
		[Toggle(_)] _ToggleVHS ("Allow VHS", Float) = 0
		[Toggle(_)] _ToggleSmoothWave ("Use Smooth Wave", Float) = 0
		_VHSXDisplacement ("Horizontal Displacement", Float) = 0
		_VHSYDisplacement ("Vertical Displacement", Float) = 0
		_shadowStrength ("Shadow Strength", Float) = 2 
		_darkness ("Darkness", Float) = 2
		_waveyness ("Waveyness", Float) = 1

		//vibrance
		_VibrancePower ("Vibrance", Float) = 0

		//vignette
		[Toggle(_)] _ToggleVignette ("Toggle Vignette", Float) = 0
		_VigX ("Vignette Power", Float) = 0
		[Enum(Soft, 0, Hard, 1)] _VigMode("Color Mode", Float) = 0
		_VigCol ("Vignette Color", Color) = (0, 0, 0, 1)
		_VigColPow ("Color Glow", Float) = 1
		[MaterialToggle] _VigReverse ("Reverse Vignette?", Float) = 0
		_VigSharpness ("Sharpness", Float) = 15

		//warp
		_WarpHorizontal ("Horizontal Warp", Float) = 1
		_WarpVertical ("Vertical Warp", Float) = 1

		//warp zoom
		[Toggle(_)] _ToggleWarpZoom ("Allow Warped Zoom", Float) = 0
		_WarpZoomAmount("Zoom Amount", Float) = 0
		_WarpZoomTolerance("Zoom Tolerance", Float) = 0.5

		//wavey
		[Toggle(_)] _ToggleWavey ("Allow Wavey", Float) = 0
		_WavesX ("X Waves", Float) = 1
		_WavesXPower ("X Power", Float) = 0
		_WavesXSpeed ("X Speed", Float) = 0
		_WavesY ("Y Waves", Float) = 1
		_WavesYPower ("Y Power", Float) = 0
		_WavesYSpeed ("Y Speed", Float) = 0
		
		//deepfry
		[Toggle(_)] _ToggleDeepfry ("Deepfry?", Float) = 0
		[Enum( None, 4, Fry, 0, Rainbow Puke, 1, Chrome, 2, Seizure, 3)] _DeepfryValue ("Flavor", Float) = 4
		_DeepfryBrightness ("Brightness", Float) = 1
		_DeepfryEmbossPower ("Emboss Power", Float) = 0

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
		Tags 
		{
			"RenderType" = "Transparent"
			"Queue" = "Overlay+20000000"
			"LightMode" = "Always"
			"IgnoreProjector" = "True"
			"ForceNoShadowCasting" = "True"  
		}

		ZTest[_ZTest]
		Cull Off



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
