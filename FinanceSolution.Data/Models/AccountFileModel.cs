using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceSolution.Data.Models
{
    public class AccountFileModel
    {
        [Key]
        public int Id { get; set; }
        public string Data { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }

        [ForeignKey("AccountEntry")]
        public int AccountEntryId { get; set; }
        public AccountEntryModel AccountEntry { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsModified { get; set; }
    }
}