using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Buffs.Boss
{
    public class Grabbed : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Grabbed");
            Description.SetDefault("Mash movement keys to escape!");
            DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "抓住你了！");
            Description.AddTranslation((int)GameCulture.CultureName.Chinese, "狂点你的移动键来逃离这个！");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
            canBeCleared = false;
        }

        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "FargowiltasSouls/Buffs/PlaceholderDebuff";
            return true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            FargoSoulsPlayer fargoPlayer = player.GetModPlayer<FargoSoulsPlayer>();

            fargoPlayer.Mash = true;
        }
    }
}
