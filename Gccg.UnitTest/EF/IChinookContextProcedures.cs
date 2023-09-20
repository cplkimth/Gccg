﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Chinook.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Data
{
    public partial interface IChinookContextProcedures
    {
        Task<List<Album_SearchResult>> Album_SearchAsync(int? ArtistId, string Title, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> InitializeAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<Track_SearchResult>> Track_SearchAsync(string Name, int? ArtistId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}