using CodeChallenge.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace CodeChallenge.Web.Assignments
{
    [ApiController]
    [Route("/api/assignments")]
    public class AssignmentsController : ControllerBase
    {
        private readonly CustomerAssignmentService service;
        private readonly ISalesRosterRepository rosterRepository;

        public AssignmentsController(
            CustomerAssignmentService service,
            ISalesRosterRepository rosterRepository)
        {
            this.service = service;
            this.rosterRepository = rosterRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var assignments = this.rosterRepository.Get()
                .Salespeople
                .Where(sp => sp.Assignment != null)
                .Select(sp => new AssignmentResponseModel(sp));
            return this.Ok(assignments);
        }

        [HttpGet("{assignmentId}")]
        public IActionResult GetById(Guid assignmentId)
        {
            var salesperson = this.service.GetSalespersonWithAssignment(assignmentId);
            return salesperson != null
                ? (IActionResult)this.Ok(new AssignmentResponseModel(salesperson))
                : (IActionResult)this.NotFound($"Could not find assignment {assignmentId}.");
        }

        [HttpDelete("{assignmentId}")]
        public IActionResult Delete(Guid assignmentId)
        {
            this.service.DeleteAssignment(assignmentId);
            return this.NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] AssignmentRequestModel model)
        {
            var customer = model.ToCustomer();
            var salesperson = this.service.AssignCustomer(customer);
            if (salesperson != null)
            {
                return this.CreatedAtAction(
                    nameof(this.GetById),
                    new { assignmentId = salesperson.Assignment.Id },
                    new AssignmentResponseModel(salesperson));
            }

            return this.Problem(
                "There are no salespeople currently available.",
                statusCode: (int)HttpStatusCode.Conflict);
        }
    }
}
