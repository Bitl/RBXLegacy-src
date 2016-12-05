rbxversion = version();
print("ROBLOX Client version '" .. rbxversion .. "' loaded.");
if (rbxversion ~= "0, 3, 809, 0") then
	settings().Rendering.FrameRateManager = 2;
else
	settings().Rendering.frameRateManager = 2;
	settings().Rendering.graphicsMode = 2;
end

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

function CSConnect(UserID,ServerIP,ServerPort,PlayerName,OutfitID,Ticket)
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

	local function ConnectionFailed(Peer,Code)
		SetMessage("Failed to connect to the Game. (ID="..Code..")");
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
	Player=game:GetService("Players"):CreateLocalPlayer(UserID);
	PlayerSuccess=pcall(function() return NetworkClient:Connect(ServerIP,ServerPort) end);

	if (not PlayerSuccess) then
		SetMessage("Failed to connect to the Game. (Invalid IP Address)");
		NetworkClient:Disconnect();
	end

	if (not Player) then
		SetMessage("Failed to connect to the Game. (Player not found)");
		NetworkClient:Disconnect();
	end
	pcall(function() Player:SetUnder13(false) end);
	pcall(function() Player:SetMembershipType(Enum.MembershipType.BuildersClub) end);
	pcall(function() Player:SetAccountAge(365) end);
	Player:SetSuperSafeChat(false);
	if (OutfitID) then
		Player.CharacterAppearance="http://www.roblox.com/Asset/CharacterFetch.ashx?userId="..OutfitID;
	else
		Player.CharacterAppearance=0;
	end
	pcall(function() Player.Name=PlayerName or ""; end);
	pcall(function() Visit:SetUploadUrl(""); end);
end

_G.CSServer=CSServer;
_G.CSConnect=CSConnect;
