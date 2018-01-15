<roblox xmlns:xmime="http://www.w3.org/2005/05/xmlmime" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:noNamespaceSchemaLocation="http://www.roblox.com/roblox.xsd" version="4">
	<External>null</External>
	<External>nil</External>
	<Item class="Script" referent="RBX0">
		<Properties>
			<bool name="Disabled">true</bool>
			<Content name="LinkedSource"><null></null></Content>
			<string name="Name">RBXStatusBuffsGUIScript</string>
			<ProtectedString name="Source">local vChar = script.Parent
local vPlayer = game.Players:GetPlayerFromCharacter(vChar)
playerGui = vPlayer.PlayerGui

local config = vChar:FindFirstChild(&quot;PlayerStats&quot;)
while config == nil do
	config = vChar:FindFirstChild(&quot;PlayerStats&quot;)
	wait(1)
end


buffGui = Instance.new(&quot;ScreenGui&quot;)
buffGui.Parent = playerGui
buffGui.Name = &quot;BuffGUI&quot;

tray = Instance.new(&quot;Frame&quot;)
tray.BackgroundTransparency = 1.0
tray.Parent = buffGui
tray.Name = &quot;Tray&quot;
tray.Position = UDim2.new(0.40, 0.0, 0.95, 0.0)
tray.Size = UDim2.new(0.0, 300.0, 0.0, 30.0)
tray.BorderColor3 = Color3.new(0, 0, 0)
tray.Visible = true

local iceLabel = Instance.new(&quot;ImageLabel&quot;)
iceLabel.Name = &quot;Ice&quot;
iceLabel.Size = UDim2.new(0.1, 0.0, 0.8, 0.0)
--iceLabel.Position = UDim2.new(0.25, 0.0, 0.0, 0.0)
iceLabel.BackgroundTransparency = 1.0
iceLabel.Image = &quot;http://www.roblox.com/asset/?id=47522829&quot;
iceLabel.Visible = true
-- iceLabel.Parent = tray

local poisonLabel = Instance.new(&quot;ImageLabel&quot;)
poisonLabel.Name = &quot;Poison&quot;
poisonLabel.Size = UDim2.new(0.1, 0.0, 0.8, 0.0)
--poisonLabel.Position = UDim2.new(0.50, 0.0, 0.0, 0.0)
poisonLabel.BackgroundTransparency = 1.0
poisonLabel.Image = &quot;http://www.roblox.com/asset/?id=47525343&quot;
poisonLabel.Visible = true

local fireLabel = Instance.new(&quot;ImageLabel&quot;)
fireLabel.Name = &quot;Fire&quot;
fireLabel.Size = UDim2.new(0.1, 0.0, 0.8, 0.0)
fireLabel.BackgroundTransparency = 1.0
fireLabel.Image = &quot;http://www.roblox.com/asset/?id=47522853&quot;
fireLabel.Visible = true 

local stunLabel = Instance.new(&quot;ImageLabel&quot;)
stunLabel.Name = &quot;Stun&quot;
stunLabel.Size = UDim2.new(0.1, 0.0, 0.8, 0.0)
stunLabel.BackgroundTransparency = 1.0
stunLabel.Image = &quot;http://www.roblox.com/asset/?id= 47522868&quot;
stunLabel.Visible = true
-- The table that contains the list of all the status buff images
local labels = {poisonLabel, iceLabel, fireLabel, stunLabel}

--  Contains the list of active Labels to draw them
local activeLabels = {}

-- Copies the necessary labels 
local buffsGuiTable = {
	[&quot;Speed&quot;] = function ()
	end,
	[&quot;MaxHealth&quot;] = function ()
	end,
	[&quot;Poison&quot;] = function ()
		table.insert(activeLabels, labels[1])
	end,
	[&quot;Ice&quot;] = function()
		table.insert(activeLabels, labels[2])
	end,
	[&quot;Fire&quot;] = function()
		table.insert(activeLabels, labels[3])
	end,
	[&quot;Stun&quot;] = function()
		table.insert(activeLabels, labels[4])
	end
}

function statusBuffGui()
	activeLabels = {}
	for a = 1, #labels do
		labels[a].Active = false
		labels[a].Visible = false
	end
	activeBuffs = config:GetChildren()
	-- removeFromTray = tray:GetChildren()
	print(#buffsGuiTable)
	print(#activeBuffs)
	if #activeBuffs &gt; 2 then 
		for i = 1, #activeBuffs do 
			print(activeBuffs[i].Name)
			buffsGuiTable[activeBuffs[i].Name]()			
		end
		-- Retractable buffs GUI, displaced from the center
	--[[	if #activeLabels &gt; 0 then 
			for j = 1, #activeLabels do				
				count = 1
				norm = j - 1
				median = 0
				if #activeLabels%2 == 0 then 
					median = -0.06
				end
				if norm == 0 then 
					activeLabels[j].Position = UDim2.new(0.45 + median, 0.0, 0.0, 0.0)
				elseif norm &gt; 0 and norm%2 == 0 then					
					activeLabels[j].Position = UDim2.new(((norm -(count * 3.0)) * 0.1) + 0.45 + median, 0.0, 0.0, 0.0)
					count = count + 1
				else
					activeLabels[j].Position = UDim2.new((norm * 0.1) + 0.45 + median, 0.0, 0.0, 0.0)
				end			
				activeLabels[j].Parent = tray
				activeLabels[j].Active = true  				
			end			
		end
			]]--

		print(#activeLabels)
		if #activeLabels &gt; 0 then
				count = 0
				parity = 1
				median = 0.45
				if #activeLabels%2 == 0 then median = .5 end
			for j = 1, #activeLabels do
				activeLabels[j].Position = UDim2.new(median + parity*count, 0.0, 0.0, 0.0)				
				if j%2 == 1 then count = count + .1 end
				parity = parity * -1
				activeLabels[j].Parent = tray
				activeLabels.Active = true
			end
		end
	end
end

-- Blinking Labels

function blinkGui()
	while true do
		for n = 1, #activeLabels do
			activeLabels[n].Visible = not activeLabels[n].Visible
		end
	wait(0.5)
	end
end

blink = coroutine.create(blinkGui)
coroutine.resume(blink)


-- Event Listeners
config.ChildAdded:connect(statusBuffGui)
config.ChildRemoved:connect(statusBuffGui)









</ProtectedString>
			<bool name="archivable">true</bool>
		</Properties>
	</Item>
</roblox>