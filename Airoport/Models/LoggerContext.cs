using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Airoport.Models
{
    public class LoggerContext : DbContext
    {
        public DbSet<ExceptionDetail> ExceptionDetails { get; set; }

        public LoggerContext() : base("DefaultConnection")
        {
        }
    }
}