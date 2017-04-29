rbxversion = version();
print("ROBLOX Client version '" .. rbxversion .. "' loaded.");
--set this to pre-alpha, alpha, beta, gamma, or delta.
rbxlegacyversion = ""
if (rbxlegacyversion == "pre-alpha") then --mid-2008 and below. currently for the modified clients.
	settings().Rendering.frameRateManager = 2;
	settings().Rendering.graphicsMode = 2;
	settings().Network.MaxSendBuffer = 1000000;
	settings().Network.PhysicsReplicationUpdateRate = 1000000;
	settings().Network.SendRate = 1000000;
elseif (rbxlegacyversion == "alpha") then --mid-2008 and below
	settings().Rendering.frameRateManager = 2;
	settings().Rendering.graphicsMode = 2;
	settings().Network.MaxSendBuffer = 1000000;
	settings().Network.PhysicsReplicationUpdateRate = 1000000;
	settings().Network.SendRate = 1000000;
elseif (rbxlegacyversion == "beta") then -- late 2008-early 2009
	settings().Rendering.FrameRateManager = 2;
	settings().Network.SendRate = 30;
	settings().Network.ReceiveRate = 60;
elseif (rbxlegacyversion == "gamma") then -- late 2009-mid 2010
	settings().Rendering.FrameRateManager = 2;
	settings().Network.DataSendRate = 30;
	settings().Network.PhysicsSendRate = 20;
	settings().Network.ReceiveRate = 60;
elseif (rbxlegacyversion == "delta") then -- late 2010-early 2011.
	settings().Rendering.FrameRateManager = 2;
	
	game:GetService("CoreGui").DescendantAdded:connect(function(Child)
		if (Child:IsA("BaseScript")) and (Child.Name~="SubMenuBuilder") and (Child.Name~="ToolTipper") and (Child.Name~="MainBotChatScript") then
			Child:Remove();
		end
	end)

	coroutine.resume(coroutine.create(function()
		while not game:GetService("CoreGui"):FindFirstChild("RobloxGui") do game:GetService("CoreGui").ChildAdded:wait(); end
		game:GetService("CoreGui").RobloxGui.TopLeftControl:Remove();
	end))

	coroutine.resume(coroutine.create(function()
		loadstring('\108\111\99\97\108\32\67\111\114\101\71\117\105\32\61\32\103\97\109\101\58\71\101\116\83\101\114\118\105\99\101\40\34\67\111\114\101\71\117\105\34\41\59\10\119\104\105\108\101\32\110\111\116\32\67\111\114\101\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\82\111\98\108\111\120\71\117\105\34\41\32\100\111\10\9\67\111\114\101\71\117\105\46\67\104\105\108\100\65\100\100\101\100\58\119\97\105\116\40\41\59\10\101\110\100\10\108\111\99\97\108\32\82\111\98\108\111\120\71\117\105\32\61\32\67\111\114\101\71\117\105\46\82\111\98\108\111\120\71\117\105\59\10\108\111\99\97\108\32\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\34\41\10\108\111\99\97\108\32\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\34\41\10\108\111\99\97\108\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\84\111\112\76\101\102\116\67\111\110\116\114\111\108\34\41\10\108\111\99\97\108\32\66\117\105\108\100\84\111\111\108\115\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\66\117\105\108\100\84\111\111\108\115\34\41\10\102\117\110\99\116\105\111\110\32\109\97\107\101\89\82\101\108\97\116\105\118\101\40\41\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\10\105\102\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\32\116\104\101\110\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\32\101\110\100\10\105\102\32\66\117\105\108\100\84\111\111\108\115\32\116\104\101\110\32\66\117\105\108\100\84\111\111\108\115\46\70\114\97\109\101\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\32\101\110\100\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\48\44\48\44\49\44\45\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\88\44\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\101\110\100\10\102\117\110\99\116\105\111\110\32\109\97\107\101\88\82\101\108\97\116\105\118\101\40\41\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\10\105\102\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\32\116\104\101\110\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\32\101\110\100\10\105\102\32\66\117\105\108\100\84\111\111\108\115\32\116\104\101\110\32\66\117\105\108\100\84\111\111\108\115\46\70\114\97\109\101\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\32\101\110\100\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\48\44\48\44\49\44\45\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\88\44\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\101\110\100\10\108\111\99\97\108\32\102\117\110\99\116\105\111\110\32\114\101\115\105\122\101\40\41\10\105\102\32\82\111\98\108\111\120\71\117\105\46\65\98\115\111\108\117\116\101\83\105\122\101\46\120\32\62\32\82\111\98\108\111\120\71\117\105\46\65\98\115\111\108\117\116\101\83\105\122\101\46\121\32\116\104\101\110\10\109\97\107\101\89\82\101\108\97\116\105\118\101\40\41\10\101\108\115\101\10\109\97\107\101\88\82\101\108\97\116\105\118\101\40\41\10\101\110\100\10\101\110\100\10\82\111\98\108\111\120\71\117\105\46\67\104\97\110\103\101\100\58\99\111\110\110\101\99\116\40\102\117\110\99\116\105\111\110\40\112\114\111\112\101\114\116\121\41\10\105\102\32\112\114\111\112\101\114\116\121\32\61\61\32\34\65\98\115\111\108\117\116\101\83\105\122\101\34\32\116\104\101\110\10\119\97\105\116\40\41\10\114\101\115\105\122\101\40\41\10\101\110\100\10\101\110\100\41\10\119\97\105\116\40\41\10\114\101\115\105\122\101\40\41\10')()
	end))
end

HeadColor=BrickColor.DarkGray();
TorsoColor=BrickColor.DarkGray();
LArmColor=BrickColor.DarkGray();
LLegColor=BrickColor.DarkGray();
RArmColor=BrickColor.DarkGray();
RLegColor=BrickColor.DarkGray();
--localized hats.
Hat1 = "rbxasset://charcustom/hats/fedora.rbxm"
Hat2 = "rbxasset://charcustom/hats/fedora.rbxm"
Hat3 = "rbxasset://charcustom/hats/fedora.rbxm"

function PlayerColorize()
	if (rbxlegacyversion == "pre-alpha") then
		local pantsColor=BrickColor.random();
		local shirtColor=BrickColor.random();
		local fleshColor=BrickColor.random();
		HeadColor=fleshColor;
		TorsoColor=shirtColor;
		LArmColor=fleshColor;
		LLegColor=pantsColor;
		RArmColor=fleshColor;
		RLegColor=pantsColor;
	else
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
end

function PlayerNoobify()
	if (rbxlegacyversion == "pre-alpha") then
		HeadColor=BrickColor.new("Cool yellow");
		TorsoColor=BrickColor.random();
		LArmColor=BrickColor.new("Cool yellow");
		LLegColor=BrickColor.new("Pastel Blue");
		RArmColor=BrickColor.new("Cool yellow");
		RLegColor=BrickColor.new("Pastel Blue");
	else
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
end

function CSServer(Port,BodyColors)
	if (rbxlegacyversion == "delta") then
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
		NetworkServer.IncommingConnection:connect(IncommingConnection);
	else
			Server = game:GetService("NetworkServer")
			RunService = game:GetService("RunService")
			Server:start(Port, 20)
			RunService:run();
			game:GetService("Players").PlayerAdded:connect(function(Player)
			print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' added");
			Player:LoadCharacter();
			if (BodyColors == true) then
				PlayerColorize();
			else
				PlayerNoobify();
			end
			Player.Character['Head'].BrickColor = HeadColor;
			Player.Character['Torso'].BrickColor = TorsoColor;
			Player.Character['Left Arm'].BrickColor = LArmColor;
			Player.Character['Left Leg'].BrickColor = LLegColor;
			Player.Character['Right Arm'].BrickColor = RArmColor;
			Player.Character['Right Leg'].BrickColor = RLegColor;
			while true do 
				wait(0.001)
				if (Player.Character ~= nil) then
					if (Player.Character.Humanoid.Health == 0) then
						wait(5)
						Player:LoadCharacter()
						if (BodyColors == true) then
							PlayerColorize();
						else
							PlayerNoobify();
						end
						Player.Character['Head'].BrickColor = HeadColor;
						Player.Character['Torso'].BrickColor = TorsoColor;
						Player.Character['Left Arm'].BrickColor = LArmColor;
						Player.Character['Left Leg'].BrickColor = LLegColor;
						Player.Character['Right Arm'].BrickColor = RArmColor;
						Player.Character['Right Leg'].BrickColor = RLegColor;
					elseif (Player.Character.Parent == nil) then 
						wait(5)
						Player:LoadCharacter() -- to make sure nobody is deleted.
						if (BodyColors == true) then
							PlayerColorize();
						else
							PlayerNoobify();
						end
						Player.Character['Head'].BrickColor = HeadColor;
						Player.Character['Torso'].BrickColor = TorsoColor;
						Player.Character['Left Arm'].BrickColor = LArmColor;
						Player.Character['Left Leg'].BrickColor = LLegColor;
						Player.Character['Right Arm'].BrickColor = RArmColor;
						Player.Character['Right Leg'].BrickColor = RLegColor;
					end
				end
			end
		end)
		game:GetService("Players").PlayerRemoving:connect(function(Player)
			print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' leaving")	
		end)
		game:GetService("RunService"):Run();
		pcall(function() game.Close:connect(function() Server:Stop(); end) end);
		Server.IncommingConnection:connect(IncommingConnection);
	end
end

function CSConnect(UserID,ServerIP,ServerPort,PlayerName,OutfitID,ColorHash,PantsID,ShirtID,TShirtID,Hat1ID,Hat2ID,Hat3ID,Hat1Version,Hat2Version,Hat3Version,Ticket)
	if (rbxlegacyversion == "delta") then
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
	else
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
	
		local suc, err = pcall(function()
			client = game:GetService("NetworkClient")
			player = game:GetService("Players"):CreateLocalPlayer(UserID) 
			player:SetSuperSafeChat(false)
			pcall(function() player:SetUnder13(false) end);
			pcall(function() player:SetMembershipType(Enum.MembershipType.BuildersClub) end);
			pcall(function() player:SetAccountAge(365) end);
			if (OutfitID and OutfitID ~= 0) then
				player.CharacterAppearance="http://www.roblox.com/Asset/CharacterFetch.ashx?userId="..OutfitID;
			elseif (ColorHash and ColorHash ~= "") then
				local aid = "http://www.roblox.com/asset?id="
				local bcid = "http://assetgame.roblox.com/Asset/BodyColors.ashx?avatarHash="
				local charapp = bcid..ColorHash..";"..aid..PantsID..";"..aid..ShirtID..";"..aid..TShirtID..";"..aid..Hat1ID.."&version="..Hat1Version..";"..aid..Hat2ID.."&version="..Hat2Version..";"..aid..Hat3ID.."&version="..Hat3Version..";"
				player.CharacterAppearance = charapp
			else
				player.CharacterAppearance=0;
			end
			pcall(function() player.Name=PlayerName or ""; end);
		end)
	
		local function dieerror(errmsg)
			game:SetMessage(errmsg)
			wait(math.huge)
		end

		if not suc then
			dieerror(err)
		end

		local function disconnect(peer,lostconnection)
			game:SetMessage("You have lost connection to the game")
		end
	
		local function connected(url, replicator)
			replicator.Disconnection:connect(disconnect)
			local marker = nil
			local suc, err = pcall(function()
				game:SetMessageBrickCount()
				marker = replicator:SendMarker()
			end)
			if not suc then
				dieerror(err)
			end
			marker.Received:connect(function()
				local suc, err = pcall(function()
					game:ClearMessage()
				end)
				if not suc then
					dieerror(err)
				end
			end)
		end

		local function rejected()
			dieerror("Failed to connect to the Game. (Connection rejected)")
		end

		local function failed(peer, errcode, why)
			dieerror("Failed to connect to the Game. (ID="..errcode.." ["..why.."])")
		end

		local suc, err = pcall(function()
			game:SetMessage("Connecting to server...");
			client.ConnectionAccepted:connect(connected)
			client.ConnectionRejected:connect(rejected)
			client.ConnectionFailed:connect(failed)
			client:Connect(ServerIP,ServerPort, 0, 20)
			if (rbxlegacyversion == "pre-alpha") then
				game.GuiRoot.MainMenu["Toolbox"]:Remove()
				game.GuiRoot.MainMenu["Edit Mode"]:Remove()
			else
				game.GuiRoot.MainMenu["Tools"]:Remove()
				game.GuiRoot.MainMenu["Insert"]:Remove()
			end
		end)

		if not suc then
			local x = Instance.new("Message")
			x.Text = err
			x.Parent = workspace
			wait(math.huge)
		end
	end
end

--same function but with our new localized customization system!
function CSConnect2(UserID,ServerIP,ServerPort,PlayerName,OutfitID,Hat1ID,Hat2ID,Hat3ID,Ticket)
	if (rbxlegacyversion == "delta") then
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
			Hat1 = "rbxasset://charcustom/hats/"..Hat1ID
			Hat2 = "rbxasset://charcustom/hats/"..Hat2ID
			Hat3 = "rbxasset://charcustom/hats/"..Hat3ID
			local charapp = "rbxasset://charcustom/CharacterColors.rbxm;"..Hat1..";"..Hat2..";"..Hat3
			player.CharacterAppearance = charapp
		else
			Player.CharacterAppearance=0;
		end
		pcall(function() Player.Name=PlayerName or ""; end);
		pcall(function() Visit:SetUploadUrl(""); end);
	else
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
	
		local suc, err = pcall(function()
			client = game:GetService("NetworkClient")
			player = game:GetService("Players"):CreateLocalPlayer(UserID) 
			player:SetSuperSafeChat(false)
			pcall(function() player:SetUnder13(false) end);
			pcall(function() player:SetMembershipType(Enum.MembershipType.BuildersClub) end);
			pcall(function() player:SetAccountAge(365) end);
			if (OutfitID and OutfitID ~= 0) then
				player.CharacterAppearance="http://www.roblox.com/Asset/CharacterFetch.ashx?userId="..OutfitID;
			elseif (Hat1ID and Hat1ID ~= 0) then
				Hat1 = "rbxasset://charcustom/hats/"..Hat1ID
				Hat2 = "rbxasset://charcustom/hats/"..Hat2ID
				Hat3 = "rbxasset://charcustom/hats/"..Hat3ID
				local charapp = "rbxasset://charcustom/CharacterColors.rbxm;"..Hat1..";"..Hat2..";"..Hat3
				player.CharacterAppearance = charapp
			else
				player.CharacterAppearance=0;
			end
			pcall(function() player.Name=PlayerName or ""; end);
		end)
	
		local function dieerror(errmsg)
			game:SetMessage(errmsg)
			wait(math.huge)
		end

		if not suc then
			dieerror(err)
		end

		local function disconnect(peer,lostconnection)
			game:SetMessage("You have lost connection to the game")
		end
	
		local function connected(url, replicator)
			replicator.Disconnection:connect(disconnect)
			local marker = nil
			local suc, err = pcall(function()
				game:SetMessageBrickCount()
				marker = replicator:SendMarker()
			end)
			if not suc then
				dieerror(err)
			end
			marker.Received:connect(function()
				local suc, err = pcall(function()
					game:ClearMessage()
				end)
				if not suc then
					dieerror(err)
				end
			end)
		end

		local function rejected()
			dieerror("Failed to connect to the Game. (Connection rejected)")
		end

		local function failed(peer, errcode, why)
			dieerror("Failed to connect to the Game. (ID="..errcode.." ["..why.."])")
		end

		local suc, err = pcall(function()
			game:SetMessage("Connecting to server...");
			client.ConnectionAccepted:connect(connected)
			client.ConnectionRejected:connect(rejected)
			client.ConnectionFailed:connect(failed)
			client:Connect(ServerIP,ServerPort, 0, 20)
			if (rbxlegacyversion == "pre-alpha") then
				game.GuiRoot.MainMenu["Toolbox"]:Remove()
				game.GuiRoot.MainMenu["Edit Mode"]:Remove()
			else
				game.GuiRoot.MainMenu["Tools"]:Remove()
				game.GuiRoot.MainMenu["Insert"]:Remove()
			end
		end)

		if not suc then
			local x = Instance.new("Message")
			x.Text = err
			x.Parent = workspace
			wait(math.huge)
		end
	end
end

_G.CSServer=CSServer;
_G.CSConnect=CSConnect;
_G.CSConnect2=CSConnect2;