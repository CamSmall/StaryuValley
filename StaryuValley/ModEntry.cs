using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace StaryuValley
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.Content.AssetRequested += this.OnAssetRequested;
        }


        /*********
        ** Private methods
        *********/

        /// <inheritdoc cref="IContentEvents.AssetRequested"/>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnAssetRequested(object sender, AssetRequestedEventArgs e)
        {
            /* 
             * This first part in the if-statement is referencing the sprite that we want to replace.
             * If you go to the SDV local files folder and go to "Content", there's a bunch of sub folders. 
             * The first part, in this case "Animals", is that folder (also could be Portraits, Buildings, etc)
             * The second part (in this case "horse"), is the specific .xnb file that we're trying to replace.
             * Since I'm trying to replace the horse sprite, that's what I put here (case sensitive. idk why horse is lowercase)
             * If I was trying to replace Abigail it'd be "Portraits/Abigail"
             */
            if (e.Name.IsEquivalentTo("Animals/horse"))                                                     
            {
                e.LoadFromModFile<Texture2D>("assets/Content/Animals/ponyta.png", AssetLoadPriority.Medium);     
                /* 
                 * The file here is the location of the .png file we're trying to put in from our mod folder. 
                 * This ponyta sprite is located in the "assets/Content/Animals" folder of our repo, and it's
                 * just the full .png filename that goes here.
                 */
            }
            if (e.Name.IsEquivalentTo("LooseSprites/logo"))
            {
                e.LoadFromModFile<Texture2D>("assets/Content/LooseSprites/logoStaryuValley.png", AssetLoadPriority.Medium);
            }
            if (e.Name.IsEquivalentTo("Minigames/TitleButtons"))
            {
                e.LoadFromModFile<Texture2D>("assets/Content/Minigames/newTitleButtons.png", AssetLoadPriority.Medium);
            }
        }
    }
}