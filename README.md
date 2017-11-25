# InfiniteCards-android-binding
This is an Android Binding library for InfiniteCards which is an infinite card switching UI for Android, support custom animation.

![infinite_cards_image](https://user-images.githubusercontent.com/24780565/33231517-0d1ea6c6-d229-11e7-9edb-b8f95d211cf7.gif)

## Installation 
Install-Package SlidingRootNav

## Attrs
- AnimType : animation type:
  + AnimTypeFront : move the selected card to first
  + AnimTypeSwitch : move the selected card to first, and the first card to the selected position
  + AnimTypeFrontToLast : move the first card to last position
- CardRatio : ratio of the card
- AnimDuration : duration of each card's animation
- AnimAddRemoveDelay : delay of animation of add and remove between each card
- AnimAddRemoveDuration : duration of add and remove each card's animation

## How to use
### layout in xml
```xml
<com.bakerj.infinitecards.InfiniteCardView
        android:id="@+id/view"
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        infiniteCard:animDuration="1000"
        infiniteCard:cardRatio="1"/>

```
### Set Adapter
Just extends the BaseAdapter
```C#
class InfiniteCardAdapter extends BaseAdapter{
  ...
}
mAdapter = new InfiniteCardAdapter(resId);
mCardView.SetAdapter(mAdapter);
```
### Animation transformers and interpolators
#### Default
If you just use all default animations, just do nothing.
```C#
mCardView.SetAnimInterpolator(new LinearInterpolator());
mCardView.SetTransformerToFront(new DefaultTransformerToFront());
mCardView.SetTransformerToBack(new DefaultTransformerToBack());
mCardView.SetZIndexTransformerToBack(new DefaultZIndexTransformerCommon());
```
#### Customisation
```C#
public class TransformerToBackStyle1 : Java.Lang.Object, IAnimationTransformer
{

    public void TransformAnimation(View p0, float p1, int p2, int p3, int p4, int p5)
    {
        int positionCount = p4 - p5;

        float scale = (0.8f - 0.1f * p4) + (0.1f * p1 * positionCount);

        p0.ScaleX = scale;
        p0.ScaleY = scale;

        if (p1 < 0.5)
        {
            p0.RotationX = 180 * p1;
        }
        else
        {
            p0.RotationX = 180 * (1 - p1);
        }
    }

    public void TransformInterpolatedAnimation(View p0, float p1, int p2, int p3, int p4, int p5)
    {
        int positionCount = p4 - p5;

        float scale = (0.8f - 0.1f * p4) + (0.1f * p1 * positionCount);

        p0.TranslationY = -p3 * (0.8f - scale) * 0.5f 
            - p2 * (0.02f * p4 - 0.02f * p1 * positionCount);
    }

}
mCardView.SetTransformerToBack(new TransformerToBackStyle1());

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
mCardView.SetZIndexTransformerToBack(new ZIndexTransformerToBackStyle1());
```

## Special thanks
Thanks to [BakerJQ](https://github.com/yarolegovich) for a native wonderful initial library [Android-InfiniteCards
](https://github.com/BakerJQ/Android-InfiniteCards).

## *License*

InfiniteCards-android-binding is released under the MIT license.

```
MIT License

Copyright (c) 2017 Dang Manh Duc

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
