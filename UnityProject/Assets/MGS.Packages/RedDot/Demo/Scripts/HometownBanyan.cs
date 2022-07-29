/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HometownBanyan.cs
 *  Description  :  Ignore.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/30/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Localization;
using System.Collections;
using System.Text;
using UnityEngine;

namespace MGS.RedDots.Demo
{
    public class HometownBanyan : MonoBehaviour
    {
        void Start()
        {
            var languages = new string[] { "zh-CN", "en-US" };
            foreach (var language in languages)
            {
                var languageFile = string.Format("{0}/MGS.Packages/RedDot/Demo/Language/{1}.txt", Application.dataPath, language);
                LocalizationAPI.Handler.Deserialize(language, languageFile, Encoding.UTF8);
            }
            StartCoroutine(TellALittleStoryAboutABanyan());
        }

        IEnumerator TellALittleStoryAboutABanyan()
        {
            var banyan = new Tree(LocalizationAPI.Handler.GetParagraph("LK_RD_HB_Tile"));
            var manyLeaves = 3000;
            banyan.Grow(manyLeaves);
            Debug.Log(LocalizationAPI.Handler.GetParagraph("LK_RD_HB_P0")); yield return new WaitForSeconds(3);
            Debug.Log(LocalizationAPI.Handler.GetParagraph("LK_RD_HB_P1"));

            yield return new WaitForSeconds(5);
            var freshLeaf = 1;
            banyan.Grow(freshLeaf);
            Debug.Log(LocalizationAPI.Handler.GetParagraph("LK_RD_HB_P2")); yield return new WaitForSeconds(3);
            Debug.Log(LocalizationAPI.Handler.GetParagraph("LK_RD_HB_P3")); yield return new WaitForSeconds(3);
            Debug.Log(LocalizationAPI.Handler.GetParagraph("LK_RD_HB_P4"));
            AProgrammerShouldDo(banyan); yield return new WaitForSeconds(5);

            var aFewLeaves = 10;
            banyan.Dyeing(aFewLeaves, Color.yellow);
            Debug.Log(LocalizationAPI.Handler.GetParagraph("LK_RD_HB_P5")); yield return new WaitForSeconds(3);
            Debug.Log(LocalizationAPI.Handler.GetParagraph("LK_RD_HB_P6")); yield return new WaitForSeconds(3);
            Debug.Log(LocalizationAPI.Handler.GetParagraph("LK_RD_HB_P7"));
            AProgrammerShouldDo(banyan); yield return new WaitForSeconds(5);

            banyan.Drop(aFewLeaves);
            Debug.Log(LocalizationAPI.Handler.GetParagraph("LK_RD_HB_P8")); yield return new WaitForSeconds(3);
            Debug.Log(LocalizationAPI.Handler.GetParagraph("LK_RD_HB_P9")); yield return new WaitForSeconds(1);
            AProgrammerShouldDo(banyan); yield return new WaitForSeconds(3);
        }

        void AProgrammerShouldDo(Tree arg)
        {
            Debug.LogWarningFormat("Please don't forget the logic of a programmer, The state is changed? {0}", arg.IsRed);
            arg.Reset();
            Debug.LogWarningFormat("Reset state to {0}", arg.IsRed);
        }
    }
}