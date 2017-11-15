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
 
include "cs_struct.thrift"

namespace csharp Protol

/*	
	//以下是gateway需要同时发给LoginSever和RoomServer的协议。
		SC_ClientClose
	
	//以下是 gateway 需要转发给 RoomServer 的协议
		100031
		100041
		100011
*/

enum MessageId {

	//在100以下为服务器和客户端的错误码协议//	
	SC_ClientClose		=		7			
	
	

	//客户端发给LoginServer协议//
	CS_Login			=		100010
	SC_Login			=		100011
	CS_Register			=		100020
	SC_Register			=		100021
	CS_TouristLogin		= 		100030
	SC_TouristLogin		= 		100031
	CS_Logout			= 		100040
	SC_Logout			= 		100041
	
	
	
	//客户端发给RoomServer协议//
	CS_CreateRoom		=		101010
	SC_CreateRoom		=		101011
	
	CS_JoinRoom			=		101030
	SC_JoinRoom			=		101031
	CS_ExitRoom			=		101040
	SC_ExitRoom			=		101041
	
	CS_StartGame		=		101050
	SC_StartGame		=		101051
	
	SC_Frame 			=		101070
	
	CS_Input			=		101080
	SC_Input			=		101081
	
	CS_ExitGame			=		101090	//退出游戏世界
	SC_ExitGame			=		101091
	CS_StartGameConfirm = 		101100
	SC_StartGameConfirm = 		101101
	CS_AddFriend		=		101110
	SC_AddFriend		=		101111
	CS_DelFriend		=		101120
	SC_DelFriend		=		101121
	CS_FindByNickName	=		101130
	SC_FindByNickName	=		101131
	CS_GetFriendList	=		101140
	SC_GetFriendList	=		101141
	CS_GetFriendRoomList 	= 	101150
	SC_GetFriendRoomList 	= 	101151
	CS_GetRoomList			= 	101160
	SC_GetRoomList			= 	101161
		
	SC_RefreshReplayData	= 	101170
	
	CS_UploadVoice		=  		101180
	SC_UploadVoice		=  		101181
	CS_GetVoice			=  		101190
	SC_GetVoice			=  		101191	
	CS_RandomNickname	= 		101200
	SC_RandomNickname	= 		101201	
	CS_SetNickname		= 		101210
	SC_SetNickname		= 		101211
	
	SC_UpdateFriendData	= 		101220
	
	SC_FriendOnlineInfo	= 		101230

	CS_StartRecord		=  	101240
	SC_StartRecord		=  	101241
	CS_EndRecord		=  	101250
	SC_EndRecord		=  	101251
	CS_EndPlayRecord	=  	101260
	SC_EndPlayRecord	=  	101261






	//客户端发给ReplayServer协议//
	CS_GetReplay		= 		102010
	SC_GetReplay		= 		102011
	CS_GetReplayInfo 	= 		102020
	SC_GetReplayInfo	= 		102021
}

struct CSLogin
{
	10: string userName
	20: string password
}

struct SCLogin
{
	10: i32 result
	20: cs_struct.UserData userData
}

struct CSRegister
{
	10: string userName
	20: string password
	30: string email
}

struct SCRegister
{
	10: i32 result
}

struct CSTouristLogin
{
	10: string deviceId
}

struct SCTouristLogin
{
	10: i32 result
	20: cs_struct.UserData userData
}

struct CSLogout
{
}

struct SCLogout
{
	10: i32 result
}

struct CSDisconnect
{
}

struct SCDisconnect
{
	10: i32 result
}

//房间销毁的时候，给原来房间的所有玩家发这个协议
struct SCRefreshReplayData
{
	10: cs_struct.ReplayData replayData
}

struct SCFrame
{
	10: cs_struct.FrameData frameData
}

struct CSInput
{
	10: cs_struct.CommandData commandData
}

struct SCInput
{
}

struct CSCreateRoom
{
	10: string roomName	
}

struct SCCreateRoom
{
	10: i32 result
	20: i32	roomId
	30:	string roomName
}

struct CSRoomList
{
}

struct SCRoomList
{
	10: i32 result
	20: list<cs_struct.RoomData> roomList
}

struct CSJoinRoom
{
	10: string roomName
	20: i32	roomId
}

struct CSExitRoom
{
}

struct SCJoinRoom
{
	10: i32 result
	20: list<cs_struct.PlayerData> playerList	
	30: cs_struct.PlayerData joinPlayer	// 新进的玩家
}

struct SCExitRoom
{
	10: i32 result
	20: list<cs_struct.PlayerData> playerList
	30: cs_struct.PlayerData exitPlayer //退出的玩家
}
	
struct CSStartGame
{
}


struct SCStartGame
{
	10: i32 result
}

struct CSRandomNickname
{
}

struct SCRandomNickname
{
	10: string nickname
}

struct CSSetNickname
{
	10: string nickname
	30: i32 iconId
}

struct SCSetNickname
{
	10: i32 result
	20: cs_struct.PlayerData playerData
}

struct SCUpdateFriendData
{
	10: cs_struct.PlayerData friendData
}

struct CSReconnect
{
	10: i32 keyReconnect
}

struct SCReconnect
{
	10: i32 keyReconnect
}

struct CSAddFriend
{
	10: string nickname
}

struct SCAddFriend
{
	10: i32 result
	20: cs_struct.PlayerData friendInfo	//好友
}

struct CSDelFriend
{
	10: string nickname
}

struct SCDelFriend
{
	10: i32 result
	20: cs_struct.PlayerData friendInfo	//好友
}

struct CSFindByNickName
{
	10: string nickname
}

struct SCFindByNickName
{
	10: list<cs_struct.PlayerData> friendList
}

struct CSGetFriendList
{
	10: string userName
}

struct SCGetFriendList
{
	10: list<cs_struct.PlayerData> friendList
}

struct CSStartGameConfirm
{
}

struct SCStartGameConfirm
{
}

struct CSGetReplayInfo
{
	10: i32 roomId	
}

struct SCGetReplayInfo
{
	10: i32 lastFrameIndex
	20: i32 influenceFrameCount
	30: list<cs_struct.PlayerData> playerList
	40: list<i32> playerExitFrameList
}

struct CSGetReplay
{
	10: i32 roomId
	20: i32 influenceStartIndex
	30: i32 influenceCount	
}

struct SCGetReplay
{
	10: list<cs_struct.FrameData> frameList
}

struct CSGetFriendRoomList
{
	10: i32 startIndex
	20: i32 count
}

struct SCGetFriendRoomList
{
	10: list<cs_struct.RoomInfo> roomList
	20: i32 totalCount
}

struct CSGetRoomList
{
	10: i32 startIndex
	20: i32 count
}

struct SCGetRoomList
{
	10: list<cs_struct.RoomInfo> roomList
	20: i32 totalCount
}

struct CSExitGame
{
}

struct SCExitGame
{
	10: i64 userId
}

struct CSUploadVoice
{
	10: i32 index
	20: string url
}

struct SCUploadVoice
{
	10: i32 result
}

struct CSGetVoice
{
	10: i32 roomId
	20: i32 index
}

struct SCGetVoice
{
	10: string url
}

struct SClientClose
{
}

struct SCFriendOnlineInfo
{
	10: bool onlineStatus
	20: cs_struct.PlayerData playerData
}

struct CSStartRecord
{
}

struct SCStartRecord
{
	10: i32 result
	20: i64 userId
}
	
struct CSEndRecord
{
	10: string url
	20: double timeLength
}

struct SCEndRecord
{
	10: string url
	20: double timeLength
}

struct CSEndPlayRecord
{
}

struct SCEndPlayRecord
{
	10: i32 result
}
