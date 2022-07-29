/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  RedDot.cs
 *  Description  :  Red dot to collect data state dirty.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/30/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace MGS.RedDots
{
    /// <summary>
    /// Red dot to collect data state dirty.
    /// </summary>
    public class RedDot : IRedDot
    {
        /// <summary>
        /// On flicker event.
        /// </summary>
        public event Action<bool> OnFlicker;

        /// <summary>
        /// This dot is red(dirty)?
        /// </summary>
        public bool IsRed
        {
            set
            {
                if (value != isRed)
                {
                    isRed = value;
                    InvokeOnFlickerEvent(isRed);
                }
            }
            get { return isRed; }
        }
        private bool isRed;

        /// <summary>
        /// Children dots.
        /// </summary>
        protected List<IRedDot> children = new List<IRedDot>();

        /// <summary>
        /// Reset dot state.
        /// </summary>
        public virtual void Reset()
        {
            //Reset all children red dot.
            foreach (var leave in children)
            {
                leave.Reset();
            }
            isRed = false;
        }

        /// <summary>
        /// Register child dot.
        /// </summary>
        /// <param name="child"></param>
        public void Register(IRedDot child)
        {
            child.OnFlicker += Child_OnFlicker;
            children.Add(child);
        }

        /// <summary>
        /// Unregister child dot. 
        /// </summary>
        /// <param name="child"></param>
        public void Unregister(IRedDot child)
        {
            child.OnFlicker -= Child_OnFlicker;
            children.Remove(child);
        }

        /// <summary>
        /// Clear all child dots.
        /// </summary>
        public virtual void Clear()
        {
            foreach (var leaf in children)
            {
                leaf.OnFlicker -= Child_OnFlicker;
            }
            children.Clear();
        }

        /// <summary>
        /// Dispose all resources.
        /// </summary>
        public virtual void Dispose()
        {
            Clear();
            children = null;
            OnFlicker = null;
        }

        /// <summary>
        /// On child dot invoke OnFlicker event.
        /// </summary>
        /// <param name="isRed"></param>
        protected virtual void Child_OnFlicker(bool isRed)
        {
            //If one of the children is red, then this dot is red.
            IsRed |= isRed;
        }

        /// <summary>
        /// Invoke OnFlicker event.
        /// </summary>
        /// <param name="isRed"></param>
        private void InvokeOnFlickerEvent(bool isRed)
        {
            if (OnFlicker != null)
            {
                OnFlicker.Invoke(isRed);
            }
        }
    }
}