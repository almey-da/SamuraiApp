using SamuraiApp.DTO.Element;

namespace SamuraiApp.DTO.Samurai
{
    public class CreateSwordElementSamuraiDTO
    {
        public string SwordName { get; set; }
        public int Year { get; set; }
        public int Weight { get; set; }
        public List<CreateElementDTO> Elements { get; set; }
    }
}
