using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleApiAndela.Models
{
    [Table("Person", Schema = "Dbo")]
    public class People
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PersonId")]
        public int PersonId { get; set; }

        [Column("JobProfileId")]
        public int JobProfileId { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [NotMapped]
        public string JobTitle { get; set; }

        [NotMapped]
        public string JobDescription { get; set; }

        [NotMapped]
        public string JobLocation { get; set; }
    }
}
