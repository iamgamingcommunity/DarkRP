using Sandbox;
using GameSystems;
using Entity.Interactable.Door;
using Sandbox.GameSystems.Database;

//using GameSystemsDarkRP;

// namespace Sandbox.GameSystemsDarkRP.PlayerNew;

public partial class PlayerDarkRP : Component, Component.INetworkSpawn
{

	/// <summary>
	/// Base Player DarkRP Variables/Infomation for the base Component 
	/// </summary>
	[Property, Feature("References")] public PlayerHUD PlayerHud { get; set; }
	[Property, Feature("References")] public PlayerHUD PlayerTabMenu { get; set; }
	[Property, Feature("References")] public LeaderBoard LeaderBoard { get; set; }

	private CameraComponent _camera;

	public string Name { get; set; }

	protected override void OnAwake()
	{
		_camera = Scene.GetAllComponents<CameraComponent>().FirstOrDefault(x => x.IsMainCamera);

		if (!Network.IsProxy)
		{
			// TODO: This should be moved off of the player and moved globally
			PlayerHud.Enabled = true;
			PlayerTabMenu.Enabled = true;
			LeaderBoard.Enabled = true;
		}
	}

	protected override void OnStart()
	{
		GameController.Instance.AddPlayer(GameObject, GameObject.Network.OwnerConnection);
		Name = this.Network.OwnerConnection.DisplayName;

		if (!Network.IsProxy)
		{
			//OnStartStatus();
			//OnStartInventory();
		}
			///Status Logic:
			_chat = Scene.Directory.FindByName( "Screen" )?.First()?.Components.Get<Chat>();
			if ( _chat is null ) { Log.Error( "Chat component not found" ); }
			_controller = GameController.Instance;
	}

	protected override void OnUpdate()
	{

	}

	protected override void OnFixedUpdate()
	{

		if (!IsProxy)
		{
			// OnFixedUpdateStatus();
			// OnFixedUpdateInventory();
			// OnFixedUpdateInteraction();
		}

		if ( _lastUsed >= _salaryTimerSeconds && (Network.IsOwner) )
			{
				Balance += GetNetworkPlayer().Job.Salary; // add Salary to the player Money
				Sound.Play( "sounds/kenney/ui/ui.upvote.sound" ); // play a basic ui sound
				_lastUsed = 0; // reset the timer
			}

			if ( _lastSaved >= _saveCooldown && (Networking.IsHost) )
			{

				if ( GetNetworkPlayer() != null )
				{
					SavedPlayer.SavePlayer( new SavedPlayer( this.GetNetworkPlayer() ) );
					_lastSaved = 0; // reset the timer
				}

			}

			if ( _lastUsedFood >= _starvingTimerSeconds && (Network.IsOwner) && (Starving) )
			{
				if ( Hunger > 0 )
				{
					Hunger -= 1;
				}
				_lastUsedFood = 0; // reset the timer
			}
			if ( Health < 1 || Hunger < 1 )
			{
				Dead = true;
				Health = 0;
				Hunger = 0;
			}
			if ( Health > MaxHealth ) { Health = MaxHealth; }
			if ( Hunger > HungerMax ) { Hunger = HungerMax; }
			if ( Dead )
			{
				// TODO: Make ragdolls and die
			}
	}



	public void OnNetworkSpawn(Connection owner)
	{
		OnNetworkSpawnOutfitter(owner);
	}


	/// <summary>
	/// We store the player's avatar over the network so everyone knows what everyone looks like.
	/// </summary>
	public string Avatar { get; set; }

	/// <summary>
	/// Grab the player's avatar data.
	/// </summary>
	/// <param name="owner"></param>
	private void OnNetworkSpawnOutfitter(Connection owner)
	{
		if (!Components.TryGet<SkinnedModelRenderer>(out var model))
		{
			return;
		}

		Avatar = owner.GetUserData("avatar");

		var container = new ClothingContainer();
		container.Deserialize(Avatar);
		container.Apply(model);
	}




		[Property, Feature( "Status" )] public List<GameObject> Doors { get; private set; } = new();
		[Property, Feature("Status")]  public List<GameObject> CanOwnDoors { get; private set; } = new();
		[Property, Feature( "Status" )] public float Balance { get; set; } = 500f;
		[Property, Feature( "Status" )] public float Health { get; private set; } = 100f;
		[Property, Feature( "Status" )] public float Hunger { get; private set; } = 100f;
		[Property, Feature( "Status" )] public float MaxHealth { get; private set; } = 100f;
		[Property, Feature( "Status" )] public float HungerMax { get; private set; } = 100f;
		[Property, Feature( "Status" )] public bool Dead { get; private set; } = false;
		[Property, Feature( "Status" )] public bool Starving { get; private set; } = false;
		[Property] private float _salaryTimerSeconds { get; set; } = 60f; // SalaryTimer in seconds
		[Property] private float _starvingTimerSeconds { get; set; } = 20f;
		private Chat _chat { get; set; }
		private GameController _controller { get; set; }
		private static readonly uint _saveCooldown = 30;
		private TimeSince _lastUsed = 0; // Set the timer
		private TimeSince _lastUsedFood = 0;
		//Pereodiocal player data save in seconds
		private TimeSince _lastSaved = 0;

		// TODO add a "/sellallowneddoors" command to sell all doors owned by the player





}
