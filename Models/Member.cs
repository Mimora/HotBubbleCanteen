using System.ComponentModel.DataAnnotations;

namespace HotBubbleCanteen.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Range(1, 3)]
        public int MembershipLevel { get; set; }  // 1 = Bronze, 2 = Silver, 3 = Gold

        // 新增 PromoCode 字段
        public string PromoCode { get; set; } = string.Empty;
    }
}