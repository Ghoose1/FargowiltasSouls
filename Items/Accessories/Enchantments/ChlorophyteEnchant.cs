using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;

namespace FargowiltasSouls.Items.Accessories.Enchantments
{
    public class ChlorophyteEnchant : SoulsItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chlorophyte Enchantment");
            
            DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "叶绿魔石");
            
            string tooltip =
@"Summons a ring of leaf crystals to shoot at nearby enemies
Grants a double spore jump
While using wings, spores will continuously spawn
Allows the ability to dash slightly
Double tap a direction
'The jungle's essence crystallizes around you'";
            Tooltip.SetDefault(tooltip);

            string tooltip_ch =
@"召唤一圈叶状水晶射击附近的敌人
使你获得孢子二段跳能力
使用翅膀进行飞行时会在你周围不断生成孢子
'丛林的精华凝结在你周围'";
            Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, tooltip_ch);
        }

        public override void SafeModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(36, 137, 0);
                }
            }
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = ItemRarityID.Lime;
            Item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoSoulsPlayer modPlayer = player.GetModPlayer<FargoSoulsPlayer>();
            //crystal
            //modPlayer.ChloroEffect(hideVisual);
            //modPlayer.JungleEnchant = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup("FargowiltasSouls:AnyChloroHead")
            .AddIngredient(ItemID.ChlorophytePlateMail)
            .AddIngredient(ItemID.ChlorophyteGreaves)
            .AddIngredient(null, "JungleEnchant")
            .AddIngredient(ItemID.ChlorophyteWarhammer)
            .AddIngredient(ItemID.ChlorophyteClaymore)
            //grape juice
            //.AddIngredient(ItemID.Seedling);
            //plantero pet

            .AddTile(TileID.CrystalBall)
           .Register();
        }
    }
}
