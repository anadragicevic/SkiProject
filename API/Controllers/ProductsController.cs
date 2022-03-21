using Infrastructure.Data;

namespace API.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }
    }
}