using Arch.EntityFrameworkCore.UnitOfWork;
using Jevstafjev.Anecdotes.AnecdoteApi.Infrastructure;
using Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.Base;

namespace Jevstafjev.Anecdotes.Web.Definitions.UnitOfWork
{
    public class UnitOfWorkDefinition : AppDefinition
    {
        public override void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddUnitOfWork<ApplicationDbContext>();
        }
    }
}
