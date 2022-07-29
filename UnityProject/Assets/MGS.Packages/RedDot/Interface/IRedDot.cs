/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IRedDot.cs
 *  Description  :  Interface of red dot.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/30/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.RedDots
{
    /// <summary>
    /// Interface of red dot.
    /// </summary>
    public interface IRedDot : IDisposable
    {
        /// <summary>
        /// On flicker event.
        /// </summary>
        event Action<bool> OnFlicker;

        /// <summary>
        /// This dot is red(dirty)?
        /// </summary>
        bool IsRed { get; }

        /// <summary>
        /// Reset dot state.
        /// </summary>
        void Reset();

        /// <summary>
        /// Register child dot.
        /// </summary>
        /// <param name="child"></param>
        void Register(IRedDot child);

        /// <summary>
        /// Unregister child dot. 
        /// </summary>
        /// <param name="child"></param>
        void Unregister(IRedDot child);

        /// <summary>
        /// Clear all child dots.
        /// </summary>
        void Clear();
    }
}