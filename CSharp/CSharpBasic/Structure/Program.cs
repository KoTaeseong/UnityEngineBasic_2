﻿using Structure;

SwordMan swordMan = new SwordMan();
swordMan.Name = "F엑스칼리버";
swordMan.Lv = 104;
swordMan.Slash();

int a;
Stats stats;

Wizard wizard= new Wizard();
wizard.Stats.STR = 10;
wizard.Stats.DEX = 5;
wizard.Stats.INT = 50;
wizard.Stats.LUK = 20;

Console.WriteLine($"마법사의 전투력 : {wizard.Stats.GetCombotPower()}");


