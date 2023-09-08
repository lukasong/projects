# VRCSDK-MacFixes
i tweaked some scripts in the vrchat sdk to work on mac.. got tired of seeing errors every time i entered play mode or opened unity. specifically, for m1 macs on latest osx and unity/vrc sdk. **the file uploaded will only contain the functions that i edited, so just open the proper file and control + f and replace them. this should make it work on any new sdk version!**

# 1. Build target error spam.

**In Unity, the errors read:**
```
Target not supported, switching to one that is.
```

**Is it an issue?** No. It will literally always spam your console when you open Unity or play because you are not using Windows.<br/> 
**How was it fixed?** Commenting out the debug output lol. <br/> 
**What file is it fixed in:** EnvConfig.cs<br/> 

# 2. Error setting graphics api.

Yeah, mac graphics. Funny funny.<br/>
**In Unity, the errors read:**
```
unsupported platform: couldn't get group name for target %i
UnityEditor.PlayerSettings:SetGraphicsAPIs (UnityEditor.BuildTarget,UnityEngine.Rendering.GraphicsDeviceType[]) (... and so on)
unsupported platform: couldn't get group name for target %i
UnityEngine.StackTraceUtility:ExtractStackTrace () (... and so on)
unsupported platform: couldn't get group name for target %i
UnityEngine.StackTraceUtility:ExtractStackTrace () (... and so on)
```

**Is it an issue?** No. It will literally always spam your console when you open Unity or play because you are not using a supported graphics device / api (presumably metal is the issue but it could also be the m1 chip not recognized itself).<br/> 
**How was it fixed?** Unless you wanna get an external GPU, I removed the code that forced the VRCSDK to try and force the graphics environment.<br/> 
**What file is it fixed in:** EnvConfig.cs<br/> 

# Other issues you may run into..

**Unknown platform 3 in GetRenderList** when using Windows libraries (aka moving project from OS's) on OSX or Linux. Delete library, reimport any repos you need, and let it do its thing.<br/><br/>
**Switching to PC, Mac & Linux Standalone:WindowsStandaloneSupport is disabled** go to the Unity Hub -> Installs and find your version. Then go to the settings icon, add modules, and find "Mac build support" and install that. *(this may help fix errors above without editing the code as well..)*
