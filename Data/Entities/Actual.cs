using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopulationAPI.Data.Entities
{
    public class Actual
    {
        [Key]
        [Column("RowId")]
        public int RowId { get; set; }

        public int State { get; set; }

        public decimal ActualPopulation { get; set; }

        public decimal ActualHouseholds { get; set; }
    }
}
