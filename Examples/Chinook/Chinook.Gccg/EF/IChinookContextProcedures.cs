﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
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
        Task<int> usp_GetMaxIdAsync(string entity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<usp_GetSystemTimeResult>> usp_GetSystemTimeAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> usp_InitializeAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
