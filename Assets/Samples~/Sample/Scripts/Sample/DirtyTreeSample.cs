/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DirtyTreeSample.cs
 *  Description  :  Ignore.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/30/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.DirtyTree.Sample
{
    public class DirtyTreeSample : MonoBehaviour
    {
        public MonoBranch dirtyTree;
        public Button btnSave;

        private void Awake()
        {
            btnSave.onClick.AddListener(() =>
            {
                //Save data codes ...

                //Reset dirty state.
                dirtyTree.ResetDirty();
            });
        }
    }
}