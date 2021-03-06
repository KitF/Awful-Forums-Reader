﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwfulForumsReader.Core.Tools;

namespace AwfulForumsReader.Core.Entity
{
    public class ForumThreadEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string ImageIconLocation { get; set; }
        // TODO: Add to unit tests.
        public string StoreImageIconLocation { get; set; }

        public string Author { get; set; }

        public int ReplyCount { get; set; }

        public int ViewCount { get; set; }

        public int Rating { get; set; }

        public string RatingImage { get; set; }

        public string KilledBy { get; set; }

        public bool IsSticky { get; set; }

        public bool IsLocked { get; set; }

        public bool IsAnnouncement { get; set; }

        public bool HasBeenViewed { get; set; }

        public bool CanMarkAsUnread { get; set; }

        public int RepliesSinceLastOpened { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public int ScrollToPost { get; set; }

        public string ScrollToPostString { get; set; }

        public long ThreadId { get; set; }

        public int ForumId { get; set; }

        public bool HasSeen { get; set; }

        public virtual ForumEntity ForumEntity { get; set; }

        public bool IsBookmark { get; set; }

        public PlatformIdentifier PlatformIdentifier { get; set; } 

        public ObservableCollection<ForumPostEntity> ForumPosts { get; set; }
        public bool IsPrivateMessage { get; set; }
    }
}
