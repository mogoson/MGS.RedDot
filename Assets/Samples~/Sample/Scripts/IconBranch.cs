/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IconBranch.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  09/17/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.DirtyTree.Sample
{
    public class IconBranch : MonoBranch
    {
        public Image icon;

        protected override void Branch_OnReset()
        {
            Branch_OnDirty(false);
        }

        protected override void Branch_OnDirty(bool isDirty)
        {
            var color = isDirty ? Color.red : Color.white;
            icon.color = color;
        }
    }
}