using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Vault.Core.Repositories;

namespace Vault.Core
{
    public class Reminder
    {
        private readonly ILogger _logger;
        private readonly ILendingRecordRepository _lendingRecordRepository;
        private readonly INotifier _notifier;

        public Reminder(ILendingRecordRepository lendingRecordRepository, INotifier notifier, ILogger logger)
        {
            _lendingRecordRepository = lendingRecordRepository ?? throw new ArgumentNullException(nameof(lendingRecordRepository));
            _notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
            _logger = logger?.ForContext<Reminder>() ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<OperationResult> SendNotifications()
        {
            var result = await _lendingRecordRepository.GetAllLateAsync();
            _logger.Information("Send notifications for {count} users", result.Length);

            var tasks = new List<Task>();
            foreach (var item in result)
            {
                tasks.Add(_notifier.SendAsync(item.Lender, "Where is my book!", "Return it, quickly")); 
            }

            if (tasks.Any())
            {
                Task.WaitAll(tasks.ToArray());
            }

            return new OperationResult();
        }
    }
}
