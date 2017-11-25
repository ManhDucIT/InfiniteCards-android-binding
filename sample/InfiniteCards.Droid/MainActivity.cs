using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views.Animations;
using Com.Bakerj.Infinitecards;
using Com.Bakerj.Infinitecards.Transformer;

namespace InfiniteCards.Droid
{
    [Activity(Label = "InfiniteCards.Droid", MainLauncher = true, Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {

        private InfiniteCardView mCardView;
        private BaseAdapter mAdapter1, mAdapter2;

        private int[] resId = {
            Resource.Mipmap.pic1,
            Resource.Mipmap.pic2,
            Resource.Mipmap.pic3,
            Resource.Mipmap.pic4,
            Resource.Mipmap.pic5};

        private bool mIsAdapter1 = true;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            mCardView = FindViewById<InfiniteCardView>(Resource.Id.view);

            mAdapter1 = new InfiniteCardAdapter(resId);
            mAdapter2 = new InfiniteCardAdapter(resId);

            mCardView.SetAdapter(mAdapter1);
            mCardView.SetCardAnimationListener(new InfiniteCardAnimationListener(this));

            InitButtons();
        }

        private void InitButtons()
        {
            FindViewById<Button>(Resource.Id.pre).Click += (sender, args) =>
            {
                if (mIsAdapter1)
                {
                    SetStyle2();
                    mCardView.BringCardToFront(mAdapter1.Count - 1);
                }
                else
                {
                    SetStyle1();
                    mCardView.BringCardToFront(mAdapter2.Count - 1);
                }
            };

            FindViewById<Button>(Resource.Id.next).Click += (sender, args) =>
            {
                if (mIsAdapter1)
                {
                    SetStyle2();
                }
                else
                {
                    SetStyle3();
                }
                mCardView.BringCardToFront(1);
            };

            FindViewById<Button>(Resource.Id.change).Click += (sender, args) =>
            {
                if (mCardView.IsAnimating)
                {
                    return;
                }

                mIsAdapter1 = !mIsAdapter1;

                if (mIsAdapter1)
                {
                    SetStyle2();
                    mCardView.SetAdapter(mAdapter1);
                }
                else
                {
                    SetStyle1();
                    mCardView.SetAdapter(mAdapter2);
                }
            };
        }

        private void SetStyle1()
        {
            mCardView.Clickable = true;
            mCardView.SetAnimType(InfiniteCardView.AnimTypeFront);
            mCardView.SetAnimInterpolator(new LinearInterpolator());
            mCardView.SetTransformerToFront(new DefaultTransformerToFront());
            mCardView.SetTransformerToBack(new DefaultTransformerToBack());
            mCardView.SetZIndexTransformerToBack(new DefaultZIndexTransformerCommon());
        }

        private void SetStyle2()
        {
            mCardView.Clickable = true;
            mCardView.SetAnimType(InfiniteCardView.AnimTypeSwitch);
            mCardView.SetAnimInterpolator(new OvershootInterpolator(-18));
            mCardView.SetTransformerToFront(new DefaultTransformerToFront());
            mCardView.SetTransformerToBack(new TransformerToBackStyle1());
            mCardView.SetZIndexTransformerToBack(new ZIndexTransformerToBackStyle1());
        }

        private void SetStyle3()
        {
            mCardView.Clickable = false;
            mCardView.SetAnimType(InfiniteCardView.AnimTypeFrontToLast);
            mCardView.SetAnimInterpolator(new OvershootInterpolator(-8));
            mCardView.SetTransformerToFront(new DefaultCommonTransformer());
            mCardView.SetTransformerToBack(new TransformerToBackStyle2());
            mCardView.SetZIndexTransformerToBack(new ZIndexTransformerToBackStyle2());
        }

    }
}

