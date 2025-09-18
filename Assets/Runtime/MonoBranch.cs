/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoBranch.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  09/17/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.DirtyTree
{
    public abstract class MonoBranch : MonoBehaviour
    {
        public bool IsDirty { get { return Branch.IsDirty; } }

        protected virtual IDirtyBranch Branch { get; } = new DirtyBranch();

        protected virtual void Awake()
        {
            Branch.OnReset += Branch_OnReset;
            Branch.OnDirty += Branch_OnDirty;

            foreach (Transform child in transform)
            {
                var monoBranch = child.GetComponent<MonoBranch>();
                if (monoBranch != null)
                {
                    Branch.Register(monoBranch.Branch);
                }
            }
        }

        /// <summary>
        /// On branch is reset.
        /// </summary>
        protected abstract void Branch_OnReset();

        /// <summary>
        /// On branch is dirty.
        /// </summary>
        /// <param name="isDirty"></param>
        protected abstract void Branch_OnDirty(bool isDirty);

        /// <summary>
        /// Reset dirty state.
        /// </summary>
        public void ResetDirty()
        {
            Branch.Reset();
        }
    }
}