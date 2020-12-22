using AutoMapper;
using KanbanBoardBlazor.Server.Dal.Repositories;
using KanbanBoardBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomerController(CustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<CustomerDto>> Get()
        {
            var customerEntities = await customerRepository.getAllCustomers();
            var customers = mapper.Map<List<CustomerDto>>(customerEntities);

            return customers.OrderBy(c => c.Name).ToList();

        }
    }
}
