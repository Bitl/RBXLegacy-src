<roblox xmlns:xmime="http://www.w3.org/2005/05/xmlmime" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:noNamespaceSchemaLocation="http://www.roblox.com/roblox.xsd" version="4">
	<External>null</External>
	<External>nil</External>
	<Item class="Script" referent="RBX0">
		<Properties>
			<bool name="Disabled">true</bool>
			<Content name="LinkedSource"><null></null></Content>
			<string name="Name">RBXStatusScript</string>
			<ProtectedString name="Source">-- Global Status Buff Script -- 
-- This will be a part of a humanoid
-- Everytime a humanoid gets hit, this script will be invoked
-- If the damage is from a previous older gear we just query the takeDamage C++ function
-- If its from some of the newer ones with status buffs, we look them up in our table and use that to determine what we need to do 


-- [[ The status debuffs currently are

		-- OVER TIME EFFECTS
					
						-- Poison
						-- Fire
						-- Ice, also slows
						-- Heal		
						-- Plague
					

		-- For fire, ice etc we could apply the texture to nearby parts to showcase as if its spreading

		-- INSTANT EFFECTS
					
					-- Stun, 10-20% chance to stun
					-- Confusion
					-- Invisibilty, there will be fading in and fading out
					-- Silence, can&apos;t use gears
					-- Blind/Miss
				

		-- TODO, AOE EFFECTS (these will propagate from the wielder) ]]

local t = {}


function waitForChild(instance, name)
	while not instance:FindFirstChild(name) do
		instance.ChildAdded:wait()
	end
end

local damageGuiWidth =  5.0
local damageGuiHeight = 5.0

local myPlayer = script.Parent
local myName = script.Parent.Name
local myHumanoid = myPlayer:FindFirstChild(&quot;Humanoid&quot;)


local charConfig = nil

-- gear effects
local poison = 0
local physical = 0
local heal = 0
local regen = 0
local piercing = 0
local poisonTime = 10   -- duration of a poisoning  (default 10)
local corruption = 0   -- amount poison worsens

local iceDOT = 0
local iceDuration = 0
local iceSlow = 0

local stunDuration = 0

-- armor/character effects [will be reloaded upon characters config folder changing]

local existingIceDuration = 0

local fireDOT = 0
local fireDuration = 0
local existingFireDuration = 0

local armor = 0
local poisonArmor = 0
local existingPoison = 0
local existingCorruption = 0

local existingStunDuration = 0


-- Create Lookup Tables
local charPropType = {
	[&quot;Armor&quot;] = function(x)
		print(&quot;ARMOR &quot;, x)
		armor = x
	end,
	[&quot;Poison Resistance&quot;] = function(x)
		print(&quot;POISON RESISTANCE &quot;, x)
		poisonArmor = x
	end,
	[&quot;Poison&quot;] = function(x)
		existingPoison = x.X
		existingCorruption = x.Z
	end,
	[&quot;Ice&quot;] = function(x)
		existingIceDuration = x.Y
	end,
	[&quot;Fire&quot;] = function(x)
		existingFireDuration = x.Y
	end,
	[&quot;Stun&quot;] = function(x)
		-- Tentative value, usually we should allow to override stun duration and have a long cool down or a chance effect
		existingStunDuration = x
	end
}


-- Damage Type Table
local damageType = {
	[&quot;Damage&quot;] = function(x) 
		--print(&quot;DAMAGE &quot;, x) 
		physical = x 
	end,
	[&quot;Poison&quot;] = function(x)
		print(&quot;POISONED&quot;, x) 
		poison = x
		--poisonTime = x.Y
		--corruption = x.Z
	end,
	[&quot;Heal&quot;] = function(x)
		print(&quot;HEALED&quot;, x) 
		heal = x 
	end,
	[&quot;Regen&quot;] = function(x)
		print(&quot;REGEN&quot;, x)
		regen = x 
	end,
	[&quot;Piercing&quot;] = function(x) 
		print(&quot;PIERCING&quot;, x) 
		piercing = x 
	end,
	[&quot;Poison Time&quot;] = function(x)
		print(&quot;POISON TIME&quot;, x)
		poisonTime = x
	end,
	[&quot;Corruption&quot;] = function(x)
		print(&quot;CORRUPTION&quot;, x)
		corruption = x
	end,
	-- Code Change Feb 25th
	[&quot;Ice&quot;] = function(x)
		--print(&quot;Ice&quot;)	
		iceDOT = x.X
		iceDuration = x.Y
		iceSlow = x.Z
	end,
	[&quot;Fire&quot;] = function(x)
		fireDOT = x.X
		fireDuration = x.Y
	end,
	[&quot;Stun&quot;] = function(x)
		stunDuration = x
	end
	--
}

function updateCharProperties()
	-- reset all char properties first to 0
	armor = 0
	poisonArmor = 0
	existingPoison = 0
	existingCorruption = 0
	--iceDOT = 0
	--iceDuration = 0
	--iceSlow = 0

	--print(&quot;Updating Char Properties&quot;)
	charProperties = charConfig:GetChildren()
	--print(iceDOT,&quot; &quot;, iceDuration,&quot; &quot;, iceSlow)
	for i = 1, #charProperties do
		if charPropType[charProperties[i].Name] then  -- can get rid of this check to improve speed at cost of safety
			charPropType[charProperties[i].Name](charProperties[i].Value)			
		end
	end
end


function applyRandomizationTo(property)
	if (math.random() &gt; property.Y) then
		return property.X
	else
		return property.Z
	end
end

function eval(property)
	if type(property) == &quot;number&quot; then return property
	else return applyRandomizationTo(property) end
end


t.ComputeStatusEffects = function (gearConfig)
	-- all gear effects need to be set to 0 initially
	poison = 0  
	physical = 0
	heal = 0	
	--iceDOT = 0
	iceDuration = 0
	--iceSlow = 0
	regen = 0
	piercing = 0
	poisonTime = 10 -- default is to poison someone for 10 seconds

	gearProperties = gearConfig:GetChildren()
	for i = 1, #gearProperties do
		if not (gearProperties[i].Name == &quot;Damage&quot;) then		
			damageType[gearProperties[i].Name](gearProperties[i].Value)
			print(gearProperties[i].Name)
		else
			damageType[gearProperties[i].Name](eval(gearProperties[i].Value))
		end
	end
	
	-- apply randomization to armors that need it
	--  (doing this here [with eval] allows us to change armor variables only when necessary)
	--print(physical)
	--print(armor)
	--poi = math.max(existingPoison, math.max(poison - eval(poisonArmor), 0))
	dmg = math.max(physical - math.max(eval(armor) - piercing, 0), 0) - heal	
	poi = math.max(poison - eval(poisonArmor), 0)
	cor = math.max(existingCorruption, corruption)



	-- Feb 25th Change
	iceDamage = iceDOT
	--

	--print(&quot;Overall Damage: &quot;, dmg)
	--print(&quot;Overall Poison: &quot;, poi)

	-- Feb 25th Change
	--print(&quot;Overall Ice Damage: &quot;, iceDamage)
	--

 -- Populate the tags in the Players Config!
myHumanoid:takeDamage(dmg)
print(myHumanoid.Health)
if charConfig ~= nil then
	--if poi &gt; 0 then -- if poison damage taken, make sure we give &apos;em a poisoned status
	if poi &gt; 0 and poi &gt;= existingPoison then -- must at least tie previous poison strength to change the poison tag		
		poisonTag = charConfig:FindFirstChild(&quot;Poison&quot;)
		if poisonTag == nil then
			poisonTag = Instance.new(&quot;Vector3Value&quot;)
			poisonTag.Name = &quot;Poison&quot;
			poisonTag.Parent = charConfig
		end
		poisonTag.Value = Vector3.new(poi, poisonTime, cor)		
	end

	-- Feb 25th Change
		if iceDuration &gt; 0 and existingIceDuration &lt;= 0 then
			iceTag = charConfig:FindFirstChild(&quot;Ice&quot;)
			if iceTag == nil then 
				iceTag = Instance.new(&quot;Vector3Value&quot;)
				iceTag.Name = &quot;Ice&quot;
				iceTag.Parent = charConfig
			end
			iceTag.Value = Vector3.new(iceDOT, iceDuration, iceSlow)					
		end
		print(fireDuration, existingFireDuration)
		if fireDuration &gt; 0 and existingFireDuration &lt;= 0 then 
			fireTag = charConfig:FindFirstChild(&quot;Fire&quot;)
			if fireTag == nil then 
				fireTag = Instance.new(&quot;Vector3Value&quot;)
				fireTag.Name = &quot;Fire&quot;
				fireTag.Parent = charConfig
			end
			fireTag.Value = Vector3.new(fireDOT, fireDuration, 0.0)
		end

		if stunDuration &gt; 0 and existingStunDuration &lt;= 0 then 
			stunTag = charConfig:FindFirstChild(&quot;Stun&quot;)
			if stunTag == nil then 
				stunTag = Instance.new(&quot;NumberValue&quot;)
				stunTag.Name = &quot;Stun&quot;
				stunTag.Parent = charConfig
			end
			stunTag.Value = stunDuration
		end
	end
	vPlayer = game.Players:GetPlayerFromCharacter(script.Parent)
	if vPlayer then	
		dmgGui = vPlayer.PlayerGui:FindFirstChild(&quot;DamageGui&quot;)
		if dmgGui ~= nil then
			dmgChildren = dmgGui:GetChildren()
			for i = 1, #dmgChildren do
				if dmgChildren[i].TextTransparency &lt; .35 then
					dmgChildren[i].Text = tostring(tonumber(dmgChildren[i].Text) + dmg)
					return
				end
			end
		end
		local guiCoRoutine = coroutine.create(statusGui)
		coroutine.resume(guiCoRoutine, vPlayer, dmg, poi)
		print(&quot;CREATING GUI&quot;)
	end
end

-- GUI STUFF -- 

function statusGui(vPlayer, guiDmg, guiPoi)			
	local damageGui = vPlayer.PlayerGui:FindFirstChild(&quot;DamageGui&quot;)
	if damageGui == nil then
		damageGui = Instance.new(&quot;BillboardGui&quot;)		
		damageGui.Name = &quot;DamageGui&quot;
		print(&quot;BB GUI CREATED&quot;)
		damageGui.Parent = vPlayer.PlayerGui
		damageGui.Adornee = script.Parent:FindFirstChild(&quot;Head&quot;)
		damageGui.Active = true
		damageGui.size = UDim2.new(damageGuiWidth, 0.0, damageGuiHeight, 0.0)	
		damageGui.StudsOffset = Vector3.new(0.0, 2.0, 0.0)
	end
	local textLabel = Instance.new(&quot;TextLabel&quot;)
	print(&quot;TEXT LABEL CREATED&quot;)
	textLabel.Text = tostring(guiDmg)
	textLabel.size = UDim2.new(1.0, 0.0, 1.0, 0.0)
	textLabel.Active = true
	textLabel.FontSize = 6
	textLabel.BackgroundTransparency = 1
	textLabel.TextColor3 = Color3.new(1, 0, 0)
	textLabel.Parent = damageGui

	for t = 1, 10 do
		wait(.1)
		textLabel.TextTransparency = t/10
		textLabel.Position = UDim2.new(0, 0, 0, -t*5)
		textLabel.FontSize = 6-t*.6
	end
	textLabel:remove()		
end

return t



-- Hook-up stuff to listeners here and do any other initialization
--[[while true do
	waitForChild(script.Parent, &quot;PlayerStats&quot;)
	charConfig = script.Parent:FindFirstChild(&quot;PlayerStats&quot;)

	if charConfig then
		updateCharProperties()
		charConfig.Changed:connect(updateCharProperties)
		charConfig.ChildAdded:connect(function (newChild) newChild.Changed:connect(updateCharProperties) updateCharProperties() end)
		--charConfig.Desc
		break
	end
end]]

</ProtectedString>
			<bool name="archivable">true</bool>
		</Properties>
	</Item>
</roblox>