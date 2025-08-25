// using Sandbox;
// //using GameSystems;

// //using GameSystemsDarkRP;

// // namespace Sandbox.GameSystemsDarkRP.PlayerNew;

// public partial class PlayerDarkRP : Component, Component.INetworkSpawn
// {
// 	public void OnNetworkSpawn(Connection owner)
// 	{
// 		OnNetworkSpawnOutfitter(owner);
// 	}

	
// 	/// <summary>
// 	/// We store the player's avatar over the network so everyone knows what everyone looks like.
// 	/// </summary>
// 	[Sync] public string Avatar { get; set; }

// 	/// <summary>
// 	/// Grab the player's avatar data.
	
// 	private void OnNetworkSpawnOutfitter( Connection owner )
// 	{
// 		if ( !Components.TryGet<SkinnedModelRenderer>( out var model ) )
// 		{
// 			return;
// 		}

// 		Avatar = owner.GetUserData( "avatar" );

// 		var container = new ClothingContainer();
// 		container.Deserialize( Avatar );
// 		container.Apply( model );
// 	}


// }
