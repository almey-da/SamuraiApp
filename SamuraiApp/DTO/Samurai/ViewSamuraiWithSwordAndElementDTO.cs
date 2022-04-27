using SamuraiApp.DTO.Sword;

namespace SamuraiApp.DTO.Samurai
{
    public class ViewSamuraiWithSwordAndElementDTO
    {
        public int Id { get; set; }
        public string SamuraiName { get; set; }
        public List<ViewSwordWithElementDTO> Swords { get; set; }
    }
}
