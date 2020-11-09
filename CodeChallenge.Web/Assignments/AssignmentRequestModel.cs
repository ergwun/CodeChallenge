using CodeChallenge.Domain.Model;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Web.Assignments
{
    public class AssignmentRequestModel
    {
        [Required]
        [MaxLength(70)]
        public string CustomerName { get; set; }

        [Required]
        public bool SpeaksGreek { get; set; }

        public CarType? CarTypePreference { get; set; }

        public Customer ToCustomer()
        {
            return new Customer(this.CustomerName, this.SpeaksGreek, this.CarTypePreference);
        }
    }
}