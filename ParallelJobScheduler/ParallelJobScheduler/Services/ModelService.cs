using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace ParallelJobScheduler
{
    public class ModelService 
    {
        public ModelService()
        {

        }

        public async Task ColdJob(int i, CancellationToken cancellationToken)
        {
            try
            {
                int count = 0;

                while (count < 5)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    count += 1;
                    Console.WriteLine($"Processing Cold Job Request: {i}");
                    await Task.Delay(1000);
                }
            }

            catch (Exception ex)
            {
                Program.OutputExceptions(ex);
            }
        }

        public async Task HotJob()
        {
            Console.WriteLine("Processing Hot Job Request");
        }
    }
}

