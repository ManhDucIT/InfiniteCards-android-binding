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
    public class InfiniteCardAnimationListener : Java.Lang.Object, InfiniteCardView.ICardAnimationListener
    {

        private Context context;

        public InfiniteCardAnimationListener(Context context)
        {
            this.context = context;
        }

        public void OnAnimationEnd()
        {
            Toast.MakeText(context, "Animation Start", ToastLength.Short).Show();
        }

        public void OnAnimationStart()
        {
            Toast.MakeText(context, "Animation End", ToastLength.Short).Show();
        }

    }
}