using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Templar
{
    [Serializable()]
    public class Items : item
    {
        Random rd = new Random();
        bool langue;
        public Vector2 positin_tile;
        string op1 = "", op2 = "", op3 = "", op4 = "", op5 = "", op6 = "", op7 = "", op8 = "", op9 = "", op10 = "", op11 = "", op12 = "", op13 = "", op14 = "", op15 = "", op16 = "",
            op17 = "", op18 = "", op19 = "", op20 = "", op21 = "", op22 = "", op23 = "", op24 = "", op25 = "", op26 = "", op27 = "", op28 = "", op29 = "", op30 = "", op31 = "",
            op32 = "", op33 = "", op34 = "", op35 = "", op36 = "", op37 = "", op38 = "", op39 = "", op40 = "", op41 = "", op42 = "", op43 = "", op44 = "", op45 = "", op46 = "",
            op47 = "", op48 = "", op49 = "";

        public string display_name(Vector2 position_tileset)
        {

            if (position_tileset == new Vector2(0, 0))
                return op1;
            else if (position_tileset == new Vector2(1, 0))
                return op2;
            else if (position_tileset == new Vector2(2, 0))
                return op3;
            else if (position_tileset == new Vector2(3, 0))
                return op4;
            else if (position_tileset == new Vector2(4, 0))
                return op5;
            else if (position_tileset == new Vector2(5, 0))
                return op6;
            else if (position_tileset == new Vector2(6, 0))
                return op7;
            else
                if (position_tileset == new Vector2(0, 1))
                    return op8;
                else if (position_tileset == new Vector2(1, 1))
                    return op9;
                else if (position_tileset == new Vector2(2, 1))
                    return op10;
                else if (position_tileset == new Vector2(3, 1))
                    return op11;
                else if (position_tileset == new Vector2(4, 1))
                    return op12;
                else if (position_tileset == new Vector2(5, 1))
                    return op13;
                else if (position_tileset == new Vector2(6, 1))
                    return op14;
                else
                    if (position_tileset == new Vector2(0, 2))
                        return op15;
                    else if (position_tileset == new Vector2(1, 2))
                        return op16;
                    else if (position_tileset == new Vector2(2, 2))
                        return op17;
                    else if (position_tileset == new Vector2(3, 2))
                        return op18;
                    else if (position_tileset == new Vector2(4, 2))
                        return op19;
                    else if (position_tileset == new Vector2(5, 2))
                        return op20;
                    else if (position_tileset == new Vector2(6, 2))
                        return op21;
                    else
                        if (position_tileset == new Vector2(0, 3))
                            return op22;
                        else if (position_tileset == new Vector2(1, 3))
                            return op23;
                        else if (position_tileset == new Vector2(2, 3))
                            return op24;
                        else if (position_tileset == new Vector2(3, 3))
                            return op25;
                        else if (position_tileset == new Vector2(4, 3))
                            return op26;
                        else if (position_tileset == new Vector2(5, 3))
                            return op27;
                        else if (position_tileset == new Vector2(6, 3))
                            return op28;
                        else
                            if (position_tileset == new Vector2(0, 4))
                                return op29;
                            else if (position_tileset == new Vector2(1, 4))
                                return op30;
                            else if (position_tileset == new Vector2(2, 4))
                                return op31;
                            else if (position_tileset == new Vector2(3, 4))
                                return op32;
                            else if (position_tileset == new Vector2(4, 4))
                                return op33;
                            else if (position_tileset == new Vector2(5, 4))
                                return op34;
                            else if (position_tileset == new Vector2(6, 4))
                                return op35;
                            else
                                if (position_tileset == new Vector2(0, 5))
                                    return op36;
                                else if (position_tileset == new Vector2(1, 5))
                                    return op37;
                                else if (position_tileset == new Vector2(2, 5))
                                    return op38;
                                else if (position_tileset == new Vector2(3, 5))
                                    return op39;
                                else if (position_tileset == new Vector2(4, 5))
                                    return op40;
                                else if (position_tileset == new Vector2(5, 5))
                                    return op41;
                                else if (position_tileset == new Vector2(6, 5))
                                    return op42;
                                else
                                    if (position_tileset == new Vector2(0, 6))
                                        return op43;
                                    else if (position_tileset == new Vector2(1, 6))
                                        return op44;
                                    else if (position_tileset == new Vector2(2, 6))
                                        return op45;
                                    else if (position_tileset == new Vector2(3, 6))
                                        return op46;
                                    else if (position_tileset == new Vector2(4, 6))
                                        return op47;
                                    else if (position_tileset == new Vector2(5, 6))
                                        return op48;
                                    else if (position_tileset == new Vector2(6, 6))
                                        return op49;
            return "";
        }
        public Items(Vector2 position_tileset, bool language)
            : base(ressource.item, position_tileset)
        {
            XmlReader reader;
            reader = XmlReader.Create("Francais.xml");
            if (!language)
            {
                reader = XmlReader.Create("English.xml");
            }
            while (reader.Read())
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.Read();
                    if (reader.Name == "i0")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op1 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i1")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op2 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i2")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op3 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i3")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op4 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i4")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op5 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i5")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op6 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i6")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op7 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i7")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op8 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i8")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op9 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i9")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op10 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i10")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op11 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i11")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op12 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i12")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op13 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i13")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op14 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i14")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op15 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i15")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op16 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i16")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op17 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i17")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op18 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i18")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op19 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i19")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op20 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i20")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op21 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i21")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op22 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i22")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op23 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i23")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op24 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i24")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op25 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i25")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op26 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i26")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op27 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i27")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op28 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i28")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op29 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i29")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op30 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i30")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op31 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i31")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op32 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i32")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op33 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i33")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op34 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i34")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op35 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i35")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op36 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i36")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op37 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i37")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op38 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i38")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op39 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i39")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op40 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i40")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op41 = reader.Value.ToString();
                        }
                        reader.Read();
                    }

                    if (reader.Name == "i41")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op42 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i42")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op43 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i43")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op44 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i44")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op45 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i45")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op46 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i46")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op47 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i47")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op48 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "i48")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op49 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                }


            usable = false;
            is_equipable = false;
            positin_tile = position_tileset;
            if (position_tileset == new Vector2(0, 0))
            {
                utilité = op1;
                usable = true;
            }
            else if (position_tileset == new Vector2(1, 0))
            {
                utilité = op2;
                usable = true;
            }
            else if (position_tileset == new Vector2(2, 0))
            {
                utilité = op3;
                usable = true;
            }
            else if (position_tileset == new Vector2(3, 0))
            {
                utilité = op4;
                Bonus = new int[] { 0, 5, 0, 0, 0, 0, 0 };
                is_equipable = true;
            }
            else if (position_tileset == new Vector2(4, 0))
            {
                utilité = op5;
                Bonus = new int[] { 0, 10, 0, 0, 0, 0, 0 };
                is_equipable = true;
            }
            else if (position_tileset == new Vector2(5, 0))
            {
                utilité = op6;
                Bonus = new int[] { 0, 2, 0, 0, 0, 0, 0 };
                is_equipable = true;
            }
            else if (position_tileset == new Vector2(6, 0))
            {
                utilité = op7;
                Bonus = new int[] { 0, 7, 0, 0, 0, 0, 0 };
                is_equipable = true;
            }
            else
                if (position_tileset == new Vector2(0, 1))
                {
                    utilité = op8;
                    usable = true;
                }
                else if (position_tileset == new Vector2(1, 1))
                {
                    utilité = op9;
                    usable = true;
                }
                else if (position_tileset == new Vector2(2, 1))
                {
                    utilité = op10;
                    usable = true;
                }
                else if (position_tileset == new Vector2(3, 1))
                {
                    utilité = op11;
                    Bonus = new int[] { 5, 0, 0, 0, 0, 0, 0 };
                    is_equipable = true;
                }
                else if (position_tileset == new Vector2(4, 1))
                {
                    utilité = op12;
                    Bonus = new int[] { 10, 0, 0, 0, 0, 0, 0 };
                    is_equipable = true;
                }
                else if (position_tileset == new Vector2(5, 1))
                {
                    utilité = op13;
                    Bonus = new int[] { 2, 0, 0, 0, 0, 0, 0 };
                    is_equipable = true;
                }
                else if (position_tileset == new Vector2(6, 1))
                {
                    utilité = op14;
                    Bonus = new int[] { 7, 0, 0, 0, 0, 0, 0 };
                    is_equipable = true;
                }
                else
                    if (position_tileset == new Vector2(0, 2))
                    {
                        utilité = op15;
                        usable = true;
                    }
                    else if (position_tileset == new Vector2(1, 2))
                    {
                        utilité = op16;
                        usable = true;
                    }
                    else if (position_tileset == new Vector2(2, 2))
                    {
                        utilité = op17;
                        usable = true;
                    }
                    else if (position_tileset == new Vector2(3, 2))
                    {
                        utilité = op18;
                        Bonus = new int[] { 0, 0, 5, 0, 0, 0, 0 };
                        is_equipable = true;
                    }
                    else if (position_tileset == new Vector2(4, 2))
                    {
                        utilité = op19;
                        Bonus = new int[] { 0, 0, 10, 0, 0, 0, 0 };
                        is_equipable = true;
                    }
                    else if (position_tileset == new Vector2(5, 2))
                    {
                        utilité = op20;
                        Bonus = new int[] { 0, 0, 2, 0, 0, 0, 0 };
                        is_equipable = true;
                    }
                    else if (position_tileset == new Vector2(6, 2))
                    {
                        utilité = op21;
                        Bonus = new int[] { 0, 0, 7, 0, 0, 0, 0 };
                        is_equipable = true;
                    }
                    else
                        if (position_tileset == new Vector2(0, 3))
                        {
                            utilité = op22;
                            usable = true;
                        }
                        else if (position_tileset == new Vector2(1, 3))
                        {
                            utilité = op23;
                            usable = true;
                        }
                        else if (position_tileset == new Vector2(2, 3))
                        {
                            utilité = op24;
                            usable = true;
                        }
                        else if (position_tileset == new Vector2(3, 3))
                        {
                            utilité = op25;
                            Bonus = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                            is_equipable = true;
                        }
                        else if (position_tileset == new Vector2(4, 3))
                        {
                            utilité = op26;
                            Bonus = new int[] { 0, 0, 0, 2, 0, 0, 0 };
                            is_equipable = true;
                        }
                        else if (position_tileset == new Vector2(5, 3))
                        {
                            utilité = op27;
                            Bonus = new int[] { 0, 0, 0, 3, 0, 0, 0 };
                            is_equipable = true;
                        }
                        else if (position_tileset == new Vector2(6, 3))
                        {
                            utilité = op28;
                            Bonus = new int[] { 0, 0, 0, 4, 0, 0, 0 };
                            is_equipable = true;
                        }
                        else
                            if (position_tileset == new Vector2(0, 4))
                            {
                                utilité = op29;
                                usable = true;
                            }
                            else if (position_tileset == new Vector2(1, 4))
                            {
                                utilité = op30;
                                usable = true;
                            }
                            else if (position_tileset == new Vector2(2, 4))
                            {
                                utilité = op31;
                                usable = true;
                            }
                            else if (position_tileset == new Vector2(3, 4))
                            {
                                utilité = op32;
                                Bonus = new int[] { 0, 0, 0, 0, 50, 0, 0 };
                                is_equipable = true;
                            }
                            else if (position_tileset == new Vector2(4, 4))
                            {
                                utilité = op33;
                                Bonus = new int[] { 0, 0, 0, 0, 100, 0, 0 };
                                is_equipable = true;
                            }
                            else if (position_tileset == new Vector2(5, 4))
                            {
                                utilité = op34;
                                Bonus = new int[] { 0, 0, 0, 0, 25, 0, 0 };
                                is_equipable = true;
                            }
                            else if (position_tileset == new Vector2(6, 4))
                            {
                                utilité = op35;
                                Bonus = new int[] { 0, 0, 0, 0, 75, 0, 0 };
                                is_equipable = true;
                            }

                            else
                                if (position_tileset == new Vector2(0, 5))
                                {
                                    utilité = op36;
                                    usable = true;
                                }
                                else if (position_tileset == new Vector2(1, 5))
                                {
                                    utilité = op37;
                                    usable = true;
                                }
                                else if (position_tileset == new Vector2(2, 5))
                                {
                                    utilité = op38;
                                    usable = true;
                                }
                                else if (position_tileset == new Vector2(3, 5))
                                {
                                    utilité = op39;
                                    is_equipable = true;
                                    Bonus = new int[] { 0, 0, 0, 0, 0, 50, 0 };
                                }
                                else if (position_tileset == new Vector2(4, 5))
                                {
                                    utilité = op40;
                                    is_equipable = true;
                                    Bonus = new int[] { 0, 0, 0, 0, 0, 100, 0 };
                                }
                                else if (position_tileset == new Vector2(5, 5))
                                {
                                    utilité = op41;
                                    is_equipable = true;
                                    Bonus = new int[] { 0, 0, 0, 0, 0, 25, 0 };
                                }
                                else if (position_tileset == new Vector2(6, 5))
                                {
                                    utilité = op42;
                                    is_equipable = true;
                                    Bonus = new int[] { 0, 0, 0, 0, 0, 75, 0 };
                                }
                                else
                                    if (position_tileset == new Vector2(0, 6))
                                    {
                                        utilité = op43;
                                        usable = true;
                                    }
                                    else if (position_tileset == new Vector2(1, 6))
                                    {
                                        utilité = op44;
                                        usable = true;
                                    }
                                    else if (position_tileset == new Vector2(2, 6))
                                    {
                                        utilité = op45;
                                        usable = true;
                                    }
                                    else if (position_tileset == new Vector2(3, 6))
                                    {
                                        utilité = op46;
                                        Bonus = new int[] { 0, 0, 0, 0, 0, 0, 5 };
                                        is_equipable = true;
                                    }
                                    else if (position_tileset == new Vector2(4, 6))
                                    {
                                        utilité = op47;
                                        Bonus = new int[] { 0, 0, 0, 0, 0, 0, 10 };
                                        is_equipable = true;
                                    }
                                    else if (position_tileset == new Vector2(5, 6))
                                    {
                                        utilité = op48;
                                        Bonus = new int[] { 0, 0, 0, 0, 0, 0, 2 };
                                        is_equipable = true;
                                    }
                                    else if (position_tileset == new Vector2(6, 6))
                                    {
                                        utilité = op49;
                                        Bonus = new int[] { 0, 0, 0, 0, 0, 0, 7 };
                                        is_equipable = true;
                                    }
        }
        public override void action(gamemain main)
        {
            if (positin_tile == new Vector2(0, 0))
            {
                utilité = op1;
                usable = true;
            }
            else if (positin_tile == new Vector2(1, 0))
            {
                utilité = op2;
                usable = true;
            }
            else if (positin_tile == new Vector2(2, 0))
            {
                main.player.pv_player += 10;
            }
            else
                if (positin_tile == new Vector2(0, 1))
                {
                    main.List_Zombie.Clear();
                    utilité = op8;
                    usable = true;
                }
                else if (positin_tile == new Vector2(1, 1))
                {
                    main.List_Zombie.RemoveAt(rd.Next(main.List_Zombie.Count));
                    utilité = op9;
                    usable = true;
                }
                else if (positin_tile == new Vector2(2, 1))
                {
                    utilité = op10;
                    main.player.pv_player += 20;
                    usable = true;
                }
                else
                    if (positin_tile == new Vector2(0, 2))
                    {
                        utilité = op15;
                        usable = true;
                    }
                    else if (positin_tile == new Vector2(1, 2))
                    {
                        utilité = op16;
                        main.player.invulnerable = true;
                        usable = true;
                    }
                    else if (positin_tile == new Vector2(2, 2))
                    {
                        utilité = op17;
                        main.player.pv_player += 0;
                        usable = true;
                    }
                    else
                        if (positin_tile == new Vector2(0, 3))
                        {
                            utilité = op22;
                            usable = true;
                        }
                        else if (positin_tile == new Vector2(1, 3))
                        {
                            utilité = op23;
                            usable = true;
                        }
                        else if (positin_tile == new Vector2(2, 3))
                        {
                            utilité = op24;
                            usable = true;
                        }

                        else
                            if (positin_tile == new Vector2(0, 4))
                            {
                                utilité = op29;
                                usable = true;
                            }
                            else if (positin_tile == new Vector2(1, 4))
                            {
                                utilité = op30;
                                usable = true;
                            }
                            else if (positin_tile == new Vector2(2, 4))
                            {
                                utilité = op31;
                                usable = true;
                            }
                            else
                                if (positin_tile == new Vector2(0, 5))
                                {
                                    utilité = op36;
                                    usable = true;
                                }
                                else if (positin_tile == new Vector2(1, 5))
                                {
                                    utilité = op37;
                                    usable = true;
                                }
                                else if (positin_tile == new Vector2(2, 5))
                                {
                                    utilité = op38;
                                    usable = true;
                                }
                                else
                                    if (positin_tile == new Vector2(0, 6))
                                    {
                                        utilité = op43;
                                        usable = true;
                                    }
                                    else if (positin_tile == new Vector2(1, 6))
                                    {
                                        utilité = op44;
                                        usable = true;
                                    }
                                    else if (positin_tile == new Vector2(2, 6))
                                    {
                                        utilité = op45;
                                        usable = true;
                                    }

            base.action(main);
        }
        public override void draw(SpriteBatch spritebatch, int x, int y, int z, int w)
        {
            spritebatch.Draw(ressource.item, new Rectangle(x, y, z, w), new Rectangle((int)positin_tile.X * 32, (int)positin_tile.Y * 32, 32, 32), Color.White);
            base.draw(spritebatch, x, y, z, w);
        }
    }
}
