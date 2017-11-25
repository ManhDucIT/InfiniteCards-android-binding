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
using Object = Java.Lang.Object;

namespace InfiniteCards.Droid
{
    public class InfiniteCardAdapter : BaseAdapter
    {

        private int[] resIds = { };

        public InfiniteCardAdapter(int[] resIds)
        {
            this.resIds = resIds;
        }

        public override int Count => resIds.Length;

        public override Object GetItem(int position)
        {
            return resIds[position];
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_card, parent, false);
            }

            convertView.SetBackgroundResource(resIds[position]);

            return convertView;
        }
        
    }
}