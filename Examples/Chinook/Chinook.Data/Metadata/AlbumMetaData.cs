//<auto-generated> This file has been generated by Gccg. </auto-generated>
#region using
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
 
#endregion

namespace Chinook.Data;


public class AlbumMetaData
{
    
	public int AlbumId {get; set;}

	public int ArtistId {get; set;}

	public string Title {get; set;}
} 
