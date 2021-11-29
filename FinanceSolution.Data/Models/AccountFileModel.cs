using System.ComponentModel.DataAnnotations;

namespace FinanceSolution.Data.Models
{
    public class AccountFileModel
    {
        [Key]
        public int Id { get; set; }
        public string Data { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
    }
}