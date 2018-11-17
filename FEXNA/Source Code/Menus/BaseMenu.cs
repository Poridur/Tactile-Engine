﻿using System;
using Microsoft.Xna.Framework.Graphics;

namespace FEXNA.Menus
{
    abstract class BaseMenu : IMenu
    {
        protected bool Visible = true;
        private bool Active = true;

        protected virtual void Activate() { }
        protected virtual void Deactivate() { }

        protected abstract void UpdateMenu(bool active);

        #region IMenu
        public virtual bool HidesParent { get { return true; } }
        public bool IsVisible
        {
            get { return Visible; }
            set { Visible = value; }
        }

        public void UpdateActive(bool active)
        {
            if (Active != active)
            {
                if (active)
                    Activate();
                else
                    Deactivate();

                Active = active;
            }
        }

        public void Update(bool active)
        {
            UpdateActive(active);
            UpdateMenu(active);
        }
        public abstract void Draw(SpriteBatch spriteBatch);
        #endregion
    }
}
