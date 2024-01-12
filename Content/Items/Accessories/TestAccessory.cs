﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Content.Items.Accessories.Forces;

namespace FargowiltasSouls.Content.Items.Accessories
{
    public class TestAccessory : SoulsItem
    {
        public override string Texture => "FargowiltasSouls/Content/Items/Placeholder";
        public override void SetStaticDefaults()
        {

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.sellPrice(0, 1);

            Item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual) => player.AddEffect<TestAccessoryEffect>(Item);
    }
    public class TestAccessoryEffect : AccessoryEffect
    {
        public override bool HasToggle => true;
        public override Header ToggleHeader => Header.GetHeader<TerraHeader>();
        public override void PostUpdateEquips(Player player)
        {
            TestAccessoryEffectFields fieldInstance = player.GetEffectFields<TestAccessoryEffectFields>();
            fieldInstance.Test++;
            Main.NewText(fieldInstance.Test);
        }
    }
    public class TestAccessoryEffectFields : EffectFields
    {
        public int Test;
        public override void ResetEffects()
        {
            //test = 0;
        }
    }
}