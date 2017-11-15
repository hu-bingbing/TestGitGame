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
 
include "profile.thrift"

namespace csharp AutoGen
namespace cpp CytxGame

struct CmdInstantiate
{
	10:	i32 uid
	20: i32 owner
	30: string resource
	40: profile.Position pos
	50: profile.Rotation rot
}

struct CmdTakeDamage
{
	10: i32 amount
	20: i32 causer
}

struct CmdStruct
{
	10: i32 type
	20: i32 argv1
	30: i32 argv2
}