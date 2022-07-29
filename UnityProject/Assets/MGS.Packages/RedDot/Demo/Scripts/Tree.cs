/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Tree.cs
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
    public class Tree : RedDot
    {
        public string Name
        {
            set
            {
                if (value != name)
                {
                    name = value;
                    IsRed = true;
                }
            }
            get { return name; }
        }
        protected string name;

        public Tree(string name)
        {
            this.name = name;
        }

        public void Grow(int leaves)
        {
            for (int i = 0; i < leaves; i++)
            {
                var leaf = new Leaf(Color.green, 1);
                Register(leaf);
                children.Add(leaf);
            }
            IsRed = true;
        }

        public void Drop(int leaves)
        {
            for (int i = 0; i < leaves; i++)
            {
                if (i < children.Count)
                {
                    var leaf = children[i] as Leaf;
                    Unregister(leaf);
                    children.Remove(leaf);
                }
                else break;
            }
            IsRed = true;
        }

        public void Dyeing(int leaves, Color color)
        {
            for (int i = 0; i < leaves; i++)
            {
                if (i < children.Count)
                {
                    var leaf = children[i] as Leaf;
                    leaf.Color = color;
                }
                else break;
            }
        }
    }
}