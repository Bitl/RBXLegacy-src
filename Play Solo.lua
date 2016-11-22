game:getService("Players"):CreateLocalPlayer(0);
game:service("RunService"):run();
game.Players.Player:LoadCharacter();
game.Players.Player:SetSuperSafeChat(false);
function onDied(humanoid)
	wait(5);
	game.Players.Player:LoadCharacter(0);
end
game.Players.Player.Character.Humanoid.Died:connect(onDied);