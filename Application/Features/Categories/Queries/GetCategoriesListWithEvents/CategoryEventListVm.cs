using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class CategoryEventListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryEventDto> Events { get; set; }
    }
}
