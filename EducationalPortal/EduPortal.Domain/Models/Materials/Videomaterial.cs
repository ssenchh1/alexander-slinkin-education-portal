
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Domain.Models.Materials
{
    [Table("VideoMaterials")]
    public class VideoMaterial : Material
    {
        public int Length { get; set; }

        public Quality Quality { get; set; }
    }
}
