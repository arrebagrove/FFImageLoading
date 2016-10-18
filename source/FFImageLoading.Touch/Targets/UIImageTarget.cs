﻿using System;
using FFImageLoading.Work;
using UIKit;

namespace FFImageLoading.Targets
{
    public class UIImageTarget: Target<UIImage, UIImage>
    {
        private WeakReference<UIImage> _imageWeakReference = null;

        public override void Set(IImageLoaderTask task, UIImage image, bool animated)
        {
            task.CancellationToken.ThrowIfCancellationRequested();

            if (_imageWeakReference == null)
                _imageWeakReference = new WeakReference<UIImage>(image);
            else
                _imageWeakReference.SetTarget(image);
        }

        public UIImage UIImage
        {
            get
            {
                if (_imageWeakReference == null)
                    return null;

                UIImage image = null;
                _imageWeakReference.TryGetTarget(out image);
                return image;
            }
        }
    }
}

