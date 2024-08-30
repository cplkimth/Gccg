﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Chinook.Data;

public partial class Track
{
    public int TrackId { get; set; }

    public string Name { get; set; }

    public int? AlbumId { get; set; }

    public bool BitCol { get; set; }

    public bool? BitColNull { get; set; }

    public byte TinyIntCol { get; set; }

    public byte? TinyIntColNull { get; set; }

    public short SmallIntCol { get; set; }

    public short? SmallIntColNull { get; set; }

    public long BigIntCol { get; set; }

    public long? BigIntColNull { get; set; }

    public string CharCol { get; set; }

    public string CharColNull { get; set; }

    public string VarCharCol { get; set; }

    public string VarCharColNull { get; set; }

    public string NcharCol { get; set; }

    public string NcharColNull { get; set; }

    public string NvarCharCol { get; set; }

    public string NvarCharColNull { get; set; }

    public byte[] BinaryCol { get; set; }

    public byte[] BinaryColNull { get; set; }

    public DateOnly DateCol { get; set; }

    public DateOnly? DateColNull { get; set; }

    public DateTime DateTimeCol { get; set; }

    public DateTime? DateTimeColNull { get; set; }

    public DateTime SmallDateTimeCol { get; set; }

    public DateTime? SmallDateTimeColNull { get; set; }

    public decimal DecimalCol { get; set; }

    public decimal? DecimalColNull { get; set; }

    public double FloatCol { get; set; }

    public double? FloatColNull { get; set; }

    public float RealCol { get; set; }

    public float? RealColNull { get; set; }

    public decimal SmallMoneyCol { get; set; }

    public decimal? SmallMoneyColNull { get; set; }

    public TimeOnly TimeCol { get; set; }

    public TimeOnly? TimeColNull { get; set; }

    public Guid GuidCol { get; set; }

    public Guid? GuidColNull { get; set; }

    public byte[] VarBinaryCol { get; set; }

    public byte[] VarBinaryColNull { get; set; }

    public DateOnly DateOnlyCol { get; set; }

    public TimeOnly TimeOnlyCol { get; set; }

    public DateOnly? DateOnlyColNull { get; set; }

    public TimeOnly? TimeOnlyColNull { get; set; }

    public int MediaTypeId { get; set; }

    public int GenreId { get; set; }

    public byte[] TimestampCol { get; set; }

    public virtual Album Album { get; set; }

    public virtual Genre Genre { get; set; }

    public virtual MediaType MediaType { get; set; }

    public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; } = new List<PlaylistTrack>();
}