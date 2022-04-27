namespace SamuraiApp.DTO.Samurai
{
    public class CreateSamuraiWithSwordAndElementDTO
    {
        public string SamuraiName { get; set; }
        public List<CreateSwordElementSamuraiDTO> Swords { get; set; }
    }
}
