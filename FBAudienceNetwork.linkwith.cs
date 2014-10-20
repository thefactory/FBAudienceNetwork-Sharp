using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("FBAudienceNetwork.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true,
    Frameworks = "Foundation")]
