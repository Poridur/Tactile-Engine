﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FEXNA.Menus
{
    interface IFadeMenu
    {
        void FadeShow();
        void FadeHide();

        ScreenFadeMenu FadeInMenu(bool skipFadeIn);
        ScreenFadeMenu FadeOutMenu();

        void Open();
        void Close();
    }
}