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
namespace csharp AutoGen

struct TileConfig
{
	10: string name
	20: i32 width
	30: i32 height
	40: i32 depth
	50: string resource
	60: i32 type1
	70: i32 type2
	80: string func
	90: double rad
	100: bool overlapFog
}

struct TileConfigList
{
	10: list<TileConfig> tileList;
}

enum TileType
{
	None = -1,
	Static,
	Trigger,
	NPC,
	PlayerStart,
	SavePoint,
}

struct TileData
{
	10: i32 id
	20: string name
	30: string resource
	40: double x
	50: double y
	60: double z
	70: double depth
	80: TileType type
}

struct ChunkData
{
	5: i32 id
	10: double x
	20: double y
	30: double z
	40: list<TileData> tiles
}

struct MapData
{
	10: i32 id
	20: string name
	30: list<ChunkData> chunks
}