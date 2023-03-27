using System.ComponentModel.DataAnnotations;

namespace testeapi.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }

        public string Uuid { get; set; }

        public bool Enable { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ViewUuid { get => Uuid.Substring(0,8); }

        public BaseModel() {
            CreatedAt = DateTime.Now;
            Enable = true;
            Uuid = Guid.NewGuid().ToString();
        }
    }
}