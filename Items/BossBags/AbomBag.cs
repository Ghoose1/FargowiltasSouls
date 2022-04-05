﻿using Terraria;
using Terraria.ModLoader;
using FargowiltasSouls.Patreon.DemonKing;
using FargowiltasSouls.Items.Materials;

namespace FargowiltasSouls.Items.BossBags
{
    public class AbomBag : BossBag
    {
        protected override bool IsPreHMBag => false;

        public override int BossBagNPC => ModContent.NPCType<NPCs.AbomBoss.AbomBoss>();

        public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(player.GetItemSource_OpenItem(Item.type), ModContent.ItemType<AbomEnergy>(), Main.rand.Next(16) + 15); // 15-30

            float chance = 3f;
            for (int i = 0; i < FargoSoulsWorld.downedChampions.Length; i++)
                if (FargoSoulsWorld.downedChampions[i])
                    chance += 0.5f;

            if (SoulConfig.Instance.PatreonFishron && Main.rand.NextFloat(100) < chance)
                player.QuickSpawnItem(player.GetItemSource_OpenItem(Item.type), ModContent.ItemType<StaffOfUnleashedOcean>());
        }
    }
}