﻿// <auto-generated />
using System;
using System.Net.Http;
using System.Collections.Generic;
using CarRentalSystem.Admin.RefitInternalGenerated;

/* ******** Hey You! *********
 *
 * This is a generated file, and gets rewritten every time you build the
 * project. If you want to edit it, you need to edit the mustache template
 * in the Refit package */

#pragma warning disable
namespace CarRentalSystem.Admin.RefitInternalGenerated
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
    sealed class PreserveAttribute : Attribute
    {

        //
        // Fields
        //
        public bool AllMembers;

        public bool Conditional;
    }
}
#pragma warning restore

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning disable CS8669 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context. Auto-generated code requires an explicit '#nullable' directive in source.
namespace CarRentalSystem.Admin.Services.Dealers
{
    using System.Threading.Tasks;
    using Models.Dealers;
    using Refit;

    /// <inheritdoc />
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [Preserve]
    [global::System.Reflection.Obfuscation(Exclude=true)]
    partial class AutoGeneratedIDealersService : IDealersService
    {
        /// <inheritdoc />
        public HttpClient Client { get; protected set; }
        readonly IRequestBuilder requestBuilder;

        /// <inheritdoc />
        public AutoGeneratedIDealersService(HttpClient client, IRequestBuilder requestBuilder)
        {
            Client = client;
            this.requestBuilder = requestBuilder;
        }

        /// <inheritdoc />
        Task<IEnumerable<DealerDetailsOutputModel>> IDealersService.All()
        {
            var arguments = new object[] {  };
            var func = requestBuilder.BuildRestResultFuncForMethod("All", new Type[] {  });
            return (Task<IEnumerable<DealerDetailsOutputModel>>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task<DealerDetailsOutputModel> IDealersService.Details(int id)
        {
            var arguments = new object[] { id };
            var func = requestBuilder.BuildRestResultFuncForMethod("Details", new Type[] { typeof(int) });
            return (Task<DealerDetailsOutputModel>)func(Client, arguments);
        }

        /// <inheritdoc />
        Task IDealersService.Edit(int id, DealerInputModel dealer)
        {
            var arguments = new object[] { id, dealer };
            var func = requestBuilder.BuildRestResultFuncForMethod("Edit", new Type[] { typeof(int), typeof(DealerInputModel) });
            return (Task)func(Client, arguments);
        }
    }
}

namespace CarRentalSystem.Admin.Services.Identity
{
    using System.Threading.Tasks;
    using Models.Identity;
    using Refit;

    /// <inheritdoc />
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [Preserve]
    [global::System.Reflection.Obfuscation(Exclude=true)]
    partial class AutoGeneratedIIdentityService : IIdentityService
    {
        /// <inheritdoc />
        public HttpClient Client { get; protected set; }
        readonly IRequestBuilder requestBuilder;

        /// <inheritdoc />
        public AutoGeneratedIIdentityService(HttpClient client, IRequestBuilder requestBuilder)
        {
            Client = client;
            this.requestBuilder = requestBuilder;
        }

        /// <inheritdoc />
        Task<UserOutputModel> IIdentityService.Login(UserInputModel loginInput)
        {
            var arguments = new object[] { loginInput };
            var func = requestBuilder.BuildRestResultFuncForMethod("Login", new Type[] { typeof(UserInputModel) });
            return (Task<UserOutputModel>)func(Client, arguments);
        }
    }
}

namespace CarRentalSystem.Admin.Services.Statistics
{
    using System.Threading.Tasks;
    using Models.Statistics;
    using Refit;

    /// <inheritdoc />
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [Preserve]
    [global::System.Reflection.Obfuscation(Exclude=true)]
    partial class AutoGeneratedIStatisticsService : IStatisticsService
    {
        /// <inheritdoc />
        public HttpClient Client { get; protected set; }
        readonly IRequestBuilder requestBuilder;

        /// <inheritdoc />
        public AutoGeneratedIStatisticsService(HttpClient client, IRequestBuilder requestBuilder)
        {
            Client = client;
            this.requestBuilder = requestBuilder;
        }

        /// <inheritdoc />
        Task<StatisticsOutputModel> IStatisticsService.Full()
        {
            var arguments = new object[] {  };
            var func = requestBuilder.BuildRestResultFuncForMethod("Full", new Type[] {  });
            return (Task<StatisticsOutputModel>)func(Client, arguments);
        }
    }
}

#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning restore CS8669 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context. Auto-generated code requires an explicit '#nullable' directive in source.
