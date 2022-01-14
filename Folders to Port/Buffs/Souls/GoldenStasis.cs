﻿using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Buffs.Souls
{
    public class GoldenStasis : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Golden Stasis");
            Description.SetDefault("You are immune to all damage, but cannot move");
            Main.buffNoSave[Type] = true;
            canBeCleared = true;
            DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "不动金身");
            Description.AddTranslation((int)GameCulture.CultureName.Chinese, "免疫所有伤害,但无法移动");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<FargoSoulsPlayer>().GoldShell = true;
            player.controlJump = false;
            player.controlDown = false;
            player.controlLeft = false;
            player.controlRight = false;
            player.controlUp = false;
            player.controlUseItem = false;
            player.controlUseTile = false;
            player.controlThrow = false;
            player.controlMount = false;
            player.velocity = player.oldVelocity;
            player.position = player.oldPosition;
        }
    }
}