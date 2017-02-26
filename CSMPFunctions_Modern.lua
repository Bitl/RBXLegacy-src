rbxversion = version();
print("ROBLOX Client version '" .. rbxversion .. "' loaded.");
settings().Rendering.FrameRateManager = 2;

-- TODO: Find out why this is glitching
game:GetService("CoreGui").DescendantAdded:connect(function(Child)
	if (Child:IsA("BaseScript")) and (Child.Name~="SubMenuBuilder") and (Child.Name~="ToolTipper") and (Child.Name~="MainBotChatScript") then
		Child:Remove();
		-- print("Deb:",Child);
	end
end)

coroutine.resume(coroutine.create(function()
	while not game:GetService("CoreGui"):FindFirstChild("RobloxGui") do game:GetService("CoreGui").ChildAdded:wait(); end
	game:GetService("CoreGui").RobloxGui.TopLeftControl:Remove();
end))

-- Load the fixed resizer CoreScript

coroutine.resume(coroutine.create(function()
	loadstring('\108\111\99\97\108\32\67\111\114\101\71\117\105\32\61\32\103\97\109\101\58\71\101\116\83\101\114\118\105\99\101\40\34\67\111\114\101\71\117\105\34\41\59\10\119\104\105\108\101\32\110\111\116\32\67\111\114\101\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\82\111\98\108\111\120\71\117\105\34\41\32\100\111\10\9\67\111\114\101\71\117\105\46\67\104\105\108\100\65\100\100\101\100\58\119\97\105\116\40\41\59\10\101\110\100\10\108\111\99\97\108\32\82\111\98\108\111\120\71\117\105\32\61\32\67\111\114\101\71\117\105\46\82\111\98\108\111\120\71\117\105\59\10\108\111\99\97\108\32\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\34\41\10\108\111\99\97\108\32\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\34\41\10\108\111\99\97\108\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\84\111\112\76\101\102\116\67\111\110\116\114\111\108\34\41\10\108\111\99\97\108\32\66\117\105\108\100\84\111\111\108\115\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\66\117\105\108\100\84\111\111\108\115\34\41\10\102\117\110\99\116\105\111\110\32\109\97\107\101\89\82\101\108\97\116\105\118\101\40\41\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\10\105\102\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\32\116\104\101\110\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\32\101\110\100\10\105\102\32\66\117\105\108\100\84\111\111\108\115\32\116\104\101\110\32\66\117\105\108\100\84\111\111\108\115\46\70\114\97\109\101\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\32\101\110\100\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\48\44\48\44\49\44\45\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\88\44\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\101\110\100\10\102\117\110\99\116\105\111\110\32\109\97\107\101\88\82\101\108\97\116\105\118\101\40\41\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\10\105\102\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\32\116\104\101\110\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\32\101\110\100\10\105\102\32\66\117\105\108\100\84\111\111\108\115\32\116\104\101\110\32\66\117\105\108\100\84\111\111\108\115\46\70\114\97\109\101\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\32\101\110\100\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\48\44\48\44\49\44\45\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\88\44\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\101\110\100\10\108\111\99\97\108\32\102\117\110\99\116\105\111\110\32\114\101\115\105\122\101\40\41\10\105\102\32\82\111\98\108\111\120\71\117\105\46\65\98\115\111\108\117\116\101\83\105\122\101\46\120\32\62\32\82\111\98\108\111\120\71\117\105\46\65\98\115\111\108\117\116\101\83\105\122\101\46\121\32\116\104\101\110\10\109\97\107\101\89\82\101\108\97\116\105\118\101\40\41\10\101\108\115\101\10\109\97\107\101\88\82\101\108\97\116\105\118\101\40\41\10\101\110\100\10\101\110\100\10\82\111\98\108\111\120\71\117\105\46\67\104\97\110\103\101\100\58\99\111\110\110\101\99\116\40\102\117\110\99\116\105\111\110\40\112\114\111\112\101\114\116\121\41\10\105\102\32\112\114\111\112\101\114\116\121\32\61\61\32\34\65\98\115\111\108\117\116\101\83\105\122\101\34\32\116\104\101\110\10\119\97\105\116\40\41\10\114\101\115\105\122\101\40\41\10\101\110\100\10\101\110\100\41\10\119\97\105\116\40\41\10\114\101\115\105\122\101\40\41\10')()
end))

HeadColor=BrickColor.DarkGray();
TorsoColor=BrickColor.DarkGray();
LArmColor=BrickColor.DarkGray();
LLegColor=BrickColor.DarkGray();
RArmColor=BrickColor.DarkGray();
RLegColor=BrickColor.DarkGray();

function PlayerColorize()
	PlayerColorPattern = math.random(5);
	if (PlayerColorPattern==1) then
		HeadColor=BrickColor.random();
		TorsoColor=BrickColor.random();
		LArmColor=BrickColor.random();
		LLegColor=BrickColor.random();
		RArmColor=BrickColor.random();
		RLegColor=BrickColor.random();
	elseif (PlayerColorPattern==2) then
		local pantsColor=BrickColor.random();
		local shirtColor=BrickColor.random();
		local armsColor=BrickColor.random();
		HeadColor=BrickColor.random();
		TorsoColor=shirtColor;
		LArmColor=armsColor;
		LLegColor=pantsColor;
		RArmColor=armsColor;
		RLegColor=pantsColor;
	elseif (PlayerColorPattern==3) then
		local pantsColor=BrickColor.random();
		local shirtColor=BrickColor.random();
		HeadColor=BrickColor.random();
		TorsoColor=shirtColor;
		LArmColor=shirtColor;
		LLegColor=pantsColor;
		RArmColor=shirtColor;
		RLegColor=pantsColor;
	elseif (PlayerColorPattern==4) then
		local pantsColor=BrickColor.random();
		local shirtColor=BrickColor.random();
		local fleshColor=BrickColor.random();
		HeadColor=fleshColor;
		TorsoColor=shirtColor;
		LArmColor=fleshColor;
		LLegColor=pantsColor;
		RArmColor=fleshColor;
		RLegColor=pantsColor;
	elseif (PlayerColorPattern==5) then
		HeadColor=BrickColor.random();
		TorsoColor=BrickColor.random();
		LArmColor=BrickColor.Black();
		LLegColor=BrickColor.Black();
		RArmColor=BrickColor.Black();
		RLegColor=BrickColor.Black();
	end
end

function PlayerNoobify()
	PlayerColorPattern = math.random(3);
	if (PlayerColorPattern==1) then
		HeadColor=BrickColor.Yellow();
		TorsoColor=BrickColor.Blue();
		LArmColor=BrickColor.Yellow();
		LLegColor=BrickColor.new("Br. yellowish green");
		RArmColor=BrickColor.Yellow();
		RLegColor=BrickColor.new("Br. yellowish green");
	elseif (PlayerColorPattern==2) then
		HeadColor=BrickColor.new("Cool yellow");
		TorsoColor=BrickColor.random();
		LArmColor=BrickColor.new("Cool yellow");
		LLegColor=BrickColor.new("Pastel Blue");
		RArmColor=BrickColor.new("Cool yellow");
		RLegColor=BrickColor.new("Pastel Blue");
	elseif (PlayerColorPattern==3) then
		HeadColor=BrickColor.White();
		TorsoColor=BrickColor.random();
		LArmColor=BrickColor.White();
		LLegColor=BrickColor.new("Medium blue");
		RArmColor=BrickColor.White();
		RLegColor=BrickColor.new("Medium blue");
	end
end

function CSServer(Port,BodyColors)
	assert((type(Port)~="number" or tonumber(Port)~=nil or Port==nil),"CSRun Error: Port must be nil or a number.");
	local NetworkServer=game:GetService("NetworkServer");
	pcall(NetworkServer.Stop,NetworkServer);
	NetworkServer:Start(Port);
	game:GetService("Players").PlayerAdded:connect(function(Player)
		print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' added");
		Player:LoadCharacter();
		Player.CharacterAdded:connect(function(char)
			if (BodyColors == true) then
				PlayerColorize();
			else
				PlayerNoobify();
			end
			char['Head'].BrickColor = HeadColor;
			char['Torso'].BrickColor = TorsoColor;
			char['Left Arm'].BrickColor = LArmColor;
			char['Left Leg'].BrickColor = LLegColor;
			char['Right Arm'].BrickColor = RArmColor;
			char['Right Leg'].BrickColor = RLegColor;
		end)
		Player.Changed:connect(function(Property)
			if (Property=="Character") and (Player.Character~=nil) then
				local Character=Player.Character;
				local Humanoid=Character:FindFirstChild("Humanoid");
				if (Humanoid~=nil) then
					Humanoid.Died:connect(function() delay(5,function() Player:LoadCharacter() end) end)
				end
			end
		end)
	end)
	game:GetService("Players").PlayerRemoving:connect(function(Player)
		print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' leaving")	
	end)
	game:GetService("RunService"):Run();
	pcall(function() game.Close:connect(function() NetworkServer:Stop(); end) end);
	-- ChildAdded is being a retard. Sorry for inefficient code.
	--[[while wait(0.1) do
		print("OMG",#game.NetworkServer:children())
		for Index,Child in pairs(NetworkServer:GetChildren()) do
			if (Child.className == "") then
				IncommingConnection(nil, Child);
			end
		end
	end]]
	NetworkServer.IncommingConnection:connect(IncommingConnection);
end

function CSConnect(UserID,ServerIP,ServerPort,PlayerName,OutfitID,ColorHash,PantsID,ShirtID,TShirtID,Hat1ID,Hat2ID,Hat3ID,Hat1Version,Hat2Version,Hat3Version,Ticket)
	pcall(function() game:SetPlaceID(-1, false) end);
	pcall(function() game:GetService("Players"):SetChatStyle(Enum.ChatStyle.ClassicAndBubble) end);
	
	pcall(function()
		game:GetService("GuiService").Changed:connect(function()
			pcall(function() game:GetService("GuiService").ShowLegacyPlayerList=true; end);
			pcall(function() game.CoreGui.RobloxGui.PlayerListScript:Remove(); end);
			pcall(function() game.CoreGui.RobloxGui.PlayerListTopRightFrame:Remove(); end);
			pcall(function() game.CoreGui.RobloxGui.BigPlayerListWindowImposter:Remove(); end);
			pcall(function() game.CoreGui.RobloxGui.BigPlayerlist:Remove(); end);
		end);
	end)
	game:GetService("RunService"):Run();
	assert((ServerIP~=nil and ServerPort~=nil),"CSConnect Error: ServerIP and ServerPort must be defined.");
	local function SetMessage(Message) game:SetMessage(Message); end
	local Visit,NetworkClient,PlayerSuccess,Player,ConnectionFailedHook=game:GetService("Visit"),game:GetService("NetworkClient");

	local function GetClassCount(Class,Parent)
		local Objects=Parent:GetChildren();
		local Number=0;
		for Index,Object in pairs(Objects) do
			if (Object.className==Class) then
				Number=Number+1;
			end
			Number=Number+GetClassCount(Class,Object);
		end
		return Number;
	end

	local function RequestCharacter(Replicator)
		local Connection;
		Connection=Player.Changed:connect(function(Property)
			if (Property=="Character") then
				game:ClearMessage();
			end
		end)
		SetMessage("Requesting character...");
		Replicator:RequestCharacter();
		SetMessage("Waiting for character...");
	end

	local function Disconnection(Peer,LostConnection)
		SetMessage("You have lost connection to the game");
	end

	local function ConnectionAccepted(Peer,Replicator)
		Replicator.Disconnection:connect(Disconnection);
		local RequestingMarker=true;
		game:SetMessageBrickCount();
		local Marker=Replicator:SendMarker();
		Marker.Received:connect(function()
			RequestingMarker=false;
			RequestCharacter(Replicator);
		end)
		while RequestingMarker do
			Workspace:ZoomToExtents();
			wait(0.5);
		end
	end

	local function ConnectionFailed(Peer, Code, why)
		SetMessage("Failed to connect to the Game. (ID="..Code.." ["..why.."])");
	end

	pcall(function() settings().Diagnostics:LegacyScriptMode(); end);
	pcall(function() game:SetRemoteBuildMode(true); end);
	SetMessage("Connecting to server...");
	NetworkClient.ConnectionAccepted:connect(ConnectionAccepted);
	ConnectionFailedHook=NetworkClient.ConnectionFailed:connect(ConnectionFailed);
	NetworkClient.ConnectionRejected:connect(function()
		pcall(function() ConnectionFailedHook:disconnect(); end);
		SetMessage("Failed to connect to the Game. (Connection rejected)");
	end)

	pcall(function() NetworkClient.Ticket=Ticket or ""; end) -- 2008 client has no ticket :O
	PlayerSuccess,Player=pcall(function() return NetworkClient:PlayerConnect(UserID,ServerIP,ServerPort) end);

	if (not PlayerSuccess) then
		SetMessage("Failed to connect to the Game. (Invalid IP Address)");
		NetworkClient:Disconnect();
	end

	if (not PlayerSuccess) then
		local Error,Message=pcall(function()
			Player=game:GetService("Players"):CreateLocalPlayer(UserID);
			NetworkClient:Connect(ServerIP,ServerPort);
		end);
		if (not Error) then
			SetMessage("Failed to connect to the Game.");
		end
	end
	pcall(function() Player:SetUnder13(false) end);
	pcall(function() Player:SetMembershipType(Enum.MembershipType.BuildersClub) end);
	pcall(function() Player:SetAccountAge(365) end);
	Player:SetSuperSafeChat(false);
	if (OutfitID and OutfitID ~= 0) then
		Player.CharacterAppearance="http://www.roblox.com/Asset/CharacterFetch.ashx?userId="..OutfitID;
	elseif (ColorHash and ColorHash ~= "") then
		local aid = "http://www.roblox.com/asset?id="
		local bcid = "http://assetgame.roblox.com/Asset/BodyColors.ashx?avatarHash="
		local charapp = bcid..ColorHash..";"..aid..PantsID..";"..aid..ShirtID..";"..aid..TShirtID..";"..aid..Hat1ID.."&version="..Hat1Version..";"..aid..Hat2ID.."&version="..Hat2Version..";"..aid..Hat3ID.."&version="..Hat3Version..";"
		Player.CharacterAppearance = charapp
	else
		Player.CharacterAppearance=0;
	end
	pcall(function() Player.Name=PlayerName or ""; end);
	pcall(function() Visit:SetUploadUrl(""); end);
end

function GetHatID(Hat1ID,Hat2ID,Hat3ID)
	if (Hat1ID == 1) then
		Hat1 = "rbxasset://charcustom/hats/BlueBaseballCap.rbxm"
	elseif (Hat1ID == 2) then
		Hat1 = "rbxasset://charcustom/hats/DominoCrown.rbxm"
	elseif (Hat1ID == 3) then
		Hat1 = "rbxasset://charcustom/hats/fedora.rbxm"
	elseif (Hat1ID == 4) then
		Hat1 = "rbxasset://charcustom/hats/GreenTopHat.rbxm"
	elseif (Hat1ID == 5) then
		Hat1 = "rbxasset://charcustom/hats/headphones.rbxm"
	elseif (Hat1ID == 6) then
		Hat1 = "rbxasset://charcustom/hats/NoHat.rbxm"
	elseif (Hat1ID == 7) then
		Hat1 = "rbxasset://charcustom/hats/PirateHat.rbxm"
	elseif (Hat1ID == 8) then
		Hat1 = "rbxasset://charcustom/hats/PoliceCap.rbxm"
	elseif (Hat1ID == 9) then
		Hat1 = "rbxasset://charcustom/hats/PurpleTopHat.rbxm"
	elseif (Hat1ID == 10) then
		Hat1 = "rbxasset://charcustom/hats/RedBaseballCap.rbxm"
	elseif (Hat1ID == 11) then
		Hat1 = "rbxasset://charcustom/hats/RedTopHat.rbxm"
	elseif (Hat1ID == 12) then
		Hat1 = "rbxasset://charcustom/hats/shades.rbxm"
	elseif (Hat1ID == 13) then
		Hat1 = "rbxasset://charcustom/hats/ShadowNinjaMask.rbxm"
	elseif (Hat1ID == 14) then
		Hat1 = "rbxasset://charcustom/hats/sombrero.rbxm"
	elseif (Hat1ID == 15) then
		Hat1 = "rbxasset://charcustom/hats/VikingHelm.rbxm"
	end
	
	if (Hat2ID == 1) then
		Hat2 = "rbxasset://charcustom/hats/BlueBaseballCap.rbxm"
	elseif (Hat2ID == 2) then
		Hat2 = "rbxasset://charcustom/hats/DominoCrown.rbxm"
	elseif (Hat2ID == 3) then
		Hat2 = "rbxasset://charcustom/hats/fedora.rbxm"
	elseif (Hat2ID == 4) then
		Hat2 = "rbxasset://charcustom/hats/GreenTopHat.rbxm"
	elseif (Hat2ID == 5) then
		Hat2 = "rbxasset://charcustom/hats/headphones.rbxm"
	elseif (Hat2ID == 6) then
		Hat2 = "rbxasset://charcustom/hats/NoHat.rbxm"
	elseif (Hat2ID == 7) then
		Hat2 = "rbxasset://charcustom/hats/PirateHat.rbxm"
	elseif (Hat2ID == 8) then
		Hat2 = "rbxasset://charcustom/hats/PoliceCap.rbxm"
	elseif (Hat2ID == 9) then
		Hat2 = "rbxasset://charcustom/hats/PurpleTopHat.rbxm"
	elseif (Hat2ID == 10) then
		Hat2 = "rbxasset://charcustom/hats/RedBaseballCap.rbxm"
	elseif (Hat2ID == 11) then
		Hat2 = "rbxasset://charcustom/hats/RedTopHat.rbxm"
	elseif (Hat2ID == 12) then
		Hat2 = "rbxasset://charcustom/hats/shades.rbxm"
	elseif (Hat2ID == 13) then
		Hat2 = "rbxasset://charcustom/hats/ShadowNinjaMask.rbxm"
	elseif (Hat2ID == 14) then
		Hat2 = "rbxasset://charcustom/hats/sombrero.rbxm"
	elseif (Hat2ID == 15) then
		Hat2 = "rbxasset://charcustom/hats/VikingHelm.rbxm"
	end
	
	if (Hat3ID == 1) then
		Hat3 = "rbxasset://charcustom/hats/BlueBaseballCap.rbxm"
	elseif (Hat3ID == 2) then
		Hat3 = "rbxasset://charcustom/hats/DominoCrown.rbxm"
	elseif (Hat3ID == 3) then
		Hat3 = "rbxasset://charcustom/hats/fedora.rbxm"
	elseif (Hat3ID == 4) then
		Hat3 = "rbxasset://charcustom/hats/GreenTopHat.rbxm"
	elseif (Hat3ID == 5) then
		Hat3 = "rbxasset://charcustom/hats/headphones.rbxm"
	elseif (Hat3ID == 6) then
		Hat3 = "rbxasset://charcustom/hats/NoHat.rbxm"
	elseif (Hat3ID == 7) then
		Hat3 = "rbxasset://charcustom/hats/PirateHat.rbxm"
	elseif (Hat3ID == 8) then
		Hat3 = "rbxasset://charcustom/hats/PoliceCap.rbxm"
	elseif (Hat3ID == 9) then
		Hat3 = "rbxasset://charcustom/hats/PurpleTopHat.rbxm"
	elseif (Hat3ID == 10) then
		Hat3 = "rbxasset://charcustom/hats/RedBaseballCap.rbxm"
	elseif (Hat3ID == 11) then
		Hat3 = "rbxasset://charcustom/hats/RedTopHat.rbxm"
	elseif (Hat3ID == 12) then
		Hat3 = "rbxasset://charcustom/hats/shades.rbxm"
	elseif (Hat3ID == 13) then
		Hat3 = "rbxasset://charcustom/hats/ShadowNinjaMask.rbxm"
	elseif (Hat3ID == 14) then
		Hat3 = "rbxasset://charcustom/hats/sombrero.rbxm"
	elseif (Hat3ID == 15) then
		Hat3 = "rbxasset://charcustom/hats/VikingHelm.rbxm"
	end
end

--same function but with our new localized customization system!
function CSConnect2(UserID,ServerIP,ServerPort,PlayerName,OutfitID,Hat1ID,Hat2ID,Hat3ID,Ticket)
	pcall(function() game:SetPlaceID(-1, false) end);
	pcall(function() game:GetService("Players"):SetChatStyle(Enum.ChatStyle.ClassicAndBubble) end);
	
	pcall(function()
		game:GetService("GuiService").Changed:connect(function()
			pcall(function() game:GetService("GuiService").ShowLegacyPlayerList=true; end);
			pcall(function() game.CoreGui.RobloxGui.PlayerListScript:Remove(); end);
			pcall(function() game.CoreGui.RobloxGui.PlayerListTopRightFrame:Remove(); end);
			pcall(function() game.CoreGui.RobloxGui.BigPlayerListWindowImposter:Remove(); end);
			pcall(function() game.CoreGui.RobloxGui.BigPlayerlist:Remove(); end);
		end);
	end)
	game:GetService("RunService"):Run();
	assert((ServerIP~=nil and ServerPort~=nil),"CSConnect Error: ServerIP and ServerPort must be defined.");
	local function SetMessage(Message) game:SetMessage(Message); end
	local Visit,NetworkClient,PlayerSuccess,Player,ConnectionFailedHook=game:GetService("Visit"),game:GetService("NetworkClient");

	local function GetClassCount(Class,Parent)
		local Objects=Parent:GetChildren();
		local Number=0;
		for Index,Object in pairs(Objects) do
			if (Object.className==Class) then
				Number=Number+1;
			end
			Number=Number+GetClassCount(Class,Object);
		end
		return Number;
	end

	local function RequestCharacter(Replicator)
		local Connection;
		Connection=Player.Changed:connect(function(Property)
			if (Property=="Character") then
				game:ClearMessage();
			end
		end)
		SetMessage("Requesting character...");
		Replicator:RequestCharacter();
		SetMessage("Waiting for character...");
	end

	local function Disconnection(Peer,LostConnection)
		SetMessage("You have lost connection to the game");
	end

	local function ConnectionAccepted(Peer,Replicator)
		Replicator.Disconnection:connect(Disconnection);
		local RequestingMarker=true;
		game:SetMessageBrickCount();
		local Marker=Replicator:SendMarker();
		Marker.Received:connect(function()
			RequestingMarker=false;
			RequestCharacter(Replicator);
		end)
		while RequestingMarker do
			Workspace:ZoomToExtents();
			wait(0.5);
		end
	end

	local function ConnectionFailed(Peer, Code, why)
		SetMessage("Failed to connect to the Game. (ID="..Code.." ["..why.."])");
	end

	pcall(function() settings().Diagnostics:LegacyScriptMode(); end);
	pcall(function() game:SetRemoteBuildMode(true); end);
	SetMessage("Connecting to server...");
	NetworkClient.ConnectionAccepted:connect(ConnectionAccepted);
	ConnectionFailedHook=NetworkClient.ConnectionFailed:connect(ConnectionFailed);
	NetworkClient.ConnectionRejected:connect(function()
		pcall(function() ConnectionFailedHook:disconnect(); end);
		SetMessage("Failed to connect to the Game. (Connection rejected)");
	end)

	pcall(function() NetworkClient.Ticket=Ticket or ""; end) -- 2008 client has no ticket :O
	PlayerSuccess,Player=pcall(function() return NetworkClient:PlayerConnect(UserID,ServerIP,ServerPort) end);

	if (not PlayerSuccess) then
		SetMessage("Failed to connect to the Game. (Invalid IP Address)");
		NetworkClient:Disconnect();
	end

	if (not PlayerSuccess) then
		local Error,Message=pcall(function()
			Player=game:GetService("Players"):CreateLocalPlayer(UserID);
			NetworkClient:Connect(ServerIP,ServerPort);
		end);
		if (not Error) then
			SetMessage("Failed to connect to the Game.");
		end
	end
	pcall(function() Player:SetUnder13(false) end);
	pcall(function() Player:SetMembershipType(Enum.MembershipType.BuildersClub) end);
	pcall(function() Player:SetAccountAge(365) end);
	Player:SetSuperSafeChat(false);
	if (OutfitID and OutfitID ~= 0) then
		Player.CharacterAppearance="http://www.roblox.com/Asset/CharacterFetch.ashx?userId="..OutfitID;
	elseif (Hat1ID and Hat1ID ~= 0) then
		GetHatID(Hat1ID,Hat2ID,Hat3ID)
		local charapp = "rbxasset://charcustom/CharacterColors.rbxm;"..Hat1..";"..Hat2..";"..Hat3
		player.CharacterAppearance = charapp
	else
		Player.CharacterAppearance=0;
	end
	pcall(function() Player.Name=PlayerName or ""; end);
	pcall(function() Visit:SetUploadUrl(""); end);
end

_G.CSServer=CSServer;
_G.CSConnect=CSConnect;
_G.CSConnect2=CSConnect2;
