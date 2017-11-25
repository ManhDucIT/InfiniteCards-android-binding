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
    public class ZIndexTransformerToBackStyle1 : Java.Lang.Object, IZIndexTransformer
    {

        public void TransformAnimation(CardItem p0, float p1, int p2, int p3, int p4, int p5)
        {
            if (p1 < 0.4f)
            {
                p0.ZIndex = 1f + 0.01f * p4;
            }
            else
            {
                p0.ZIndex = 1f + 0.01f * p5;
            }
        }

        public void TransformInterpolatedAnimation(CardItem p0, float p1, int p2, int p3, int p4, int p5)
        {
            
        }

    }
}