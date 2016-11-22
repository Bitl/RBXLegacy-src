function Play(PlayerName)
	local plr = game.Players:CreateLocalPlayer(0);
	plr.Name = PlayerName;
	game:GetService("Visit");
	game:GetService("RunService"):run();
	plr:LoadCharacter();
	while true do wait(0.001)
		if plr.Character.Humanoid.Health == 0 then
		wait(5);
		plr:LoadCharacter();
		end
	end
end

_G.Play=Play;
