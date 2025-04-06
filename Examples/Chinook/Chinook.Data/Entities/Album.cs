#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
#endregion

namespace Chinook.Data;

[MetadataType(typeof(AlbumMetaData))]
public partial class Album
{
    [NotMapped]
    public string ArtistName { get; set; }

    [NotMapped]
    public int TrackCount { get; set; }

    partial void ToStringCore(ref string value)
    {
        value = $"{AlbumId} / {Title} / {ArtistName} / {TrackCount}";
    }
}