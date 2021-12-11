using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SampleProject.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class GreeterListDto
    {
        public IEnumerable<string> Values { get; set; }
        public string From { get; internal set; }

        public GreeterListDto(string from, params string[] values)
        {
            this.From = from;
            this.Values = values;
        }

        public void FromMemory()
        {
            this.From = "From Memory";
        }
    }
}
