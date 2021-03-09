using System;
using System.Collections.Generic;
using System.Text;
using Vidly.Domain.Entities;

namespace Vidly.Application.Contracts.Presistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
    }
}
