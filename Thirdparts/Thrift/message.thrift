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

enum MessageId {

	// enum LoginServer 		= 		1
	CS_Login					=		0xd072710	// 10000
	SC_Login					=		0xf072711
	
	CS_Register					=		0xd072774
	SC_Register					=		0xf072775
	
	CS_TouristLogin				= 		0xd0727d8
	SC_TouristLogin				= 		0xf0727d9
	
	CS_Logout					= 		0xd07283c
	SC_Logout					= 		0xf07283d

	// general login server
	C_LoginGame					= 		0x5050005
	S_LoginGame 				= 		0x7050005
	
	SC_Connect 					= 		0x40a0006
	
	CS_ConnectKey 				= 		0x50a0003
	SC_ConnectKey 				= 		0x70a0003
	
	CS_TouristLoginGame			=		0xd0728a0	// 10400
	SC_TouristLoginGame			=		0xf0728a1	

	// enum LobbyServer 		= 		2
	CS_CreateInstance			=		0xd074e20	// 20000
	SC_CreateInstance			=		0xf074e21
	
	CS_InstanceList				=		0xd074e84
	SC_InstanceList				=		0xf074e85

	CS_JoinInstance				=		0xd074ee8
	SC_JoinInstance				=		0xf074ee9
	
	CS_ExitInstance				=		0xd074f4c
	SC_ExitInstance				=		0xf074f4d
	
	CS_StartGame				=		0xd074fb0
	SC_StartGame				=		0xf074fb1
	
	CS_StartGameConfirm 		= 		0xd075014
	SC_StartGameConfirm 		= 		0xf075015
	
	CS_EndGame					=		0xd075078
	SC_EndGame					=		0xf075079
	
	CS_ExitGame					=		0xd075082	// 20610
	SC_ExitGame					=		0xf075083
	
	CS_RetrieveCommand 			=		0xd0750dc
	SC_RetrieveCommand 			=		0xf0750dd

	CS_Frame					=		0xd075140
	SC_Frame					=		0xf075141
	
	CS_RandomNickname 			=		0xd0751a4
	SC_RandomNickname			=		0xf0751a5
	
	CS_SetNickname				=		0xd075208
	SC_SetNickname				=		0xf075209

	CS_SetClassType				=		0xd07526c
	SC_SetClassType				=		0xf07526d

	CS_RefreshFriendList		=		0xd0752d0
	SC_RefreshFriendList		=		0xf0752d1
	
	CS_Invitation				=		0xd075334
	SC_Invitation				=		0xf075335
	
	SC_NoticeInvitation			=		0xf075399
	
	CS_ConfirmInvitation		=		0xd0753fc
	SC_ConfirmInvitation		=		0xf0753fd
	
	SC_NoticeConfirmInvitation	=		0xf075461

	CS_CancelInvitation			=		0xd0754c4
	SC_CancelInvitation			=		0xf0754c5

	SC_NoticeCancelInvitation	=		0xf075529

	CS_ExitInvitation			=		0xd07558c
	SC_ExitInvitation			=		0xf07558d
	
	CS_ChooseLevel				=		0xd0755f0
	SC_ChooseLevel				=		0xf0755f1
	
	CS_FindUser					=		0xd075654
	SC_FindUser					=		0xf075655
	
	CS_SaveDungeonProgress		=		0xd0756b8
	SC_SaveDungeonProgress		=		0xf0756b9
	
	CS_Pause					=		0xd07571c
	SC_Pause					=		0xf07571d

	CS_Continue					=		0xd075780
	SC_Continue					=		0xf075781
	
	CS_RestartGame              =       0xd075848	// 22600
    SC_RestartGame              =       0xf075849

	CS_QuickMatch				=		0xd0758ac
	SC_QuickMatch				=		0xf0758ad
	
	CS_QuickMatchLan			=		0xd075910
	SC_QuickMatchLan			=		0xf075911
	
	CS_QuickMatchCancel			=		0xd075974
	SC_QuickMatchCancel			=		0xf075975

	CS_ReplayList				=		0xd0761a8	// 25000
	SC_ReplayList				=		0xf0761a9
	
	CS_ReplayChoose				=		0xd07620c
	SC_ReplayChoose				=		0xf07620d
	
	CS_ReplayStart				=		0xd076270
	SC_ReplayStart				=		0xf076271

	CS_ReplayEnd				=		0xd0762d4
	SC_ReplayEnd				=		0xf0762d5
	
	CS_QuickMatchClassType		=		0xd076338
	SC_QuickMatchClassType		=		0xf076339

	CS_TestProtocol				=		0xd077148	// 29001
	SC_TestProtocol				=		0xf077149
	
	CS_Ping						=		0xd0771ac	// 29100
	SC_Ping						=		0xf0771ad
}

struct CSLogin
{
	10: string userName
	20: string password
}

struct SCLogin
{
	10: i32 result
	20: profile.UserData userData
}

struct CSRegister
{
	10: string userName
	20: string password
}

struct SCRegister
{
	10: i32 result
	20: profile.UserData userData
}

struct CSTouristLogin
{
	10: string deviceId
}

struct SCTouristLogin
{
	10: i32 result
	20: profile.UserData userData
}

struct CSLogout
{
}

struct SCLogout
{
	10: i32 result
}

// general login server
struct CLoginGame {
	10: i32 accountId
	20: string sessionKey
}

struct SLoginGame {
	10: bool state
	20: optional string error
	30: optional profile.AccountData account
}

struct CSTouristLoginGame
{
	10: string deviceId
}

struct SCTouristLoginGame
{
	10: i32 result
	20: profile.UserData userData
}

struct CSCreateInstance
{
	10: string instanceName	
}

struct SCCreateInstance
{
	10: i32 result
	20: profile.InstanceData instanceData
}

struct CSInstanceList
{
	10: i32 startIndex
	20: i32 count
}

struct SCInstanceList
{
	10: i32 result
	20: list<profile.InstanceData> instanceList
}

struct CSJoinInstance
{
	10: i32	instanceId
	20: string instanceName
}

struct SCJoinInstance
{
	10: i32 result
	20: profile.InstanceData instanceData
}

struct CSExitInstance
{
}

struct SCExitInstance
{
	10: i32 result
	20: profile.PlayerData player 
}

struct CSStartGame
{
	10: i32 levelId
	20: bool isContinue
}

struct SCStartGame
{
	10: i32 result
	20: i32 levelId
	25: bool isContinue
	30: profile.LevelData levelData
}

struct CSStartGameConfirm
{
}

struct SCStartGameConfirm
{
	10: i32 result
}

struct CSEndGame
{
	10: i32 levelId
	20: profile.LevelData levelData
	30: bool isWin
}

struct SCEndGame
{
	10: i32 result
	20: i32 endUserId
	30:	bool isWin			// true : win game ; false : fail game
	40: i32 levelId
	50: profile.LevelData levelData
}

struct CSExitGame
{
}

struct SCExitGame
{
	10: i32 result
	20: bool isNormalEnd	// true : normal end ; false : not normal end
}

struct CSRetrieveCommand
{
	10:	i32 playerId
	20:	list<profile.CommandData> dataList
	30:	double timestamp
}

struct SCRetrieveCommand
{
	10:	list<profile.CommandData> dataList
}

struct CSFrame
{
	10: profile.FrameData frameData
}

struct SCFrame
{
	10: profile.FrameData frameData
}

struct CSRandomNickname
{
}

struct SCRandomNickname
{
	10: i32 result
	20: string nickname
}

struct CSSetNickname
{
	10: string nickname
}

struct SCSetNickname
{
	10: i32 result
	20: string nickname
}
 
struct CSSetClassType
{
	10: profile.ClassType classType
}

struct SCSetClassType
{
	10: i32 result
	20: profile.ClassType classType
}

struct CSRefreshFriendList
{
}

struct SCRefreshFriendList
{
	10: i32 result
	20: map<i32, profile.PlayerData> playerMap
}

struct CSInvitation
{	
	10: string nickname
}

struct SCInvitation
{
	10: i32 result
}

struct SCNoticeInvitation
{
	10: profile.RoleData roleData
}

struct CSConfirmInvitation
{
}

struct SCConfirmInvitation
{
	10: i32 result
}

struct SCNoticeConfirmInvitation
{
	10: profile.RoleData roleData
}

struct CSCancelInvitation
{
}

struct SCCancelInvitation
{
	10: i32 result
}

struct SCNoticeCancelInvitation
{
	10: profile.RoleData roleData
}

struct CSExitInvitation
{
}

struct SCExitInvitation
{
	10: i32 result
}

struct CSChooseLevel
{
	10: i32 levelId
}

struct SCChooseLevel
{
	10: i32 result
	20: i32 levelId
}

struct CSFindUser
{
	10: string nickname
}

struct SCFindUser
{
	10: i32 result
	20: profile.PlayerData player 
}

struct CSSaveDungeonProgress
{
	10: i32 levelId
	20: profile.LevelData levelData
}

struct SCSaveDungeonProgress
{
	10: i32 result
}

struct CSPause
{
}

struct SCPause
{
	10: i32 result
}

struct CSContinue
{
}

struct SCContinue
{
	10: i32 result
}

struct CSRestartGame
{
}

struct SCRestartGame
{
	10: i32 result
	20: i32 levelId
	30: profile.LevelData levelData
}

struct CSQuickMatch
{
	10: i32 userId
}

struct SCQuickMatch
{	
	10: i32 result
	20: bool isHostRole
	30: profile.RoleData hostRoleData
	40: profile.RoleData guestRoleData
}

struct CSQuickMatchLan
{
	10: list<i32> userId
}

struct SCQuickMatchLan
{	
	10: i32 result
	20: bool isHostRole
	30: profile.RoleData hostRoleData
	40: profile.RoleData guestRoleData
}

struct CSQuickMatchCancel
{

}

struct SCQuickMatchCancel
{	
	10: i32 result
	20: profile.PlayerData player 
}

struct CSReplayList
{
	10: i32 userId
}
	
struct SCReplayList
{
	10: i32 result
	20: list<profile.ReplayData> replayList
}

struct CSReplayChoose
{
	10: i32 userId
	20: i64 timeData
}

struct SCReplayChoose
{
	10: i32 result
	20: profile.LevelData levelData
	30: profile.ClassType classType 
	40: i32 levelId
	50: i32 endFrameIndex
}

struct CSReplayStart
{
}

struct SCReplayStart
{
	10: i32 result
}

struct CSReplayEnd
{
}

struct SCReplayEnd
{
	10: i32 result
}
	
struct CSQuickMatchClassType
{
	10: profile.ClassType classType
}

struct SCQuickMatchClassType
{
	10: i32 result
	20: profile.ClassType classType
}

struct CSTestProtocol
{
	10: i32 levelId
	20: profile.LevelData levelData
}

struct SCTestProtocol
{
	10: i32 result
}

struct CSPing
{
}

struct SCPing
{
	10: i32 result
}


