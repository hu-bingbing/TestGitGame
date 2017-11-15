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
namespace csharp Protol

enum DownloadAssetType
{
	ConfigByte,
	Image,
	Audio,
	AssetBundle,
}
struct VersionConfigElement
{
	/** path + name */
	1: string name
	2: string sign
	3: DownloadAssetType type
}

struct VersionConfig
{	
	1: list<VersionConfigElement> versionList
}