// List of all items available to buy from inventory station
$InvList[Blaster] = 1;
$InvList[Chaingun] = 1;
$InvList[Disclauncher] = 1;
$InvList[GrenadeLauncher] = 1;
$InvList[Mortar] = 1;
$InvList[PlasmaGun] = 1;
$InvList[LaserRifle] = 1;
$InvList[EnergyRifle] = 1;
$InvList[TargetingLaser] = 1;
$InvList[MineAmmo] = 1;
$InvList[Grenade] = 1;
$InvList[Beacon] = 1;

$InvList[BulletAmmo] = 1;
$InvList[PlasmaAmmo] = 1;
$InvList[DiscAmmo] = 1;
$InvList[GrenadeAmmo] = 1;
$InvList[MortarAmmo] = 1;
  
$InvList[EnergyPack] = 1;
$InvList[RepairPack] = 1;
$InvList[ShieldPack] = 1;
$InvList[SensorJammerPack] = 1;
$InvList[MotionSensorPack] = 1;
$InvList[PulseSensorPack] = 1;
$InvList[DeployableSensorJammerPack] = 1;
$InvList[CameraPack] = 1;
$InvList[TurretPack] = 1;
$InvList[AmmoPack] = 1;
$InvList[RepairKit] = 1;
$InvList[DeployableInvPack] = 1;
$InvList[DeployableAmmoPack] = 1;


//----------------------------------------------------------------------------

StaticShapeData InventoryStation
{
   description = "Station Supply Unit";
	shapeFile = "inventory_sta";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 1.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
   explosionId = flashExpLarge;
};

function InventoryStation::onEndSequence(%this,%thread)
{
	//echo("End Seq ",%thread);
	if (Station::onEndSequence(%this,%thread)) 
		InventoryStation::onResupply(%this,"InvList");
}

function InventoryStation::onResupply(%this,%InvShopList) {
	dbecho(3, "STATION::Resupply");
	if (GameBase::isActive(%this)) {
		%player = Station::getTarget(%this);
		if (%player != -1 && %this.lastPlayer == %player) {
			%client = Player::getClient(%player);
			if (%this.target != %client) {
				%player.Station = %this;
				setupShoppingList(%client,%this,%InvShopList);
				updateBuyingList(%client);
				%this.target = %client;
				%this.clTeamEnergy = %client.TeamEnergy;
				if(!%client.noEnterInventory)
					Client::setGuiMode(%client,$GuiModeInventory);
				Client::sendMessage(%client,0,"Station Access On");
				%player.ResupplyFlag = 1;
				%weapon = Player::getMountedItem(%player,$WeaponSlot);
				if(%weapon != -1) {
					%player.lastWeapon = %weapon;
					Player::unMountItem(%player,$WeaponSlot);
				}
			}
			%player.waitThrowTime = getSimTime();
			schedule("InventoryStation::onResupply(" @ %this @ ");",0.5,%this);
			if(%player.ResupplyFlag) 
				%player.ResupplyFlag = resupply(%this);

			switch ( %InvShopList ) {
				case "InvList": %type = "Inventory"; break;
				case "RemoteInvList": %type = "RemoteInventory"; break;
				default: %type = ""; break;
			}
			if ( %type != "" )
				message::tagged( %client, "RPC", "EnterStation", %type );
			return;
		}
		GameBase::setActive(%this,false);
	}

	if (%this.target != "") {
		%player = Client::getOwnedObject(%this.target);
		Client::clearItemShopping(%this.target);
		Client::sendMessage(%this.target,0,"Station Access Off");
		message::tagged( %this.target, "RPC", "ExitStation" );
		Station::onEndSequence(%this);		
		if(GameBase::getDataName(%player.Station) == DeployableInvStation) {
			Client::setInventoryText(%this.target, "<f1><jc>TEAM ENERGY: " @ $TeamEnergy[Client::getTeam(%this.target)]);
			if(Client::getGuiMode(%this.target) != 1)
				Client::setGuiMode(%this.target,1);
			%player.Station = "";
			%this.target = "";
		}

		if(Player::getMountedItem(%player,$WeaponSlot) == -1) {
			if(%player.lastWeapon != "") {
				Player::useItem(%player,%player.lastWeapon);
				%player.lastWeapon = "";
			}
		}
	}

	%this.enterTime="";
}
