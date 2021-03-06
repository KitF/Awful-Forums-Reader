﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using AwfulForumsReader.Commands;
using AwfulForumsReader.Common;
using AwfulForumsReader.Core.Entity;
using AwfulForumsReader.Core.Manager;
using AwfulForumsReader.Tools;

namespace AwfulForumsReader.ViewModels
{
    public class PostIconListPageViewModel : NotifierBase
    {
        private bool _isLoading;
        private readonly PostIconManager _postIconManager = new PostIconManager();
        private ObservableCollection<PostIconEntity> _postIconEntities = new ObservableCollection<PostIconEntity>();
        private ForumEntity _forumEntity;
        private TextBox _replyBox;
        private PickPostIconCommand _pickPostIconCommand = new PickPostIconCommand();

        public PickPostIconCommand PickPostIconCommand
        {
            get { return _pickPostIconCommand; }
            set { _pickPostIconCommand = value; }
        }

        public TextBox ReplyBox
        {
            get { return _replyBox; }
            set
            {
                SetProperty(ref _replyBox, value);
                OnPropertyChanged();
            }
        }

        public ForumEntity ForumEntity
        {
            get { return _forumEntity; }
            set
            {
                SetProperty(ref _forumEntity, value);
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PostIconEntity> PostIconEntities
        {
            get { return _postIconEntities; }
            set { _postIconEntities = value; }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                SetProperty(ref _isLoading, value);
                OnPropertyChanged();
            }
        }

        public ReplyBoxLocation ReplyBoxLocation { get; set; }

        public async Task Initialize()
        {
            
            ForumEntity = Locator.ViewModels.ThreadListPageVm.ForumEntity;
            if ((PostIconEntities == null || !PostIconEntities.Any()) && ForumEntity != null)
            {
                var test = await _postIconManager.GetPostIcons(ForumEntity);
                PostIconEntities = test.First().List.ToObservableCollection();
            }
            else
            {
                var test = await _postIconManager.GetPmPostIcons();
                PostIconEntities = test.First().List.ToObservableCollection();
            }
        }
    }
}
