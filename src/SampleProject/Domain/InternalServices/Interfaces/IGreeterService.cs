using SampleProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Core.InternalServices.Interfaces
{
    public interface IGreeterService
    {
        Task<GreeterListDto> List();
    }
}
