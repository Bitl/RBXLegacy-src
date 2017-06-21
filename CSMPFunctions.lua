rbxlegacyversion = ""

-- VERSION CODENAME DOCUMENTATION
-- -------------------------------------------------------------
-- pre-alpha
-- - Mid-2008 or lower.
-- - Support for "fake" 2006/2007 clients, or the real things.
-- - Uses Legacy joinscript.
-- - Does not support hats or any other form of customization besides body colors.
-- -------------------------------------------------------------
-- pre-alpha-ext
-- - Mid-2008 or lower.
-- - Support for "fake" 2006/2007 clients, or the real things.
-- - Uses Legacy joinscript.
-- - Supports only hats, body colors, and T-Shirts.
-- -------------------------------------------------------------
-- alpha
-- - Mid-2008 or lower.
-- - Uses Legacy joinscript.
-- - Supports only hats, body colors, T-Shirts, shirts, and pants.
-- -------------------------------------------------------------
-- beta
-- - Late-2008-Early 2009.
-- - Uses Legacy joinscript.
-- - Supports only hats, body colors, T-Shirts, shirts, and pants.
-- -------------------------------------------------------------
-- delta-beta
-- - Late-2008-Early 2009.
-- - Uses RBXPri joinscript.
-- - Supports only hats, body colors, T-Shirts, shirts, and pants.
-- -------------------------------------------------------------
-- pre-gamma
-- - Late-2009-Early 2010.
-- - Uses Legacy joinscript.
-- - Supports all kinds of customization.
-- -------------------------------------------------------------
-- delta-pre-gamma
-- - Late-2009-Early 2010.
-- - Uses RBXPri joinscript.
-- - Supports all kinds of customization.
-- -------------------------------------------------------------
-- gamma
-- - Mid-2010-November 2010.
-- - Uses Legacy joinscript.
-- - Supports all kinds of customization.
-- -------------------------------------------------------------
-- delta-gamma
-- - Mid-2010-November 2010.
-- - Uses RBXPri joinscript.
-- - Supports all kinds of customization.
-- -------------------------------------------------------------
-- delta
-- - December-2010-Early 2011.
-- - Uses RBXPri joinscript.
-- - Supports the more modern 2011 user interface.
-- - Supports all kinds of customization.
-- -------------------------------------------------------------
-- delta-omega
-- - Mid-2011-Early-2012.
-- - Uses RBXPri joinscript.
-- - Supports the more modern 2011 user interface.
-- - Supports all kinds of customization.
-- -------------------------------------------------------------
-- omega
-- - Mid-2011-Early-2012.
-- - Uses RBXPri joinscript.
-- - Meant for more modern clients which don't use early 2011's UI.
-- - Supports all kinds of customization.
-- -------------------------------------------------------------
-- Don't edit anything below unless you know what you are doing.
-- -------------------------------------------------------------

if (rbxlegacyversion == "pre-alpha") then
	settings().Rendering.frameRateManager = 2;
	settings().Rendering.graphicsMode = 2;
	settings().Network.MaxSendBuffer = 1000000;
	settings().Network.PhysicsReplicationUpdateRate = 1000000;
	settings().Network.SendRate = 1000000;
elseif (rbxlegacyversion == "pre-alpha-ext") then
	settings().Rendering.frameRateManager = 2;
	settings().Rendering.graphicsMode = 2;
	settings().Network.MaxSendBuffer = 1000000;
	settings().Network.PhysicsReplicationUpdateRate = 1000000;
	settings().Network.SendRate = 1000000;
elseif (rbxlegacyversion == "alpha") then
	settings().Rendering.frameRateManager = 2;
	settings().Rendering.graphicsMode = 2;
	settings().Network.MaxSendBuffer = 1000000;
	settings().Network.PhysicsReplicationUpdateRate = 1000000;
	settings().Network.SendRate = 1000000;
elseif (rbxlegacyversion == "beta") then
	settings().Rendering.FrameRateManager = 2;
	settings().Network.SendRate = 30;
	settings().Network.ReceiveRate = 60;
elseif (rbxlegacyversion == "delta-beta") then
	settings().Rendering.FrameRateManager = 2;
	settings().Network.SendRate = 30;
	settings().Network.ReceiveRate = 60;
elseif (rbxlegacyversion == "pre-gamma") then
	settings().Rendering.FrameRateManager = 2;
	settings().Network.DataSendRate = 30;
	settings().Network.PhysicsSendRate = 20;
	settings().Network.ReceiveRate = 60;
elseif (rbxlegacyversion == "delta-pre-gamma") then
	settings().Rendering.FrameRateManager = 2;
	settings().Network.DataSendRate = 30;
	settings().Network.PhysicsSendRate = 20;
	settings().Network.ReceiveRate = 60;
elseif (rbxlegacyversion == "gamma") then
	settings().Rendering.FrameRateManager = 2;
	settings().Network.DataSendRate = 30;
	settings().Network.PhysicsSendRate = 20;
	settings().Network.ReceiveRate = 60;
	pcall(function() game:GetService("ScriptContext").ScriptsDisabled = false end);
	pcall(function() settings().Diagnostics:LegacyScriptMode() end);
elseif (rbxlegacyversion == "delta-gamma") then
	settings().Rendering.FrameRateManager = 2;
	settings().Network.DataSendRate = 30;
	settings().Network.PhysicsSendRate = 20;
	settings().Network.ReceiveRate = 60;
	pcall(function() game:GetService("ScriptContext").ScriptsDisabled = false end);
	pcall(function() settings().Diagnostics:LegacyScriptMode() end);
elseif (rbxlegacyversion == "delta") then
	settings().Rendering.FrameRateManager = 2;
	pcall(function() game:GetService("ScriptContext").ScriptsDisabled = false end);
	pcall(function() settings().Diagnostics:LegacyScriptMode() end);
	coroutine.resume(coroutine.create(function()
		loadstring('\108\111\99\97\108\32\67\111\114\101\71\117\105\32\61\32\103\97\109\101\58\71\101\116\83\101\114\118\105\99\101\40\34\67\111\114\101\71\117\105\34\41\59\10\119\104\105\108\101\32\110\111\116\32\67\111\114\101\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\82\111\98\108\111\120\71\117\105\34\41\32\100\111\10\9\67\111\114\101\71\117\105\46\67\104\105\108\100\65\100\100\101\100\58\119\97\105\116\40\41\59\10\101\110\100\10\108\111\99\97\108\32\82\111\98\108\111\120\71\117\105\32\61\32\67\111\114\101\71\117\105\46\82\111\98\108\111\120\71\117\105\59\10\108\111\99\97\108\32\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\34\41\10\108\111\99\97\108\32\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\34\41\10\108\111\99\97\108\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\84\111\112\76\101\102\116\67\111\110\116\114\111\108\34\41\10\108\111\99\97\108\32\66\117\105\108\100\84\111\111\108\115\32\61\32\82\111\98\108\111\120\71\117\105\58\70\105\110\100\70\105\114\115\116\67\104\105\108\100\40\34\66\117\105\108\100\84\111\111\108\115\34\41\10\102\117\110\99\116\105\111\110\32\109\97\107\101\89\82\101\108\97\116\105\118\101\40\41\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\10\105\102\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\32\116\104\101\110\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\32\101\110\100\10\105\102\32\66\117\105\108\100\84\111\111\108\115\32\116\104\101\110\32\66\117\105\108\100\84\111\111\108\115\46\70\114\97\109\101\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\50\32\101\110\100\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\48\44\48\44\49\44\45\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\88\44\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\101\110\100\10\102\117\110\99\116\105\111\110\32\109\97\107\101\88\82\101\108\97\116\105\118\101\40\41\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\10\105\102\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\32\116\104\101\110\32\84\111\112\76\101\102\116\67\111\110\116\114\111\108\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\32\101\110\100\10\105\102\32\66\117\105\108\100\84\111\111\108\115\32\116\104\101\110\32\66\117\105\108\100\84\111\111\108\115\46\70\114\97\109\101\46\83\105\122\101\67\111\110\115\116\114\97\105\110\116\32\61\32\49\32\101\110\100\10\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\48\44\48\44\49\44\45\66\111\116\116\111\109\76\101\102\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\80\111\115\105\116\105\111\110\32\61\32\85\68\105\109\50\46\110\101\119\40\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\88\44\49\44\45\66\111\116\116\111\109\82\105\103\104\116\67\111\110\116\114\111\108\46\65\98\115\111\108\117\116\101\83\105\122\101\46\89\41\10\101\110\100\10\108\111\99\97\108\32\102\117\110\99\116\105\111\110\32\114\101\115\105\122\101\40\41\10\105\102\32\82\111\98\108\111\120\71\117\105\46\65\98\115\111\108\117\116\101\83\105\122\101\46\120\32\62\32\82\111\98\108\111\120\71\117\105\46\65\98\115\111\108\117\116\101\83\105\122\101\46\121\32\116\104\101\110\10\109\97\107\101\89\82\101\108\97\116\105\118\101\40\41\10\101\108\115\101\10\109\97\107\101\88\82\101\108\97\116\105\118\101\40\41\10\101\110\100\10\101\110\100\10\82\111\98\108\111\120\71\117\105\46\67\104\97\110\103\101\100\58\99\111\110\110\101\99\116\40\102\117\110\99\116\105\111\110\40\112\114\111\112\101\114\116\121\41\10\105\102\32\112\114\111\112\101\114\116\121\32\61\61\32\34\65\98\115\111\108\117\116\101\83\105\122\101\34\32\116\104\101\110\10\119\97\105\116\40\41\10\114\101\115\105\122\101\40\41\10\101\110\100\10\101\110\100\41\10\119\97\105\116\40\41\10\114\101\115\105\122\101\40\41\10')()
	end))
	coroutine.resume(coroutine.create(function()
	for _,v in pairs(game:GetChildren()) do
	if v.Name == "GuiRoot" then
	coroutine.resume(coroutine.create(function()
	v.ScoreHud.Parent = nil
	end)) end end end))
elseif (rbxlegacyversion == "delta-omega") then
	settings().Rendering.FrameRateManager = 2;
	pcall(function() game:GetService("ScriptContext").ScriptsDisabled = false end);
	pcall(function() settings().Diagnostics:LegacyScriptMode() end);
	coroutine.resume(coroutine.create(function()
	for _,v in pairs(game:GetChildren()) do
	if v.Name == "GuiRoot" then
	coroutine.resume(coroutine.create(function()
	v.ScoreHud.Parent = nil
	end)) end end end))
elseif (rbxlegacyversion == "omega") then
	settings().Rendering.FrameRateManager = 2;
	pcall(function() game:GetService("ScriptContext").ScriptsDisabled = false end);
	pcall(function() settings().Diagnostics:LegacyScriptMode() end);
end

rbxversion = version();
print("ROBLOX Client version '" .. rbxversion .. "' loaded.");

--function made by rbxbanland
function newWaitForChild(newParent,name)
	local returnable = nil
	if newParent:FindFirstChild(name) then
		returnable = newParent:FindFirstChild(name)
	else 
		repeat wait() returnable = newParent:FindFirstChild(name)  until returnable ~= nil
	end
	return returnable
end

--we aren't doing anything with shirts or t-shirts or pants yet, we're only doing hats.
function LoadCharacterNew(playerApp,newChar)
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
				if (rbxlegacyversion ~= "pre-alpha" or rbxlegacyversion ~= "pre-alpha-ext" or rbxlegacyversion ~= "alpha" or rbxlegacyversion ~= "beta" or rbxlegacyversion ~= "delta-beta") then
					pcall(function()
					local newFace = game.Workspace:InsertContent("http://www.roblox.com/asset/?id="..newVal.Value)
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
		end
	end
end

function InitalizeClientAppearance(Player,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID)
	local newCharApp = Instance.new("IntValue",Player);
	newCharApp.Name = "Appearance";
	--BODY COLORS
	for i=1,6,1 do
		local BodyColor = Instance.new("BrickColorValue",newCharApp);
		if (i == 1) then
			if (HeadColorID ~= nil) then
				BodyColor.Value = BrickColor.new(HeadColorID);
			else
				BodyColor.Value = BrickColor.new(1);
			end
			BodyColor.Name = "HeadColor";
		elseif (i == 2) then
			if (TorsoColorID ~= nil) then
				BodyColor.Value = BrickColor.new(TorsoColorID);
			else
				BodyColor.Value = BrickColor.new(1);
			end
			BodyColor.Name = "TorsoColor";
		elseif (i == 3) then
			if (LeftArmColorID ~= nil) then
				BodyColor.Value = BrickColor.new(LeftArmColorID);
			else
				BodyColor.Value = BrickColor.new(1);
			end
			BodyColor.Name = "LeftArmColor";
		elseif (i == 4) then
			if (RightArmColorID ~= nil) then
				BodyColor.Value = BrickColor.new(RightArmColorID);
			else
				BodyColor.Value = BrickColor.new(1);
			end
			BodyColor.Name = "RightArmColor";
		elseif (i == 5) then
			if (LeftLegColorID ~= nil) then
				BodyColor.Value = BrickColor.new(LeftLegColorID);
			else
				BodyColor.Value = BrickColor.new(1);
			end
			BodyColor.Name = "LeftLegColor";
		elseif (i == 6) then
			if (RightLegColorID ~= nil) then
				BodyColor.Value = BrickColor.new(RightLegColorID);
			else
				BodyColor.Value = BrickColor.new(1);
			end
			BodyColor.Name = "RightLegColor";
		end
		local indexValue = Instance.new("NumberValue");
		indexValue.Name = "ColorIndex";
		indexValue.Parent = BodyColor;
		indexValue.Value = i;
		local typeValue = Instance.new("NumberValue");
		typeValue.Name = "CustomizationType";
		typeValue.Parent = BodyColor;
		typeValue.Value = 1;
	end
	--HATS
	for i=1,3,1 do
		local newHat = Instance.new("StringValue",newCharApp);
		if (i == 1) then
			if (Hat1ID ~= nil) then
				newHat.Value = Hat1ID;
				newHat.Name = Hat1ID;
			else
				newHat.Value = "NoHat.rbxm";
				newHat.Name = "NoHat.rbxm";
			end
		elseif (i == 2) then
			if (Hat2ID ~= nil) then
				newHat.Value = Hat2ID;
				newHat.Name = Hat2ID;
			else
				newHat.Value = "NoHat.rbxm";
				newHat.Name = "NoHat.rbxm";
			end
		elseif (i == 3) then
			if (Hat3ID ~= nil) then
				newHat.Value = Hat3ID;
				newHat.Name = Hat3ID;
			else
				newHat.Value = "NoHat.rbxm";
				newHat.Name = "NoHat.rbxm";
			end
		end
		local typeValue = Instance.new("NumberValue");
		typeValue.Name = "CustomizationType";
		typeValue.Parent = newHat;
		typeValue.Value = 2;
	end
	--T-SHIRT
	local newTShirt = Instance.new("StringValue",newCharApp);
	if (TShirtID ~= nil or TShirtID ~= "0") then
		newTShirt.Value = TShirtID;
	else
		newTShirt.Value = "0";
	end
	newTShirt.Name = "T-Shirt";
	local typeValue = Instance.new("NumberValue");
	typeValue.Name = "CustomizationType";
	typeValue.Parent = newTShirt;
	typeValue.Value = 3;
	--SHIRT
	local newShirt = Instance.new("StringValue",newCharApp);
	if (ShirtID ~= nil or ShirtID ~= "0") then
		newShirt.Value = ShirtID;
	else
		newShirt.Value = "0";
	end
	newShirt.Name = "Shirt";
	local typeValue = Instance.new("NumberValue");
	typeValue.Name = "CustomizationType";
	typeValue.Parent = newShirt;
	typeValue.Value = 4;
	--PANTS
	local newPants = Instance.new("StringValue",newCharApp);
	if (PantsID ~= nil or PantsID ~= "0") then
		newPants.Value = PantsID;
	else
		newPants.Value = "0";
	end
	newPants.Name = "Pants";
	local typeValue = Instance.new("NumberValue");
	typeValue.Name = "CustomizationType";
	typeValue.Parent = newPants;
	typeValue.Value = 5;
	--FACE
	local newFace = Instance.new("StringValue",newCharApp);
	if (FaceID ~= nil or FaceID ~= "0") then
		newFace.Value = FaceID;
	else
		newFace.Value = "0";
	end
	newFace.Name = "Face";
	local typeValue = Instance.new("NumberValue");
	typeValue.Name = "CustomizationType";
	typeValue.Parent = newFace;
	typeValue.Value = 6;
end

function CSServer(Port,PlayerLimit)
	if (rbxlegacyversion == "delta" or rbxlegacyversion == "delta-gamma" or rbxlegacyversion == "omega" or rbxlegacyversion == "delta-pre-gamma" or rbxlegacyversion == "delta-omega" or rbxlegacyversion == "delta-beta") then
		assert((type(Port)~="number" or tonumber(Port)~=nil or Port==nil),"CSRun Error: Port must be nil or a number.");
		local NetworkServer=game:GetService("NetworkServer");
		pcall(NetworkServer.Stop,NetworkServer);
		NetworkServer:Start(Port);
		if (rbxlegacyversion ~= "omega") then
			game:GetService("Players").MaxPlayers = PlayerLimit;
		end
		game:GetService("Players").PlayerAdded:connect(function(Player)
			if (game:GetService("Players").NumPlayers > game:GetService("Players").MaxPlayers) then
				local message = Instance.new("Message")
				message.Text = "You were kicked. Reason: Too many players on server."
				message.Parent = Player
				wait(2)
				Player:remove()
				print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' kicked. Reason: Too many players on server.");
			else
				print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' added");
				Player:LoadCharacter();
			end
			Player.CharacterAdded:connect(function(char)
				LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character);
			end)
			Player.Changed:connect(function(Property)
				if (Property=="Character") and (Player.Character~=nil) then
					local Character=Player.Character;
					local Humanoid=Character:FindFirstChild("Humanoid");
					if (Humanoid~=nil) then
						Humanoid.Died:connect(function() delay(5,function() Player:LoadCharacter() LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character) end) end)
					end
				end
			end)
		end)
		game:GetService("Players").PlayerRemoving:connect(function(Player)
			print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' leaving")	
		end)
		game:GetService("RunService"):Run();
		if (rbxlegacyversion == "delta-gamma") then
			game.Workspace:InsertContent("rbxasset://Fonts//Health2010.rbxm");
		elseif (rbxlegacyversion == "delta") then
			game.Workspace:InsertContent("rbxasset://Fonts//Health2011.rbxm");
			game.Workspace:InsertContent("rbxasset://Fonts//CoreGui2011.rbxm");
		elseif (rbxlegacyversion == "omega" or rbxlegacyversion == "delta-omega") then
			game.Workspace:InsertContent("rbxasset://Fonts//Health2012.rbxm");
			game.Workspace:InsertContent("rbxasset://Fonts//CoreGui2012.rbxm");
		end
		pcall(function() game.Close:connect(function() NetworkServer:Stop(); end) end);
		NetworkServer.IncommingConnection:connect(IncommingConnection);
	else
		Server = game:GetService("NetworkServer")
		RunService = game:GetService("RunService")
		Server:start(Port, 20)
		RunService:run();
		if (rbxlegacyversion == "gamma") then
			game.Workspace:InsertContent("rbxasset://Fonts//Health2010.rbxm");
		end
		game:GetService("Players").MaxPlayers = PlayerLimit;
		game:GetService("Players").PlayerAdded:connect(function(Player)
			if (game:GetService("Players").NumPlayers > game:GetService("Players").MaxPlayers) then
				local message = Instance.new("Message")
				message.Text = "You were kicked. Reason: Too many players on server."
				message.Parent = Player
				wait(2)
				Player:remove()
				print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' kicked. Reason: Too many players on server.");
			else
				print("Player '" .. Player.Name .. "' with ID '" .. Player.userId .. "' added");
				Player:LoadCharacter();
				LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character);
			end
				while true do 
					wait(0.001)
					if (Player.Character ~= nil) then
						if (Player.Character.Humanoid.Health == 0) then
							wait(5)
							Player:LoadCharacter()
							LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character);
						elseif (Player.Character.Parent == nil) then 
							wait(5)
							Player:LoadCharacter() -- to make sure nobody is deleted.
							LoadCharacterNew(newWaitForChild(Player,"Appearance"),Player.Character);
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

function CSConnect(UserID,ServerIP,ServerPort,PlayerName,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID,Ticket)
	if (rbxlegacyversion == "delta" or rbxlegacyversion == "delta-gamma" or rbxlegacyversion == "omega" or rbxlegacyversion == "delta-pre-gamma" or rbxlegacyversion == "delta-omega" or rbxlegacyversion == "delta-beta") then
		pcall(function() game:SetPlaceID(-1, false) end);
		pcall(function() game:GetService("Players"):SetChatStyle(Enum.ChatStyle.ClassicAndBubble) end);
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
		Player.CharacterAppearance=0;
		pcall(function() Player.Name=PlayerName or ""; end);
		pcall(function() Visit:SetUploadUrl(""); end);
		game:GetService("Visit");
		if (rbxlegacyversion == "delta") then
			game.CoreGui.RobloxGui.TopLeftControl.Help.Active = true;
		elseif (rbxlegacyversion == "omega" or rbxlegacyversion == "delta-omega") then
			game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.Help.Active = true;
		end
		InitalizeClientAppearance(Player,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID);
	else
		pcall(function() game:SetPlaceID(-1, false) end);
		pcall(function() game:GetService("Players"):SetChatStyle(Enum.ChatStyle.ClassicAndBubble) end);
	
		local suc, err = pcall(function()
			client = game:GetService("NetworkClient")
			player = game:GetService("Players"):CreateLocalPlayer(UserID) 
			player:SetSuperSafeChat(false)
			pcall(function() player:SetUnder13(false) end);
			pcall(function() player:SetMembershipType(Enum.MembershipType.BuildersClub) end);
			pcall(function() player:SetAccountAge(365) end);
			player.CharacterAppearance=0;
			pcall(function() player.Name=PlayerName or ""; end);
			game:GetService("Visit");
			InitalizeClientAppearance(player,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID);
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
				game.GuiRoot.RightPalette.ReportAbuse:Remove()
				game.GuiRoot.ChatMenuPanel:Remove()
			elseif (rbxlegacyversion == "pre-alpha-ext") then
				game.GuiRoot.MainMenu["Toolbox"]:Remove()
				game.GuiRoot.MainMenu["Edit Mode"]:Remove()
				game.GuiRoot.ChatMenuPanel:Remove()
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

function CSSolo(UserID,PlayerName,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID)
	if (rbxlegacyversion == "omega" or rbxlegacyversion == "delta-omega") then
		game:GetService("RunService"):Run();
	else
		game:GetService("RunService"):run();
	end
	if (rbxlegacyversion == "gamma" or rbxlegacyversion == "delta-gamma") then
		game.Workspace:InsertContent("rbxasset://Fonts//Health2010.rbxm");
	elseif (rbxlegacyversion == "delta") then
		game.Workspace:InsertContent("rbxasset://Fonts//Health2011.rbxm");
		game.Workspace:InsertContent("rbxasset://Fonts//CoreGui2011.rbxm");
	elseif (rbxlegacyversion == "omega" or rbxlegacyversion == "delta-omega") then
		game.Workspace:InsertContent("rbxasset://Fonts//Health2012.rbxm");
		game.Workspace:InsertContent("rbxasset://Fonts//CoreGui2012.rbxm");
	end
	if (rbxlegacyversion == "delta") then
		game.CoreGui.RobloxGui.TopLeftControl.Help.Active = true;
	elseif (rbxlegacyversion == "omega" or rbxlegacyversion == "delta-omega") then
		game.CoreGui.RobloxGui.ControlFrame.BottomRightControl.Help.Active = true;
	end
	local plr = game.Players:CreateLocalPlayer(UserID);
	plr.Name = PlayerName;
	plr:LoadCharacter();
	plr.CharacterAppearance=0;
	InitalizeClientAppearance(plr,Hat1ID,Hat2ID,Hat3ID,HeadColorID,TorsoColorID,LeftArmColorID,RightArmColorID,LeftLegColorID,RightLegColorID,TShirtID,ShirtID,PantsID,FaceID);
	LoadCharacterNew(newWaitForChild(plr,"Appearance"),plr.Character);
	game:GetService("Visit");
	while true do wait()
		if (plr.Character.Humanoid.Health == 0) then
			wait(5)
			plr:LoadCharacter()
			LoadCharacterNew(newWaitForChild(plr,"Appearance"),plr.Character);
		end
	end
end

_G.CSServer=CSServer;
_G.CSConnect=CSConnect;
_G.CSSolo=CSSolo;