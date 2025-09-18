/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DirtyBranch.cs
 *  Description  :  Branch to record dirty state.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/30/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace MGS.DirtyTree
{
    /// <summary>
    /// Branch to record dirty state.
    /// </summary>
    public class DirtyBranch : IDirtyBranch
    {
        /// <summary>
        /// On branch reset event.
        /// </summary>
        public event Action OnReset;

        /// <summary>
        /// On branch dirty event.
        /// </summary>
        public event Action<bool> OnDirty;

        /// <summary>
        /// This branch is dirty?
        /// </summary>
        public bool IsDirty
        {
            set
            {
                if (isSelfDirty != value)
                {
                    isSelfDirty = value;
                    OnDirty?.Invoke(IsDirty);
                }
            }
            get { return isSelfDirty | isChildDirty; }
        }

        /// <summary>
        /// One of children of this branch is dirty?
        /// </summary>
        protected bool IsChildDirty
        {
            set
            {
                if (isChildDirty != value)
                {
                    isChildDirty = value;
                    OnDirty?.Invoke(IsDirty);
                }
            }
            get { return isChildDirty; }
        }

        /// <summary>
        /// This branch self is dirty?
        /// </summary>
        protected bool isSelfDirty;

        /// <summary>
        /// One of children of this branch is dirty?
        /// </summary>
        protected bool isChildDirty;

        /// <summary>
        /// Children branches.
        /// </summary>
        protected List<IDirtyBranch> children = new List<IDirtyBranch>();

        /// <summary>
        /// Reset branch state.
        /// </summary>
        public virtual void Reset()
        {
            //Clean all children state.
            foreach (var child in children)
            {
                child.Reset();
            }

            isSelfDirty = false;
            isChildDirty = false;
            OnReset?.Invoke();
        }

        /// <summary>
        /// Register child branch.
        /// </summary>
        /// <param name="child"></param>
        public virtual void Register(IDirtyBranch child)
        {
            child.OnDirty += Child_OnDirty;
            children.Add(child);
        }

        /// <summary>
        /// Unregister child branch. 
        /// </summary>
        /// <param name="child"></param>
        public virtual void Unregister(IDirtyBranch child)
        {
            child.OnDirty -= Child_OnDirty;
            children.Remove(child);
            IsChildDirty = CheckChildDirty();
        }

        /// <summary>
        /// Unregister all child branches.
        /// </summary>
        public virtual void Unregisters()
        {
            foreach (var leaf in children)
            {
                leaf.OnDirty -= Child_OnDirty;
            }
            children.Clear();
            IsChildDirty = false;
        }

        /// <summary>
        /// On child branch change dirty state.
        /// </summary>
        /// <param name="isDirty"></param>
        protected virtual void Child_OnDirty(bool isDirty)
        {
            if (!isDirty)
            {
                isDirty = CheckChildDirty();
            }
            IsChildDirty = isDirty;
        }

        /// <summary>
        /// Check one of children is dirty?
        /// </summary>
        /// <returns></returns>
        protected bool CheckChildDirty()
        {
            foreach (var child in children)
            {
                if (child.IsDirty)
                {
                    return true;
                }
            }
            return false;
        }
    }
}