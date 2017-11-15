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

// ENUM
enum StartGameResult {
	ESuccess = 0,
	ERoomGameIsRunning,
}

enum CreateRoomResult {
	ESuccess = 0,
	ECreateRoomFail,
	ECreateRoomNotOkStatus,
}

enum JoinRoomResult {
	ESuccess = 0,
	EJoinRoomFail,
	EAlreadyInRoom,
	ENotInRoom,
}

enum ExitRoomResult {
	ESuccess = 0,
	EExitRoomFail,
}

enum AddFriendResult {
	ESuccess = 0,
	EAddFriendFail,
	EDoNotAddSelf,
	EAddFriendRepeat,
}

enum DelFriendResult {
	ESuccess = 0,
	EDelFriendFail,	
	EDoNotDelSelf,
	EDelFriendNotExist,
}

enum ReqDlVoiceResResult {
	ESuccess = 0,
	EReqDlVoiceResFail,
	EUpdateVoiceResFail,	
}

enum SetNicknameResult {
	ESuccess = 0,
	ESetNicknameFail,
	ENicknameIsEmpty,
	EIconIdUndefined,
	ENicknameOverLength,
}

enum CSLoginResult {
	ESuccess = 0,
	EAccountNotExist,
	EAccountError,
	EPasswordError,
	EAccountAlreadyLogged,
}

enum CSRegisterResult {
	ESuccess = 0,
	EAccountError,
	EPasswordError,
	EAccountAlreadyExist,
}

enum CSTouristResult {
	ESuccess = 0,
	EAccountAlreadyLogged,
}

enum CSDisconnectResult {
	ESuccess = 0,
}

enum LDLoginResult {
	ESuccess = 0,
	EAccountNotExist,
	EPasswordError,
}

enum LDRegisterResult {
	ESuccess = 0,
	EAccountAlreadyExist,
}

enum LDTouristResult {
	ESuccess = 0,
}

enum LDDisconnectResult {
	ESuccess = 0,
}

enum RDAddFriendResult {
	ESuccess = 0,
	EUserNotExist,
	ERoleNotExist,
	EUserError,
}

enum RDDelFriendResult {
	ESuccess = 0,
	EUserError,
}

enum RDFindByNickNameResult {
	ESuccess = 0,
	EUserError,
}

enum RDGetFriendListResult {
	ESuccess = 0,
	EUserError,
	ERoleError,
}

enum RDCreateRoomResult {
	ESuccess = 0,
	EUserError,
}

enum RDGetReplayResult {
	ESuccess = 0,
	ERoomError,
}

enum RDGetReplayInfoResult {
	ESuccess = 0,
	ERoomError,
}

enum RDGetVoiceResult {
	ESuccess = 0,
	ERoomError,
}

enum RDRandomNicknameResult {
	ESuccess = 0,
}

enum RDSaveFrameResult {
	ESuccess = 0,
	ERoomError,
}

enum RDSaveRoomDataResult {
	ESuccess = 0,
	ERoomError,
}

enum RDSetNicknameResult {
	ESuccess = 0,
	EUserError,
	ENicknameAlreadyExist,
}

enum StartRecordResult {
	ESuccess = 0,
	ERecorderFail,
	ERecorderBusy,	
}

enum EndPlayRecordResult {
	ESuccess = 0,
	EPlayRecordFail,
}










enum UserLoginMode {
	EUnLogin = 0,
	EAccount,
	ETourist
}

enum RoomStatus {
	STATUS_CLOSE = 0,
	STATUS_FULL,
	STATUS_OK,
	STATUS_START,
	STATUS_READY,
	STATUS_RUNNING,
	STATUS_NONE
}

// STRUCT
struct Position{
	10: double x
	20: double y
	30: double z
}

struct Rotation{
	10: double x
	20: double y
	30: double z
	40: double w
}

// simple UserData
struct PlayerData
{
	10: i64 userId
	20: string userName
	25: i32 roleId
	30: string nickname
	40: i32 iconId
}
	
struct RoleData
{
	1:	i32 roleId
	10: string nickname
	20: bool isSetNickname		// true:已设置  false:未设置
	30: i32 iconId				// 0: 未设置
	100: list<PlayerData> friendList
	110: list<bool> friendOnlineStatusList
}

struct ReplayData
{
	10: i32 roomId
	20: i64 createTime 	//2016/9/9
}

struct UserData
{
	10: i32 createTimeSec
	20: i32 createTimeMsec
	30: i32 lastLoginSec
	40: i32 lastLoginMsec
	50: i32 totalOnlineTime
	
	60: i64 userId
	70: string userAccount
	71: string userPassword
	80: string userEmail
	90: i32 userLoginMode		// UserLoginMode
	95: i32 roleId

	10000: list<RoleData> roleData

	20000: list<ReplayData> replayList
}

struct CommandData
{
	10: i32 type
	11: i32 localPlayerId
	12: i16 dataLength
	20: binary data	
}

struct FrameData
{
	10: i32 frameIndex
	20: list<CommandData> commandList
}

struct VoiceData
{
	10: i32 index
	20: string url
}

struct RoomData
{
	10: i64 createTimeSec	//2016/9/9
	30: i64 destoryTimesec	//2016/9/9
	
	50: i32 id
	60: string identity
	70: map<i64, PlayerData> playerMap
	71: map<i64, i32> playerExitTimeMap	//x		
	81: i32 lastFrameIndex;	//最大帧
	90: i64 masterUserId
	
	100: map<i32, VoiceData> voiceMap //VoiceData.index :VoiceData
}

struct RoomInfo
{
	10: i32 roomId
	20: string roomName
	30: i32 playerCount
}