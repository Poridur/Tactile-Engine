﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tactile.Graphics.Text;

namespace Tactile.Windows.UserInterface.Status
{
    class StatusLabeledTextUINode : StatusTextUINode
    {
        protected TextSprite Label;

        internal StatusLabeledTextUINode(
                string helpLabel,
                string label,
                Func<Game_Unit, string> textFormula,
                int textOffset = 32,
                bool center = false)
            : base(helpLabel, textFormula, center)
        {
            //TextFormula = textFormula; //Debug

            initialize_label(label);
            initialize_text(new Vector2(textOffset, 0));
        }

        protected virtual void initialize_label(string label)
        {
            Label = new TextSprite();
            Label.draw_offset = new Vector2(0, 0);
            Label.SetFont(Config.UI_FONT, Global.Content, "Yellow");
            set_label(label);
        }

        protected override void initialize_text(Vector2 draw_offset)
        {
            Text = new TextSprite();
            Text.draw_offset = draw_offset;
            Text.SetFont(Config.UI_FONT, Global.Content, "Blue");
        }

        internal void set_label(string label)
        {
            Label.text = label;
        }

        protected override void update_graphics(bool activeNode)
        {
            base.update_graphics(activeNode);
            Label.update();
        }

        protected override Vector2 HitBoxLoc(Vector2 drawOffset)
        {
            Vector2 loc = base.HitBoxLoc(drawOffset);
            if (Center)
                loc.X += Size.X / 2;
            return loc;
        }

        protected override void mouse_off_graphic()
        {
            base.mouse_off_graphic();
            Label.tint = Color.White;
        }
        protected override void mouse_highlight_graphic()
        {
            base.mouse_highlight_graphic();
            Label.tint = Config.MOUSE_OVER_ELEMENT_COLOR;
        }
        protected override void mouse_click_graphic()
        {
            base.mouse_click_graphic();
            Label.tint = Config.MOUSE_PRESSED_ELEMENT_COLOR;
        }

        public override void Draw(SpriteBatch sprite_batch, Vector2 draw_offset = default(Vector2))
        {
            Label.draw(sprite_batch, draw_offset - (loc + draw_vector()));

            base.Draw(sprite_batch, draw_offset);
        }
    }
}
