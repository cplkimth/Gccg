﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Chinook.Data;

public partial class PlaylistTrack
{
    public int PlaylistId { get; set; }

    public int TrackId { get; set; }

    public virtual Playlist Playlist { get; set; }

    public virtual ICollection<PlaylistTrackHistory> PlaylistTrackHistories { get; set; } = new List<PlaylistTrackHistory>();
}