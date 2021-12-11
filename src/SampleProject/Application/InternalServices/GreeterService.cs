using SampleProject.Core.InternalServices.Interfaces;
using SampleProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Infra.InternalServices
{
    public class GreeterService : IGreeterService
    {
        public async Task<GreeterListDto> List()
        {
            var values = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
            return await Task.FromResult(new GreeterListDto("FROM FAKE DATABASE", values));
        }
    }
}
