using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace webapi_agende_mais.src.Repositories;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}

