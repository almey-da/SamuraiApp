using SamuraiApp.DTO.Sword;

namespace SamuraiApp.DTO.Samurai
{
    public class ViewSamuraiWithSwordDTO
    {
        //data samurai
        public int Id { get; set; }
        public string SamuraiName { get; set; }
        public List<ViewSwordDTO> Swords { get; set; }
    }
}
