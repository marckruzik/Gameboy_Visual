﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace nQuant
{
    public struct Color
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;


        public Color (byte r, byte g, byte b, byte a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }

}