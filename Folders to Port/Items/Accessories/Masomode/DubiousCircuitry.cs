using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using FargowiltasSouls.Toggler;

namespace FargowiltasSouls.Items.Accessories.Masomode
{
    public class DubiousCircuitry : SoulsItem
    {
        public override bool Eternity => true;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dubious Circuitry");
            Tooltip.SetDefault(@"Grants immunity to Cursed Inferno, Ichor, Lightning Rod, Defenseless, Nano Injection, and knockback
Your attacks inflict Cursed Inferno and Ichor
Your attacks have a small chance to inflict Lightning Rod
Two friendly probes fight by your side
Reduces damage taken by 5%
'Malware probably not included'");
            DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "可疑电路");
            Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, @"'里面也许没有恶意软件'
免疫诅咒地狱,脓液,避雷针,毫无防御,昏迷和击退
攻击造成诅咒地狱和脓液效果
攻击小概率造成避雷针效果
召唤2个友善的探测器为你而战
减少6%所受伤害");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(0, 5);
            item.defense = 10;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.CursedInferno] = true;
            player.buffImmune[BuffID.Ichor] = true;
            player.buffImmune[ModContent.BuffType<Buffs.Masomode.Defenseless>()] = true;
            player.buffImmune[ModContent.BuffType<Buffs.Masomode.NanoInjection>()] = true;
            player.buffImmune[ModContent.BuffType<Buffs.Masomode.LightningRod>()] = true;

            player.GetModPlayer<FargoSoulsPlayer>().FusedLens = true;
            player.GetModPlayer<FargoSoulsPlayer>().GroundStick = true;
            if (player.GetToggleValue("MasoProbe"))
                player.AddBuff(ModContent.BuffType<Buffs.Minions.Probes>(), 2);

            player.endurance += 0.05f;
            player.noKnockback = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()

            .AddIngredient(mod.ItemType("FusedLens"));
            .AddIngredient(mod.ItemType("GroundStick"));
            .AddIngredient(mod.ItemType("ReinforcedPlating"));
            .AddIngredient(ItemID.HallowedBar, 10);
            .AddIngredient(ItemID.SoulofFright, 5);
            .AddIngredient(ItemID.SoulofMight, 5);
            .AddIngredient(ItemID.SoulofSight, 5);
            .AddIngredient(mod.ItemType("DeviatingEnergy"), 10);

            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            .Register();
        }
    }
}