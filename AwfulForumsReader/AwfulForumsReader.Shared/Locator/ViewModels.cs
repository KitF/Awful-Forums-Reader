﻿using System;
using System.Collections.Generic;
using System.Text;
using Windows.ApplicationModel;
using Autofac;
using AwfulForumsReader.Common;
using AwfulForumsReader.ViewModels;

namespace AwfulForumsReader.Locator
{
    public class ViewModels
    {
        public ViewModels()
        {
            if (DesignMode.DesignModeEnabled)
            {
                App.Container = AutoFacConfiguration.Configure();
            }
        }

        public static NewPrivateMessageViewModel NewPrivateMessagePageVm
        {
            get { return App.Container.Resolve<NewPrivateMessageViewModel>(); }
        }

        public static PrivateMessagePageViewModel PrivateMessagePageVm
        {
            get { return App.Container.Resolve<PrivateMessagePageViewModel>(); }
        }

        public static SmiliesPageViewModel SmiliesPageVm
        {
            get { return App.Container.Resolve<SmiliesPageViewModel>(); }
        }

        public static LastPostPageViewModel LastPostPageVm
        {
            get { return App.Container.Resolve<LastPostPageViewModel>(); }
        }

        public static MainForumsPageViewModel MainForumsPageVm
        {
            get { return App.Container.Resolve<MainForumsPageViewModel>(); }
        }

        public static PreviewThreadPageViewModel PreviewThreadPageVm
        {
            get { return App.Container.Resolve<PreviewThreadPageViewModel>(); }
        }


        public static BbCodeListPageViewModel BbCodeListVm
        {
            get { return App.Container.Resolve<BbCodeListPageViewModel>(); }
        }
        public static NewThreadReplyPageViewModel NewThreadReplyVm
        {
            get { return App.Container.Resolve<NewThreadReplyPageViewModel>(); }
        }

        public static PostIconListPageViewModel PostIconListPageVm
        {
            get { return App.Container.Resolve<PostIconListPageViewModel>(); }
        }

        public static NewThreadPageViewModel NewThreadVm
        {
            get { return App.Container.Resolve<NewThreadPageViewModel>(); }
        }

        public static ThreadListPageViewModel ThreadListPageVm
        {
            get { return App.Container.Resolve<ThreadListPageViewModel>(); }
        }

        public static BookmarksPageViewModel BookmarksPageVm
        {
            get { return App.Container.Resolve<BookmarksPageViewModel>(); }
        }

        public static PrivateMessageListViewModel PrivateMessageVm
        {
            get { return App.Container.Resolve<PrivateMessageListViewModel>(); }
        }

        public static ThreadPageViewModel ThreadPageVm
        {
            get { return App.Container.Resolve<ThreadPageViewModel>(); }
        }
    }
}
