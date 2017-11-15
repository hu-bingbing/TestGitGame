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
namespace cpp CytxGame

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

enum UserLoginMode {
	EUnLogin = 0,
	EAccount,
	ETourist
}

enum ClassType
{
	None,
	Warrior,
	Wizzard
}

enum GameState
{
	Offline,
	Waiting,
	Playing
}

struct PlayerData
{
	10: i32 userId
	20: string nickname
	30: ClassType classType
	40: GameState gameState
	50: i32 levelDataBest
}

struct ServerData
{
	10: i32 connId
}

struct PetData
{
	10: i32 petId
	20: i32 health
}

struct LevelData
{
	10: i32 levelProgress
	20: list<PetData> petDataList
	30: i32 restMana
}

struct RoleData
{
	10: string nickname
	20: ClassType classType
	110: GameState gameState
	120: i32 levelDataBest
	130: map<i32, LevelData> levelDataMap
	210: map<i32, PlayerData> playerMap
}

struct UserData
{
	10: i32 userId
	20: string userAccount
	30: string userPassword
	40: i32 userLoginMode		// enum UserLoginMode
	50:	bool alreadyRegist		// true: already registered   false: not registered
	60: RoleData roleData
	70: ServerData serverData
}

struct InstanceData
{
	10: i32 instanceId
	20: i32 masterUserId
	30: string instanceName
	40: map<i32, PlayerData> playerMap
	50:	i32 levelId
	60: LevelData levelData
}

struct UnitSyncData
{
	10:	i32 uid
	20:	Position pos
	30: Rotation rot
	40: Position dir
}

struct UnitSyncDataList
{
	10:	list<UnitSyncData> dataList
}

enum CommandType
{
	Data,
	Instantiate,
}

enum CommandTargetType
{
	Server = 0,
	Others = 1,
	OthersBuffered = 2,
	All = 3,
	AllBuffered = 4,
}

struct CommandData
{
	10:	CommandType commandType
	20: i16 dataLength
	30:	binary data
	40: CommandTargetType target
}

enum FrameCmdType
{
	Move,
	Jump
}

struct FrameCommand
{
	10:	FrameCmdType frameCmdType
	20:	i32 playerId
	30: i16 dataLength
	40: binary data
}

struct FrameData
{
	10: i32 frameIndex
	20: list<FrameCommand> commandList
}

struct ReplayData
{
	20: i64 timeData
	30: ClassType classType 
	40: i32 levelId
	50: i32 levelProgress
}

struct AccountData{
	10: i32 id
	20: string sessionKey
	30: string channel
	40: string openId
	50: i64 lastLoginTime
}



// result
enum CSLoginResult {
	ESuccess = 0,
	EAccountNotExist,
	EAccountError,
	EPasswordError,
	EAccountAlreadyLogged,
	ELandingAccount,
}

enum CSRegisterResult {
	ESuccess = 0,
	EAccountError,
	EPasswordError,
	EAccountAlreadyExist,
	ELandingAccount,
}

enum CSTouristResult {
	ESuccess = 0,
	EAccountAlreadyLogged,
}

enum CSRandomNicknameResult {
	ESuccess = 0,
}

enum CSSetNicknameResult {
	ESuccess = 0,
	ENicknameLengthError,
	ENicknameAlreadyExist,
	EFaild,
}

enum CSSetClassTypeResult {
	ESuccess = 0,
	EAlreadySetClassType,
}

enum CSRefreshFriendListResult {
	ESuccess = 0,
}

enum CSInvitationResult {
	ESuccess = 0,
	ETargetNotOnline,
	ETargetNotWaiting,
	ETargetClassTypeWizzard,
	ETargetAlreadyInvited,
	EAlreadyInvitation,
}

enum CSConfirmInvitationResult {
	ESuccess = 0,
}

enum CSCancelInvitationResult {
	ESuccess = 0,
}

enum CSExitInvitationResult {
	ESuccess = 0,
}

enum CSChooseLevelResult {
	ESuccess = 0,
}

enum CSFindUserResult {
	ESuccess = 0,
	ETargetClassTypeWizzard,
}

enum CreateInstanceResult {
	ESuccess = 0,
}

enum InstanceListResult {
	ESuccess = 0,
}

enum JoinInstanceResult {
	ESuccess = 0,
	ENotFindInstance,
}

enum SaveDungeonProgressResult {
	ESuccess = 0,
}

enum PauseResult {
	ESuccess = 0,
}

enum ContinueResult {
	ESuccess = 0,
}

enum QuickMatchResult {
	ESuccess = 0,
	ETargetNotOnline = 1,
	ETargetNotWaiting = 2,
}

enum StartGameResult {
	ESuccess = 0,
	ELastLevel,
}

enum StartGameConfirmResult {
	ESuccess = 0,
	EConfirmTimeout,
}