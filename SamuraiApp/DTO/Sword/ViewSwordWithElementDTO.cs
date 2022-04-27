using SamuraiApp.DTO.Element;

namespace SamuraiApp.DTO.Sword
{
    public class ViewSwordWithElementDTO
    {
        public int id { get; set; }
        public string SwordName { get; set; }
        public int Year { get; set; }
        public int Weight { get; set; }
        public List<ViewElementDTO> Elements { get; set; }
    }
}
