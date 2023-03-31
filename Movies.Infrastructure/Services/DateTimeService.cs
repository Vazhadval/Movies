using Movies.Application.Common.Interfaces;

namespace Movies.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
