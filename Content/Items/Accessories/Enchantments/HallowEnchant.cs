﻿using FargowiltasSouls.Common.Graphics.Particles;
using FargowiltasSouls.Content.Projectiles;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler.Content;
using Luminance.Core.Graphics;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Content.Items.Accessories.Enchantments
{
    public class HallowEnchant : BaseEnchant
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override Color nameColor => new(150, 133, 100);


        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.rare = ItemRarityID.LightPurple;
            Item.value = 180000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddEffect<HallowEffect>(Item);
        }


        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("FargowiltasSouls:AnyHallowHead")
                .AddIngredient(ItemID.HallowedPlateMail)
                .AddIngredient(ItemID.HallowedGreaves)
                .AddIngredient(ItemID.FairyBell)
                .AddIngredient(ItemID.HallowJoustingLance)
                .AddIngredient(ItemID.BouncingShield)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
    public class HallowEffect : AccessoryEffect
    {

        public override Header ToggleHeader => Header.GetHeader<SpiritHeader>();
        public override int ToggleItemType => ModContent.ItemType<HallowEnchant>();

        public const int RepelRadius = 350;
        public static void HealRepel(Player player)
        {
            Item effectItem = player.EffectItem<HallowEffect>();
            if (effectItem == null || effectItem.type != ModContent.ItemType<HallowEnchant>())
            {
                return;
            }
            SoundEngine.PlaySound(SoundID.Item72);
            Particle p = new HallowEnchantBarrier(player.Center, Vector2.Zero, RepelRadius / 160f, 32);
            p.Spawn();

            foreach (Projectile projectile in Main.projectile.Where(p => p.hostile && FargoSoulsUtil.CanDeleteProjectile(p) && p.Distance(player.Center) <= RepelRadius))
            {
                projectile.velocity = Vector2.Normalize(projectile.Center - player.Center) * projectile.velocity.Length();
                projectile.hostile = false;
                projectile.friendly = true;
            }
        }

        public override void PostUpdate(Player player)
        {
            // prevent time heal from persisting after death
            if (player.dead) {
                player.FargoSouls().HallowHealTime = 0;
            }
        }
    }
}
