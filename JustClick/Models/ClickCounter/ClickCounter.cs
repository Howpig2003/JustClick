using System.ComponentModel.DataAnnotations;

namespace JustClick.Models.ClickCounter
{
    public class ClickCounter
    {
        [Key]
        public int Id { get; set; } = 1; // 固定 Id 為 1，確保單一記錄

        public int TotalClickCount { get; set; } = 0;

        public DateTime LastClickTime { get; set; } = DateTime.Now;
    }
}
