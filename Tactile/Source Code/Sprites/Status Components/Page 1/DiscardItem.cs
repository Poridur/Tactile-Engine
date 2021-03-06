﻿using Microsoft.Xna.Framework.Graphics;
using TactileLibrary;
namespace Tactile
{
    class DiscardItem : Status_Item
    {
        protected override void set_text_color(Game_Actor actor, Data_Equipment item)
        {
            base.set_text_color(actor, item);

            // Grey out if can't be discarded
            bool canDiscard = Global.battalion.convoy_ready_for_sending ||
                actor.CanDiscard(item);
            string color = canDiscard ? "White" : "Grey";
            change_text_color(color);
        }
    }
}
