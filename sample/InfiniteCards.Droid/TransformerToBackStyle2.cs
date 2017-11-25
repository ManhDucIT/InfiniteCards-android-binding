using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Bakerj.Infinitecards;

namespace InfiniteCards.Droid
{
    public class TransformerToBackStyle2 : TransformerToBackStyle1
    {

        public new void TransformAnimation(View p0, float p1, int p2, int p3, int p4, int p5)
        {
            int positionCount = p4 - p5;

            float scale = (0.8f - 0.1f * p4) + (0.1f * p1 * positionCount);

            p0.ScaleX = scale;
            p0.ScaleY = scale;

            if (p1 < 0.5)
            {
                p0.TranslationX = p2 * p1 * 1.5f;
                p0.RotationY = -45 * p1;
            }
            else
            {
                p0.TranslationX = p2 * 1.5f * (1f - p1);
                p0.RotationY = -45 * p1;
            }
        }

    }
}