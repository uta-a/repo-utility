# Items

## Enums

### SemiFunc.emojiIcon

| Value | Name |
|-------|------|
| 0 | drone_heal |
| 1 | drone_zero_gravity |
| 2 | drone_indestructible |
| 3 | drone_feather |
| 4 | drone_torque |
| 5 | drone_battery |
| 6 | orb_heal |
| 7 | orb_zero_gravity |
| 8 | orb_indestructible |
| 9 | orb_feather |
| 10 | orb_torque |
| 11 | orb_battery |
| 12 | orb_magnet |
| 13 | grenade_explosive |
| 14 | grenade_stun |
| 15 | weapon_baseball_bat |
| 16 | weapon_sledgehammer |
| 17 | weapon_frying_pan |
| 18 | weapon_sword |
| 19 | weapon_inflatable_hammer |
| 20 | item_health_pack_S |
| 21 | item_health_pack_M |
| 22 | item_health_pack_L |
| 23 | item_gun_handgun |
| 24 | item_gun_shotgun |
| 25 | item_gun_tranq |
| 26 | item_valuable_tracker |
| 27 | item_extraction_tracker |
| 28 | item_grenade_human |
| 29 | item_grenade_duct_taped |
| 30 | item_rubber_duck |
| 31 | item_mine_explosive |
| 32 | item_grenade_shockwave |
| 33 | item_mine_shockwave |
| 34 | item_mine_stun |

### SemiFunc.itemSecretShopType

| Value | Name |
|-------|------|
| 0 | none |
| 1 | shop_attic |

### SemiFunc.itemType

| Value | Name |
|-------|------|
| 0 | drone |
| 1 | orb |
| 2 | cart |
| 3 | item_upgrade |
| 4 | player_upgrade |
| 5 | power_crystal |
| 6 | grenade |
| 7 | melee |
| 8 | healthPack |
| 9 | gun |
| 10 | tracker |
| 11 | mine |
| 12 | pocket_cart |
| 13 | tool |

### SemiFunc.itemVolume

| Value | Name |
|-------|------|
| 0 | small |
| 1 | medium |
| 2 | large |
| 3 | large_wide |
| 4 | power_crystal |
| 5 | large_high |
| 6 | upgrade |
| 7 | healthPack |
| 8 | large_plus |

## Core Types

### Item

Base: `ScriptableObject`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `Boolean` | disabled |
| public | `String` | itemName |
| public | `String` | description |
| public | `itemType` | itemType |
| public | `emojiIcon` | emojiIcon |
| public | `itemVolume` | itemVolume |
| public | `itemSecretShopType` | itemSecretShopType |
| public | `ColorPresets` | colorPreset |
| public | `PrefabRef` | prefab |
| public | `Value` | value |
| public | `Int32` | maxAmount |
| public | `Int32` | maxAmountInShop |
| public | `Boolean` | maxPurchase |
| public | `Int32` | maxPurchaseAmount |
| public | `Quaternion` | spawnRotationOffset |
| public | `Boolean` | physicalItem |

### ItemAttributes

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `PhotonView` | photonView |
| public | `Item` | item |
| public | `Vector3` | costOffset |
| protected | `emojiIcon` | emojiIcon |
| protected | `ColorPresets` | colorPreset |
| protected | `Int32` | value |
| protected | `RoomVolumeCheck` | roomVolumeCheck |
| private | `Single` | inStartRoomCheckTimer |
| private | `Boolean` | inStartRoom |
| private | `ItemEquippable` | itemEquippable |
| private | `Transform` | itemVolume |
| protected | `Boolean` | shopItem |
| private | `PhysGrabObject` | physGrabObject |
| protected | `Boolean` | disableUI |
| protected | `String` | itemName |
| protected | `String` | instanceName |
| protected | `Single` | showInfoTimer |
| protected | `Boolean` | hasIcon |
| public | `Sprite` | icon |
| private | `itemType` | itemType |
| private | `ItemToggle` | itemToggle |
| private | `Single` | isHeldTimer |
| private | `String` | itemTag |
| private | `String` | promptName |
| private | `String` | itemAssetName |
| private | `Single` | itemValueMin |
| private | `Single` | itemValueMax |

### ItemManager

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public static | `ItemManager` | instance |
| public | `List<ItemVolume>` | itemVolumes |
| public | `List<Item>` | purchasedItems |
| public | `List<PhysGrabObject>` | powerCrystals |
| public | `List<ItemAttributes>` | spawnedItems |
| public | `List<String>` | localPlayerInventory |
| protected | `Boolean` | firstIcon |
| public | `GameObject` | itemIconLights |

## Concrete Item Classes

### ItemBattery

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `Int32` | batteryBars |
| public | `Boolean` | isUnchargable |
| public | `Transform` | batteryTransform |
| private | `Camera` | mainCamera |
| public | `Single` | upOffset |
| public | `Boolean` | batteryActive |
| public | `Single` | batteryLife |
| protected | `Int32` | batteryLifeInt |
| private | `Single` | batteryOutBlinkTimer |
| private | `PhotonView` | photonView |
| public | `Color` | batteryColor |
| protected | `Color` | batteryColorMedium |
| private | `Single` | chargeTimer |
| private | `Single` | chargeRate |
| private | `List<GameObject>` | chargerList |
| protected | `Boolean` | isCharging |
| private | `Single` | chargingBlinkTimer |
| private | `Boolean` | chargingBlink |
| private | `ItemAttributes` | itemAttributes |
| private | `Single` | showTimer |
| private | `Boolean` | showBattery |
| public | `Boolean` | autoDrain |
| private | `ItemEquippable` | itemEquippable |
| public | `Boolean` | onlyShowWhenItemToggleIsOn |
| public | `Single` | batteryDrainRate |
| private | `Single` | drainRate |
| private | `Single` | drainTimer |
| protected | `Int32` | currentBars |
| private | `Int32` | batteryLifeCountBars |
| protected | `Int32` | batteryLifeCountBarsPrev |
| private | `BatteryVisualLogic` | batteryVisualLogic |
| private | `Boolean` | tutorialCheck |
| private | `PhysGrabObject` | physGrabObject |

### ItemCartCannon

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemCartCannonMain` | cartCannonMain |
| private | `PhotonView` | photonView |
| public | `AnimationCurve` | animationCurve |
| public | `GameObject` | bulletPrefab |
| private | `PhysGrabObject` | physGrabObject |
| private | `ItemBattery` | itemBattery |
| public | `Sound` | soundHit |
| public | `AnimationCurve` | animationCurveShoot |
| public | `AnimationCurve` | animationCurveShootRecoil |
| public | `Transform` | shootAnimationTransform |
| public | `Transform` | shootParticlesTransform |
| private | `Vector3` | movingPieceStartPosition |
| private | `Vector3` | movingPieceStartPositionRecoil |
| public | `Sound` | buildup1 |
| public | `Sound` | buildup2 |
| public | `Sound` | shootSound |
| public | `Sound` | shootSoundGlobal |
| private | `Boolean` | animationEvent1 |
| private | `Boolean` | animationEvent2 |
| public | `Transform` | animationEventTransform |
| public | `Transform` | shootNozzleRecoilTransform |
| private | `List<ParticleSystem>` | particles |
| private | `List<ParticleSystem>` | shootParticles |
| private | `Boolean` | doRecoil |
| private | `Single` | recoilTimer |
| private | `Single` | recoilTimerMax |
| private | `ParticleScriptExplosion` | particleScriptExplosion |
| private | `Int32` | statePrev |
| private | `Int32` | stateCurrent |
| private | `Boolean` | stateStart |

### ItemCartCannonMain

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `Single` | shootBuildUpTime |
| public | `Single` | shootTime |
| public | `Single` | goBackFromShootTime |
| public | `Boolean` | singleShot |
| public | `Color` | mainOnColor |
| public | `Single` | investigationRange |
| private | `ItemBattery` | battery |
| private | `PhysGrabObject` | physGrabObject |
| protected | `Boolean` | impulseShoot |
| protected | `Boolean` | impulseShooting |
| public | `Transform` | muzzle |
| private | `ItemToggle` | itemToggle |
| private | `Boolean` | prevToggleState |
| private | `Rigidbody` | rb |
| private | `PhysGrabObjectImpactDetector` | impactDetector |
| protected | `Boolean` | isActive |
| protected | `Quaternion` | rotationTargetY |
| public | `GameObject` | currentCorrector |
| public | `GameObject` | cannonGrabPoint |
| private | `PhysGrabObjectGrabArea` | physGrabObjectGrabArea |
| public | `List<MeshRenderer>` | grabMeshRenderers |
| private | `List<Material>` | grabMaterials |
| public | `MeshRenderer` | cartLogoScreen |
| public | `Light` | cartGrabLight |
| private | `PhotonView` | photonView |
| public | `MeshRenderer` | mainMesh |
| public | `Light` | mainLight |
| public | `Sound` | soundBootUp |
| public | `Sound` | soundShutdown |
| public | `Sound` | soundAimLoop |
| public | `Sound` | soundQuickTurn |
| private | `Quaternion` | prevRotation |
| private | `Single` | quickTurnSoundCooldown |
| private | `Single` | smoothPitch |
| protected | `Single` | stateTimer |
| protected | `Single` | stateTimerMax |
| protected | `Boolean` | stateStart |
| protected | `state` | stateCurrent |
| protected | `state` | statePrev |
| private | `Boolean` | isFixedUpdate |
| private | `Boolean` | singleShotNextFrame |
| public | `Sound` | soundGrabStart |
| public | `Sound` | soundGrabEnd |
| private | `Boolean` | handleGrabbed |

### ItemCartCannonMain.state

| Value | Name |
|-------|------|
| 0 | inactive |
| 1 | active |
| 2 | buildup |
| 3 | shooting |
| 4 | goingBack |

### ItemCartLaser

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `SemiLaser` | semiLaser |
| public | `Transform` | muzzleTransform |
| private | `ItemCartCannonMain` | cartCannonMain |
| private | `PhotonView` | photonView |
| private | `PhysGrabObject` | physGrabObject |
| private | `ItemBattery` | itemBattery |
| public | `Sound` | soundHit |
| public | `AnimationCurve` | animationCurveBuildup |
| public | `AnimationCurve` | animationCurveHatchType1 |
| public | `AnimationCurve` | animationCurveHatchType2 |
| public | `AnimationCurve` | animationCurveWarningLight |
| private | `Vector3` | movingPieceStartPosition |
| public | `Sound` | soundBuildupStart |
| public | `Sound` | soundBuildupLoop |
| public | `Sound` | soundGoingBack |
| private | `PhysGrabObjectImpactDetector` | physGrabObjectImpactDetector |
| private | `Boolean` | animationEvent1 |
| private | `Boolean` | animationEvent2 |
| public | `Transform` | animationEventTransform |
| public | `Transform` | shootParticlesTransform |
| private | `List<ParticleSystem>` | particles |
| private | `List<ParticleSystem>` | shootParticles |
| private | `ParticleScriptExplosion` | particleScriptExplosion |
| private | `Int32` | statePrev |
| protected | `Int32` | stateCurrent |
| private | `Boolean` | stateStart |
| public | `HurtCollider` | laserHurtCollider |
| public | `Transform` | hatch1Right |
| public | `Transform` | hatch1Left |
| public | `Transform` | hatch2Right |
| public | `Transform` | hatch2Left |
| public | `MeshRenderer` | warningLight1MeshRenderer |
| public | `MeshRenderer` | warningLight2MeshRenderer |
| public | `Light` | warningLight1Light |
| public | `Light` | warningLight2Light |
| public | `ParticleSystem` | hatchLeft |
| public | `ParticleSystem` | hatchRight |

### ItemCartLaserBuildupMeter

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemCartLaser` | itemCartLaser |
| private | `Light` | lightMeter |
| private | `MeshRenderer` | meshRenderer |
| private | `ItemCartCannonMain` | itemCartCannonMain |
| private | `AnimationCurve` | animationCurveBuildup |
| private | `State` | statePrevState |
| private | `State` | stateCurrent |
| private | `Boolean` | stateStart |
| private | `Int32` | cartLaserStatePrev |
| private | `Int32` | cartLaserStateCurrent |

### ItemCartLaserBuildupMeter.State

| Value | Name |
|-------|------|
| 0 | Inactive |
| 1 | Buildup |
| 2 | Shooting |
| 3 | GoingBack |

### ItemDeactivatedUntilLevel

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `Int32` | levelToActivate |

### ItemDrone

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `GameObject` | teleportParticles |
| private | `ItemAttributes` | itemAttributes |
| protected | `emojiIcon` | emojiIcon |
| public | `Texture` | droneIcon |
| protected | `ColorPresets` | colorPreset |
| public | `BatteryDrainPresets` | batteryDrainPreset |
| protected | `Single` | batteryDrainRate |
| protected | `Color` | droneColor |
| protected | `Color` | batteryColor |
| protected | `Color` | beamColor |
| private | `Single` | checkTimer |
| private | `Transform` | magnetTarget |
| protected | `PhysGrabObject` | magnetTargetPhysGrabObject |
| protected | `Rigidbody` | magnetTargetRigidbody |
| protected | `Boolean` | magnetActive |
| public | `PlayerTumble` | playerTumbleTarget |
| private | `Rigidbody` | rb |
| private | `Boolean` | attachPointFound |
| private | `Vector3` | attachPoint |
| private | `Single` | springConstant |
| private | `Single` | dampingCoefficient |
| private | `Single` | newAttachPointTimer |
| protected | `Boolean` | itemActivated |
| private | `PhotonView` | photonView |
| private | `Vector3` | rayHitPosition |
| private | `Vector3` | animatedRayHitPosition |
| private | `LineBetweenTwoPoints` | lineBetweenTwoPoints |
| public | `Transform` | lineStartPoint |
| private | `Single` | rayTimer |
| private | `Transform` | prevMagnetTarget |
| private | `Transform` | droneTransform |
| private | `List<Transform>` | dronePyramidTransforms |
| private | `List<Transform>` | droneTriangleTransforms |
| private | `Single` | lerpAnimationProgress |
| private | `Boolean` | hasBattery |
| private | `ItemBattery` | itemBattery |
| private | `Single` | onNoBatteryTimer |
| private | `Boolean` | animationOpen |
| private | `Transform` | onSwitchTransform |
| public | `ItemDroneSounds` | itemDroneSounds |
| protected | `Sound` | soundDroneLoop |
| protected | `Sound` | soundDroneBeamLoop |
| public | `PhysicMaterial` | physicMaterialSlippery |
| public | `Boolean` | targetValuables |
| public | `Boolean` | targetPlayers |
| public | `Boolean` | targetEnemies |
| public | `Boolean` | targetNonValuables |
| protected | `Vector3` | connectionPoint |
| protected | `Transform` | lastPlayerToTouch |
| private | `PhysGrabObject` | physGrabObject |
| private | `Single` | randomNudgeTimer |
| private | `Collider` | droneCollider |
| private | `PhysicMaterial` | physicMaterialOriginal |
| private | `ItemToggle` | itemToggle |
| protected | `PlayerAvatar` | playerAvatarTarget |
| private | `Boolean` | targetIsPlayer |
| protected | `Boolean` | targetIsLocalPlayer |
| private | `ItemEquippable` | itemEquippable |
| private | `Camera` | cameraMain |
| protected | `PlayerAvatar` | droneOwner |
| private | `Single` | teleportSpotTimer |
| private | `Boolean` | hadTarget |
| private | `Boolean` | targetIsEnemy |
| private | `Boolean` | togglePrevious |
| private | `Boolean` | fullReset |
| private | `Boolean` | fullInit |
| private | `EnemyParent` | enemyTarget |
| private | `Boolean` | magnetActivePrev |
| private | `ITargetingCondition` | customTargetingCondition |

### ItemDroneBattery

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemDrone` | itemDrone |
| private | `PhysGrabObject` | myPhysGrabObject |
| private | `ItemEquippable` | itemEquippable |
| private | `ItemBattery` | itemBattery |

### ItemDroneFeather

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemDrone` | itemDrone |
| private | `PhysGrabObject` | myPhysGrabObject |
| private | `ItemEquippable` | itemEquippable |
| private | `ItemBattery` | itemBattery |

### ItemDroneHeal

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemDrone` | itemDrone |
| private | `PhysGrabObject` | myPhysGrabObject |
| private | `Single` | healRate |
| private | `Single` | healTimer |
| private | `Int32` | healAmount |
| private | `ItemEquippable` | itemEquippable |

### ItemDroneIndestructible

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemDrone` | itemDrone |
| private | `PhysGrabObject` | myPhysGrabObject |
| private | `ItemEquippable` | itemEquippable |

### ItemDroneSounds

Base: `ScriptableObject`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `Sound` | DroneStart |
| public | `Sound` | DroneEnd |
| public | `Sound` | DroneDeploy |
| public | `Sound` | DroneRetract |
| public | `Sound` | DroneLoop |
| public | `Sound` | DroneBeamLoop |

### ItemDroneTargetingCondition

Base: `MonoBehaviour`

### ItemDroneTorque

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemDrone` | itemDrone |
| private | `PhysGrabObject` | myPhysGrabObject |
| private | `ItemEquippable` | itemEquippable |
| private | `ItemToggle` | itemToggle |
| private | `ItemBattery` | itemBattery |
| private | `ItemAttributes` | itemAttributes |
| private | `Single` | tumbleEnemyTimer |
| private | `Boolean` | tumbledPlayer |

### ItemDroneZeroGravity

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemDrone` | itemDrone |
| private | `PhysGrabObject` | myPhysGrabObject |
| private | `ItemEquippable` | itemEquippable |
| private | `Single` | tumbleEnemyTimer |
| private | `ItemBattery` | itemBattery |

### ItemDuckBucket

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `SphereCollider` | sphereCollider |
| private | `Boolean` | active |
| private | `Boolean` | activePrevious |
| private | `EnemyDuck` | enemyDuck |
| private | `EnemyElsa` | enemyElsa |
| private | `PlayerAvatar` | playerAvatar |
| public | `GameObject` | lowPassParent |

### ItemEquipCube

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `Boolean` | isObstructed |
| private | `Single` | obstructedTimer |

### ItemEquippable

Base: `MonoBehaviourPunCallbacks`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemState` | currentState |
| public | `Sprite` | ItemIcon |
| private | `InventorySpot` | equippedSpot |
| private | `Int32` | ownerPlayerId |
| protected | `Boolean` | isEquipped |
| protected | `Boolean` | isEquippedPrev |
| protected | `Single` | wasEquippedTimer |
| protected | `Boolean` | isUnequipping |
| protected | `Boolean` | isEquipping |
| private | `Single` | isUnequippingTimer |
| private | `Single` | isEquippingTimer |
| public | `LayerMask` | ObstructionLayers |
| public | `emojiIcon` | itemEmojiIcon |
| protected | `String` | itemEmoji |
| protected | `Int32` | inventorySpotIndex |
| protected | `Single` | unequipTimer |
| protected | `Single` | equipTimer |
| private static | `Single` | animationDuration |
| private | `PhysGrabObject` | physGrabObject |
| private | `Boolean` | stateStart |
| private | `Single` | itemEquipCubeShowTimer |
| private | `Vector3` | teleportPosition |
| private | `Single` | forceGrabTimer |
| private | `Boolean` | wasForceGrabbed |
| protected | `PhysGrabber` | latestOwner |

#### Properties

| Type | Name |
|------|------|
| `Rigidbody` | rb |

### ItemEquippable.ItemState

| Value | Name |
|-------|------|
| 0 | Idle |
| 1 | Equipping |
| 2 | Equipped |
| 3 | Unequipping |

### ItemGrenade

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `Color` | blinkColor |
| public | `UnityEvent` | onDetonate |
| private | `ItemToggle` | itemToggle |
| private | `ItemAttributes` | itemAttributes |
| protected | `Boolean` | isActive |
| private | `Single` | grenadeTimer |
| public | `Single` | tickTime |
| private | `PhotonView` | photonView |
| private | `PhysGrabObjectImpactDetector` | physGrabObjectImpactDetector |
| public | `Sound` | soundSplinter |
| public | `Sound` | soundTick |
| private | `Single` | splinterAnimationProgress |
| public | `AnimationCurve` | splinterAnimationCurve |
| private | `Transform` | splinterTransform |
| private | `Material` | grenadeEmissionMaterial |
| private | `ItemEquippable` | itemEquippable |
| private | `Vector3` | grenadeStartPosition |
| private | `Quaternion` | grenadeStartRotation |
| private | `PhysGrabObject` | physGrabObject |
| private | `Vector3` | prevPosition |
| public | `Boolean` | isSpawnedGrenade |
| public | `GameObject` | throwLine |
| private | `Rigidbody` | rb |
| private | `Single` | throwLineTimer |
| private | `TrailRenderer` | throwLineTrail |

### ItemGrenadeDuctTaped

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `GameObject` | grenadePrefab |
| private | `ParticleScriptExplosion` | particleScriptExplosion |
| private | `PhotonView` | photonView |
| public | `Sound` | soundExplosion |
| public | `Sound` | soundExplosionGlobal |

### ItemGrenadeExplosive

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ParticleScriptExplosion` | particleScriptExplosion |

### ItemGrenadeHuman

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ParticleScriptExplosion` | particleScriptExplosion |
| private | `ItemToggle` | itemToggle |
| private | `ItemGrenade` | itemGrenade |
| private | `PhotonView` | photonView |
| private | `PhysGrabObject` | physGrabObject |
| private | `Rigidbody` | rb |
| public | `Sound` | soundExplosion |
| public | `Sound` | soundExplosionGlobal |

### ItemGrenadeShockwave

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `GameObject` | shockwavePrefab |

### ItemGrenadeStun

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `Sound` | soundExplosion |
| public | `Sound` | soundTinnitus |
| private | `Transform` | stunExplosion |
| private | `ItemGrenade` | itemGrenade |

### ItemGun

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `PhysGrabObject` | physGrabObject |
| private | `ItemToggle` | itemToggle |
| public | `Boolean` | hasOneShot |
| public | `Single` | shootTime |
| public | `Boolean` | hasBuildUp |
| public | `Single` | buildUpTime |
| public | `Int32` | numberOfBullets |
| public | `Single` | gunRandomSpread |
| public | `Single` | gunRange |
| public | `Single` | distanceKeep |
| public | `Single` | gunRecoilForce |
| public | `Single` | cameraShakeMultiplier |
| public | `Single` | torqueMultiplier |
| public | `Single` | grabStrengthMultiplier |
| public | `Single` | shootCooldown |
| public | `Single` | batteryDrain |
| public | `Boolean` | batteryDrainFullBar |
| public | `Int32` | batteryDrainFullBars |
| public | `Single` | misfirePercentageChange |
| public | `AnimationCurve` | shootLineWidthCurve |
| public | `Single` | grabVerticalOffset |
| public | `Single` | aimVerticalOffset |
| public | `Single` | investigateRadius |
| private | `Single` | investigateCooldown |
| public | `Transform` | gunMuzzle |
| public | `GameObject` | bulletPrefab |
| public | `GameObject` | muzzleFlashPrefab |
| public | `Transform` | gunTrigger |
| protected | `HurtCollider` | hurtCollider |
| public | `Sound` | soundShoot |
| public | `Sound` | soundShootGlobal |
| public | `Sound` | soundNoAmmoClick |
| public | `Sound` | soundHit |
| private | `ItemBattery` | itemBattery |
| private | `PhotonView` | photonView |
| private | `PhysGrabObjectImpactDetector` | impactDetector |
| private | `Boolean` | prevToggleState |
| private | `AnimationCurve` | triggerAnimationCurve |
| private | `Single` | triggerAnimationEval |
| private | `Boolean` | triggerAnimationActive |
| public | `UnityEvent` | onStateIdleStart |
| public | `UnityEvent` | onStateIdleUpdate |
| public | `UnityEvent` | onStateIdleFixedUpdate |
| public | `UnityEvent` | onStateOutOfAmmoStart |
| public | `UnityEvent` | onStateOutOfAmmoUpdate |
| public | `UnityEvent` | onStateOutOfAmmoFixedUpdate |
| public | `UnityEvent` | onStateBuildupStart |
| public | `UnityEvent` | onStateBuildupUpdate |
| public | `UnityEvent` | onStateBuildupFixedUpdate |
| public | `UnityEvent` | onStateShootingStart |
| public | `UnityEvent` | onStateShootingUpdate |
| public | `UnityEvent` | onStateShootingFixedUpdate |
| public | `UnityEvent` | onStateReloadingStart |
| public | `UnityEvent` | onStateReloadingUpdate |
| public | `UnityEvent` | onStateReloadingFixedUpdate |
| private | `Boolean` | hasIdleUpdate |
| private | `Boolean` | hasIdleFixedUpdate |
| private | `Boolean` | hasOutOfAmmoUpdate |
| private | `Boolean` | hasOutOfAmmoFixedUpdate |
| private | `Boolean` | hasBuildupUpdate |
| private | `Boolean` | hasBuildupFixedUpdate |
| private | `Boolean` | hasShootingUpdate |
| private | `Boolean` | hasShootingFixedUpdate |
| private | `Boolean` | hasReloadingUpdate |
| private | `Boolean` | hasReloadingFixedUpdate |
| private | `RoomVolumeCheck` | roomVolumeCheck |
| protected | `Single` | stateTimer |
| protected | `Single` | stateTimeMax |
| protected | `State` | stateCurrent |
| private | `State` | statePrev |
| private | `Boolean` | stateStart |
| private | `ItemEquippable` | itemEquippable |

### ItemGun.State

| Value | Name |
|-------|------|
| 0 | Idle |
| 1 | OutOfAmmo |
| 2 | Buildup |
| 3 | Shooting |
| 4 | Reloading |

### ItemGunBullet

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `Transform` | hitEffectTransform |
| private | `ParticleSystem` | particleSparks |
| private | `ParticleSystem` | particleSmoke |
| private | `ParticleSystem` | particleImpact |
| private | `Light` | hitLight |
| private | `LineRenderer` | shootLine |
| public | `Boolean` | hasHurtCollider |
| public | `HurtCollider` | hurtCollider |
| protected | `Boolean` | bulletHit |
| protected | `Vector3` | hitPosition |
| public | `Single` | hurtColliderTimer |
| private | `Boolean` | shootLineActive |
| private | `Single` | shootLineLerp |
| protected | `AnimationCurve` | shootLineWidthCurve |
| public | `GameObject` | hitGameObject |
| public | `Single` | hitGameObjectDestroyTime |
| public | `Boolean` | hasExtraParticles |
| public | `GameObject` | extraParticles |

### ItemGunLaser

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `SemiLaser` | semiLaser |
| public | `Transform` | muzzleTransform |
| private | `Single` | shootImpulseTimer |
| private | `Boolean` | shooting |
| public | `ParticleSystem` | muzzleFlashParticle |
| private | `ItemGun` | itemGun |
| public | `Sound` | soundInitialCrack |
| public | `Sound` | soundBuildup |
| public | `Sound` | soundReload |
| public | `Sound` | soundReload2 |
| private | `Single` | buildupImpulseTimer |
| public | `ParticleSystem` | particleOverHeat |
| public | `AnimationCurve` | buildupImpulseCurve |
| public | `AnimationCurve` | heatLatchCurve |
| public | `AnimationCurve` | backLatchCurve |
| public | `Transform` | transformGunEnergyPlop |
| public | `Transform` | transformOverHeatLatch |
| public | `Transform` | transformBackPlingPlong |
| private | `Material` | materialGunEnergyPlop |
| public | `ParticleSystem` | particleBuildUp |
| public | `ParticleSystem` | particleInitialCrack |
| private | `Boolean` | soundReload2Played |
| private | `PhysGrabObject` | physGrabObject |

### ItemGunMuzzleFlash

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ParticleSystem` | smoke |
| private | `ParticleSystem` | impact |
| private | `ParticleSystem` | sparks |
| private | `Light` | shootLight |

### ItemGunTranq

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `PhotonView` | photonView |

### ItemHealthPack

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `Int32` | healAmount |
| private | `ItemToggle` | itemToggle |
| private | `ItemEquippable` | itemEquippable |
| private | `ItemAttributes` | itemAttributes |
| private | `PhotonView` | photonView |
| private | `PhysGrabObject` | physGrabObject |
| public | `ParticleSystem[]` | particles |
| public | `ParticleSystem[]` | rejectParticles |
| public | `PropLight` | propLight |
| public | `AnimationCurve` | lightIntensityCurve |
| private | `Single` | lightIntensityLerp |
| public | `MeshRenderer` | mesh |
| private | `Material` | material |
| private | `Color` | materialEmissionOriginal |
| private | `Int32` | materialPropertyEmission |
| public | `Sound` | soundUse |
| public | `Sound` | soundReject |
| private | `Boolean` | used |

### ItemInfoExtraUI

Base: `SemiUI`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `TextMeshProUGUI` | Text |
| public static | `ItemInfoExtraUI` | instance |
| private | `String` | messagePrev |
| private | `Single` | messageTimer |
| private | `GameObject` | bigMessageEmojiObject |
| private | `TextMeshProUGUI` | emojiText |
| private | `Color` | textColor |

### ItemInfoUI

Base: `SemiUI`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `TextMeshProUGUI` | Text |
| public static | `ItemInfoUI` | instance |
| private | `String` | messagePrev |
| private | `Single` | messageTimer |
| private | `GameObject` | bigMessageEmojiObject |
| private | `TextMeshProUGUI` | emojiText |
| private | `VertexGradient` | originalGradient |

### ItemLadder

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `Transform` | topTransformPivot |
| public | `Transform` | bottomTransform |
| public | `Transform` | plasmaBridgePivot |
| public | `MeshRenderer` | grabIcon |
| public | `MeshRenderer` | bridge |
| public | `Transform` | collisionCheckPivot |
| public | `Transform` | collisionCheck |
| public | `Transform` | groundCollisionCheck |
| public | `Transform` | colliderPivot |
| public | `Transform` | endCollider |
| public | `AnimationCurve` | animationCurve |
| public | `Single` | extendingSpeed |
| public | `Single` | extensionBatteryDrain |
| public | `Int32` | extensionAmount |
| public | `PhysicMaterial` | defaultPhysicMaterial |
| public | `PhysicMaterial` | littleStickyMaterial |
| public | `PhysAudio` | OffPhysAudio |
| public | `PhysAudio` | OnPhysAudio |
| public | `Sound` | grabSound |
| public | `Sound` | releaseSound |
| public | `Sound` | extendSound |
| public | `Sound` | retractSound |
| public | `Sound` | bridgeLoop |
| public | `Sound` | deniedSound |
| public | `Sound` | flickeringSound |
| public | `Boolean` | denied |
| private | `States` | currentState |
| private | `States` | previousState |
| private | `States` | previousPreviousState |
| private | `Vector3` | colliderPivotOriginalScale |
| private | `Vector3` | collisionCheckPivotOriginalPosition |
| private | `Vector3` | topTransformPivotOriginalPosition |
| private | `Vector3` | plasmaBridgePivotOriginalScale |
| private | `Vector3` | endColliderOriginalPosition |
| private | `PhotonView` | photonView |
| private | `ItemToggle` | itemToggle |
| private | `ItemEquippable` | itemEquippable |
| private | `ItemBattery` | itemBattery |
| private | `PhysGrabObject` | physGrabObject |
| private | `Rigidbody` | rb |
| private | `PhysGrabObjectImpactDetector` | impactDetector |
| private | `RoomVolumeCheck` | roomVolumeCheck |
| private | `Vector3` | roomVolumeCheckOriginalPosition |
| private | `Vector3` | roomVolumeCheckOriginalScale |
| private | `Boolean` | animate |
| private | `Boolean` | previousToggleState |
| private | `Boolean` | previousEquippedState |
| private | `Int32` | previousExtensionIndex |
| private | `Int32` | extensionIndex |
| private | `Single` | deniedTime |
| private | `Single` | animationCurveEval |
| private | `Material` | grabMaterial |
| private | `Color` | bridgeBaseColor |
| private | `Vector3` | startTopPosition |
| private | `Vector3` | startScale |
| private | `Boolean` | flickering |
| private | `Single` | shopTimer |
| private | `Boolean` | shopTimerOn |
| private | `Boolean` | justGrabbed |
| private | `Single` | flickeringTime |
| private | `Single` | flickeringTimer |
| private | `Single` | staticResetTimer |
| private | `Vector3` | staticPosition |
| private | `Quaternion` | staticRotation |
| private | `Single` | staticLerp |

### ItemLadder.States

| Value | Name |
|-------|------|
| 0 | Denied |
| 1 | Neutral |
| 2 | Grabbed |
| 3 | OutOfBattery |
| 4 | Flickering |

### ItemLight

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `Boolean` | alwaysActive |
| public | `Light` | itemLight |
| private | `Single` | lightIntensityOriginal |
| private | `Single` | lightRangeOriginal |
| private | `Boolean` | showLight |
| private | `PhysGrabObject` | physGrabObject |
| private | `Boolean` | culledLight |
| public | `AnimationCurve` | lightIntensityCurve |
| private | `Single` | animationCurveEval |
| public | `List<MeshRenderer>` | meshRenderers |
| private | `Single` | fresnelScaleOriginal |
| private | `ItemEquippable` | itemEquippable |

### ItemMelee

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `Single` | durabilityDrain |
| public | `Single` | durabilityDrainOnEnemiesAndPVP |
| public | `Single` | hitFreeze |
| public | `Single` | hitFreezeDelay |
| public | `Single` | swingDetectSpeedMultiplier |
| public | `Boolean` | turnWeapon |
| public | `Boolean` | customTorqueStrength |
| public | `Single` | torqueStrength |
| public | `Single` | turnWeaponStrength |
| public | `Quaternion` | customRotation |
| public | `UnityEvent` | onHit |
| private | `HurtCollider` | hurtCollider |
| private | `Transform` | hurtColliderTransform |
| private | `Transform` | hurtColliderRotation |
| private | `PhysGrabObjectImpactDetector` | physGrabObjectImpactDetector |
| private | `PhysGrabObject` | physGrabObject |
| private | `Rigidbody` | rb |
| private | `Single` | swingTimer |
| private | `Single` | hitBoxTimer |
| private | `TrailRenderer` | trailRenderer |
| public | `Sound` | soundSwingLoop |
| public | `Sound` | soundSwing |
| public | `Sound` | soundHit |
| private | `Vector3` | prevPosition |
| private | `Single` | prevPosDistance |
| private | `Single` | prevPosUpdateTimer |
| private | `Transform` | swingPoint |
| private | `Quaternion` | swingDirection |
| private | `PlayerAvatar` | playerAvatar |
| private | `Single` | hitSoundDelayTimer |
| private | `ParticleSystem` | particleSystem |
| private | `ParticleSystem` | particleSystemGroundHit |
| private | `PhotonView` | photonView |
| private | `Single` | swingPitch |
| private | `Single` | swingPitchTarget |
| private | `Single` | swingPitchTargetProgress |
| private | `Single` | distanceCheckTimer |
| private | `ItemBattery` | itemBattery |
| private | `Vector3` | swingStartDirection |
| private | `Transform` | forceGrabPoint |
| private | `Boolean` | isBroken |
| private | `Quaternion` | targetYRotation |
| private | `Quaternion` | currentYRotation |
| private | `Single` | durabilityLossCooldown |
| private | `Transform` | meshHealthy |
| private | `Transform` | meshBroken |
| protected | `Boolean` | isSwinging |
| private | `Boolean` | newSwing |
| private | `Single` | hitTimer |
| private | `ItemEquippable` | itemEquippable |
| private | `Single` | hitCooldown |
| private | `Single` | groundHitCooldown |
| private | `Single` | groundHitSoundTimer |
| private | `Single` | spawnTimer |
| private | `Single` | grabbedTimer |
| private | `Single` | enemyOrPVPDurabilityLossCooldown |

### ItemMeleeInflatableHammer

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ParticleScriptExplosion` | particleScriptExplosion |
| private | `Transform` | explosionPosition |
| private | `PhotonView` | photonView |

### ItemMine

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `MineType` | mineType |
| public | `Color` | emissionColor |
| public | `UnityEvent` | onTriggered |
| public | `Single` | armingTime |
| public | `Single` | triggeringTime |
| private | `SpringQuaternion` | triggerSpringQuaternion |
| private | `Quaternion` | triggerTargetRotation |
| private | `Boolean` | upsideDown |
| public | `Transform` | triggerTransform |
| public | `LineRenderer` | triggerLine |
| public | `ParticleSystem` | lineParticles |
| private | `Single` | beepTimer |
| private | `Single` | checkTimer |
| private | `ItemMineTrigger` | itemMineTrigger |
| private | `ItemEquippable` | itemEquippable |
| private | `ItemAttributes` | itemAttributes |
| private | `ItemToggle` | itemToggle |
| private | `PhotonView` | photonView |
| private | `PhysGrabObject` | physGrabObject |
| public | `MeshRenderer` | meshRenderer |
| public | `Light` | lightArmed |
| public | `Sound` | soundArmingBeep |
| public | `Sound` | soundArmedBeep |
| public | `Sound` | soundDisarmingBeep |
| public | `Sound` | soundDisarmedBeep |
| public | `Sound` | soundTriggereringBeep |
| private | `Single` | initialLightIntensity |
| private | `ParticleScriptExplosion` | particleScriptExplosion |
| private | `Boolean` | hasBeenGrabbed |
| private | `Vector3` | startPosition |
| private | `Quaternion` | startRotation |
| protected | `Vector3` | triggeredPosition |
| protected | `Transform` | triggeredTransform |
| protected | `PlayerAvatar` | triggeredPlayerAvatar |
| protected | `PlayerTumble` | triggeredPlayerTumble |
| protected | `PhysGrabObject` | triggeredPhysGrabObject |
| public | `Boolean` | triggeredByRigidBodies |
| public | `Boolean` | triggeredByEnemies |
| public | `Boolean` | triggeredByPlayers |
| public | `Boolean` | triggeredByForces |
| public | `Boolean` | destroyAfterTimer |
| public | `Single` | destroyTimer |
| protected | `Boolean` | wasTriggeredByEnemy |
| protected | `Boolean` | wasTriggeredByPlayer |
| protected | `Boolean` | wasTriggeredByForce |
| protected | `Boolean` | wasTriggeredByRigidBody |
| protected | `Boolean` | firstLight |
| private | `Boolean` | firstLightDone |
| private | `Single` | secondArmedTimer |
| private | `Boolean` | wasGrabbed |
| private | `Single` | targetLineLength |
| private | `Vector3` | prevPos |
| private | `Quaternion` | prevRot |
| protected | `States` | state |
| private | `Boolean` | stateStart |
| private | `Single` | stateTimer |
| private | `PhysGrabObjectImpactDetector` | impactDetector |
| private | `Boolean` | mineDestroyed |

### ItemMine.MineType

| Value | Name |
|-------|------|
| 0 | None |
| 1 | Explosive |
| 2 | Shockwave |
| 3 | Stun |

### ItemMine.States

| Value | Name |
|-------|------|
| 0 | Disarmed |
| 1 | Arming |
| 2 | Armed |
| 3 | Disarming |
| 4 | Triggering |
| 5 | Triggered |

### ItemMineExplosive

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ParticleScriptExplosion` | particleScriptExplosion |

### ItemMineStun

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemMine` | itemMine |
| private | `PhysGrabObject` | bitPhysGrabObject |
| private | `Transform` | bitTransform |
| private | `Vector3` | startPosition |
| private | `Boolean` | triggered |
| public | `AnimationCurve` | jawAnimationCurve |
| private | `Rigidbody` | rb |
| private | `PhysGrabObject` | physGrabObject |
| public | `Transform` | jaw1Tranform |
| public | `Transform` | jaw2Tranform |
| private | `Single` | jawEval |
| private | `Single` | jaw1CurrentRot |
| private | `Single` | jaw2CurrentRot |
| public | `GameObject` | hurtCollider |
| private | `Boolean` | bite |
| public | `ParticleSystem` | particleFlash |
| public | `ParticleSystem` | particleLightning |
| private | `Boolean` | chomp |
| public | `Sound` | soundChomp |
| public | `Sound` | soundElectricity |
| private | `Quaternion` | jaw1StartRot |
| private | `Quaternion` | jaw2StartRot |

### ItemMineTrigger

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `PhysGrabObject` | parentPhysGrabObject |
| private | `ItemMine` | itemMine |
| public | `Boolean` | enemyTrigger |
| private | `Boolean` | targetAcquired |
| private | `Single` | visionCheckTimer |

### ItemMineTrigger.TargetType

| Value | Name |
|-------|------|
| 0 | None |
| 1 | Enemy |
| 2 | RigidBody |
| 3 | Player |

### ItemOrb

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `emojiIcon` | emojiIcon |
| public | `Texture` | orbIcon |
| private | `Material` | orbEffect |
| public | `Single` | orbRadius |
| private | `Single` | orbRadiusOriginal |
| private | `Single` | orbRadiusMultiplier |
| private | `Transform` | orbTransform |
| private | `Transform` | orbInnerTransform |
| private | `ItemToggle` | itemToggle |
| public | `Single` | batteryDrainRate |
| public | `Boolean` | itemActive |
| private | `Transform` | sphereEffectTransform |
| private | `Single` | sphereEffectScaleLerp |
| private | `PhysGrabObject` | physGrabObject |
| protected | `List<PhysGrabObject>` | objectAffected |
| protected | `Boolean` | localPlayerAffected |
| private | `Transform` | sphereCheckTransform |
| private | `Single` | sphereCheckTimer |
| private | `List<Transform>` | spherePieces |
| private | `Transform` | sphereCore |
| public | `ColorPresets` | colorPresets |
| public | `BatteryDrainPresets` | batteryDrainPreset |
| public | `Color` | orbColor |
| private | `Color` | orbColorLight |
| public | `Color` | batteryColor |
| private | `ItemBattery` | itemBattery |
| private | `Single` | onNoBatteryTimer |
| private | `ItemEquippable` | itemEquippable |
| private | `ItemAttributes` | itemAttributes |
| public | `Sound` | soundOrbBoot |
| public | `Sound` | soundOrbShutdown |
| public | `Sound` | soundOrbLoop |
| public | `OrbType` | orbType |
| public | `Boolean` | targetValuables |
| public | `Boolean` | targetPlayers |
| public | `Boolean` | targetEnemies |
| public | `Boolean` | targetNonValuables |
| private | `ITargetingCondition` | customTargetingCondition |

### ItemOrb.OrbType

| Value | Name |
|-------|------|
| 0 | Constant |
| 1 | Pulse |

### ItemOrbBattery

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemOrb` | itemOrb |
| private | `PhysGrabObject` | physGrabObject |
| private | `ItemToggle` | itemToggle |
| private | `ItemBattery` | itemBattery |
| private | `Boolean` | didCharge |

### ItemOrbFeather

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemOrb` | itemOrb |
| private | `PhysGrabObject` | physGrabObject |

### ItemOrbHeal

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemOrb` | itemOrb |
| private | `ItemBattery` | itemBattery |
| private | `PhysGrabObject` | physGrabObject |
| private | `Single` | healRate |
| private | `Single` | healTimer |
| private | `Int32` | healAmount |

### ItemOrbIndestructible

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemOrb` | itemOrb |
| private | `PhysGrabObject` | physGrabObject |

### ItemOrbMagnet

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemOrb` | itemOrb |
| private | `PhysGrabObject` | physGrabObject |

### ItemOrbTorque

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemOrb` | itemOrb |
| private | `PhysGrabObject` | physGrabObject |

### ItemOrbZeroGravity

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemOrb` | itemOrb |
| private | `PhysGrabObject` | physGrabObject |
| private | `ItemBattery` | itemBattery |

### ItemRubberDuck

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `Sound` | soundQuack |
| public | `Sound` | soundSqueak |
| public | `Sound` | soundDuckLoop |
| public | `Sound` | soundDuckExplosion |
| public | `Sound` | soundDuckExplosionGlobal |
| private | `Rigidbody` | rb |
| private | `PhotonView` | photonView |
| private | `ParticleScriptExplosion` | particleScriptExplosion |
| private | `PhysGrabObject` | physGrabObject |
| public | `HurtCollider` | hurtCollider |
| public | `Transform` | hurtTransform |
| private | `Single` | hurtColliderTime |
| private | `Vector3` | prevPosition |
| private | `Boolean` | playDuckLoop |
| private | `List<TrailRenderer>` | trails |
| private | `ItemBattery` | itemBattery |
| private | `Single` | trailTimer |
| public | `GameObject` | brokenObject |
| public | `GameObject` | notBrokenObject |
| private | `ItemEquippable` | itemEquippable |
| private | `Single` | lilQuacksTimer |

### ItemShockwave

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `MeshRenderer` | meshRenderer |
| private | `Single` | startScale |
| private | `Boolean` | finalScale |
| private | `Light` | lightShockwave |
| public | `ParticleSystem` | particleSystemWave |
| public | `ParticleSystem` | particleSystemSparks |
| public | `ParticleSystem` | particleSystemLightning |
| private | `HurtCollider` | hurtCollider |
| public | `Sound` | soundExplosion |
| public | `Sound` | soundExplosionGlobal |

### ItemStunBaton

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `Transform` | stunBatonEffects |
| public | `Sound` | stunBatonSound |
| private | `List<ParticleSystem>` | particleSystems |

### ItemToggle

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `Boolean` | toggleState |
| public | `Boolean` | playSound |
| private | `Boolean` | fetchSound |
| protected | `Boolean` | toggleStatePrevious |
| private | `PhotonView` | photonView |
| private | `PhysGrabObject` | physGrabObject |
| private | `ItemEquippable` | itemEquippable |
| private | `Sound` | soundOn |
| private | `Sound` | soundOff |
| protected | `Int32` | playerTogglePhotonID |
| protected | `Boolean` | toggleImpulse |
| private | `Single` | toggleImpulseTimer |
| protected | `Boolean` | disabled |
| public | `Boolean` | autoTurnOffWhenEquipped |
| public | `UnityEvent` | onToggle |

### ItemTracker

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `TrackerType` | trackerType |
| private | `Single` | timer |
| private | `Transform` | currentTarget |
| private | `PhysGrabObject` | currentTargetPhysGrabObject |
| private | `Rigidbody` | rb |
| public | `Transform` | nozzleTransform |
| private | `PhysGrabObject` | physGrabObject |
| public | `MeshRenderer` | meshRenderer |
| public | `AnimationCurve` | animationCurve |
| private | `Single` | blipTimer |
| public | `Sound` | soundBleep |
| public | `Sound` | digitSwap |
| public | `Sound` | soundTargetFound |
| public | `Sound` | soundTargetLost |
| private | `ItemToggle` | itemToggle |
| private | `ItemBattery` | itemBattery |
| private | `PhotonView` | photonView |
| private | `Boolean` | currentToggleState |
| public | `Light` | nozzleLight |
| public | `MeshRenderer` | display |
| public | `TextMeshPro` | displayText |
| private | `Int32` | prevDigit |
| private | `Single` | changeDigitTimer |
| private | `Single` | displayOverrideTimer |
| public | `Light` | displayLight |
| private | `Boolean` | hasTarget |
| public | `Color` | colorBleep |
| public | `Color` | colorBleepOff |
| public | `Color` | colorTargetFound |
| public | `Color` | colorScreenNeutral |
| private | `Vector3` | targetPosition |
| private | `Single` | batteryOutTimer |

### ItemTracker.TrackerType

| Value | Name |
|-------|------|
| 0 | Valuable |
| 1 | Extraction |

### ItemUpgrade

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `UnityEvent` | upgradeEvent |
| public | `Boolean` | isPlayerUpgrade |
| public | `ColorPresets` | colorPreset |
| protected | `Color` | beamColor |
| private | `Single` | checkTimer |
| private | `Transform` | magnetTarget |
| protected | `PhysGrabObject` | magnetTargetPhysGrabObject |
| protected | `Rigidbody` | magnetTargetRigidbody |
| protected | `Boolean` | magnetActive |
| private | `Rigidbody` | rb |
| private | `Boolean` | attachPointFound |
| private | `Vector3` | attachPoint |
| private | `Single` | springConstant |
| private | `Single` | dampingCoefficient |
| private | `Single` | newAttachPointTimer |
| protected | `Boolean` | itemActivated |
| private | `PhotonView` | photonView |
| private | `Vector3` | rayHitPosition |
| private | `Vector3` | animatedRayHitPosition |
| private | `LineBetweenTwoPoints` | lineBetweenTwoPoints |
| public | `Transform` | lineStartPoint |
| private | `Single` | rayTimer |
| private | `Transform` | prevMagnetTarget |
| private | `Transform` | droneTransform |
| private | `PhysGrabObjectImpactDetector` | impactDetector |
| private | `ItemAttributes` | itemAttributes |
| private | `Transform` | particleEffects |
| private | `Transform` | onSwitchTransform |
| protected | `Vector3` | connectionPoint |
| protected | `Transform` | lastPlayerToTouch |
| private | `PhysGrabObject` | physGrabObject |
| private | `PhysicMaterial` | physicMaterialOriginal |
| private | `ItemToggle` | itemToggle |
| protected | `PlayerAvatar` | playerAvatarTarget |
| private | `Boolean` | targetIsPlayer |
| protected | `Boolean` | targetIsLocalPlayer |
| private | `Camera` | cameraMain |
| private | `Boolean` | upgradeDone |
| private | `Boolean` | pushedOrPulled |
| private | `ITargetingCondition` | customTargetingCondition |

### ItemUpgradeDeathHeadBattery

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemToggle` | itemToggle |

### ItemUpgradeMapPlayerCount

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemToggle` | itemToggle |

### ItemUpgradeParticleEffects

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `Single` | destroyTimer |

### ItemUpgradePlayerCrouchRest

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemToggle` | itemToggle |

### ItemUpgradePlayerEnergy

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemToggle` | itemToggle |

### ItemUpgradePlayerExtraJump

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemToggle` | itemToggle |

### ItemUpgradePlayerGrabRange

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemToggle` | itemToggle |

### ItemUpgradePlayerGrabStrength

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemToggle` | itemToggle |

### ItemUpgradePlayerGrabThrow

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemToggle` | itemToggle |

### ItemUpgradePlayerHealth

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemToggle` | itemToggle |

### ItemUpgradePlayerSprintSpeed

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemToggle` | itemToggle |

### ItemUpgradePlayerTumbleClimb

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemToggle` | itemToggle |

### ItemUpgradePlayerTumbleLaunch

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemToggle` | itemToggle |

### ItemUpgradePlayerTumbleWings

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `ItemToggle` | itemToggle |

### ItemUpgradePlayerTumbleWingsLogic

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `PhysGrabObject` | physGrabObject |
| private | `PlayerTumble` | playerTumble |
| public | `PlayerAvatar` | playerAvatar |
| private | `String` | steamID |
| private | `Boolean` | stateStart |
| public | `Transform` | transformWings |
| public | `Transform` | transformWingLeft |
| public | `Transform` | transformWingRight |
| private | `Boolean` | isLocal |
| public | `Sound` | soundWingsLoop |
| private | `Vector3` | posPrev |
| private | `Vector3` | posCurrent |
| private | `Single` | targetSpeed |
| private | `Single` | currentSpeed |
| public | `AudioSource` | localAudioSource |
| private | `Boolean` | lateStartDone |
| private | `Single` | pitchSpeed |
| private | `Boolean` | fetchComplete |
| private | `Single` | wingsSwitchCooldown |
| public | `Light` | lightWings |
| protected | `Single` | tumbleWingTimer |
| private | `Boolean` | hasBeenGrounded |
| protected | `Single` | tumbleWingPinkTimer |
| private | `Boolean` | isPink |
| private | `MeshRenderer` | wing1MeshRenderer |
| private | `MeshRenderer` | wing2MeshRenderer |
| private | `Color` | originalWingBaseColor |
| private | `Color` | originalWingFresnelColor |
| private | `Color` | lightOriginalColor |
| private | `State` | currentState |

### ItemUpgradePlayerTumbleWingsLogic.State

| Value | Name |
|-------|------|
| 0 | Intro |
| 1 | Outro |
| 2 | Active |
| 3 | Inactive |

### ItemVolume

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `itemVolume` | itemVolume |
| public | `itemSecretShopType` | itemSecretShopType |
| public | `List<GameObject>` | volumes |
| private | `ItemAttributes` | itemAttributes |

