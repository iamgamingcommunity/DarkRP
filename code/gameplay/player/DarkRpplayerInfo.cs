using Sandbox;
using Sandbox.Utility;

public sealed class DarkrpPlayerInfo : Component
{

    [Property, ReadOnly] public SteamId SteamId { get; private set; }
	[Property, ReadOnly] public string SteamName { get; private set; }
	[Property, ReadOnly] public string DisplayName { get; private set; }

	protected override void OnStart()
	{
		//Gets and sets SteamID to Be the Players SteamID for Using Later
		DisplayName = Steam.PersonaName;
		SteamId = Steam.SteamId;
		Log.Info( $"Local Player Name: {DisplayName}" );
		Log.Info($"Local Player Name: {SteamId}");
	}
	protected override void OnUpdate()
	{

	}
}
