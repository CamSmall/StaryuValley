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
            if (e.Name.IsEquivalentTo("Animals/horse"))                                                     // This is referencing the sprite that we want to replace
                                                                                                            // If you go to the Stardew local files folder and go to "Content"
                                                                                                            // there's a bunch of sub folders. The first part, in this case 
                                                                                                            // "Animals", is that folder (also could be Portraits, etc)
                                                                                                            // The last part (in this case "horse"), is the specific .xnb file
                                                                                                            // we're trying to replace. Since I'm trying to replace the horse sprite,
                                                                                                            // that's what I put here (case sensitive)
            {
                e.LoadFromModFile<Texture2D>("assets/ponyta_unfinished.png", AssetLoadPriority.Medium);     // the file here is the location of the .png file we're trying to put
                                                                                                            // in from our mod folder. This sprite is located in the "assets" folder.
            }
        }
    }
}