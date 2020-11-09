using CodeChallenge.Domain;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace CodeChallenge.Web.Assignments
{
    public class AssignmentRequestModel
    {
        [Required]
        [MaxLength(1024)]        
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