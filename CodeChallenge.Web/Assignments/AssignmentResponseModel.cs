﻿using CodeChallenge.Domain.Model;
using System;

namespace CodeChallenge.Web.Assignments
{
    public class AssignmentResponseModel
    {
        public AssignmentResponseModel(Salesperson salesperson)
        {
            this.Id = salesperson.Assignment.Id;
            this.SalespersonName = salesperson.Name;
            this.CustomerName = salesperson.Assignment.Customer.Name;
        }

        public Guid Id { get; }

        public string SalespersonName { get; }

        public string CustomerName { get; }
    }
}
