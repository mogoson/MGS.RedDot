/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ToggleBranch.cs
 *  Description  :  Ignore.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/30/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine.UI;

namespace MGS.DirtyTree.Sample
{
    public class ToggleBranch : IconBranch
    {
        public Toggle toggle;
        private bool isOnOrigin;

        protected override void Awake()
        {
            base.Awake();

            isOnOrigin = toggle.isOn;
            toggle.onValueChanged.AddListener(isOn => Branch.IsDirty = isOn != isOnOrigin);
        }

        protected override void Branch_OnReset()
        {
            base.Branch_OnReset();
            isOnOrigin = toggle.isOn;
        }
    }
}