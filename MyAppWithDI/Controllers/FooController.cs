using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyApp;

namespace MyAppWithDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FooController : ControllerBase
    {
        private readonly IFooService fooService;

        public FooController(IFooService fooService)
        {
            this.fooService = fooService;
        }

        [HttpGet]
        public string Foo()
        {
           return this.fooService.Foo();
        }
    }
}
