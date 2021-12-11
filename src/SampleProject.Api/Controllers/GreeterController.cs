using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleProject.Core.InternalServices.Interfaces;
using SampleProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreeterController : ControllerBase
    {
        private readonly ILogger<GreeterController> _logger;
        private readonly IGreeterService greeterService;
        private readonly Random _random;

        public GreeterController(Random random, ILogger<GreeterController> logger, IGreeterService greeterService)
        {
            _logger = logger;
            this.greeterService = greeterService;
            _random = random;
        }

        [HttpGet]
        public async Task<GreeterListDto> Get()
        {
            _logger.LogInformation("Obtendo greeter list");
            return await greeterService.List();
        }
    }
}
