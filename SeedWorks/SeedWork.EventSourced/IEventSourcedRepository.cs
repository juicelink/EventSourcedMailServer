using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedWork.EventSourced
{
    public interface IEventSourcedRepository
    {
        Task Create(string stream, IEnumerable<object> events, Dictionary<string, object> metadata);

        Task Update(string stream, IEnumerable<object> events, Dictionary<string, object> metadata);

        Task Update(string stream, IEnumerable<object> events, Dictionary<string, object> metadata, int version);

        Task<Events> Get(string stream);
    }
}
