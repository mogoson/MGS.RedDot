/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Leaf.cs
 *  Description  :  Ignore.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/30/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.RedDots.Demo
{
    public class Leaf : RedDot
    {
        public Color Color
        {
            set
            {
                if (value != color)
                {
                    color = value;
                    IsRed = true;
                }
            }
            get { return color; }
        }
        protected Color color;

        public int Size
        {
            set
            {
                if (value != size)
                {
                    size = value;
                    IsRed = true;
                }
            }
            get { return size; }
        }
        protected int size;

        public Leaf(Color color, int size)
        {
            this.color = color;
            this.size = size;
        }
    }
}