using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopulationAPI.Data.Entities
{
    public class Estimate
    {
        [Key]
        [Column("RowId")]
        public int Id { get; set; }

        public int State { get; set; }

        public int Districts { get; set; }

        public decimal EstimatesPopulation { get; set; }

        public decimal EstimatesHouseholds { get; set; }
    }
}
