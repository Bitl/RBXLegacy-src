--coded by Bitl and Carrot
--stuff was borrowed from RBXBanland, EnergyCell, John, and the RBXPri team
rbxlegacyversion = ""

function SetRBXLegacyVersion(Version)
	rbxlegacyversion = Version
	if (rbxlegacyversion == "pre-alpha") then
		settings().Rendering.frameRateManager = 2
    	settings().Rendering.graphicsMode = 2
		settings().Network.MaxSendBuffer = 1000000
		settings().Network.PhysicsReplicationUpdateRate = 1000000
		settings().Network.SendRate = 1000000
	elseif (rbxlegacyversion == "pre-alpha-ext") then
		settings().Rendering.frameRateManager = 2
		settings().Rendering.graphicsMode = 2
		settings().Network.MaxSendBuffer = 1000000
		settings().Network.PhysicsReplicationUpdateRate = 1000000
		settings().Network.SendRate = 1000000
	elseif (rbxlegacyversion == "alpha") then
		settings().Rendering.frameRateManager = 2
		settings().Network.MaxSendBuffer = 1000000
		settings().Network.PhysicsReplicationUpdateRate = 1000000
		settings().Network.SendRate = 1000000
	elseif (rbxlegacyversion == "beta") then
		settings().Rendering.FrameRateManager = 2
		settings().Network.SendRate = 30
		settings().Network.ReceiveRate = 60
	elseif (rbxlegacyversion == "delta-beta") then
		settings().Rendering.FrameRateManager = 2
		settings().Network.SendRate = 30
		settings().Network.ReceiveRate = 60
	elseif (rbxlegacyversion == "pre-gamma-beta") then
		settings().Rendering.FrameRateManager = 2
		settings().Network.DataSendRate = 30
		settings().Network.PhysicsSendRate = 20
		settings().Network.ReceiveRate = 60
	elseif (rbxlegacyversion == "delta-pre-gamma-beta") then
		settings().Rendering.FrameRateManager = 2
		settings().Network.DataSendRate = 30
		settings().Network.PhysicsSendRate = 20
		settings().Network.ReceiveRate = 60
	elseif (rbxlegacyversion == "pre-gamma") then
		settings().Rendering.FrameRateManager = 2
		settings().Network.DataSendRate = 30
		settings().Network.PhysicsSendRate = 20
		settings().Network.ReceiveRate = 60
	elseif (rbxlegacyversion == "delta-pre-gamma") then
		settings().Rendering.FrameRateManager = 2
		settings().Network.DataSendRate = 30
		settings().Network.PhysicsSendRate = 20
		settings().Network.ReceiveRate = 60
	elseif (rbxlegacyversion == "gamma") then
		settings().Rendering.FrameRateManager = 2
		settings().Network.DataSendRate = 30
		settings().Network.PhysicsSendRate = 20
		settings().Network.ReceiveRate = 60
		pcall(function() game:GetService("ScriptContext").ScriptsDisabled = false end)
		pcall(function() settings().Diagnostics:LegacyScriptMode() end)
	elseif (rbxlegacyversion == "delta-gamma") then
		settings().Rendering.FrameRateManager = 2
		settings().Network.DataSendRate = 30
		settings().Network.PhysicsSendRate = 20
		settings().Network.ReceiveRate = 60
		pcall(function() game:GetService("ScriptContext").ScriptsDisabled = false end)
		pcall(function() settings().Diagnostics:LegacyScriptMode() end)
	elseif (rbxlegacyversion == "delta") then
		settings().Rendering.FrameRateManager = 2
		pcall(function() game:GetService("ScriptContext").ScriptsDisabled = false end)
		pcall(function() settings().Diagnostics:LegacyScriptMode() end)
		coroutine.resume(coroutine.create(function()
			local CoreGui = game:GetService("CoreGui")
				while not CoreGui:FindFirstChild("RobloxGui") do
					CoreGui.ChildAdded:wait()
				end
			local RobloxGui = CoreGui.RobloxGui
			local BottomLeftControl = RobloxGui:FindFirstChild("BottomLeftControl")
			local BottomRightControl = RobloxGui:FindFirstChild("BottomRightControl")
			local TopLeftControl = RobloxGui:FindFirstChild("TopLeftControl")
			local BuildTools = RobloxGui:FindFirstChild("BuildTools")
			function makeYRelative() -- 123
				BottomLeftControl.SizeConstraint = 2
				BottomRightControl.SizeConstraint = 2
					if TopLeftControl then TopLeftControl.SizeConstraint = 2 
				end
					if BuildTools then BuildTools.Frame.SizeConstraint = 2 
				end
				BottomLeftControl.Position = UDim2.new(0,0,1,-BottomLeftControl.AbsoluteSize.Y)
				BottomRightControl.Position = UDim2.new(1,-BottomRightControl.AbsoluteSize.X,1,-BottomRightControl.AbsoluteSize.Y)
			end
			function makeXRelative()
				loadstring("\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\10\9\9\9\9\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49")()
				--[[BottomLeftControl.SizeConstraint = 1
				BottomRightControl.SizeConstraint = 1
				]]--
					if TopLeftControl then TopLeftControl.SizeConstraint = 1 
				end
					if BuildTools then BuildTools.Frame.SizeConstraint = 1 
				end
				BottomLeftControl.Position = UDim2.new(0,0,1,-BottomLeftControl.AbsoluteSize.Y)
				BottomRightControl.Position = UDim2.new(1,-BottomRightControl.AbsoluteSize.X,1,-BottomRightControl.AbsoluteSize.Y)
			end
			local function resize()
				if RobloxGui.AbsoluteSize.x > RobloxGui.AbsoluteSize.y then
					makeYRelative()
				else
					makeXRelative()
				end
			end
			RobloxGui.Changed:connect(function(property)
				if property == "AbsoluteSize" then
					wait()
					resize()
				end
			end)
		wait()
		resize()
		end))
		coroutine.resume(coroutine.create(function()
			for _,v in pairs(game:GetChildren()) do
				if v.Name == "GuiRoot" then
				coroutine.resume(coroutine.create(function()
					v.ScoreHud.Parent = nil
				end)) 
			end 
		end 
	end))
	elseif (rbxlegacyversion == "delta-omega") then
		settings().Rendering.FrameRateManager = 2
		pcall(function() game:GetService("ScriptContext").ScriptsDisabled = false end)
		pcall(function() settings().Diagnostics:LegacyScriptMode() end)
		coroutine.resume(coroutine.create(function()
		for _,v in pairs(game:GetChildren()) do
		if v.Name == "GuiRoot" then
		coroutine.resume(coroutine.create(function()
		v.ScoreHud.Parent = nil
		end)) end end end))
	elseif (rbxlegacyversion == "omega") then
		settings().Rendering.FrameRateManager = 2
		pcall(function() game:GetService("ScriptContext").ScriptsDisabled = false end)
		pcall(function() settings().Diagnostics:LegacyScriptMode()
		--stamper
		game:GetService("InsertService"):SetBaseSetsUrl("http://www.roblox.com/Game/Tools/InsertAsset.ashx?nsets=10&type=base")
		game:GetService("InsertService"):SetUserSetsUrl("http://www.roblox.com/Game/Tools/InsertAsset.ashx?nsets=20&type=user&userid=%d")
       		game:GetService("InsertService"):SetCollectionUrl("http://www.roblox.com/Game/Tools/InsertAsset.ashx?sid=%d")
		game:GetService("InsertService"):SetAssetUrl("http://www.roblox.com/Asset/?id=%d")
        	game:GetService("InsertService"):SetAssetVersionUrl("http://www.roblox.com/Asset/?assetversionid=%d")
		--[[corescripts
		local RobloxGui = game:GetService("CoreGui"):WaitForChild("RobloxGui") 
		local scriptContext = game:GetService("ScriptContext") 
		scriptContext:AddCoreScript("CoreScripts/Playerlist", RobloxGui)
		scriptContext:AddCoreScript("CoreScripts/GameMenu", RobloxGui)
		scriptContext:AddCoreScript("CoreScripts/BackpackFull", RobloxGui)
		]]--todo: file:// (rbxasset://) and the corescript adder thing
	end)
	--[[elseif (rbxlegacyversion == "ultra") then
		settings().Rendering.FrameRateManager = 2
		pcall(function() game:GetService("ScriptContext").ScriptsDisabled = false end)
		pcall(function() settings().Diagnostics:LegacyScriptMode() end)]]--we aren't ready for this yet
	end
	print("RBXLegacy client operation set to '" .. rbxlegacyversion .. "'.")
end

rbxversion = version()
print("ROBLOX Client version '" .. rbxversion .. "' loaded.")

function newWaitForChild(newParent,name)
	local returnable = nil
	if newParent:FindFirstChild(name) then
		returnable = newParent:FindFirstChild(name)
	else 
		repeat wait() returnable = newParent:FindFirstChild(name)  until returnable ~= nil
	end
	return returnable
end

function LoadCharacterNew(playerApp,newChar)
	--authentic roblox style loading
	wait(1.5)
	local charparts = {[1] = newWaitForChild(newChar,"Head"),[2] = newWaitForChild(newChar,"Torso"),[3] = newWaitForChild(newChar,"Left Arm"),[4] = newWaitForChild(newChar,"Right Arm"),[5] = newWaitForChild(newChar,"Left Leg"),[6] = newWaitForChild(newChar,"Right Leg")}
	for _,newVal in pairs(playerApp:GetChildren()) do
			if (newVal.CustomizationType.Value == 1) then 
				pcall(function() 
				charparts[newVal.ColorIndex.Value].BrickColor = newVal.Value 
				end)
			elseif (newVal.CustomizationType.Value == 2)  then
				if (rbxlegacyversion ~= "pre-alpha") then
					pcall(function()
					local newHat = game.Workspace:InsertContent("rbxasset://../../../charcustom/hats/"..newVal.Value)
					if newHat[1] then 
						if newHat[1].className == "Hat" then
							newHat[1].Parent = newChar
						else
							newHat[1]:remove()
						end
					end
				end)
			end
			elseif (newVal.CustomizationType.Value == 3)  then
				if (rbxlegacyversion ~= "pre-alpha") then
					pcall(function()
					local newTShirt = game.Workspace:InsertContent("http://www.roblox.com/asset/?id="..newVal.Value)
					if newTShirt[1] then 
						if newTShirt[1].className == "ShirtGraphic" then
							newTShirt[1].Parent = newChar
						else
							newTShirt[1]:remove()
						end
					end
				end)
			end
			elseif (newVal.CustomizationType.Value == 4)  then
				if (rbxlegacyversion ~= "pre-alpha" or rbxlegacyversion ~= "pre-alpha-ext") then
					pcall(function()
					local newShirt = game.Workspace:InsertContent("http://www.roblox.com/asset/?id="..newVal.Value)
					if newShirt[1] then 
						if newShirt[1].className == "Shirt" then
							newShirt[1].Parent = newChar
						else
							newShirt[1]:remove()
						end
					end
				end)
			end
			elseif (newVal.CustomizationType.Value == 5)  then
				if (rbxlegacyversion ~= "pre-alpha" or rbxlegacyversion ~= "pre-alpha-ext") then
					pcall(function()
					local newPants = game.Workspace:InsertContent("http://www.roblox.com/asset/?id="..newVal.Value)
					if newPants[1] then 
						if newPants[1].className == "Pants" then
							newPants[1].Parent = newChar
						else
							newPants[1]:remove()
						end
					end
				end)
			end
			elseif (newVal.CustomizationType.Value == 6)  then
				if (rbxlegacyversion ~= "pre-alpha" or rbxlegacyversion ~= "pre-alpha-ext" or rbxlegacyversion ~= "alpha" or rbxlegacyversion ~= "beta" or rbxlegacyversion ~= "delta-beta" or rbxlegacyversion ~= "pre-gamma-beta" or rbxlegacyversion ~= "delta-pre-gamma-beta") then
					pcall(function()
					local newFace = game.Workspace:InsertContent("rbxasset://../../../charcustom/faces/"..newVal.Value)
					if newFace[1] then 
						if newFace[1].className == "Decal" then
							newWaitForChild(charparts[1],"face"):remove()
							newFace[1].Parent = charparts[1]
							newFace[1].Face = "Front"
						else
							newFace[1]:remove()
						end
					end
				end)
			end
			elseif (newVal.CustomizationType.Value == 7) then 
				if (rbxlegacyversion ~= "pre-alpha" or rbxlegacyversion ~= "pre-alpha-ext" or rbxlegacyversion ~= "alpha" or rbxlegacyversion ~= "beta" or rbxlegacyversion ~= "delta-beta" or rbxlegacyversion ~= "pre-gamma-beta" or rbxlegacyversion ~= "delta-pre-gamma-beta") then
					pcall(function()
					local newPart = game.Workspace:InsertContent("rbxasset://../../../charcustom/heads/"..newVal.Value)
					if newPart[1] then 
						if newPart[1].className == "SpecialMesh" then
							newPart[1].Parent = charparts[1]
						else
							newPart[1]:remove()
						end
					end
				end)
			end
			elseif (newVal.CustomizationType.Value == 8) then 
				if (rbxlegacyversion ~= "pre-alpha" or rbxlegacyversion ~= "pre-alpha-ext" or rbxlegacyversion ~= "alpha" or rbxlegacyversion ~= "beta" or rbxlegacyversion ~= "delta-beta" or rbxlegacyversion ~= "pre-gamma" or rbxlegacyversion ~= "delta-pre-gamma" or rbxlegacyversion ~= "pre-gamma-beta" or rbxlegacyversion ~= "delta-pre-gamma-beta") then
					pcall(function()
					local newPart = game.Workspace:InsertContent("rbxasset://../../../charcustom/bodies/"..newVal.MeshIndex.Value.."/"..newVal.Value)
					if newPart[1] then 
						if newPart[1].className == "SpecialMesh" then
							newPart[1].Parent = charparts[newVal.MeshIndex.Value]
						else
							newPart[1]:remove()
						end
					end
				end)
			end
		end
	end
end

function InitalizeClientAppearance(Player,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID)
	local newCharApp = Instance.new("IntValue",Player)
	newCharApp.Name = "Appearance"
	--BODY COLORS
	for i=1,6,1 do
		local BodyColor = Instance.new("BrickColorValue",newCharApp)
		if (i == 1) then
			if (HeadColorID ~= nil) then
				BodyColor.Value = BrickColor.new(HeadColorID)
			else
				BodyColor.Value = BrickColor.new(1)
			end
			BodyColor.Name = "HeadColor"
		elseif (i == 2) then
			if (TorsoColorID ~= nil) then
				BodyColor.Value = BrickColor.new(TorsoColorID)
			else
				BodyColor.Value = BrickColor.new(1)
			end
			BodyColor.Name = "TorsoColor"
		elseif (i == 3) then
			if (LeftArmColorID ~= nil) then
				BodyColor.Value = BrickColor.new(LeftArmColorID)
			else
				BodyColor.Value = BrickColor.new(1)
			end
			BodyColor.Name = "LeftArmColor"
		elseif (i == 4) then
			if (RightArmColorID ~= nil) then
				BodyColor.Value = BrickColor.new(RightArmColorID)
			else
				BodyColor.Value = BrickColor.new(1)
			end
			BodyColor.Name = "RightArmColor"
		elseif (i == 5) then
			if (LeftLegColorID ~= nil) then
				BodyColor.Value = BrickColor.new(LeftLegColorID)
			else
				BodyColor.Value = BrickColor.new(1)
			end
			BodyColor.Name = "LeftLegColor"
		elseif (i == 6) then
			if (RightLegColorID ~= nil) then
				BodyColor.Value = BrickColor.new(RightLegColorID)
			else
				BodyColor.Value = BrickColor.new(1)
			end
			BodyColor.Name = "RightLegColor"
		end
		local indexValue = Instance.new("NumberValue")
		indexValue.Name = "ColorIndex"
		indexValue.Parent = BodyColor
		indexValue.Value = i
		local typeValue = Instance.new("NumberValue")
		typeValue.Name = "CustomizationType"
		typeValue.Parent = BodyColor
		typeValue.Value = 1
	end
	--HATS
	for i=1,3,1 do
		local newHat = Instance.new("StringValue",newCharApp)
		if (i == 1) then
			if (Hat1ID ~= nil) then
				newHat.Value = Hat1ID
				newHat.Name = Hat1ID
			else
				newHat.Value = "NoHat.rbxm"
				newHat.Name = "NoHat.rbxm"
			end
		elseif (i == 2) then
			if (Hat2ID ~= nil) then
				newHat.Value = Hat2ID
				newHat.Name = Hat2ID
			else
				newHat.Value = "NoHat.rbxm"
				newHat.Name = "NoHat.rbxm"
			end
		elseif (i == 3) then
			if (Hat3ID ~= nil) then
				newHat.Value = Hat3ID
				newHat.Name = Hat3ID
			else
				newHat.Value = "NoHat.rbxm"
				newHat.Name = "NoHat.rbxm"
			end
		end
		local typeValue = Instance.new("NumberValue")
		typeValue.Name = "CustomizationType"
		typeValue.Parent = newHat
		typeValue.Value = 2
	end
	--T-SHIRT
	local newTShirt = Instance.new("StringValue",newCharApp)
	if (TShirtID ~= nil or TShirtID ~= "0") then
		newTShirt.Value = TShirtID
	else
		newTShirt.Value = "0"
	end
	newTShirt.Name = "T-Shirt"
	local typeValue = Instance.new("NumberValue")
	typeValue.Name = "CustomizationType"
	typeValue.Parent = newTShirt
	typeValue.Value = 3
	--SHIRT
	local newShirt = Instance.new("StringValue",newCharApp)
	if (ShirtID ~= nil or ShirtID ~= "0") then
		newShirt.Value = ShirtID
	else
		newShirt.Value = "0"
	end
	newShirt.Name = "Shirt"
	local typeValue = Instance.new("NumberValue")
	typeValue.Name = "CustomizationType"
	typeValue.Parent = newShirt
	typeValue.Value = 4
	--PANTS
	local newPants = Instance.new("StringValue",newCharApp)
	if (PantsID ~= nil or PantsID ~= "0") then
		newPants.Value = PantsID
	else
		newPants.Value = "0"
	end
	newPants.Name = "Pants"
	local typeValue = Instance.new("NumberValue")
	typeValue.Name = "CustomizationType"
	typeValue.Parent = newPants
	typeValue.Value = 5
	--FACE
	local newFace = Instance.new("StringValue",newCharApp)
	if (FaceID ~= nil) then
		newFace.Value = FaceID
		newFace.Name = FaceID
	else
		newFace.Value = "DefaultFace.rbxm"
		newFace.Name = "DefaultFace.rbxm"
	end
	local typeValue = Instance.new("NumberValue")
	typeValue.Name = "CustomizationType"
	typeValue.Parent = newFace
	typeValue.Value = 6
	--HEADS
	local newHead = Instance.new("StringValue",newCharApp)
	if (HeadID ~= nil) then
		newHead.Value = HeadID
		newHead.Name = HeadID
	else
		newHead.Value = "DefaultHead.rbxm"
		newHead.Name = "DefaultHead.rbxm"
	end
	local typeValue = Instance.new("NumberValue")
	typeValue.Name = "CustomizationType"
	typeValue.Parent = newHead
	typeValue.Value = 7
	--PACKAGES
	for i=2,5,1 do
		local BodyMesh = Instance.new("StringValue",newCharApp)
		if (i == 2) then
			if (TorsoID ~= nil) then
				BodyMesh.Value = TorsoID
				BodyMesh.Name = TorsoID
			else
				BodyMesh.Value = "DefaultTorso.rbxm"
				BodyMesh.Name = "DefaultTorso.rbxm"
			end
		elseif (i == 3) then
			if (LArmID ~= nil) then
				BodyMesh.Value = LArmID
				BodyMesh.Name = LArmID
			else
				BodyMesh.Value = "DefaultLArm.rbxm"
				BodyMesh.Name = "DefaultLArm.rbxm"
			end
		elseif (i == 4) then
			if (RArmID ~= nil) then
				BodyMesh.Value = RArmID
				BodyMesh.Name = RArmID
			else
				BodyMesh.Value = "DefaultRArm.rbxm"
				BodyMesh.Name = "DefaultRArm.rbxm"
			end
		elseif (i == 5) then
			if (LLegID ~= nil) then
				BodyMesh.Value = LLegID
				BodyMesh.Name = LLegID
			else
				BodyMesh.Value = "DefaultLLeg.rbxm"
				BodyMesh.Name = "DefaultLLeg.rbxm"
			end
		elseif (i == 6) then
			if (RLegID ~= nil) then
				BodyMesh.Value = RLegID
				BodyMesh.Name = RLegID
			else
				BodyMesh.Value = "DefaultRLeg.rbxm"
				BodyMesh.Name = "DefaultRLeg.rbxm"
			end
		end
		local indexValue = Instance.new("NumberValue")
		indexValue.Name = "MeshIndex"
		indexValue.Parent = BodyColor
		indexValue.Value = i
		local typeValue = Instance.new("NumberValue")
		typeValue.Name = "CustomizationType"
		typeValue.Parent = BodyColor
		typeValue.Value = 8
	end
end

function CSServer(Port,PlayerLimit)
	if (rbxlegacyversion == "delta" or rbxlegacyversion == "delta-gamma" or rbxlegacyversion == "omega" or rbxlegacyversion == "delta-pre-gamma" or rbxlegacyversion == "delta-omega" or rbxlegacyversion == "delta-beta" or rbxlegacyversion == "delta-pre-gamma-beta") then
		assert((type(Port)~="number" or tonumber(Port)~=nil or Port==nil),"CSRun Error: Port must be nil or a number.")
		local NetworkServer=game:GetService("NetworkServer")
		pcall(NetworkServer.Stop,NetworkServer)
		NetworkServer:Start(Port)
		if (rbxlegacyversion ~= "omega") then
			game:GetService("Players").MaxPlayers = PlayerLimit
		end
		game:GetService("Players").PlayerAdded:connect(function(Player)
			if (game:GetService("Players").NumPlayers > game:GetService("Players").MaxPlayers) then
				local message = Instance.new("Message")
				message.Text = "You were kicked. Reason: Too many players on server."
				message.Parent = Player
				wait(2)
				Player:remove()
				print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' kicked. Reason: Too many players on server.")
			else
				print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' added")
				Player:LoadCharacter()
			end
			Player.CharacterAdded:connect(function(char)
				LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character)
			end)
			Player.Changed:connect(function(Property)
				if (Property=="Character") and (Player.Character~=nil) then
					local Character=Player.Character
					local Humanoid=Character:FindFirstChild("Humanoid")
					if (Humanoid~=nil) then
						Humanoid.Died:connect(function() delay(5,function() Player:LoadCharacter() LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character) end) end)
					end
				end
			end)
		end)
		game:GetService("Players").PlayerRemoving:connect(function(Player)
			print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' leaving")	
		end)
		game:GetService("RunService"):Run()
		game.Workspace:InsertContent("rbxasset://fonts/libraries.rbxm")
		pcall(function() game.Close:connect(function() NetworkServer:Stop() end) end)
		NetworkServer.IncommingConnection:connect(IncommingConnection)
	else
		Server = game:GetService("NetworkServer")
		RunService = game:GetService("RunService")
		Server:start(Port, 20)
		RunService:run()
		game.Workspace:InsertContent("rbxasset://fonts/libraries.rbxm")
		game:GetService("Players").MaxPlayers = PlayerLimit
		game:GetService("Players").PlayerAdded:connect(function(Player)
			if (game:GetService("Players").NumPlayers > game:GetService("Players").MaxPlayers) then
				local message = Instance.new("Message")
				message.Text = "You were kicked. Reason: Too many players on server."
				message.Parent = Player
				wait(2)
				Player:remove()
				print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' kicked. Reason: Too many players on server.")
			else
				print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' added")
				Player:LoadCharacter()
				LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character)
			end
				while true do 
					wait(0.001)
					if (Player.Character ~= nil) then
						if (Player.Character.Humanoid.Health == 0) then
							wait(5)
							Player:LoadCharacter()
							LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character)
						elseif (Player.Character.Parent == nil) then 
							wait(5)
							Player:LoadCharacter() -- to make sure nobody is deleted.
							LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character)
						end
					end
				end
			end)
		game:GetService("Players").PlayerRemoving:connect(function(Player)
			print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' leaving")	
		end)
		game:GetService("RunService"):Run()
		pcall(function() game.Close:connect(function() Server:Stop() end) end)
		Server.IncommingConnection:connect(IncommingConnection)
	end
end

function CSConnect(UserID,ServerIP,ServerPort,PlayerName,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID,IconType,Ticket)
	if (rbxlegacyversion == "delta" or rbxlegacyversion == "delta-gamma" or rbxlegacyversion == "omega" or rbxlegacyversion == "delta-pre-gamma" or rbxlegacyversion == "delta-omega" or rbxlegacyversion == "delta-beta" or rbxlegacyversion == "delta-pre-gamma-beta") then
		pcall(function() game:SetPlaceID(-1, false) end)
		pcall(function() game:GetService("Players"):SetChatStyle(Enum.ChatStyle.ClassicAndBubble) end)
		game:GetService("RunService"):Run()
		assert((ServerIP~=nil and ServerPort~=nil),"CSConnect Error: ServerIP and ServerPort must be defined.")
		local function SetMessage(Message) game:SetMessage(Message) end
		local Visit,NetworkClient,PlayerSuccess,Player,ConnectionFailedHook=game:GetService("Visit"),game:GetService("NetworkClient")

		local function GetClassCount(Class,Parent)
			local Objects=Parent:GetChildren()
			local Number=0
			for Index,Object in pairs(Objects) do
				if (Object.className==Class) then
					Number=Number+1
				end
				Number=Number+GetClassCount(Class,Object)
			end
			return Number
		end

		local function RequestCharacter(Replicator)
			local Connection
			Connection=Player.Changed:connect(function(Property)
				if (Property=="Character") then
					game:ClearMessage()
				end
			end)
			SetMessage("Requesting character...")
			Replicator:RequestCharacter()
			SetMessage("Waiting for character...")
		end

		local function Disconnection(Peer,LostConnection)
			SetMessage("You have lost connection to the game")
		end

		local function ConnectionAccepted(Peer,Replicator)
			Replicator.Disconnection:connect(Disconnection)
			local RequestingMarker=true
			game:SetMessageBrickCount()
			local Marker=Replicator:SendMarker()
			Marker.Received:connect(function()
				RequestingMarker=false
				RequestCharacter(Replicator)
			end)
			while RequestingMarker do
				Workspace:ZoomToExtents()
				wait(0.5)
			end
		end

		local function ConnectionFailed(Peer, Code, why)
			SetMessage("Failed to connect to the Game. (ID="..Code.." ["..why.."])")
		end

		pcall(function() settings().Diagnostics:LegacyScriptMode() end)
		pcall(function() game:SetRemoteBuildMode(true) end)
		SetMessage("Connecting to server...")
		NetworkClient.ConnectionAccepted:connect(ConnectionAccepted)
		ConnectionFailedHook=NetworkClient.ConnectionFailed:connect(ConnectionFailed)
		NetworkClient.ConnectionRejected:connect(function()
			pcall(function() ConnectionFailedHook:disconnect() end)
			SetMessage("Failed to connect to the Game. (Connection rejected)")
		end)

		pcall(function() NetworkClient.Ticket=Ticket or "" end) -- 2008 client has no ticket :O
		PlayerSuccess,Player=pcall(function() return NetworkClient:PlayerConnect(UserID,ServerIP,ServerPort) end)

		if (not PlayerSuccess) then
			SetMessage("Failed to connect to the Game. (Invalid IP Address)")
			NetworkClient:Disconnect()
		end

		if (not PlayerSuccess) then
			local Error,Message=pcall(function()
				Player=game:GetService("Players"):CreateLocalPlayer(UserID)
				NetworkClient:Connect(ServerIP,ServerPort)
			end)
			if (not Error) then
				SetMessage("Failed to connect to the Game.")
			end
		end
		pcall(function() Player:SetUnder13(false) end)
		if (rbxlegacyversion == "delta" or rbxlegacyversion == "omega" or rbxlegacyversion == "delta-omega") then
			if (IconType == "BC") then
				Player:SetMembershipType(Enum.MembershipType.BuildersClub)
			elseif (IconType == "TBC") then
				Player:SetMembershipType(Enum.MembershipType.TurboBuildersClub)
			elseif  (IconType == "OBC") then
				Player:SetMembershipType(Enum.MembershipType.OutrageousBuildersClub)
			elseif  (IconType == "NBC") then
				Player:SetMembershipType(Enum.MembershipType.None)
			end
		end
		pcall(function() Player:SetAccountAge(365) end)
		Player:SetSuperSafeChat(false)
		Player.CharacterAppearance=0
		pcall(function() Player.Name=PlayerName or "" end)
		pcall(function() Visit:SetUploadUrl("") end)
		game:GetService("Visit")
		if (rbxlegacyversion == "delta") then
			game.CoreGui.RobloxGui.TopLeftControl.Help:Remove()
		elseif (rbxlegacyversion == "omega" or rbxlegacyversion == "delta-omega") then
			game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.Help:Remove()
			game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.ReportAbuse:Remove()
			game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.RecordToggle:Remove()
			game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.Screenshot:Remove()
			game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.ToggleFullScreen:Remove()
			game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.TogglePlayMode:Remove()
			game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.Exit:Remove()
			wait(5) -- we have to wait until the menu gets built, don't we?
			Player.PlayerGui.Menu.UserSettingsShield.Settings.SettingsStyle.GameSettingsMenu.FullscreenCheckbox:SetVerb("ToggleFullScreen")
			Player.PlayerGui.Menu.UserSettingsShield.Settings.SettingsStyle.GameMainMenu.ScreenshotButton:SetVerb("Screenshot")
		end
		InitalizeClientAppearance(Player,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID)
	else
		pcall(function() game:SetPlaceID(-1, false) end)
		pcall(function() game:GetService("Players"):SetChatStyle(Enum.ChatStyle.ClassicAndBubble) end)
	
		local suc, err = pcall(function()
			client = game:GetService("NetworkClient")
			player = game:GetService("Players"):CreateLocalPlayer(UserID) 
			player:SetSuperSafeChat(false)
			pcall(function() player:SetUnder13(false) end)
			pcall(function() player:SetAccountAge(365) end)
			player.CharacterAppearance=0
			pcall(function() player.Name=PlayerName or "" end)
			game:GetService("Visit")
			InitalizeClientAppearance(player,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID)
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
			game:SetMessage("Connecting to server...")
			client.ConnectionAccepted:connect(connected)
			client.ConnectionRejected:connect(rejected)
			client.ConnectionFailed:connect(failed)
			client:Connect(ServerIP,ServerPort, 0, 20)
      			end)
		end

		if not suc then
			local x = Instance.new("Message")
			x.Text = err
			x.Parent = workspace
			wait(math.huge)
		end
end

function CSSolo(UserID,PlayerName,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID,IconType)
	if (rbxlegacyversion == "omega" or rbxlegacyversion == "delta-omega") then
		game:GetService("RunService"):Run()
	else
		game:GetService("RunService"):run()
	end
	game.Workspace:InsertContent("rbxasset://fonts//libraries.rbxm")
	if (rbxlegacyversion == "delta") then
		game.CoreGui.RobloxGui.TopLeftControl.Help:Remove()
	elseif (rbxlegacyversion == "omega" or rbxlegacyversion == "delta-omega") then
		game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.Help:Remove()
      	game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.ReportAbuse:Remove()
		game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.RecordToggle:Remove()
        game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.Screenshot:Remove()
        game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.ToggleFullScreen:Remove()
        game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.TogglePlayMode:Remove()
		game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.Exit:Remove()
	end
	--[[elseif (rbxlegacyversion == "ultra") then
		game.CoreGui.RobloxGui.ControlFrame.BottomRightControl:Remove()
	end]]
	local plr = game.Players:CreateLocalPlayer(UserID)
	plr.Name = PlayerName
	plr:LoadCharacter()
	if (rbxlegacyversion == "omega") then
		wait(5) -- we have to wait until the menu gets built, don't we?
		plr.PlayerGui.Menu.UserSettingsShield.Settings.SettingsStyle.GameSettingsMenu.FullscreenCheckbox:SetVerb("ToggleFullScreen")
		plr.PlayerGui.Menu.UserSettingsShield.Settings.SettingsStyle.GameMainMenu.ScreenshotButton:SetVerb("Screenshot")
	end
	pcall(function() plr:SetUnder13(false) end)
	if (rbxlegacyversion == "delta" or rbxlegacyversion == "omega" or rbxlegacyversion == "delta-omega") then
		if (IconType == "BC") then
			plr:SetMembershipType(Enum.MembershipType.BuildersClub)
		elseif (IconType == "TBC") then
			plr:SetMembershipType(Enum.MembershipType.TurboBuildersClub)
		elseif  (IconType == "OBC") then
			plr:SetMembershipType(Enum.MembershipType.OutrageousBuildersClub)
		elseif  (IconType == "NBC") then
			plr:SetMembershipType(Enum.MembershipType.None)
		end
	end
	pcall(function() plr:SetAccountAge(365) end)
	plr.CharacterAppearance=0
	InitalizeClientAppearance(plr,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID)
	LoadCharacterNew(newWaitForChild(plr,"Appearance"),plr.Character)
	game:GetService("Visit")
	while true do wait()
		if (plr.Character.Humanoid.Health == 0) then
			wait(5)
			plr:LoadCharacter()
			LoadCharacterNew(newWaitForChild(plr,"Appearance"),plr.Character)
		end
	end
end

_G.SetRBXLegacyVersion=SetRBXLegacyVersion
_G.CSServer=CSServer
_G.CSConnect=CSConnect
_G.CSSolo=CSSolo
