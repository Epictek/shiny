﻿using Nuke.Common;
using static Nuke.Common.ValueInjection.ValueInjectionUtility;


[ParameterPrefix(Nuget)]
interface INugetCredentials
{
    public const string Nuget = nameof(Nuget);
    [Parameter] [Secret] string ApiToken => TryGetValue(() => ApiToken);
}