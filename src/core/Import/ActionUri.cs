﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Dime.Scheduler.Sdk.Import
{
    public class ActionUri : IImportRequestable
    {
        /// <include file='docs.xml' path='docs/members[@name="TrackedEntity"]/SourceApp/*'/>
        [ImportParameter(nameof(SourceApp))]
        [MaxLength(30)]
        public string SourceApp { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="TrackedEntity"]/SourceType/*'/>
        [ImportParameter(nameof(SourceType))]
        [MaxLength(10)]
        public string SourceType { get; set; }

        [ImportParameter("UrlType")]
        public int UriType { get; set; }

        [ImportParameter(nameof(Uri))]
        [Required]
        public string Uri { get; set; }

        [ImportParameter(nameof(Description))]
        [MaxLength(255)]
        public string Description { get; set; }

        [ImportParameter(nameof(Default))]
        public bool Default { get; set; }

        ImportRequest IImportRequestable.ToImportRequest(TransactionType transactionType)
            => transactionType switch
            {
                TransactionType.Append => CreateAppendRequest(),
                TransactionType.Delete => CreateDeleteRequest(),
                _ => throw new ArgumentOutOfRangeException(nameof(transactionType), transactionType, null)
            };

        private ImportRequest CreateAppendRequest()
            => new(ImportProcedures.ActionUri.Append, this.CreateParameters(TransactionType.Append));

        private ImportRequest CreateDeleteRequest()
            => throw new NotImplementedException("Action does not exist yet in Dime.Scheduler");
    }
}