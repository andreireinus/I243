using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vault.Core.Entities;
using Vault.Core.Repositories;

namespace Vault.Core
{
    public class ReportInteractor
    {
        public class Row
        {
            public string Author { get; set; }
            public string Title { get; set; }

            public string LoadedTo { get; set; }
            public DateTime? LoanedUntil { get; set; }
        }


        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<LendingRecord> _lendingRepository;

        public ReportInteractor(IRepository<Book> bookRepository, IRepository<LendingRecord> lendingRepository)
        {
            _bookRepository = bookRepository;
            _lendingRepository = lendingRepository;
        }

        public Row[] Available()
        {
            return _bookRepository.Query()
                .Where(a => a.IsAvailable)
                .Select(b => new Row
                {
                    Author = b.Author,
                    Title = b.Name,
                    LoadedTo = "",
                    LoanedUntil = null
                })
                .ToArray();
        }

        public Row[] LoanedOut()
        {
            return _lendingRepository.Query()
                .Where(a => a.Returned == null)
                .Select(r => new Row
                {
                    Author = r.Book.Author,
                    Title = r.Book.Name,
                    LoadedTo = r.Lender.Name,
                    LoanedUntil = r.To
                })
                .ToArray();
        }

        public Row[] OverDeadline()
        {
            return _lendingRepository.Query()
                .Where(a => a.Returned == null)
                .Where(a => a.To > DateTime.Now)
                .Select(r => new Row
                {
                    Author = r.Book.Author,
                    Title = r.Book.Name,
                    LoadedTo = r.Lender.Name,
                    LoanedUntil = r.To
                })
                .ToArray();
        }
    }
}
