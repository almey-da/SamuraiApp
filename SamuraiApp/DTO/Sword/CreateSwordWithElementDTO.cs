using SamuraiApp.DTO.Element;

namespace SamuraiApp.DTO.Sword
{
    public class CreateSwordWithElementDTO
    {
        public string SwordName { get; set; }
        public int Year { get; set; }
        public int Weight { get; set; }
        public int SamuraiId { get; set; }
        public List<CreateElementDTO> Elements { get; set; }    //create sword dg. elemen-elemennya 
    }
}
