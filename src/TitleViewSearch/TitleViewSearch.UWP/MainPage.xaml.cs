﻿namespace TitleViewSearch.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            LoadApplication(new TitleViewSearch.App());
        }
    }
}
