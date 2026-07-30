/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IDirtyBranch.cs
 *  Description  :  Interface of dirty branch.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/30/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.DirtyTree
{
    /// <summary>
    /// Interface of dirty branch.
    /// </summary>
    public interface IDirtyBranch
    {
        /// <summary>
        /// On branch reset event.
        /// </summary>
        event Action OnReset;

        /// <summary>
        /// On branch dirty event.
        /// </summary>
        event Action<bool> OnDirty;

        /// <summary>
        /// This branch is dirty?
        /// </summary>
        bool IsDirty { set; get; }

        /// <summary>
        /// Reset branch state.
        /// </summary>
        void Reset();

        /// <summary>
        /// Register child branch.
        /// </summary>
        /// <param name="child"></param>
        void Register(IDirtyBranch child);

        /// <summary>
        /// Unregister child branch. 
        /// </summary>
        /// <param name="child"></param>
        void Unregister(IDirtyBranch child);

        /// <summary>
        /// Unregister all child branches.
        /// </summary>
        void Unregisters();
    }
}