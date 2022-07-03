    static void SetDefaultGraphicsAPIs()
    {
        /* no */
    }
    
    static void SetBuildTarget()
    {
#if !VRC_CLIENT
       
       // why u spam !?! 
       // VRC.Core.Logger.Log("Setting build target", VRC.Core.DebugLevel.All);

        BuildTarget target = UnityEditor.EditorUserBuildSettings.activeBuildTarget;

        if (!allowedBuildtargets.Contains(target))
        {
            // why u spam !?! 
            // Debug.LogError("Target not supported, switching to one that is.");
            target = allowedBuildtargets[0];
#pragma warning disable CS0618 // Type or member is obsolete
            EditorUserBuildSettings.SwitchActiveBuildTarget(target);
#pragma warning restore CS0618 // Type or member is obsolete
        }
#endif
    }
    
