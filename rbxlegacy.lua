--coded by Bitl and Carrot
--stuff was borrowed from RBXBanland, EnergyCell, John, and the RBXPri team

function waitForChild(instance, name) -- for everything else
	while not instance:FindFirstChild(name) do
		instance.ChildAdded:wait()
	end
end

rbxlegacyversion = 0

function SetRBXLegacyVersion(Version)
	rbxlegacyversion = Version
	if (rbxlegacyversion == 1) then -- Pre Alpha
		settings().Rendering.frameRateManager = 2
    	settings().Rendering.graphicsMode = 2
		settings().Network.MaxSendBuffer = 1000000
		settings().Network.PhysicsReplicationUpdateRate = 1000000
		settings().Network.SendRate = 1000000
		settings().Network.PhysicsSend = 1 -- 1==RoundRobin
	elseif (rbxlegacyversion == 2) then -- Ext. Pre Alpha
		settings().Rendering.frameRateManager = 2
		settings().Rendering.graphicsMode = 2
		settings().Network.MaxSendBuffer = 1000000
		settings().Network.PhysicsReplicationUpdateRate = 1000000
		settings().Network.SendRate = 1000000
		settings().Network.PhysicsSend = 1 -- 1==RoundRobin
	elseif (rbxlegacyversion == 3) then -- Alpha
		settings().Rendering.frameRateManager = 2
		settings().Network.MaxSendBuffer = 1000000
		settings().Network.PhysicsReplicationUpdateRate = 1000000
		settings().Network.SendRate = 1000000
		settings().Network.PhysicsSend = 1 -- 1==RoundRobin
	elseif (rbxlegacyversion == 4) then -- Beta
		settings().Rendering.FrameRateManager = 2
		settings().Network.SendRate = 30
		settings().Network.ReceiveRate = 60
		settings().Network.PhysicsSend = 1 -- 1==RoundRobin
	elseif (rbxlegacyversion == 5) then -- Beta Pre-Gamma
		settings().Rendering.FrameRateManager = 2
		settings().Network.DataSendRate = 30
		settings().Network.PhysicsSendRate = 20
		settings().Network.ReceiveRate = 60
	elseif (rbxlegacyversion == 6) then -- Pre-Gamma
		settings().Rendering.FrameRateManager = 2
		settings().Network.DataSendRate = 30
		settings().Network.PhysicsSendRate = 20
		settings().Network.ReceiveRate = 60
	elseif (rbxlegacyversion == 7) then -- Gamma
		settings().Rendering.FrameRateManager = 2
		settings().Network.DataSendRate = 30
		settings().Network.PhysicsSendRate = 20
		settings().Network.ReceiveRate = 60
		settings().Diagnostics.LuaRamLimit = 0
		pcall(function() game:GetService("ScriptContext").ScriptsDisabled = false end)
		pcall(function() settings().Diagnostics:LegacyScriptMode() end)
	elseif (rbxlegacyversion == 8) then -- Delta
		settings().Rendering.FrameRateManager = 2
		settings().Diagnostics.LuaRamLimit = 0
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
		waitForChild(game.GuiRoot,"ScoreHud")
		game.GuiRoot.ScoreHud:Remove()
	elseif (rbxlegacyversion == 9) then -- Delta Omega
		settings().Rendering.FrameRateManager = 2
		settings().Diagnostics.LuaRamLimit = 0
		pcall(function() game:GetService("ScriptContext").ScriptsDisabled = false end)
		pcall(function() settings().Diagnostics:LegacyScriptMode() end)
		waitForChild(game.GuiRoot,"ScoreHud")
		game.GuiRoot.ScoreHud:Remove()
	elseif (rbxlegacyversion == 10) then -- Omega
		settings().Rendering.FrameRateManager = 2
		settings().Diagnostics.LuaRamLimit = 0
		pcall(function() game:GetService("ScriptContext").ScriptsDisabled = false end)
		pcall(function() settings().Diagnostics:LegacyScriptMode() end)
		--stamper
		pcall(function() game:GetService("ScriptContext").ScriptsDisabled = false end)
		pcall(function() settings().Diagnostics:LegacyScriptMode() end)
		pcall(function() game:GetService("InsertService"):SetBaseSetsUrl("http://www.roblox.com/Game/Tools/InsertAsset.ashx?nsets=10&type=base") end)
		pcall(function() game:GetService("InsertService"):SetUserSetsUrl("http://www.roblox.com/Game/Tools/InsertAsset.ashx?nsets=20&type=user&userid=%d") end)
		pcall(function() game:GetService("InsertService"):SetCollectionUrl("http://www.roblox.com/Game/Tools/InsertAsset.ashx?sid=%d") end)
		pcall(function() game:GetService("InsertService"):SetAssetUrl("http://www.roblox.com/Asset/?id=%d") end)
		pcall(function() game:GetService("InsertService"):SetAssetVersionUrl("http://www.roblox.com/Asset/?assetversionid=%d") end)
		pcall(function() game:GetService("SocialService"):SetGroupUrl("http://assetgame.roblox.com/Game/LuaWebService/HandleSocialRequest.ashx?method=IsInGroup&playerid=%d&groupid=%d") end)
		pcall(function() game:GetService("BadgeService"):SetPlaceId(-1) end)
		pcall(function() game:GetService("BadgeService"):SetIsBadgeLegalUrl("") end)
		pcall(function() game:GetService("ScriptInformationProvider"):SetAssetUrl("http://www.roblox.com/Asset/") end)
		pcall(function() game:GetService("ContentProvider"):SetBaseUrl("http://www.roblox.com/") end)
	elseif (rbxlegacyversion == 11) then -- Ultra
		settings().Rendering.FrameRateManager = 2
		settings().Diagnostics.LuaRamLimit = 0
		pcall(function() game:GetService("ScriptContext").ScriptsDisabled = false end)
		pcall(function() settings().Diagnostics:LegacyScriptMode() end)
		pcall(function() game:GetService("InsertService"):SetBaseSetsUrl("http://www.roblox.com/Game/Tools/InsertAsset.ashx?nsets=10&type=base") end)
		pcall(function() game:GetService("InsertService"):SetUserSetsUrl("http://www.roblox.com/Game/Tools/InsertAsset.ashx?nsets=20&type=user&userid=%d") end)
		pcall(function() game:GetService("InsertService"):SetCollectionUrl("http://www.roblox.com/Game/Tools/InsertAsset.ashx?sid=%d") end)
		pcall(function() game:GetService("InsertService"):SetAssetUrl("http://www.roblox.com/Asset/?id=%d") end)
		pcall(function() game:GetService("InsertService"):SetAssetVersionUrl("http://www.roblox.com/Asset/?assetversionid=%d") end)
		pcall(function() game:GetService("SocialService"):SetGroupUrl("http://assetgame.roblox.com/Game/LuaWebService/HandleSocialRequest.ashx?method=IsInGroup&playerid=%d&groupid=%d") end)
		pcall(function() game:GetService("BadgeService"):SetPlaceId(-1) end)
		pcall(function() game:GetService("BadgeService"):SetIsBadgeLegalUrl("") end)
		pcall(function() game:GetService("ScriptInformationProvider"):SetAssetUrl("http://www.roblox.com/Asset/") end)
		pcall(function() game:GetService("ContentProvider"):SetBaseUrl("http://www.roblox.com/") end)
	end
	print("RBXLegacy client version '" .. rbxlegacyversion .. "' loaded.")
end

rbxversion = version()
print("ROBLOX Client version '" .. rbxversion .. "' loaded.")

function newWaitForChild(newParent,name) -- for char
	local returnable = nil
	if newParent:FindFirstChild(name) then
		returnable = newParent:FindFirstChild(name)
	else 
		repeat wait() returnable = newParent:FindFirstChild(name)  until returnable ~= nil
	end
	return returnable
end

function LoadCharacterNew(playerApp,newChar,newBackpack)
	--authentic roblox style loading
	local charparts = {[1] = newWaitForChild(newChar,"Head"),[2] = newWaitForChild(newChar,"Torso"),[3] = newWaitForChild(newChar,"Left Arm"),[4] = newWaitForChild(newChar,"Right Arm"),[5] = newWaitForChild(newChar,"Left Leg"),[6] = newWaitForChild(newChar,"Right Leg")}
	for _,newVal in pairs(playerApp:GetChildren()) do
			newWaitForChild(newVal,"CustomizationType")
			local customtype = newVal:FindFirstChild("CustomizationType")
			if (customtype.Value == 1) then 
				pcall(function() 
					newWaitForChild(newVal,"ColorIndex")
					local colorindex = newVal:FindFirstChild("ColorIndex")
					charparts[colorindex.Value].BrickColor = newVal.Value 
				end)
			elseif (customtype.Value == 2)  then
				if (rbxlegacyversion > 1) then
					pcall(function()
						local newHat = game.Workspace:InsertContent("rbxasset://../../../avatar/hats/"..newVal.Value)
						if newHat[1] then 
							if newHat[1].className == "Hat" then
								newHat[1].Parent = newChar
							else
								newHat[1]:remove()
							end
						end
					end)
				end
			elseif (customtype.Value == 3)  then
				if (rbxlegacyversion > 1) then
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
			elseif (customtype.Value == 4)  then
				if (rbxlegacyversion > 2) then
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
			elseif (customtype.Value == 5)  then
				if (rbxlegacyversion > 2) then
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
			elseif (customtype.Value == 6)  then
				if (rbxlegacyversion > 5) then
					pcall(function()
						local newFace = game.Workspace:InsertContent("rbxasset://../../../avatar/faces/"..newVal.Value)
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
			elseif (customtype.Value == 7) then 
				if (rbxlegacyversion > 5) then
					pcall(function()
						local newPart = game.Workspace:InsertContent("rbxasset://../../../avatar/heads/"..newVal.Value)
						if newPart[1] then 
							if newPart[1].className == "SpecialMesh" or newPart[1].className == "CylinderMesh" or newPart[1].className == "BlockMesh" then
								newWaitForChild(charparts[1],"Mesh"):remove()
								newPart[1].Parent = charparts[1]
							else
								newPart[1]:remove()
							end
						end
					end)
				end
			elseif (customtype.Value == 8) then 
				if (rbxlegacyversion > 7) then
					pcall(function()
						local meshindex = newVal:FindFirstChild("MeshIndex")
						local newPart = game.Workspace:InsertContent("rbxasset://../../../avatar/bodies/"..meshindex.Value.."/"..newVal.Value)
						if newPart[1] then 
							if newPart[1].className == "SpecialMesh" then
								newWaitForChild(newVal,"MeshIndex")
								newPart[1].Parent = charparts[meshindex.Value]
							else
								newPart[1]:remove()
							end
						end
					end)
				end
			elseif (customtype.Value == 9) then 
				if (rbxlegacyversion > 7) then
					pcall(function()
						local newGear = game.Workspace:InsertContent("rbxasset://../../../avatar/gears/"..newVal.Value)
						if newGear[1] then 
							if newGear[1].className == "Tool" then
								if (ReadGearInfo(newGear[1], playerApp) == true) then
									if (playerApp.StarterGear) then
										for _,gearCheck in pairs(playerApp.StarterGear:GetChildren()) do
											if (gearCheck ~= nil) then
												if (gearCheck:isA("Tool")) then
													if (gearCheck.Name ~= newGear[1].Name) then
														newGear[1].Parent = playerApp.StarterGear
													else
														newGear[1]:remove()
													end
												end
											end
										end
									else
										for _,gearCheck in pairs(playerApp.Backpack:GetChildren()) do
											if (gearCheck ~= nil) then
												if (gearCheck:isA("Tool")) then
													if (gearCheck.Name ~= newGear[1].Name) then
														newGear[1].Parent = playerApp.Backpack
													else
														newGear[1]:remove()
													end
												end
											end
										end
									end
								else
									newGear[1]:remove()
								end
							else
								newGear[1]:remove()
							end
						end
					end)
				end
			end
		end
	end

function ReadGearInfo(newTool,player)
	if newTool.className == "Tool" then
		for _,GearVal in pairs(newTool:GetChildren()) do
			newWaitForChild(GearVal,"GearType")
			local GearType = newTool:FindFirstChild("GearType")
			--GearType must be an IntBool. This must also be placed in the root of the tool.
			newWaitForChild(game.Lighting,"AllowedGearTypes")
			if (GearType == 1) then
				if (game.Lighting.AllowedGearTypes.Melee == true) then
					return true
				end
			elseif (GearType == 2) then
				if (game.Lighting.AllowedGearTypes.PowerUp == true) then
					return true
				end
			elseif (GearType == 3) then
				if (game.Lighting.AllowedGearTypes.Ranged == true) then
					return true
				end
			elseif (GearType == 4) then
				if (game.Lighting.AllowedGearTypes.Navigation == true) then
					return true
				end
			elseif (GearType == 5) then
				if (game.Lighting.AllowedGearTypes.Explosives == true) then
					return true
				end
			elseif (GearType == 6) then
				if (game.Lighting.AllowedGearTypes.Musical == true) then
					return true
				end
			elseif (GearType == 7) then
				if (game.Lighting.AllowedGearTypes.Social == true) then
					return true
				end
			elseif (GearType == 8) then
				if (game.Lighting.AllowedGearTypes.Transport == true) then
					return true
				end
			elseif (GearType == 9) then
				if (game.Lighting.AllowedGearTypes.Building == true) then
					return true
				end
			end
		end
	else
		return false
	end
end

function InitalizeClientAppearance(Player,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID,Gear1,Gear2,Gear3)
	local newCharApp = Instance.new("IntValue",Player)
	newCharApp.Name = "Appearance"
	--BODY COLORS
	for i=1,6,1 do
		local BodyColor = Instance.new("BrickColorValue",newCharApp)
		if (i == 1) then
			if (HeadColorID ~= nil) then
				BodyColor.Value = BrickColor.new(HeadColorID)
				BodyColor.Name = "HeadColor (ID: "..HeadColorID..")"
			else
				BodyColor.Value = BrickColor.new(1)
				BodyColor.Name = "HeadColor (ID: 1)"
			end
		elseif (i == 2) then
			if (TorsoColorID ~= nil) then
				BodyColor.Value = BrickColor.new(TorsoColorID)
				BodyColor.Name = "TorsoColor (ID: "..TorsoColorID..")"
			else
				BodyColor.Value = BrickColor.new(1)
				BodyColor.Name = "TorsoColor (ID: 1)"
			end
		elseif (i == 3) then
			if (LeftArmColorID ~= nil) then
				BodyColor.Value = BrickColor.new(LeftArmColorID)
				BodyColor.Name = "LeftArmColor (ID: "..LeftArmColorID..")"
			else
				BodyColor.Value = BrickColor.new(1)
				BodyColor.Name = "LeftArmColor (ID: 1)"
			end
		elseif (i == 4) then
			if (RightArmColorID ~= nil) then
				BodyColor.Value = BrickColor.new(RightArmColorID)
				BodyColor.Name = "RightArmColor (ID: "..RightArmColorID..")"
			else
				BodyColor.Value = BrickColor.new(1)
				BodyColor.Name = "RightArmColor (ID: 1)"
			end
		elseif (i == 5) then
			if (LeftLegColorID ~= nil) then
				BodyColor.Value = BrickColor.new(LeftLegColorID)
				BodyColor.Name = "LeftLegColor (ID: "..LeftLegColorID..")"
			else
				BodyColor.Value = BrickColor.new(1)
				BodyColor.Name = "LeftLegColor (ID: 1)"
			end
		elseif (i == 6) then
			if (RightLegColorID ~= nil) then
				BodyColor.Value = BrickColor.new(RightLegColorID)
				BodyColor.Name = "RightLegColor (ID: "..RightLegColorID..")"
			else
				BodyColor.Value = BrickColor.new(1)
				BodyColor.Name = "RightLegColor (ID: 1)"
			end
		end
		local typeValue = Instance.new("NumberValue")
		typeValue.Name = "CustomizationType"
		typeValue.Parent = BodyColor
		typeValue.Value = 1
		local indexValue = Instance.new("NumberValue")
		indexValue.Name = "ColorIndex"
		indexValue.Parent = BodyColor
		indexValue.Value = i
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
		local BodyMesh2 = Instance.new("StringValue",newCharApp)
		local BodyMesh3 = Instance.new("StringValue",newCharApp)
		local BodyMesh4 = Instance.new("StringValue",newCharApp)
		local BodyMesh5 = Instance.new("StringValue",newCharApp)
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
				BodyMesh2.Value = LArmID
				BodyMesh2.Name = LArmID
			else
				BodyMesh2.Value = "DefaultLArm.rbxm"
				BodyMesh2.Name = "DefaultLArm.rbxm"
			end
		elseif (i == 4) then
			if (RArmID ~= nil) then
				BodyMesh3.Value = RArmID
				BodyMesh3.Name = RArmID
			else
				BodyMesh3.Value = "DefaultRArm.rbxm"
				BodyMesh3.Name = "DefaultRArm.rbxm"
			end
		elseif (i == 5) then
			if (LLegID ~= nil) then
				BodyMesh4.Value = LLegID
				BodyMesh4.Name = LLegID
			else
				BodyMesh4.Value = "DefaultLLeg.rbxm"
				BodyMesh4.Name = "DefaultLLeg.rbxm"
			end
		elseif (i == 6) then
			if (RLegID ~= nil) then
				BodyMesh5.Value = RLegID
				BodyMesh5.Name = RLegID
			else
				BodyMesh5.Value = "DefaultRLeg.rbxm"
				BodyMesh5.Name = "DefaultRLeg.rbxm"
			end
		end
		local typeValue = Instance.new("NumberValue")
		typeValue.Name = "CustomizationType"
		typeValue.Parent = BodyMesh
		typeValue.Value = 8
		local typeValue2 = Instance.new("NumberValue")
		typeValue2.Name = "CustomizationType"
		typeValue2.Parent = BodyMesh2
		typeValue2.Value = 8
		local typeValue3 = Instance.new("NumberValue")
		typeValue3.Name = "CustomizationType"
		typeValue3.Parent = BodyMesh3
		typeValue3.Value = 8
		local typeValue4 = Instance.new("NumberValue")
		typeValue4.Name = "CustomizationType"
		typeValue4.Parent = BodyMesh4
		typeValue4.Value = 8
		local typeValue5 = Instance.new("NumberValue")
		typeValue5.Name = "CustomizationType"
		typeValue5.Parent = BodyMesh5
		typeValue5.Value = 8
		local indexValue = Instance.new("NumberValue")
		indexValue.Name = "MeshIndex"
		indexValue.Parent = BodyMesh
		indexValue.Value = i
		local indexValue2 = Instance.new("NumberValue")
		indexValue2.Name = "MeshIndex"
		indexValue2.Parent = BodyMesh2
		indexValue2.Value = i
		local indexValue3 = Instance.new("NumberValue")
		indexValue3.Name = "MeshIndex"
		indexValue3.Parent = BodyMesh3
		indexValue3.Value = i
		local indexValue4 = Instance.new("NumberValue")
		indexValue4.Name = "MeshIndex"
		indexValue4.Parent = BodyMesh4
		indexValue4.Value = i
		local indexValue5 = Instance.new("NumberValue")
		indexValue5.Name = "MeshIndex"
		indexValue5.Parent = BodyMesh5
		indexValue5.Value = i
	end
	--GEARS
	for i=1,3,1 do
		local newGear = Instance.new("StringValue",newCharApp)
		if (i == 1) then
			if (Gear1 ~= nil) then
				newGear.Value = Gear1
				newGear.Name = Gear1
			else
				newGear.Value = "NoGear.rbxm"
				newGear.Name = "NoGear.rbxm"
			end
		elseif (i == 2) then
			if (Gear2 ~= nil) then
				newGear.Value = Gear2
				newGear.Name = Gear2
			else
				newGear.Value = "NoGear.rbxm"
				newGear.Name = "NoGear.rbxm"
			end
		elseif (i == 3) then
			if (Gear3 ~= nil) then
				newGear.Value = Gear3
				newGear.Name = Gear3
			else
				newGear.Value = "NoGear.rbxm"
				newGear.Name = "NoGear.rbxm"
			end
		end
		local typeValue = Instance.new("NumberValue")
		typeValue.Name = "CustomizationType"
		typeValue.Parent = newGear
		typeValue.Value = 9
	end
end

function CSServer(Port,PlayerLimit,RespawnTime,IsPersonalServer,ChatType,HostID,Blacklist1,Blacklist2,Blacklist3,Blacklist4,Blacklist5,Blacklist6,Blacklist7,Blacklist8,MeleeGT,PowerUpGT,RangedGT,NavigationGT,ExplosivesGT,MusicalGT,SocialGT,TransportGT,BuildingGT) -- GT is Gear Type, not Graphictoria
	assert((type(Port)~="number" or tonumber(Port)~=nil or Port==nil),"CSRun Error: Port must be nil or a number.")
	local NetworkServer=game:GetService("NetworkServer")
	local RunService=game:GetService("RunService")
	pcall(NetworkServer.Stop,NetworkServer)
	if (rbxlegacyversion >= 8) then
		NetworkServer:Start(Port)
		RunService:Run()
	else
		NetworkServer:start(Port, 20)
		RunService:run()
	end
	
	game.Workspace:InsertContent("rbxasset://fonts/libraries.rbxm")
	game:GetService("Players").PlayerAdded:connect(function(Player)	
		if (rbxlegacyversion < 9) then
			game:GetService("Players").MaxPlayers = PlayerLimit
			if (game:GetService("Players").NumPlayers > game:GetService("Players").MaxPlayers) then
				local message = Instance.new("Message")
				message.Text = "You were kicked. Reason: Too many players on server."
				message.Parent = Player
				wait(2)
				Player:remove()
				print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' kicked. Reason: Too many players on server.")
			end
		end
			
		if (Player.userId == Blacklist1 or Player.userId == Blacklist2 or Player.userId == Blacklist3 or Player.userId == Blacklist4 or Player.userId == Blacklist5 or Player.userId == Blacklist6 or Player.userId == Blacklist7 or Player.userId == Blacklist8) then
			local message = Instance.new("Message")
			message.Text = "You have been blacklisted from this server."
			message.Parent = Player
			wait(2)
			Player:remove()
			print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' kicked. Reason: Player is banned from playing this server.")
	--[[elseif (Player.Name == "QuackIAttack" or Player.Name == "connor" or Player.Name == "CPunch" or Player.Name == "Carrot" or Player.Name == "Bitl" or Player.Name == "khanglegos" or Player.Name == "Nukley" or Player.Name == "OliverA" or Player.Name == "coke" or Player.Name == "Peridorky" or Player.Name == "Raymonf" or Player.Name == "romulo27" or Player.Name == "TheLivingBee" or Player.Name == "robloxtester" or Player.Name == "winsupermario1234" and Player.isAdmin == false) then
			wait(2)
			Player:Remove()
			print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' kicked. Reason: Being an impostor")]]
		else
			print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' added")
			Player:LoadCharacter()
			if (rbxlegacyversion < 8) then
				LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character,Player.Backpack)
			end
		end
			
		if (rbxlegacyversion >= 8) then
			Player.CharacterAdded:connect(function(char)
				LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character,Player.Backpack)
			end)
			Player.Changed:connect(function(Property)
				if (Property=="Character") and (Player.Character~=nil) then
					local Character=Player.Character
					local Humanoid=Character:FindFirstChild("Humanoid")
					if (Humanoid~=nil) then
						Humanoid.Died:connect(function() delay(RespawnTime,function() Player:LoadCharacter() LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character,Player.Backpack) end) end)
					end
				end
			end)
		else
			while true do 
				wait(0.001)
				if (Player.Character ~= nil) then
					if (Player.Character.Humanoid.Health == 0) then
						wait(RespawnTime)
						Player:LoadCharacter()
						LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character,Player.Backpack)
					elseif (Player.Character.Parent == nil) then 
						wait(RespawnTime)
						Player:LoadCharacter() -- to make sure nobody is deleted.
						LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character,Player.Backpack)
					end
				end
			end
		end
	end)
	game:GetService("Players").PlayerRemoving:connect(function(Player)
		print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' leaving")	
	end)
	pcall(function() game.Close:connect(function() NetworkServer:Stop() end) end)
	NetworkServer.IncommingConnection:connect(IncommingConnection)
	-- perbsosnal sebrs!
	if IsPersonalServer == true then
		pcall(function() game:GetService("PersonalServerService") end)
		pcall(function() game.IsPersonalServer(true) end)
	end
	local HostIDValue = Instance.new("StringValue")
	HostIDValue.Parent = game.Lighting
	HostIDValue.Name = "HostID"
	HostIDValue.Value = "" .. HostID .. ""
	-- gear types!!!!!!!
	local AllowedGearTypes = Instance.new("StringValue")
	AllowedGearTypes.Name = "AllowedGearTypes"
	AllowedGearTypes.Parent = game.Lighting
	-- ok, lets register our s e p e r a t e  g e a r s
	local MeleeGTR = Instance.new("BoolValue")
	MeleeGTR.Parent = AllowedGearTypes
	MeleeGTR.Name = "Melee"
	MeleeGTR.Value = MeleeGT
	local PowerUpGTR = Instance.new("BoolValue")
	PowerUpGTR.Parent = AllowedGearTypes
	PowerUpGTR.Name = "PowerUp"
	PowerUpGTR.Value = PowerUpGT
	local RangedGTR = Instance.new("BoolValue")
	RangedGTR.Parent = AllowedGearTypes
	RangedGTR.Name = "Ranged"
	RangedGTR.Value = RangedGT
	local NavigationGTR = Instance.new("BoolValue")
	NavigationGTR.Parent = AllowedGearTypes
	NavigationGTR.Name = "Navigation"
	NavigationGTR.Value = NavigationGT
	local ExplosivesGTR = Instance.new("BoolValue")
	ExplosivesGTR.Parent = AllowedGearTypes
	ExplosivesGTR.Name = "Explosives"
	ExplosivesGTR.Value = ExplosivesGT
	local MusicalGTR = Instance.new("BoolValue")
	MusicalGTR.Parent = AllowedGearTypes
	MusicalGTR.Name = "Musical"
	MusicalGTR.Value = MusicalGT
	local SocialGTR = Instance.new("BoolValue")
	SocialGTR.Parent = AllowedGearTypes
	SocialGTR.Name = "Social"
	SocialGTR.Value = SocialGT
	local TransportGTR = Instance.new("BoolValue")
	TransportGTR.Parent = AllowedGearTypes
	TransportGTR.Name = "Transport"
	TransportGTR.Value = TransportGT
	local BuildingGTR = Instance.new("BoolValue")
	BuildingGTR.Parent = AllowedGearTypes
	BuildingGTR.Name = "Building"
	BuildingGTR.Value = BuildingGT
	-- chat types
	if rbxlegacyversion >= 7 then
		if ChatType == "Both" then
			pcall(function() game:GetService("Players"):SetChatStyle(Enum.ChatStyle.ClassicAndBubble) end)
		elseif ChatType == "Classic" then
			pcall(function() game:GetService("Players"):SetChatStyle(Enum.ChatStyle.Classic) end)
		elseif ChatType == "Bubble" then
			pcall(function() game:GetService("Players"):SetChatStyle(Enum.ChatStyle.Bubble) end)
		end
	end
end

function CSConnect(UserID,ServerIP,ServerPort,PlayerName,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID,Gear1,Gear2,Gear3,IconType,IsAdminUser,Ticket)
	if (rbxlegacyversion >= 8) then
		pcall(function() game:SetPlaceID(-1, false) end)
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
		if (rbxlegacyversion >= 8) then
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
		if (rbxlegacyversion == 8) then
			game.CoreGui.RobloxGui.TopLeftControl.Help:Remove()
		elseif (rbxlegacyversion > 8) then
			game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.Help:Remove()
			game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.ReportAbuse:Remove()
			game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.RecordToggle:Remove()
			game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.Screenshot:Remove()
			game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.ToggleFullScreen:Remove()
			game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.TogglePlayMode:Remove()
			game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.Exit:Remove()
			-- set up listeners for type of mouse mode
			waitForChild(Player,"PlayerGui")
			waitForChild(Player.PlayerGui,"UserSettingsShield")
			waitForChild(Player.PlayerGui.UserSettingsShield,"Settings")
			waitForChild(Player.PlayerGui.UserSettingsShield.Settings,"SettingsStyle")
			waitForChild(Player.PlayerGui.UserSettingsShield.Settings.SettingsStyle,"GameSettingsMenu")
			waitForChild(Player.PlayerGui.UserSettingsShield.Settings.SettingsStyle.GameSettingsMenu, "CameraField")
			waitForChild(Player.PlayerGui.UserSettingsShield.Settings.SettingsStyle.GameSettingsMenu.CameraField, "DropDownMenuButton")
	
			UserSettings().GameSettings.ControlMode.Changed:connect(function()
				if UserSettings().GameSettings.ControlMode == Enum.ControlMode["MouseShiftLock"] then 
					if game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.MouseLockLabel.Visible == false then
						game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.MouseLockLabel.Visible = true
					end
				end
				if UserSettings().GameSettings.ControlMode == Enum.ControlMode["Classic"] then
					if game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.MouseLockLabel.Visible == true then
						game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.MouseLockLabel.Visible = false
					end
				end
			end)
		end
		if (rbxlegacyversion > 8) then
			Player.CanLoadCharacterAppearance = false
		end
		InitalizeClientAppearance(Player,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID,Gear1,Gear2,Gear3)
		--[[if (Player.Name == "QuackIAttack" or Player.Name == "CPunch" or Player.Name == "connor" or Player.Name == "Carrot" or Player.Name == "Bitl" or Player.Name == "khanglegos" or Player.Name == "Nukley" or Player.Name == "OliverA" or Player.Name == "coke" or Player.Name == "Peridorky" or Player.Name == "Raymonf" or Player.Name == "romulo27" or Player.Name == "TheLivingBee" or Player.Name == "robloxtester" or Player.Name == "winsupermario1234" and IsAdminUser == false) then
			game:SetMessage("Kicked for impersonating an administrator.")
			Player:Remove()
		end]]
		local isAdmin = Instance.new("BoolValue")
		isAdmin.Parent = Player
		isAdmin.Name = "isAdmin"
		isAdmin.Value = IsAdminUser 
	else
		pcall(function() game:SetPlaceID(-1, false) end)
	
		local suc, err = pcall(function()
			client = game:GetService("NetworkClient")
			player = game:GetService("Players"):CreateLocalPlayer(UserID) 
			player:SetSuperSafeChat(false)
			pcall(function() player:SetUnder13(false) end)
			pcall(function() player:SetAccountAge(365) end)
			player.CharacterAppearance=0
			pcall(function() player.Name=PlayerName or "" end)
			game:GetService("Visit")
			InitalizeClientAppearance(player,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID,Gear1,Gear2,Gear3)
			--[[if (player.Name == "QuackIAttack" or player.Name == "CPunch" or player.Name == "connor" or player.Name == "Carrot" or player.Name == "Bitl" or player.Name == "khanglegos" or player.Name == "Nukley" or player.Name == "OliverA" or player.Name == "coke" or player.Name == "Peridorky" or player.Name == "Raymonf" or player.Name == "romulo27" or player.Name == "TheLivingBee" or player.Name == "robloxtester" or player.Name == "winsupermario1234" and IsAdminUser == false) then
				game:SetMessage("Kicked for impersonating an administrator.")
				player:Remove()
			end]]
			local isAdmin = Instance.new("BoolValue")
			isAdmin.Parent = player
			isAdmin.Name = "isAdmin"
			isAdmin.Value = IsAdminUser
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
			if (rbxlegacyversion == 1) then
				game.GuiRoot.MainMenu["Toolbox"]:Remove()
				game.GuiRoot.MainMenu["Edit Mode"]:Remove()
				game.GuiRoot.ChatMenuPanel:Remove()
				game.GuiRoot.RightPalette.ReportAbuse:Remove()
			elseif (rbxlegacyversion == 2) then
				game.GuiRoot.ChatMenuPanel:Remove()
				game.GuiRoot.RightPalette.ReportAbuse:Remove()
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

function CSSolo(UserID,PlayerName,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID,Gear1,Gear2,Gear3,IconType,MeleeGT,PowerUpGT,RangedGT,NavigationGT,ExplosivesGT,MusicalGT,SocialGT,TransportGT,BuildingGT)
	if (rbxlegacyversion > 8) then
		game:GetService("RunService"):Run()
	else
		game:GetService("RunService"):run()
	end
	game.Workspace:InsertContent("rbxasset://fonts//libraries.rbxm")
	if (rbxlegacyversion == 10) then
		waitForChild(game.StarterGui,"Playerlist")
		waitForChild(game.StarterGui,"Menu")
		waitForChild(game.StarterGui,"Backpack")
		waitForChild(game.StarterGui,"Dialogs")
		waitForChild(game.StarterGui,"Health")
		waitForChild(game.StarterGui,"Notifications")
		game.StarterGui.Menu.Workaround:remove()
	elseif (rbxlegacyversion == 11) then
		waitForChild(game.StarterGui,"Playerlist")
		waitForChild(game.StarterGui,"Menu")
		waitForChild(game.StarterGui,"Backpack")
		waitForChild(game.StarterGui,"Dialogs")
		waitForChild(game.StarterGui,"Health")
		waitForChild(game.StarterGui,"Notifications")
		waitForChild(game.StarterGui,"Chat")
		game.StarterGui.Menu.Workaround:remove()
	elseif (rbxlegacyversion == 7) then
		waitForChild(game.StarterGui,"Health")
		game.StarterGui.Health.Workaround:remove()
	end
	-- gear types!!!!!!!
	local AllowedGearTypes = Instance.new("StringValue")
	AllowedGearTypes.Name = "AllowedGearTypes"
	AllowedGearTypes.Parent = game.Lighting
	-- ok, lets register our s e p e r a t e  g e a r s
	local MeleeGTR = Instance.new("BoolValue")
	MeleeGTR.Parent = AllowedGearTypes
	MeleeGTR.Name = "Melee"
	MeleeGTR.Value = MeleeGT
	local PowerUpGTR = Instance.new("BoolValue")
	PowerUpGTR.Parent = AllowedGearTypes
	PowerUpGTR.Name = "PowerUp"
	PowerUpGTR.Value = PowerUpGT
	local RangedGTR = Instance.new("BoolValue")
	RangedGTR.Parent = AllowedGearTypes
	RangedGTR.Name = "Ranged"
	RangedGTR.Value = RangedGT
	local NavigationGTR = Instance.new("BoolValue")
	NavigationGTR.Parent = AllowedGearTypes
	NavigationGTR.Name = "Navigation"
	NavigationGTR.Value = NavigationGT
	local ExplosivesGTR = Instance.new("BoolValue")
	ExplosivesGTR.Parent = AllowedGearTypes
	ExplosivesGTR.Name = "Explosives"
	ExplosivesGTR.Value = ExplosivesGT
	local MusicalGTR = Instance.new("BoolValue")
	MusicalGTR.Parent = AllowedGearTypes
	MusicalGTR.Name = "Musical"
	MusicalGTR.Value = MusicalGT
	local SocialGTR = Instance.new("BoolValue")
	SocialGTR.Parent = AllowedGearTypes
	SocialGTR.Name = "Social"
	SocialGTR.Value = SocialGT
	local TransportGTR = Instance.new("BoolValue")
	TransportGTR.Parent = AllowedGearTypes
	TransportGTR.Name = "Transport"
	TransportGTR.Value = TransportGT
	local BuildingGTR = Instance.new("BoolValue")
	BuildingGTR.Parent = AllowedGearTypes
	BuildingGTR.Name = "Building"
	BuildingGTR.Value = BuildingGT
	local plr = game.Players:CreateLocalPlayer(UserID)
	plr.Name = PlayerName
	plr:LoadCharacter()	
	
	if (rbxlegacyversion == 8) then
		game.CoreGui.RobloxGui.TopLeftControl.Help:Remove()
	elseif (rbxlegacyversion > 8) then
		game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.Help:Remove()
      	game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.ReportAbuse:Remove()
		game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.RecordToggle:Remove()
       	game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.Screenshot:Remove()
        game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.ToggleFullScreen:Remove()
       	game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.TogglePlayMode:Remove()
		game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.Exit:Remove()
		-- set up listeners for type of mouse mode	
		waitForChild(plr,"PlayerGui")
		waitForChild(plr.PlayerGui,"UserSettingsShield")
		waitForChild(plr.PlayerGui.UserSettingsShield,"Settings")
		waitForChild(plr.PlayerGui.UserSettingsShield.Settings,"SettingsStyle")
		waitForChild(plr.PlayerGui.UserSettingsShield.Settings.SettingsStyle,"GameSettingsMenu")
		waitForChild(plr.PlayerGui.UserSettingsShield.Settings.SettingsStyle.GameSettingsMenu, "CameraField")
		waitForChild(plr.PlayerGui.UserSettingsShield.Settings.SettingsStyle.GameSettingsMenu.CameraField, "DropDownMenuButton")
	
		UserSettings().GameSettings.ControlMode.Changed:connect(function()
			if UserSettings().GameSettings.ControlMode == Enum.ControlMode["MouseShiftLock"] then 
				if game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.MouseLockLabel.Visible == false then
					game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.MouseLockLabel.Visible = true
				end
			end
			if UserSettings().GameSettings.ControlMode == Enum.ControlMode["Classic"] then
				if game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.MouseLockLabel.Visible == true then
					game.CoreGui.RobloxGui.ControlFrame.BottomLeftControl.MouseLockLabel.Visible = false
				end
			end
		end)
	end
	pcall(function() plr:SetUnder13(false) end)
	if (rbxlegacyversion >= 8) then
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
	if (rbxlegacyversion > 8) then
		plr.CanLoadCharacterAppearance = false
	end
	InitalizeClientAppearance(plr,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID,Gear1,Gear2,Gear3)
	LoadCharacterNew(newWaitForChild(plr,"Appearance"),plr.Character,plr.Backpack)
	game:GetService("Visit")
	if (rbxlegacyversion >= 8) then
		if (plr.Character ~= nil) then
			local Character=plr.Character
			local Humanoid=Character:FindFirstChild("Humanoid")
			if (Humanoid~=nil) then
				Humanoid.Died:connect(function() delay(5,function() plr:LoadCharacter() LoadCharacterNew(newWaitForChild(plr,"Appearance"),plr.Character,plr.Backpack) end) end)
			end
		end
	else
		while true do 
			wait(0.001)
			if (Player.Character ~= nil) then
				if (Player.Character.Humanoid.Health == 0) then
					wait(RespawnTime)
					Player:LoadCharacter()
					LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character,Player.Backpack)
				elseif (Player.Character.Parent == nil) then 
					wait(RespawnTime)
					Player:LoadCharacter() -- to make sure nobody is deleted.
					LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character,Player.Backpack)
				end
			end
		end
	end
end

function CS3DView(UserID,PlayerName,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID,Gear1,Gear2,Gear3,IconType)
	rbxlegacyversion = 8
	settings().Rendering.FrameRateManager = 2
	game:GetService("RunService"):run()
	
	local plr = game.Players:CreateLocalPlayer(UserID)
	plr.Name = PlayerName
	plr:LoadCharacter()
	pcall(function() plr:SetUnder13(false) end)
	pcall(function() plr:SetSuperSafeChat(true) end)
	pcall(function() plr:SetAccountAge(365) end)
	
	plr.CharacterAppearance=0
	game.CoreGui.RobloxGui:Remove()
	game.GuiRoot.ScoreHud:Remove()
	game.GuiRoot.ChatHud:Remove()
	game.GuiRoot.ChatMenuPanel:Remove()
	if (plr.PlayerGui:FindFirstChild("HealthGUI")) then
		plr.PlayerGui.HealthGUI:Remove()
	end
	pcall(function() game:GetService("ScriptContext").ScriptsDisabled = true end)
	if plr.Character:FindFirstChild("Animate") then
		plr.Character.Animate:Remove()
	end
	InitalizeClientAppearance(plr,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,HeadID,TorsoID,RArmID,LArmID,RLegID,LLegID,Gear1,Gear2,Gear3)
	LoadCharacterNew(newWaitForChild(plr,"Appearance"),plr.Character,plr.Backpack)
	wait(1)
	game:GetService("NetworkClient")
end

_G.SetRBXLegacyVersion=SetRBXLegacyVersion
_G.CSServer=CSServer
_G.CSConnect=CSConnect
_G.CSSolo=CSSolo
_G.CS3DView=CS3DView
