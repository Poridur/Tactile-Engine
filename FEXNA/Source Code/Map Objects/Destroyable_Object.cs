﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.IO;
using FEXNAVector2Extension;

namespace FEXNA
{
    internal class Destroyable_Object : Combat_Map_Object
    {
        protected string Event_Name;
        protected int MaxHp, Hp;
        protected int Def = 0;

        #region Serialization
        public void write(BinaryWriter writer)
        {
            writer.Write(Id);
            Loc.write(writer);
            Real_Loc.write(writer);
            writer.Write(Event_Name);
            writer.Write(MaxHp);
            writer.Write(Hp);
        }

        public void read(BinaryReader reader)
        {
            Id = reader.ReadInt32();
            Loc = Loc.read(reader);
            Real_Loc = Real_Loc.read(reader);
            Event_Name = reader.ReadString();
            MaxHp = reader.ReadInt32();
            Hp = reader.ReadInt32();
        }
        #endregion

        #region Accessors
        public string event_name { get { return Event_Name; } }

        public override int maxhp { get { return MaxHp; } }
        public override int hp
        {
            get { return Hp; }
            set { Hp = Math.Min(MaxHp, value); }
        }
        public override bool is_dead { get { return hp <= 0; } }

        public override int def { get { return Def; } }

        public override string name
        {
            get
            {
                if (Global.game_map.is_off_map(Loc))
                    return "";
                return Global.data_terrains[Global.game_map.terrain_tag(Loc)].Name;
            }
        }

        public override int team { get { return Constants.Map.DESTROYABLE_OBJECT_TEAM; } }
        #endregion

        public Destroyable_Object() { }
        public Destroyable_Object(int id, Vector2 loc, int hp, string event_name)
        {
            Id = id;
            force_loc(loc);
            MaxHp = Hp = hp;
            Event_Name = event_name;
        }
    }
}