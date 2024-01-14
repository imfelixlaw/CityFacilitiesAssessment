using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.Models;
using ReactApp1.Server.Services;

namespace ReactApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    //[DisableCors]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IForwarderService _forwarderService;

        public ProductController(ILogger<ProductController> logger,
                                 IForwarderService forwarderService)
        {
            _logger = logger;
            _forwarderService = forwarderService;
        }

        [HttpGet]
        public async Task<List<Product>> Get() => await _forwarderService.GetProductFromVendor();
    }
}
