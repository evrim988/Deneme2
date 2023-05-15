using Deneme.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Domain.Entities.Common
{
    public class Project : BaseEntity
    {
        [DisplayName("ProjectName")]
        public string ProjeAdı { get; set; }

        [DisplayName("ProjectDescription")]
        public string ProjeAçıklaması { get; set; }
    }
}
