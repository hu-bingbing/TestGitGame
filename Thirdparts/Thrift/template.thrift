/**
 * The first thing to know about are types. The available types in Thrift are:
 *
 *  bool        Boolean, one byte
 *  byte        Signed byte
 *  i16         Signed 16-bit integer
 *  i32         Signed 32-bit integer
 *  i64         Signed 64-bit integer
 *  double      64-bit floating point value
 *  string      String
 *  map<t1,t2>  Map from one type to another
 *  list<t1>    Ordered list of one type
 *  set<t1>     Set of unique elements of one type
 *
 * Did you also notice that Thrift supports C style comments?
 */
namespace csharp Config
namespace cpp CytxGame

struct PlayerAttrConfig
{
	10: i32 initHp
	20: i32 maxHp
	30: i32 moveSpeed
	40: i32 jumpSpeed
	50: i32 guardDuration
}

struct MagicPlayerAttrConfig
{
	10: i32 initMana
	20: i32 maxMana
	30: i32 initChopCost
	40: i32 ChopCostAdd
	50: i32 maxChopCost
	60: i32 blowCost
	70: i32 minFogRadius
	80: i32 maxFogRadius
	90: i32 manaTimer
	100: i32 winduration
	110: bool isFireMode
	120: i32 blowCdTime
}

struct CreatureAttrConfig
{
	5: i32 id
	6: string name
	10: i32 type
	20: i32 initHp
	30: i32 maxHp
	40: i32 patrolSpeed
	50: i32 chaseSpeed
	60: i32 attackSpeed
	70: i32 guardArea
	80: i32 attackArea
	90: i32 aiMode
	100: string assetBundle
	110: string sourceName
	120: i32 bonusStrategy
}

struct CreatureAttrConfigTable
{
	10: map<i32,CreatureAttrConfig> creatureConfigMap
}

struct PetAttrConfig
{
	10: i32 id
	20: string name
	30: i32 type
	40: i32 initHp
	50: i32 maxHp
	60: i32 aiMode
	70: string assetBundle
	80: string sourceName
	90: i32 fellowSpeed
	100: i32 chaseSpeed
	110: i32 attackSpeed
}

struct PetAttrConfigTable
{
	10: map<i32, PetAttrConfig> petConfigMap
}

struct DungeonConfig
{
	10: i32 id
	20: string name
	30: string icon
	40: string mapName
	50: list<ChildDungeonConfig> childrenList
}

struct DungeonConfigTable
{
	10: map<i32,DungeonConfig> dungeonConfigMap
}

struct ChildDungeonConfig
{
        10: i32 id
        30: string name
        40: string resourceName
}

struct TriggerConfig
{
	10: i32 id
	11: string name
	20: i32 type
	50: string assetBundle
	60: string sourceName
	70: i32 bonusStrategy
}

struct TriggerConfigTable
{
	10: map<i32,TriggerConfig> triggerConfigMap
}

struct ItemConfig
{
	10: i32 id
	20: string name
	30: i32 type
	32: i32 blood
	34: i32 mana
	36: i32 light
	40: string dataPrefab
	50: string assetBundle
	60: string sourceName
	70: string dieEffect
}

struct ItemConfigTable
{
	10: map<i32,ItemConfig> itemConfigMap
}

struct BulletConfig
{
	10: i32 id
	20: string name
	30: i32 type
	40: i32 atk
	50: i32 manaCost
	60: i32 shootStrategy
	70: string sourceName
	80: string assetBundle
	90: double speed
}

struct BulletConfigTable
{
	10: map<i32, BulletConfig> bulletConfigMap
}

struct SoundPath
{
	10: string type
	20: string path
}

struct SoundPathMap
{
	10: map<string,SoundPath> soundPathMap
}

struct ItemGeneratorConfig
{
	10: i32 id
	20: list<i32> itemIds
	25: list<i32> itemProbs
	30: i32 generateType
}

struct ItemGeneratorConfigTable
{
	10: map<i32,ItemGeneratorConfig> itemGeneratorConfigMap
}

struct VersionConfig
{
	10: string name
}
